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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Instrument> RequiredInstruments { get; set; }
        [Range(1, 5)]
        public int Priority {  get; set; }
    }
}
