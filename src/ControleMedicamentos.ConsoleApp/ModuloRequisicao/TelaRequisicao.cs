using ControleMedicamentos.ConsoleApp.ModuloRequisicao;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicao
{
    public class TelaRequisicao
    {
        public RepositorioRequisicao repositorio = new RepositorioRequisicao();

        //public TelaRequisicao()
        //{
        //    Requisicao requisicaoTeste = new Requisicao("Joaozinho", "111-222-333-44", "Bairro Universitario", "007 7500 4002 8922");

        //    repositorio.CadastrarRequisicao(requisicaoTeste);
        //}




        public char ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|        Gestão de Requisicaos        |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("1 - Cadastrar Requisicao");
            Console.WriteLine("2 - Editar Requisicao");
            Console.WriteLine("3 - Excluir Requisicao");
            Console.WriteLine("4 - Visualizar Requisicaos");

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            char operacaoEscolhida = Convert.ToChar(Console.ReadLine());

            return operacaoEscolhida;
        }



        public void CadastrarRequisicao()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|        Gestão de Requisições        |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("Cadastrando Requisição...");

            Console.WriteLine();


            //adicionar a listagem de medicamentos para o usuario escolher o id do medicamento
            Console.Write("Digite o ID do Medicamento: ");
            int idMedicamento = int.Parse(Console.ReadLine());

            //adicionar a listagem de pacientes para o usuario escolher o id do paciente
            Console.Write("Digite o ID do Paciente: ");
            int idPaciente = int.Parse(Console.ReadLine());

            Console.Write("Digite a quantidade de Medicamento: ");
            int quantidadeMedicamento = int.Parse(Console.ReadLine());

            Console.Write("Digite o endereço do requisicao:");
            DateTime dataValidade = Convert.ToDateTime(Console.ReadLine());


            //Requisicao requisicao = new Requisicao();

            //repositorio.CadastrarRequisicao(requisicao);

            Program.ExibirMensagem("O requisicao foi cadastrado com sucesso!", ConsoleColor.Green);
        }







        //public void EditarRequisicao()
        //{
        //    Console.Clear();

        //    Console.WriteLine("----------------------------------------");
        //    Console.WriteLine("|        Gestão de Requisicaos        |");
        //    Console.WriteLine("----------------------------------------");

        //    Console.WriteLine();

        //    Console.WriteLine("Editando Requisicao...");

        //    Console.WriteLine();

        //    VisualizarRequisicaos(false);

        //    Console.Write("Digite o ID do requisicao que deseja editar: ");
        //    int idRequisicaoEscolhido = Convert.ToInt32(Console.ReadLine());

        //    if (!repositorio.ExisteRequisicao(idRequisicaoEscolhido))
        //    {
        //        Program.ExibirMensagem("O requisicao mencionado não existe!", ConsoleColor.DarkYellow);
        //        return;
        //    }

        //    Console.WriteLine();



        //    Console.Write("Digite o nome do requisicao: ");
        //    string nome = Console.ReadLine();

        //    Console.Write("Digite o CPF do requisicao: ");
        //    string cpf = Console.ReadLine();

        //    Console.Write("Digite o endereço do requisicao:");
        //    string endereco = Console.ReadLine();

        //    Console.Write("Digite o número do Cartão do SUS do requisicao, ex: (000-0000-0000-0000):  ");
        //    string numeroSus = Console.ReadLine();

        //    Requisicao novoRequisicao = new Requisicao(nome, cpf, endereco, numeroSus);



        //    bool conseguiuEditar = repositorio.EditarRequisicao(idRequisicaoEscolhido, novoRequisicao);

        //    if (!conseguiuEditar)
        //    {
        //        Program.ExibirMensagem("Houve um erro durante a edição de requisicao", ConsoleColor.Red);
        //        return;
        //    }

        //    Program.ExibirMensagem("O requisicao foi editado com sucesso!", ConsoleColor.Green);
        //}


        //public void ExcluirRequisicao()
        //{
        //    Console.Clear();

        //    Console.WriteLine("----------------------------------------");
        //    Console.WriteLine("|        Gestão de Requisicaos        |");
        //    Console.WriteLine("----------------------------------------");

        //    Console.WriteLine();

        //    Console.WriteLine("Excluindo Requisicao...");

        //    Console.WriteLine();

        //    VisualizarRequisicaos(false);

        //    Console.Write("Digite o ID do requisicao que deseja excluir: ");
        //    int idRequisicaoEscolhido = Convert.ToInt32(Console.ReadLine());

        //    if (!repositorio.ExisteRequisicao(idRequisicaoEscolhido))
        //    {
        //        Program.ExibirMensagem("O requisicao mencionado não existe!", ConsoleColor.DarkYellow);
        //        return;
        //    }

        //    bool conseguiuExcluir = repositorio.ExcluirRequisicao(idRequisicaoEscolhido);

        //    if (!conseguiuExcluir)
        //    {
        //        Program.ExibirMensagem("Houve um erro durante a exclusão do requisicao", ConsoleColor.Red);
        //        return;
        //    }

        //    Program.ExibirMensagem("O requisicao foi excluído com sucesso!", ConsoleColor.Green);
        //}




        public void VisualizarRequisicaos(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                Console.Clear();

                Console.WriteLine("----------------------------------------");
                Console.WriteLine("|        Gestão de Requisicaos        |");
                Console.WriteLine("----------------------------------------");

                Console.WriteLine();

                Console.WriteLine("Visualizando Requisicaos...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "| {0, -10} | {1, -15} | {2, -15} | {3, -19} |",
                   "Id", "Nome", "CPF", "Numero do Cartão SUS"
                );

            Requisicao[] requisicoesCadastrados = repositorio.SelecionarRequisicaos();

            for (int i = 0; i < requisicoesCadastrados.Length; i++)
            {
                Requisicao pac = requisicoesCadastrados[i];

                if (pac == null)
                    continue;

                Console.WriteLine(
                "| {0, -10} | {1, -15} | {2, -15} | {3, -19} |",
                 pac.Id, pac.Nome, pac.Cpf, pac.NumeroCartaoSus
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }
    }
}
