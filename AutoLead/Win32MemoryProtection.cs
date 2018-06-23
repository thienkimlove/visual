using System;

namespace AutoLead
{
	// Token: 0x0200006E RID: 110
	[Flags]
	public enum Win32MemoryProtection
	{
		// Token: 0x0400035D RID: 861
		PAGE_EXECUTE = 16,
		// Token: 0x0400035E RID: 862
		PAGE_EXECUTE_READ = 32,
		// Token: 0x0400035F RID: 863
		PAGE_EXECUTE_READWRITE = 64,
		// Token: 0x04000360 RID: 864
		PAGE_EXECUTE_WRITECOPY = 128,
		// Token: 0x04000361 RID: 865
		PAGE_NOACCESS = 1,
		// Token: 0x04000362 RID: 866
		PAGE_READONLY = 2,
		// Token: 0x04000363 RID: 867
		PAGE_READWRITE = 4,
		// Token: 0x04000364 RID: 868
		PAGE_WRITECOPY = 8,
		// Token: 0x04000365 RID: 869
		PAGE_GUARD = 256,
		// Token: 0x04000366 RID: 870
		PAGE_NOCACHE = 512,
		// Token: 0x04000367 RID: 871
		PAGE_WRITECOMBINE = 1024
	}
}
