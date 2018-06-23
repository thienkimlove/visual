using System;
using System.Linq;
using System.Windows.Forms;

namespace AutoLead
{
	// Token: 0x0200005E RID: 94
	internal static class Program
	{
		// Token: 0x060003BA RID: 954 RVA: 0x00027034 File Offset: 0x00025234
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			bool flag = args.Count<string>() > 0;
			if (flag)
			{
				Application.Run(new Form1(args[0]));
			}
			else
			{
				Application.Run(new Form1("none"));
			}
		}
	}
}
