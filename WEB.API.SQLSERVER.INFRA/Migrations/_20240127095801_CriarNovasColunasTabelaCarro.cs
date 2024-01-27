using FluentMigrator;

namespace WEB.API.SQLSERVER.INFRA.Migrations
{

    [Migration(20240127095801)]
    public class _20240127095801_CriarNovasColunasTabelaCarro : Migration
    {
        public override void Up()
        {
            Alter.Table("Carro")
                .AddColumn("Modelo").AsString().NotNullable()
                .AddColumn("Versao").AsString().NotNullable()
                .AddColumn("Cor").AsString().NotNullable()
                .AddColumn("Combustivel").AsInt32().NotNullable()
                .AddColumn("Usado").AsBoolean().WithDefaultValue(false)
                .AddColumn("PrecoCusto").AsDecimal().Nullable()
                .AddColumn("PrecoVenda").AsDecimal().Nullable()
                .AddColumn("AnoFabricacao").AsDateTime().Nullable()
                .AddColumn("AnoModelo").AsDateTime().Nullable()
                .AddColumn("DataDeCadastro").AsDateTime().Nullable()
                .AddColumn("DataUltimaAtualizacao").AsDateTime().Nullable();
        }
        public override void Down()
        {
        }
    }
}
