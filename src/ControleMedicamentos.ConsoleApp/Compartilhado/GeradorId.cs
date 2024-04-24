namespace ControleMedicamentos.ConsoleApp.Compartilhado
{
    public static class GeradorId
    {
        private static int idMedicamento = 0;
        private static int idPaciente = 0;
        private static int idRequisicao = 0;

        public static int GerarIdMedicamento()
        {
            return ++idMedicamento;
        }        
        
        public static int GerarIdPaciente()
        {
            return ++idPaciente;
        }        
        
        public static int GerarIdRequisicao()
        {
            return ++idRequisicao;
        }
    }
}
