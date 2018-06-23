using System;
using System.Text;

namespace AutoLead
{
	// Token: 0x02000010 RID: 16
	internal class command
	{
		// Token: 0x0600003B RID: 59 RVA: 0x000044B4 File Offset: 0x000026B4
		public void getDeviceInfo()
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("getinfo=1{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600003C RID: 60 RVA: 0x000044F0 File Offset: 0x000026F0
		public void setProxy(string socks, int port)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes(string.Concat(new string[]
				{
					"setProxy=",
					socks,
					":",
					port.ToString(),
					"{|}"
				}));
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00004558 File Offset: 0x00002758
		public void disableProxy()
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("disableProxy={|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00004594 File Offset: 0x00002794
		public void getAppList()
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("getapp=install{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600003F RID: 63 RVA: 0x000045D0 File Offset: 0x000027D0
		public void setReferer(string URL)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("setreferer=" + URL + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00004618 File Offset: 0x00002818
		public void installapp(string appId)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("install=" + appId + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00004660 File Offset: 0x00002860
		public void uninstallapp(string appId)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("uninstall=" + appId + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000042 RID: 66 RVA: 0x000046A8 File Offset: 0x000028A8
		public void openURL(string URL)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("openurl=" + URL + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000043 RID: 67 RVA: 0x000046F0 File Offset: 0x000028F0
		public void openApp(string AppID)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("open=" + AppID + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00004738 File Offset: 0x00002938
		public void close(string AppID)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("close=" + AppID + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00004780 File Offset: 0x00002980
		public void getfront()
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("getapp=front{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000047BC File Offset: 0x000029BC
		public void wipe(string text)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("wipe=" + text + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00004804 File Offset: 0x00002A04
		public void getversion()
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("getversion=1{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00004840 File Offset: 0x00002A40
		public void checkip(string text)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("checkip=" + text + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00004888 File Offset: 0x00002A88
		public void backup(string text)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("backup=" + text + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x000048D0 File Offset: 0x00002AD0
		public void touchRandom(double x, double y, double x1, double y1, double time, double speed)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes(string.Concat(new string[]
				{
					"randomtouch=",
					x.ToString(),
					" ",
					y.ToString(),
					" ",
					x1.ToString(),
					" ",
					y1.ToString(),
					" ",
					time.ToString(),
					" ",
					speed.ToString(),
					"{|}"
				}));
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600004B RID: 75 RVA: 0x0000498C File Offset: 0x00002B8C
		public void touch(double x, double y)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes(string.Concat(new string[]
				{
					"touch=",
					x.ToString(),
					" ",
					y.ToString(),
					"{|}"
				}));
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600004C RID: 76 RVA: 0x000049F8 File Offset: 0x00002BF8
		public void swipe(double x1, double y1, double x2, double y2, double time)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes(string.Concat(new string[]
				{
					"swipe=",
					x1.ToString(),
					" ",
					y1.ToString(),
					" ",
					x2.ToString(),
					" ",
					y2.ToString(),
					" ",
					time.ToString(),
					"{|}"
				}));
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00004AA0 File Offset: 0x00002CA0
		public void sendtext(string text)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("send=" + text + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00004AE8 File Offset: 0x00002CE8
		public void backupfull(string text)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("backupfull=" + text + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00004B30 File Offset: 0x00002D30
		public void savecomment(string filename, string comment)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes(string.Concat(new string[]
				{
					"savecomment=",
					filename,
					"=",
					comment,
					"{|}"
				}));
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00004B90 File Offset: 0x00002D90
		public void fakeversion(string text)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("fakeversion=" + text + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00004BD8 File Offset: 0x00002DD8
		public void faketype(string text)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("faketype=" + text + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00004C20 File Offset: 0x00002E20
		public void backupfull(string text, string filename, string comment, string timemod, string runtime)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes(string.Concat(new string[]
				{
					"backupfull=",
					text,
					"|",
					filename,
					"|",
					comment,
					"|",
					timemod,
					"|",
					runtime,
					"{|}"
				}));
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00004CAC File Offset: 0x00002EAC
		public void backup(string text, string filename, string comment, string timemod, string runtime)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes(string.Concat(new string[]
				{
					"backup=",
					text,
					"|",
					filename,
					"|",
					comment,
					timemod,
					"|",
					runtime,
					"{|}"
				}));
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00004D2C File Offset: 0x00002F2C
		public void setsocks(string text)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("setsocks=" + text + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00004D74 File Offset: 0x00002F74
		public void getbackup()
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("getbackup=1{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00004DB0 File Offset: 0x00002FB0
		public void checkwipe()
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("checkwipe=1{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00004DEC File Offset: 0x00002FEC
		public void checkbackup(string filename)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("checkbackup=" + filename + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00004E34 File Offset: 0x00003034
		public void checkbackup()
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("checkbackup=1{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00004E70 File Offset: 0x00003070
		public void checkrestore()
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("checkrestore=1{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00004EAC File Offset: 0x000030AC
		public void deletebackup(string text)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("deletebackup=" + text + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00004EF4 File Offset: 0x000030F4
		public void restore(string text)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("restore=" + text + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00004F3C File Offset: 0x0000313C
		public void changetimezone(string text)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("changetimezone=" + text + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00004F84 File Offset: 0x00003184
		public void changecarrier(string text)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("changecarrier=" + text + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00004FCC File Offset: 0x000031CC
		public void changecarrier(string carriername, string countrycode, string carriercode, string ioscountrycode)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes(string.Concat(new string[]
				{
					"changecarrier=",
					carriername,
					"||",
					countrycode,
					"||",
					carriercode,
					"||",
					ioscountrycode,
					"{|}"
				}));
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00005048 File Offset: 0x00003248
		public void randomtouchpause()
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("rdtouchPause={|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00005084 File Offset: 0x00003284
		public void randomtouchresume()
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("rdtouchResume={|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000061 RID: 97 RVA: 0x000050C0 File Offset: 0x000032C0
		public void randomtouchstop()
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("rdtouchStop={|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000062 RID: 98 RVA: 0x000050FC File Offset: 0x000032FC
		public void changename(string text)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("changename=" + text + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00005144 File Offset: 0x00003344
		public void mousedown(int x, int y)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes(string.Concat(new string[]
				{
					"mousedown=",
					x.ToString(),
					" ",
					y.ToString(),
					"{|}"
				}));
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x000051B0 File Offset: 0x000033B0
		public void excuteScript(string text)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("script=" + text + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000065 RID: 101 RVA: 0x000051F8 File Offset: 0x000033F8
		public void getAllProtectData()
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("getAllProtectData={|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00005234 File Offset: 0x00003434
		public void getProtectData(string appID)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("getProtectData=" + appID + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000067 RID: 103 RVA: 0x0000527C File Offset: 0x0000347C
		public void resping()
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("resping={|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000068 RID: 104 RVA: 0x000052B8 File Offset: 0x000034B8
		public void addProtectData(string path)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("addProtectData=" + path + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00005300 File Offset: 0x00003500
		public void removeProtectData(string path)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("removeProtectData=" + path + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00005348 File Offset: 0x00003548
		public void getSubFolder(string path)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("getSubFolder=" + path + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00005390 File Offset: 0x00003590
		public void pauseScript(string text)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("pausescript=1{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600006C RID: 108 RVA: 0x000053CC File Offset: 0x000035CC
		public void mouseup(int x, int y)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes(string.Concat(new string[]
				{
					"mouseup=",
					x.ToString(),
					" ",
					y.ToString(),
					"{|}"
				}));
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00005438 File Offset: 0x00003638
		public void changeversion(string text)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("changeversion=" + text + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00005480 File Offset: 0x00003680
		public void fakeGPS(bool enable)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("locationFaker=" + (enable ? "1" : "0") + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x0600006F RID: 111 RVA: 0x000054D4 File Offset: 0x000036D4
		public void fakeGPS(bool enable, double latitude, double longitude)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes(string.Concat(new string[]
				{
					"locationFaker=",
					enable ? "1" : "0",
					"|",
					latitude.ToString(),
					"|",
					longitude.ToString(),
					"{|}"
				}));
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000070 RID: 112 RVA: 0x0000555C File Offset: 0x0000375C
		public void changeregion(string text)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("changeregion=" + text + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000071 RID: 113 RVA: 0x000055A4 File Offset: 0x000037A4
		public void randominfo()
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("randominfo=1{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x000055E0 File Offset: 0x000037E0
		public void changelanguage(string text)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("changelanguage=" + text + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00005628 File Offset: 0x00003828
		public void changedevice(string text)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("changedevice=" + text + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00005670 File Offset: 0x00003870
		public void getproxy()
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("getproxy=1{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000075 RID: 117 RVA: 0x000056AC File Offset: 0x000038AC
		public void wipefull(string text)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("wipefull=" + text + "{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000076 RID: 118 RVA: 0x000056F4 File Offset: 0x000038F4
		public void clearipa()
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("cleanipa=1{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00005730 File Offset: 0x00003930
		public void enablemouse()
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("enablemouse=YES{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000078 RID: 120 RVA: 0x0000576C File Offset: 0x0000396C
		public void disablemouse()
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes("enablemouse=NO{|}");
				this.sendControl(bytes);
			}
		}

		// Token: 0x06000079 RID: 121 RVA: 0x000057A8 File Offset: 0x000039A8
		public void movemouse(int x, int y)
		{
			bool flag = this.sendControl != null;
			if (flag)
			{
				byte[] bytes = Encoding.Unicode.GetBytes(string.Concat(new string[]
				{
					"movemouse=",
					x.ToString(),
					" ",
					y.ToString(),
					"{|}"
				}));
				this.sendControl(bytes);
			}
		}

		// Token: 0x04000037 RID: 55
		public command.SendControl sendControl;

		// Token: 0x02000011 RID: 17
		// Token: 0x0600007C RID: 124
		public delegate void SendControl(byte[] buffer);
	}
}
