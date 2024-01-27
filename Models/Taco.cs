namespace Taco_Food_Truck.Models
{
    public class Taco
    {
        public int Id { get; set; }
        public bool SoftShell { get; set; }
        public string Name { get; set; }

        public int Price { get; set; }
        public bool Chips { get; set; }
    }
}
