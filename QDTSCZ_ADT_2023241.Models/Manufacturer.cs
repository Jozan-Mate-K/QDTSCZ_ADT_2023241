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
    [Table("Manufacturer")]
    public class Manufacturer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Instrument> Instruments { get; set; }

        public Manufacturer()
        {
            Instruments = new HashSet<Instrument>();
        }

        public override string ToString()
        {
            return $"[{Id}]: {Name} ";
        }
    }
}
