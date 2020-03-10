using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMSData.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Services;

namespace LMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IJwtFactory jwtFactory;
        private readonly JwtIssuerOptions jwtOptions;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        //private readonly ILogger _logger;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            IJwtFactory _jwtFactory,
            IOptions<JwtIssuerOptions> _jwtOptions)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            jwtFactory = _jwtFactory;
            jwtOptions = _jwtOptions.Value;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    var userToVerify = await _userManager.FindByNameAsync(model.UserName);
                    var identity = await Task.FromResult(jwtFactory.GenerateClaimsIdentity(model.UserName, userToVerify.Id));

                    if (identity == null)
                    {

                        return BadRequest();
                    }

                    var jwt = await Tokens.GenerateJwt(identity, jwtFactory, model.UserName, jwtOptions, new JsonSerializerSettings { Formatting = Formatting.Indented });
                    
                    return new OkObjectResult(jwt);

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return new BadRequestObjectResult(ModelState);
                }
            }


            // If we got this far, something failed, redisplay form
            //return View(model);
            return new BadRequestObjectResult(ModelState);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            //ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //_logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
                    //await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    //_logger.LogInformation("User created a new account with password.");
                    //return RedirectToLocal(returnUrl);
                    return new OkResult();
                }
                AddErrors(result);

                //if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));
                if (!result.Succeeded) return new BadRequestObjectResult(ModelState);

            }

            // If we got this far, something failed, redisplay form
            //return View(model);
            return new BadRequestObjectResult(ModelState);
        }

        [HttpPost("logout")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<string>> Logout()
        {
            await _signInManager.SignOutAsync();
            //_logger.LogInformation("User logged out.");
            //return RedirectToAction(nameof(HomeController.Index), "Home");
            return string.Empty;
        }
        
        [HttpGet("confirmemail")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> ConfirmEmail(string userId, string code)
        {
            //if (userId == null || code == null)
            //{
            //    return RedirectToAction(nameof(HomeController.Index), "Home");
            //}

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{userId}'.");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            //return View(result.Succeeded ? "ConfirmEmail" : "Error");

            return result.Succeeded ? "ConfirmEmail" : "Error";
        }
        [HttpPost("forget")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    //return RedirectToAction(nameof(ForgotPasswordConfirmation));
                    return null;
                }

                // For more information on how to enable account confirmation and password reset please
                // visit https://go.microsoft.com/fwlink/?LinkID=532713
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                //var callbackUrl = Url.ResetPasswordCallbackLink(user.Id, code, Request.Scheme);
                await _emailSender.SendEmailAsync(model.Email, "Reset Password",
                   $"Please reset your password by clicking here: <a href=''>link</a>");
                //return RedirectToAction(nameof(ForgotPasswordConfirmation));
                return null;
            }

            // If we got this far, something failed, redisplay form
            //return View(model);
            return null;
        }
        
        [HttpPost("reset")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return null;
            }
            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                //return RedirectToAction(nameof(ResetPasswordConfirmation));
                return null;
            }
            AddErrors(result);
            return null;
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        #endregion

        [HttpPost("refresh")]
        [AllowAnonymous]
        public IActionResult Refresh(string token, string refreshToken)
        {
            //var principal = jwtFactory.GetPrincipalFromExpiredToken(token);
            //var username = principal.Identity.Name;
            //var username = principal.Claims.Where(x => x.Type.Contains("nameidentifier")).SingleOrDefault().Value;
            //var id = principal.Claims.SingleOrDefault().Value;
            //var id = principal.Claims.Where(x => x.Type.Contains("cid")).SingleOrDefault().Value;
            var username = "asif.raza@gmail.com";
                var id = "1";
            /*
            var savedRefreshToken = GetRefreshToken(username); //retrieve the refresh token from a data store
            if (savedRefreshToken != refreshToken)
                throw new SecurityTokenException("Invalid refresh token");
                */
            var newJwtToken = jwtFactory.GenerateEncodedToken(username, jwtFactory.GenerateClaimsIdentity(username, id));
            var newRefreshToken = jwtFactory.GenerateRefreshToken();
            //DeleteRefreshToken(username, refreshToken);
            //SaveRefreshToken(username, newRefreshToken);

            return new ObjectResult(new
            {
                token = newJwtToken,
                refreshToken = newRefreshToken
            });
        }
    }
}