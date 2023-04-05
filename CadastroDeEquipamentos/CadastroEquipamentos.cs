using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeEquipamentos
{
    public class CadastroEquipamentos
    {
        static int ContadorDeEquipamento = 1;

        public static ArrayList listaIdsEquipamento = new ArrayList();
        public static ArrayList listaPrecoEquipamento = new ArrayList();
        static ArrayList listaNumerosSerieEquipamento = new ArrayList();
        static ArrayList listaDatasFabricacaoEquipamento = new ArrayList();
        static ArrayList listaFabricanteEquipamento = new ArrayList();
        public static ArrayList listaNomesEquipamento = new ArrayList();

        public static string ApresentarMenuCadastroEquipamentos()
        {
            Console.Clear();
            Console.WriteLine("\nCadastro de Equipamentos");
            Console.WriteLine("\nDigite 1 para Inserir um Novo Equipamento");
            Console.WriteLine("\nDigite 2 para visualizar equipamentos cadastrados");
            Console.WriteLine("\nDigite 3 para Editar Equipamentos Cadastrados");
            Console.WriteLine("\nDigite 4 para Excluir Equipamentos Cadastrados");
            Console.WriteLine("\nDigite s para voltar para o menu principal");

            string opcao = Console.ReadLine();
            return opcao;

        }

        public static void InserirNovoEquipamento()
        {
            Program.MostrarCabecalho("Cadastro de Equipamentos", "Inserindo Novo Equipamento: ");

            GravarEquipamento(ContadorDeEquipamento, "INSERIR");

            Program.IncrementarId(ContadorDeEquipamento);

            Program.ApresentarMensagem("Equipamento inserido com sucesso!", ConsoleColor.Green);
        }
        public static bool VisualizarEquipamentos(bool mostrarCabecalho)
        {
            if (mostrarCabecalho)
                Program.MostrarCabecalho("Cadastro de Equipamentos", "Visualizando Equipamentos: ");

            if (listaIdsEquipamento.Count == 0)
            {
                Program.ApresentarMensagem("Nenhum equipamento cadastrado!", ConsoleColor.DarkYellow);
                return false;
            }

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("{0,-10} | {1,-40} | {2,-30}", "Id", "Nome", "Fabricante");

            Console.WriteLine("---------------------------------------------------------------------------------------");

            for (int i = 0; i < listaIdsEquipamento.Count; i++)
            {
                Console.WriteLine("{0,-10} | {1,-40} | {2,-30}",
                    listaIdsEquipamento[i], listaNomesEquipamento[i], listaFabricanteEquipamento[i]);
            }

            Console.ResetColor();

            return true;
        }

        public static void EditarEquipamento()
        {
            Program.MostrarCabecalho("Cadastro de Equipamentos", "Editando Equipamento: ");

            bool temEquipamentosGravados = VisualizarEquipamentos(false);

            if (temEquipamentosGravados == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarEquipamento();

            GravarEquipamento(idSelecionado, "EDITAR");

            Program.ApresentarMensagem("Equipamento editado com sucesso!", ConsoleColor.Green);
        }

        public static void ExcluirEquipamento()
        {
            Program.MostrarCabecalho("Cadastro de Equipamentos", "Excluindo Equipamento: ");

            bool temEquipamentosGravados = VisualizarEquipamentos(false);

            if (temEquipamentosGravados == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarEquipamento();

            int posicao = listaIdsEquipamento.IndexOf(idSelecionado);

            listaIdsEquipamento.RemoveAt(posicao);
            listaNomesEquipamento.RemoveAt(posicao);
            listaPrecoEquipamento.RemoveAt(posicao);
            listaNumerosSerieEquipamento.RemoveAt(posicao);
            listaDatasFabricacaoEquipamento.RemoveAt(posicao);
            listaFabricanteEquipamento.RemoveAt(posicao);

            Program.ApresentarMensagem("Equipamento excluído com sucesso!", ConsoleColor.Green);
        }

        public static int EncontrarEquipamento()
        {
            int idSelecionado = 0;
            bool idInvalido;
            do
            {

                Console.WriteLine("Digite o Id do Equipamento que deseja encontrar: ");
                idSelecionado = Convert.ToInt32(Console.ReadLine());

                idInvalido = listaIdsEquipamento.Contains(idSelecionado) == false;

                if (idInvalido)
                    Program.ApresentarMensagem("Id inválido, tente novamente", ConsoleColor.Red);


            } while (idInvalido);

            return idSelecionado;
        }

        public static void GravarEquipamento(int id, string tipoOperacao)
        {
            string nomeEquipamento;
            bool nomeInvalido;

            do
            {
                nomeInvalido = false;
                Console.Write("Digite o Nome do Equipamento: ");
                nomeEquipamento = Console.ReadLine();

                if (nomeEquipamento.Length < 6)
                {
                    nomeInvalido = true;
                    Program.ApresentarMensagem("Nome inválido. O nome deve ter no mínimo 6 caracteres.", ConsoleColor.Red);
                }
            }
            while (nomeInvalido);

            Console.Write("Digite o Preço do Equipamento: ");
            decimal preco = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Digite o Numero de Série do Equipamento: ");
            string numeroSerie = Console.ReadLine();

            Console.Write("Digite a data de Fabricação do Equipamento: ");
            string dataFabricacao = Console.ReadLine();

            Console.Write("Digite o Fabricante do Equipamento: ");
            string fabricante = Console.ReadLine();

            if (tipoOperacao == "EDITAR")
            {
                int posicao = listaIdsEquipamento.IndexOf(id);

                listaIdsEquipamento[posicao] = id;
                listaNomesEquipamento[posicao] = nomeEquipamento;
                listaPrecoEquipamento[posicao] = preco;
                listaNumerosSerieEquipamento[posicao] = numeroSerie;
                listaDatasFabricacaoEquipamento[posicao] = dataFabricacao;
                listaFabricanteEquipamento[posicao] = fabricante;

            }
            else if (tipoOperacao == "INSERIR")
            {
                listaIdsEquipamento.Add(id);
                listaNomesEquipamento.Add(nomeEquipamento);
                listaPrecoEquipamento.Add(preco);
                listaNumerosSerieEquipamento.Add(numeroSerie);
                listaDatasFabricacaoEquipamento.Add(dataFabricacao);
                listaFabricanteEquipamento.Add(fabricante);
            }

        }




    }
}
