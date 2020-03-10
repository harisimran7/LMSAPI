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
    public class EntityBaseDbConfiguration : IEntityTypeConfiguration<EntityBase>
    {
        public void Configure(EntityTypeBuilder<EntityBase> builder)
        {
            builder.HasNoDiscriminator();
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}
