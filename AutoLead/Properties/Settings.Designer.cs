using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace AutoLead.Properties
{
	// Token: 0x0200007B RID: 123
	[CompilerGenerated, GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000075 RID: 117
		public static Settings Default
		{
			// Token: 0x060004B2 RID: 1202 RVA: 0x0002AACC File Offset: 0x00028CCC
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x17000076 RID: 118
		[DefaultSettingValue(""), UserScopedSetting, DebuggerNonUserCode]
		public string ipaddress
		{
			// Token: 0x060004B3 RID: 1203 RVA: 0x0002AAE4 File Offset: 0x00028CE4
			get
			{
				return (string)this["ipaddress"];
			}
			// Token: 0x060004B4 RID: 1204 RVA: 0x00003973 File Offset: 0x00001B73
			set
			{
				this["ipaddress"] = value;
			}
		}

		// Token: 0x04000388 RID: 904
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
