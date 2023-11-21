using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QDTSCZ_ADT_2023241.Models
{
    internal class Manufacturer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Instrument> Instruments { get; set; }
    }
}
