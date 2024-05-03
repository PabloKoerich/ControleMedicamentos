using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicao.Entrada
{
    class RequisicaoEntrada : EntidadeBase
    {
        public Medicamento Medicamento { get; set; }
        public Funcionario Funcionario { get; set; }
        public Fornecedor fornecedor { get; set; }
        public DateTime DataRequisicao { get; set; }
        public int QuantidadeRetirada { get; set; }
        public object Fornecedor { get; internal set; }

        public RequisicaoEntrada(Medicamento medicamentoSelecionado, Fornecedor fornecedorSelecionado, Funcionario funcionarioSelecionado, int quantidade)
        {
            Medicamento = null;
            Funcionario = funcionarioSelecionado;

            DataRequisicao = DateTime.Now;
            QuantidadeRetirada = quantidade;
        }

        public override string[] Validar()
        {
            string[] erros = new string[3];
            int contadorErros = 0;

            if (Medicamento == null)
                erros[contadorErros++] = "O medicamento precisa ser devidamente preenchido";

            if (Fornecedor == null)
                erros[contadorErros++] = "O Nome do fornecedor precisa ser informado corretamente";

            if (Funcionario == null)
                erros[contadorErros++] = "O Nome do funcionario precisa ser informado corretamente";

            if (QuantidadeRetirada < 1)
                erros[contadorErros++] = "Por favor informe uma quantidade válida";

            string[] errosFiltrados = new string[contadorErros];

            Array.Copy(erros, errosFiltrados, contadorErros);

            return errosFiltrados;
        }

        public bool RetirarMedicamento()
        {
            if (Medicamento.Quantidade < QuantidadeRetirada)
                return false;

            Medicamento.Quantidade -= QuantidadeRetirada;
            return true;
        }

        internal bool EntradaMedicamento()
        {
            throw new NotImplementedException();
        }
    }
}
