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
    public class MemberDbConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {

            builder.HasNoDiscriminator();
            #region Patient

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            #endregion

            builder.HasMany<Address>(x => x.Address);

            builder.OwnsOne<HumanName>(x => x.Name);
            //builder.OwnsOne<Period>(x => x.Name.Period);
            //builder.OwnsOne<HumanName>(x => x.NameAR);
        }
    }
}
