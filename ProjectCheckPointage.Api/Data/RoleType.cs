using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectCheckPointage.Api.Data
{
    public class RoleType
    {
        public RoleType()
        {

        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleTypeID { get; set; }
        public string CodeRole { get; set; }
        public string Libelle { get; set; }
    }
}
