using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;
using System;

namespace ControleMedicamentos.ConsoleApp.ModuloPaciente
{
    public class TelaPaciente : Tela
    {
        
        RepositorioPaciente RepositorioPaciente { get; set; }

        public TelaPaciente(RepositorioPaciente repositorioPaciente)
        {
            RepositorioPaciente = repositorioPaciente;

            Paciente pacienteTeste = new Paciente("Joaozinho", "111-222-333-44", "Bairro Universitario", "007 7500 4002 8922");

            RepositorioPaciente.Cadastrar(pacienteTeste);
        }






        public char ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("-------------------------------------");
            Console.WriteLine("|        Gestão de Pacientes        |");
            Console.WriteLine("-------------------------------------");

            Console.WriteLine();

            Console.WriteLine("1 - Cadastrar Paciente");
            Console.WriteLine("2 - Editar Paciente");
            Console.WriteLine("3 - Excluir Paciente");
            Console.WriteLine("4 - Visualizar Pacientes");

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            char operacaoEscolhida = Convert.ToChar(Console.ReadLine());

            return operacaoEscolhida;
        }



        public void CadastrarPaciente()
        {
            Console.Clear();

            Console.WriteLine("-------------------------------------");
            Console.WriteLine("|        Gestão de Pacientes        |");
            Console.WriteLine("-------------------------------------");

            Console.WriteLine();

            Console.WriteLine("Cadastrando Paciente...");

            Console.WriteLine();

            Console.Write("Digite o nome do paciente: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o CPF do paciente: ");
            string cpf = Console.ReadLine();

            Console.Write("Digite o endereço do paciente:");
            string endereco = Console.ReadLine();

            Console.Write("Digite o número do Cartão do SUS do paciente, ex: (000-0000-0000-0000):  ");
            string numeroSus = Console.ReadLine();

            Paciente paciente = new Paciente(nome, cpf, endereco, numeroSus);

            RepositorioPaciente.Cadastrar(paciente);

            Program.ExibirMensagem("O paciente foi cadastrado com sucesso!", ConsoleColor.Green);
        }







        public void EditarPaciente()
        {
            Console.Clear();

            Console.WriteLine("-------------------------------------");
            Console.WriteLine("|        Gestão de Pacientes        |");
            Console.WriteLine("-------------------------------------");

            Console.WriteLine();

            Console.WriteLine("Editando Paciente...");

            Console.WriteLine();

            VisualizarItens(false);

            Console.Write("Digite o ID do paciente que deseja editar: ");
            int idPacienteEscolhido = Convert.ToInt32(Console.ReadLine());

            if (!RepositorioPaciente.ExisteItem(idPacienteEscolhido))
            {
                Program.ExibirMensagem("O paciente mencionado não existe!", ConsoleColor.DarkYellow);
                return;
            }

            Console.WriteLine();



            Console.Write("Digite o nome do paciente: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o CPF do paciente: ");
            string cpf = Console.ReadLine();

            Console.Write("Digite o endereço do paciente:");
            string endereco = Console.ReadLine();

            Console.Write("Digite o número do Cartão do SUS do paciente, ex: (000-0000-0000-0000):  ");
            string numeroSus = Console.ReadLine();

            Paciente novoPaciente = new Paciente(nome, cpf, endereco, numeroSus);



            bool conseguiuEditar = RepositorioPaciente.Editar(idPacienteEscolhido, novoPaciente);

            if (!conseguiuEditar)
            {
                Program.ExibirMensagem("Houve um erro durante a edição de paciente", ConsoleColor.Red);
                return;
            }

            Program.ExibirMensagem("O paciente foi editado com sucesso!", ConsoleColor.Green);
        }


        public void ExcluirPaciente()
        {
            Console.Clear();

            Console.WriteLine("-------------------------------------");
            Console.WriteLine("|        Gestão de Pacientes        |");
            Console.WriteLine("-------------------------------------");

            Console.WriteLine();

            Console.WriteLine("Excluindo Paciente...");

            Console.WriteLine();

            VisualizarItens(false);

            Console.Write("Digite o ID do paciente que deseja excluir: ");
            int idPacienteEscolhido = Convert.ToInt32(Console.ReadLine());

            if (!RepositorioPaciente.ExisteItem(idPacienteEscolhido))
            {
                Program.ExibirMensagem("O paciente mencionado não existe!", ConsoleColor.DarkYellow);
                return;
            }

            bool conseguiuExcluir = RepositorioPaciente.Excluir(idPacienteEscolhido);

            if (!conseguiuExcluir)
            {
                Program.ExibirMensagem("Houve um erro durante a exclusão do paciente", ConsoleColor.Red);
                return;
            }

            Program.ExibirMensagem("O paciente foi excluído com sucesso!", ConsoleColor.Green);
        }


        public void VisualizarItens(bool exibirTitulo)
        {
            bool pausaParaVisualizacao = false;

            if (exibirTitulo)
            {
                Console.Clear();

                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"|        Gestão de Pacientes        |");
                Console.WriteLine("----------------------------------------");

                Console.WriteLine();

                Console.WriteLine($"Visualizando Pacientes...");

                pausaParaVisualizacao = true;
            }
            Console.WriteLine();



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



            if (pausaParaVisualizacao)
                Console.ReadLine();

            Console.WriteLine();
        }
    }
}