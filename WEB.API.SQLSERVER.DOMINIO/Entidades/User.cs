using LinqToDB.Mapping;

namespace WEB.API.SQLSERVER.DOMINIO.Entidades
{
    [Table("User")]
    public class User
    {
        [PrimaryKey, Identity]
        public int? Id { get; set; }

        [Column("Email")]
        public string? Email { get; set; }

        [Column("UserName")]
        public required string UserName { get; set; }

        [Column("Role")]
        public string? Role { get; set; }

        [Column("Password")]
        public required string Password { get; set; }
    }
}