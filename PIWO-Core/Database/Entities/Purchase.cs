namespace PIWO_Core.Database.Entities
{
    public class Purchase
    {
        public int Id { get; set; }
        public Alcohol Alcohol { get; set; }
        public Shop Shop { get; set; }
        public DateTime Date { get; set; }

        /// <summary>
        /// Price of only the alcohols bought. Other items excluded.
        /// </summary>
        public decimal Price { get; set; }
    }
}
