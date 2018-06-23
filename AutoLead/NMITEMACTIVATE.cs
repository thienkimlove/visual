using System;

namespace AutoLead
{
	// Token: 0x0200006A RID: 106
	internal struct NMITEMACTIVATE
	{
		// Token: 0x04000334 RID: 820
		public IntPtr hdr;

		// Token: 0x04000335 RID: 821
		public int iItem;

		// Token: 0x04000336 RID: 822
		public int iSubItem;

		// Token: 0x04000337 RID: 823
		public uint uNewState;

		// Token: 0x04000338 RID: 824
		public uint uOldState;

		// Token: 0x04000339 RID: 825
		public uint uChanged;

		// Token: 0x0400033A RID: 826
		public IntPtr ptAction;

		// Token: 0x0400033B RID: 827
		public uint lParam;

		// Token: 0x0400033C RID: 828
		public uint uKeyFlags;
	}
}
