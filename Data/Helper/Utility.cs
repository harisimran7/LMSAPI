using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMSData.Helper
{
    public static class Utility
    {
        /*
        public static string GetTableName(DbContext context, Type entityType)
        {
            IEntityType entity = context.Model.FindEntityType(entityType.ToString());
            return entity.Name;
        }

        public static string GetSchemaName(DbContext context, Type entityType)
        {
            IEntityType entity = context.Model.FindEntityType(entityType.ToString());
            //var schema = entityType.GetSchema();
            return entity.DefiningNavigationName;
        }
        */
    }
}
