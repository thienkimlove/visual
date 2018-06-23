using System;

namespace AutoLead
{
	// Token: 0x0200005F RID: 95
	internal class Script
	{
		// Token: 0x17000045 RID: 69
		public string scriptname
		{
			// Token: 0x060003BB RID: 955 RVA: 0x0000369E File Offset: 0x0000189E
			get;
			// Token: 0x060003BC RID: 956 RVA: 0x000036A6 File Offset: 0x000018A6
			set;
		}

		// Token: 0x17000046 RID: 70
		public string script
		{
			// Token: 0x060003BD RID: 957 RVA: 0x000036AF File Offset: 0x000018AF
			get;
			// Token: 0x060003BE RID: 958 RVA: 0x000036B7 File Offset: 0x000018B7
			set;
		}

		// Token: 0x17000047 RID: 71
		public int slot
		{
			// Token: 0x060003BF RID: 959 RVA: 0x000036C0 File Offset: 0x000018C0
			get;
			// Token: 0x060003C0 RID: 960 RVA: 0x000036C8 File Offset: 0x000018C8
			set;
		}

		// Token: 0x060003C1 RID: 961 RVA: 0x000036D1 File Offset: 0x000018D1
		public Script()
		{
			this.scriptname = "";
			this.script = "";
			this.slot = 0;
		}
	}
}
