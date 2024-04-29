using System;
using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;
using ControleMedicamentos.ConsoleApp.ModuloRequisicao;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class TelaMedicamento : Tela
    {
        RepositorioMedicamento RepositorioMedicamento { get; set; }

        public TelaMedicamento(RepositorioMedicamento repositorioMedicamento)
        {
            RepositorioMedicamento = repositorioMedicamento;

            Medicamento medicamentoTeste = new Medicamento("SERTRALINA", "Antidepressivo", 20);

            RepositorioMedicamento.Cadastrar(medicamentoTeste);
        }




        public char ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|        Gestão de Medicamentos        |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("1 - Cadastrar Medicamento");
            Console.WriteLine("2 - Editar Medicamento");
            Console.WriteLine("3 - Excluir Medicamento");
            Console.WriteLine("4 - Visualizar Medicamentos");

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            char operacaoEscolhida = Convert.ToChar(Console.ReadLine());

            return operacaoEscolhida;
        }



        public void CadastrarMedicamento()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|        Gestão de Medicamentos        |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("Cadastrando Medicamento...");

            Console.WriteLine();

            Console.Write("Digite o nome do medicamento: ");
            string nome = Console.ReadLine().ToUpper();

            Console.Write("Digite a descrição do medicamento: ");
            string descricao = Console.ReadLine();

            Console.Write("Digite a quantidade:");
            int quantidade = Convert.ToInt32(Console.ReadLine());


            bool existeMedicamento = false;


            Entidade[] medicamentosCadastrados = RepositorioMedicamento.SelecionarTudo();

            foreach (Medicamento medic in medicamentosCadastrados)
            {
                if (medic == null)
                    continue;

                if (medic.Nome == nome)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("-------------------------------------------------------------------------");
                    Console.WriteLine("| O Medicamento já Existe em no Sistema, Sua Quantidade será Atualizada |");
                    Console.WriteLine("-------------------------------------------------------------------------");
                    Console.ResetColor();

                    medic.Quantidade += quantidade;

                    existeMedicamento = true;
                }
            }

            while ( quantidade <= 0 ) 
            {
                Console.WriteLine("A Quantidade Digitada é Inválida, por favor Digite um valor maior que 0: ");

                quantidade = Convert.ToInt32(Console.ReadLine());
            }

            if (!existeMedicamento)
            {
                Medicamento medicamento = new Medicamento(nome, descricao, quantidade);

                RepositorioMedicamento.Cadastrar(medicamento);
                Program.ExibirMensagem("O medicamento foi cadastrado com sucesso!", ConsoleColor.Green);
            }
            else
            {
                Program.ExibirMensagem("O medicamento foi atualizado com sucesso!", ConsoleColor.Green);

            }
        }







        public void EditarMedicamento()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|        Gestão de Medicamentos        |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("Editando Medicamento...");

            Console.WriteLine();

            VisualizarItens(false);

            Console.Write("Digite o ID do medicamento que deseja editar: ");
            int idMedicamentoEscolhido = Convert.ToInt32(Console.ReadLine());

            if (!RepositorioMedicamento.ExisteItem(idMedicamentoEscolhido))
            {
                Program.ExibirMensagem("O medicamento mencionado não existe!", ConsoleColor.DarkYellow);
                return;
            }

            Console.WriteLine();


            Console.Write("Digite o nome do medicamento: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a descrição do medicamento: ");
            string descricao = Console.ReadLine();

            Console.Write("Digite a quantidade:");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            Medicamento novoMedicamento = new Medicamento(nome, descricao, quantidade);


            bool conseguiuEditar = RepositorioMedicamento.Editar(idMedicamentoEscolhido, novoMedicamento);

            if (!conseguiuEditar)
            {
                Program.ExibirMensagem("Houve um erro durante a edição de medicamento", ConsoleColor.Red);
                return;
            }

            Program.ExibirMensagem("O medicamento foi editado com sucesso!", ConsoleColor.Green);
        }


        public void ExcluirMedicamento()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|        Gestão de Medicamentos        |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("Excluindo Medicamento...");

            Console.WriteLine();

            VisualizarItens(false);


            Console.Write("Digite o ID do medicamento que deseja excluir: ");
            int idMedicamentoEscolhido = Convert.ToInt32(Console.ReadLine());

            if (!RepositorioMedicamento.ExisteItem(idMedicamentoEscolhido))
            {
                Program.ExibirMensagem("O medicamento mencionado não existe!", ConsoleColor.DarkYellow);
                return;
            }

            bool conseguiuExcluir = RepositorioMedicamento.Excluir(idMedicamentoEscolhido);

            if (!conseguiuExcluir)
            {
                Program.ExibirMensagem("Houve um erro durante a exclusão do medicamento", ConsoleColor.Red);
                return;
            }

            Program.ExibirMensagem("O medicamento foi excluído com sucesso!", ConsoleColor.Green);
        }

        public void VisualizarItens(bool exibirTitulo)
        {
            bool pausaParaVisualizacao = false;

            if (exibirTitulo)
            {
                Console.Clear();

                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"|        Gestão de <Medicamentos>        |");
                Console.WriteLine("----------------------------------------");

                Console.WriteLine();

                Console.WriteLine($"Visualizando Medicamentos...");

                pausaParaVisualizacao = true;
            }
            Console.WriteLine();



            Console.WriteLine(
                "| {0, -10} | {1, -15} | {2, -15} | {3, -10} |",
                    "Id", "Nome", "Descrição", "Quantidade"
                );

            Entidade[] medicamentosCadastrados = RepositorioMedicamento.SelecionarTudo();

            foreach (Medicamento medic in medicamentosCadastrados)
            {
                if (medic == null)
                    continue;

                Console.WriteLine(
                    "| {0, -10} | {1, -15} | {2, -15} | {3, -10} |",
                    medic.Id, medic.Nome, medic.Descricao, medic.Quantidade
                );
            }
            


            if (pausaParaVisualizacao)
                Console.ReadLine();

            Console.WriteLine();
        }
    }
}
