using ProiectOptDezAplWeb.Models.Base;

namespace ProiectOptDezAplWeb.Models
{
    public class Worker: BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname {  get; set; }
        public int SalaryNET { get; set; }
        public int Age {  get; set; }
        public int Experience { get; set; }

    }
}
