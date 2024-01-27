using System.ComponentModel;

namespace WEB.API.SQLSERVER.DOMINIO.Enums
{
    public enum ECombustivel
    {
        [Description ("Etanol / Gasolina")]
        Flex,

        [Description("Gasolina")]
        Gasolina,

        [Description("Diesel")]
        Diesel,

        [Description("Hibrido")]
        Hibrido,

        [Description("Elétrico")]
        Eletrico
    }
}
