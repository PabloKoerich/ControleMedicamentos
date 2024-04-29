using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloRequisicao;

namespace ControleMedicamentos.ConsoleApp.ModuloPaciente
{
    public class Paciente : Entidade
    {
        public string Nome { get; set; }
        public string Cpf { get; set;}
        public string Endereco { get; set; }
        public string NumeroCartaoSus { get; set; }
        
        public Requisicao[] Requisicoes { get; set; }

        public Paciente(string nome, string cpf, string endereco, string numeroSus)
        {
            Nome = nome;
            Cpf = cpf;
            Endereco = endereco;
            NumeroCartaoSus = numeroSus;

            Requisicoes = new Requisicao[100];
        }
    }
}
