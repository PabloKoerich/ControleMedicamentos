
using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFornecedor;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamento
{
    internal class TelaFornecedor : TelaBase
    {
        public override char ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"        Gestão de {tipoEntidade}es        ");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine($"1 - Cadastrar {tipoEntidade}");
            Console.WriteLine($"2 - Editar {tipoEntidade}");
            Console.WriteLine($"3 - Excluir {tipoEntidade}");
            Console.WriteLine($"4 - Visualizar {tipoEntidade}es");

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            char operacaoEscolhida = Convert.ToChar(Console.ReadLine());

            return operacaoEscolhida;
        }





        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Fornecedores...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20}",
                "Id", "Nome" 
            );

            EntidadeBase[] FornecedorCadastrados = repositorio.SelecionarTodos();

            foreach ( Fornecedor fornecedor in FornecedorCadastrados)
            {
                if (fornecedor == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20}",
                    fornecedor.Id, fornecedor.Nome, fornecedor.CNPJ
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o nome do Fornecedor: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o telefone do Fornecedor: ");
            string telefone = Console.ReadLine();
            
            Console.Write("Digite o CNPJ do Fornecedor: ");
            string Cnpj = Console.ReadLine();

            
            Fornecedor fornecedor = new Fornecedor (nome,telefone,Cnpj);

            return fornecedor;
        }
    }
}
