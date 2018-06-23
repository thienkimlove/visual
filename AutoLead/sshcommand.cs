using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace AutoLead
{
	// Token: 0x02000063 RID: 99
	internal class sshcommand
	{
		// Token: 0x060003E6 RID: 998
		[DllImport("User32.dll")]
		private static extern bool SetForegroundWindow(IntPtr hWnd);

		// Token: 0x060003E7 RID: 999
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern int SendMessageA(IntPtr hwnd, int wMsg, int wParam, uint lParam);

		// Token: 0x060003E8 RID: 1000
		[DllImport("user32.dll")]
		private static extern IntPtr FindWindow(string sClass, string sWindow);

		// Token: 0x060003E9 RID: 1001
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

		// Token: 0x060003EA RID: 1002
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int msg, int Param, StringBuilder text);

		// Token: 0x060003EB RID: 1003
		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		public static extern int SendMessage1(IntPtr hWnd, int msg, IntPtr Param, IntPtr text);

		// Token: 0x060003EC RID: 1004
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr GetDlgItem(int hwnd, int childID);

		// Token: 0x060003ED RID: 1005
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int GetWindowText(IntPtr hwnd, IntPtr windowString, int maxcount);

		// Token: 0x060003EE RID: 1006
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr GetWindowLong(IntPtr hwnd, int nIndex);

		// Token: 0x060003EF RID: 1007
		[DllImport("user32", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool EnumThreadWindows(int threadId, sshcommand.EnumWindowsProc callback, IntPtr lParam);

		// Token: 0x060003F0 RID: 1008
		[DllImport("user32", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool EnumChildWindows(IntPtr hwndParent, sshcommand.EnumWindowsProc lpEnumFunc, IntPtr lParam);

		// Token: 0x060003F1 RID: 1009
		[DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int maxCount);

		// Token: 0x060003F2 RID: 1010 RVA: 0x00027714 File Offset: 0x00025914
		public static string ControlGetText(IntPtr hwnd)
		{
			StringBuilder stringBuilder = new StringBuilder(255);
			int num = sshcommand.SendMessage(hwnd, 13, stringBuilder.Capacity, stringBuilder);
			return stringBuilder.ToString();
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x00027748 File Offset: 0x00025948
		public static void ControlClick(IntPtr hwnd)
		{
			int num = sshcommand.SendMessage1(hwnd, 513, IntPtr.Zero, IntPtr.Zero);
			sshcommand.SendMessage1(hwnd, 514, IntPtr.Zero, IntPtr.Zero);
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x00027784 File Offset: 0x00025984
		public static IntPtr ControlGetHandle(IntPtr parentHandle, string _controlClass, int ID)
		{
			bool flag = parentHandle == IntPtr.Zero;
			IntPtr result;
			if (flag)
			{
				result = IntPtr.Zero;
			}
			else
			{
				IntPtr intPtr = IntPtr.Zero;
				IntPtr intPtr2 = IntPtr.Zero;
				int num = -1;
				while (num != ID)
				{
					intPtr2 = sshcommand.FindWindowEx(parentHandle, intPtr, _controlClass, null);
					num = (int)sshcommand.GetWindowLong(intPtr2, -12);
					intPtr = intPtr2;
					bool flag2 = intPtr2 == IntPtr.Zero;
					if (flag2)
					{
						result = IntPtr.Zero;
						return result;
					}
				}
				result = intPtr;
			}
			return result;
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x00027808 File Offset: 0x00025A08
		public static IntPtr ControlGetHandle(string _text, string _class, string _controlClass, int ID)
		{
			IntPtr intPtr = sshcommand.FindWindow(_class, _text);
			bool flag = intPtr == IntPtr.Zero;
			IntPtr result;
			if (flag)
			{
				result = IntPtr.Zero;
			}
			else
			{
				IntPtr intPtr2 = IntPtr.Zero;
				IntPtr intPtr3 = IntPtr.Zero;
				int num = -1;
				while (num != ID)
				{
					intPtr3 = sshcommand.FindWindowEx(intPtr, intPtr2, _controlClass, null);
					num = (int)sshcommand.GetWindowLong(intPtr3, -12);
					intPtr2 = intPtr3;
					bool flag2 = intPtr3 == IntPtr.Zero;
					if (flag2)
					{
						result = IntPtr.Zero;
						return result;
					}
				}
				result = intPtr2;
			}
			return result;
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x00027894 File Offset: 0x00025A94
		public static IntPtr FindWindowInProcess(Process process, Func<string, bool> compareTitle)
		{
			IntPtr intPtr = IntPtr.Zero;
			foreach (ProcessThread processThread in process.Threads)
			{
				intPtr = sshcommand.FindWindowInThread(processThread.Id, compareTitle);
				bool flag = intPtr != IntPtr.Zero;
				if (flag)
				{
					break;
				}
			}
			return intPtr;
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x0002791C File Offset: 0x00025B1C
		private static IntPtr FindWindowInThread(int threadId, Func<string, bool> compareTitle)
		{
			IntPtr windowHandle = IntPtr.Zero;
			sshcommand.EnumThreadWindows(threadId, delegate(IntPtr hWnd, IntPtr lParam)
			{
				StringBuilder stringBuilder = new StringBuilder(200);
				sshcommand.GetWindowText(hWnd, stringBuilder, 200);
				bool flag = compareTitle(stringBuilder.ToString());
				bool result;
				if (flag)
				{
					windowHandle = hWnd;
					result = false;
				}
				else
				{
					result = true;
				}
				return result;
			}, IntPtr.Zero);
			return windowHandle;
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x00027964 File Offset: 0x00025B64
		public static void closebitvise(int port)
		{
			Process[] processesByName = Process.GetProcessesByName("BvSsh");
			Process[] array = processesByName;
			for (int i = 0; i < array.Length; i++)
			{
				Process process = array[i];
				Process arg_3B_0 = process;
				Func<string, bool> arg_3B_1;
				if ((arg_3B_1 = sshcommand.<>c.<>9__23_0) == null)
				{
					arg_3B_1 = (sshcommand.<>c.<>9__23_0 = new Func<string, bool>(sshcommand.<>c.<>9.<closebitvise>b__23_0));
				}
				IntPtr hWnd = sshcommand.FindWindowInProcess(arg_3B_0, arg_3B_1);
				StringBuilder stringBuilder = new StringBuilder(200);
				sshcommand.GetWindowText(hWnd, stringBuilder, 200);
				string input = stringBuilder.ToString();
				Regex regex = new Regex("_(.*?).bscp");
				Match match = regex.Match(input);
				bool success = match.Success;
				if (success)
				{
					string value = match.Groups[1].Value;
					bool flag = value == port.ToString();
					if (flag)
					{
						process.Kill();
					}
				}
			}
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x00027A3C File Offset: 0x00025C3C
		private static void createProfile(string IPforward, string Portforward, string fileLocation)
		{
			sshcommand.profile profile = default(sshcommand.profile);
			Stream stream = File.Open(AppDomain.CurrentDomain.BaseDirectory + "1.bscp", FileMode.Open);
			BinaryReader binaryReader = new BinaryReader(stream);
			long length = stream.Length;
			profile.header = binaryReader.ReadBytes(21);
			profile.length = binaryReader.ReadByte();
			profile.body = binaryReader.ReadBytes((int)length - 189);
			profile.iplen = binaryReader.ReadByte();
			profile.ip = binaryReader.ReadBytes((int)profile.iplen);
			profile.s1 = binaryReader.ReadBytes(3);
			profile.portlen = binaryReader.ReadByte();
			profile.port = binaryReader.ReadBytes((int)profile.portlen);
			profile.end = binaryReader.ReadBytes(149);
			profile.ip = Encoding.UTF8.GetBytes(IPforward);
			profile.length = (byte)((int)profile.length + (IPforward.Length + Portforward.Length - (int)profile.iplen - (int)profile.portlen));
			profile.iplen = (byte)IPforward.Length;
			profile.port = Encoding.UTF8.GetBytes(Portforward);
			profile.portlen = (byte)Portforward.Length;
			stream.Close();
			using (Stream stream2 = new FileStream(fileLocation, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(stream2, Encoding.Default))
				{
					binaryWriter.Write(profile.header);
					binaryWriter.Write(profile.length);
					binaryWriter.Write(profile.body);
					binaryWriter.Write(profile.iplen);
					binaryWriter.Write(profile.ip);
					binaryWriter.Write(profile.s1);
					binaryWriter.Write(profile.portlen);
					binaryWriter.Write(profile.port);
					binaryWriter.Write(profile.end);
				}
				stream2.Close();
			}
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x00027C5C File Offset: 0x00025E5C
		public static bool SetSSH(string host, string username, string password, string ipforward, string portfoward, ref Process refproc)
		{
			SshChecker sshChecker = new SshChecker();
			string text = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
			bool flag = File.Exists(text + "\\Bitviseprofile");
			if (flag)
			{
				Directory.CreateDirectory(text + "\\Bitviseprofile");
			}
			text = new Uri(text).LocalPath;
			string text2 = Path.Combine(text + "\\Bitviseprofile", "_" + portfoward + ".bscp");
			sshcommand.createProfile(ipforward, portfoward, text2);
			string arguments = string.Concat(new string[]
			{
				" -profile=\"",
				text2,
				"\" -host=",
				host,
				" -port=22 -user=",
				username,
				" -password=",
				password,
				" -openTerm=n -openSFTP=n -openRDP=n -loginOnStartup -menu=small"
			});
			string fileName = AppDomain.CurrentDomain.BaseDirectory + "Bitvise SSH Client\\BvSsh.exe";
			Process process = Process.Start(fileName, arguments);
			refproc = process;
			while ((DateTime.Now - process.StartTime).Seconds < 1)
			{
				Thread.Sleep(100);
			}
			Process arg_135_0 = process;
			Func<string, bool> arg_135_1;
			if ((arg_135_1 = sshcommand.<>c.<>9__25_0) == null)
			{
				arg_135_1 = (sshcommand.<>c.<>9__25_0 = new Func<string, bool>(sshcommand.<>c.<>9.<SetSSH>b__25_0));
			}
			IntPtr intPtr = sshcommand.FindWindowInProcess(arg_135_0, arg_135_1);
			while (intPtr == IntPtr.Zero)
			{
				Process arg_160_0 = process;
				Func<string, bool> arg_160_1;
				if ((arg_160_1 = sshcommand.<>c.<>9__25_1) == null)
				{
					arg_160_1 = (sshcommand.<>c.<>9__25_1 = new Func<string, bool>(sshcommand.<>c.<>9.<SetSSH>b__25_1));
				}
				intPtr = sshcommand.FindWindowInProcess(arg_160_0, arg_160_1);
				Thread.Sleep(100);
			}
			bool flag2 = !sshcommand.threadAccept(intPtr);
			bool result;
			if (flag2)
			{
				process.Kill();
				result = false;
			}
			else
			{
				refproc = process;
				result = true;
			}
			return result;
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x00027E18 File Offset: 0x00026018
		public static bool threadAccept(IntPtr hwnd)
		{
			IntPtr hwnd2 = sshcommand.ControlGetHandle(hwnd, "Button", 1);
			DateTime now = DateTime.Now;
			while (true)
			{
				IntPtr intPtr = sshcommand.ControlGetHandle("Host Key Verification", "#32770", "Button", 102);
				bool flag = intPtr != IntPtr.Zero;
				if (flag)
				{
					sshcommand.ControlClick(intPtr);
				}
				Thread.Sleep(100);
				bool flag2 = sshcommand.ControlGetText(hwnd2) == "Logout";
				if (flag2)
				{
					break;
				}
				bool flag3 = (DateTime.Now - now).Seconds > 15;
				if (flag3)
				{
					goto Block_3;
				}
			}
			bool result = true;
			return result;
			Block_3:
			result = false;
			return result;
		}

		// Token: 0x0400031D RID: 797
		private Process[] myProcess = Process.GetProcessesByName("program name here");

		// Token: 0x0400031E RID: 798
		public const int WM_LBUTTONDOWN = 513;

		// Token: 0x0400031F RID: 799
		public const int WM_LBUTTONUP = 514;

		// Token: 0x02000064 RID: 100
		// Token: 0x060003FE RID: 1022
		public delegate bool EnumWindowsProc(IntPtr hwnd, IntPtr lParam);

		// Token: 0x02000065 RID: 101
		private struct profile
		{
			// Token: 0x04000320 RID: 800
			public byte[] header;

			// Token: 0x04000321 RID: 801
			public byte length;

			// Token: 0x04000322 RID: 802
			public byte[] body;

			// Token: 0x04000323 RID: 803
			public byte iplen;

			// Token: 0x04000324 RID: 804
			public byte[] ip;

			// Token: 0x04000325 RID: 805
			public byte[] s1;

			// Token: 0x04000326 RID: 806
			public byte portlen;

			// Token: 0x04000327 RID: 807
			public byte[] port;

			// Token: 0x04000328 RID: 808
			public byte[] end;
		}

		// Token: 0x02000067 RID: 103
		[CompilerGenerated]
		[Serializable]
		private sealed class <>c
		{
			// Token: 0x06000405 RID: 1029 RVA: 0x000038B1 File Offset: 0x00001AB1
			internal bool <closebitvise>b__23_0(string s)
			{
				return s.StartsWith("Bitvise SSH Client");
			}

			// Token: 0x06000406 RID: 1030 RVA: 0x000038B1 File Offset: 0x00001AB1
			internal bool <SetSSH>b__25_0(string s)
			{
				return s.StartsWith("Bitvise SSH Client");
			}

			// Token: 0x06000407 RID: 1031 RVA: 0x000038B1 File Offset: 0x00001AB1
			internal bool <SetSSH>b__25_1(string s)
			{
				return s.StartsWith("Bitvise SSH Client");
			}

			// Token: 0x0400032B RID: 811
			public static readonly sshcommand.<>c <>9 = new sshcommand.<>c();

			// Token: 0x0400032C RID: 812
			public static Func<string, bool> <>9__23_0;

			// Token: 0x0400032D RID: 813
			public static Func<string, bool> <>9__25_0;

			// Token: 0x0400032E RID: 814
			public static Func<string, bool> <>9__25_1;
		}
	}
}
