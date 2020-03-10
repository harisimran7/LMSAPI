API = false;


function LMSInitialize()
{

    console.log('test LMSInitialize');
}


function getAPIHandle() {
  
    console.log("getAPIHandle test");
    var win = window;

    if (win.parent && win.parent != win) {
        this.findAPI(win.parent);
    }

    if (!this.API && win.top.opener) {
        this.findAPI(win.top.opener);
    } else if (!this.API) {
        console.log("Unable to find API adapter");   
    }
}

function findAPI(win) {
    console.log("findAPI test");
    var findAttempts = 0,
        findAttemptLimit = 500;
    
    for (findAttempts; findAttempts < findAttemptLimit; findAttempts++) {
    
        if (win["API"] && (this.version === "1.2" || this.version === "Auto" )) {
            this.API = win["API"];
            this.version = "1.2";
            break;  
        } else if (win["API_1484_11"] && (this.version === "2004" || this.version === "Auto" )) {
            this.API = win["API_1484_11"];
            this.version = "2004";
            break;
        } else if (win.parent && win.parent != win) {
            findAttempts++;
            win = win.parent;
        }
    }   
};