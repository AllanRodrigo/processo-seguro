using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SegurosAllanAPI.Data;
using SegurosAllanAPI.Models;
using SegurosAllanAPI.Services;
using System.Drawing;

namespace SegurosAllanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegurosController : ControllerBase
    {
        private readonly DataDbContext _dbContext;
        private readonly SeguradoService _seguradoService;
        private static double _MARGEM_SEGURANCA = 0.03;
        private static double _LUCRO = 0.05;

        public SegurosController()
        {   
        }

        public SegurosController(SeguradoService seguradoService, DataDbContext dbContext)
        {
            _seguradoService = seguradoService;
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> gravar(SeguroRequest entrada)
        {
            try
            {
                var segurado = _dbContext.Segurados.Find(entrada.Cpf);
                if (segurado == null)
                    segurado = await _seguradoService.GetSegurado(entrada.Cpf);

                var calculo = calcularSeguro(entrada.Valor);
            
                var seguro = new Seguro()
                {
                    TaxaRisco = calculo.TaxaRisco,
                    PremioRisco = calculo.PremioRisco,
                    PremioPuro = calculo.PremioPuro,
                    PremioComercial = calculo.PremioComercial,
                    Segurado = segurado,
                    Veiculo = new Veiculo()
                    {
                        Marca = entrada.Marca,
                        Modelo = entrada.Modelo,
                        Valor = entrada.Valor
                    }
                };
            
                _dbContext.Seguros.Add(seguro);

                _dbContext.SaveChanges();

                return Ok(seguro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("calculo")]
        public async Task<ActionResult<Seguro>> getCalcularSeguro(double valor)
        {
            return Ok(calcularSeguro(valor));
        }

        public Seguro calcularSeguro(double valor)
        {
            var seguro = new Seguro();
            seguro.TaxaRisco = (valor * 5) / (valor * 2);
            seguro.PremioRisco = (seguro.TaxaRisco / 100) * valor;
            seguro.PremioPuro = seguro.PremioRisco * (1 + _MARGEM_SEGURANCA);
            seguro.PremioComercial = seguro.PremioPuro * (1 + _LUCRO);

            return seguro;
        }

        [HttpGet("seguro")]
        public async Task<ActionResult<Seguro>> getSeguro(int Id)
        {
            var seguro = _dbContext.Seguros.Where(w => w.Id == Id).FirstOrDefault();

            return Ok(seguro);
        }

        [HttpGet("relatorio")]
        public IActionResult getRelatorio()
        {
            var seguro = _dbContext.Seguros
            .Select(
                a => new
                { 
                    Cpf = a.Segurado.Cpf,
                    PremioComercial = a.PremioComercial
                }
            )
            .GroupBy( a => a.Cpf, a => a.PremioComercial)
            .Select(
                a => new
                {
                    Cpf = a.Key,
                    MediaSeguros = a.Average()
                }
            );

            return Ok(seguro);
        }
    }
}
