using Logica;

namespace TrabalhandoComCSV
{
	internal static class Program
	{
		[STAThread]
		static void Main()
		{
			ApplicationConfiguration.Initialize();
			Application.Run(new frmPrincipal());
		}
	}
}