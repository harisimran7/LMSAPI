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
    public class CourseDbConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {

            builder.HasNoDiscriminator();
            #region Patient

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            #endregion

            //builder.HasOne(x => x.Duration);
            builder.OwnsOne<Period>(x => x.Duration);
        }
    }
}
