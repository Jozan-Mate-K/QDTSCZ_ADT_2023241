﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace QDTSCZ_ADT_2023241.Models
{
    public enum instrumentTypeEnum {STRINGS, PERCUSSION, WIND, SYNTH }
    [Table("Instruments")]
    public class Instrument
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        public int Year { get; set; }
        [Required]
        public instrumentTypeEnum Type{ get; set; }
        public string Color {  get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Manufacturer Manufacturer { get; set; }
        [ForeignKey(nameof(Manufacturer))]
        public int ManufacturerId { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Band Band { get; set; }
        [ForeignKey(nameof(Band))]
        public int BandId { get; set; }


        public override string ToString()
        {
            return $"{Manufacturer} {Name} has been rented out by {Band.Name} for their next tour";
        }
    }
}