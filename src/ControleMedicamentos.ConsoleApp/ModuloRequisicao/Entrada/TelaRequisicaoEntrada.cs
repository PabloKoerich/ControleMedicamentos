using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;
using ControleMedicamentos.ConsoleApp.ModuloRequisicao;
using ControleMedicamentos.ConsoleApp.ModuloFornecedor;



namespace ControleMedicamentos.ConsoleApp.ModuloRequisicao.Entrada 
{
    internal class TelaRequisicaoEntrada : TelaBase
    {
        public TelaMedicamento telaMedicamento = null;
        public TelaFuncionario telaFuncionario = null;
        public RepositorioMedicamento repositorioMedicamento = null;
        public RepositorioFuncionario repositorioFuncionario = null; 
        public RepositorioFornecedor repositorioFornecedor = null; 
        

        public override void Registrar()
        {
            ApresentarCabecalho();

            Console.WriteLine($"Cadastrando {tipoEntidade}...");

            Console.WriteLine();

            RequisicaoEntrada entidade = (RequisicaoEntrada)ObterRegistro();

            string[] erros = entidade.Validar();

            if (erros.Length > 0)
            {
                ApresentarErros(erros);
                return;
            }

            bool conseguiuCadastrar = entidade.EntradaMedicamento();

            if (!conseguiuCadastrar)
            {
                ExibirMensagem("A quantidade de retirada informada não está disponível.", ConsoleColor.DarkYellow);
                return;
            }

            repositorio.Cadastrar(entidade);

            ExibirMensagem($"O {tipoEntidade} cadastrado com sucesso!", ConsoleColor.Green);
        }

        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Requisições de Entrada...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -15} | {3, -20} | {4, -5} | {5, -5}",
                "Id", "Medicamento", "Funcionario", "Fornecedor", "Data de Requisição", "Quantidade"
            );

            EntidadeBase[] requisicoesCadastradas = repositorio.SelecionarTodos();

            foreach (RequisicaoEntrada requisicao in requisicoesCadastradas)
            {
                if (requisicao == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -15} | {2, -15} | {3, -20} | {4, -5} | {5, -5}",
                    requisicao.Id,
                    requisicao.Medicamento.Nome,
                    requisicao.Funcionario.Nome,
                    requisicao.Fornecedor,
                    requisicao.DataRequisicao.ToShortDateString(),
                    requisicao.QuantidadeRetirada
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            telaMedicamento.VisualizarRegistros(false);

            Console.Write("Digite o ID do medicamento cadastrado: ");
            int idMedicamento = Convert.ToInt32(Console.ReadLine());

            Medicamento medicamentoSelecionado = (Medicamento)repositorioMedicamento.SelecionarPorId(idMedicamento);

            telaFuncionario.VisualizarRegistros(false);

            Console.Write("Digite o ID do Funcionário: ");
            int idFuncionario = Convert.ToInt32(Console.ReadLine());

            Funcionario funcionarioselecionado = (Funcionario)repositorioFuncionario.SelecionarPorId(idFuncionario);

            Console.Write("Digite a quantidade do medicamente que deseja Cadastrar: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o ID do Fornecedor: ");
            int idFornecedor = Convert.ToInt32(Console.ReadLine());
            Fornecedor fornecedorselecionado = (Fornecedor)repositorioFornecedor.SelecionarPorId(idFornecedor);

            RequisicaoEntrada novaRequisicao = new RequisicaoEntrada (medicamentoSelecionado, fornecedorselecionado, funcionarioselecionado, quantidade);

            return novaRequisicao;
        }
    }
}
