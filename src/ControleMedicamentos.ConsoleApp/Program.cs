using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;

namespace ControleMedicamentos.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            TelaMedicamento telaMedicamento = new TelaMedicamento();
            TelaPaciente telaPaciente = new TelaPaciente();



            ExibirTitulo();

            Console.WriteLine("----------Menu----------");
            Console.WriteLine("1 - Menu de Requisições");
            Console.WriteLine("2 - Menu de Medicamentos");
            Console.WriteLine("3 - Menu de Pacientes");
            Console.WriteLine("S - Sair");

            bool opcaoSairEscolhida = false;

            while (!opcaoSairEscolhida)
            {
                char opcaoPrincipalEscolhida = ApresentarMenuPrincipal();
                char operacaoEscolhida;

                switch (opcaoPrincipalEscolhida)
                {
                    case '1':
                        //operacaoEscolhida = telaEquipamento.ApresentarMenu();

                        //if (operacaoEscolhida == 'S' || operacaoEscolhida == 's')
                        //    break;

                        //if (operacaoEscolhida == '1')
                        //    telaEquipamento.CadastrarEquipamento();

                        //else if (operacaoEscolhida == '2')
                        //    telaEquipamento.EditarEquipamento();

                        //else if (operacaoEscolhida == '3')
                        //    telaEquipamento.ExcluirEquipamento();

                        //else if (operacaoEscolhida == '4')
                        //    telaEquipamento.VisualizarEquipamentos(true);

                        break;

                    case '2':
                        operacaoEscolhida = telaMedicamento.ApresentarMenu();

                        if (operacaoEscolhida == 'S' || operacaoEscolhida == 's')
                            break;

                        if (operacaoEscolhida == '1')
                            telaMedicamento.CadastrarMedicamento();

                        if (operacaoEscolhida == '2')
                            telaMedicamento.EditarMedicamento();

                        if (operacaoEscolhida == '3')
                            telaMedicamento.ExcluirMedicamento();

                        else if (operacaoEscolhida == '4')
                            telaMedicamento.VisualizarMedicamentos(true);

                        break;

                    case '3':
                        operacaoEscolhida = telaPaciente.ApresentarMenu();
                        
                        if (operacaoEscolhida == 'S' || operacaoEscolhida == 's')
                            break;

                        if (operacaoEscolhida == '1')
                            telaPaciente.CadastrarPaciente();

                        if (operacaoEscolhida == '2')
                            telaPaciente.EditarPaciente();

                        if (operacaoEscolhida == '3')
                            telaPaciente.ExcluirPaciente();

                        else if (operacaoEscolhida == '4')
                            telaPaciente.VisualizarPacientes(true);

                        break;

                    default: opcaoSairEscolhida = true; break;
                }
            }
        }

        #region Exibir Titulo
        private static void ExibirTitulo()
        {
            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine("| Controle de Medicamentos |");
            Console.WriteLine("----------------------------");
            Console.WriteLine();
        }
        #endregion


        private static char ApresentarMenuPrincipal()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|        Gestão de Medicamentos        |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("----------Menu----------");
            Console.WriteLine("1 - Menu de Requisições");
            Console.WriteLine("2 - Menu de Medicamentos");
            Console.WriteLine("3 - Menu de Pacientes");
            Console.WriteLine("S - Sair");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");

            char opcaoEscolhida = Console.ReadLine()[0];

            return opcaoEscolhida;
        }

        public static void ExibirMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;

            Console.WriteLine();

            Console.WriteLine(mensagem);

            Console.ResetColor();

            Console.ReadLine();
        }
    }
}
