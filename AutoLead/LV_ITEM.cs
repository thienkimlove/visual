using System;

namespace AutoLead
{
	// Token: 0x0200006B RID: 107
	internal struct LV_ITEM
	{
		// Token: 0x0400033D RID: 829
		public int mask;

		// Token: 0x0400033E RID: 830
		public int iItem;

		// Token: 0x0400033F RID: 831
		public int iSubItem;

		// Token: 0x04000340 RID: 832
		public int state;

		// Token: 0x04000341 RID: 833
		public int stateMask;

		// Token: 0x04000342 RID: 834
		public unsafe char* pszText;

		// Token: 0x04000343 RID: 835
		public int cchTextMax;

		// Token: 0x04000344 RID: 836
		public int iImage;

		// Token: 0x04000345 RID: 837
		public int lParam;

		// Token: 0x04000346 RID: 838
		public int iIndent;
	}
}
