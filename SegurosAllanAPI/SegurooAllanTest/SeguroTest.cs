using Microsoft.AspNetCore.Mvc;
using SegurosAllanAPI.Controllers;
using SegurosAllanAPI.Models;
using System.Threading.Tasks;

namespace SegurooAllanTest
{
    public class SeguroTest
    {
        [Fact(DisplayName = "Validar Calculo de Seguro, quando retornado com sucesso")]
        public void getCalcularSeguro_ReturnSuccess()
        {
            const double experado = 270.375;

            SegurosController chamada = new SegurosController();

            Seguro result = chamada.calcularSeguro(10000);
                        
            Assert.Equal(experado, result.PremioComercial);
        }
    }
}