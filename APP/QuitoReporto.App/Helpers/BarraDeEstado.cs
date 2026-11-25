using CommunityToolkit.Maui.Core;
using QuitoReporto.App.Views.Auth;

namespace QuitoReporto.App.Helpers
{
    /// <summary>
    /// Pinta la barra de estado del sistema del mismo color que el fondo de la pantalla actual
    /// (azul noche en el inicio de sesión). Todas las pantallas de la app son oscuras, así que los
    /// iconos de la barra (hora, señal, batería) siempre van claros, sin importar el tema del teléfono.
    /// </summary>
    public static class BarraDeEstado
    {
        public static void Ajustar(Page? pagina)
        {
#if ANDROID || IOS
            try
            {
                var color = pagina is LoginPage
                    ? Recurso("Ink")
                    : pagina?.BackgroundColor ?? Recurso("Navy");

                CommunityToolkit.Maui.Core.Platform.StatusBar.SetColor(color);
                CommunityToolkit.Maui.Core.Platform.StatusBar.SetStyle(StatusBarStyle.LightContent);
            }
            catch
            {
                // La barra de estado es solo estética: nunca debe interrumpir la navegación
            }
#endif
        }

        private static Color Recurso(string clave) =>
            Application.Current?.Resources.TryGetValue(clave, out var valor) == true && valor is Color c ? c : Colors.Black;
    }
}
