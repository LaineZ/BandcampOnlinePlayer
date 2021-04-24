using BandcampOnlinePlayer;
using Eto.Forms;
using System;

public class Program
{
	[STAThread]
	static void Main()
	{
		new Application().Run(new SplashScreen());
	}
}