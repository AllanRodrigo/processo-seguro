using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace SegurosAllanAPI.Models
{
    public class Seguro
    {
        public int Id { get; set; }
        public double TaxaRisco { get; set; }
        public double PremioRisco { get; set; }
        public double PremioPuro { get; set; }
        public double PremioComercial { get; set; }

        public Segurado Segurado { get; set; }
        public Veiculo Veiculo { get; set; }
    }

    public class SeguroRequest
    {
        public long Cpf { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public double Valor { get; set; }
    }
}
