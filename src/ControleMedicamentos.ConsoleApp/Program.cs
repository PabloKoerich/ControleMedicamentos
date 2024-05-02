using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;
using ControleMedicamentos.ConsoleApp.ModuloRequisicao;
using ControleMedicamentos.ConsoleApp.ModuloFornecedor;


namespace ControleMedicamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RepositorioPaciente repositorioPaciente = new RepositorioPaciente();

            #region Tela Paciente
            TelaPaciente telaPaciente = new TelaPaciente();
            telaPaciente.tipoEntidade = "Paciente";
            telaPaciente.repositorio = repositorioPaciente;
            #endregion

            telaPaciente.CadastrarEntidadeTeste();

            RepositorioMedicamento repositorioMedicamento = new RepositorioMedicamento();

            #region Tela Medicamento
            TelaMedicamento telaMedicamento = new TelaMedicamento();
            telaMedicamento.repositorio = repositorioMedicamento;
            telaMedicamento.tipoEntidade = "Medicamento";
            #endregion

            RepositorioRequisicaoSaida repositorioRequisicaoSaida = new RepositorioRequisicaoSaida();

            #region Tela Requisição
            TelaRequisicaoSaida telaRequisicaoSaida = new TelaRequisicaoSaida();
            telaRequisicaoSaida.repositorio = repositorioRequisicaoSaida;
            telaRequisicaoSaida.tipoEntidade = "Requisição";
            #endregion

            RepositorioFuncionario repositorioFuncionario = new RepositorioFuncionario();

            #region Tela Funcionário
            TelaFuncionario telaFuncionario = new TelaFuncionario();
            telaFuncionario.repositorio = repositorioFuncionario;
            telaFuncionario.tipoEntidade = "Funcionário";
            #endregion


            telaRequisicaoSaida.telaPaciente = telaPaciente;
            telaRequisicaoSaida.telaMedicamento = telaMedicamento;

            telaRequisicaoSaida.repositorioPaciente = repositorioPaciente;
            telaRequisicaoSaida.repositorioMedicamento = repositorioMedicamento;

            RepositorioFornecedor repositorioFornecedor = new RepositorioFornecedor(); 
              
            TelaFornecedor telafornecedor = new TelaFornecedor();
            telafornecedor.repositorio = repositorioFornecedor;
            telafornecedor.tipoEntidade = "Fornecedor";


            while (true)
            {
                char opcaoPrincipalEscolhida = TelaPrincipal.ApresentarMenuPrincipal();

                if (opcaoPrincipalEscolhida == 'S' || opcaoPrincipalEscolhida == 's')
                    break;

                TelaBase tela = null;

                if (opcaoPrincipalEscolhida == '1')
                    tela = telaPaciente;

                else if (opcaoPrincipalEscolhida == '2')
                    tela = telaMedicamento;

                else if (opcaoPrincipalEscolhida == '3')
                    tela = telaRequisicaoSaida;
                
                else if (opcaoPrincipalEscolhida == '4')
                    tela = telaFuncionario;


             
                else if (opcaoPrincipalEscolhida == '5')
                    tela = telafornecedor;


                char operacaoEscolhida = tela.ApresentarMenu();


                if (operacaoEscolhida == 'S' || operacaoEscolhida == 's')
                    continue;

                if (operacaoEscolhida == '1')
                    tela.Registrar();

                else if (operacaoEscolhida == '2')
                    tela.Editar();

                else if (operacaoEscolhida == '3')
                    tela.Excluir();

                else if (operacaoEscolhida == '4')
                    tela.VisualizarRegistros(true);
           
            
            
            }

            Console.ReadLine();
        }
    }
}
