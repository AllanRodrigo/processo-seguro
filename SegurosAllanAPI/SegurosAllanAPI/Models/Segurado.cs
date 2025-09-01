using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SegurosAllanAPI.Models
{
    public class Segurado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Cpf { get; set; }
        
        public string? Nome { get; set; }
        
        public int? Idade { get; set; }
    }
}
