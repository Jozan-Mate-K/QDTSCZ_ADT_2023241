using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QDTSCZ_ADT_2023241.Models
{
    [Table("Bands")]
    public class Band
    {
        [Range(1, 5)]
        public int? Priority {  get; set; }
        
        public int? Balance { get; set; }
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Instrument> RequiredInstruments { get; set; }

        public Band()
        {
            RequiredInstruments = new HashSet<Instrument>();
        }

        public override string ToString()
        {
            if(Balance == null)
            {
                return $"[{Id}]: {Name} has no checking account";
            }
            else
            {
                if(Priority == null)
                {
                    return $"[{Id}]: {Name} has a balance of {Balance}";

                }
                else
                {
                    return $"[{Id}]: {Name} has a balance of {Balance} with a priority of {Priority}";

                }
            }
        }

    }
}
