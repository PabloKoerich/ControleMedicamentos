using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using Microsoft.Win32;

namespace ControleMedicamentos.ConsoleApp.Compartilhado
{
    public class Repositorio
    {
        protected Entidade[] itens = new Entidade[100];

        protected int contadorId = 1;

        public void Cadastrar(Entidade novaEntidade)
        {
            novaEntidade.Id = contadorId++;
            
            RegistrarItem(novaEntidade);
        }


        public Entidade[] SelecionarTudo()
        {
            return itens;
        }


        public bool Editar(int id, Entidade novaEntidade)
        {
            novaEntidade.Id = id;

            for (int i = 0; i < itens.Length; i++)
            {
                if (itens[i] == null)
                    continue;

                else if (itens[i].Id == id)
                {
                    itens[i] = novaEntidade;

                    return true;
                }
            }

            return false;
        }

        public bool Excluir(int id)
        {
            for (int i = 0; i < itens.Length; i++)
            {
                if (itens[i] == null)
                    continue;

                else if (itens[i].Id == id)
                {
                    itens[i] = null;
                    return true;
                }
            }

            return false;
        }



        public bool ExisteItem(int id)
        {
            for (int i = 0; i < itens.Length; i++)
            {
                Entidade e = itens[i];

                if (e == null)
                    continue;

                else if (e.Id == id)
                    return true;
            }

            return false;
        }



        public Entidade SelecionarPorId(int id)
        {
            for (int i = 0; i < itens.Length; i++)
            {
                Entidade ent = itens[i];

                if (ent == null)
                    continue;

                else if (ent.Id == id)
                    return ent;
            }

            return null;
        }



        protected void RegistrarItem(Entidade novaEntidade)
        {
            for (int i = 0; i < itens.Length; i++)
            {
                if (itens[i] != null)
                    continue;

                else
                {
                    itens[i] = novaEntidade;
                    break;
                }
            }
        }
    }
}
