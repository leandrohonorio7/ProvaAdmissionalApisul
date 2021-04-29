using System.Collections.Generic;
using System.Linq;
using Console.Entidade;
using Console.Services.Interface;

namespace Console.Services
{
    public class ElevadorService : IElevadorService
    {
        private List<UsoElevador> usoElevadors;
        public ElevadorService(List<UsoElevador> _usoElevadors)
        {
            usoElevadors = _usoElevadors;
        }

        public List<int> andarMenosUtilizado()
        {
            if(!ValidarUsoElevadores())
                return new List<int>();

            var usoElevadorAgrupado = usoElevadors
                                        .GroupBy(uso => uso.Andar)
                                        .Select(group => new
                                        {
                                            Andar = group.Key,
                                            Count = group.Count()
                                        });

            int minimoUso = usoElevadorAgrupado.Min(uso => uso.Count);
            List<int> andaresMenosUtilizados = usoElevadorAgrupado.Where(uso => uso.Count.Equals(minimoUso))
                                                                    .Select(usoSelect => usoSelect.Andar).ToList();

            return andaresMenosUtilizados;
        }

        public List<char> elevadorMaisFrequentado()
        {
            if(!ValidarUsoElevadores())
                return new List<char>();

            var usoElevadorAgrupado = usoElevadors
                                        .GroupBy(uso => uso.Elevador)
                                        .Select(group => new
                                        {
                                            Elevador = group.Key,
                                            Count = group.Count()
                                        });

            int maximoUso = usoElevadorAgrupado.Max(uso => uso.Count);
            List<char> elevadoresMaisFrequentados = usoElevadorAgrupado.Where(uso => uso.Count.Equals(maximoUso))
                                                                    .Select(usoSelect => usoSelect.Elevador).ToList();

            return elevadoresMaisFrequentados;
        }

        public List<char> elevadorMenosFrequentado()
        {
            if(!ValidarUsoElevadores())
                return new List<char>();

            var usoElevadorAgrupado = usoElevadors
                                        .GroupBy(uso => uso.Elevador)
                                        .Select(group => new
                                        {
                                            Elevador = group.Key,
                                            Count = group.Count()
                                        });

            int minimoUso = usoElevadorAgrupado.Min(uso => uso.Count);
            List<char> elevadoresMenosFrequentados = usoElevadorAgrupado.Where(uso => uso.Count.Equals(minimoUso))
                                                                    .Select(usoSelect => usoSelect.Elevador).ToList();

            return elevadoresMenosFrequentados;
        }

        public float percentualDeUsoElevadorA()
        {
            return PegarPercentualUso('A');
        }

        public float percentualDeUsoElevadorB()
        {
            return PegarPercentualUso('B');
        }

        public float percentualDeUsoElevadorC()
        {
            return PegarPercentualUso('C');
        }

        public float percentualDeUsoElevadorD()
        {
            return PegarPercentualUso('D');
        }

        public float percentualDeUsoElevadorE()
        {
            return PegarPercentualUso('E');
        }

        public List<char> periodoMaiorFluxoElevadorMaisFrequentado()
        {
            if(!ValidarUsoElevadores())
                return new List<char>();

            var usoElevadorAgrupado = usoElevadors
                                        .GroupBy(uso => uso.Turno)
                                        .Select(group => new
                                        {
                                            Periodo = group.Key,
                                            Count = group.Count()
                                        });

            int MaiorFluxo = usoElevadorAgrupado.Max(uso => uso.Count);
            char periodosMaiorFluxo = usoElevadorAgrupado.Where(x => x.Count.Equals(MaiorFluxo)).Select(y => y.Periodo).FirstOrDefault();

            var usoElevadoresAgrupadosPeriodo = usoElevadors.Where(uso => uso.Turno == periodosMaiorFluxo)
                                                            .GroupBy(uso => uso.Elevador)
                                                            .Select(group => new
                                                            {
                                                                Elevador = group.Key,
                                                                Count = group.Count()
                                                            });

            int MaiorUsoElevador = usoElevadoresAgrupadosPeriodo.Max(uso => uso.Count);

            List<char> elevadoresMaisFrequentados = usoElevadoresAgrupadosPeriodo
                                                        .Where(uso => uso.Count.Equals(MaiorUsoElevador))
                                                        .Select(usoSelect => usoSelect.Elevador).ToList();

            return elevadoresMaisFrequentados;
        }

        public List<char> periodoMaiorUtilizacaoConjuntoElevadores()
        {
            if(!ValidarUsoElevadores())
                return new List<char>();

            var usoElevadorAgrupado = usoElevadors
                                        .GroupBy(uso => uso.Turno)
                                        .Select(group => new
                                        {
                                            Periodo = group.Key,
                                            Count = group.Count()
                                        });

            int MaiorFluxo = usoElevadorAgrupado.Max(uso => uso.Count);
            char periodosMaiorFluxo = usoElevadorAgrupado.Where(x => x.Count.Equals(MaiorFluxo)).Select(y => y.Periodo).FirstOrDefault();

            var usoElevadoresAgrupadosPeriodo = usoElevadors.Where(uso => uso.Turno == periodosMaiorFluxo)
                                                            .GroupBy(uso => uso.Elevador)
                                                            .Select(group => new
                                                            {
                                                                Elevador = group.Key,
                                                                Count = group.Count()
                                                            });

            return usoElevadoresAgrupadosPeriodo.Select(x => x.Elevador).ToList();
        }

        public List<char> periodoMenorFluxoElevadorMenosFrequentado()
        {
            if(!ValidarUsoElevadores())
                return new List<char>();

            var usoElevadorAgrupado = usoElevadors
                                        .GroupBy(uso => uso.Turno)
                                        .Select(group => new
                                        {
                                            Periodo = group.Key,
                                            Count = group.Count()
                                        });

            int MenorFluxo = usoElevadorAgrupado.Min(uso => uso.Count);
            char periodosMenorFluxo = usoElevadorAgrupado.Where(x => x.Count.Equals(MenorFluxo)).Select(y => y.Periodo).FirstOrDefault();

            var usoElevadoresAgrupadosPeriodo = usoElevadors.Where(uso => uso.Turno == periodosMenorFluxo)
                                                            .GroupBy(uso => uso.Elevador)
                                                            .Select(group => new
                                                            {
                                                                Elevador = group.Key,
                                                                Count = group.Count()
                                                            });

            int MenorUsoElevador = usoElevadoresAgrupadosPeriodo.Min(uso => uso.Count);

            List<char> elevadoresMenosFrequentados = usoElevadoresAgrupadosPeriodo
                                                        .Where(uso => uso.Count.Equals(MenorUsoElevador))
                                                        .Select(usoSelect => usoSelect.Elevador).ToList();

            return elevadoresMenosFrequentados;
        }

        private bool ValidarUsoElevadores()
        {
            return usoElevadors != null ? usoElevadors.Any() : false;
        }

        private float PegarPercentualUso(char elevador)
        {
            if(!ValidarUsoElevadores())
                return 0;

            int quantidadeUsoElevador = usoElevadors
                                        .Where(uso => uso.Elevador.Equals(elevador))
                                        .Count();

            return quantidadeUsoElevador / (float)usoElevadors.Count();
        }
    }
}