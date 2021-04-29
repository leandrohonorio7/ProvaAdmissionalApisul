using System.Collections.Generic;
using System.IO;
using Console.Entidade;
using Newtonsoft.Json;

namespace Console.Services
{
    public static class ArquivoService
    {
        public static string LerArquivo(string arquivo)
        {
            return File.Exists(arquivo) ? File.ReadAllText(arquivo) : string.Empty;
        } 
        public static List<UsoElevador> ConverterArquivo(string json) => string.IsNullOrEmpty(json) ? new List<UsoElevador>() : JsonConvert.DeserializeObject<List<UsoElevador>>(json);
    }
}