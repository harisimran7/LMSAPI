using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using LMSData.Model;

namespace LMSData
{
    public class AddressDbConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {

            //builder.HasNoDiscriminator();
            #region Patient

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            #endregion

            builder.OwnsOne<Period>(x => x.Period);
        }
    }
}
