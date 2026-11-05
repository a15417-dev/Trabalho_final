using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_final
{
    internal class Veiculo
    {
        
            // Campos privados
            private int _quilometragem;
            private double _nivelCombustivel;

            // Propriedades automáticas
            public string Matricula { get; set; }
            public int CapacidadeDeposito { get; set; }

            // Evento de alerta
            public event EventHandler ReservaAtingida;

            // Propriedade da quilometragem
            public int Quilometragem
            {
                get { return _quilometragem; }
                set
                {
                    if (value >= _quilometragem)
                    {
                        _quilometragem = value;
                    }
                    else
                    {
                        Console.WriteLine("Erro: A quilometragem não pode diminuir!");
                    }
                }
            }

            // Propriedade do combustível
            public double NivelCombustivel
            {
                get { return _nivelCombustivel; }
                set
                {
                    if (value >= 0 && value <= CapacidadeDeposito)
                    {
                        _nivelCombustivel = value;

                        if (_nivelCombustivel < CapacidadeDeposito * 0.10)
                        {
                            ReservaAtingida?.Invoke(this, EventArgs.Empty);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Erro: Nível de combustível inválido!");
                    }
                }
            }

            // Construtor
            public Veiculo(string matricula, int capacidadeDeposito)
            {
                Matricula = matricula;
                CapacidadeDeposito = capacidadeDeposito;
                Quilometragem = 0;
                NivelCombustivel = capacidadeDeposito;
            }

            // Método para abastecer
            public void Abastecer(double litros)
            {
                if (litros <= 0)
                {
                    Console.WriteLine("Quantidade de litros inválida!");
                    return;
                }

                if (NivelCombustivel + litros > CapacidadeDeposito)
                {
                    Console.WriteLine("Aviso: O depósito ficou apenas atestado até ao limite!");
                    NivelCombustivel = CapacidadeDeposito;
                }
                else
                {
                    NivelCombustivel += litros;
                }

                Console.WriteLine("Abastecimento realizado!");
            }

            // Método para realizar uma viagem
            public bool RealizarViagem(int kmDistancia)
            {
                if (kmDistancia <= 0)
                {
                    Console.WriteLine("Distância inválida!");
                    return false;
                }

                double combustivelNecessario = kmDistancia * 0.07;

                if (NivelCombustivel >= combustivelNecessario)
                {
                    Quilometragem += kmDistancia;
                    NivelCombustivel -= combustivelNecessario;

                    Console.WriteLine("Viagem realizada com sucesso!");
                    return true;
                }
                else
                {
                    Console.WriteLine("Combustível insuficiente para realizar a viagem!");
                    return false;
                }
            }
        }
    }


