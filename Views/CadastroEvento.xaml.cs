using CadastroEventos.Models;

namespace CadastroEventos.Views;

public partial class CadastroEvento : ContentPage
{
    public CadastroEvento()
    {
        InitializeComponent();

        dtpck_inicio.MinimumDate = DateTime.Today;
        dtpck_inicio.Date = DateTime.Today;

        dtpck_termino.MinimumDate = DateTime.Today;
        dtpck_termino.Date = DateTime.Today.AddDays(1);
    }

    private void dtpck_inicio_DateSelected(object? sender, DateChangedEventArgs e)
    {
        DateTime inicio = e.NewDate ?? DateTime.Today;

        dtpck_termino.MinimumDate = inicio;

        if (dtpck_termino.Date < inicio)
            dtpck_termino.Date = inicio;
    }

    private async void Button_Clicked(object? sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(txt_nome.Text))
                throw new Exception("Informe o nome do evento.");

            if (string.IsNullOrWhiteSpace(txt_local.Text))
                throw new Exception("Informe o local do evento.");

            if (!int.TryParse(txt_participantes.Text, out int participantes) || participantes <= 0)
                throw new Exception("Informe um número de participantes válido.");

            if (!double.TryParse(txt_custo.Text, out double custo) || custo < 0)
                throw new Exception("Informe um custo por participante válido.");

            Evento evento = new Evento
            {
                Nome = txt_nome.Text.Trim(),
                Local = txt_local.Text.Trim(),
                DataInicio = dtpck_inicio.Date ?? DateTime.Today,
                DataTermino = dtpck_termino.Date ?? DateTime.Today,
                NumeroParticipantes = participantes,
                CustoPorParticipante = custo
            };

            if (evento.DataTermino < evento.DataInicio)
                throw new Exception("A data de término não pode ser anterior à data de início.");

            await Navigation.PushAsync(new ResumoEvento()
            {
                BindingContext = evento
            });
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Ops", ex.Message, "OK");
        }
    }
}
