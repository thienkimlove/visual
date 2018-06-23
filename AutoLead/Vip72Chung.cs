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
	// Token: 0x02000076 RID: 118
	public class Vip72Chung
	{
		// Token: 0x0600045A RID: 1114
		[DllImport("user32.dll")]
		private static extern IntPtr FindWindow(string sClass, string sWindow);

		// Token: 0x0600045B RID: 1115
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

		// Token: 0x0600045C RID: 1116
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int msg, int Param, StringBuilder text);

		// Token: 0x0600045D RID: 1117
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int SendMessageTimeout(IntPtr hWnd, int Msg, int wParam, StringBuilder lParam, int fuFlags, int uTimeout, out int lpdwResult);

		// Token: 0x0600045E RID: 1118
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int msg, int Param, string text);

		// Token: 0x0600045F RID: 1119
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int SendMessageTimeout(IntPtr hWnd, int Msg, int wParam, string lParam, int fuFlags, int uTimeout, out int lpdwResult);

		// Token: 0x06000460 RID: 1120
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int SendMessage(IntPtr hWnd, int msg, IntPtr Param, IntPtr text);

		// Token: 0x06000461 RID: 1121
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int SendMessageTimeout(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam, int fuFlags, int uTimeout, out int lpdwResult);

		// Token: 0x06000462 RID: 1122
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr GetDlgItem(int hwnd, int childID);

		// Token: 0x06000463 RID: 1123
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int GetWindowText(IntPtr hwnd, IntPtr windowString, int maxcount);

		// Token: 0x06000464 RID: 1124
		[DllImport("user32", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool EnumThreadWindows(int threadId, Vip72Chung.EnumWindowsProc callback, IntPtr lParam);

		// Token: 0x06000465 RID: 1125
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr GetWindowLong(IntPtr hwnd, int nIndex);

		// Token: 0x06000466 RID: 1126
		[DllImport("kernel32.dll")]
		public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

		// Token: 0x06000467 RID: 1127
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesWritten);

		// Token: 0x06000468 RID: 1128
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress, int[] lpBuffer, int dwSize, ref int lpNumberOfBytesWritten);

		// Token: 0x06000469 RID: 1129
		[DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int maxCount);

		// Token: 0x0600046A RID: 1130
		[DllImport("kernel32.dll", SetLastError = true)]
		internal static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, int dwSize, out int lpNumberOfBytesRead);

		// Token: 0x0600046B RID: 1131 RVA: 0x000293C8 File Offset: 0x000275C8
		public static string ControlGetText(IntPtr hwnd)
		{
			StringBuilder stringBuilder = new StringBuilder(255);
			int num = 0;
			int num2 = Vip72Chung.SendMessageTimeout(hwnd, 13, stringBuilder.Capacity, stringBuilder, 2, 5000, out num);
			return stringBuilder.ToString();
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x00029408 File Offset: 0x00027608
		public static int ControlSetText(IntPtr hwnd, string text)
		{
			return Vip72Chung.SendMessage(hwnd, 12, text.Length, text);
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x0002942C File Offset: 0x0002762C
		public static void ControlClick(IntPtr hwnd)
		{
			int num = 0;
			int num2 = Vip72Chung.SendMessageTimeout(hwnd, 513, IntPtr.Zero, IntPtr.Zero, 2, 5000, out num);
			Vip72Chung.SendMessageTimeout(hwnd, 514, IntPtr.Zero, IntPtr.Zero, 2, 5000, out num);
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x00029478 File Offset: 0x00027678
		public static void ControlDoubleClick(IntPtr hwnd)
		{
			int num = 0;
			int num2 = Vip72Chung.SendMessageTimeout(hwnd, 515, IntPtr.Zero, IntPtr.Zero, 2, 5000, out num);
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x000294A8 File Offset: 0x000276A8
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
					intPtr2 = Vip72Chung.FindWindowEx(parentHandle, intPtr, _controlClass, null);
					num = (int)Vip72Chung.GetWindowLong(intPtr2, -12);
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

		// Token: 0x06000470 RID: 1136 RVA: 0x0002952C File Offset: 0x0002772C
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
					intPtr2 = Vip72Chung.FindWindowEx(parentHandle, intPtr, _controlClass, null);
					num = (int)Vip72Chung.GetWindowLong(intPtr2, -16);
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

		// Token: 0x06000471 RID: 1137 RVA: 0x000295B0 File Offset: 0x000277B0
		public static IntPtr ControlGetHandle(string _text, string _class, string _controlClass, int ID)
		{
			IntPtr intPtr = Vip72Chung.FindWindow(_class, _text);
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
					intPtr3 = Vip72Chung.FindWindowEx(intPtr, intPtr2, _controlClass, null);
					num = (int)Vip72Chung.GetWindowLong(intPtr3, -12);
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

		// Token: 0x06000472 RID: 1138 RVA: 0x0002963C File Offset: 0x0002783C
		private static bool ControlGetCheck(IntPtr controlhand)
		{
			int num2;
			int num = Vip72Chung.SendMessageTimeout(controlhand, 240, IntPtr.Zero, IntPtr.Zero, 2, 5000, out num2);
			return num2 == 1;
		}

		// Token: 0x06000473 RID: 1139 RVA: 0x00029670 File Offset: 0x00027870
		private static bool ControlGetState(IntPtr controlhandle, int state)
		{
			int num = (int)Vip72Chung.GetWindowLong(controlhandle, -16);
			return (num & state) != 0;
		}

		// Token: 0x06000474 RID: 1140 RVA: 0x000296A0 File Offset: 0x000278A0
		public static IntPtr FindWindowInProcess(Process process, Func<string, bool> compareTitle)
		{
			IntPtr intPtr = IntPtr.Zero;
			foreach (ProcessThread processThread in process.Threads)
			{
				intPtr = Vip72Chung.FindWindowInThread(processThread.Id, compareTitle);
				bool flag = intPtr != IntPtr.Zero;
				if (flag)
				{
					break;
				}
			}
			return intPtr;
		}

		// Token: 0x06000475 RID: 1141 RVA: 0x00029728 File Offset: 0x00027928
		private static IntPtr FindWindowInThread(int threadId, Func<string, bool> compareTitle)
		{
			IntPtr windowHandle = IntPtr.Zero;
			Vip72Chung.EnumThreadWindows(threadId, delegate(IntPtr hWnd, IntPtr lParam)
			{
				StringBuilder stringBuilder = new StringBuilder(200);
				Vip72Chung.GetWindowText(hWnd, stringBuilder, 200);
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

		// Token: 0x06000476 RID: 1142 RVA: 0x00029770 File Offset: 0x00027970
		public void waitiotherVIP72()
		{
			Process[] processesByName = Process.GetProcessesByName("AutoLead");
			while (true)
			{
				bool flag = true;
				Process[] array = processesByName;
				for (int i = 0; i < array.Length; i++)
				{
					Process process = array[i];
					bool flag2 = Process.GetCurrentProcess().Id != process.Id;
					if (flag2)
					{
						Process arg_61_0 = process;
						Func<string, bool> arg_61_1;
						if ((arg_61_1 = Vip72Chung.<>c.<>9__31_0) == null)
						{
							arg_61_1 = (Vip72Chung.<>c.<>9__31_0 = new Func<string, bool>(Vip72Chung.<>c.<>9.<waitiotherVIP72>b__31_0));
						}
						IntPtr parentHandle = Vip72Chung.FindWindowInProcess(arg_61_0, arg_61_1);
						IntPtr hwnd = Vip72Chung.ControlGetHandle(parentHandle, "WindowsForms10.STATIC.app.0.141b42a_r12_ad1", 1442840576, true);
						bool flag3 = Vip72Chung.ControlGetText(hwnd) == "Getting Vip72 IP...";
						if (flag3)
						{
							flag = false;
						}
					}
				}
				bool flag4 = flag;
				if (flag4)
				{
					break;
				}
				Thread.Sleep(500);
			}
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x00029840 File Offset: 0x00027A40
		public bool vip72login(string username, string password, int mainPort)
		{
			Thread.Sleep(1000);
			Process[] processByName = this.GetProcessByName("vip72socks");
			bool flag = processByName.Count<Process>() > 0;
			bool result;
			if (flag)
			{
				bool flag2 = !processByName[0].Responding;
				if (flag2)
				{
					try
					{
						bool flag3 = !processByName[0].HasExited;
						if (flag3)
						{
							processByName[0].Kill();
						}
					}
					catch (Exception)
					{
					}
					result = this.vip72login(username, password, mainPort);
					return result;
				}
			}
			IntPtr parentHandle = IntPtr.Zero;
			bool flag4 = processByName.Count<Process>() > 0;
			if (flag4)
			{
				Process arg_A3_0 = processByName[0];
				Func<string, bool> arg_A3_1;
				if ((arg_A3_1 = Vip72Chung.<>c.<>9__32_0) == null)
				{
					arg_A3_1 = (Vip72Chung.<>c.<>9__32_0 = new Func<string, bool>(Vip72Chung.<>c.<>9.<vip72login>b__32_0));
				}
				parentHandle = Vip72Chung.FindWindowInProcess(arg_A3_0, arg_A3_1);
			}
			IntPtr intPtr = Vip72Chung.ControlGetHandle(parentHandle, "Button", 119);
			bool flag5 = intPtr != IntPtr.Zero;
			if (flag5)
			{
				bool flag6 = !Vip72Chung.ControlGetState(intPtr, 134217728);
				if (flag6)
				{
					IntPtr hwnd = Vip72Chung.ControlGetHandle(parentHandle, "Edit", 303);
					Vip72Chung.ControlSetText(hwnd, username);
					IntPtr hwnd2 = Vip72Chung.ControlGetHandle(parentHandle, "Edit", 301);
					Vip72Chung.ControlSetText(hwnd2, password);
					Vip72Chung.ControlClick(intPtr);
					IntPtr hwnd3 = Vip72Chung.ControlGetHandle(parentHandle, "Edit", 131);
					DateTime now = DateTime.Now;
					while (Vip72Chung.ControlGetText(hwnd3) != "System ready")
					{
						bool flag7 = processByName.Count<Process>() > 0;
						if (flag7)
						{
							processByName = this.GetProcessByName("vip72socks");
							bool flag8 = !processByName[0].Responding;
							if (flag8)
							{
								try
								{
									bool flag9 = !processByName[0].HasExited;
									if (flag9)
									{
										processByName[0].Kill();
									}
								}
								catch (Exception)
								{
								}
								bool flag10 = this.vip72login(username, password, mainPort);
								result = flag10;
								return result;
							}
						}
						bool flag11 = processByName.Count<Process>() == 0;
						if (flag11)
						{
							result = false;
							return result;
						}
						bool flag12 = Vip72Chung.ControlGetText(hwnd3) == "ERROR!Login and Password is incorrect";
						if (flag12)
						{
							result = false;
							return result;
						}
						bool flag13 = !Vip72Chung.ControlGetState(intPtr, 134217728);
						if (flag13)
						{
							result = false;
							return result;
						}
						Thread.Sleep(100);
						bool flag14 = (DateTime.Now - now).Seconds > 20;
						if (flag14)
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
				processByName = this.GetProcessByName("vip72socks");
				bool flag15 = processByName.Count<Process>() != 0;
				if (flag15)
				{
					try
					{
						bool flag16 = !processByName[0].HasExited;
						if (flag16)
						{
							processByName[0].Kill();
						}
					}
					catch (Exception)
					{
					}
				}
				Process.Start(new ProcessStartInfo
				{
					FileName = "vip72socks.exe",
					WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory + "vip72"
				});
				Thread.Sleep(500);
				bool flag17 = this.vip72login(username, password, mainPort);
				result = flag17;
			}
			return result;
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x00029B7C File Offset: 0x00027D7C
		public void clearip()
		{
			Process[] processByName = this.GetProcessByName("vip72socks");
			bool flag = processByName.Count<Process>() > 0;
			if (flag)
			{
				Process arg_40_0 = processByName[0];
				Func<string, bool> arg_40_1;
				if ((arg_40_1 = Vip72Chung.<>c.<>9__33_0) == null)
				{
					arg_40_1 = (Vip72Chung.<>c.<>9__33_0 = new Func<string, bool>(Vip72Chung.<>c.<>9.<clearip>b__33_0));
				}
				IntPtr parentHandle = Vip72Chung.FindWindowInProcess(arg_40_0, arg_40_1);
				IntPtr intPtr = Vip72Chung.OpenProcess(2035711, false, processByName[0].Id);
				byte[] array = new byte[]
				{
					144,
					144
				};
				IntPtr hWnd = Vip72Chung.ControlGetHandle(parentHandle, "SysListView32", 117);
				for (int i = 0; i < 30; i++)
				{
					int num = 0;
					Vip72Chung.SendMessageTimeout(hWnd, 256, (IntPtr)46, IntPtr.Zero, 2, 5000, out num);
				}
			}
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x00029C50 File Offset: 0x00027E50
		public void clearIpWithPort(int port)
		{
			Process[] processByName = this.GetProcessByName("vip72socks");
			bool flag = processByName.Count<Process>() == 0;
			if (!flag)
			{
				uint id = (uint)processByName[0].Id;
				Process arg_4D_0 = processByName[0];
				Func<string, bool> arg_4D_1;
				if ((arg_4D_1 = Vip72Chung.<>c.<>9__34_0) == null)
				{
					arg_4D_1 = (Vip72Chung.<>c.<>9__34_0 = new Func<string, bool>(Vip72Chung.<>c.<>9.<clearIpWithPort>b__34_0));
				}
				IntPtr parentHandle = Vip72Chung.FindWindowInProcess(arg_4D_0, arg_4D_1);
				IntPtr intPtr = Vip72Chung.ControlGetHandle(parentHandle, "SysListView32", 117);
				int num = 0;
				while (ListViewItem1.GetListViewItem(intPtr, id, num, 4) != "")
				{
					string listViewItem = ListViewItem1.GetListViewItem(intPtr, id, num, 4);
					bool flag2 = listViewItem.Contains(port.ToString()) || listViewItem.Contains("main stream");
					if (flag2)
					{
						ListViewItem1.SelectListViewItem(intPtr, id, num);
						int num2 = 0;
						Vip72Chung.SendMessageTimeout(intPtr, 256, (IntPtr)46, IntPtr.Zero, 2, 5000, out num2);
						num--;
					}
					num++;
				}
			}
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x00029D50 File Offset: 0x00027F50
		public string clickip(int port)
		{
			int value = 4328465;
			int lpBaseAddress = 4324611;
			int lpBaseAddress2 = 4324304;
			int lpBaseAddress3 = 4253085;
			Process[] processByName = this.GetProcessByName("vip72socks");
			bool flag = processByName.Count<Process>() == 0;
			string result;
			if (flag)
			{
				result = "not running";
			}
			else
			{
				Process arg_66_0 = processByName[0];
				Func<string, bool> arg_66_1;
				if ((arg_66_1 = Vip72Chung.<>c.<>9__35_0) == null)
				{
					arg_66_1 = (Vip72Chung.<>c.<>9__35_0 = new Func<string, bool>(Vip72Chung.<>c.<>9.<clickip>b__35_0));
				}
				IntPtr parentHandle = Vip72Chung.FindWindowInProcess(arg_66_0, arg_66_1);
				IntPtr intPtr = Vip72Chung.ControlGetHandle(parentHandle, "Button", 7817);
				bool flag2 = Vip72Chung.ControlGetCheck(intPtr);
				if (flag2)
				{
					Vip72Chung.ControlClick(intPtr);
				}
				IntPtr intPtr2 = Vip72Chung.OpenProcess(2035711, false, processByName[0].Id);
				int num = 0;
				IntPtr lpBuffer = IntPtr.Zero;
				lpBuffer = Marshal.AllocHGlobal(4);
				Vip72Chung.ReadProcessMemory(intPtr2, (IntPtr)value, lpBuffer, 4, out num);
				Random random = new Random();
				uint id = (uint)processByName[0].Id;
				IntPtr intPtr3 = Vip72Chung.ControlGetHandle(parentHandle, "SysListView32", 117);
				int num2 = 0;
				while (ListViewItem1.GetListViewItem(intPtr3, id, num2, 4) != "")
				{
					string listViewItem = ListViewItem1.GetListViewItem(intPtr3, id, num2, 4);
					bool flag3 = listViewItem.Contains(port.ToString()) || listViewItem.Contains("main stream");
					if (flag3)
					{
						ListViewItem1.SelectListViewItem(intPtr3, id, num2);
						int num3 = 0;
						Vip72Chung.SendMessageTimeout(intPtr3, 256, (IntPtr)46, IntPtr.Zero, 2, 5000, out num3);
					}
					else
					{
						num2++;
					}
				}
				IntPtr hwnd = Vip72Chung.ControlGetHandle(parentHandle, "SysListView32", 116);
				while (ListViewItem1.GetListViewItem(hwnd, id, num2, 0) != "")
				{
					num2++;
				}
				int num4 = num2;
				bool flag4 = num4 == 0;
				if (flag4)
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
						bool flag5 = listViewItem2.Contains(".**");
						if (flag5)
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
					bool flag6 = num5 == -1;
					if (flag6)
					{
						result = "no IP";
					}
					else
					{
						int[] array = new int[]
						{
							472809
						};
						int[] lpBuffer2 = new int[]
						{
							port
						};
						int[] lpBuffer3 = new int[]
						{
							num5
						};
						int num6 = 0;
						Vip72Chung.WriteProcessMemory((int)intPtr2, lpBaseAddress, lpBuffer2, 4, ref num6);
						Vip72Chung.WriteProcessMemory((int)intPtr2, lpBaseAddress3, array, 4, ref num6);
						Vip72Chung.WriteProcessMemory((int)intPtr2, lpBaseAddress2, lpBuffer3, 4, ref num6);
						ListViewItem1.SelectListViewItem(hwnd, id, num5);
						Vip72Chung.ControlDoubleClick(hwnd);
						Thread.Sleep(500);
						array[0] = 21529871;
						Vip72Chung.WriteProcessMemory((int)intPtr2, lpBaseAddress3, array, 4, ref num6);
						IntPtr controlhand = Vip72Chung.ControlGetHandle(parentHandle, "Button", 7303);
						IntPtr hwnd2 = Vip72Chung.ControlGetHandle(parentHandle, "Edit", 131);
						DateTime now = DateTime.Now;
						while (!Vip72Chung.ControlGetCheck(controlhand))
						{
							bool flag7 = Vip72Chung.ControlGetText(hwnd2).Contains("ffline");
							if (flag7)
							{
								result = "dead";
								return result;
							}
							bool flag8 = Vip72Chung.ControlGetText(hwnd2).Contains("limit");
							if (flag8)
							{
								try
								{
									bool flag9 = !processByName[0].HasExited;
									if (flag9)
									{
										processByName[0].Kill();
									}
								}
								catch (Exception)
								{
								}
								result = "limited";
								return result;
							}
							bool flag10 = Vip72Chung.ControlGetText(hwnd2).Contains("can't");
							if (flag10)
							{
								result = "dead";
								return result;
							}
							bool flag11 = Vip72Chung.ControlGetText(hwnd2).Contains("disconnect");
							if (flag11)
							{
								result = "dead";
								return result;
							}
							bool flag12 = Vip72Chung.ControlGetText(hwnd2).Contains("aximum");
							if (flag12)
							{
								result = "maximum";
								return result;
							}
							bool flag13 = (DateTime.Now - now).TotalSeconds > 15.0;
							if (flag13)
							{
								result = "timeout";
								return result;
							}
						}
						Thread.Sleep(500);
						intPtr3 = Vip72Chung.ControlGetHandle(parentHandle, "SysListView32", 117);
						num2 = 0;
						while (ListViewItem1.GetListViewItem(intPtr3, id, num2, 4) != "")
						{
							string listViewItem3 = ListViewItem1.GetListViewItem(intPtr3, id, num2, 4);
							bool flag14 = listViewItem3.Contains(port.ToString());
							if (flag14)
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

		// Token: 0x0600047B RID: 1147 RVA: 0x000290F0 File Offset: 0x000272F0
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

		// Token: 0x0600047C RID: 1148 RVA: 0x0002A268 File Offset: 0x00028468
		public bool getip(byte countryindex)
		{
			byte[] array = new byte[1];
			int[] array2 = new int[1];
			array[0] = countryindex;
			int num = 4482683;
			Process[] processByName = this.GetProcessByName("vip72socks");
			Process process = new Process();
			bool flag = processByName.Count<Process>() > 0;
			bool result;
			if (flag)
			{
				process = processByName[0];
				Process arg_65_0 = process;
				Func<string, bool> arg_65_1;
				if ((arg_65_1 = Vip72Chung.<>c.<>9__37_0) == null)
				{
					arg_65_1 = (Vip72Chung.<>c.<>9__37_0 = new Func<string, bool>(Vip72Chung.<>c.<>9.<getip>b__37_0));
				}
				IntPtr parentHandle = Vip72Chung.FindWindowInProcess(arg_65_0, arg_65_1);
				IntPtr value = Vip72Chung.OpenProcess(2035711, false, process.Id);
				int num2 = 0;
				Vip72Chung.WriteProcessMemory((int)value, num, array, 1, ref num2);
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
				Vip72Chung.WriteProcessMemory((int)value, num + 1, array2, 4, ref num2);
				IntPtr intPtr = Vip72Chung.ControlGetHandle(parentHandle, "Button", 127);
				Vip72Chung.ControlClick(intPtr);
				IntPtr intPtr2 = Vip72Chung.ControlGetHandle(parentHandle, "Edit", 131);
				DateTime now = DateTime.Now;
				while (Vip72Chung.ControlGetState(intPtr, 134217728))
				{
					Thread.Sleep(100);
					Process[] processByName2 = this.GetProcessByName("vip72socks");
					bool flag3 = processByName2.Count<Process>() == 0;
					if (flag3)
					{
						result = false;
						return result;
					}
					bool flag4 = !processByName2[0].Responding || (DateTime.Now - now).TotalSeconds > 30.0;
					if (flag4)
					{
						try
						{
							bool flag5 = !processByName2[0].HasExited;
							if (flag5)
							{
								processByName2[0].Kill();
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

		// Token: 0x0400037B RID: 891
		public const int WM_LBUTTONDOWN = 513;

		// Token: 0x0400037C RID: 892
		public const int WM_LBUTTONUP = 514;

		// Token: 0x02000077 RID: 119
		// Token: 0x0600047F RID: 1151
		public delegate bool EnumWindowsProc(IntPtr hwnd, IntPtr lParam);

		// Token: 0x02000079 RID: 121
		[CompilerGenerated]
		[Serializable]
		private sealed class <>c
		{
			// Token: 0x06000486 RID: 1158 RVA: 0x00003949 File Offset: 0x00001B49
			internal bool <waitiotherVIP72>b__31_0(string x)
			{
				return x.StartsWith("");
			}

			// Token: 0x06000487 RID: 1159 RVA: 0x00003930 File Offset: 0x00001B30
			internal bool <vip72login>b__32_0(string s)
			{
				return s.StartsWith("VIP72 Socks Client");
			}

			// Token: 0x06000488 RID: 1160 RVA: 0x00003930 File Offset: 0x00001B30
			internal bool <clearip>b__33_0(string s)
			{
				return s.StartsWith("VIP72 Socks Client");
			}

			// Token: 0x06000489 RID: 1161 RVA: 0x00003930 File Offset: 0x00001B30
			internal bool <clearIpWithPort>b__34_0(string s)
			{
				return s.StartsWith("VIP72 Socks Client");
			}

			// Token: 0x0600048A RID: 1162 RVA: 0x00003930 File Offset: 0x00001B30
			internal bool <clickip>b__35_0(string s)
			{
				return s.StartsWith("VIP72 Socks Client");
			}

			// Token: 0x0600048B RID: 1163 RVA: 0x00003930 File Offset: 0x00001B30
			internal bool <getip>b__37_0(string s)
			{
				return s.StartsWith("VIP72 Socks Client");
			}

			// Token: 0x0400037F RID: 895
			public static readonly Vip72Chung.<>c <>9 = new Vip72Chung.<>c();

			// Token: 0x04000380 RID: 896
			public static Func<string, bool> <>9__31_0;

			// Token: 0x04000381 RID: 897
			public static Func<string, bool> <>9__32_0;

			// Token: 0x04000382 RID: 898
			public static Func<string, bool> <>9__33_0;

			// Token: 0x04000383 RID: 899
			public static Func<string, bool> <>9__34_0;

			// Token: 0x04000384 RID: 900
			public static Func<string, bool> <>9__35_0;

			// Token: 0x04000385 RID: 901
			public static Func<string, bool> <>9__37_0;
		}
	}
}
