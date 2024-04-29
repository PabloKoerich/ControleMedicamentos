using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;
using ControleMedicamentos.ConsoleApp.ModuloRequisicao;
using System;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicao
{
    public class TelaRequisicao
    {
        RepositorioMedicamento RepositorioMedicamento { get; set; }
        RepositorioPaciente RepositorioPaciente { get; set; }
        RepositorioRequisicao RepositorioRequisicao { get; set; }


        public TelaRequisicao(RepositorioRequisicao repositorioRequisicao, RepositorioMedicamento repositorioMedicamento, RepositorioPaciente repositorioPaciente)
        {
            RepositorioRequisicao = repositorioRequisicao;
            RepositorioMedicamento = repositorioMedicamento;
            RepositorioPaciente = repositorioPaciente;
        }



        public char ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("|        Gestão de Requisicaos        |");
            Console.WriteLine("---------------------------------------");

            Console.WriteLine();

            Console.WriteLine("1 - Cadastrar Requisicao");
            Console.WriteLine("2 - Editar Requisicao");
            Console.WriteLine("3 - Excluir Requisicao");
            Console.WriteLine("4 - Visualizar Requisicoes");

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            char operacaoEscolhida = Convert.ToChar(Console.ReadLine());

            return operacaoEscolhida;
        }



        public void CadastrarRequisicao()
        {
            Console.Clear();

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("|        Gestão de Requisições        |");
            Console.WriteLine("---------------------------------------");

            Console.WriteLine();

            Console.WriteLine("Cadastrando Requisição...");

            Console.WriteLine();





            //adicionar a listagem de medicamentos para o usuario escolher o id do medicamento
            Console.WriteLine(
            "| {0, -10} | {1, -15} | {2, -15} | {3, -10} |",
                 "Id", "Nome", "Descrição", "Quantidade"
            );

            Entidade[] medicamentosCadastrados = RepositorioMedicamento.SelecionarTudo();

            foreach (Medicamento medic in medicamentosCadastrados)
            {
                int quantidadeVerificada;

                if (medic == null)
                    continue;


                Console.WriteLine(
                    "| {0, -10} | {1, -15} | {2, -15} | {3, -10} |",
                    medic.Id, medic.Nome, medic.Descricao, medic.Quantidade
                );

            }


            Console.Write("Digite o ID do Medicamento: ");
            int idMedicamento = int.Parse(Console.ReadLine());

            Medicamento medicamentoSelecionado = (Medicamento)RepositorioMedicamento.SelecionarPorId(idMedicamento);



            while (medicamentoSelecionado.Quantidade <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("O Medicamento Escolhido não está Disponível no Estoque");
                Console.ResetColor();
                Console.WriteLine("Por Favor Escolha outro Medicamento: ");


                Console.Write("Digite o ID do Medicamento: ");
                idMedicamento = int.Parse(Console.ReadLine());

                medicamentoSelecionado = (Medicamento)RepositorioMedicamento.SelecionarPorId(idMedicamento);
            }

            if(medicamentoSelecionado.Quantidade > 0 && medicamentoSelecionado.Quantidade < 10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"O Medicamento Escolhido se encontra com Baixo Estoque: {medicamentoSelecionado.Quantidade}");
                Console.ResetColor();
            }



            //adicionar a listagem de pacientes para o usuario escolher o id do paciente
            Console.WriteLine(
            "| {0, -10} | {1, -15} | {2, -15} | {3, -20} |",
                "Id", "Nome", "CPF", "Numero do Cartão SUS"
            );

            Entidade[] pacientesCadastrados = RepositorioPaciente.SelecionarTudo();

            foreach (Paciente pac in pacientesCadastrados)
            {
                if (pac == null)
                    continue;

                Console.WriteLine(
                "| {0, -10} | {1, -15} | {2, -15} | {3, -20} |",
                 pac.Id, pac.Nome, pac.Cpf, pac.NumeroCartaoSus
                );
            }

            Console.Write("Digite o ID do Paciente: ");
            int idPaciente = int.Parse(Console.ReadLine());

            Paciente pacienteSelecionado = (Paciente)RepositorioPaciente.SelecionarPorId(idPaciente);




            Console.Write("Digite a quantidade de Medicamento: ");
            int quantidadeMedicamento = int.Parse(Console.ReadLine());

            bool quantidadeValida = false;

            while(!quantidadeValida)
            {
                if (quantidadeMedicamento > medicamentoSelecionado.Quantidade && quantidadeMedicamento != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("A quantidade Digitada é maior que o Estoque Presente, Por Favor Informe outro valor.");
                    Console.ResetColor();

                    Console.Write("Digite a quantidade de Medicamento: ");
                    quantidadeMedicamento = int.Parse(Console.ReadLine());
                }
                else
                    quantidadeValida = true;
            }

            medicamentoSelecionado.Quantidade -= quantidadeMedicamento;
            quantidadeValida = true;



            Console.Write("Digite a Data de Validade Requisicao:");
            DateTime dataValidade = Convert.ToDateTime(Console.ReadLine());




            Requisicao requisicao = new Requisicao(medicamentoSelecionado, pacienteSelecionado, quantidadeMedicamento, dataValidade);

            RepositorioRequisicao.Cadastrar(requisicao);

            Program.ExibirMensagem("O requisicao foi cadastrado com sucesso!", ConsoleColor.Green);
        }







        public void EditarRequisicao()
        {
            Console.Clear();

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("|        Gestão de Requisicaos        |");
            Console.WriteLine("---------------------------------------");

            Console.WriteLine();

            Console.WriteLine("Editando Requisicao...");

            Console.WriteLine();

            VisualizarItens(false);

            Console.Write("Digite o ID do requisicao que deseja editar: ");
            int idRequisicaoEscolhido = Convert.ToInt32(Console.ReadLine());

            if (!RepositorioRequisicao.ExisteItem(idRequisicaoEscolhido))
            {
                Program.ExibirMensagem("O requisicao mencionado não existe!", ConsoleColor.DarkYellow);
                return;
            }

            Console.WriteLine();



            //adicionar a listagem de medicamentos para o usuario escolher o id do medicamento
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


            Console.Write("Digite o ID do Medicamento: ");
            int idMedicamento = int.Parse(Console.ReadLine());

            Medicamento medicamentoSelecionado = (Medicamento)RepositorioMedicamento.SelecionarPorId(idMedicamento);





            //adicionar a listagem de pacientes para o usuario escolher o id do paciente
            Console.WriteLine(
            "| {0, -10} | {1, -15} | {2, -15} | {3, -20} |",
                "Id", "Nome", "CPF", "Numero do Cartão SUS"
            );

            Entidade[] pacientesCadastrados = RepositorioPaciente.SelecionarTudo();

            foreach (Paciente pac in pacientesCadastrados)
            {
                if (pac == null)
                    continue;

                Console.WriteLine(
                "| {0, -10} | {1, -15} | {2, -15} | {3, -20} |",
                 pac.Id, pac.Nome, pac.Cpf, pac.NumeroCartaoSus
                );
            }

            Console.Write("Digite o ID do Paciente: ");
            int idPaciente = int.Parse(Console.ReadLine());

            Paciente pacienteSelecionado = (Paciente)RepositorioPaciente.SelecionarPorId(idPaciente);




            Console.Write("Digite a quantidade de Medicamento: ");
            int quantidadeMedicamento = int.Parse(Console.ReadLine());

            Console.Write("Digite a Data de Validade Requisicao:");
            DateTime dataValidade = Convert.ToDateTime(Console.ReadLine());




            Requisicao novaRequisicao = new Requisicao(medicamentoSelecionado, pacienteSelecionado, quantidadeMedicamento, dataValidade);



            bool conseguiuEditar = RepositorioRequisicao.Editar(idRequisicaoEscolhido, novaRequisicao);

            if (!conseguiuEditar)
            {
                Program.ExibirMensagem("Houve um erro durante a edição de requisicao", ConsoleColor.Red);
                return;
            }

            Program.ExibirMensagem("O requisicao foi editado com sucesso!", ConsoleColor.Green);
        }


        public void ExcluirRequisicao()
        {
            Console.Clear();

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("|        Gestão de Requisicaos        |");
            Console.WriteLine("---------------------------------------");

            Console.WriteLine();

            Console.WriteLine("Excluindo Requisicao...");

            Console.WriteLine();

            VisualizarItens(false);

            Console.Write("Digite o ID do requisicao que deseja excluir: ");
            int idRequisicaoEscolhido = Convert.ToInt32(Console.ReadLine());

            if (!RepositorioRequisicao.ExisteItem(idRequisicaoEscolhido))
            {
                Program.ExibirMensagem("O requisicao mencionado não existe!", ConsoleColor.DarkYellow);
                return;
            }

            bool conseguiuExcluir = RepositorioRequisicao.Excluir(idRequisicaoEscolhido);

            if (!conseguiuExcluir)
            {
                Program.ExibirMensagem("Houve um erro durante a exclusão do requisicao", ConsoleColor.Red);
                return;
            }

            Program.ExibirMensagem("O requisicao foi excluído com sucesso!", ConsoleColor.Green);
        }




        public void VisualizarItens(bool exibirTitulo)
        {
            bool pausaParaVisualizacao = false;

            if (exibirTitulo)
            {
                Console.Clear();

                Console.WriteLine("---------------------------------------");
                Console.WriteLine("|        Gestão de Requisicaos        |");
                Console.WriteLine("---------------------------------------");

                Console.WriteLine();

                Console.WriteLine("Visualizando Requisicaos...");

                pausaParaVisualizacao = true;
            }

            Console.WriteLine();

            Console.WriteLine(
                "| {0, -5} | {1, -20} | {2, -20} | {3, -10} | {4, -10} |",
                   "Id",   "Medicamento", "Paciente", "Quantidade", "Data de Validade"
                );


            Entidade[] requisicoesCadastradas = RepositorioRequisicao.SelecionarTudo();

            foreach (Requisicao rec in requisicoesCadastradas)
            {
                if (rec == null)
                    continue;

                Console.WriteLine(
                "| {0, -5} | {1, -20} | {2, -20} | {3, -10} | {4, -10} |",
                   rec.Id, rec.Medicamento.Nome, rec.Paciente.Nome, rec.Quantidade, rec.DataValidade.ToShortDateString()
                );
            }


            if (pausaParaVisualizacao)
                Console.ReadLine();

            Console.WriteLine();
        }
    }
}
