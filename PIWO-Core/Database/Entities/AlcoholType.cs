namespace PIWO_Core.Database.Entities
{
    public enum AlcoholTypeId
    {
        Beer = 1,
        Vodka,
        Wine,
        Mead,
        Cider,
        Whisky,
        Drink,
        Gin,
        Brandy,
        Rum,
        Tequila,
        RectifiedSpirit,
    }
    internal class AlcoholType
    {
        public AlcoholTypeId Id { get; set; }
        public string Name { get; set; }
    }
}
