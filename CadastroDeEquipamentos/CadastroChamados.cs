using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeEquipamentos
{
    internal class CadastroChamados
    {
        static int ContadorDeChamados = 1;

        static ArrayList listaIdsChamados = new ArrayList();
        static ArrayList listaTitulosChamado = new ArrayList();
        static ArrayList listaAberturaChamado = new ArrayList();
        static ArrayList listaDescricaoChamado = new ArrayList();
        static ArrayList listaIdEquipamentoChamado = new ArrayList();

        public static void InserirNovoChamado()
        {
            Program.MostrarCabecalho("Cadastro de Chamados", "Inserir Novo Chamado: ");

            GravarChamado(ContadorDeChamados, "INSERIR");

            Program.IncrementarId(ContadorDeChamados);

            Program.ApresentarMensagem("Chamado cadastrado com sucesso!", ConsoleColor.Green);

        }
        public static bool VisualizarChamados(bool mostrarCabecalho)
        {
            if (mostrarCabecalho)
                Program.MostrarCabecalho("Aberetura de Chamados", "Visualizar Chamados");

            if (listaIdsChamados.Count == 0)
            {
                Program.ApresentarMensagem("Nenhum chamado registrado!", ConsoleColor.DarkYellow);
                return false;
            }

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("{0,-10} | {1,-40} | {2,-30} | {3,-30}", "Id", "Título", "Equipamento", "Data de Abertura");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------");


            for (int i = 0; i < listaIdsChamados.Count; i++)
            {
                string nomeEquipamento = ObterNomeEquipamento((int)listaIdEquipamentoChamado[i]);

                Console.WriteLine("{0,-10} | {1,-40} | {2,-30} | {3,-30}",
                    listaIdsChamados[i], listaTitulosChamado[i], nomeEquipamento, listaAberturaChamado[i]);
            }

            Console.ResetColor();

            return true;
        }
        public static void EditarChamados()
        {
            Program.MostrarCabecalho("Cadastro de Chamados", "Editando chamado: ");

            bool temChamadosGravados = VisualizarChamados(false);

            if (temChamadosGravados == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarChamado();

            GravarChamado(idSelecionado, "EDITAR");

            Program.ApresentarMensagem("Chamado editado com sucesso!", ConsoleColor.Green);
        }
        public static void ExcluirChamados()
        {
            Program.MostrarCabecalho("Cadastro de Chamados", "Excluindo Chamados: ");

            bool temChamadosGravados = VisualizarChamados(false);

            if (temChamadosGravados == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarChamado();


            int posicao = listaIdsChamados.IndexOf(idSelecionado);

            listaIdsChamados.RemoveAt(posicao);
            listaTitulosChamado.RemoveAt(posicao);
            listaAberturaChamado.RemoveAt(posicao);
            listaDescricaoChamado.RemoveAt(posicao);
            listaIdEquipamentoChamado.RemoveAt(posicao);

            Program.ApresentarMensagem("Equipamento excluído com sucesso!", ConsoleColor.Green);
        }
        static int EncontrarChamado()
        {
            int idSelecionado = 0;
            bool idInvalido;
            do
            {

                Console.WriteLine("Digite o Id do Chamado que deseja encontrar: ");
                idSelecionado = Convert.ToInt32(Console.ReadLine());

                idInvalido = listaIdsChamados.Contains(idSelecionado) == false;

                if (idInvalido)
                    Program.ApresentarMensagem("Id inválido, tente novamente", ConsoleColor.Red);

            } while (idInvalido);

            return idSelecionado;
        }
        static void GravarChamado(int id, string tipoOperacao)
        {
            string nomeChamado, idParaChamado;
            bool chamadoInvalido, idInvalido;

            do
            {

                Console.WriteLine("Informe o Id do produto desejado: ");
                idParaChamado = Console.ReadLine();

                if (CadastroEquipamentos.listaIdsEquipamento.Contains(idParaChamado))
                {
                    idInvalido = false;
                }
                else
                {
                    Program.ApresentarMensagem("O Id não tem nenhuma correspondencia dentro da lista de Equipamentos.", ConsoleColor.Red);
                    idInvalido = true;
                }

            } while (idInvalido);

            Console.WriteLine("Digite um titulo para o Chamado: ");
            string tituloChamado = Console.ReadLine();

            Console.WriteLine("Digite a descrição do Chamado: ");
            string descricaoChamado = Console.ReadLine();

            Console.Write("Digite a data de Abertura do Chamado: ");
            string aberturaChamado = Console.ReadLine();



            if (tipoOperacao == "EDITAR")
            {
                int posicao = listaIdsChamados.IndexOf(id);

                listaIdsChamados[posicao] = id;
                listaTitulosChamado[posicao] = tituloChamado;
                listaAberturaChamado[posicao] = aberturaChamado;
                listaDescricaoChamado[posicao] = descricaoChamado;
                listaIdEquipamentoChamado[posicao] = (idParaChamado);

            }
            else if (tipoOperacao == "INSERIR")
            {
                listaIdsChamados.Add(id);
                listaTitulosChamado.Add(tituloChamado);
                listaAberturaChamado.Add(aberturaChamado);
                listaDescricaoChamado.Add(descricaoChamado);
                listaIdEquipamentoChamado.Add(idParaChamado);
            }

        }
        public static string ApresentarMenuCadastroChamados()
        {
            Console.Clear();
            Console.WriteLine("\nCadastro de Equipamentos");
            Console.WriteLine("\nDigite 1 para Inserir um Novo Chamado");
            Console.WriteLine("\nDigite 2 para visualizar Chamados");
            Console.WriteLine("\nDigite 3 para Editar Chamado");
            Console.WriteLine("\nDigite 4 para Excluir Chamado");
            Console.WriteLine("\nDigite s para voltar para o menu principal");

            string opcao = Console.ReadLine();
            return opcao;

        }
        private static string ObterNomeEquipamento(int id)
        {
            int posicao = CadastroEquipamentos.listaIdsEquipamento.IndexOf(id);

            string nomeEquipamento = (string)CadastroEquipamentos.listaNomesEquipamento[posicao];

            return nomeEquipamento;
        }

    }
}
