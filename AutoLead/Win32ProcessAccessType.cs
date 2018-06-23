using System;

namespace AutoLead
{
	// Token: 0x0200006C RID: 108
	[Flags]
	public enum Win32ProcessAccessType
	{
		// Token: 0x04000348 RID: 840
		AllAccess = 1050235,
		// Token: 0x04000349 RID: 841
		CreateThread = 2,
		// Token: 0x0400034A RID: 842
		DuplicateHandle = 64,
		// Token: 0x0400034B RID: 843
		QueryInformation = 1024,
		// Token: 0x0400034C RID: 844
		SetInformation = 512,
		// Token: 0x0400034D RID: 845
		Terminate = 1,
		// Token: 0x0400034E RID: 846
		VMOperation = 8,
		// Token: 0x0400034F RID: 847
		VMRead = 16,
		// Token: 0x04000350 RID: 848
		VMWrite = 32,
		// Token: 0x04000351 RID: 849
		Synchronize = 1048576
	}
}
