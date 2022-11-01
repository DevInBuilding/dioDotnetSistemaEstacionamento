using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Sistema_Estacionamento.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            Console.WriteLine($"Veículo com placa {placa} foi registrado com sucesso.");
            veiculos.Add(placa);
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover: ");
            string placa = Console.ReadLine();
            Console.WriteLine("Digite o total de horas: ");
            int horas = int.Parse(Console.ReadLine());
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine($"Veículo {placa} tem débito de $ {this.CalcularTotal(horas)} pelo estacionamento em {horas} horas.");            
                veiculos.Remove(placa);
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("----- LISTA DE VEÍCULOS -----");
                Console.WriteLine("Os veículos estacionados são:");
                foreach(string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
                Console.WriteLine("-----------------------------");
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        public decimal CalcularTotal(int horas)
        {
            return (this.precoInicial + this.precoPorHora * horas);
        }

        public void VerificarCustoTotal()
        {
            Console.WriteLine("Digite o nº da placa: ");
            string placa = Console.ReadLine();
            Console.WriteLine("Total de horas estacionado: ");
            int tempo = int.Parse(Console.ReadLine());
            bool existe = false;
            
            foreach(string veiculo in veiculos)
            {
                if(veiculo.ToUpper().Equals(placa.ToUpper())) existe = true;                
            }

            if(existe)
            {
                Console.WriteLine($"O veículo {placa} está estacionado há {tempo} horas, com um custo total de {this.CalcularTotal(tempo)} até o momento.");
            }
            else
            {
                Console.WriteLine("Veículo não cadastrado.");
            }
        }

        public void ExibirMenu()
        {
            try
            {            
                Console.Title = "PS Sistema de Estacionamento";
                
                Loop:
                Console.WriteLine("\n----- MENU -----");
                Console.WriteLine("Escolha uma das opções abaixo:");
                Console.WriteLine("1. Adicionar novo veículo");
                Console.WriteLine("2. Remover veículo");
                Console.WriteLine("3. Listar veículos");
                Console.WriteLine("4. Verificar custo atual no estacionamento");
                Console.WriteLine("5. Encerrar");
                Console.WriteLine("----------------\n");
                                
                Console.WriteLine("Digite o número da opção: ");
                int escolha = int.Parse(Console.ReadLine());
                switch (escolha)
                {
                    case 1: this.AdicionarVeiculo();
                            break;
                    case 2: this.RemoverVeiculo();
                            break;
                    case 3: this.ListarVeiculos();
                            break;
                    case 4: this.VerificarCustoTotal();
                            break;
                    case 5: Console.WriteLine("Encerrando a aplicação...\n");                            
                            break;
                    default:Console.WriteLine("\nEscolha uma opção válida!\n");
                            Console.Clear();
                            goto Loop;
                }
                
                Console.WriteLine("\nDeseja sair (0 - Não /1 - Sim)?");
                int escolha2 = int.Parse(Console.ReadLine());
                if(escolha2 == 0)
                {
                    goto Loop;
                }
                else
                {
                    Console.WriteLine("\nFoi um prazer lhe atender.\n");
                }
            }
            catch(Exception exc)
            {
                Console.WriteLine($"Entrada inválida! \nExceção: {exc}");
            }            
        }
    }
}