using System.ComponentModel.DataAnnotations;

namespace gesdette15.Models
{
    public class Dette
    {
        [Key]
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public DateTime Date { get; set; }
        public float Montant { get; set; }

        public override string ToString()
        {
            return $"Dette n°{Id}, du {Date:dd/MM/yyyy} pour {Montant}";
        }
    }
}