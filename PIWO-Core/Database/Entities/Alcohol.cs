namespace PIWO_Core.Database.Entities
{
    
    public class Alcohol
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        /// <summary>
        /// Alcohol volumetric percentage. In whole percents, ex. 4.5 if 4.5%.
        /// </summary>
        public decimal Voltage { get; set; }
        /// <summary>
        /// Whole drink volume - In liters. 0.3 = 300ml.
        /// </summary>
        public decimal Volume { get; set; }
        internal AlcoholType Type { get; set; }
        public AlcoholTypeId TypeId { get; set; }
    }
}
