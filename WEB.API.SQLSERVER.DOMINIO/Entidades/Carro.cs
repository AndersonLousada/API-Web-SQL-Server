using LinqToDB.Mapping;
using WEB.API.SQLSERVER.DOMINIO.Enums;

namespace WEB.API.SQLSERVER.DOMINIO.Entidades
{
    [Table("Carro")]
    public sealed class Carro
    {
        [PrimaryKey, Identity]
        public int? Id { get; set; }

        [Column("DataDeCadastro")]
        public DateTime? DataDeCadastro { get; set; }

        [Column("DataUltimaAtualizacao")]
        public DateTime? DataUltimaAtualizacao { get; set; }

        [Column("Marca")]
        public string? Marca { get; set; }

        [Column("Modelo")]
        public string? Modelo { get; set; }

        [Column("Versao")]
        public string? Versao { get; set; }

        [Column("Cor")]
        public string? Cor { get; set; }

        [Column("Combustivel")]
        public ECombustivel Combustivel { get; set; }

        [Column("Usado")]
        public bool Usado { get; set; }

        [Column("PrecoCusto")]
        public decimal PrecoCusto { get; set; }

        [Column("PrecoVenda")]
        public decimal PrecoVenda { get; set; }

        [Column("AnoFabricacao")]
        public DateTime AnoFabricacao { get; set; }

        [Column("AnoModelo")]
        public DateTime AnoModelo { get; set; }
    }
}