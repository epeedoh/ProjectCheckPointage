using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectCheckPointage.Api.Data
{
    public class Utilisateur
    {

        public Utilisateur()
        {

        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UtilisateurID { get; set; }
        public string? Nom { get; set; }
        public string? Prenoms { get; set; }
        public string? NomComplet { get; set; }
        public string? Email { get; set; }
        public string? Telephone { get; set; }
        public string? Username { get; set; }

        // public byte[] Image { get; set; }
        //public byte[] PasswordHash { get; set; }
        public string? PasswordHash { get; set; }

        public byte[]? PasswordSalt { get; set; }
        public DateTime? DateCreation { get; set; }
        public int RoleTypeID { get; set; }
        public RoleType RoleType { get; internal set; }
    }


}
