using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace Assesment1;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("christmas.ttf", "Christmas");
                fonts.AddFont("homemadesausage.ttf", "HomeMadeSausage");
                fonts.AddFont("tinyangels.ttf", "TinyAngels");
				fonts.AddFont("winkleregular.ttf", "WinkleRegular");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
