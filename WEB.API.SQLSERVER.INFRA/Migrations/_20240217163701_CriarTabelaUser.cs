using FluentMigrator;

namespace WEB.API.SQLSERVER.INFRA.Migrations
{
    [Migration(20240217163701)]
    public class _20240217163701_CriarTabelaUser : Migration
    {
        public override void Up()
        {
            Create.Table("User")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("UserName").AsString().NotNullable()
                .WithColumn("Email").AsString().NotNullable()
                .WithColumn("Role").AsString().NotNullable()
                .WithColumn("Password").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("User");
        }
    }
}
