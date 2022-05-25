namespace PIWO_Core.Database.Entities
{
    
    public class Alcohol
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public decimal Voltage { get; set; }
        internal AlcoholType Type { get; set; }
        public AlcoholTypeId TypeId { get; set; }
    }
}
