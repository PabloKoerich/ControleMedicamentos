using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;
using System;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicao
{
    public class Requisicao : Entidade
    {
        public Medicamento Medicamento { get; set; }
        public Paciente Paciente { get; set; }

        public int Quantidade { get; set; }
        public DateTime DataValidade { get; set; }


        public Requisicao(Medicamento medicamento, Paciente paciente, int quantidade, DateTime dataValidade)
        {
            Medicamento = medicamento;
            Paciente = paciente;
            Quantidade = quantidade;
            DataValidade = dataValidade;
        }
    }
}
