
using ControleMedicamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloFornecedor
{
    internal class Fornecedor : EntidadeBase 
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string CNPJ { get; set; }

        public Fornecedor (string nome, string telefone, string Cnpj)
        {
            Nome = nome;
            Telefone = telefone;
            CNPJ = Cnpj;
        }

        public override string[] Validar()
        {
            string[] erros = new string[3];
            int contadorErros = 0;

            if (Nome.Length < 3)
                erros[contadorErros++] = "O Nome do Fornecedor precisa conter ao menos 3 caracteres";

            if (string.IsNullOrEmpty(Telefone))
                erros[contadorErros++] = "O Telefone precisa ser preenchido corretamente";

            if (string.IsNullOrEmpty(CNPJ))
                erros[contadorErros++] = "O CNPJ do Fornecedor precisa ser preenchido";

            string[] errosFiltrados = new string[contadorErros];

            Array.Copy(erros, errosFiltrados, contadorErros);

            return errosFiltrados;
        }
    }
}