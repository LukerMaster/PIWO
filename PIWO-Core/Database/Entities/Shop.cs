namespace PIWO_Core.Database.Entities
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public City? City { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
