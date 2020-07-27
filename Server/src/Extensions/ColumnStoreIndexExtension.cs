using ControleSocial.Domain.Models;

namespace Microsoft.EntityFrameworkCore.Migrations
{
    public static class ColumnStoreIndexExtension
    {
        public static void UpColumnStoreIndex(this MigrationBuilder migrationBuilder, string tableName, string schema = "dbo")
        {
            migrationBuilder.Sql(@$"
                ALTER TABLE [{schema}].[{tableName}] DROP CONSTRAINT [PK_{tableName}]
                GO
                CREATE CLUSTERED COLUMNSTORE INDEX [PK_CS_{tableName}] ON [{schema}].[{tableName}]
                GO",
                false
            );
        }

        public static void DownColumnStoreIndex(this MigrationBuilder migrationBuilder, string tableName, string schema = "dbo")
        {
            migrationBuilder.Sql(@$"
                DROP INDEX [PK_CS_{tableName}] ON [{schema}].[{tableName}]
                GO
                ALTER TABLE [{schema}].[{tableName}] ADD CONSTRAINT [PK_{tableName}] PRIMARY KEY CLUSTERED
                (
                    [{nameof(IEntity.Id)}] ASC
                )
                GO",
                false
            );
        }
    }
}
