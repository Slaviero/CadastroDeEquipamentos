using System;
using System.Collections;
using System.Reflection.PortableExecutable;

namespace CadastroDeEquipamentos
{
    internal class Program
    {



        static void Main(string[] args)
        {
            while (true)
            {
                string opcao = ApresentarMenuPrincipal();

                if (opcao == "s")
                {
                    break;
                }

                if (opcao == "1")
                {
                    //apresentar um submenu com o CRUD de Equipamentos
                    string opcaoCadastroEquipamentos = CadastroEquipamentos.ApresentarMenuCadastroEquipamentos();
                    if (opcaoCadastroEquipamentos == "s")
                        continue;

                    else if (opcaoCadastroEquipamentos == "1")
                    {
                        CadastroEquipamentos.InserirNovoEquipamento();
                    }
                    else if (opcaoCadastroEquipamentos == "2")
                    {
                        bool temEquipamentos = CadastroEquipamentos.VisualizarEquipamentos(true);

                        if (temEquipamentos)
                            Console.ReadLine();
                    }
                    else if (opcaoCadastroEquipamentos == "3")
                    {
                        CadastroEquipamentos.EditarEquipamento();
                    }
                    else if (opcaoCadastroEquipamentos == "4")
                    {
                        CadastroEquipamentos.ExcluirEquipamento();
                    }

                }
                else if (opcao == "2")
                {
                    string opcaoCadastroChamados = CadastroChamados.ApresentarMenuCadastroChamados();

                    //apresentar um submenu com o CRUD de Chamados
                    if (opcaoCadastroChamados == "1")
                    {
                        CadastroChamados.InserirNovoChamado();
                    }
                    else if (opcaoCadastroChamados == "2")
                    {
                        bool temChamados = CadastroChamados.VisualizarChamados(true);

                        if (temChamados)
                            Console.ReadLine();
                    }
                    else if (opcaoCadastroChamados == "3")
                    {
                        CadastroChamados.EditarChamados();
                    }
                    else if (opcaoCadastroChamados == "4")
                    {
                        CadastroChamados.ExcluirChamados();
                    }
                }
            }
        }

        
            
        public static void ApresentarMensagem(string mensagem, ConsoleColor cor)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(mensagem);
            Console.ReadLine();
            Console.ResetColor();
        }
        public static void MostrarCabecalho(string titulo, string subtitulo)
        {
            Console.Clear();

            Console.WriteLine();

            Console.WriteLine(titulo);

            Console.WriteLine();

            Console.WriteLine(subtitulo);

            Console.WriteLine();
        }
        public static void IncrementarId(int contador)
        {
            contador++;
        }
        public static string ApresentarMenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("\nGestão de Equipamentos 1.0");
            Console.WriteLine("\nDigite 1 para Cadastrar Equipamentos");
            Console.WriteLine("\nDigite 2 para Controlar Chamados");
            Console.WriteLine("\nDigite s para sair");
            
            string opcao = Console.ReadLine();
            return opcao;
        }
    }
}