using System;
using System.Runtime.InteropServices;

namespace AutoLead
{
	// Token: 0x02000071 RID: 113
	public class ListViewItem1
	{
		// Token: 0x06000414 RID: 1044
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr SendMessageTimeout(IntPtr hWnd, int Msg, IntPtr wParam, string lParam, int fuFlags, int uTimeout, IntPtr lpdwResult);

		// Token: 0x06000415 RID: 1045
		[DllImport("kernel32.dll")]
		internal static extern IntPtr OpenProcess(Win32ProcessAccessType dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, uint dwProcessId);

		// Token: 0x06000416 RID: 1046
		[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
		internal static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, Win32AllocationTypes flWin32AllocationType, Win32MemoryProtection flProtect);

		// Token: 0x06000417 RID: 1047
		[DllImport("kernel32.dll", SetLastError = true)]
		internal static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, ref LV_ITEM lpBuffer, uint nSize, out int lpNumberOfBytesWritten);

		// Token: 0x06000418 RID: 1048
		[DllImport("kernel32.dll", SetLastError = true)]
		internal static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, ref NMITEMACTIVATE lpBuffer, uint nSize, out int lpNumberOfBytesWritten);

		// Token: 0x06000419 RID: 1049
		[DllImport("kernel32.dll", SetLastError = true)]
		internal static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, ref POINT lpBuffer, uint nSize, out int lpNumberOfBytesWritten);

		// Token: 0x0600041A RID: 1050
		[DllImport("kernel32.dll", SetLastError = true)]
		internal static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, ref NMHDR lpBuffer, uint nSize, out int lpNumberOfBytesWritten);

		// Token: 0x0600041B RID: 1051
		[DllImport("kernel32.dll", SetLastError = true)]
		internal static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, int dwSize, out int lpNumberOfBytesRead);

		// Token: 0x0600041C RID: 1052
		[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
		internal static extern bool VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress, int dwSize, Win32AllocationTypes dwFreeType);

		// Token: 0x0600041D RID: 1053
		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool CloseHandle(IntPtr hObject);

		// Token: 0x0600041E RID: 1054
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

		// Token: 0x0600041F RID: 1055
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr SendMessageTimeout(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam, int fuFlags, int uTimeout, IntPtr lpdwResult);

		// Token: 0x06000420 RID: 1056
		[DllImport("user32.dll")]
		private static extern int GetDlgCtrlID(IntPtr hwndCtl);

		// Token: 0x06000421 RID: 1057 RVA: 0x00027F08 File Offset: 0x00026108
		public static void DoubleClickListView(IntPtr hwnd, uint processId, int item, int subitem)
		{
			IntPtr intPtr = IntPtr.Zero;
			IntPtr intPtr2 = IntPtr.Zero;
			NMHDR nMHDR;
			nMHDR.hwndFrom = (int)hwnd;
			nMHDR.idFrom = 116;
			nMHDR.code = 515;
			IntPtr hProcess = IntPtr.Zero;
			hProcess = ListViewItem1.OpenProcess(Win32ProcessAccessType.AllAccess, false, processId);
			intPtr = ListViewItem1.VirtualAllocEx(hProcess, IntPtr.Zero, 2048u, Win32AllocationTypes.MEM_COMMIT, Win32MemoryProtection.PAGE_READWRITE);
			IntPtr zero = IntPtr.Zero;
			int num = 0;
			ListViewItem1.WriteProcessMemory(hProcess, intPtr, ref nMHDR, (uint)Marshal.SizeOf(typeof(NMHDR)), out num);
			POINT pOINT;
			pOINT.x = 31;
			pOINT.y = 31;
			intPtr2 = ListViewItem1.VirtualAllocEx(hProcess, IntPtr.Zero, 2048u, Win32AllocationTypes.MEM_COMMIT, Win32MemoryProtection.PAGE_READWRITE);
			ListViewItem1.WriteProcessMemory(hProcess, intPtr2, ref pOINT, (uint)Marshal.SizeOf(typeof(POINT)), out num);
			NMITEMACTIVATE nMITEMACTIVATE = default(NMITEMACTIVATE);
			nMITEMACTIVATE.hdr = intPtr;
			nMITEMACTIVATE.iItem = item;
			nMITEMACTIVATE.iSubItem = subitem;
			nMITEMACTIVATE.uOldState = 2u;
			nMITEMACTIVATE.uNewState = 0u;
			nMITEMACTIVATE.ptAction = intPtr2;
			IntPtr intPtr3 = IntPtr.Zero;
			intPtr3 = ListViewItem1.VirtualAllocEx(hProcess, IntPtr.Zero, 2048u, Win32AllocationTypes.MEM_COMMIT, Win32MemoryProtection.PAGE_READWRITE);
			ListViewItem1.WriteProcessMemory(hProcess, intPtr3, ref nMITEMACTIVATE, (uint)Marshal.SizeOf(typeof(NMITEMACTIVATE)), out num);
			ListViewItem1.SendMessageTimeout(hwnd, 78, (IntPtr)116, intPtr3, 2, 5000, IntPtr.Zero);
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x00028068 File Offset: 0x00026268
		public static void SelectListViewItem(IntPtr hwnd, uint processId, int item)
		{
			IntPtr intPtr = IntPtr.Zero;
			IntPtr intPtr2 = IntPtr.Zero;
			IntPtr intPtr3 = IntPtr.Zero;
			LV_ITEM lV_ITEM = default(LV_ITEM);
			intPtr3 = Marshal.AllocHGlobal(2048);
			intPtr = ListViewItem1.OpenProcess(Win32ProcessAccessType.AllAccess, false, processId);
			intPtr2 = ListViewItem1.VirtualAllocEx(intPtr, IntPtr.Zero, 2048u, Win32AllocationTypes.MEM_COMMIT, Win32MemoryProtection.PAGE_READWRITE);
			lV_ITEM.state = 3;
			lV_ITEM.stateMask = 3;
			IntPtr zero = IntPtr.Zero;
			int num = 0;
			ListViewItem1.WriteProcessMemory(intPtr, intPtr2, ref lV_ITEM, (uint)Marshal.SizeOf(typeof(LV_ITEM)), out num);
			ListViewItem1.SendMessageTimeout(hwnd, 4139, (IntPtr)item, intPtr2, 2, 5000, IntPtr.Zero);
			ListViewItem1.VirtualFreeEx(intPtr, intPtr2, 0, Win32AllocationTypes.MEM_RELEASE);
			ListViewItem1.CloseHandle(intPtr);
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x00028130 File Offset: 0x00026330
		public static string GetListViewItem(IntPtr hwnd, uint processId, int item, int subItem = 0)
		{
			int num = 0;
			IntPtr intPtr = IntPtr.Zero;
			IntPtr intPtr2 = IntPtr.Zero;
			IntPtr intPtr3 = IntPtr.Zero;
			string result;
			try
			{
				LV_ITEM lV_ITEM = default(LV_ITEM);
				intPtr3 = Marshal.AllocHGlobal(2048);
				intPtr = ListViewItem1.OpenProcess(Win32ProcessAccessType.AllAccess, false, processId);
				bool flag = intPtr == IntPtr.Zero;
				if (flag)
				{
					throw new ApplicationException("Failed to access process!");
				}
				intPtr2 = ListViewItem1.VirtualAllocEx(intPtr, IntPtr.Zero, 2048u, Win32AllocationTypes.MEM_COMMIT, Win32MemoryProtection.PAGE_READWRITE);
				bool flag2 = intPtr2 == IntPtr.Zero;
				if (flag2)
				{
					throw new SystemException("Failed to allocate memory in remote process");
				}
				lV_ITEM.mask = 1;
				lV_ITEM.iItem = item;
				lV_ITEM.iSubItem = subItem;
				lV_ITEM.pszText = intPtr2.ToInt32() + Marshal.SizeOf(typeof(LV_ITEM));
				lV_ITEM.cchTextMax = 500;
				bool flag3 = ListViewItem1.WriteProcessMemory(intPtr, intPtr2, ref lV_ITEM, (uint)Marshal.SizeOf(typeof(LV_ITEM)), out num);
				bool flag4 = !flag3;
				if (flag4)
				{
					throw new SystemException("Failed to write to process memory");
				}
				ListViewItem1.SendMessageTimeout(hwnd, 4171, IntPtr.Zero, intPtr2, 2, 5000, IntPtr.Zero);
				flag3 = ListViewItem1.ReadProcessMemory(intPtr, intPtr2, intPtr3, 2048, out num);
				bool flag5 = !flag3;
				if (flag5)
				{
					throw new SystemException("Failed to read from process memory");
				}
				result = Marshal.PtrToStringUni((IntPtr)(intPtr3.ToInt32() + Marshal.SizeOf(typeof(LV_ITEM))));
			}
			finally
			{
				bool flag6 = intPtr3 != IntPtr.Zero;
				if (flag6)
				{
					Marshal.FreeHGlobal(intPtr3);
				}
				bool flag7 = intPtr2 != IntPtr.Zero;
				if (flag7)
				{
					ListViewItem1.VirtualFreeEx(intPtr, intPtr2, 0, Win32AllocationTypes.MEM_RELEASE);
				}
				bool flag8 = intPtr != IntPtr.Zero;
				if (flag8)
				{
					ListViewItem1.CloseHandle(intPtr);
				}
			}
			return result;
		}

		// Token: 0x0400036D RID: 877
		private static readonly int GWL_ID = -12;
	}
}
