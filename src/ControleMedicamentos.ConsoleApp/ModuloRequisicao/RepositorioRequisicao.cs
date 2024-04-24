using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloRequisicao;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicao
{
    public class RepositorioRequisicao
    {
        private Requisicao[] requisicoes = new Requisicao[100];

        public void CadastrarRequisicao(Requisicao novaRequisicao)
        {
            novaRequisicao.Id = GeradorId.GerarIdRequisicao();

            RegistrarItem(novaRequisicao);
        }

        private void RegistrarItem(Requisicao paciente)
        {
            for (int i = 0; i < requisicoes.Length; i++)
            {
                if (requisicoes[i] != null)
                    continue;

                else
                {
                    requisicoes[i] = paciente;
                    break;
                }
            }
        }

        public Requisicao[] SelecionarRequisicaos()
        {
            return requisicoes;
        }

        public bool ExisteRequisicao(int id)
        {
            for (int i = 0; i < requisicoes.Length; i++)
            {
                Requisicao e = requisicoes[i];

                if (e == null)
                    continue;

                else if (e.Id == id)
                    return true;
            }

            return false;
        }

        public bool EditarRequisicao(int id, Requisicao novoRequisicao)
        {
            novoRequisicao.Id = id;

            for (int i = 0; i < requisicoes.Length; i++)
            {
                if (requisicoes[i] == null)
                    continue;

                else if (requisicoes[i].Id == id)
                {
                    requisicoes[i] = novoRequisicao;

                    return true;
                }
            }

            return false;
        }

        public bool ExcluirRequisicao(int id)
        {
            for (int i = 0; i < requisicoes.Length; i++)
            {
                if (requisicoes[i] == null)
                    continue;

                else if (requisicoes[i].Id == id)
                {
                    requisicoes[i] = null;
                    return true;
                }
            }

            return false;
        }
    }
}
