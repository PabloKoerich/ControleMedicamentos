using ControleMedicamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class Medicamento
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }

        public Medicamento(string nome, string descricao, int quantidade)
        {
            Id = GeradorId.GerarIdMedicamento();
            Nome = nome;
            Descricao = descricao;
            Quantidade = quantidade;
        }
    }
}
