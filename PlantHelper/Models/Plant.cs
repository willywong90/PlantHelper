using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlantHelper.Models
{
    public enum Frequency
    {
        Low,
        Medium,
        High
    }

    public class Plant
    {
        public string CommonName { get; set; }
        public string BinomialName { get; set; }
        public string Notes { get; set; }
        public Frequency WateringFrequency { get; set; }
        public DateTime LastWaterDate { get; set; }

        public Plant(string commonName, string binomialName = "", string notes = "") 
        {
            CommonName = commonName;
            BinomialName = binomialName;
            Notes = notes;
        }

        public Plant(string commonName, string binomialName, string notes, Frequency wateringFrequency, DateTime lastWaterDate) : this(commonName, binomialName, notes) {
            WateringFrequency = wateringFrequency;
            LastWaterDate = lastWaterDate;
        }

        public DateTime getNextWaterDate() { 
            DateTime date = LastWaterDate.AddDays((int)WateringFrequency);
            return date;
        }
    }
}
