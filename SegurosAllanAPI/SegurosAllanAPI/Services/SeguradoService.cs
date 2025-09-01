using Microsoft.EntityFrameworkCore;
using SegurosAllanAPI.Models;
using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;

namespace SegurosAllanAPI.Services
{
    public class SeguradoService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public SeguradoService(HttpClient httpClient, IConfiguration configuration) {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<Segurado> GetSegurado(long cpf)
        {
            //string mySetting = _configuration.GetValue("ConnectionJsonServer").Tos  ;
            string mySetting = _configuration["ConnectionJsonServer"];

            var response = await _httpClient.GetFromJsonAsync<Segurado>($"{mySetting}/segurados/{cpf}");
            
            if (response == null)
                throw new InvalidOperationException("Cpf não encontrado");
                        
            var segurado = new Segurado
            {
                Cpf = response.Cpf,
                Nome = response.Nome,
                Idade = response.Idade
            };

            return segurado;
        }
    }
}
