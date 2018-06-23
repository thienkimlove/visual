using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace AutoLead
{
	// Token: 0x02000072 RID: 114
	public class Vip72
	{
		// Token: 0x06000426 RID: 1062
		[DllImport("user32.dll")]
		private static extern IntPtr FindWindow(string sClass, string sWindow);

		// Token: 0x06000427 RID: 1063
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

		// Token: 0x06000428 RID: 1064
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int msg, int Param, StringBuilder text);

		// Token: 0x06000429 RID: 1065
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int SendMessageTimeout(IntPtr hWnd, int Msg, int wParam, StringBuilder lParam, int fuFlags, int uTimeout, out int lpdwResult);

		// Token: 0x0600042A RID: 1066
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int msg, int Param, string text);

		// Token: 0x0600042B RID: 1067
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int SendMessageTimeout(IntPtr hWnd, int Msg, int wParam, string lParam, int fuFlags, int uTimeout, out int lpdwResult);

		// Token: 0x0600042C RID: 1068
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int SendMessage(IntPtr hWnd, int msg, IntPtr Param, IntPtr text);

		// Token: 0x0600042D RID: 1069
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int SendMessageTimeout(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam, int fuFlags, int uTimeout, out int lpdwResult);

		// Token: 0x0600042E RID: 1070
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr GetDlgItem(int hwnd, int childID);

		// Token: 0x0600042F RID: 1071
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int GetWindowText(IntPtr hwnd, IntPtr windowString, int maxcount);

		// Token: 0x06000430 RID: 1072
		[DllImport("user32", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool EnumThreadWindows(int threadId, Vip72.EnumWindowsProc callback, IntPtr lParam);

		// Token: 0x06000431 RID: 1073
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr GetWindowLong(IntPtr hwnd, int nIndex);

		// Token: 0x06000432 RID: 1074
		[DllImport("kernel32.dll")]
		public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

		// Token: 0x06000433 RID: 1075
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesWritten);

		// Token: 0x06000434 RID: 1076
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress, int[] lpBuffer, int dwSize, ref int lpNumberOfBytesWritten);

		// Token: 0x06000435 RID: 1077
		[DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int maxCount);

		// Token: 0x06000436 RID: 1078
		[DllImport("kernel32.dll", SetLastError = true)]
		internal static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, int dwSize, out int lpNumberOfBytesRead);

		// Token: 0x06000437 RID: 1079 RVA: 0x0002832C File Offset: 0x0002652C
		public static string ControlGetText(IntPtr hwnd)
		{
			StringBuilder stringBuilder = new StringBuilder(255);
			int num = 0;
			int num2 = Vip72.SendMessageTimeout(hwnd, 13, stringBuilder.Capacity, stringBuilder, 2, 5000, out num);
			return stringBuilder.ToString();
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x0002836C File Offset: 0x0002656C
		public static int ControlSetText(IntPtr hwnd, string text)
		{
			return Vip72.SendMessage(hwnd, 12, text.Length, text);
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x00028390 File Offset: 0x00026590
		public static void ControlClick(IntPtr hwnd)
		{
			int num = 0;
			int num2 = Vip72.SendMessageTimeout(hwnd, 513, IntPtr.Zero, IntPtr.Zero, 2, 5000, out num);
			Vip72.SendMessageTimeout(hwnd, 514, IntPtr.Zero, IntPtr.Zero, 2, 5000, out num);
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x000283DC File Offset: 0x000265DC
		public static void ControlDoubleClick(IntPtr hwnd)
		{
			int num = 0;
			int num2 = Vip72.SendMessageTimeout(hwnd, 515, IntPtr.Zero, IntPtr.Zero, 2, 5000, out num);
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x0002840C File Offset: 0x0002660C
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
					intPtr2 = Vip72.FindWindowEx(parentHandle, intPtr, _controlClass, null);
					num = (int)Vip72.GetWindowLong(intPtr2, -12);
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

		// Token: 0x0600043C RID: 1084 RVA: 0x00028490 File Offset: 0x00026690
		public static IntPtr ControlGetHandle(IntPtr parentHandle, string _controlClass, int ID, bool instance)
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
					intPtr2 = Vip72.FindWindowEx(parentHandle, intPtr, _controlClass, null);
					num = (int)Vip72.GetWindowLong(intPtr2, -16);
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

		// Token: 0x0600043D RID: 1085 RVA: 0x00028514 File Offset: 0x00026714
		public static IntPtr ControlGetHandle(string _text, string _class, string _controlClass, int ID)
		{
			IntPtr intPtr = Vip72.FindWindow(_class, _text);
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
					intPtr3 = Vip72.FindWindowEx(intPtr, intPtr2, _controlClass, null);
					num = (int)Vip72.GetWindowLong(intPtr3, -12);
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

		// Token: 0x0600043E RID: 1086 RVA: 0x000285A0 File Offset: 0x000267A0
		private static bool ControlGetCheck(IntPtr controlhand)
		{
			int num2;
			int num = Vip72.SendMessageTimeout(controlhand, 240, IntPtr.Zero, IntPtr.Zero, 2, 5000, out num2);
			return num2 == 1;
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x000285D4 File Offset: 0x000267D4
		private static bool ControlGetState(IntPtr controlhandle, int state)
		{
			int num = (int)Vip72.GetWindowLong(controlhandle, -16);
			return (num & state) != 0;
		}

		// Token: 0x06000440 RID: 1088 RVA: 0x00028604 File Offset: 0x00026804
		public static IntPtr FindWindowInProcess(Process process, Func<string, bool> compareTitle)
		{
			IntPtr intPtr = IntPtr.Zero;
			bool flag = process == null;
			IntPtr result;
			if (flag)
			{
				result = intPtr;
			}
			else
			{
				foreach (ProcessThread processThread in process.Threads)
				{
					intPtr = Vip72.FindWindowInThread(processThread.Id, compareTitle);
					bool flag2 = intPtr != IntPtr.Zero;
					if (flag2)
					{
						break;
					}
				}
				result = intPtr;
			}
			return result;
		}

		// Token: 0x06000441 RID: 1089 RVA: 0x00028698 File Offset: 0x00026898
		private static IntPtr FindWindowInThread(int threadId, Func<string, bool> compareTitle)
		{
			IntPtr windowHandle = IntPtr.Zero;
			Vip72.EnumThreadWindows(threadId, delegate(IntPtr hWnd, IntPtr lParam)
			{
				StringBuilder stringBuilder = new StringBuilder(200);
				Vip72.GetWindowText(hWnd, stringBuilder, 200);
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

		// Token: 0x06000442 RID: 1090 RVA: 0x000286E0 File Offset: 0x000268E0
		public bool vip72login(string username, string password, int mainPort)
		{
			Thread.Sleep(1000);
			Process[] processByName = this.GetProcessByName("vip72socks");
			Process[] array = processByName;
			for (int i = 0; i < array.Length; i++)
			{
				Process process = array[i];
				Process arg_4A_0 = process;
				Func<string, bool> arg_4A_1;
				if ((arg_4A_1 = Vip72.<>c.<>9__32_0) == null)
				{
					arg_4A_1 = (Vip72.<>c.<>9__32_0 = new Func<string, bool>(Vip72.<>c.<>9.<vip72login>b__32_0));
				}
				IntPtr parentHandle = Vip72.FindWindowInProcess(arg_4A_0, arg_4A_1);
				IntPtr hwnd = Vip72.ControlGetHandle(parentHandle, "Static", 7955);
				bool flag = Vip72.ControlGetText(hwnd).EndsWith(":" + mainPort.ToString());
				if (flag)
				{
					Vip72.Vip72Process = process;
					break;
				}
			}
			bool flag2 = Vip72.Vip72Process != null && !Vip72.Vip72Process.HasExited && Vip72.Vip72Process.Responding;
			if (flag2)
			{
				Process arg_EE_0 = Vip72.Vip72Process;
				Func<string, bool> arg_EE_1;
				if ((arg_EE_1 = Vip72.<>c.<>9__32_1) == null)
				{
					arg_EE_1 = (Vip72.<>c.<>9__32_1 = new Func<string, bool>(Vip72.<>c.<>9.<vip72login>b__32_1));
				}
				IntPtr parentHandle2 = Vip72.FindWindowInProcess(arg_EE_0, arg_EE_1);
				IntPtr hwnd2 = Vip72.ControlGetHandle(parentHandle2, "Static", 7955);
				bool flag3 = !Vip72.ControlGetText(hwnd2).EndsWith(":" + mainPort.ToString());
				if (flag3)
				{
					bool flag4 = !Vip72.Vip72Process.HasExited;
					if (flag4)
					{
						Vip72.Vip72Process.Kill();
					}
					Vip72.Vip72Process = null;
				}
			}
			else
			{
				bool flag5 = Vip72.Vip72Process != null && !Vip72.Vip72Process.Responding;
				if (flag5)
				{
					bool flag6 = !Vip72.Vip72Process.HasExited;
					if (flag6)
					{
						Vip72.Vip72Process.Kill();
					}
					Vip72.Vip72Process = null;
				}
			}
			bool flag7 = Vip72.Vip72Process == null || Vip72.Vip72Process.HasExited;
			if (flag7)
			{
				Vip72.Vip72Process = Process.Start(new ProcessStartInfo
				{
					FileName = "vip72socks.exe",
					WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory + "vip72",
					Arguments = "-mp:" + mainPort.ToString()
				});
				IntPtr value = Vip72.OpenProcess(2035711, false, Vip72.Vip72Process.Id);
				byte[] lpBuffer = new byte[]
				{
					235
				};
				int num = 0;
				int lpBaseAddress = 4234074;
				Vip72.WriteProcessMemory((int)value, lpBaseAddress, lpBuffer, 1, ref num);
			}
			Thread.Sleep(500);
			Process arg_285_0 = Vip72.Vip72Process;
			Func<string, bool> arg_285_1;
			if ((arg_285_1 = Vip72.<>c.<>9__32_2) == null)
			{
				arg_285_1 = (Vip72.<>c.<>9__32_2 = new Func<string, bool>(Vip72.<>c.<>9.<vip72login>b__32_2));
			}
			IntPtr parentHandle3 = Vip72.FindWindowInProcess(arg_285_0, arg_285_1);
			IntPtr intPtr = Vip72.ControlGetHandle(parentHandle3, "Button", 119);
			IntPtr hwnd3 = Vip72.ControlGetHandle(parentHandle3, "Static", 7955);
			bool flag8 = intPtr != IntPtr.Zero;
			bool result;
			if (flag8)
			{
				Vip72.ControlSetText(hwnd3, "Port mac dinh:" + mainPort.ToString());
				bool flag9 = !Vip72.ControlGetState(intPtr, 134217728);
				if (flag9)
				{
					IntPtr hwnd4 = Vip72.ControlGetHandle(parentHandle3, "Edit", 303);
					Vip72.ControlSetText(hwnd4, username);
					IntPtr hwnd5 = Vip72.ControlGetHandle(parentHandle3, "Edit", 301);
					Vip72.ControlSetText(hwnd5, password);
					Vip72.ControlClick(intPtr);
					IntPtr hwnd6 = Vip72.ControlGetHandle(parentHandle3, "Edit", 131);
					DateTime now = DateTime.Now;
					while (Vip72.ControlGetText(hwnd6) != "System ready")
					{
						bool flag10 = Vip72.ControlGetText(hwnd6) == "ERROR!Login and Password is incorrect";
						if (flag10)
						{
							result = false;
							return result;
						}
						bool flag11 = !Vip72.ControlGetState(intPtr, 134217728);
						if (flag11)
						{
							result = false;
							return result;
						}
						Thread.Sleep(100);
						bool flag12 = (DateTime.Now - now).Seconds > 20;
						if (flag12)
						{
							result = false;
							return result;
						}
					}
					Thread.Sleep(3000);
				}
				result = true;
			}
			else
			{
				result = this.vip72login(username, password, mainPort);
			}
			return result;
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x000021A5 File Offset: 0x000003A5
		public void waitiotherVIP72()
		{
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x00028AD8 File Offset: 0x00026CD8
		public void clearIpWithPort(int port)
		{
			Process[] processByName = this.GetProcessByName("vip72socks");
			bool flag = processByName.Count<Process>() > 0;
			if (flag)
			{
				Process[] array = processByName;
				for (int i = 0; i < array.Length; i++)
				{
					Process process = array[i];
					Process arg_4F_0 = Vip72.Vip72Process;
					Func<string, bool> arg_4F_1;
					if ((arg_4F_1 = Vip72.<>c.<>9__34_0) == null)
					{
						arg_4F_1 = (Vip72.<>c.<>9__34_0 = new Func<string, bool>(Vip72.<>c.<>9.<clearIpWithPort>b__34_0));
					}
					IntPtr parentHandle = Vip72.FindWindowInProcess(arg_4F_0, arg_4F_1);
					IntPtr hwnd = Vip72.ControlGetHandle(parentHandle, "Static", 7955);
					bool flag2 = Vip72.ControlGetText(hwnd).EndsWith(":" + port.ToString());
					if (flag2)
					{
						process.Kill();
					}
				}
			}
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x00028B88 File Offset: 0x00026D88
		public void clearip()
		{
			bool flag = !Vip72.Vip72Process.HasExited;
			if (flag)
			{
				IntPtr intPtr = Vip72.OpenProcess(2035711, false, Vip72.Vip72Process.Id);
				byte[] array = new byte[]
				{
					144,
					144
				};
				Process arg_69_0 = Vip72.Vip72Process;
				Func<string, bool> arg_69_1;
				if ((arg_69_1 = Vip72.<>c.<>9__35_0) == null)
				{
					arg_69_1 = (Vip72.<>c.<>9__35_0 = new Func<string, bool>(Vip72.<>c.<>9.<clearip>b__35_0));
				}
				IntPtr parentHandle = Vip72.FindWindowInProcess(arg_69_0, arg_69_1);
				IntPtr hWnd = Vip72.ControlGetHandle(parentHandle, "SysListView32", 117);
				for (int i = 0; i < 30; i++)
				{
					int num = 0;
					Vip72.SendMessageTimeout(hWnd, 256, (IntPtr)46, IntPtr.Zero, 2, 5000, out num);
				}
			}
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x00028C54 File Offset: 0x00026E54
		public string clickip(int port)
		{
			bool hasExited = Vip72.Vip72Process.HasExited;
			string result;
			if (hasExited)
			{
				result = "not running";
			}
			else
			{
				Process arg_41_0 = Vip72.Vip72Process;
				Func<string, bool> arg_41_1;
				if ((arg_41_1 = Vip72.<>c.<>9__36_0) == null)
				{
					arg_41_1 = (Vip72.<>c.<>9__36_0 = new Func<string, bool>(Vip72.<>c.<>9.<clickip>b__36_0));
				}
				IntPtr parentHandle = Vip72.FindWindowInProcess(arg_41_0, arg_41_1);
				int value = 4328465;
				int lpBaseAddress = 4324304;
				IntPtr intPtr = Vip72.ControlGetHandle(parentHandle, "Button", 7817);
				bool flag = Vip72.ControlGetCheck(intPtr);
				if (flag)
				{
					Vip72.ControlClick(intPtr);
				}
				IntPtr intPtr2 = Vip72.OpenProcess(2035711, false, Vip72.Vip72Process.Id);
				int num = 0;
				IntPtr lpBuffer = IntPtr.Zero;
				lpBuffer = Marshal.AllocHGlobal(4);
				Vip72.ReadProcessMemory(intPtr2, (IntPtr)value, lpBuffer, 4, out num);
				Random random = new Random();
				uint id = (uint)Vip72.Vip72Process.Id;
				IntPtr intPtr3 = Vip72.ControlGetHandle(parentHandle, "SysListView32", 117);
				int num2 = 0;
				while (ListViewItem1.GetListViewItem(intPtr3, id, num2, 4) != "")
				{
					string listViewItem = ListViewItem1.GetListViewItem(intPtr3, id, num2, 4);
					bool flag2 = listViewItem.Contains(port.ToString()) || listViewItem.Contains("main stream");
					if (flag2)
					{
						ListViewItem1.SelectListViewItem(intPtr3, id, num2);
						int num3 = 0;
						Vip72.SendMessageTimeout(intPtr3, 256, (IntPtr)46, IntPtr.Zero, 2, 5000, out num3);
					}
					else
					{
						num2++;
					}
				}
				num2 = 0;
				IntPtr hwnd = Vip72.ControlGetHandle(parentHandle, "SysListView32", 116);
				while (ListViewItem1.GetListViewItem(hwnd, id, num2, 0) != "")
				{
					num2++;
				}
				int num4 = num2;
				bool flag3 = num4 == 0;
				if (flag3)
				{
					result = "no IP";
				}
				else
				{
					num2 = 0;
					int num5 = -1;
					while (ListViewItem1.GetListViewItem(hwnd, id, num2, 0) != "")
					{
						string listViewItem2 = ListViewItem1.GetListViewItem(hwnd, id, num2, 0);
						bool flag4 = listViewItem2.Contains(".**");
						if (flag4)
						{
							num5 = random.Next(0, num4);
							while (!ListViewItem1.GetListViewItem(hwnd, id, num5, 0).Contains(".**"))
							{
								num5 = random.Next(0, num4);
							}
							break;
						}
						num2++;
					}
					bool flag5 = num5 == -1;
					if (flag5)
					{
						result = "no IP";
					}
					else
					{
						int[] lpBuffer2 = new int[]
						{
							num5
						};
						int num6 = 0;
						Vip72.WriteProcessMemory((int)intPtr2, lpBaseAddress, lpBuffer2, 4, ref num6);
						ListViewItem1.SelectListViewItem(hwnd, id, num5);
						Vip72.ControlDoubleClick(hwnd);
						Thread.Sleep(500);
						IntPtr controlhand = Vip72.ControlGetHandle(parentHandle, "Button", 7303);
						IntPtr hwnd2 = Vip72.ControlGetHandle(parentHandle, "Edit", 131);
						DateTime now = DateTime.Now;
						while (!Vip72.ControlGetCheck(controlhand))
						{
							bool flag6 = Vip72.ControlGetText(hwnd2).Contains("ffline");
							if (flag6)
							{
								result = "dead";
								return result;
							}
							bool flag7 = Vip72.ControlGetText(hwnd2).Contains("limit");
							if (flag7)
							{
								try
								{
									bool flag8 = !Vip72.Vip72Process.HasExited;
									if (flag8)
									{
										Vip72.Vip72Process.Kill();
									}
								}
								catch (Exception)
								{
								}
								result = "limited";
								return result;
							}
							bool flag9 = Vip72.ControlGetText(hwnd2).Contains("can't");
							if (flag9)
							{
								result = "dead";
								return result;
							}
							bool flag10 = Vip72.ControlGetText(hwnd2).Contains("disconnect");
							if (flag10)
							{
								result = "dead";
								return result;
							}
							bool flag11 = Vip72.ControlGetText(hwnd2).Contains("aximum");
							if (flag11)
							{
								result = "maximum";
								return result;
							}
							bool flag12 = (DateTime.Now - now).TotalSeconds > 15.0;
							if (flag12)
							{
								result = "timeout";
								return result;
							}
						}
						Thread.Sleep(500);
						intPtr3 = Vip72.ControlGetHandle(parentHandle, "SysListView32", 117);
						num2 = 0;
						while (ListViewItem1.GetListViewItem(intPtr3, id, num2, 4) != "")
						{
							string listViewItem3 = ListViewItem1.GetListViewItem(intPtr3, id, num2, 4);
							bool flag13 = listViewItem3.Contains("main stream");
							if (flag13)
							{
								result = ListViewItem1.GetListViewItem(intPtr3, id, num2, 0);
								return result;
							}
							num2++;
						}
						result = "limited";
					}
				}
			}
			return result;
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x000290F0 File Offset: 0x000272F0
		public Process[] GetProcessByName(string processName)
		{
			Process[] processes = Process.GetProcesses();
			List<Process> list = new List<Process>();
			Process[] array = processes;
			for (int i = 0; i < array.Length; i++)
			{
				Process process = array[i];
				bool flag = process.ProcessName.StartsWith(processName);
				if (flag)
				{
					list.Add(process);
				}
			}
			return list.ToArray();
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x0002914C File Offset: 0x0002734C
		public bool getip(byte countryindex)
		{
			byte[] array = new byte[1];
			int[] array2 = new int[1];
			array[0] = countryindex;
			int num = 4482683;
			bool flag = Vip72.Vip72Process != null && !Vip72.Vip72Process.HasExited;
			bool result;
			if (flag)
			{
				Process arg_5C_0 = Vip72.Vip72Process;
				Func<string, bool> arg_5C_1;
				if ((arg_5C_1 = Vip72.<>c.<>9__38_0) == null)
				{
					arg_5C_1 = (Vip72.<>c.<>9__38_0 = new Func<string, bool>(Vip72.<>c.<>9.<getip>b__38_0));
				}
				IntPtr parentHandle = Vip72.FindWindowInProcess(arg_5C_0, arg_5C_1);
				IntPtr value = Vip72.OpenProcess(2035711, false, Vip72.Vip72Process.Id);
				int num2 = 0;
				Vip72.WriteProcessMemory((int)value, num, array, 1, ref num2);
				array2[0] = 0;
				bool flag2 = File.Exists(AppDomain.CurrentDomain.BaseDirectory + "citycode\\" + countryindex.ToString() + ".dat");
				if (flag2)
				{
					string[] array3 = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "citycode\\" + countryindex.ToString() + ".dat");
					Random random = new Random();
					string text = array3[random.Next(0, array3.Count<string>())];
					int num3 = Convert.ToInt32(text.Split(new string[]
					{
						"|"
					}, StringSplitOptions.None)[1]);
					array2[0] = num3;
				}
				Vip72.WriteProcessMemory((int)value, num + 1, array2, 4, ref num2);
				IntPtr intPtr = Vip72.ControlGetHandle(parentHandle, "Button", 127);
				Vip72.ControlClick(intPtr);
				IntPtr intPtr2 = Vip72.ControlGetHandle(parentHandle, "Edit", 131);
				DateTime now = DateTime.Now;
				while (Vip72.ControlGetState(intPtr, 134217728))
				{
					Thread.Sleep(100);
					bool hasExited = Vip72.Vip72Process.HasExited;
					if (hasExited)
					{
						result = false;
						return result;
					}
					bool flag3 = !Vip72.Vip72Process.Responding || (DateTime.Now - now).TotalSeconds > 30.0;
					if (flag3)
					{
						try
						{
							bool flag4 = !Vip72.Vip72Process.HasExited;
							if (flag4)
							{
								Vip72.Vip72Process.Kill();
							}
						}
						catch (Exception)
						{
						}
						result = false;
						return result;
					}
				}
			}
			result = true;
			return result;
		}

		// Token: 0x0400036E RID: 878
		public static Process Vip72Process = null;

		// Token: 0x0400036F RID: 879
		public const int WM_LBUTTONDOWN = 513;

		// Token: 0x04000370 RID: 880
		public const int WM_LBUTTONUP = 514;

		// Token: 0x02000073 RID: 115
		// Token: 0x0600044C RID: 1100
		public delegate bool EnumWindowsProc(IntPtr hwnd, IntPtr lParam);

		// Token: 0x02000075 RID: 117
		[CompilerGenerated]
		[Serializable]
		private sealed class <>c
		{
			// Token: 0x06000453 RID: 1107 RVA: 0x00003930 File Offset: 0x00001B30
			internal bool <vip72login>b__32_0(string s)
			{
				return s.StartsWith("VIP72 Socks Client");
			}

			// Token: 0x06000454 RID: 1108 RVA: 0x00003930 File Offset: 0x00001B30
			internal bool <vip72login>b__32_1(string s)
			{
				return s.StartsWith("VIP72 Socks Client");
			}

			// Token: 0x06000455 RID: 1109 RVA: 0x00003930 File Offset: 0x00001B30
			internal bool <vip72login>b__32_2(string s)
			{
				return s.StartsWith("VIP72 Socks Client");
			}

			// Token: 0x06000456 RID: 1110 RVA: 0x00003930 File Offset: 0x00001B30
			internal bool <clearIpWithPort>b__34_0(string s)
			{
				return s.StartsWith("VIP72 Socks Client");
			}

			// Token: 0x06000457 RID: 1111 RVA: 0x00003930 File Offset: 0x00001B30
			internal bool <clearip>b__35_0(string s)
			{
				return s.StartsWith("VIP72 Socks Client");
			}

			// Token: 0x06000458 RID: 1112 RVA: 0x00003930 File Offset: 0x00001B30
			internal bool <clickip>b__36_0(string s)
			{
				return s.StartsWith("VIP72 Socks Client");
			}

			// Token: 0x06000459 RID: 1113 RVA: 0x00003930 File Offset: 0x00001B30
			internal bool <getip>b__38_0(string s)
			{
				return s.StartsWith("VIP72 Socks Client");
			}

			// Token: 0x04000373 RID: 883
			public static readonly Vip72.<>c <>9 = new Vip72.<>c();

			// Token: 0x04000374 RID: 884
			public static Func<string, bool> <>9__32_0;

			// Token: 0x04000375 RID: 885
			public static Func<string, bool> <>9__32_1;

			// Token: 0x04000376 RID: 886
			public static Func<string, bool> <>9__32_2;

			// Token: 0x04000377 RID: 887
			public static Func<string, bool> <>9__34_0;

			// Token: 0x04000378 RID: 888
			public static Func<string, bool> <>9__35_0;

			// Token: 0x04000379 RID: 889
			public static Func<string, bool> <>9__36_0;

			// Token: 0x0400037A RID: 890
			public static Func<string, bool> <>9__38_0;
		}
	}
}
