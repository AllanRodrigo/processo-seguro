using System.Text.Json.Serialization;

namespace SegurosAllanAPI.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public double Valor { get; set; }
    }
}
