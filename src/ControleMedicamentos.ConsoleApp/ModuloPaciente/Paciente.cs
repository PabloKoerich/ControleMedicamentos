using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloRequisicao;

namespace ControleMedicamentos.ConsoleApp.ModuloPaciente
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set;}
        public string Endereco { get; set; }
        public string NumeroCartaoSus { get; set; }
        
        public Requisicao[] Requisicoes { get; set; }

        public Paciente(string nome, string cpf, string endereco, string numeroSus)
        {
            Id = GeradorId.GerarIdPaciente();
            Nome = nome;
            Cpf = cpf;
            Endereco = endereco;
            NumeroCartaoSus = numeroSus;

            Requisicoes = new Requisicao[100];
        }
    }
}
