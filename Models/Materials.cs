using ProiectOptDezAplWeb.Models.Base;

namespace ProiectOptDezAplWeb.Models
{
    public class Materials: BaseEntity
    {
        public int Id { get; set; }
        public string MaterialName { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
        public string Type { get; set; }
    }
}
