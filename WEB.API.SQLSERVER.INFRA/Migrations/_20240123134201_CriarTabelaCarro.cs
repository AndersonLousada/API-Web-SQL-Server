using FluentMigrator;

namespace WEB.API.SQLSERVER.INFRA.Migrations
{
    [Migration(20240123134201)]
    public class _20240123134201_CriarTabelaCarro : Migration
    {
        public override void Up()
        {
            Create.Table("Carro")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Marca").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Carro");
        }
    }
}