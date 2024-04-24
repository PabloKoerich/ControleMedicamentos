namespace ControleMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class TelaMedicamento
    {
        public RepositorioMedicamento repositorio = new RepositorioMedicamento();

        public TelaMedicamento()
        {
            Medicamento medicamentoTeste = new Medicamento("Sertralina", "Antidepressivo", 20);

            repositorio.CadastrarMedicamento(medicamentoTeste);
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
            string nome = Console.ReadLine();

            Console.Write("Digite a descrição do medicamento: ");
            string descricao = Console.ReadLine();

            Console.Write("Digite a quantidade:");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            Medicamento medicamento = new Medicamento(nome, descricao, quantidade);

            repositorio.CadastrarMedicamento(medicamento);

            Program.ExibirMensagem("O medicamento foi cadastrado com sucesso!", ConsoleColor.Green);
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

            VisualizarMedicamentos(false);

            Console.Write("Digite o ID do medicamento que deseja editar: ");
            int idMedicamentoEscolhido = Convert.ToInt32(Console.ReadLine());

            if (!repositorio.ExisteMedicamento(idMedicamentoEscolhido))
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


            bool conseguiuEditar = repositorio.EditarMedicamento(idMedicamentoEscolhido, novoMedicamento);

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

            VisualizarMedicamentos(false);

            Console.Write("Digite o ID do medicamento que deseja excluir: ");
            int idMedicamentoEscolhido = Convert.ToInt32(Console.ReadLine());

            if (!repositorio.ExisteMedicamento(idMedicamentoEscolhido))
            {
                Program.ExibirMensagem("O medicamento mencionado não existe!", ConsoleColor.DarkYellow);
                return;
            }

            bool conseguiuExcluir = repositorio.ExcluirMedicamento(idMedicamentoEscolhido);

            if (!conseguiuExcluir)
            {
                Program.ExibirMensagem("Houve um erro durante a exclusão do medicamento", ConsoleColor.Red);
                return;
            }

            Program.ExibirMensagem("O medicamento foi excluído com sucesso!", ConsoleColor.Green);
        }




        public void VisualizarMedicamentos(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                Console.Clear();

                Console.WriteLine("----------------------------------------");
                Console.WriteLine("|        Gestão de Medicamentos        |");
                Console.WriteLine("----------------------------------------");

                Console.WriteLine();

                Console.WriteLine("Visualizando Medicamentos...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -15}",
                "Id", "Nome", "Quantidade"
                );

            Medicamento[] medicamentosCadastrados = repositorio.SelecionarMedicamentos();

            for (int i = 0; i < medicamentosCadastrados.Length; i++)
            {
                Medicamento medic = medicamentosCadastrados[i];

                if (medic == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -15} | {2, -15}",
                    medic.Id, medic.Nome, medic.Quantidade
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }
    }
}
