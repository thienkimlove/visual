using System;

namespace AutoLead
{
	// Token: 0x0200006D RID: 109
	[Flags]
	public enum Win32AllocationTypes
	{
		// Token: 0x04000353 RID: 851
		MEM_COMMIT = 4096,
		// Token: 0x04000354 RID: 852
		MEM_RESERVE = 8192,
		// Token: 0x04000355 RID: 853
		MEM_DECOMMIT = 16384,
		// Token: 0x04000356 RID: 854
		MEM_RELEASE = 32768,
		// Token: 0x04000357 RID: 855
		MEM_RESET = 524288,
		// Token: 0x04000358 RID: 856
		MEM_PHYSICAL = 4194304,
		// Token: 0x04000359 RID: 857
		MEM_TOP_DOWN = 1048576,
		// Token: 0x0400035A RID: 858
		WriteWatch = 2097152,
		// Token: 0x0400035B RID: 859
		MEM_LARGE_PAGES = 536870912
	}
}
