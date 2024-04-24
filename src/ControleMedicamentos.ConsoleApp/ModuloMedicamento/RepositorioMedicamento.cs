using ControleMedicamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class RepositorioMedicamento
    {
        private Medicamento[] medicamentos = new Medicamento[100];

        public void CadastrarMedicamento(Medicamento novoMedicamento)
        {
            novoMedicamento.Id = GeradorId.GerarIdMedicamento();

            RegistrarItem(novoMedicamento);
        }

        private void RegistrarItem(Medicamento medicamento)
        {
            for (int i = 0; i < medicamentos.Length; i++)
            {
                if (medicamentos[i] != null)
                    continue;

                else
                {
                    medicamentos[i] = medicamento;
                    break;
                }
            }
        }

        public Medicamento[] SelecionarMedicamentos()
        {
            return medicamentos;
        }

        public bool ExisteMedicamento(int id)
        {
            for (int i = 0; i < medicamentos.Length; i++)
            {
                Medicamento e = medicamentos[i];

                if (e == null)
                    continue;

                else if (e.Id == id)
                    return true;
            }

            return false;
        }

        public bool EditarMedicamento(int id, Medicamento novoMedicamento)
        {
            novoMedicamento.Id = id;

            for (int i = 0; i < medicamentos.Length; i++)
            {
                if (medicamentos[i] == null)
                    continue;

                else if (medicamentos[i].Id == id)
                {
                    medicamentos[i] = novoMedicamento;

                    return true;
                }
            }

            return false;
        }

        public bool ExcluirMedicamento(int id)
        {
            for (int i = 0; i < medicamentos.Length; i++)
            {
                if (medicamentos[i] == null)
                    continue;

                else if (medicamentos[i].Id == id)
                {
                    medicamentos[i] = null;
                    return true;
                }
            }

            return false;
        }
    }
}
