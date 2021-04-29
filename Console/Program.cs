using System;
using System.Collections.Generic;
using System.IO;
using Console.Entidade;
using Console.Services;
using Newtonsoft.Json;

namespace ProvaAdmissionalApisul.Console
{
    class Program
    {
        private static ElevadorService elevadorService;

        static void Main(string[] args)
        {
            string json = ArquivoService.LerArquivo("input.json");
            List<UsoElevador> usoElevadors = ArquivoService.ConverterArquivo(json);

            elevadorService = new ElevadorService(usoElevadors);

            List<int> andaresMenosUtilizados = elevadorService.andarMenosUtilizado();
            List<char> elevadoreMaisFrequentados = elevadorService.elevadorMaisFrequentado();
            List<char> elevadoreMenosFrequentados = elevadorService.elevadorMenosFrequentado();
            float percentualDeUsoElevadorA = elevadorService.percentualDeUsoElevadorA();
            float percentualDeUsoElevadorB = elevadorService.percentualDeUsoElevadorB();
            float percentualDeUsoElevadorC = elevadorService.percentualDeUsoElevadorC();
            float percentualDeUsoElevadorD = elevadorService.percentualDeUsoElevadorD();
            float percentualDeUsoElevadorE = elevadorService.percentualDeUsoElevadorE();
            List<char> periodoMaiorFluxoElevadorMaisFrequentado = elevadorService.periodoMaiorFluxoElevadorMaisFrequentado();
            List<char> periodoMaiorUtilizacaoConjuntoElevadores = elevadorService.periodoMaiorUtilizacaoConjuntoElevadores();
            List<char> periodoMenorFluxoElevadorMenosFrequentado = elevadorService.periodoMenorFluxoElevadorMenosFrequentado();



            

            ImprimirResultado("andares menos utilizados:", andaresMenosUtilizados);
            ImprimirResultado("elevadores mais frequentados:", elevadoreMaisFrequentados);
            ImprimirResultado("elevadores menos frequentados:", elevadoreMenosFrequentados);
            ImprimirResultado("percentual de uso elevador A:", percentualDeUsoElevadorA);
            ImprimirResultado("percentual de uso elevador B:", percentualDeUsoElevadorB);
            ImprimirResultado("percentual de uso elevador C:", percentualDeUsoElevadorC);
            ImprimirResultado("percentual de uso elevador D:", percentualDeUsoElevadorD);
            ImprimirResultado("percentual de uso elevador E:", percentualDeUsoElevadorE);
            ImprimirResultado("periodo maior fluxo elevador mais Frequentado:", periodoMaiorFluxoElevadorMaisFrequentado);
            ImprimirResultado("periodo maior utilizacao conjunto elevadores:", periodoMaiorUtilizacaoConjuntoElevadores);
            ImprimirResultado("periodo menor fluxo elevador menos frequentado:", periodoMenorFluxoElevadorMenosFrequentado);
        }

        private static void ImprimirResultado(string mensagem, List<char> itens)
        {
            System.Console.WriteLine();
            System.Console.Write(mensagem);
            for(int i = 0; i < itens.Count; i++)
                System.Console.Write(" " + Convert.ToChar(itens[i]) + (i < itens.Count-1 ? ",": ";"));                
        }
        private static void ImprimirResultado(string mensagem, List<int> itens)
        {
            System.Console.WriteLine();
            System.Console.Write(mensagem);
            for(int i = 0; i < itens.Count; i++)
                System.Console.Write(" " + itens[i] + (i < itens.Count-1 ? ",": ";"));                
        }
        private static void ImprimirResultado(string mensagem, float percentual)
        {
            System.Console.WriteLine();
            System.Console.Write(mensagem + " " + (percentual *100).ToString("00.00") + "%;");
        }

    }
}
