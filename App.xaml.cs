using System.Globalization;

namespace CadastroEventos;

public partial class App : Application
{
	public App()
	{
		CultureInfo cultura = new CultureInfo("pt-BR");
		CultureInfo.DefaultThreadCurrentCulture = cultura;
		CultureInfo.DefaultThreadCurrentUICulture = cultura;
		CultureInfo.CurrentCulture = cultura;
		CultureInfo.CurrentUICulture = cultura;

		InitializeComponent();

		UserAppTheme = AppTheme.Light;
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new Window(new AppShell());
	}
}
