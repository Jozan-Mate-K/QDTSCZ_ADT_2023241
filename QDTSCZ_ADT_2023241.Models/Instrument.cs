using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QDTSCZ_ADT_2023241.Models
{
    public enum instrumentTypeEnum {STRINGS, PERCUSSION, WIND, SYNTH }
    internal class Instrument
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public instrumentTypeEnum Type{ get; set; }
        public string Color {  get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
    }
}