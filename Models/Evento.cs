namespace CadastroEventos.Models
{
    public class Evento
    {
        public string Nome { get; set; } = string.Empty;
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public int NumeroParticipantes { get; set; }
        public string Local { get; set; } = string.Empty;
        public double CustoPorParticipante { get; set; }

        public TimeSpan Intervalo
        {
            get => DataTermino.Date.Subtract(DataInicio.Date);
        }

        public int DuracaoEmDias
        {
            get => Intervalo.Days + 1;
        }

        public double CustoTotal
        {
            get => NumeroParticipantes * CustoPorParticipante;
        }
    }
}
