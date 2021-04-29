using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using Console.Services;
using Console.Entidade;

namespace UnitTests.ElevadorService_Teste
{
    public class Tests
    {
        private ElevadorService elevadorService;
        List<UsoElevador> list = new List<UsoElevador>() 
            {
                new UsoElevador() { Andar = 11, Elevador = 'A', Turno = 'M' },
                new UsoElevador() { Andar = 12, Elevador = 'A', Turno = 'M' },
                new UsoElevador() { Andar = 14, Elevador = 'A', Turno = 'M' },
                new UsoElevador() { Andar = 0, Elevador = 'A', Turno = 'M' },
                new UsoElevador() { Andar = 1, Elevador = 'A', Turno = 'M' },
                new UsoElevador() { Andar = 15, Elevador = 'B', Turno = 'M' },
                new UsoElevador() { Andar = 13, Elevador = 'B', Turno = 'M' },
                new UsoElevador() { Andar = 1, Elevador = 'C', Turno = 'M' },
                new UsoElevador() { Andar = 2, Elevador = 'C', Turno = 'M' },
                new UsoElevador() { Andar = 4, Elevador = 'C', Turno = 'M' },
                new UsoElevador() { Andar = 3, Elevador = 'C', Turno = 'M' },
                new UsoElevador() { Andar = 4, Elevador = 'C', Turno = 'M' },
                new UsoElevador() { Andar = 5, Elevador = 'D', Turno = 'M' },
                new UsoElevador() { Andar = 6, Elevador = 'E', Turno = 'M' },
                new UsoElevador() { Andar = 7, Elevador = 'A', Turno = 'M' },
                new UsoElevador() { Andar = 10, Elevador = 'A', Turno = 'M' },
                new UsoElevador() { Andar = 9, Elevador = 'A', Turno = 'M' },
                new UsoElevador() { Andar = 15, Elevador = 'B', Turno = 'V' },
                new UsoElevador() { Andar = 13, Elevador = 'B', Turno = 'V' },
                new UsoElevador() { Andar = 1, Elevador = 'C', Turno = 'V' },
                new UsoElevador() { Andar = 2, Elevador = 'C', Turno = 'V' },
                new UsoElevador() { Andar = 4, Elevador = 'C', Turno = 'N' },
                new UsoElevador() { Andar = 3, Elevador = 'C', Turno = 'V' }
            };

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test_passar_instancia_vazio_para_service_e_chamar_metodo_qualquer()
        {
            elevadorService = new ElevadorService(new List<UsoElevador>());
            
            List<int> result = elevadorService.andarMenosUtilizado();
            Assert.IsInstanceOf(typeof(List<int>), result);
            Assert.IsEmpty(result);
        }

        [Test]
        public void Test_passar_instancia_nula_para_service_e_chamar_metodo_qualquer()
        {
            elevadorService = new ElevadorService(null);
            
            List<int> result = elevadorService.andarMenosUtilizado();
            Assert.IsInstanceOf(typeof(List<int>), result);
            Assert.IsEmpty(result);
        }

        [Test]
        public void Test_andarMenosUtilizado_sucesso()
        {
            elevadorService = new ElevadorService(list);

            List<int> result = elevadorService.andarMenosUtilizado();
            Assert.IsInstanceOf(typeof(List<int>), result);
            Assert.IsNotEmpty(result);
        }

        [Test]
        public void Test_elevadorMaisFrequentado_sucesso()
        {
            elevadorService = new ElevadorService(list);

            List<char> result = elevadorService.elevadorMaisFrequentado();
            Assert.IsInstanceOf(typeof(List<char>), result);
            Assert.IsNotEmpty(result);
        }

        [Test]
        public void Test_percentualDeUsoElevadorA_sucesso()
        {
            elevadorService = new ElevadorService(list);

            float result = elevadorService.percentualDeUsoElevadorA();
            Assert.IsInstanceOf(typeof(float), result);
            Assert.Greater(result, 0);
        }
        [Test]
        public void Test_percentualDeUsoElevadorB_sucesso()
        {
            elevadorService = new ElevadorService(list);

            float result = elevadorService.percentualDeUsoElevadorB();
            Assert.IsInstanceOf(typeof(float), result);
            Assert.Greater(result, 0);
        }
        [Test]
        public void Test_percentualDeUsoElevadorC_sucesso()
        {
            elevadorService = new ElevadorService(list);

            float result = elevadorService.percentualDeUsoElevadorC();
            Assert.IsInstanceOf(typeof(float), result);
            Assert.Greater(result, 0);
        }
        [Test]
        public void Test_percentualDeUsoElevadorD_sucesso()
        {
            elevadorService = new ElevadorService(list);

            float result = elevadorService.percentualDeUsoElevadorD();
            Assert.IsInstanceOf(typeof(float), result);
            Assert.Greater(result, 0);
        }
        [Test]
        public void Test_percentualDeUsoElevadorE_sucesso()
        {
            elevadorService = new ElevadorService(list);

            float result = elevadorService.percentualDeUsoElevadorE();
            Assert.IsInstanceOf(typeof(float), result);
            Assert.Greater(result, 0);
        }
        [Test]
        public void Test_periodoMaiorFluxoElevadorMaisFrequentado_sucesso()
        {
            elevadorService = new ElevadorService(list);

            List<char> result = elevadorService.periodoMaiorFluxoElevadorMaisFrequentado();
            Assert.IsInstanceOf(typeof(List<char>), result);
            Assert.IsNotEmpty(result);
        }
        [Test]
        public void Test_periodoMaiorUtilizacaoConjuntoElevadores_sucesso()
        {
            elevadorService = new ElevadorService(list);

            List<char> result = elevadorService.periodoMaiorUtilizacaoConjuntoElevadores();
            Assert.IsInstanceOf(typeof(List<char>), result);
            Assert.IsNotEmpty(result);
        }
        [Test]
        public void Test_periodoMenorFluxoElevadorMenosFrequentado_sucesso()
        {
            elevadorService = new ElevadorService(list);

            List<char> result = elevadorService.periodoMenorFluxoElevadorMenosFrequentado();
            Assert.IsInstanceOf(typeof(List<char>), result);
            Assert.IsNotEmpty(result);
        }
    }
}