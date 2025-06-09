using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectCheckPointage.Api.Data
{
    public class Sexe
    {
        public Sexe()
        {

        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SexeID { get; set; }
        public string CodeSexe { get; set; }
        public string Libelle { get; set; }
    }
}
