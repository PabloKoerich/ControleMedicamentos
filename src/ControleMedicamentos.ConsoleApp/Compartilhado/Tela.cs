using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;
using ControleMedicamentos.ConsoleApp.ModuloRequisicao;
using System;

namespace ControleMedicamentos.ConsoleApp.Compartilhado
{
    public class Tela
    {

        //public void VisualizarItens(bool exibirTitulo, string entidade)
        //{
        //    bool pausaParaVisualizacao = false;

        //    if (exibirTitulo)
        //    {
        //        Console.Clear();

        //        Console.WriteLine("----------------------------------------");
        //        Console.WriteLine($"|        Gestão de {entidade}        |");
        //        Console.WriteLine("----------------------------------------");

        //        Console.WriteLine();

        //        Console.WriteLine($"Visualizando {entidade}s...");

        //        pausaParaVisualizacao = true;
        //    }
        //    Console.WriteLine();



        //    if (entidade == "Medicamento")
        //    {
        //        Console.WriteLine(
        //            "| {0, -10} | {1, -15} | {2, -15} | {3, -10} |",
        //               "Id", "Nome", "Descrição", "Quantidade"
        //            );

        //        Entidade[] medicamentosCadastrados = repositorioMedicamento.SelecionarTudo();

        //        foreach (Medicamento medic in medicamentosCadastrados)
        //        {
        //            if (medic == null)
        //                continue;

        //            Console.WriteLine(
        //                "| {0, -10} | {1, -15} | {2, -15} | {3, -10} |",
        //                medic.Id, medic.Nome, medic.Descricao, medic.Quantidade
        //            );
        //        }
        //    }

        //    else if (entidade == "Paciente")
        //    {
        //        Console.WriteLine(
        //        "| {0, -10} | {1, -15} | {2, -15} | {3, -20} |",
        //            "Id", "Nome", "CPF", "Numero do Cartão SUS"
        //        );

        //        Entidade[] pacientesCadastrados = RepositorioPaciente.SelecionarTudo();

        //        foreach (Paciente pac in pacientesCadastrados)
        //        {
        //            if (pac == null)
        //                continue;

        //            Console.WriteLine(
        //            "| {0, -10} | {1, -15} | {2, -15} | {3, -20} |",
        //             pac.Id, pac.Nome, pac.Cpf, pac.NumeroCartaoSus
        //            );
        //        }
        //    }

        //    else if (entidade == "Requisicao")
        //    {
        //        Console.WriteLine(
        //        "| {0, -10} | {1, -15} | {2, -15} | {3, -20} |",
        //            "Id", "Nome", "CPF", "Numero do Cartão SUS"
        //        );

        //        Entidade[] requisicoesCadastradas = RepositorioRequisicao.SelecionarTudo();

        //        foreach (Requisicao rec in requisicoesCadastradas)
        //        {
        //            if (rec == null)
        //                continue;

        //            Console.WriteLine(
        //            "| {0, -10} | {1, -15} | {2, -15} | {3, -20} |",
        //               rec.Id, rec.Medicamento, rec.Paciente, rec.Quantidade, rec.DataValidade
        //            );
        //        }
        //    }



        //    if (pausaParaVisualizacao)
        //        Console.ReadLine();

        //    Console.WriteLine();
        //}

    }
}
