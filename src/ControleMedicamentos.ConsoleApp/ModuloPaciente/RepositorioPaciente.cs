using ControleMedicamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloPaciente
{
    public class RepositorioPaciente
    {
        private Paciente[] pacientes = new Paciente[100];

        public void CadastrarPaciente(Paciente novoPaciente)
        {
            novoPaciente.Id = GeradorId.GerarIdPaciente();

            RegistrarItem(novoPaciente);
        }

        private void RegistrarItem(Paciente paciente)
        {
            for (int i = 0; i < pacientes.Length; i++)
            {
                if (pacientes[i] != null)
                    continue;

                else
                {
                    pacientes[i] = paciente;
                    break;
                }
            }
        }

        public Paciente[] SelecionarPacientes()
        {
            return pacientes;
        }

        public bool ExistePaciente(int id)
        {
            for (int i = 0; i < pacientes.Length; i++)
            {
                Paciente e = pacientes[i];

                if (e == null)
                    continue;

                else if (e.Id == id)
                    return true;
            }

            return false;
        }

        public bool EditarPaciente(int id, Paciente novoPaciente)
        {
            novoPaciente.Id = id;

            for (int i = 0; i < pacientes.Length; i++)
            {
                if (pacientes[i] == null)
                    continue;

                else if (pacientes[i].Id == id)
                {
                    pacientes[i] = novoPaciente;

                    return true;
                }
            }

            return false;
        }

        public bool ExcluirPaciente(int id)
        {
            for (int i = 0; i < pacientes.Length; i++)
            {
                if (pacientes[i] == null)
                    continue;

                else if (pacientes[i].Id == id)
                {
                    pacientes[i] = null;
                    return true;
                }
            }

            return false;
        }
    } 
}
