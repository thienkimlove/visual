using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using AutoLead.Properties;
using IPAddressControlLib;
using Microsoft.CSharp.RuntimeBinder;
using Renci.SshNet;
using RNCryptor;

namespace AutoLead
{
	// Token: 0x02000013 RID: 19
	public partial class Form1 : Form
	{
		// Token: 0x06000082 RID: 130 RVA: 0x00005944 File Offset: 0x00003B44
		public static int GetRandomNumber(int min, int max)
		{
			object obj = Form1.syncLock;
			int result;
			lock (obj)
			{
				result = Form1.getrandom.Next(min, max);
			}
			return result;
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00005990 File Offset: 0x00003B90
		public Form1(string param)
		{
			Random random = new Random();
			this.listcommand = Resources.scriptcommand.Split(new string[]
			{
				"\r\n"
			}, StringSplitOptions.None).ToList<string>();
			this.usformat = new CultureInfo(this.usCulture, false);
			this.listfirstname = Resources.firstname.Split(new string[]
			{
				"\r\n"
			}, StringSplitOptions.None).ToList<string>();
			this.listlastname = Resources.lastname.Split(new string[]
			{
				"\r\n"
			}, StringSplitOptions.None).ToList<string>();
			this.listemaildomain = Resources.emaildomain.Split(new string[]
			{
				"\r\n"
			}, StringSplitOptions.None).ToList<string>();
			this.dataleft = "";
			this.removeandreplace();
			this.InitializeComponent();
			this.numericUpDown1.Value = random.Next(1000, 65000);
			this.DeviceIpControl.Text = Settings.Default.ipaddress;
			this.loadlangcode();
			this.loadtimezone();
			this.loadcarrier();
			this.loadgeo();
			this.loadcountrycodeiOS();
			this.lvwColumnSorter = new ListViewColumnSorter();
			this.listView4.ListViewItemSorter = this.lvwColumnSorter;
			this.listView4.OwnerDraw = true;
			this.ipAddressControl1.Text = Form1.IPAddresses();
			this.optionform.passControl = new OfferOption.PassControl(this.passlistview);
			this.optionform.UpdateCombo = new OfferOption.updateCombo(this.getApp);
			this.optionform.StartPosition = FormStartPosition.CenterScreen;
			this.loadcountrycode();
			ImageList imageList = new ImageList();
			imageList.ImageSize = new Size(1, 50);
			this.listView1.SmallImageList = imageList;
			this.proxytool.Text = "SSH";
			this.cmd.sendControl = new command.SendControl(this.Send);
			this.checkversion();
			Process[] processesByName = Process.GetProcessesByName("AutoLead");
			List<string> list = new List<string>();
			Process[] array = processesByName;
			for (int i = 0; i < array.Length; i++)
			{
				Process process = array[i];
				string mainWindowTitle = process.MainWindowTitle;
				bool flag = mainWindowTitle != "";
				if (flag)
				{
					list.Add(mainWindowTitle);
				}
			}
			bool flag2 = param == "start";
			if (flag2)
			{
				string[] array2 = File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//iplist.txt");
				for (int j = 0; j < array2.Length; j++)
				{
					string lastip = array2[j].Split(new string[]
					{
						"."
					}, StringSplitOptions.None)[3];
					bool flag3 = list.FirstOrDefault((string x) => x == lastip) == null;
					if (flag3)
					{
						new Process
						{
							StartInfo = 
							{
								FileName = AppDomain.CurrentDomain.BaseDirectory + "AutoLead.exe",
								Arguments = array2[j]
							}
						}.Start();
						Thread.Sleep(500);
					}
				}
				Application.Exit();
				Environment.Exit(0);
			}
			bool flag4 = param != "none";
			if (flag4)
			{
				this.DeviceIpControl.Text = param;
				this.button2_Click(null, null);
			}
		}

		// Token: 0x06000084 RID: 132 RVA: 0x000021A5 File Offset: 0x000003A5
		private void loadgeo()
		{
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00005F8C File Offset: 0x0000418C
		private void loadcarrier()
		{
			string[] array = Resources.carrierlist.Split(new string[]
			{
				"\r\n"
			}, StringSplitOptions.None);
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string text = array2[i];
				string[] array3 = text.Split(new string[]
				{
					"||"
				}, StringSplitOptions.None);
				Carrier carrier = new Carrier();
				carrier.CarrierName = array3[0];
				carrier.country = array3[1];
				carrier.ISOCountryCode = array3[2];
				carrier.mobileCarrierCode = array3[3];
				carrier.mobileCountryCode = array3[4];
				this.carrierList.Add(carrier);
				this._listcountry.Add(array3[1]);
			}
			this._listcountry = this._listcountry.Distinct<string>().ToList<string>();
			this.carrierBox.Items.AddRange(this._listcountry.ToArray());
			this.carrierBox.Text = "United States of America";
		}

		// Token: 0x06000086 RID: 134 RVA: 0x0000608C File Offset: 0x0000428C
		private void loadtimezone()
		{
			string timezone = Resources.timezone;
			this.listtimezone = timezone.Split(new string[]
			{
				"\",\""
			}, StringSplitOptions.None).ToList<string>();
		}

		// Token: 0x06000087 RID: 135 RVA: 0x000021A5 File Offset: 0x000003A5
		private void getuseragentfordevice()
		{
		}

		// Token: 0x06000088 RID: 136 RVA: 0x000060C0 File Offset: 0x000042C0
		private void loadcountrycode()
		{
			string path = AppDomain.CurrentDomain.BaseDirectory + "countrycode.dat";
			string text = File.ReadAllText(path);
			string[] array = text.Split(new string[]
			{
				"\r\n"
			}, StringSplitOptions.None);
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string text2 = array2[i];
				string[] array3 = text2.Split(new string[]
				{
					"|"
				}, StringSplitOptions.None);
				bool flag = array3.Count<string>() == 2;
				if (flag)
				{
					countrycode countrycode = new countrycode();
					countrycode.country = array3[0];
					countrycode.code = Convert.ToByte(array3[1]);
					this.listcountrycode.Add(countrycode);
				}
			}
		}

		// Token: 0x06000089 RID: 137 RVA: 0x0000617C File Offset: 0x0000437C
		private void loadcountrycodeiOS()
		{
			string countrycodeiOS = Resources.countrycodeiOS;
			string[] array = countrycodeiOS.Split(new string[]
			{
				"\r\n"
			}, StringSplitOptions.None);
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string text = array2[i];
				try
				{
					string[] array3 = text.Split(new string[]
					{
						"|"
					}, StringSplitOptions.None);
					RegionInfo regionInfo = new RegionInfo(array3[0]);
					countrycodeiOS countrycodeiOS2 = new countrycodeiOS();
					countrycodeiOS2.countrycode = array3[0];
					countrycodeiOS2.countryname = regionInfo.EnglishName;
					bool flag = array3.Count<string>() == 1;
					if (flag)
					{
						countrycodeiOS2.languageCode = "en";
					}
					else
					{
						countrycodeiOS2.languageCode = array3[1];
					}
					this.listcountrycodeiOS.Add(countrycodeiOS2);
					this.comboBox2.Items.Add(regionInfo.EnglishName);
				}
				catch (Exception)
				{
				}
			}
			this.comboBox2.Text = "United States";
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00006284 File Offset: 0x00004484
		private void loadlangcode()
		{
			string languagecode = Resources.languagecode;
			string[] array = languagecode.Split(new string[]
			{
				"\r\n"
			}, StringSplitOptions.None);
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string text = array2[i];
				string[] array3 = text.Split(new string[]
				{
					"|"
				}, StringSplitOptions.None);
				languagecode languagecode2 = new languagecode();
				languagecode2.langcode = array3[1];
				languagecode2.langname = array3[0];
				this.listlanguagecode.Add(languagecode2);
				this.comboBox1.Items.Add(languagecode2.langname);
			}
			this.comboBox1.Text = "English";
		}

		// Token: 0x0600008B RID: 139 RVA: 0x000021A8 File Offset: 0x000003A8
		private void getApp()
		{
			this.optionform.setButton3(true);
			this.cmd.getAppList();
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00006334 File Offset: 0x00004534
		private void button2_Click(object sender, EventArgs e)
		{
			bool flag = this.button2.Text == "Connect";
			if (flag)
			{
				string text = this.DeviceIpControl.Text;
				string[] array = text.Split(new string[]
				{
					"."
				}, StringSplitOptions.None);
				bool flag2 = true;
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					string a = array2[i];
					bool flag3 = a == "";
					if (flag3)
					{
						flag2 = false;
						break;
					}
				}
				bool flag4 = flag2;
				if (flag4)
				{
					this.button2.Text = "Connecting";
					this.button2.Refresh();
					this.label1.Text = "Connecting to iDevice, please wait....";
					this.label1.Refresh();
					this._clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
					IPAddress address = IPAddress.Parse(text);
					this._clientSocket.BeginConnect(new IPEndPoint(address, 2409), new AsyncCallback(this.ConnectCallback), null);
					System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
					t.Interval = 10000;
					t.Tick += delegate(object o, EventArgs ex)
					{
						t.Stop();
						this.label1.Invoke(new MethodInvoker(this.<button2_Click>b__98_1));
					};
					t.Start();
				}
				else
				{
					MessageBox.Show("Ip invalid!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				bool flag5 = this.button2.Text == "Disconnect";
				if (flag5)
				{
					this.disconnect();
				}
			}
		}

		// Token: 0x0600008D RID: 141 RVA: 0x000064D0 File Offset: 0x000046D0
		private void ConnectCallback(IAsyncResult AR)
		{
			try
			{
				this._clientSocket.EndConnect(AR);
				this._buffer = new byte[this._clientSocket.ReceiveBufferSize];
				this._clientSocket.BeginReceive(this._buffer, 0, this._buffer.Length, SocketFlags.None, new AsyncCallback(this.ReceiveCallBack), null);
				this.button2.Invoke(new MethodInvoker(delegate
				{
					this.button2.Text = "Disconnect";
				}));
				this.DeviceIpControl.Invoke(new MethodInvoker(delegate
				{
					this.DeviceIpControl.Enabled = false;
				}));
				this.label1.Invoke(new MethodInvoker(delegate
				{
					this.label1.Text = "Getting info..";
				}));
				this.isconnected = true;
				Thread.Sleep(200);
				base.Invoke(new MethodInvoker(delegate
				{
					this.button15_Click(null, null);
					this.cmd.getproxy();
					this.cmd.getDeviceInfo();
					this.cmd.getAppList();
				}));
			}
			catch (SocketException)
			{
				bool @checked = this.autoreconnect.Checked;
				if (@checked)
				{
					this.button2.Invoke(new MethodInvoker(delegate
					{
						this.button2.Text = "Connect";
					}));
					Thread thread = new Thread(new ThreadStart(this.reconnect));
					thread.Start();
				}
				else
				{
					MessageBox.Show("Unable to connect to Idevice", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					this.label1.Invoke(new MethodInvoker(delegate
					{
						this.label1.Text = "Unable to connect to Idevice";
					}));
					this.button2.Invoke(new MethodInvoker(delegate
					{
						this.button2.Text = "Connect";
					}));
				}
			}
		}

		// Token: 0x0600008E RID: 142 RVA: 0x0000663C File Offset: 0x0000483C
		private void ReceiveCallBack(IAsyncResult AR)
		{
			try
			{
				int newSize = this._clientSocket.EndReceive(AR);
				Array.Resize<byte>(ref this._buffer, newSize);
				string @string = Encoding.Unicode.GetString(this._buffer);
				bool flag = @string == "";
				if (flag)
				{
					this.listView1.Invoke(new MethodInvoker(delegate
					{
						this.disconnect();
					}));
				}
				else
				{
					this.AnalyData(@string);
					Array.Resize<byte>(ref this._buffer, this._clientSocket.ReceiveBufferSize);
					this._clientSocket.BeginReceive(this._buffer, 0, this._buffer.Length, SocketFlags.None, new AsyncCallback(this.ReceiveCallBack), null);
				}
			}
			catch (SocketException)
			{
				this.listView1.Invoke(new MethodInvoker(delegate
				{
					this.disconnect();
				}));
			}
			catch (Exception var_3_BF)
			{
			}
		}

		// Token: 0x0600008F RID: 143 RVA: 0x0000672C File Offset: 0x0000492C
		private void Send(byte[] buffer)
		{
			try
			{
				this._clientSocket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(this.SendCallBack), null);
			}
			catch (SocketException)
			{
				this.listView1.Invoke(new MethodInvoker(delegate
				{
					this.disconnect();
				}));
			}
			catch (Exception var_0_41)
			{
			}
		}

		// Token: 0x06000090 RID: 144 RVA: 0x0000679C File Offset: 0x0000499C
		private void SendCallBack(IAsyncResult AR)
		{
			try
			{
				this._clientSocket.EndSend(AR);
			}
			catch (Exception var_0_12)
			{
			}
		}

		// Token: 0x06000091 RID: 145 RVA: 0x000021C4 File Offset: 0x000003C4
		private void button3_Click(object sender, EventArgs e)
		{
			this.optionform.resetFormData();
			this.optionform.ShowDialog();
		}

		// Token: 0x06000092 RID: 146 RVA: 0x000067D0 File Offset: 0x000049D0
		private void passlistview(bool add, object sender)
		{
			bool flag = this.listView1.SelectedItems.Count <= 0 | add;
			if (flag)
			{
				offerItem _item = (offerItem)sender;
				_item.appID = this.AppList[Convert.ToInt32(_item.appID)].appID;
				this.offerListItem.Add((offerItem)sender);
				offerItem offerItem = (offerItem)sender;
				offerItem.appName = (from z in this.AppList
				where z.appID == _item.appID
				select z).First<appDetail>().appName;
				ListViewItem listViewItem = new ListViewItem(new string[]
				{
					offerItem.offerName,
					offerItem.offerURL,
					offerItem.appName,
					offerItem.timeSleep.ToString(),
					offerItem.useScript.ToString()
				});
				listViewItem.Checked = offerItem.offerEnable;
				this.listView1.Items.Add(listViewItem);
			}
			else
			{
				int index = this.listView1.Items.IndexOf(this.listView1.SelectedItems[0]);
				offerItem offerItem2 = (offerItem)sender;
				this.offerListItem.ElementAt(index).appID = this.AppList[Convert.ToInt32(offerItem2.appID)].appID;
				this.offerListItem.ElementAt(index).appName = this.AppList[Convert.ToInt32(offerItem2.appID)].appName;
				this.offerListItem.ElementAt(index).offerEnable = offerItem2.offerEnable;
				this.offerListItem.ElementAt(index).offerName = offerItem2.offerName;
				this.offerListItem.ElementAt(index).offerURL = offerItem2.offerURL;
				this.offerListItem.ElementAt(index).script = offerItem2.script;
				this.offerListItem.ElementAt(index).timeSleep = offerItem2.timeSleep;
				this.offerListItem.ElementAt(index).useScript = offerItem2.useScript;
				this.offerListItem.ElementAt(index).timeSleepBefore = offerItem2.timeSleepBefore;
				this.offerListItem.ElementAt(index).timeSleepBeforeRandom = offerItem2.timeSleepBeforeRandom;
				this.offerListItem.ElementAt(index).range1 = offerItem2.range1;
				this.offerListItem.ElementAt(index).range2 = offerItem2.range2;
				this.offerListItem.ElementAt(index).referer = offerItem2.referer;
				ListViewItem listViewItem2 = this.listView1.SelectedItems[0];
				listViewItem2.Text = offerItem2.offerName;
				listViewItem2.Checked = offerItem2.offerEnable;
				listViewItem2.SubItems[1].Text = offerItem2.offerURL;
				listViewItem2.SubItems[2].Text = offerItem2.appName;
				listViewItem2.SubItems[3].Text = offerItem2.timeSleep.ToString();
				listViewItem2.SubItems[4].Text = offerItem2.useScript.ToString();
			}
			this.saveofferlist();
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00006B48 File Offset: 0x00004D48
		private void disconnect()
		{
			this.dataleft = "";
			this.Text = "AutoLead for iOS";
			this.settingtime.Stop();
			this.listView7.Items.Clear();
			this.listView6.Items.Clear();
			this.listView7.Items.Add(new ListViewItem("All Script"));
			this.listscript.Clear();
			this._disable();
			this.rrsdisableall();
			this.disableAll();
			foreach (ListViewItem listViewItem in this.listView1.Items)
			{
				listViewItem.SubItems[0].ResetStyle();
				listViewItem.SubItems[1].ResetStyle();
				listViewItem.SubItems[2].ResetStyle();
				listViewItem.SubItems[3].ResetStyle();
				listViewItem.SubItems[4].ResetStyle();
				this.listView1.Refresh();
			}
			this.label12.Text = "Date Expired:";
			this.button7.Text = "START";
			this.button19.Enabled = false;
			this.button19.Refresh();
			this.button19.Text = "START";
			this.button27.Enabled = false;
			this.button29.Enabled = false;
			this.button7.Enabled = false;
			this.button7.Refresh();
			this.safariX.Enabled = false;
			this.safariY.Enabled = false;
			bool flag = this.oThread != null;
			if (flag)
			{
				bool flag2 = this.oThread.ThreadState != System.Threading.ThreadState.Unstarted;
				if (flag2)
				{
					bool flag3 = this.oThread.ThreadState == System.Threading.ThreadState.Suspended;
					if (flag3)
					{
						this.oThread.Resume();
						Thread.Sleep(100);
					}
					try
					{
						this.oThread.Abort();
					}
					catch (Exception)
					{
					}
				}
			}
			bool flag4 = this.bkThread != null;
			if (flag4)
			{
				bool flag5 = this.bkThread.ThreadState != System.Threading.ThreadState.Unstarted;
				if (flag5)
				{
					bool flag6 = this.bkThread.ThreadState == System.Threading.ThreadState.Suspended;
					if (flag6)
					{
						this.bkThread.Resume();
						Thread.Sleep(100);
					}
					try
					{
						this.bkThread.Abort();
					}
					catch (Exception)
					{
					}
				}
			}
			this.optionform.disableButton3();
			this.label1.Text = "Disconnected to iDevice";
			this.DeviceIpControl.Enabled = true;
			this.button2.Text = "Connect";
			this.labelSerial.Text = "Serial:";
			this.button7.Enabled = false;
			this.Reset.Enabled = false;
			this.isconnected = false;
			this.getListApp("");
			try
			{
				this._clientSocket.Shutdown(SocketShutdown.Both);
				this._clientSocket.Close();
			}
			catch (Exception)
			{
			}
			bool @checked = this.autoreconnect.Checked;
			if (@checked)
			{
				Thread thread = new Thread(new ThreadStart(this.reconnect));
				thread.Start();
			}
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00006EE8 File Offset: 0x000050E8
		private void reconnect()
		{
			int i;
			int j;
			for (i = 0; i < 20; i = j + 1)
			{
				this.label1.Invoke(new MethodInvoker(delegate
				{
					this.label1.Text = "Auto-reconnect in " + (20 - i - 1).ToString() + " seconds";
					this.label1.Refresh();
				}));
				Thread.Sleep(1000);
				j = i;
			}
			this.button2.Invoke(new MethodInvoker(delegate
			{
				bool flag = this.button2.Text == "Connect";
				if (flag)
				{
					this.button2_Click(null, null);
				}
			}));
		}

		// Token: 0x06000095 RID: 149 RVA: 0x000021DF File Offset: 0x000003DF
		private void button1_Click(object sender, EventArgs e)
		{
			this.savedata();
			base.Close();
		}

		// Token: 0x06000096 RID: 150 RVA: 0x000021A5 File Offset: 0x000003A5
		private void savedata()
		{
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00006F68 File Offset: 0x00005168
		private void button4_Click(object sender, EventArgs e)
		{
			bool flag = this.listView1.SelectedItems.Count > 0;
			if (flag)
			{
				int index = this.listView1.Items.IndexOf(this.listView1.SelectedItems[0]);
				offerItem offerItem = this.offerListItem.ElementAt(index);
				this.optionform.setFormData(offerItem.offerEnable, offerItem.offerName, offerItem.offerURL, offerItem.appName, offerItem.timeSleepBefore, offerItem.timeSleepBeforeRandom, offerItem.range1, offerItem.range2, offerItem.timeSleep, offerItem.useScript, offerItem.script, offerItem.referer);
				this.optionform.ShowDialog();
			}
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00007024 File Offset: 0x00005224
		private void button5_Click(object sender, EventArgs e)
		{
			bool flag = this.listView1.SelectedItems.Count > 0;
			if (flag)
			{
				int index = this.listView1.Items.IndexOf(this.listView1.SelectedItems[0]);
				this.offerListItem.RemoveAt(index);
				this.listView1.Items[index].Remove();
			}
		}

		// Token: 0x06000099 RID: 153 RVA: 0x000021F0 File Offset: 0x000003F0
		private void button6_Click(object sender, EventArgs e)
		{
			this.offerListItem.Clear();
			this.listView1.Items.Clear();
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00007094 File Offset: 0x00005294
		private void threadcontinuerrs()
		{
			string txt = "";
			this.button15.Invoke(new MethodInvoker(delegate
			{
				txt = this.button15.Text;
			}));
			while (txt == "Getting...")
			{
				Thread.Sleep(500);
				this.button15.Invoke(new MethodInvoker(delegate
				{
					txt = this.button15.Text;
				}));
			}
			Thread.Sleep(5000);
			this.button15.Invoke(new MethodInvoker(delegate
			{
				this.button19_Click(null, null);
			}));
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00007130 File Offset: 0x00005330
		private void setInfo(string text)
		{
			string[] array = text.Split(new string[]
			{
				";"
			}, StringSplitOptions.None);
			bool flag = array.Count<string>() != 5;
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string text2 = array2[i];
				string[] array3 = text2.Split(new string[]
				{
					":"
				}, StringSplitOptions.None);
				string a = array3[0];
				if (!(a == "Model"))
				{
					if (!(a == "Name"))
					{
						if (!(a == "Version"))
						{
							if (!(a == "AutoVersion"))
							{
								if (a == "Serial")
								{
									this.Text = this.DeviceIpControl.Text.Split(new string[]
									{
										"."
									}, StringSplitOptions.None)[3];
									this.labelSerial.Text = "Serial:" + array3[1];
									this.deviceseri.Text = array3[1];
									this.DeviceInfo.SerialNumber = array3[1];
									Encryptor encryptor = new Encryptor();
									string requestUriString = this.serverurl + encryptor.Encrypt(array3[1], this.privatekey);
									HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
									httpWebRequest.UserAgent = "autoleadios";
									try
									{
										Stream responseStream = httpWebRequest.GetResponse().GetResponseStream();
										StreamReader streamReader = new StreamReader(responseStream);
										string text3 = streamReader.ReadToEnd();
										Decryptor decryptor = new Decryptor();
										string text4 = "9999";
										bool flag2 = text4 == "Unregistered";
										if (flag2)
										{
											this.label12.Text = "Date Expired:Unregistered";
										}
										else
										{
											bool flag3 = text4 == "Expired";
											if (flag3)
											{
												this.label12.Text = "Date Expired:Hết Hạn";
											}
											else
											{
												this.cmd.getAllProtectData();
												TimeSpan t = TimeSpan.Parse(text4);
												DateTime dateTime = DateTime.Now + t;
												this.label12.Text = "Date Expired:" + dateTime.ToShortDateString();
												this._enable();
												this.enableAll();
												this.rssenableall();
												this.loadsetting();
												bool @checked = this.autoreconnect.Checked;
												if (@checked)
												{
													bool flag4 = this.runningstt == 1;
													if (flag4)
													{
														this.button7_Click(null, null);
													}
													bool flag5 = this.runningstt == 2;
													if (flag5)
													{
														Thread thread = new Thread(new ThreadStart(this.threadcontinuerrs));
														thread.Start();
													}
												}
												string hostName = Dns.GetHostName();
												IPHostEntry hostByName = Dns.GetHostByName(hostName);
												IPAddress[] addressList = hostByName.AddressList;
												for (int j = 0; j < addressList.Length; j++)
												{
													IPAddress iPAddress = addressList[j];
													string[] array4 = iPAddress.ToString().Split(new string[]
													{
														"."
													}, StringSplitOptions.None);
													string[] array5 = this.DeviceIpControl.Text.Split(new string[]
													{
														"."
													}, StringSplitOptions.None);
													bool flag6 = array4[0] == array5[0] && array4[1] == array5[1] && array4[2] == array5[2];
													if (flag6)
													{
														this.ipAddressControl1.IPAddress = iPAddress;
														break;
													}
												}
												bool flag7 = !Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber);
												if (flag7)
												{
													Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber);
												}
												bool flag8 = !Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting");
												if (flag8)
												{
													Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting");
												}
												bool flag9 = File.Exists(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting\\changes.dat");
												if (flag9)
												{
													string text5 = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting\\changes.dat");
													try
													{
														string[] array6 = text5.Split(new string[]
														{
															"|"
														}, StringSplitOptions.None);
														this.changes = Convert.ToInt32(array6[0]);
														this.c_listoff = Convert.ToInt32(array6[1]);
														this.c_othersetting = Convert.ToInt32(array6[2]);
														this.c_ssh = Convert.ToInt32(array6[3]);
														this.c_vip = Convert.ToInt32(array6[4]);
														this.c_startall = Convert.ToInt32(array6[5]);
														this.c_stopall = Convert.ToInt32(array6[6]);
														this.c_resetall = Convert.ToInt32(array6[7]);
													}
													catch (Exception ex)
													{
														Exception ex4;
														MessageBox.Show(ex4.Message);
													}
												}
												else
												{
													string contents = string.Concat(new string[]
													{
														this.changes.ToString(),
														"|",
														this.c_listoff.ToString(),
														"|",
														this.c_othersetting.ToString(),
														"|",
														this.c_ssh.ToString(),
														"|",
														this.c_vip.ToString(),
														"|",
														this.c_startall.ToString(),
														"|",
														this.c_stopall.ToString(),
														"|",
														this.c_resetall.ToString()
													});
													File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting\\changes.dat", contents);
												}
												bool flag10 = File.Exists(this.documentfolder + "changes.dat");
												if (flag10)
												{
													string text6 = File.ReadAllText(this.documentfolder + "changes.dat");
													try
													{
														string[] array7 = text6.Split(new string[]
														{
															"|"
														}, StringSplitOptions.None);
														this.changeslocal = Convert.ToInt32(array7[0]);
														this.c_listofflocal = Convert.ToInt32(array7[1]);
														this.c_othersettinglocal = Convert.ToInt32(array7[2]);
														this.c_sshlocal = Convert.ToInt32(array7[3]);
														this.c_viplocal = Convert.ToInt32(array7[4]);
														this.c_startalllocal = Convert.ToInt32(array7[5]);
														this.c_stopalllocal = Convert.ToInt32(array7[6]);
														this.c_resetalllocal = Convert.ToInt32(array7[7]);
													}
													catch (Exception ex2)
													{
														MessageBox.Show(ex2.Message);
													}
												}
												else
												{
													string contents2 = string.Concat(new string[]
													{
														this.changeslocal.ToString(),
														"|",
														this.c_listofflocal.ToString(),
														"|",
														this.c_othersettinglocal.ToString(),
														"|",
														this.c_sshlocal.ToString(),
														"|",
														this.c_viplocal.ToString(),
														"|",
														this.c_startalllocal.ToString(),
														"|",
														this.c_stopalllocal.ToString(),
														"|",
														this.c_resetalllocal.ToString()
													});
													File.WriteAllText(this.documentfolder + "changes.dat", contents2);
												}
												bool flag11 = !Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "SSHFile");
												if (flag11)
												{
													Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "SSHFile");
												}
												bool flag12 = File.Exists(AppDomain.CurrentDomain.BaseDirectory + "SSHFile\\changes.dat");
												if (flag12)
												{
													this.changesssh = Convert.ToInt32(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "SSHFile\\changes.dat"));
												}
												else
												{
													string contents3 = this.changesssh.ToString();
													File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "SSHFile\\changes.dat", contents3);
												}
												this.settingtime.Interval = 1000;
												this.settingtime.Tick += delegate(object o, EventArgs ex)
												{
													string text7 = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting\\changes.dat");
													try
													{
														string[] array8 = text7.Split(new string[]
														{
															"|"
														}, StringSplitOptions.None);
														int num = Convert.ToInt32(array8[0]);
														int num2 = Convert.ToInt32(array8[1]);
														int num3 = Convert.ToInt32(array8[2]);
														int num4 = Convert.ToInt32(array8[3]);
														int num5 = Convert.ToInt32(array8[4]);
														int num6 = Convert.ToInt32(array8[5]);
														int num7 = Convert.ToInt32(array8[6]);
														int num8 = Convert.ToInt32(array8[7]);
														bool flag14 = this.changes != num;
														if (flag14)
														{
															bool flag15 = this.c_listoff != num2;
															if (flag15)
															{
																this.button43_Click(null, null);
															}
															bool flag16 = this.c_othersetting != num3;
															if (flag16)
															{
																this.button46_Click(null, null);
															}
															bool flag17 = this.c_ssh != num4;
															if (flag17)
															{
																this.button44_Click(null, null);
															}
															bool flag18 = this.c_vip != num5;
															if (flag18)
															{
																this.button45_Click(null, null);
															}
															bool flag19 = this.c_startall != num6;
															if (flag19)
															{
																bool flag20 = this.button7.Text != "STOP";
																if (flag20)
																{
																	this.button7_Click(null, null);
																}
															}
															bool flag21 = this.c_stopall != num7;
															if (flag21)
															{
																bool flag22 = this.button7.Text == "STOP";
																if (flag22)
																{
																	this.button7_Click(null, null);
																}
															}
															bool flag23 = this.c_resetall != num8;
															if (flag23)
															{
																bool flag24 = this.button7.Text == "STOP";
																if (flag24)
																{
																	this.button7_Click(null, null);
																	this.Reset_Click(null, null);
																}
																else
																{
																	bool flag25 = this.button7.Text == "RESUME";
																	if (flag25)
																	{
																		this.Reset_Click(null, null);
																	}
																}
															}
															this.changes = num;
															this.c_listoff = num2;
															this.c_othersetting = num3;
															this.c_ssh = num4;
															this.c_vip = num5;
															this.c_startall = num6;
															this.c_stopall = num7;
															this.c_resetall = num8;
														}
													}
													catch (Exception)
													{
													}
													text7 = File.ReadAllText(this.documentfolder + "changes.dat");
													try
													{
														string[] array9 = text7.Split(new string[]
														{
															"|"
														}, StringSplitOptions.None);
														int num9 = Convert.ToInt32(array9[0]);
														int num10 = Convert.ToInt32(array9[1]);
														int num11 = Convert.ToInt32(array9[2]);
														int num12 = Convert.ToInt32(array9[3]);
														int num13 = Convert.ToInt32(array9[4]);
														int num14 = Convert.ToInt32(array9[5]);
														int num15 = Convert.ToInt32(array9[6]);
														int num16 = Convert.ToInt32(array9[7]);
														bool flag26 = this.changeslocal != num9;
														if (flag26)
														{
															bool flag27 = this.c_listofflocal != num10;
															if (flag27)
															{
																this.button43_Click(null, null);
															}
															bool flag28 = this.c_sshlocal != num12;
															if (flag28)
															{
																this.button44_Click(null, null);
															}
															bool flag29 = this.c_viplocal != num13;
															if (flag29)
															{
																this.button45_Click(null, null);
															}
															bool flag30 = this.c_othersettinglocal != num11;
															if (flag30)
															{
																this.button46_Click(null, null);
															}
															bool flag31 = this.c_startalllocal != num14;
															if (flag31)
															{
																bool flag32 = this.button7.Text != "STOP";
																if (flag32)
																{
																	this.button7_Click(null, null);
																}
															}
															bool flag33 = this.c_stopalllocal != num15;
															if (flag33)
															{
																bool flag34 = this.button7.Text == "STOP";
																if (flag34)
																{
																	this.button7_Click(null, null);
																}
															}
															bool flag35 = num16 != this.c_resetalllocal;
															if (flag35)
															{
																bool flag36 = this.button7.Text == "STOP";
																if (flag36)
																{
																	this.button7_Click(null, null);
																	this.Reset_Click(null, null);
																}
																else
																{
																	bool flag37 = this.button7.Text == "RESUME";
																	if (flag37)
																	{
																		this.Reset_Click(null, null);
																	}
																}
															}
															this.changeslocal = num9;
															this.c_listofflocal = num10;
															this.c_othersettinglocal = num11;
															this.c_sshlocal = num12;
															this.c_viplocal = num13;
															this.c_startalllocal = num14;
															this.c_stopalllocal = num15;
															this.c_resetalllocal = num16;
														}
													}
													catch (Exception)
													{
													}
													int num17 = Convert.ToInt32(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "SSHFile\\changes.dat"));
													bool flag38 = num17 != this.changesssh;
													if (flag38)
													{
														string text8;
														while (true)
														{
															List<string> list = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "SSHFile").ToList<string>();
															bool flag39 = list.Count > 1;
															if (flag39)
															{
																text8 = "";
																try
																{
																	IEnumerable<string> arg_4FA_0 = list;
																	Func<string, bool> arg_4FA_1;
																	if ((arg_4FA_1 = Form1.<>c.<>9__113_1) == null)
																	{
																		arg_4FA_1 = (Form1.<>c.<>9__113_1 = new Func<string, bool>(Form1.<>c.<>9.<setInfo>b__113_1));
																	}
																	text8 = File.ReadAllText(arg_4FA_0.FirstOrDefault(arg_4FA_1));
																	IEnumerable<string> arg_527_0 = list;
																	Func<string, bool> arg_527_1;
																	if ((arg_527_1 = Form1.<>c.<>9__113_2) == null)
																	{
																		arg_527_1 = (Form1.<>c.<>9__113_2 = new Func<string, bool>(Form1.<>c.<>9.<setInfo>b__113_2));
																	}
																	File.Delete(arg_527_0.FirstOrDefault(arg_527_1));
																}
																catch (Exception)
																{
																	continue;
																}
																break;
															}
															goto IL_565;
														}
														this.importssh(text8);
														this.savessh();
														this.ssh_uncheck.Invoke(new MethodInvoker(delegate
														{
															Control arg_43_0 = this.ssh_uncheck;
															string arg_3E_0 = "Uncheck:";
															IEnumerable<ssh> arg_31_0 = this.listssh;
															Func<ssh, bool> arg_31_1;
															if ((arg_31_1 = Form1.<>c.<>9__113_4) == null)
															{
																arg_31_1 = (Form1.<>c.<>9__113_4 = new Func<ssh, bool>(Form1.<>c.<>9.<setInfo>b__113_4));
															}
															arg_43_0.Text = arg_3E_0 + arg_31_0.Count(arg_31_1).ToString();
															Control arg_8B_0 = this.ssh_used;
															string arg_86_0 = "Used:";
															IEnumerable<ssh> arg_79_0 = this.listssh;
															Func<ssh, bool> arg_79_1;
															if ((arg_79_1 = Form1.<>c.<>9__113_5) == null)
															{
																arg_79_1 = (Form1.<>c.<>9__113_5 = new Func<ssh, bool>(Form1.<>c.<>9.<setInfo>b__113_5));
															}
															arg_8B_0.Text = arg_86_0 + arg_79_0.Count(arg_79_1).ToString();
															Control arg_D3_0 = this.ssh_live;
															string arg_CE_0 = "Live:";
															IEnumerable<ssh> arg_C1_0 = this.listssh;
															Func<ssh, bool> arg_C1_1;
															if ((arg_C1_1 = Form1.<>c.<>9__113_6) == null)
															{
																arg_C1_1 = (Form1.<>c.<>9__113_6 = new Func<ssh, bool>(Form1.<>c.<>9.<setInfo>b__113_6));
															}
															arg_D3_0.Text = arg_CE_0 + arg_C1_0.Count(arg_C1_1).ToString();
															Control arg_11B_0 = this.ss_dead;
															string arg_116_0 = "Dead:";
															IEnumerable<ssh> arg_109_0 = this.listssh;
															Func<ssh, bool> arg_109_1;
															if ((arg_109_1 = Form1.<>c.<>9__113_7) == null)
															{
																arg_109_1 = (Form1.<>c.<>9__113_7 = new Func<ssh, bool>(Form1.<>c.<>9.<setInfo>b__113_7));
															}
															arg_11B_0.Text = arg_116_0 + arg_109_0.Count(arg_109_1).ToString();
														}));
														IL_565:
														this.changesssh = num17;
													}
												};
												this.settingtime.Start();
											}
										}
									}
									catch (Exception ex3)
									{
										MessageBox.Show(ex3.Message);
										this.button2_Click(null, null);
									}
								}
							}
							else
							{
								this.l_autover.Text = "AutoLead Version:" + array3[1];
								bool flag13 = this.clientver != array3[1];
								if (flag13)
								{
									Label expr_15A = this.l_autover;
									expr_15A.Text = expr_15A.Text + " (Vui lòng vào cydia update lên phiên bản " + this.clientver + ")";
								}
							}
						}
						else
						{
							this.iOSversion = (int)Convert.ToInt16(array3[1].Substring(0, 1));
							this.safariY.Enabled = true;
							this.safariX.Enabled = true;
							this.DeviceInfo.DeviceOSVersion = array3[1];
						}
					}
					else
					{
						this.DeviceInfo.DeviceName = array3[1];
					}
				}
				else
				{
					this.DeviceInfo.DeviceModel = array3[1];
				}
			}
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00007AC8 File Offset: 0x00005CC8
		private void _enable()
		{
			this.button27.Enabled = true;
			this.button29.Enabled = true;
			this.proxytool.Enabled = true;
			this.comboBox5.Enabled = true;
			this.ipAddressControl1.Enabled = true;
			this.numericUpDown1.Enabled = true;
			this.button20.Enabled = true;
			this.button9.Enabled = true;
			this.button11.Enabled = true;
			this.button30.Enabled = true;
			this.button12.Enabled = true;
			this.button10.Enabled = true;
			this.button13.Enabled = true;
			this.wipecombo.Enabled = true;
			this.button18.Enabled = true;
			this.button28.Enabled = true;
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00007BA8 File Offset: 0x00005DA8
		private void _disable()
		{
			this.button29.Enabled = false;
			this.button28.Enabled = false;
			this.button27.Enabled = false;
			this.proxytool.Enabled = false;
			this.comboBox5.Enabled = false;
			this.ipAddressControl1.Enabled = false;
			this.numericUpDown1.Enabled = false;
			this.button20.Enabled = false;
			this.button9.Enabled = false;
			this.button30.Enabled = false;
			this.button11.Enabled = false;
			this.button12.Enabled = false;
			this.button10.Enabled = false;
			this.button13.Enabled = false;
			this.wipecombo.Enabled = false;
			this.button18.Enabled = false;
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00007C88 File Offset: 0x00005E88
		private void getListApp(string text)
		{
			this.AppList.Clear();
			this.AppList1.Clear();
			this.wipecombo.Items.Clear();
			string[] array = text.Split(new string[]
			{
				";"
			}, StringSplitOptions.None);
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string text2 = array2[i];
				string[] array3 = text2.Split(new string[]
				{
					"|"
				}, StringSplitOptions.None);
				bool flag = array3.Count<string>() > 1;
				if (flag)
				{
					appDetail appDetail = new appDetail();
					appDetail.appID = array3[0];
					appDetail.appName = array3[1];
					this.AppList.Add(appDetail);
					appDetail.appName = array3[1];
					this.AppList1.Add(appDetail);
					this.wipecombo.Items.Add(appDetail.appName);
				}
			}
			IEnumerable<appDetail> arg_10B_0 = this.AppList;
			Func<appDetail, string> arg_10B_1;
			if ((arg_10B_1 = Form1.<>c.<>9__116_0) == null)
			{
				arg_10B_1 = (Form1.<>c.<>9__116_0 = new Func<appDetail, string>(Form1.<>c.<>9.<getListApp>b__116_0));
			}
			this.AppList = arg_10B_0.OrderBy(arg_10B_1).ToList<appDetail>();
			IEnumerable<appDetail> arg_140_0 = this.AppList1;
			Func<appDetail, string> arg_140_1;
			if ((arg_140_1 = Form1.<>c.<>9__116_1) == null)
			{
				arg_140_1 = (Form1.<>c.<>9__116_1 = new Func<appDetail, string>(Form1.<>c.<>9.<getListApp>b__116_1));
			}
			this.AppList1 = arg_140_0.OrderBy(arg_140_1).ToList<appDetail>();
			bool flag2 = this.AppList.Count > 0 && this.wipecombo.Text == "";
			if (flag2)
			{
				this.wipecombo.SelectedIndex = 0;
			}
			this.button28.Enabled = true;
			this.optionform.setComboBoxItem(this.AppList);
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00007E40 File Offset: 0x00006040
		private void getListBackUp(string text)
		{
			this._sshssh = true;
			string path = AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\checkssh.dat";
			List<string> source = new List<string>();
			bool flag = File.Exists(path);
			if (flag)
			{
				source = File.ReadAllLines(path).ToList<string>();
			}
			string[] array = text.Split(new string[]
			{
				"|"
			}, StringSplitOptions.None);
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string text2 = array2[i];
				string[] array3 = text2.Split(new string[]
				{
					"="
				}, StringSplitOptions.None);
				bool flag2 = array3.Count<string>() > 1;
				if (flag2)
				{
					backup bkup = new backup();
					bkup.filename = array3[0];
					string[] array4 = array3[0].Split(new string[]
					{
						"_"
					}, StringSplitOptions.None);
					bkup.timecreate = new DateTime(Convert.ToInt32(array4[0]), Convert.ToInt32(array4[1]), Convert.ToInt32(array4[2]), Convert.ToInt32(array4[3]), Convert.ToInt32(array4[4]), Convert.ToInt32(array4[5]));
					string[] array5 = array3[1].Split(new string[]
					{
						";"
					}, StringSplitOptions.None);
					List<string> list = new List<string>();
					string[] array6 = array5;
					for (int j = 0; j < array6.Length; j++)
					{
						string text3 = array6[j];
						bool flag3 = text3 != "";
						if (flag3)
						{
							list.Add(text3);
						}
					}
					bkup.appList = list;
					bkup.comment = "";
					bool flag4 = array3.Count<string>() > 4;
					if (flag4)
					{
						string[] array7 = array3[2].Split(new string[]
						{
							"[]"
						}, StringSplitOptions.None);
						bkup.country = "";
						try
						{
							bkup.comment = array7[0];
							bkup.country = array7[1];
						}
						catch (Exception)
						{
						}
						bool flag5 = array3[3] == "";
						if (flag5)
						{
							bkup.timemod = bkup.timecreate;
						}
						else
						{
							bkup.timemod = DateTime.Parse(array3[3].Replace("CH", "PM").Replace("SA", "AM"), this.usformat);
						}
						bool flag6 = array3[4] == "";
						if (flag6)
						{
							bkup.runtime = 0;
						}
						else
						{
							bkup.runtime = Convert.ToInt32(array3[4]);
						}
					}
					ListViewItem listViewItem = new ListViewItem(new string[]
					{
						"",
						bkup.timecreate.ToString("MM/dd/yyyy HH:mm:ss"),
						bkup.timemod.ToString("MM/dd/yyyy HH:mm:ss"),
						bkup.runtime.ToString(),
						array3[1],
						bkup.comment,
						bkup.country,
						bkup.filename
					});
					bool flag7 = source.FirstOrDefault((string x) => x == bkup.filename) != null;
					if (flag7)
					{
						listViewItem.Checked = true;
					}
					this.listView4.Items.Add(listViewItem);
					this.listbackup.Add(bkup);
					this.label34.Text = "Total RRS:" + (Convert.ToInt32(this.label34.Text.Replace("Total RRS:", "")) + 1).ToString();
				}
			}
			this._sshssh = false;
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x0000825C File Offset: 0x0000645C
		private void AnalyData(string text)
		{
			MethodInvoker method = delegate
			{
				string[] array = (this.dataleft + text).Split(new string[]
				{
					"{[|]}"
				}, StringSplitOptions.None);
				bool flag = text != "";
				if (flag)
				{
					for (int i = 0; i < array.Count<string>() - 1; i++)
					{
						string[] array2 = array[i].Split(new string[]
						{
							"="
						}, StringSplitOptions.None);
						bool flag2 = array[i] != "";
						if (flag2)
						{
							string text2 = array[i].Substring(array2[0].Length + 1);
							string text3 = array2[0];
							uint num = <PrivateImplementationDetails>.ComputeStringHash(text3);
							if (num <= 1619954845u)
							{
								if (num <= 902963599u)
								{
									if (num <= 53521840u)
									{
										if (num != 26364541u)
										{
											if (num == 53521840u)
											{
												if (text3 == "getapp-front")
												{
													bool flag3 = text2 == "" || text2 == "none";
													if (flag3)
													{
														this.cmdResult.frontAppByID = "none";
														this.cmdResult.frontAppByName = "none";
													}
													else
													{
														string[] array3 = text2.Split(new string[]
														{
															";"
														}, StringSplitOptions.None);
														this.cmdResult.frontAppByID = array3[1];
														this.cmdResult.frontAppByName = array3[0];
													}
												}
											}
										}
										else if (text3 == "setProxy")
										{
											bool flag4 = text2 == "done";
											if (flag4)
											{
												this.cmdResult.changeport = true;
											}
										}
									}
									else if (num != 850372319u)
									{
										if (num != 900455091u)
										{
											if (num == 902963599u)
											{
												if (text3 == "checkrestore")
												{
													this.cmdResult.restore = true;
												}
											}
										}
										else if (text3 == "getinfo")
										{
											this.label1.Text = "Connected";
											this.button7.Enabled = true;
											this.button19.Enabled = true;
											this.setInfo(text2);
										}
									}
									else if (text3 == "backup")
									{
										bool flag5 = text2 == "done";
										if (flag5)
										{
											this.cmdResult.backup = true;
										}
									}
								}
								else if (num <= 1181855383u)
								{
									if (num != 990164253u)
									{
										if (num != 1026424046u)
										{
											if (num == 1181855383u)
											{
												if (text3 == "version")
												{
													this.cmdResult.version = text2;
												}
											}
										}
										else if (text3 == "checkip")
										{
											bool flag6 = text2 == "true";
											if (flag6)
											{
												this.cmdResult.checkip = 1;
											}
											else
											{
												this.cmdResult.checkip = 2;
											}
										}
									}
									else if (text3 == "checkbackup")
									{
										this.cmdResult.backup = true;
									}
								}
								else if (num != 1214083380u)
								{
									if (num != 1313051034u)
									{
										if (num == 1619954845u)
										{
											if (text3 == "savecomment")
											{
												this.cmdResult.savecomment = true;
											}
										}
									}
									else if (text3 == "backupfull")
									{
										bool flag7 = text2 == "done";
										if (flag7)
										{
											this.cmdResult.backup = true;
										}
									}
								}
								else if (text3 == "Applist")
								{
									this.optionform.setButton3(false);
									this.getListApp(text2);
								}
							}
							else if (num <= 2516915897u)
							{
								if (num <= 2060525400u)
								{
									if (num != 1623334567u)
									{
										if (num != 1770621400u)
										{
											if (num == 2060525400u)
											{
												if (text3 == "sendtext")
												{
													this.cmdResult.sendtext = Convert.ToBoolean(text2);
												}
											}
										}
										else if (text3 == "touch")
										{
											this.cmdResult.touch = Convert.ToBoolean(text2);
										}
									}
									else if (text3 == "backuplist")
									{
										this.button15.Enabled = true;
										this.getListBackUp(text2);
										this.cmdResult.getbackup = true;
									}
								}
								else if (num != 2084656896u)
								{
									if (num != 2107770459u)
									{
										if (num == 2516915897u)
										{
											if (text3 == "swipe")
											{
												this.cmdResult.swipe = Convert.ToBoolean(text2);
											}
										}
									}
									else if (text3 == "proxy")
									{
										bool flag8 = text2 != "notfound";
										if (flag8)
										{
											string[] array4 = text2.Split(new string[]
											{
												":"
											}, StringSplitOptions.None);
											this.ipAddressControl1.Text = array4[0];
											this.numericUpDown1.Value = Convert.ToInt32(array4[1]);
											this.oriadd = this.ipAddressControl1.Text;
											this.oriport = (int)this.numericUpDown1.Value;
											this.ipAddressControl1.Refresh();
											this.numericUpDown1.Refresh();
											bool flag9 = array4.Count<string>() > 2;
											if (flag9)
											{
												bool flag10 = array4[2] == "enable";
												if (flag10)
												{
													this.button23.Text = "Disable Proxy";
													this.button23.BackColor = Color.Red;
												}
												else
												{
													this.button23.Text = "Enable Proxy";
												}
												this.button23.Refresh();
												bool flag11 = this.button23.Text.Contains("Enable");
												if (flag11)
												{
													this.button23_Click(null, null);
												}
											}
										}
									}
								}
								else if (text3 == "setsocks")
								{
									this.cmdResult.changeport = true;
								}
							}
							else if (num <= 3546203337u)
							{
								if (num != 2805759324u)
								{
									if (num != 3492411834u)
									{
										if (num == 3546203337u)
										{
											if (text3 == "open")
											{
												string a = text2;
												if (!(a == "true"))
												{
													if (!(a == "notfound"))
													{
														this.cmdResult.openApp = 3;
													}
													else
													{
														this.cmdResult.openApp = 2;
													}
												}
												else
												{
													this.cmdResult.openApp = 1;
												}
											}
										}
									}
									else if (text3 == "openurl")
									{
										this.cmdResult.openURL = Convert.ToBoolean(text2);
									}
								}
								else if (text3 == "checkwipe")
								{
									this.cmdResult.wipe = true;
								}
							}
							else if (num != 3704858577u)
							{
								if (num != 3880909333u)
								{
									if (num == 3881128326u)
									{
										if (text3 == "wipe")
										{
											bool flag12 = text2 == "done";
											if (flag12)
											{
												this.cmdResult.wipe = true;
											}
										}
									}
								}
								else if (text3 == "randomtouch")
								{
									this.cmdResult.touchrandom = true;
								}
							}
							else if (text3 == "restore")
							{
								this.cmdResult.restore = true;
							}
						}
					}
					this.dataleft = array[array.Count<string>() - 1];
				}
			};
			base.Invoke(method);
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00008294 File Offset: 0x00006494
		private void button7_Click(object sender, EventArgs e)
		{
			bool flag = this.button7.Text == "START" || this.button7.Text == "RESUME";
			if (flag)
			{
				this.runningstt = 1;
				bool flag2 = this.listView1.SelectedItems.Count > 0;
				if (flag2)
				{
					this.listView1.SelectedItems[0].Selected = false;
				}
				this.button19.Enabled = false;
				this.button19.Refresh();
				this.disableAll();
				bool flag3 = this.button7.Text == "START";
				if (flag3)
				{
					this.oThread = new Thread(new ThreadStart(this.autoLeadThread));
					this.oThread.Start();
				}
				else
				{
					this.cmd.randomtouchresume();
					bool flag4 = this.oThread == null || (this.oThread.ThreadState & System.Threading.ThreadState.Stopped) == System.Threading.ThreadState.Stopped;
					if (flag4)
					{
						this.oThread = new Thread(new ThreadStart(this.autoLeadThread));
					}
					bool flag5 = (this.oThread.ThreadState & System.Threading.ThreadState.Suspended) == System.Threading.ThreadState.Suspended;
					if (flag5)
					{
						this.oThread.Resume();
					}
					else
					{
						bool flag6 = (this.oThread.ThreadState & System.Threading.ThreadState.Unstarted) == System.Threading.ThreadState.Unstarted || (this.oThread.ThreadState & System.Threading.ThreadState.AbortRequested) == System.Threading.ThreadState.AbortRequested || (this.oThread.ThreadState & System.Threading.ThreadState.Aborted) == System.Threading.ThreadState.Aborted || (this.oThread.ThreadState & System.Threading.ThreadState.Stopped) == System.Threading.ThreadState.Stopped;
						if (flag6)
						{
							this.oThread = new Thread(new ThreadStart(this.autoLeadThread));
							this.oThread.Start();
						}
					}
				}
				this.button7.Text = "STOP";
				this.button7.Refresh();
			}
			else
			{
				this.runningstt = 0;
				try
				{
					this.oThread.Suspend();
				}
				catch (Exception)
				{
				}
				this.cmd.randomtouchpause();
				this.button7.Text = "RESUME";
				this.button7.Refresh();
				this.enableAll();
				this.button19.Enabled = true;
				this.button19.Refresh();
			}
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x000021A5 File Offset: 0x000003A5
		private void doscript(string marco)
		{
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00008500 File Offset: 0x00006700
		private void autoLeadThread()
		{
			while (true)
			{
				IL_01:
				while (true)
				{
					Form1.<>c__DisplayClass121_0 <>c__DisplayClass121_ = new Form1.<>c__DisplayClass121_0();
					<>c__DisplayClass121_.<>4__this = this;
					this.curip = "";
					IEnumerable<offerItem> arg_45_0 = this.offerListItem;
					Func<offerItem, bool> arg_45_1;
					if ((arg_45_1 = Form1.<>c.<>9__121_0) == null)
					{
						arg_45_1 = (Form1.<>c.<>9__121_0 = new Func<offerItem, bool>(Form1.<>c.<>9.<autoLeadThread>b__121_0));
					}
					bool flag = arg_45_0.FirstOrDefault(arg_45_1) == null;
					if (flag)
					{
						break;
					}
					<>c__DisplayClass121_.proxytype = "SSH";
					object arg;
					string text;
					while (true)
					{
						this.proxytool.Invoke(new MethodInvoker(delegate
						{
							<>c__DisplayClass121_.proxytype = <>c__DisplayClass121_.<>4__this.proxytool.Text;
						}));
						Thread.Sleep(10);
						<>c__DisplayClass121_.svip = false;
						base.Invoke(new MethodInvoker(delegate
						{
							<>c__DisplayClass121_.svip = <>c__DisplayClass121_.<>4__this.sameVip.Checked;
						}));
						bool flag2 = !<>c__DisplayClass121_.svip;
						if (flag2)
						{
							arg = new Vip72();
						}
						else
						{
							arg = new Vip72Chung();
						}
						bool flag3 = <>c__DisplayClass121_.proxytype == "SSH";
						if (flag3)
						{
							goto Block_3;
						}
						bool flag4 = <>c__DisplayClass121_.proxytype == "Vip72";
						if (!flag4)
						{
							goto IL_A27;
						}
						try
						{
							sshcommand.closebitvise((int)this.numericUpDown1.Value);
							bool flag5 = !this.bitproc.HasExited;
							if (flag5)
							{
								this.bitproc.Kill();
							}
						}
						catch (Exception)
						{
						}
						this.label1.Invoke(new MethodInvoker(delegate
						{
							this.label1.Text = "Đang đợi Để sử dụng Vip72...";
						}));
						if (Form1.<>o__121.<>p__1 == null)
						{
							Form1.<>o__121.<>p__1 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "waitiotherVIP72", null, typeof(Form1), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Form1.<>o__121.<>p__1.Target(Form1.<>o__121.<>p__1, arg);
						this.label1.Invoke(new MethodInvoker(delegate
						{
							this.label1.Text = "Getting Vip72 IP...";
						}));
						IEnumerable<vipaccount> arg_4F2_0 = this.listvipacc;
						Func<vipaccount, bool> arg_4F2_1;
						if ((arg_4F2_1 = Form1.<>c.<>9__121_23) == null)
						{
							arg_4F2_1 = (Form1.<>c.<>9__121_23 = new Func<vipaccount, bool>(Form1.<>c.<>9.<autoLeadThread>b__121_23));
						}
						this.vipacc = arg_4F2_0.FirstOrDefault(arg_4F2_1);
						bool flag6 = this.vipacc == null;
						if (flag6)
						{
							bool flag7 = this.listvipacc.Count == 0;
							if (flag7)
							{
								goto Block_17;
							}
							foreach (vipaccount current in this.listvipacc)
							{
								current.limited = false;
							}
						}
						else
						{
							int num = 0;
							this.listView3.Invoke(new MethodInvoker(delegate
							{
								this.listView3.Items[this.listvipacc.IndexOf(this.vipacc)].BackColor = Color.Yellow;
								this.listView3.Refresh();
							}));
							bool flag8;
							do
							{
								if (Form1.<>o__121.<>p__4 == null)
								{
									Form1.<>o__121.<>p__4 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Form1), new CSharpArgumentInfo[]
									{
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
									}));
								}
								Func<CallSite, object, bool> arg_72A_0 = Form1.<>o__121.<>p__4.Target;
								CallSite arg_72A_1 = Form1.<>o__121.<>p__4;
								if (Form1.<>o__121.<>p__3 == null)
								{
									Form1.<>o__121.<>p__3 = CallSite<Func<CallSite, object, object>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.Not, typeof(Form1), new CSharpArgumentInfo[]
									{
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
									}));
								}
								Func<CallSite, object, object> arg_725_0 = Form1.<>o__121.<>p__3.Target;
								CallSite arg_725_1 = Form1.<>o__121.<>p__3;
								if (Form1.<>o__121.<>p__2 == null)
								{
									Form1.<>o__121.<>p__2 = CallSite<Func<CallSite, object, string, string, int, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "vip72login", null, typeof(Form1), new CSharpArgumentInfo[]
									{
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
									}));
								}
								if (!arg_72A_0(arg_72A_1, arg_725_0(arg_725_1, Form1.<>o__121.<>p__2.Target(Form1.<>o__121.<>p__2, arg, this.vipacc.username, this.vipacc.password, (int)this.numericUpDown1.Value))))
								{
									goto Block_23;
								}
								num++;
								flag8 = (num > 0);
							}
							while (!flag8);
							this.vipacc.limited = true;
							this.listView3.Invoke(new MethodInvoker(delegate
							{
								this.listView3.Items[this.listvipacc.IndexOf(this.vipacc)].BackColor = Color.Red;
								this.listView3.Refresh();
							}));
							continue;
							Block_23:
							this.listView3.Invoke(new MethodInvoker(delegate
							{
								this.listView3.Items[this.listvipacc.IndexOf(this.vipacc)].BackColor = Color.Lime;
								this.listView3.Refresh();
							}));
							string a;
							string txt;
							while (true)
							{
								txt = "";
								this.label1.Invoke(new MethodInvoker(delegate
								{
									txt = <>c__DisplayClass121_.<>4__this.comboBox5.Text;
								}));
								if (Form1.<>o__121.<>p__6 == null)
								{
									Form1.<>o__121.<>p__6 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Form1), new CSharpArgumentInfo[]
									{
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
									}));
								}
								Func<CallSite, object, bool> arg_82F_0 = Form1.<>o__121.<>p__6.Target;
								CallSite arg_82F_1 = Form1.<>o__121.<>p__6;
								if (Form1.<>o__121.<>p__5 == null)
								{
									Form1.<>o__121.<>p__5 = CallSite<Func<CallSite, object, byte, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "getip", null, typeof(Form1), new CSharpArgumentInfo[]
									{
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
									}));
								}
								bool flag9 = arg_82F_0(arg_82F_1, Form1.<>o__121.<>p__5.Target(Form1.<>o__121.<>p__5, arg, this.listcountrycode.FirstOrDefault((countrycode x) => x.country == txt).code));
								if (!flag9)
								{
									goto IL_A21;
								}
								Control arg_863_0 = this.label1;
								MethodInvoker arg_863_1;
								if ((arg_863_1 = Form1.<>c.<>9__121_31) == null)
								{
									arg_863_1 = (Form1.<>c.<>9__121_31 = new MethodInvoker(Form1.<>c.<>9.<autoLeadThread>b__121_31));
								}
								arg_863_0.Invoke(arg_863_1);
								if (Form1.<>o__121.<>p__8 == null)
								{
									Form1.<>o__121.<>p__8 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(Form1)));
								}
								Func<CallSite, object, string> arg_90D_0 = Form1.<>o__121.<>p__8.Target;
								CallSite arg_90D_1 = Form1.<>o__121.<>p__8;
								if (Form1.<>o__121.<>p__7 == null)
								{
									Form1.<>o__121.<>p__7 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "clickip", null, typeof(Form1), new CSharpArgumentInfo[]
									{
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
									}));
								}
								text = arg_90D_0(arg_90D_1, Form1.<>o__121.<>p__7.Target(Form1.<>o__121.<>p__7, arg, (int)this.numericUpDown1.Value));
								a = text;
								if (a == "not running")
								{
									break;
								}
								if (!(a == "no IP"))
								{
									if (!(a == "dead"))
									{
										if (a == "limited")
										{
											goto IL_983;
										}
										if (!(a == "maximum"))
										{
											goto Block_34;
										}
										if (Form1.<>o__121.<>p__9 == null)
										{
											Form1.<>o__121.<>p__9 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "clearip", null, typeof(Form1), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										Form1.<>o__121.<>p__9.Target(Form1.<>o__121.<>p__9, arg);
									}
								}
							}
							continue;
							IL_983:
							this.listView3.Invoke(new MethodInvoker(delegate
							{
								this.listView3.Items[this.listvipacc.IndexOf(this.vipacc)].BackColor = Color.Red;
								this.listView3.Refresh();
							}));
							this.vipacc.limited = true;
							continue;
							Block_34:
							if (!(a == "timeout"))
							{
								goto Block_35;
							}
						}
					}
					IL_D63:
					bool flag10 = <>c__DisplayClass121_.proxytype != "Direct" && <>c__DisplayClass121_.proxytype != "SSHServer";
					if (flag10)
					{
					}
					this.cmd.close("all");
					Thread.Sleep(1000);
					this.cmd.sendtext("{HOME}");
					string text2 = "";
					foreach (offerItem current2 in this.offerListItem)
					{
						bool offerEnable = current2.offerEnable;
						if (offerEnable)
						{
							text2 += current2.appID;
							text2 += ";";
						}
					}
					this.cmdResult.wipe = false;
					<>c__DisplayClass121_.wipechoose = false;
					this.label1.Invoke(new MethodInvoker(delegate
					{
						<>c__DisplayClass121_.<>4__this.label1.Text = "Wiping Application data...";
						bool checked3 = <>c__DisplayClass121_.<>4__this.checkBox2.Checked;
						if (checked3)
						{
							<>c__DisplayClass121_.wipechoose = true;
						}
					}));
					this.cmd.faketype(this.getrandomdevice());
					bool @checked = this.fakeversion.Checked;
					if (@checked)
					{
						bool flag11 = this.checkBox14.Checked || this.checkBox15.Checked;
						if (flag11)
						{
							bool flag12 = this.checkBox14.Checked && this.checkBox15.Checked;
							string text3;
							if (flag12)
							{
								Random random = new Random();
								text3 = random.Next(8, 10).ToString();
							}
							else
							{
								bool checked2 = this.checkBox14.Checked;
								if (checked2)
								{
									text3 = "8";
								}
								else
								{
									text3 = "9";
								}
							}
							this.cmd.fakeversion(text3);
						}
					}
					this.cmd.randominfo();
					this.cmd.wipe(text2);
					bool wipechoose = <>c__DisplayClass121_.wipechoose;
					if (wipechoose)
					{
						foreach (offerItem current3 in this.offerListItem)
						{
							bool offerEnable2 = current3.offerEnable;
							if (offerEnable2)
							{
								this.cmd.uninstallapp(current3.appID);
							}
						}
					}
					this.button2.Invoke(new MethodInvoker(delegate
					{
						this.maxwait = (int)this.numericUpDown10.Value;
					}));
					DateTime now = DateTime.Now;
					while (!this.cmdResult.wipe)
					{
						Thread.Sleep(1000);
						bool flag13 = (DateTime.Now - now).TotalSeconds > (double)this.maxwait;
						if (flag13)
						{
							goto Block_52;
						}
						this.cmd.checkwipe();
					}
					this.button2.Invoke(new MethodInvoker(delegate
					{
						bool flag59 = !this.fakedevice.Checked;
						if (flag59)
						{
							this.cmd.changename("orig");
						}
						bool flag60 = this.fakedevice.Checked && this.checkBox11.Checked && File.Exists(this.fileofname.Text);
						if (flag60)
						{
							string[] array4 = File.ReadAllLines(this.fileofname.Text);
							Random random6 = new Random();
							this.cmd.changename(array4[random6.Next(0, array4.Count<string>())]);
						}
						bool checked3 = this.checkBox20.Checked;
						if (checked3)
						{
							this.fakeLocationByIP(this.curip);
						}
						bool checked4 = this.fakelang.Checked;
						if (checked4)
						{
							this.cmd.changelanguage(this.listlanguagecode.FirstOrDefault((languagecode x) => x.langname == this.comboBox1.Text).langcode);
						}
						bool checked5 = this.fakeregion.Checked;
						if (checked5)
						{
							this.cmd.changeregion(this.listcountrycodeiOS.FirstOrDefault((countrycodeiOS x) => x.countryname == this.comboBox2.Text).countrycode);
						}
						bool checked6 = this.checkBox5.Checked;
						if (checked6)
						{
							this.cmd.changetimezone(this.ltimezone.Text);
						}
						else
						{
							this.cmd.changetimezone("orig");
						}
						bool checked7 = this.checkBox13.Checked;
						if (checked7)
						{
							bool checked8 = this.checkBox9.Checked;
							if (checked8)
							{
								List<Carrier> list = (from x in this.carrierList
								where x.country == this.carrierBox.Text
								select x).ToList<Carrier>();
								Random random7 = new Random();
								Carrier carrier = list.ElementAt(random7.Next(0, list.Count));
								this.cmd.changecarrier(carrier.CarrierName, carrier.mobileCountryCode, carrier.mobileCarrierCode, carrier.ISOCountryCode.ToLower());
							}
							else
							{
								Random random8 = new Random();
								Carrier carrier2 = this.carrierList.ElementAt(random8.Next(0, this.carrierList.Count));
								this.cmd.changecarrier(carrier2.CarrierName, carrier2.mobileCountryCode, carrier2.mobileCarrierCode, carrier2.ISOCountryCode.ToLower());
							}
						}
						else
						{
							this.cmd.changecarrier("orig", "orig", "orig", "orig");
						}
						bool checked9 = this.checkBox19.Checked;
						if (checked9)
						{
							this.cmd.fakeGPS(true, (double)this.latitude.Value, (double)this.longtitude.Value);
						}
						else
						{
							this.cmd.fakeGPS(false);
						}
					}));
					using (List<offerItem>.Enumerator enumerator4 = this.offerListItem.GetEnumerator())
					{
						while (enumerator4.MoveNext())
						{
							Form1.<>c__DisplayClass121_7 <>c__DisplayClass121_3 = new Form1.<>c__DisplayClass121_7();
							<>c__DisplayClass121_3.CS$<>8__locals6 = <>c__DisplayClass121_;
							<>c__DisplayClass121_3.item = enumerator4.Current;
							Form1.<>c__DisplayClass121_6 <>c__DisplayClass121_4 = new Form1.<>c__DisplayClass121_6();
							<>c__DisplayClass121_4.CS$<>8__locals7 = <>c__DisplayClass121_3;
							<>c__DisplayClass121_4.rerunt = 0;
							int num2;
							Form1.<>c__DisplayClass121_8 <>c__DisplayClass121_5;
							DateTime now2;
							int i;
							while (true)
							{
								IL_107E:
								num2 = <>c__DisplayClass121_4.rerunt;
								<>c__DisplayClass121_4.rerunt = num2 + 1;
								this.label1.Invoke(new MethodInvoker(delegate
								{
									bool checked3 = <>c__DisplayClass121_4.CS$<>8__locals7.CS$<>8__locals6.<>4__this.checkBox4.Checked;
									if (checked3)
									{
										bool flag59 = <>c__DisplayClass121_4.rerunt > (int)<>c__DisplayClass121_4.CS$<>8__locals7.CS$<>8__locals6.<>4__this.numericUpDown5.Value;
										if (flag59)
										{
											<>c__DisplayClass121_4.CS$<>8__locals7.item.offerEnable = false;
											<>c__DisplayClass121_4.CS$<>8__locals7.CS$<>8__locals6.<>4__this.listView1.Items[<>c__DisplayClass121_4.CS$<>8__locals7.CS$<>8__locals6.<>4__this.offerListItem.IndexOf(<>c__DisplayClass121_4.CS$<>8__locals7.item)].Checked = false;
											<>c__DisplayClass121_4.CS$<>8__locals7.CS$<>8__locals6.<>4__this.listView1.Refresh();
										}
									}
								}));
								bool offerEnable3 = <>c__DisplayClass121_4.CS$<>8__locals7.item.offerEnable;
								if (offerEnable3)
								{
									<>c__DisplayClass121_5 = new Form1.<>c__DisplayClass121_8();
									<>c__DisplayClass121_5.CS$<>8__locals8 = <>c__DisplayClass121_4;
									<>c__DisplayClass121_5.index = this.offerListItem.IndexOf(<>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.item);
									this.label1.Invoke(new MethodInvoker(delegate
									{
										<>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>4__this.label1.Text = "Running :" + <>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>4__this.listView1.Items[<>c__DisplayClass121_5.index].Text;
										<>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>4__this.listView1.Items[<>c__DisplayClass121_5.index].UseItemStyleForSubItems = false;
										<>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>4__this.listView1.Items[<>c__DisplayClass121_5.index].SubItems[0].BackColor = Color.Lime;
										<>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>4__this.listView1.Items[<>c__DisplayClass121_5.index].SubItems[1].BackColor = Color.Yellow;
										<>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>4__this.listView1.Refresh();
									}));
									<>c__DisplayClass121_5.urlinfo = "";
									this.label1.Invoke(new MethodInvoker(delegate
									{
										<>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>4__this.label1.Text = "Opening Offer URL....";
										try
										{
											bool flag59 = <>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.proxytype == "Vip72";
											if (flag59)
											{
												<>c__DisplayClass121_5.urlinfo += "Vip72||";
												<>c__DisplayClass121_5.urlinfo = <>c__DisplayClass121_5.urlinfo + <>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>4__this.comboBox5.Text + "||";
												<>c__DisplayClass121_5.urlinfo = <>c__DisplayClass121_5.urlinfo + <>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>4__this.currentvipip + "||";
												<>c__DisplayClass121_5.urlinfo = <>c__DisplayClass121_5.urlinfo + <>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>4__this.vipacc.username + "||";
												<>c__DisplayClass121_5.urlinfo = <>c__DisplayClass121_5.urlinfo + <>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>4__this.vipacc.password + "||";
											}
											bool flag60 = <>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.proxytype == "SSH";
											if (flag60)
											{
												<>c__DisplayClass121_5.urlinfo += "SSH||";
												<>c__DisplayClass121_5.urlinfo = <>c__DisplayClass121_5.urlinfo + <>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>4__this.comboBox5.Text + "||";
												<>c__DisplayClass121_5.urlinfo = <>c__DisplayClass121_5.urlinfo + <>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>4__this._getssh.IP + "||";
												<>c__DisplayClass121_5.urlinfo = <>c__DisplayClass121_5.urlinfo + <>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>4__this._getssh.username + "||";
												<>c__DisplayClass121_5.urlinfo = <>c__DisplayClass121_5.urlinfo + <>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>4__this._getssh.password + "||";
											}
											bool flag61 = <>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.proxytype == "Direct";
											if (flag61)
											{
												<>c__DisplayClass121_5.urlinfo += "Direct||";
											}
										}
										catch (Exception)
										{
										}
									}));
									this.cmdResult.openURL = false;
									<>c__DisplayClass121_5.urlinfo = <>c__DisplayClass121_5.urlinfo + this.anaURL(<>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.item.offerURL) + "||";
									<>c__DisplayClass121_5.urlinfo += <>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.item.appID;
									string[] array = <>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.item.referer.Split(new string[]
									{
										"\r\n"
									}, StringSplitOptions.None);
									bool flag14 = array.Count<string>() > 0;
									if (flag14)
									{
										Random random2 = new Random();
										string uriString = array[random2.Next(0, array.Count<string>())];
										Uri uri;
										bool flag15 = Uri.TryCreate(uriString, UriKind.Absolute, out uri) && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
										bool flag16 = flag15;
										if (flag16)
										{
											this.cmd.setReferer(uri.GetComponents(UriComponents.SchemeAndServer, UriFormat.UriEscaped));
										}
										else
										{
											this.cmd.setReferer("");
										}
										this.cmd.openURL(this.anaURL(<>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.item.offerURL));
									}
									else
									{
										this.cmd.setReferer("");
									}
									now2 = DateTime.Now;
									DateTime now3 = DateTime.Now;
									while (!this.cmdResult.openURL)
									{
										bool flag17 = (DateTime.Now - now3).Seconds > 5;
										if (flag17)
										{
											this.cmd.openURL(this.anaURL(<>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.item.offerURL));
											now3 = DateTime.Now;
										}
										Thread.Sleep(100);
										bool flag18 = (DateTime.Now - now2).TotalSeconds > (double)this.maxwait1;
										if (flag18)
										{
											goto Block_93;
										}
									}
									this.listView1.Invoke(new MethodInvoker(delegate
									{
										<>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>4__this.listView1.Items[<>c__DisplayClass121_5.index].SubItems[1].BackColor = Color.Lime;
										<>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>4__this.listView1.Items[<>c__DisplayClass121_5.index].SubItems[2].BackColor = Color.Yellow;
										<>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>4__this.listView1.Refresh();
										<>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>4__this.maxwait1 = (int)<>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>4__this.numericUpDown4.Value;
									}));
									this.cmdResult.frontAppByID = "";
									this.cmd.getfront();
									now2 = DateTime.Now;
									while (this.cmdResult.frontAppByID == "" || this.cmdResult.frontAppByID == "com.apple.mobilesafari")
									{
										bool flag19 = this.safariX.Value != decimal.MinusOne;
										if (flag19)
										{
											this.cmd.touch((double)this.itunesX.Value, (double)this.itunesY.Value);
											Thread.Sleep(500);
											this.cmd.touch((double)this.safariX.Value, (double)this.safariY.Value);
										}
										bool flag20 = this.cmdResult.frontAppByID == <>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.item.appID;
										if (flag20)
										{
											break;
										}
										Thread.Sleep(500);
										bool flag21 = (DateTime.Now - now2).TotalSeconds > (double)this.maxwait1;
										if (flag21)
										{
											bool flag22 = this.cmdResult.frontAppByID == "";
											if (flag22)
											{
												goto Block_98;
											}
											bool flag23 = this.cmdResult.frontAppByID != "";
											if (flag23)
											{
												string text4;
												while (true)
												{
													Control arg_154A_0 = this.proxytool;
													MethodInvoker arg_154A_1;
													if ((arg_154A_1 = <>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>9__50) == null)
													{
														arg_154A_1 = (<>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>9__50 = new MethodInvoker(<>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<autoLeadThread>b__50));
													}
													arg_154A_0.Invoke(arg_154A_1);
													Thread.Sleep(10);
													MethodInvoker arg_15AA_1;
													if ((arg_15AA_1 = <>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>9__51) == null)
													{
														arg_15AA_1 = (<>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>9__51 = new MethodInvoker(<>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<autoLeadThread>b__51));
													}
													base.Invoke(arg_15AA_1);
													bool flag24 = !<>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.svip;
													if (flag24)
													{
														arg = new Vip72();
													}
													else
													{
														arg = new Vip72Chung();
													}
													bool flag25 = <>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.proxytype == "SSH";
													if (flag25)
													{
														goto Block_102;
													}
													bool flag26 = <>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.proxytype == "Vip72";
													if (!flag26)
													{
														goto IL_2197;
													}
													try
													{
														sshcommand.closebitvise((int)this.numericUpDown1.Value);
														bool flag27 = !this.bitproc.HasExited;
														if (flag27)
														{
															this.bitproc.Kill();
														}
													}
													catch (Exception)
													{
													}
													this.label1.Invoke(new MethodInvoker(delegate
													{
														this.label1.Text = "Đang đợi Để sử dụng Vip72...";
													}));
													if (Form1.<>o__121.<>p__12 == null)
													{
														Form1.<>o__121.<>p__12 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "waitiotherVIP72", null, typeof(Form1), new CSharpArgumentInfo[]
														{
															CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
														}));
													}
													Form1.<>o__121.<>p__12.Target(Form1.<>o__121.<>p__12, arg);
													this.label1.Invoke(new MethodInvoker(delegate
													{
														this.label1.Text = "Getting Vip72 IP....";
													}));
													IEnumerable<vipaccount> arg_1AF0_0 = this.listvipacc;
													Func<vipaccount, bool> arg_1AF0_1;
													if ((arg_1AF0_1 = Form1.<>c.<>9__121_73) == null)
													{
														arg_1AF0_1 = (Form1.<>c.<>9__121_73 = new Func<vipaccount, bool>(Form1.<>c.<>9.<autoLeadThread>b__121_73));
													}
													this.vipacc = arg_1AF0_0.FirstOrDefault(arg_1AF0_1);
													bool flag28 = this.vipacc == null;
													if (flag28)
													{
														goto Block_117;
													}
													this.listView3.Invoke(new MethodInvoker(delegate
													{
														this.listView3.Items[this.listvipacc.IndexOf(this.vipacc)].BackColor = Color.Yellow;
														this.listView3.Refresh();
													}));
													int num3 = 0;
													while (true)
													{
														if (Form1.<>o__121.<>p__15 == null)
														{
															Form1.<>o__121.<>p__15 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Form1), new CSharpArgumentInfo[]
															{
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
															}));
														}
														Func<CallSite, object, bool> arg_1E87_0 = Form1.<>o__121.<>p__15.Target;
														CallSite arg_1E87_1 = Form1.<>o__121.<>p__15;
														if (Form1.<>o__121.<>p__14 == null)
														{
															Form1.<>o__121.<>p__14 = CallSite<Func<CallSite, object, object>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.Not, typeof(Form1), new CSharpArgumentInfo[]
															{
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
															}));
														}
														Func<CallSite, object, object> arg_1E82_0 = Form1.<>o__121.<>p__14.Target;
														CallSite arg_1E82_1 = Form1.<>o__121.<>p__14;
														if (Form1.<>o__121.<>p__13 == null)
														{
															Form1.<>o__121.<>p__13 = CallSite<Func<CallSite, object, string, string, int, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "vip72login", null, typeof(Form1), new CSharpArgumentInfo[]
															{
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
															}));
														}
														if (!arg_1E87_0(arg_1E87_1, arg_1E82_0(arg_1E82_1, Form1.<>o__121.<>p__13.Target(Form1.<>o__121.<>p__13, arg, this.vipacc.username, this.vipacc.password, (int)this.numericUpDown1.Value))))
														{
															break;
														}
														num3++;
														bool flag29 = num3 > 0;
														if (flag29)
														{
															goto Block_122;
														}
													}
													this.listView3.Invoke(new MethodInvoker(delegate
													{
														this.listView3.Items[this.listvipacc.IndexOf(this.vipacc)].BackColor = Color.Lime;
														this.listView3.Refresh();
													}));
													string a2;
													string txt;
													while (true)
													{
														txt = "";
														this.label1.Invoke(new MethodInvoker(delegate
														{
															txt = <>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>4__this.comboBox5.Text;
														}));
														if (Form1.<>o__121.<>p__17 == null)
														{
															Form1.<>o__121.<>p__17 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Form1), new CSharpArgumentInfo[]
															{
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
															}));
														}
														Func<CallSite, object, bool> arg_1F8C_0 = Form1.<>o__121.<>p__17.Target;
														CallSite arg_1F8C_1 = Form1.<>o__121.<>p__17;
														if (Form1.<>o__121.<>p__16 == null)
														{
															Form1.<>o__121.<>p__16 = CallSite<Func<CallSite, object, byte, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "getip", null, typeof(Form1), new CSharpArgumentInfo[]
															{
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
															}));
														}
														bool flag30 = arg_1F8C_0(arg_1F8C_1, Form1.<>o__121.<>p__16.Target(Form1.<>o__121.<>p__16, arg, this.listcountrycode.FirstOrDefault((countrycode x) => x.country == txt).code));
														if (!flag30)
														{
															goto IL_2191;
														}
														Control arg_1FC0_0 = this.label1;
														MethodInvoker arg_1FC0_1;
														if ((arg_1FC0_1 = Form1.<>c.<>9__121_85) == null)
														{
															arg_1FC0_1 = (Form1.<>c.<>9__121_85 = new MethodInvoker(Form1.<>c.<>9.<autoLeadThread>b__121_85));
														}
														arg_1FC0_0.Invoke(arg_1FC0_1);
														if (Form1.<>o__121.<>p__19 == null)
														{
															Form1.<>o__121.<>p__19 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(Form1)));
														}
														Func<CallSite, object, string> arg_206A_0 = Form1.<>o__121.<>p__19.Target;
														CallSite arg_206A_1 = Form1.<>o__121.<>p__19;
														if (Form1.<>o__121.<>p__18 == null)
														{
															Form1.<>o__121.<>p__18 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "clickip", null, typeof(Form1), new CSharpArgumentInfo[]
															{
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
																CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
															}));
														}
														text4 = arg_206A_0(arg_206A_1, Form1.<>o__121.<>p__18.Target(Form1.<>o__121.<>p__18, arg, (int)this.numericUpDown1.Value));
														a2 = text4;
														if (a2 == "not running")
														{
															break;
														}
														if (!(a2 == "no IP"))
														{
															if (!(a2 == "dead"))
															{
																if (a2 == "limited")
																{
																	goto IL_20E0;
																}
																if (!(a2 == "maximum"))
																{
																	goto Block_139;
																}
																if (Form1.<>o__121.<>p__20 == null)
																{
																	Form1.<>o__121.<>p__20 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "clearip", null, typeof(Form1), new CSharpArgumentInfo[]
																	{
																		CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
																	}));
																}
																Form1.<>o__121.<>p__20.Target(Form1.<>o__121.<>p__20, arg);
															}
														}
													}
													continue;
													IL_20E0:
													this.vipacc.limited = true;
													this.listView3.Invoke(new MethodInvoker(delegate
													{
														this.listView3.Items[this.listvipacc.IndexOf(this.vipacc)].BackColor = Color.Red;
														this.listView3.Refresh();
													}));
													continue;
													Block_139:
													if (!(a2 == "timeout"))
													{
														goto Block_140;
													}
												}
												IL_24D8:
												goto IL_24DA;
												IL_2191:
												goto IL_24D8;
												IL_2197:
												bool flag31 = <>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.proxytype == "SSHServer";
												if (flag31)
												{
													Form1.<>c__DisplayClass121_11 <>c__DisplayClass121_7 = new Form1.<>c__DisplayClass121_11();
													<>c__DisplayClass121_7.CS$<>8__locals11 = <>c__DisplayClass121_5;
													<>c__DisplayClass121_7.checktrung = false;
													<>c__DisplayClass121_7.offer_id = "";
													if (Form1.<>o__121.<>p__21 == null)
													{
														Form1.<>o__121.<>p__21 = CallSite<Action<CallSite, object, int>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "clearIpWithPort", null, typeof(Form1), new CSharpArgumentInfo[]
														{
															CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
															CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
														}));
													}
													Form1.<>o__121.<>p__21.Target(Form1.<>o__121.<>p__21, arg, (int)this.numericUpDown1.Value);
													sshcommand.closebitvise((int)this.numericUpDown1.Value);
													while (true)
													{
														string curcontry;
														while (true)
														{
															Control arg_22B9_0 = this.label1;
															MethodInvoker arg_22B9_1;
															if ((arg_22B9_1 = <>c__DisplayClass121_7.<>9__87) == null)
															{
																arg_22B9_1 = (<>c__DisplayClass121_7.<>9__87 = new MethodInvoker(<>c__DisplayClass121_7.<autoLeadThread>b__87));
															}
															arg_22B9_0.Invoke(arg_22B9_1);
															curcontry = "";
															this.label1.Invoke(new MethodInvoker(delegate
															{
																curcontry = <>c__DisplayClass121_7.CS$<>8__locals11.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>4__this.comboBox5.Text;
															}));
															string text5 = this.sshserverurl + "/Home/getssh?country=" + curcontry;
															bool checktrung = <>c__DisplayClass121_7.checktrung;
															if (checktrung)
															{
																text5 = text5 + "&offerID=" + <>c__DisplayClass121_7.offer_id;
															}
															HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text5);
															httpWebRequest.UserAgent = "autoleadios";
															try
															{
																Stream responseStream = httpWebRequest.GetResponse().GetResponseStream();
																StreamReader streamReader = new StreamReader(responseStream);
																string text6 = streamReader.ReadToEnd();
																bool flag32 = text6 == "hetssh";
																if (flag32)
																{
																	base.Invoke(new MethodInvoker(delegate
																	{
																		this.label1.Text = "SSh trên server đã hết, đang đợi ssh mới ...";
																	}));
																	int i;
																	for (i = 0; i < 10; i = num2 + 1)
																	{
																		Thread.Sleep(1000);
																		base.Invoke(new MethodInvoker(delegate
																		{
																			<>c__DisplayClass121_7.CS$<>8__locals11.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>4__this.label1.Text = "Đợi để lấy SSH trên server trong " + (10 - i).ToString() + " giây";
																		}));
																		num2 = i;
																	}
																	continue;
																}
																string[] array2 = text6.Split(new string[]
																{
																	"|"
																}, StringSplitOptions.None);
																bool flag33 = array2.Count<string>() < 4;
																if (flag33)
																{
																	continue;
																}
																this.curip = array2[1];
																bool flag34 = sshcommand.SetSSH(array2[1], array2[2], array2[3], this.ipAddressControl1.Text, this.numericUpDown1.Value.ToString(), ref this.bitproc);
																if (flag34)
																{
																	goto IL_24D2;
																}
																string requestUriString = this.sshserverurl + "/Home/xoassh?ID=" + array2[0];
																HttpWebRequest httpWebRequest2 = (HttpWebRequest)WebRequest.Create(requestUriString);
																httpWebRequest2.UserAgent = "autoleadios";
																try
																{
																	Stream responseStream2 = httpWebRequest2.GetResponse().GetResponseStream();
																	StreamReader streamReader2 = new StreamReader(responseStream2);
																	string text7 = streamReader.ReadToEnd();
																}
																catch (Exception var_148_24BA)
																{
																}
															}
															catch (Exception var_149_24C3)
															{
															}
															break;
														}
													}
													IL_24D2:
													goto IL_107E;
												}
												goto IL_24D8;
												Block_102:
												if (Form1.<>o__121.<>p__11 == null)
												{
													Form1.<>o__121.<>p__11 = CallSite<Action<CallSite, object, int>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "clearIpWithPort", null, typeof(Form1), new CSharpArgumentInfo[]
													{
														CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
														CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
													}));
												}
												Form1.<>o__121.<>p__11.Target(Form1.<>o__121.<>p__11, arg, (int)this.numericUpDown1.Value);
												sshcommand.closebitvise((int)this.numericUpDown1.Value);
												while (true)
												{
													string curcontry = "";
													this.label1.Invoke(new MethodInvoker(delegate
													{
														curcontry = <>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>4__this.comboBox5.Text;
													}));
													this._getssh = this.listssh.FirstOrDefault((ssh x) => x.live != "dead" && !x.used && x.country == curcontry);
													bool check32 = false;
													this.label1.Invoke(new MethodInvoker(delegate
													{
														check32 = <>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>4__this.checkBox17.Checked;
													}));
													bool flag35 = this._getssh == null;
													if (flag35)
													{
														goto Block_104;
													}
													Random random3 = new Random();
													int index = random3.Next(0, this.listssh.Count);
													while (this.listssh.ElementAt(index).live == "dead" || this.listssh.ElementAt(index).used || this.listssh.ElementAt(index).country != curcontry)
													{
														index = random3.Next(0, this.listssh.Count);
													}
													this._getssh = this.listssh.ElementAt(index);
													this._getssh.used = true;
													this.listView2.Invoke(new MethodInvoker(delegate
													{
														this.listView2.Items[this.listssh.IndexOf(this._getssh)].BackColor = Color.Aqua;
														this.listView2.Refresh();
														this.savessh();
														this.ssh_uncheck.Invoke(new MethodInvoker(delegate
														{
															Control arg_43_0 = this.ssh_uncheck;
															string arg_3E_0 = "Uncheck:";
															IEnumerable<ssh> arg_31_0 = this.listssh;
															Func<ssh, bool> arg_31_1;
															if ((arg_31_1 = Form1.<>c.<>9__121_59) == null)
															{
																arg_31_1 = (Form1.<>c.<>9__121_59 = new Func<ssh, bool>(Form1.<>c.<>9.<autoLeadThread>b__121_59));
															}
															arg_43_0.Text = arg_3E_0 + arg_31_0.Count(arg_31_1).ToString();
															Control arg_8B_0 = this.ssh_used;
															string arg_86_0 = "Used:";
															IEnumerable<ssh> arg_79_0 = this.listssh;
															Func<ssh, bool> arg_79_1;
															if ((arg_79_1 = Form1.<>c.<>9__121_60) == null)
															{
																arg_79_1 = (Form1.<>c.<>9__121_60 = new Func<ssh, bool>(Form1.<>c.<>9.<autoLeadThread>b__121_60));
															}
															arg_8B_0.Text = arg_86_0 + arg_79_0.Count(arg_79_1).ToString();
															Control arg_D3_0 = this.ssh_live;
															string arg_CE_0 = "Live:";
															IEnumerable<ssh> arg_C1_0 = this.listssh;
															Func<ssh, bool> arg_C1_1;
															if ((arg_C1_1 = Form1.<>c.<>9__121_61) == null)
															{
																arg_C1_1 = (Form1.<>c.<>9__121_61 = new Func<ssh, bool>(Form1.<>c.<>9.<autoLeadThread>b__121_61));
															}
															arg_D3_0.Text = arg_CE_0 + arg_C1_0.Count(arg_C1_1).ToString();
															Control arg_11B_0 = this.ss_dead;
															string arg_116_0 = "Dead:";
															IEnumerable<ssh> arg_109_0 = this.listssh;
															Func<ssh, bool> arg_109_1;
															if ((arg_109_1 = Form1.<>c.<>9__121_62) == null)
															{
																arg_109_1 = (Form1.<>c.<>9__121_62 = new Func<ssh, bool>(Form1.<>c.<>9.<autoLeadThread>b__121_62));
															}
															arg_11B_0.Text = arg_116_0 + arg_109_0.Count(arg_109_1).ToString();
														}));
													}));
													try
													{
														sshcommand.closebitvise((int)this.numericUpDown1.Value);
														bool flag36 = !this.bitproc.HasExited;
														if (flag36)
														{
															this.bitproc.Kill();
														}
													}
													catch (Exception)
													{
													}
													this.curip = this._getssh.IP;
													bool flag37 = sshcommand.SetSSH(this._getssh.IP, this._getssh.username, this._getssh.password, this.ipAddressControl1.Text, this.numericUpDown1.Value.ToString(), ref this.bitproc);
													if (flag37)
													{
														break;
													}
													this._getssh.live = "dead";
													this.listView2.Invoke(new MethodInvoker(delegate
													{
														this.listView2.Items[this.listssh.IndexOf(this._getssh)].BackColor = Color.Red;
														this.listView2.Refresh();
														this.savessh();
														this.ssh_uncheck.Invoke(new MethodInvoker(delegate
														{
															Control arg_43_0 = this.ssh_uncheck;
															string arg_3E_0 = "Uncheck:";
															IEnumerable<ssh> arg_31_0 = this.listssh;
															Func<ssh, bool> arg_31_1;
															if ((arg_31_1 = Form1.<>c.<>9__121_65) == null)
															{
																arg_31_1 = (Form1.<>c.<>9__121_65 = new Func<ssh, bool>(Form1.<>c.<>9.<autoLeadThread>b__121_65));
															}
															arg_43_0.Text = arg_3E_0 + arg_31_0.Count(arg_31_1).ToString();
															Control arg_8B_0 = this.ssh_used;
															string arg_86_0 = "Used:";
															IEnumerable<ssh> arg_79_0 = this.listssh;
															Func<ssh, bool> arg_79_1;
															if ((arg_79_1 = Form1.<>c.<>9__121_66) == null)
															{
																arg_79_1 = (Form1.<>c.<>9__121_66 = new Func<ssh, bool>(Form1.<>c.<>9.<autoLeadThread>b__121_66));
															}
															arg_8B_0.Text = arg_86_0 + arg_79_0.Count(arg_79_1).ToString();
															Control arg_D3_0 = this.ssh_live;
															string arg_CE_0 = "Live:";
															IEnumerable<ssh> arg_C1_0 = this.listssh;
															Func<ssh, bool> arg_C1_1;
															if ((arg_C1_1 = Form1.<>c.<>9__121_67) == null)
															{
																arg_C1_1 = (Form1.<>c.<>9__121_67 = new Func<ssh, bool>(Form1.<>c.<>9.<autoLeadThread>b__121_67));
															}
															arg_D3_0.Text = arg_CE_0 + arg_C1_0.Count(arg_C1_1).ToString();
															Control arg_11B_0 = this.ss_dead;
															string arg_116_0 = "Dead:";
															IEnumerable<ssh> arg_109_0 = this.listssh;
															Func<ssh, bool> arg_109_1;
															if ((arg_109_1 = Form1.<>c.<>9__121_68) == null)
															{
																arg_109_1 = (Form1.<>c.<>9__121_68 = new Func<ssh, bool>(Form1.<>c.<>9.<autoLeadThread>b__121_68));
															}
															arg_11B_0.Text = arg_116_0 + arg_109_0.Count(arg_109_1).ToString();
														}));
													}));
												}
												Thread.Sleep(1000);
												this.cmd.sendtext("{HOME}");
												this.cmd.wipe("com.apple.mobilesafari");
												this.button2.Invoke(new MethodInvoker(delegate
												{
													this.maxwait = (int)this.numericUpDown10.Value;
												}));
												now = DateTime.Now;
												while (!this.cmdResult.wipe)
												{
													Thread.Sleep(1000);
													bool flag38 = (DateTime.Now - now).TotalSeconds > (double)this.maxwait;
													if (flag38)
													{
														goto Block_111;
													}
													this.cmd.checkwipe();
												}
												goto IL_107E;
												Block_117:
												bool flag39 = this.listvipacc.Count == 0;
												if (flag39)
												{
													MessageBox.Show("All vip72 are limited or there is no account, Please add other Vip72 account to use", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
													this.label1.Invoke(new MethodInvoker(delegate
													{
														this.label1.Text = "Vip72 account is out";
													}));
													this.button7.Invoke(new MethodInvoker(delegate
													{
														bool flag59 = this.button7.Text == "STOP";
														if (flag59)
														{
															this.button7_Click(null, null);
														}
														bool flag60 = this.button19.Text == "STOP";
														if (flag60)
														{
															this.button19_Click(null, null);
														}
													}));
												}
												else
												{
													foreach (vipaccount current4 in this.listvipacc)
													{
														current4.limited = false;
													}
												}
												Thread.Sleep(1000);
												this.cmd.sendtext("{HOME}");
												this.cmd.wipe("com.apple.mobilesafari");
												this.button2.Invoke(new MethodInvoker(delegate
												{
													this.maxwait = (int)this.numericUpDown10.Value;
												}));
												now = DateTime.Now;
												while (!this.cmdResult.wipe)
												{
													Thread.Sleep(1000);
													bool flag40 = (DateTime.Now - now).TotalSeconds > (double)this.maxwait;
													if (flag40)
													{
														goto Block_120;
													}
													this.cmd.checkwipe();
												}
												goto IL_107E;
												Block_122:
												this.vipacc.limited = true;
												this.listView3.Invoke(new MethodInvoker(delegate
												{
													this.listView3.Items[this.listvipacc.IndexOf(this.vipacc)].BackColor = Color.Red;
													this.listView3.Refresh();
												}));
												this.cmd.wipe("com.apple.mobilesafari");
												now = DateTime.Now;
												this.button2.Invoke(new MethodInvoker(delegate
												{
													this.maxwait = (int)this.numericUpDown10.Value;
												}));
												while (!this.cmdResult.wipe)
												{
													Thread.Sleep(1000);
													bool flag41 = (DateTime.Now - now).TotalSeconds > (double)this.maxwait;
													if (flag41)
													{
														goto Block_123;
													}
													this.cmd.checkwipe();
												}
												goto IL_107E;
												Block_140:
												this.cmd.close("com.apple.mobilesafari");
												this.currentvipip = text4;
												this.curip = this.currentvipip;
												goto IL_107E;
											}
											IL_24DA:;
										}
										this.cmd.getfront();
									}
									goto IL_2520;
								}
								break;
							}
							continue;
							Block_93:
							this.button2.Invoke(new MethodInvoker(delegate
							{
								bool flag59 = this.button2.Text == "Disconnect";
								if (flag59)
								{
									this.button2_Click(null, null);
								}
							}));
							return;
							IL_2520:
							Thread.Sleep(2000);
							this.listView1.Invoke(new MethodInvoker(delegate
							{
								<>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>4__this.listView1.Items[<>c__DisplayClass121_5.index].SubItems[2].BackColor = Color.Lime;
								<>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>4__this.listView1.Items[<>c__DisplayClass121_5.index].SubItems[3].BackColor = Color.Yellow;
								<>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>4__this.listView1.Refresh();
							}));
							this.cmdResult.wipe = false;
							bool wipechoose2 = <>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.wipechoose;
							if (wipechoose2)
							{
								this.cmd.installapp(<>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.item.appID);
							}
							<>c__DisplayClass121_5.timesleep = <>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.item.timeSleepBefore;
							bool timeSleepBeforeRandom = <>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.item.timeSleepBeforeRandom;
							if (timeSleepBeforeRandom)
							{
								Random random4 = new Random();
								<>c__DisplayClass121_5.timesleep = random4.Next(<>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.item.range1, <>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.item.range2);
							}
							for (i = 0; i < <>c__DisplayClass121_5.timesleep; i = num2 + 1)
							{
								this.label1.Invoke(new MethodInvoker(delegate
								{
									<>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>4__this.label1.Text = "Sleeping for " + (<>c__DisplayClass121_5.timesleep - i - 1).ToString() + " seconds";
								}));
								Thread.Sleep(1000);
								bool flag42 = this.itunesX.Value != decimal.MinusOne;
								if (flag42)
								{
									this.cmd.touch((double)this.itunesX.Value, (double)this.itunesY.Value);
								}
								num2 = i;
							}
							bool wipechoose3 = <>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.wipechoose;
							if (wipechoose3)
							{
								this.label1.Invoke(new MethodInvoker(delegate
								{
									this.label1.Text = "Đang cài đặt ứng dụng...";
								}));
								now = DateTime.Now;
								while (!this.cmdResult.wipe)
								{
									Thread.Sleep(500);
									bool flag43 = (DateTime.Now - now).TotalSeconds > (double)this.maxwait;
									if (flag43)
									{
										this.button2.Invoke(new MethodInvoker(delegate
										{
											bool flag59 = this.button2.Text == "Disconnect";
											if (flag59)
											{
												this.button2_Click(null, null);
											}
										}));
										return;
									}
									this.cmd.checkwipe();
								}
							}
							this.cmdResult.openApp = 0;
							this.label1.Invoke(new MethodInvoker(delegate
							{
								this.label1.Text = "Opening Aplication...";
							}));
							this.cmd.openApp(<>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.item.appID);
							now2 = DateTime.Now;
							this.button2.Invoke(new MethodInvoker(delegate
							{
								this.maxwait = (int)this.numericUpDown10.Value;
							}));
							while (this.cmdResult.openApp == 0 || this.cmdResult.openApp == 2)
							{
								Thread.Sleep(100);
								bool flag44 = (DateTime.Now - now2).TotalSeconds > (double)this.maxwait1;
								if (flag44)
								{
									this.button2.Invoke(new MethodInvoker(delegate
									{
										bool flag59 = this.button2.Text == "Disconnect";
										if (flag59)
										{
											this.button2_Click(null, null);
										}
									}));
									return;
								}
								bool flag45 = this.cmdResult.openApp == 2;
								if (flag45)
								{
									break;
								}
							}
							bool flag46 = this.cmdResult.openApp == 1;
							if (flag46)
							{
								for (int j = 0; j < Convert.ToInt32(<>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.item.timeSleep); j++)
								{
									Thread.Sleep(1000);
									bool flag47 = this.itunesX.Value != decimal.MinusOne;
									if (flag47)
									{
										this.cmd.touch((double)this.itunesX.Value, (double)this.itunesY.Value);
									}
									Control arg_290F_0 = this.listView1;
									MethodInvoker arg_290F_1;
									if ((arg_290F_1 = <>c__DisplayClass121_5.<>9__98) == null)
									{
										arg_290F_1 = (<>c__DisplayClass121_5.<>9__98 = delegate
										{
											<>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>4__this.listView1.Items[<>c__DisplayClass121_5.index].SubItems[3].Text = (Convert.ToInt32(<>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>4__this.listView1.Items[<>c__DisplayClass121_5.index].SubItems[3].Text) - 1).ToString();
											<>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>4__this.label1.Text = "Application will be closed in " + <>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>4__this.listView1.Items[<>c__DisplayClass121_5.index].SubItems[3].Text + " sec";
										});
									}
									arg_290F_0.Invoke(arg_290F_1);
								}
								this.listView1.Invoke(new MethodInvoker(delegate
								{
									<>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>4__this.listView1.Items[<>c__DisplayClass121_5.index].SubItems[3].Text = <>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.item.timeSleep.ToString();
									<>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>4__this.listView1.Items[<>c__DisplayClass121_5.index].SubItems[3].BackColor = Color.Lime;
									<>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>4__this.listView1.Items[<>c__DisplayClass121_5.index].SubItems[4].BackColor = Color.Yellow;
									<>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>4__this.listView1.Refresh();
								}));
								bool useScript = <>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.item.useScript;
								if (useScript)
								{
									this.excuteScript(<>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.item.script);
								}
								this.listView1.Invoke(new MethodInvoker(delegate
								{
									<>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>4__this.listView1.Items[<>c__DisplayClass121_5.index].SubItems[4].BackColor = Color.Lime;
									<>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.CS$<>8__locals6.<>4__this.listView1.Refresh();
								}));
								this.cmd.close(<>c__DisplayClass121_5.CS$<>8__locals8.CS$<>8__locals7.item.appID);
							}
							continue;
							goto IL_2520;
							Block_98:
							this.button2.Invoke(new MethodInvoker(delegate
							{
								bool flag59 = this.button2.Text == "Disconnect";
								if (flag59)
								{
									this.button2_Click(null, null);
								}
							}));
							return;
							Block_104:
							bool flag48 = !<>c__DisplayClass121_10.check32;
							if (flag48)
							{
								MessageBox.Show("All SSH are used or dead, please update new SSH list!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
								this.label1.Invoke(new MethodInvoker(delegate
								{
									this.button7_Click(null, null);
								}));
							}
							else
							{
								this.label1.Invoke(new MethodInvoker(delegate
								{
									this.button24_Click(null, null);
								}));
							}
							goto IL_01;
							Block_111:
							this.button2.Invoke(new MethodInvoker(delegate
							{
								bool flag59 = this.button2.Text == "Disconnect";
								if (flag59)
								{
									this.button2_Click(null, null);
								}
							}));
							return;
							Block_120:
							this.button2.Invoke(new MethodInvoker(delegate
							{
								bool flag59 = this.button2.Text == "Disconnect";
								if (flag59)
								{
									this.button2_Click(null, null);
								}
							}));
							return;
							Block_123:
							this.button2.Invoke(new MethodInvoker(delegate
							{
								bool flag59 = this.button2.Text == "Disconnect";
								if (flag59)
								{
									this.button2_Click(null, null);
								}
							}));
							return;
						}
					}
					<>c__DisplayClass121_.bk = false;
					<>c__DisplayClass121_.bkfull = false;
					<>c__DisplayClass121_.bkrate = 0;
					this.checkBox1.Invoke(new MethodInvoker(delegate
					{
						<>c__DisplayClass121_.bk = <>c__DisplayClass121_.<>4__this.checkBox1.Checked;
						<>c__DisplayClass121_.bkfull = <>c__DisplayClass121_.<>4__this.checkBox3.Checked;
						<>c__DisplayClass121_.bkrate = (int)<>c__DisplayClass121_.<>4__this.numericUpDown3.Value;
					}));
					bool flag49 = <>c__DisplayClass121_.bk && (this.backuptime + 1) * 100 / (this.runtime + 1) <= <>c__DisplayClass121_.bkrate;
					if (flag49)
					{
						string cm = "";
						this.label1.Invoke(new MethodInvoker(delegate
						{
							<>c__DisplayClass121_.<>4__this.label1.Text = "Backing Up the application...";
							cm = <>c__DisplayClass121_.<>4__this.comment.Text;
							bool checked3 = <>c__DisplayClass121_.<>4__this.checkBox12.Checked;
							if (checked3)
							{
								cm = cm + " IP:" + <>c__DisplayClass121_.<>4__this.curip;
							}
							cm = cm + "[]" + <>c__DisplayClass121_.<>4__this.comboBox5.Text;
						}));
						string filename = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss_fff");
						bool bkfull = <>c__DisplayClass121_.bkfull;
						if (bkfull)
						{
							this.cmd.backupfull(text2, filename, cm, "", "");
						}
						else
						{
							this.cmd.backup(text2, filename, cm, "", "");
						}
						this.cmdResult.backup = false;
						DateTime now4 = DateTime.Now;
						this.button2.Invoke(new MethodInvoker(delegate
						{
							this.maxwait = (int)this.numericUpDown10.Value;
						}));
						while (!this.cmdResult.backup)
						{
							Thread.Sleep(500);
							bool flag50 = (DateTime.Now - now4).TotalSeconds > (double)this.maxwait;
							if (flag50)
							{
								goto Block_58;
							}
							this.cmd.checkbackup(filename);
						}
						this.backupoftime.Invoke(new MethodInvoker(delegate
						{
							this.backuptime++;
							this.backupoftime.Text = "Backup:" + this.backuptime.ToString();
						}));
					}
					this.backupoftime.Invoke(new MethodInvoker(delegate
					{
						this.runtime++;
						this.runoftime.Text = "Run:" + this.runtime.ToString();
						this.backuprate.Text = "Backup Rate:" + Math.Round((double)this.backuptime / (double)this.runtime * 100.0, 2).ToString() + "%";
						bool flag59 = this.checkBox10.Checked && this.runtime >= this.numericUpDown6.Value;
						if (flag59)
						{
							bool flag60 = this.button7.Text == "STOP";
							if (flag60)
							{
								this.button7_Click(null, null);
							}
						}
					}));
					this.listView1.Invoke(new MethodInvoker(delegate
					{
						foreach (ListViewItem listViewItem in this.listView1.Items)
						{
							listViewItem.SubItems[0].ResetStyle();
							listViewItem.SubItems[1].ResetStyle();
							listViewItem.SubItems[2].ResetStyle();
							listViewItem.SubItems[3].ResetStyle();
							listViewItem.SubItems[4].ResetStyle();
							this.listView1.Refresh();
						}
					}));
					continue;
					Block_3:
					if (Form1.<>o__121.<>p__0 == null)
					{
						Form1.<>o__121.<>p__0 = CallSite<Action<CallSite, object, int>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "clearIpWithPort", null, typeof(Form1), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
						}));
					}
					Form1.<>o__121.<>p__0.Target(Form1.<>o__121.<>p__0, arg, (int)this.numericUpDown1.Value);
					sshcommand.closebitvise((int)this.numericUpDown1.Value);
					try
					{
						bool flag51 = !this.bitproc.HasExited;
						if (flag51)
						{
							this.bitproc.Kill();
						}
					}
					catch (Exception)
					{
					}
					while (true)
					{
						string curcontry = "";
						this.label1.Invoke(new MethodInvoker(delegate
						{
							<>c__DisplayClass121_.<>4__this.label1.Text = "Checking SSH....";
							curcontry = <>c__DisplayClass121_.<>4__this.comboBox5.Text;
						}));
						this._getssh = this.listssh.FirstOrDefault((ssh x) => x.live != "dead" && !x.used && x.country == curcontry);
						bool check32 = false;
						this.label1.Invoke(new MethodInvoker(delegate
						{
							check32 = <>c__DisplayClass121_.<>4__this.checkBox17.Checked;
						}));
						bool flag52 = this._getssh == null;
						if (flag52)
						{
							goto Block_6;
						}
						Random random5 = new Random();
						int index2 = random5.Next(0, this.listssh.Count);
						while (this.listssh.ElementAt(index2).live == "dead" || this.listssh.ElementAt(index2).used || this.listssh.ElementAt(index2).country != curcontry)
						{
							index2 = random5.Next(0, this.listssh.Count);
						}
						this._getssh = this.listssh.ElementAt(index2);
						this._getssh.used = true;
						this.listView2.Invoke(new MethodInvoker(delegate
						{
							this.listView2.Items[this.listssh.IndexOf(this._getssh)].BackColor = Color.Aqua;
							this.listView2.Refresh();
							this.savessh();
							this.ssh_uncheck.Invoke(new MethodInvoker(delegate
							{
								Control arg_43_0 = this.ssh_uncheck;
								string arg_3E_0 = "Uncheck:";
								IEnumerable<ssh> arg_31_0 = this.listssh;
								Func<ssh, bool> arg_31_1;
								if ((arg_31_1 = Form1.<>c.<>9__121_11) == null)
								{
									arg_31_1 = (Form1.<>c.<>9__121_11 = new Func<ssh, bool>(Form1.<>c.<>9.<autoLeadThread>b__121_11));
								}
								arg_43_0.Text = arg_3E_0 + arg_31_0.Count(arg_31_1).ToString();
								Control arg_8B_0 = this.ssh_used;
								string arg_86_0 = "Used:";
								IEnumerable<ssh> arg_79_0 = this.listssh;
								Func<ssh, bool> arg_79_1;
								if ((arg_79_1 = Form1.<>c.<>9__121_12) == null)
								{
									arg_79_1 = (Form1.<>c.<>9__121_12 = new Func<ssh, bool>(Form1.<>c.<>9.<autoLeadThread>b__121_12));
								}
								arg_8B_0.Text = arg_86_0 + arg_79_0.Count(arg_79_1).ToString();
								Control arg_D3_0 = this.ssh_live;
								string arg_CE_0 = "Live:";
								IEnumerable<ssh> arg_C1_0 = this.listssh;
								Func<ssh, bool> arg_C1_1;
								if ((arg_C1_1 = Form1.<>c.<>9__121_13) == null)
								{
									arg_C1_1 = (Form1.<>c.<>9__121_13 = new Func<ssh, bool>(Form1.<>c.<>9.<autoLeadThread>b__121_13));
								}
								arg_D3_0.Text = arg_CE_0 + arg_C1_0.Count(arg_C1_1).ToString();
								Control arg_11B_0 = this.ss_dead;
								string arg_116_0 = "Dead:";
								IEnumerable<ssh> arg_109_0 = this.listssh;
								Func<ssh, bool> arg_109_1;
								if ((arg_109_1 = Form1.<>c.<>9__121_14) == null)
								{
									arg_109_1 = (Form1.<>c.<>9__121_14 = new Func<ssh, bool>(Form1.<>c.<>9.<autoLeadThread>b__121_14));
								}
								arg_11B_0.Text = arg_116_0 + arg_109_0.Count(arg_109_1).ToString();
							}));
						}));
						this.curip = this._getssh.IP;
						bool flag53 = sshcommand.SetSSH(this._getssh.IP, this._getssh.username, this._getssh.password, this.ipAddressControl1.Text, this.numericUpDown1.Value.ToString(), ref this.bitproc);
						if (flag53)
						{
							break;
						}
						this._getssh.live = "dead";
						this.listView2.Invoke(new MethodInvoker(delegate
						{
							try
							{
								this.listView2.Items[this.listssh.IndexOf(this._getssh)].BackColor = Color.Red;
								this.listView2.Refresh();
								this.savessh();
								this.ssh_uncheck.Invoke(new MethodInvoker(delegate
								{
									Control arg_43_0 = this.ssh_uncheck;
									string arg_3E_0 = "Uncheck:";
									IEnumerable<ssh> arg_31_0 = this.listssh;
									Func<ssh, bool> arg_31_1;
									if ((arg_31_1 = Form1.<>c.<>9__121_17) == null)
									{
										arg_31_1 = (Form1.<>c.<>9__121_17 = new Func<ssh, bool>(Form1.<>c.<>9.<autoLeadThread>b__121_17));
									}
									arg_43_0.Text = arg_3E_0 + arg_31_0.Count(arg_31_1).ToString();
									Control arg_8B_0 = this.ssh_used;
									string arg_86_0 = "Used:";
									IEnumerable<ssh> arg_79_0 = this.listssh;
									Func<ssh, bool> arg_79_1;
									if ((arg_79_1 = Form1.<>c.<>9__121_18) == null)
									{
										arg_79_1 = (Form1.<>c.<>9__121_18 = new Func<ssh, bool>(Form1.<>c.<>9.<autoLeadThread>b__121_18));
									}
									arg_8B_0.Text = arg_86_0 + arg_79_0.Count(arg_79_1).ToString();
									Control arg_D3_0 = this.ssh_live;
									string arg_CE_0 = "Live:";
									IEnumerable<ssh> arg_C1_0 = this.listssh;
									Func<ssh, bool> arg_C1_1;
									if ((arg_C1_1 = Form1.<>c.<>9__121_19) == null)
									{
										arg_C1_1 = (Form1.<>c.<>9__121_19 = new Func<ssh, bool>(Form1.<>c.<>9.<autoLeadThread>b__121_19));
									}
									arg_D3_0.Text = arg_CE_0 + arg_C1_0.Count(arg_C1_1).ToString();
									Control arg_11B_0 = this.ss_dead;
									string arg_116_0 = "Dead:";
									IEnumerable<ssh> arg_109_0 = this.listssh;
									Func<ssh, bool> arg_109_1;
									if ((arg_109_1 = Form1.<>c.<>9__121_20) == null)
									{
										arg_109_1 = (Form1.<>c.<>9__121_20 = new Func<ssh, bool>(Form1.<>c.<>9.<autoLeadThread>b__121_20));
									}
									arg_11B_0.Text = arg_116_0 + arg_109_0.Count(arg_109_1).ToString();
								}));
							}
							catch (Exception)
							{
							}
						}));
					}
					IL_D62:
					goto IL_D63;
					IL_A27:
					bool flag54 = <>c__DisplayClass121_.proxytype == "SSHServer";
					if (flag54)
					{
						Form1.<>c__DisplayClass121_3 <>c__DisplayClass121_14 = new Form1.<>c__DisplayClass121_3();
						<>c__DisplayClass121_14.CS$<>8__locals3 = <>c__DisplayClass121_;
						<>c__DisplayClass121_14.checktrung = false;
						<>c__DisplayClass121_14.offer_id = "";
						if (Form1.<>o__121.<>p__10 == null)
						{
							Form1.<>o__121.<>p__10 = CallSite<Action<CallSite, object, int>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "clearIpWithPort", null, typeof(Form1), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
							}));
						}
						Form1.<>o__121.<>p__10.Target(Form1.<>o__121.<>p__10, arg, (int)this.numericUpDown1.Value);
						sshcommand.closebitvise((int)this.numericUpDown1.Value);
						while (true)
						{
							string curcontry;
							while (true)
							{
								Control arg_B38_0 = this.label1;
								MethodInvoker arg_B38_1;
								if ((arg_B38_1 = <>c__DisplayClass121_14.<>9__33) == null)
								{
									arg_B38_1 = (<>c__DisplayClass121_14.<>9__33 = new MethodInvoker(<>c__DisplayClass121_14.<autoLeadThread>b__33));
								}
								arg_B38_0.Invoke(arg_B38_1);
								curcontry = "";
								this.label1.Invoke(new MethodInvoker(delegate
								{
									curcontry = <>c__DisplayClass121_14.CS$<>8__locals3.<>4__this.comboBox5.Text;
								}));
								string text8 = this.sshserverurl + "/Home/getssh?country=" + curcontry;
								bool checktrung2 = <>c__DisplayClass121_14.checktrung;
								if (checktrung2)
								{
									text8 = text8 + "&offerID=" + <>c__DisplayClass121_14.offer_id;
								}
								HttpWebRequest httpWebRequest3 = (HttpWebRequest)WebRequest.Create(text8);
								httpWebRequest3.UserAgent = "autoleadios";
								try
								{
									Stream responseStream3 = httpWebRequest3.GetResponse().GetResponseStream();
									StreamReader streamReader3 = new StreamReader(responseStream3);
									string text9 = streamReader3.ReadToEnd();
									bool flag55 = text9 == "hetssh";
									if (flag55)
									{
										base.Invoke(new MethodInvoker(delegate
										{
											this.label1.Text = "SSh trên server đã hết, đang đợi ssh mới ...";
										}));
										int num2;
										int i;
										for (i = 0; i < 10; i = num2 + 1)
										{
											Thread.Sleep(1000);
											base.Invoke(new MethodInvoker(delegate
											{
												<>c__DisplayClass121_14.CS$<>8__locals3.<>4__this.label1.Text = "Đợi để lấy SSH trên server trong " + (10 - i).ToString() + " giây";
											}));
											num2 = i;
										}
										continue;
									}
									string[] array3 = text9.Split(new string[]
									{
										"|"
									}, StringSplitOptions.None);
									bool flag56 = array3.Count<string>() < 4;
									if (flag56)
									{
										continue;
									}
									this.curip = array3[1];
									bool flag57 = sshcommand.SetSSH(array3[1], array3[2], array3[3], this.ipAddressControl1.Text, this.numericUpDown1.Value.ToString(), ref this.bitproc);
									if (flag57)
									{
										goto IL_D51;
									}
									string requestUriString2 = this.sshserverurl + "/Home/xoassh?ID=" + array3[0];
									HttpWebRequest httpWebRequest4 = (HttpWebRequest)WebRequest.Create(requestUriString2);
									httpWebRequest4.UserAgent = "autoleadios";
									try
									{
										Stream responseStream4 = httpWebRequest4.GetResponse().GetResponseStream();
										StreamReader streamReader4 = new StreamReader(responseStream4);
										string text10 = streamReader3.ReadToEnd();
									}
									catch (Exception var_52_D39)
									{
									}
								}
								catch (Exception var_53_D42)
								{
								}
								break;
							}
						}
						IL_D51:;
					}
					else
					{
						this.curip = "";
					}
					IL_A21:
					goto IL_D62;
					Block_35:
					this.currentvipip = text;
					this.curip = this.currentvipip;
					goto IL_A21;
				}
				this.button7.Invoke(new MethodInvoker(delegate
				{
					bool flag59 = this.button7.Text == "STOP";
					if (flag59)
					{
						this.button7_Click(null, null);
					}
					bool flag60 = this.button19.Text == "STOP";
					if (flag60)
					{
						this.button19_Click(null, null);
					}
				}));
				continue;
				Block_6:
				bool flag58 = !<>c__DisplayClass121_13.check32;
				if (flag58)
				{
					MessageBox.Show("All SSH are used or dead, please update new SSH list!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					this.label1.Invoke(new MethodInvoker(delegate
					{
						this.button7_Click(null, null);
					}));
				}
				else
				{
					this.label1.Invoke(new MethodInvoker(delegate
					{
						this.button24_Click(null, null);
					}));
				}
				continue;
				Block_17:
				MessageBox.Show("There is no account, Please add other Vip72 account to use", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				this.label1.Invoke(new MethodInvoker(delegate
				{
					this.label1.Text = "Vip72 account is out";
				}));
				this.button7.Invoke(new MethodInvoker(delegate
				{
					bool flag59 = this.button7.Text == "STOP";
					if (flag59)
					{
						this.button7_Click(null, null);
					}
					bool flag60 = this.button19.Text == "STOP";
					if (flag60)
					{
						this.button19_Click(null, null);
					}
				}));
			}
			Block_52:
			this.button2.Invoke(new MethodInvoker(delegate
			{
				bool flag59 = this.button2.Text == "Disconnect";
				if (flag59)
				{
					this.button2_Click(null, null);
				}
			}));
			return;
			Block_58:
			this.button2.Invoke(new MethodInvoker(delegate
			{
				bool flag59 = this.button2.Text == "Disconnect";
				if (flag59)
				{
					this.button2_Click(null, null);
				}
			}));
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000B228 File Offset: 0x00009428
		private string anaURL(string URL)
		{
			Regex regex = new Regex("{randomnum\\((.*?)\\)}");
			MatchCollection matchCollection = regex.Matches(URL);
			int num = 0;
			foreach (Match match in matchCollection)
			{
				string value = match.Groups[1].Value;
				string[] array = value.Replace(" ", string.Empty).Split(new string[]
				{
					","
				}, StringSplitOptions.None);
				bool flag = array.Count<string>() == 2;
				if (flag)
				{
					Random random3 = new Random();
					int count = random3.Next(Convert.ToInt32(array[0]), Convert.ToInt32(array[1]) + 1);
					Random random = new Random();
					string text = new string((from s in Enumerable.Repeat<string>("123456789", count)
					select s[random.Next(s.Length)]).ToArray<char>());
					URL = URL.Remove(match.Index - num, match.Length);
					URL = URL.Insert(match.Index - num, text);
					num += match.Length - text.Length;
					Thread.Sleep(10);
				}
			}
			regex = new Regex("{randomtext\\((.*?)\\)}");
			matchCollection = regex.Matches(URL);
			num = 0;
			foreach (Match match2 in matchCollection)
			{
				string value2 = match2.Groups[1].Value;
				string[] array2 = value2.Replace(" ", string.Empty).Split(new string[]
				{
					","
				}, StringSplitOptions.None);
				bool flag2 = array2.Count<string>() == 2;
				if (flag2)
				{
					Random random2 = new Random();
					int count2 = random2.Next(Convert.ToInt32(array2[0]), Convert.ToInt32(array2[1]) + 1);
					Random random = new Random();
					string text2 = new string((from s in Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", count2)
					select s[random.Next(s.Length)]).ToArray<char>());
					URL = URL.Remove(match2.Index - num, match2.Length);
					URL = URL.Insert(match2.Index - num, text2);
					num += match2.Length - text2.Length;
					Thread.Sleep(10);
				}
			}
			return URL;
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0000B508 File Offset: 0x00009708
		private void excuteScript(string script)
		{
			string text = "";
			string[] array = script.Split(new string[]
			{
				"\n"
			}, StringSplitOptions.None);
			List<textvar> list = new List<textvar>();
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string _eachscript = array2[i];
				bool flag = _eachscript != "";
				if (flag)
				{
					Regex regex = new Regex("(.*?)\\(");
					Match match = regex.Match(_eachscript);
					Regex regex2 = new Regex("\\((.*?)\\)");
					Match match2 = regex2.Match(_eachscript);
					bool flag2 = match.Success && match2.Success;
					if (flag2)
					{
						string value = match2.Groups[1].Value;
						string[] _vararray = value.Split(new string[]
						{
							","
						}, StringSplitOptions.None);
						string text2 = "";
						string[] _script = match.Groups[1].Value.ToLower().Split(new string[]
						{
							"="
						}, StringSplitOptions.None);
						bool flag3 = _script.Count<string>() == 2;
						string text3;
						if (flag3)
						{
							text3 = _script[1];
						}
						else
						{
							text3 = match.Groups[1].Value.ToLower();
						}
						string text4 = text3;
						uint num = <PrivateImplementationDetails>.ComputeStringHash(text4);
						if (num <= 1811393716u)
						{
							if (num <= 667630371u)
							{
								if (num <= 362961967u)
								{
									if (num != 340129801u)
									{
										if (num == 362961967u)
										{
											if (text4 == "touchrandom")
											{
												this.label1.Invoke(new MethodInvoker(delegate
												{
													this.label1.Text = "Command:" + _eachscript;
												}));
												bool flag4 = _vararray.Count<string>() == 7;
												if (flag4)
												{
													this.cmdResult.touchrandom = false;
													Random random12 = new Random();
													int num2 = random12.Next(Convert.ToInt32(_vararray[4]), Convert.ToInt32(_vararray[5]));
													this.cmd.touchRandom((double)Convert.ToInt32(_vararray[0]), (double)Convert.ToInt32(_vararray[1]), (double)Convert.ToInt32(_vararray[2]), (double)Convert.ToInt32(_vararray[3]), (double)num2, Math.Pow(10.0, (double)Convert.ToInt32(_vararray[6])));
													Thread.Sleep(num2 * 1000);
													DateTime now = DateTime.Now;
													while (!this.cmdResult.touchrandom)
													{
														bool flag5 = (DateTime.Now - now).Seconds >= 5;
														if (flag5)
														{
															break;
														}
														Thread.Sleep(100);
													}
												}
											}
										}
									}
									else if (text4 == "randomtext")
									{
										this.label1.Invoke(new MethodInvoker(delegate
										{
											this.label1.Text = "Command:" + _eachscript;
										}));
										bool flag6 = _vararray.Count<string>() == 2;
										if (flag6)
										{
											this.cmdResult.sendtext = false;
											Random random2 = new Random();
											int count = random2.Next(Convert.ToInt32(_vararray[0]), Convert.ToInt32(_vararray[1]) + 1);
											Random random = new Random();
											string text5 = new string((from s in Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", count)
											select s[random.Next(s.Length)]).ToArray<char>());
											this.cmd.sendtext(text5);
											text = text + "send=" + text5;
											text += "|";
											text2 = text5;
											DateTime now = DateTime.Now;
											while (!this.cmdResult.sendtext)
											{
												bool flag7 = (DateTime.Now - now).Seconds >= 5;
												if (flag7)
												{
													break;
												}
												Thread.Sleep(100);
											}
										}
									}
								}
								else if (num != 656211712u)
								{
									if (num == 667630371u)
									{
										if (text4 == "close")
										{
											this.label1.Invoke(new MethodInvoker(delegate
											{
												this.label1.Text = "Command:" + _eachscript;
											}));
											Regex regex3 = new Regex("'(.*?)'");
											Match match3 = regex3.Match(_eachscript);
											bool success = match3.Success;
											if (success)
											{
												this.cmd.close(match3.Groups[1].Value);
												text = text + "close=" + match3.Groups[1].Value;
												text += "|";
											}
										}
									}
								}
								else if (text4 == "randomfromfile")
								{
									this.label1.Invoke(new MethodInvoker(delegate
									{
										this.label1.Text = "Command:" + _eachscript;
									}));
									string str = AppDomain.CurrentDomain.BaseDirectory + "TextFile";
									bool flag8 = File.Exists(str + "\\" + _vararray[0]);
									if (flag8)
									{
										string[] array3 = File.ReadAllLines(str + "\\" + _vararray[0]);
										Random random3 = new Random();
										string text6 = array3[random3.Next(0, array3.Count<string>())];
										this.cmdResult.sendtext = false;
										this.cmd.sendtext(text6);
										text = text + "send=" + text6;
										text += "|";
										text2 = text6;
										DateTime now = DateTime.Now;
										while (!this.cmdResult.sendtext)
										{
											bool flag9 = (DateTime.Now - now).Seconds >= 5;
											if (flag9)
											{
												break;
											}
											Thread.Sleep(100);
										}
									}
								}
							}
							else if (num <= 843736943u)
							{
								if (num != 843623666u)
								{
									if (num == 843736943u)
									{
										if (text4 == "randomnumber")
										{
											this.label1.Invoke(new MethodInvoker(delegate
											{
												this.label1.Text = "Command:" + _eachscript;
											}));
											bool flag10 = _vararray.Count<string>() == 2;
											if (flag10)
											{
												this.cmdResult.sendtext = false;
												Random random4 = new Random();
												int count2 = random4.Next(Convert.ToInt32(_vararray[0]), Convert.ToInt32(_vararray[1]) + 1);
												Random random = new Random();
												string text7 = new string((from s in Enumerable.Repeat<string>("123456789", count2)
												select s[random.Next(s.Length)]).ToArray<char>());
												this.cmd.sendtext(text7);
												text = text + "send=" + text7;
												text += "|";
												text2 = text7;
												DateTime now = DateTime.Now;
												while (!this.cmdResult.sendtext)
												{
													bool flag11 = (DateTime.Now - now).Seconds >= 5;
													if (flag11)
													{
														break;
													}
													Thread.Sleep(100);
												}
											}
										}
									}
								}
								else if (text4 == "randomemaildomain")
								{
									this.label1.Invoke(new MethodInvoker(delegate
									{
										this.label1.Text = "Command:" + _eachscript;
									}));
									this.cmdResult.sendtext = false;
									Random random5 = new Random();
									string text8 = this.listemaildomain.ElementAt(random5.Next(0, this.listemaildomain.Count));
									this.cmd.sendtext("@" + text8);
									text = text + "send=@" + text8;
									text += "|";
									text2 = "@" + text8;
									DateTime now = DateTime.Now;
									while (!this.cmdResult.sendtext)
									{
										bool flag12 = (DateTime.Now - now).Seconds >= 5;
										if (flag12)
										{
											break;
										}
										Thread.Sleep(100);
									}
								}
							}
							else if (num != 1770621400u)
							{
								if (num == 1811393716u)
								{
									if (text4 == "sendvar")
									{
										this.label1.Invoke(new MethodInvoker(delegate
										{
											this.label1.Text = "Command:" + _eachscript;
										}));
										textvar textvar = list.FirstOrDefault((textvar x) => x.varname == _vararray[0]);
										bool flag13 = textvar != null;
										if (flag13)
										{
											text2 = textvar.varvalue;
											this.cmdResult.sendtext = false;
											this.cmd.sendtext(text2);
											text = text + "send=" + text2;
											text += "|";
											DateTime now = DateTime.Now;
											while (!this.cmdResult.sendtext)
											{
												bool flag14 = (DateTime.Now - now).Seconds >= 5;
												if (flag14)
												{
													break;
												}
												Thread.Sleep(100);
											}
										}
									}
								}
							}
							else if (text4 == "touch")
							{
								this.label1.Invoke(new MethodInvoker(delegate
								{
									this.label1.Text = "Command:" + _eachscript;
								}));
								bool flag15 = _vararray.Count<string>() == 2;
								if (flag15)
								{
									this.cmdResult.touch = false;
									this.cmd.touch(Convert.ToDouble(_vararray[0], this.usformat), Convert.ToDouble(_vararray[1], this.usformat));
									text = string.Concat(new string[]
									{
										text,
										"touch=",
										_vararray[0],
										" ",
										_vararray[1]
									});
									text += "|";
									DateTime now = DateTime.Now;
									while (!this.cmdResult.touch)
									{
										bool flag16 = (DateTime.Now - now).Seconds >= 5;
										if (flag16)
										{
											break;
										}
										Thread.Sleep(100);
									}
								}
							}
						}
						else if (num <= 2516915897u)
						{
							if (num <= 2301512864u)
							{
								if (num != 1919010991u)
								{
									if (num == 2301512864u)
									{
										if (text4 == "wait")
										{
											bool flag17 = _vararray.Count<string>() != 0;
											if (flag17)
											{
												Thread.Sleep((int)(Convert.ToDouble(_vararray[0], this.usformat) * 1000.0));
												text = text + "wait=" + _vararray[0];
												text += "|";
											}
										}
									}
								}
								else if (text4 == "send")
								{
									this.label1.Invoke(new MethodInvoker(delegate
									{
										this.label1.Text = "Command:" + _eachscript;
									}));
									Regex regex4 = new Regex("'(.*?)'");
									Match match4 = regex4.Match(_eachscript);
									bool success2 = match4.Success;
									if (success2)
									{
										this.cmdResult.sendtext = false;
										this.cmd.sendtext(match4.Groups[1].Value);
										text2 = match4.Groups[1].Value;
										text = text + "send=" + match4.Groups[1].Value;
										text += "|";
										DateTime now = DateTime.Now;
										while (!this.cmdResult.sendtext)
										{
											bool flag18 = (DateTime.Now - now).Seconds >= 5;
											if (flag18)
											{
												break;
											}
											Thread.Sleep(100);
										}
									}
								}
							}
							else if (num != 2355735947u)
							{
								if (num == 2516915897u)
								{
									if (text4 == "swipe")
									{
										this.label1.Invoke(new MethodInvoker(delegate
										{
											this.label1.Text = "Command:" + _eachscript;
										}));
										bool flag19 = _vararray.Count<string>() == 5;
										if (flag19)
										{
											double num3 = Convert.ToDouble(_vararray[0], this.usformat);
											double num4 = Convert.ToDouble(_vararray[1], this.usformat);
											double num5 = Convert.ToDouble(_vararray[2], this.usformat);
											double num6 = Convert.ToDouble(_vararray[3], this.usformat);
											double num7 = Convert.ToDouble(_vararray[4], this.usformat);
											double num8 = num7 / 0.01;
											double num9 = (num5 - num3) / num8;
											double num10 = (num6 - num4) / num8;
											for (int j = 0; j < (int)num8; j++)
											{
												this.cmd.mousedown((int)num3, (int)num4);
												num3 += num9;
												num4 += num10;
												Thread.Sleep(10);
												text = string.Concat(new string[]
												{
													text,
													"mousedown=",
													((int)num3).ToString(),
													" ",
													((int)num4).ToString()
												});
												text += "|";
											}
											this.cmdResult.touch = false;
											this.cmd.touch((double)((int)num5), (double)((int)num6));
											DateTime now = DateTime.Now;
											while (!this.cmdResult.touch)
											{
												bool flag20 = (DateTime.Now - now).Seconds >= 5;
												if (flag20)
												{
													break;
												}
												Thread.Sleep(100);
											}
											text = string.Concat(new string[]
											{
												text,
												"touch=",
												((int)num5).ToString(),
												" ",
												((int)num5).ToString()
											});
											text += "|";
										}
										else
										{
											bool flag21 = _vararray.Count<string>() == 6;
											if (flag21)
											{
												double num11 = Convert.ToDouble(_vararray[0], this.usformat);
												double num12 = Convert.ToDouble(_vararray[1], this.usformat);
												double num13 = Convert.ToDouble(_vararray[2], this.usformat);
												double num14 = Convert.ToDouble(_vararray[3], this.usformat);
												double num15 = Convert.ToDouble(_vararray[4], this.usformat);
												double num16 = Convert.ToDouble(_vararray[5], this.usformat);
												Random random6 = new Random();
												double num17 = (double)random6.Next((int)(num15 * 100.0), (int)(num16 * 100.0));
												double num18 = num17;
												double num19 = (num13 - num11) / num18;
												double num20 = (num14 - num12) / num18;
												for (int k = 0; k < (int)num18; k++)
												{
													this.cmd.mousedown((int)num11, (int)num12);
													num11 += num19;
													num12 += num20;
													Thread.Sleep(10);
													text = string.Concat(new string[]
													{
														text,
														"mousedown=",
														((int)num11).ToString(),
														" ",
														((int)num12).ToString()
													});
													text += "|";
												}
												this.cmdResult.touch = false;
												this.cmd.touch((double)((int)num13), (double)((int)num14));
												DateTime now = DateTime.Now;
												while (!this.cmdResult.touch)
												{
													bool flag22 = (DateTime.Now - now).Seconds >= 5;
													if (flag22)
													{
														break;
													}
													Thread.Sleep(100);
												}
												text = string.Concat(new string[]
												{
													text,
													"touch=",
													((int)num13).ToString(),
													" ",
													((int)num13).ToString()
												});
												text += "|";
											}
										}
									}
								}
							}
							else if (text4 == "randomfirstname")
							{
								this.label1.Invoke(new MethodInvoker(delegate
								{
									this.label1.Text = "Command:" + _eachscript;
								}));
								this.cmdResult.sendtext = false;
								Random random7 = new Random();
								string text9 = this.listfirstname.ElementAt(random7.Next(0, this.listfirstname.Count));
								this.cmd.sendtext(text9);
								text2 = text9;
								text = text + "send=" + text9;
								text += "|";
								DateTime now = DateTime.Now;
								while (!this.cmdResult.sendtext)
								{
									bool flag23 = (DateTime.Now - now).Seconds >= 5;
									if (flag23)
									{
										break;
									}
									Thread.Sleep(100);
								}
							}
						}
						else if (num <= 3429425863u)
						{
							if (num != 2875230837u)
							{
								if (num == 3429425863u)
								{
									if (text4 == "waitrandom")
									{
										bool flag24 = _vararray.Count<string>() == 2;
										if (flag24)
										{
											Random random8 = new Random();
											int num21 = random8.Next(Convert.ToInt32(_vararray[0]) * 1000, Convert.ToInt32(_vararray[1]) * 1000);
											Thread.Sleep(num21);
											text = text + "wait=" + (num21 / 1000).ToString();
											text += "|";
										}
									}
								}
							}
							else if (text4 == "randomlastname")
							{
								this.label1.Invoke(new MethodInvoker(delegate
								{
									this.label1.Text = "Command:" + _eachscript;
								}));
								this.cmdResult.sendtext = false;
								Random random9 = new Random();
								string text10 = this.listlastname.ElementAt(random9.Next(0, this.listfirstname.Count));
								this.cmd.sendtext(text10);
								text = text + "send=" + text10;
								text += "|";
								text2 = text10;
								DateTime now = DateTime.Now;
								while (!this.cmdResult.sendtext)
								{
									bool flag25 = (DateTime.Now - now).Seconds >= 5;
									if (flag25)
									{
										break;
									}
									Thread.Sleep(100);
								}
							}
						}
						else if (num != 3505689541u)
						{
							if (num != 3536692078u)
							{
								if (num == 3546203337u)
								{
									if (text4 == "open")
									{
										this.label1.Invoke(new MethodInvoker(delegate
										{
											this.label1.Text = "Command:" + _eachscript;
										}));
										Regex regex5 = new Regex("'(.*?)'");
										Match match5 = regex5.Match(_eachscript);
										bool success3 = match5.Success;
										if (success3)
										{
											this.cmd.openApp(match5.Groups[1].Value);
											text = text + "open=" + match5.Groups[1].Value;
											text += "|";
										}
									}
								}
							}
							else if (text4 == "randomemail")
							{
								this.label1.Invoke(new MethodInvoker(delegate
								{
									this.label1.Text = "Command:" + _eachscript;
								}));
								this.cmdResult.sendtext = false;
								Random random10 = new Random();
								string text11 = this.listlastname.ElementAt(random10.Next(0, this.listlastname.Count)).ToLower();
								text11 += this.listfirstname.ElementAt(random10.Next(0, this.listfirstname.Count)).ToLower();
								bool flag26 = random10.Next(0, 2) == 0;
								if (flag26)
								{
									text11 += random10.Next(0, 3000).ToString();
								}
								this.cmd.sendtext(text11);
								text = text + "send=" + text11;
								text += "|";
								text2 = text11;
								DateTime now = DateTime.Now;
								while (!this.cmdResult.sendtext)
								{
									bool flag27 = (DateTime.Now - now).Seconds >= 5;
									if (flag27)
									{
										break;
									}
									Thread.Sleep(100);
								}
							}
						}
						else if (text4 == "randomfromfiledel")
						{
							this.label1.Invoke(new MethodInvoker(delegate
							{
								this.label1.Text = "Command:" + _eachscript;
							}));
							string str2 = AppDomain.CurrentDomain.BaseDirectory + "TextFile";
							bool flag28 = File.Exists(str2 + "\\" + _vararray[0]);
							if (flag28)
							{
								string[] array4 = File.ReadAllLines(str2 + "\\" + _vararray[0]);
								Random random11 = new Random();
								int num22 = random11.Next(0, array4.Count<string>());
								string text12 = array4[num22];
								List<string> list2 = array4.ToList<string>();
								list2.RemoveAt(num22);
								array4 = list2.ToArray();
								File.WriteAllLines(str2 + "\\" + _vararray[0], array4);
								this.cmd.sendtext(text12);
								text = text + "send=" + text12;
								text += "|";
								text2 = text12;
								DateTime now = DateTime.Now;
								while (!this.cmdResult.sendtext)
								{
									bool flag29 = (DateTime.Now - now).Seconds >= 5;
									if (flag29)
									{
										break;
									}
									Thread.Sleep(100);
								}
							}
						}
						IL_16C0:
						bool flag30 = _script.Count<string>() == 2;
						if (flag30)
						{
							textvar textvar2 = list.FirstOrDefault((textvar x) => x.varname == _script[0]);
							bool flag31 = textvar2 == null;
							if (flag31)
							{
								list.Add(new textvar
								{
									varname = _script[0],
									varvalue = text2
								});
							}
							else
							{
								textvar2.varvalue = text2;
							}
						}
						goto IL_1731;
						goto IL_16C0;
					}
					IL_1731:;
				}
			}
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x0000CC58 File Offset: 0x0000AE58
		private void disableAll()
		{
			this.checkBox6.Enabled = false;
			this.checkBox7.Enabled = false;
			this.comboBox3.Enabled = false;
			this.listView7.Enabled = false;
			this.button33.Enabled = false;
			this.listView6.Enabled = false;
			this.button34.Enabled = false;
			this.button32.Enabled = false;
			this.checkBox1.Enabled = false;
			this.button3.Enabled = false;
			this.button4.Enabled = false;
			this.button5.Enabled = false;
			this.button6.Enabled = false;
			this.proxytool.Enabled = false;
			this.label5.Enabled = false;
			this.checkBox2.Enabled = false;
			this.checkBox3.Enabled = false;
			this.Reset.Enabled = false;
			this.ipAddressControl1.Enabled = false;
			this.numericUpDown1.Enabled = false;
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x0000CD6C File Offset: 0x0000AF6C
		private void enableAll()
		{
			this.checkBox6.Enabled = true;
			this.checkBox7.Enabled = this.checkBox6.Checked;
			this.comboBox3.Enabled = this.checkBox6.Checked;
			this.listView7.Enabled = true;
			this.button33.Enabled = true;
			this.listView6.Enabled = true;
			this.button34.Enabled = true;
			this.button32.Enabled = true;
			this.checkBox1.Enabled = true;
			this.button3.Enabled = (this.button7.Text == "START");
			this.checkBox2.Enabled = true;
			this.button4.Enabled = true;
			this.button5.Enabled = (this.button7.Text == "START");
			this.button6.Enabled = (this.button7.Text == "START");
			this.proxytool.Enabled = true;
			this.label5.Enabled = true;
			this.checkBox3.Enabled = this.checkBox1.Checked;
			this.Reset.Enabled = (this.button7.Text == "RESUME");
			this.ipAddressControl1.Enabled = true;
			this.numericUpDown1.Enabled = true;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x0000CEEC File Offset: 0x0000B0EC
		private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			ListViewItem listViewItem = this.listView1.Items[e.Index];
			bool flag = e.NewValue == CheckState.Checked;
			if (flag)
			{
				this.offerListItem.ElementAt(e.Index).offerEnable = true;
			}
			else
			{
				bool flag2 = e.NewValue == CheckState.Unchecked;
				if (flag2)
				{
					this.offerListItem.ElementAt(e.Index).offerEnable = false;
				}
			}
			this.saveofferlist();
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0000CF64 File Offset: 0x0000B164
		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			bool flag = this._clientSocket != null;
			if (flag)
			{
				this._clientSocket.Close();
				this._clientSocket.Dispose();
			}
			try
			{
				sshcommand.closebitvise((int)this.numericUpDown1.Value);
				this.bitproc.Kill();
			}
			catch (Exception)
			{
			}
			Application.Exit();
			Environment.Exit(0);
		}

		// Token: 0x060000AA RID: 170 RVA: 0x0000CFE4 File Offset: 0x0000B1E4
		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool flag = this.button7.Text == "STOP";
			if (flag)
			{
				bool flag2 = this.listView1.SelectedItems.Count > 0;
				if (flag2)
				{
					this.listView1.SelectedItems[0].Selected = false;
				}
			}
		}

		// Token: 0x060000AB RID: 171 RVA: 0x000021A5 File Offset: 0x000003A5
		private void tabPage3_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060000AC RID: 172 RVA: 0x0000D040 File Offset: 0x0000B240
		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.checkBox1.Checked;
			if (@checked)
			{
				this.comment.Enabled = true;
			}
			else
			{
				this.comment.Enabled = false;
			}
			this.checkBox3.Enabled = this.checkBox1.Checked;
			this.saveothersetting();
		}

		// Token: 0x060000AD RID: 173 RVA: 0x0000D09C File Offset: 0x0000B29C
		private void Reset_Click(object sender, EventArgs e)
		{
			this.runtime = 0;
			this.backuptime = 0;
			this.runoftime.Text = "Run:0";
			this.backupoftime.Text = "Backup:0";
			this.backuprate.Text = "Backup Rate:0%";
			bool flag = this.button7.Text == "STOP";
			if (flag)
			{
				this.button7_Click(null, null);
				this.button7.Refresh();
			}
			bool flag2 = this.button7.Text == "RESUME";
			if (flag2)
			{
				foreach (ListViewItem listViewItem in this.listView1.Items)
				{
					listViewItem.SubItems[0].ResetStyle();
					listViewItem.SubItems[1].ResetStyle();
					listViewItem.SubItems[2].ResetStyle();
					listViewItem.SubItems[3].ResetStyle();
					listViewItem.SubItems[4].ResetStyle();
					this.listView1.Refresh();
				}
				this.cmd.randomtouchstop();
				this.button7.Text = "START";
				this.button7.Refresh();
				bool flag3 = this.oThread != null;
				if (flag3)
				{
					bool flag4 = this.oThread.ThreadState != System.Threading.ThreadState.Unstarted;
					if (flag4)
					{
						bool flag5 = this.oThread.ThreadState == System.Threading.ThreadState.Suspended;
						if (flag5)
						{
							this.oThread.Resume();
							Thread.Sleep(100);
						}
						try
						{
							try
							{
								this.oThread.Abort();
							}
							catch (Exception)
							{
							}
						}
						catch (Exception)
						{
						}
					}
				}
				this.enableAll();
			}
		}

		// Token: 0x060000AE RID: 174 RVA: 0x0000D2AC File Offset: 0x0000B4AC
		private void importssh(string text)
		{
			string[] array = text.Split(new string[]
			{
				"\r\n"
			}, StringSplitOptions.None);
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string text2 = array2[i];
				string[] array3 = text2.Split(new string[]
				{
					"|"
				}, StringSplitOptions.None);
				bool flag = array3.Count<string>() == 1;
				if (flag)
				{
					string[] array4 = new string[]
					{
						array3[0],
						"root",
						"admin",
						"USA"
					};
					array3 = array4;
				}
				bool flag2 = array3.Count<string>() >= 3;
				if (flag2)
				{
					string text3 = array3[0];
					string[] array5 = text3.Split(new char[]
					{
						'.'
					});
					bool flag3 = true;
					bool flag4 = array5.Length == 4;
					if (flag4)
					{
						string[] array6 = array5;
						for (int j = 0; j < array6.Length; j++)
						{
							string s = array6[j];
							byte b = 0;
							bool flag5 = !byte.TryParse(s, out b);
							if (flag5)
							{
								flag3 = false;
							}
						}
					}
					else
					{
						flag3 = false;
					}
					bool flag6 = flag3;
					if (flag6)
					{
						ssh ssh = new ssh();
						ssh.IP = array3[0];
						ssh.username = array3[1];
						ssh.password = array3[2];
						bool flag7 = array3.Count<string>() > 3;
						if (flag7)
						{
							string[] array7 = array3[3].Split(new string[]
							{
								"("
							}, StringSplitOptions.None);
							ssh.country = array3[3];
							bool flag8 = array7.Count<string>() > 1;
							if (flag8)
							{
								ssh.country = Regex.Replace(array7[0], "\\s+", "");
							}
						}
						else
						{
							ssh.country = "unknown";
						}
						Regex regex = new Regex("\\((.*?)\\)");
						bool flag9 = array3.Count<string>() == 3;
						if (flag9)
						{
							Array.Resize<string>(ref array3, 4);
							array3[3] = "Unknown";
						}
						Match match = regex.Match(array3[3]);
						bool success = match.Success;
						if (success)
						{
							ssh.countrycode = match.Groups[1].Value.ToString();
						}
						else
						{
							ssh.countrycode = "Unknow";
						}
						ssh.live = "uncheck";
						ssh.used = false;
						this.listssh.Add(ssh);
						ListViewItem value = new ListViewItem(new string[]
						{
							ssh.IP,
							ssh.username,
							ssh.password,
							ssh.country
						});
						this.listView2.Items.Add(value);
					}
				}
			}
			bool flag10 = this.proxytool.Text == "SSH";
			if (flag10)
			{
				IEnumerable<ssh> arg_2E6_0 = this.listssh;
				Func<ssh, string> arg_2E6_1;
				if ((arg_2E6_1 = Form1.<>c.<>9__132_0) == null)
				{
					arg_2E6_1 = (Form1.<>c.<>9__132_0 = new Func<ssh, string>(Form1.<>c.<>9.<importssh>b__132_0));
				}
				IEnumerable<string> enumerable = arg_2E6_0.Select(arg_2E6_1).Distinct<string>();
				IEnumerable<string> arg_313_0 = enumerable;
				Func<string, string> arg_313_1;
				if ((arg_313_1 = Form1.<>c.<>9__132_1) == null)
				{
					arg_313_1 = (Form1.<>c.<>9__132_1 = new Func<string, string>(Form1.<>c.<>9.<importssh>b__132_1));
				}
				arg_313_0.OrderBy(arg_313_1);
				this.comboBox5.Items.Clear();
				foreach (string current in enumerable)
				{
					this.comboBox5.Items.Add(current);
				}
				bool flag11 = this.comboBox5.Items.Count > 0;
				if (flag11)
				{
					this.comboBox5.Text = this.comboBox5.Items[0].ToString();
				}
			}
			this.labeltotalssh.Text = "Total SSH:" + this.listView2.Items.Count.ToString();
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0000D6A0 File Offset: 0x0000B8A0
		private void importfromfile_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			bool flag = openFileDialog.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				string text = File.ReadAllText(openFileDialog.FileName);
				this.importssh(text);
				this.savessh();
				this.ssh_uncheck.Invoke(new MethodInvoker(delegate
				{
					Control arg_43_0 = this.ssh_uncheck;
					string arg_3E_0 = "Uncheck:";
					IEnumerable<ssh> arg_31_0 = this.listssh;
					Func<ssh, bool> arg_31_1;
					if ((arg_31_1 = Form1.<>c.<>9__133_1) == null)
					{
						arg_31_1 = (Form1.<>c.<>9__133_1 = new Func<ssh, bool>(Form1.<>c.<>9.<importfromfile_Click>b__133_1));
					}
					arg_43_0.Text = arg_3E_0 + arg_31_0.Count(arg_31_1).ToString();
					Control arg_8B_0 = this.ssh_used;
					string arg_86_0 = "Used:";
					IEnumerable<ssh> arg_79_0 = this.listssh;
					Func<ssh, bool> arg_79_1;
					if ((arg_79_1 = Form1.<>c.<>9__133_2) == null)
					{
						arg_79_1 = (Form1.<>c.<>9__133_2 = new Func<ssh, bool>(Form1.<>c.<>9.<importfromfile_Click>b__133_2));
					}
					arg_8B_0.Text = arg_86_0 + arg_79_0.Count(arg_79_1).ToString();
					Control arg_D3_0 = this.ssh_live;
					string arg_CE_0 = "Live:";
					IEnumerable<ssh> arg_C1_0 = this.listssh;
					Func<ssh, bool> arg_C1_1;
					if ((arg_C1_1 = Form1.<>c.<>9__133_3) == null)
					{
						arg_C1_1 = (Form1.<>c.<>9__133_3 = new Func<ssh, bool>(Form1.<>c.<>9.<importfromfile_Click>b__133_3));
					}
					arg_D3_0.Text = arg_CE_0 + arg_C1_0.Count(arg_C1_1).ToString();
					Control arg_11B_0 = this.ss_dead;
					string arg_116_0 = "Dead:";
					IEnumerable<ssh> arg_109_0 = this.listssh;
					Func<ssh, bool> arg_109_1;
					if ((arg_109_1 = Form1.<>c.<>9__133_4) == null)
					{
						arg_109_1 = (Form1.<>c.<>9__133_4 = new Func<ssh, bool>(Form1.<>c.<>9.<importfromfile_Click>b__133_4));
					}
					arg_11B_0.Text = arg_116_0 + arg_109_0.Count(arg_109_1).ToString();
				}));
			}
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00002210 File Offset: 0x00000410
		private void button14_Click(object sender, EventArgs e)
		{
			this.importssh(Clipboard.GetText());
			this.savessh();
			this.ssh_uncheck.Invoke(new MethodInvoker(delegate
			{
				Control arg_43_0 = this.ssh_uncheck;
				string arg_3E_0 = "Uncheck:";
				IEnumerable<ssh> arg_31_0 = this.listssh;
				Func<ssh, bool> arg_31_1;
				if ((arg_31_1 = Form1.<>c.<>9__134_1) == null)
				{
					arg_31_1 = (Form1.<>c.<>9__134_1 = new Func<ssh, bool>(Form1.<>c.<>9.<button14_Click>b__134_1));
				}
				arg_43_0.Text = arg_3E_0 + arg_31_0.Count(arg_31_1).ToString();
				Control arg_8B_0 = this.ssh_used;
				string arg_86_0 = "Used:";
				IEnumerable<ssh> arg_79_0 = this.listssh;
				Func<ssh, bool> arg_79_1;
				if ((arg_79_1 = Form1.<>c.<>9__134_2) == null)
				{
					arg_79_1 = (Form1.<>c.<>9__134_2 = new Func<ssh, bool>(Form1.<>c.<>9.<button14_Click>b__134_2));
				}
				arg_8B_0.Text = arg_86_0 + arg_79_0.Count(arg_79_1).ToString();
				Control arg_D3_0 = this.ssh_live;
				string arg_CE_0 = "Live:";
				IEnumerable<ssh> arg_C1_0 = this.listssh;
				Func<ssh, bool> arg_C1_1;
				if ((arg_C1_1 = Form1.<>c.<>9__134_3) == null)
				{
					arg_C1_1 = (Form1.<>c.<>9__134_3 = new Func<ssh, bool>(Form1.<>c.<>9.<button14_Click>b__134_3));
				}
				arg_D3_0.Text = arg_CE_0 + arg_C1_0.Count(arg_C1_1).ToString();
				Control arg_11B_0 = this.ss_dead;
				string arg_116_0 = "Dead:";
				IEnumerable<ssh> arg_109_0 = this.listssh;
				Func<ssh, bool> arg_109_1;
				if ((arg_109_1 = Form1.<>c.<>9__134_4) == null)
				{
					arg_109_1 = (Form1.<>c.<>9__134_4 = new Func<ssh, bool>(Form1.<>c.<>9.<button14_Click>b__134_4));
				}
				arg_11B_0.Text = arg_116_0 + arg_109_0.Count(arg_109_1).ToString();
			}));
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x0000D6F8 File Offset: 0x0000B8F8
		private void button24_Click(object sender, EventArgs e)
		{
			for (int i = this.listssh.Count - 1; i > 0; i--)
			{
				for (int j = i - 1; j >= 0; j--)
				{
					bool flag = this.listssh.ElementAt(i).IP == this.listssh.ElementAt(j).IP;
					if (flag)
					{
						this.listssh.RemoveAt(j);
						i--;
					}
				}
			}
			List<ssh> arg_9B_0 = this.listssh;
			Predicate<ssh> arg_9B_1;
			if ((arg_9B_1 = Form1.<>c.<>9__135_0) == null)
			{
				arg_9B_1 = (Form1.<>c.<>9__135_0 = new Predicate<ssh>(Form1.<>c.<>9.<button24_Click>b__135_0));
			}
			arg_9B_0.RemoveAll(arg_9B_1);
			IEnumerable<ssh> arg_C7_0 = this.listssh;
			Func<ssh, string> arg_C7_1;
			if ((arg_C7_1 = Form1.<>c.<>9__135_1) == null)
			{
				arg_C7_1 = (Form1.<>c.<>9__135_1 = new Func<ssh, string>(Form1.<>c.<>9.<button24_Click>b__135_1));
			}
			this.listssh = arg_C7_0.OrderBy(arg_C7_1).ToList<ssh>();
			foreach (ssh current in this.listssh)
			{
				current.used = false;
			}
			this.listView2.Items.Clear();
			foreach (ssh current2 in this.listssh)
			{
				ListViewItem listViewItem = new ListViewItem(new string[]
				{
					current2.IP,
					current2.username,
					current2.password,
					current2.country
				});
				bool flag2 = current2.live == "alive";
				if (flag2)
				{
					listViewItem.BackColor = Color.Lime;
				}
				bool flag3 = current2.live == "dead";
				if (flag3)
				{
					listViewItem.BackColor = Color.Red;
				}
				bool used = current2.used;
				if (used)
				{
					listViewItem.BackColor = Color.Aqua;
				}
				this.listView2.Items.Add(listViewItem);
			}
			this.savessh();
			this.ssh_uncheck.Invoke(new MethodInvoker(delegate
			{
				Control arg_43_0 = this.ssh_uncheck;
				string arg_3E_0 = "Uncheck:";
				IEnumerable<ssh> arg_31_0 = this.listssh;
				Func<ssh, bool> arg_31_1;
				if ((arg_31_1 = Form1.<>c.<>9__135_3) == null)
				{
					arg_31_1 = (Form1.<>c.<>9__135_3 = new Func<ssh, bool>(Form1.<>c.<>9.<button24_Click>b__135_3));
				}
				arg_43_0.Text = arg_3E_0 + arg_31_0.Count(arg_31_1).ToString();
				Control arg_8B_0 = this.ssh_used;
				string arg_86_0 = "Used:";
				IEnumerable<ssh> arg_79_0 = this.listssh;
				Func<ssh, bool> arg_79_1;
				if ((arg_79_1 = Form1.<>c.<>9__135_4) == null)
				{
					arg_79_1 = (Form1.<>c.<>9__135_4 = new Func<ssh, bool>(Form1.<>c.<>9.<button24_Click>b__135_4));
				}
				arg_8B_0.Text = arg_86_0 + arg_79_0.Count(arg_79_1).ToString();
				Control arg_D3_0 = this.ssh_live;
				string arg_CE_0 = "Live:";
				IEnumerable<ssh> arg_C1_0 = this.listssh;
				Func<ssh, bool> arg_C1_1;
				if ((arg_C1_1 = Form1.<>c.<>9__135_5) == null)
				{
					arg_C1_1 = (Form1.<>c.<>9__135_5 = new Func<ssh, bool>(Form1.<>c.<>9.<button24_Click>b__135_5));
				}
				arg_D3_0.Text = arg_CE_0 + arg_C1_0.Count(arg_C1_1).ToString();
				Control arg_11B_0 = this.ss_dead;
				string arg_116_0 = "Dead:";
				IEnumerable<ssh> arg_109_0 = this.listssh;
				Func<ssh, bool> arg_109_1;
				if ((arg_109_1 = Form1.<>c.<>9__135_6) == null)
				{
					arg_109_1 = (Form1.<>c.<>9__135_6 = new Func<ssh, bool>(Form1.<>c.<>9.<button24_Click>b__135_6));
				}
				arg_11B_0.Text = arg_116_0 + arg_109_0.Count(arg_109_1).ToString();
			}));
			this.labeltotalssh.Text = "Total SSH:" + this.listView2.Items.Count.ToString();
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000D980 File Offset: 0x0000BB80
		private void button8_Click(object sender, EventArgs e)
		{
			for (int i = this.listView2.SelectedItems.Count - 1; i >= 0; i--)
			{
				this.listssh.RemoveAt(this.listView2.SelectedItems[i].Index);
				this.listView2.Items.Remove(this.listView2.SelectedItems[i]);
			}
			this.savessh();
			this.ssh_uncheck.Invoke(new MethodInvoker(delegate
			{
				Control arg_43_0 = this.ssh_uncheck;
				string arg_3E_0 = "Uncheck:";
				IEnumerable<ssh> arg_31_0 = this.listssh;
				Func<ssh, bool> arg_31_1;
				if ((arg_31_1 = Form1.<>c.<>9__136_1) == null)
				{
					arg_31_1 = (Form1.<>c.<>9__136_1 = new Func<ssh, bool>(Form1.<>c.<>9.<button8_Click>b__136_1));
				}
				arg_43_0.Text = arg_3E_0 + arg_31_0.Count(arg_31_1).ToString();
				Control arg_8B_0 = this.ssh_used;
				string arg_86_0 = "Used:";
				IEnumerable<ssh> arg_79_0 = this.listssh;
				Func<ssh, bool> arg_79_1;
				if ((arg_79_1 = Form1.<>c.<>9__136_2) == null)
				{
					arg_79_1 = (Form1.<>c.<>9__136_2 = new Func<ssh, bool>(Form1.<>c.<>9.<button8_Click>b__136_2));
				}
				arg_8B_0.Text = arg_86_0 + arg_79_0.Count(arg_79_1).ToString();
				Control arg_D3_0 = this.ssh_live;
				string arg_CE_0 = "Live:";
				IEnumerable<ssh> arg_C1_0 = this.listssh;
				Func<ssh, bool> arg_C1_1;
				if ((arg_C1_1 = Form1.<>c.<>9__136_3) == null)
				{
					arg_C1_1 = (Form1.<>c.<>9__136_3 = new Func<ssh, bool>(Form1.<>c.<>9.<button8_Click>b__136_3));
				}
				arg_D3_0.Text = arg_CE_0 + arg_C1_0.Count(arg_C1_1).ToString();
				Control arg_11B_0 = this.ss_dead;
				string arg_116_0 = "Dead:";
				IEnumerable<ssh> arg_109_0 = this.listssh;
				Func<ssh, bool> arg_109_1;
				if ((arg_109_1 = Form1.<>c.<>9__136_4) == null)
				{
					arg_109_1 = (Form1.<>c.<>9__136_4 = new Func<ssh, bool>(Form1.<>c.<>9.<button8_Click>b__136_4));
				}
				arg_11B_0.Text = arg_116_0 + arg_109_0.Count(arg_109_1).ToString();
			}));
			this.labeltotalssh.Text = "Total SSH:" + this.listView2.Items.Count.ToString();
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x0000223E File Offset: 0x0000043E
		private void button22_Click(object sender, EventArgs e)
		{
			this.listssh.Clear();
			this.listView2.Items.Clear();
			this.savessh();
			this.labeltotalssh.Text = "Total SSH:0";
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0000DA48 File Offset: 0x0000BC48
		private void button25_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			bool flag = saveFileDialog.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				string text = "";
				foreach (ssh current in this.listssh)
				{
					text = string.Concat(new string[]
					{
						text,
						current.IP,
						"|",
						current.username,
						"|",
						current.password,
						"|",
						current.country,
						"|",
						current.countrycode
					});
					text += "\r\n";
				}
				File.WriteAllText(saveFileDialog.FileName, text);
			}
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x0000DB38 File Offset: 0x0000BD38
		private void threadchecklive(List<ListViewItem> _items)
		{
			using (List<ListViewItem>.Enumerator enumerator = _items.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ListViewItem _item = enumerator.Current;
					this.listView2.Invoke(new MethodInvoker(delegate
					{
						_item.SubItems[0].BackColor = Color.Yellow;
						this.listView2.Refresh();
					}));
					try
					{
						using (SshClient sshClient = new SshClient(_item.SubItems[0].Text, _item.SubItems[1].Text, _item.SubItems[2].Text))
						{
							sshClient.KeepAliveInterval = new TimeSpan(0, 0, 30);
							sshClient.ConnectionInfo.Timeout = new TimeSpan(0, 0, 15);
							try
							{
								sshClient.Connect();
								this.listView2.Invoke(new MethodInvoker(delegate
								{
									_item.SubItems[0].BackColor = Color.Lime;
									this.listssh.ElementAt(_item.Index).live = "alive";
									this.listView2.Refresh();
									this.savessh();
									this.ssh_uncheck.Invoke(new MethodInvoker(this.<threadchecklive>b__139_2));
								}));
							}
							catch (Exception var_3_D3)
							{
								this.listView2.Invoke(new MethodInvoker(delegate
								{
									_item.SubItems[0].BackColor = Color.Red;
									this.listssh.ElementAt(_item.Index).live = "dead";
									this.listView2.Refresh();
								}));
							}
						}
					}
					catch (Exception)
					{
					}
					this.ssh_uncheck.Invoke(new MethodInvoker(delegate
					{
						Control arg_43_0 = this.ssh_uncheck;
						string arg_3E_0 = "Uncheck:";
						IEnumerable<ssh> arg_31_0 = this.listssh;
						Func<ssh, bool> arg_31_1;
						if ((arg_31_1 = Form1.<>c.<>9__139_9) == null)
						{
							arg_31_1 = (Form1.<>c.<>9__139_9 = new Func<ssh, bool>(Form1.<>c.<>9.<threadchecklive>b__139_9));
						}
						arg_43_0.Text = arg_3E_0 + arg_31_0.Count(arg_31_1).ToString();
						Control arg_8B_0 = this.ssh_used;
						string arg_86_0 = "Used:";
						IEnumerable<ssh> arg_79_0 = this.listssh;
						Func<ssh, bool> arg_79_1;
						if ((arg_79_1 = Form1.<>c.<>9__139_10) == null)
						{
							arg_79_1 = (Form1.<>c.<>9__139_10 = new Func<ssh, bool>(Form1.<>c.<>9.<threadchecklive>b__139_10));
						}
						arg_8B_0.Text = arg_86_0 + arg_79_0.Count(arg_79_1).ToString();
						Control arg_D3_0 = this.ssh_live;
						string arg_CE_0 = "Live:";
						IEnumerable<ssh> arg_C1_0 = this.listssh;
						Func<ssh, bool> arg_C1_1;
						if ((arg_C1_1 = Form1.<>c.<>9__139_11) == null)
						{
							arg_C1_1 = (Form1.<>c.<>9__139_11 = new Func<ssh, bool>(Form1.<>c.<>9.<threadchecklive>b__139_11));
						}
						arg_D3_0.Text = arg_CE_0 + arg_C1_0.Count(arg_C1_1).ToString();
						Control arg_11B_0 = this.ss_dead;
						string arg_116_0 = "Dead:";
						IEnumerable<ssh> arg_109_0 = this.listssh;
						Func<ssh, bool> arg_109_1;
						if ((arg_109_1 = Form1.<>c.<>9__139_12) == null)
						{
							arg_109_1 = (Form1.<>c.<>9__139_12 = new Func<ssh, bool>(Form1.<>c.<>9.<threadchecklive>b__139_12));
						}
						arg_11B_0.Text = arg_116_0 + arg_109_0.Count(arg_109_1).ToString();
					}));
				}
			}
			this.savessh();
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x0000DCEC File Offset: 0x0000BEEC
		private void button9_Click(object sender, EventArgs e)
		{
			bool flag = this.button9.Text == "Check Live";
			if (flag)
			{
				Form1.<>c__DisplayClass140_0 <>c__DisplayClass140_ = new Form1.<>c__DisplayClass140_0();
				<>c__DisplayClass140_.<>4__this = this;
				<>c__DisplayClass140_.listitems = new List<ListViewItem>[(int)this.numericUpDown2.Value];
				int num = 0;
				while (num < this.numericUpDown2.Value)
				{
					<>c__DisplayClass140_.listitems[num] = new List<ListViewItem>();
					num++;
				}
				int i = 0;
				int num2 = 0;
				while (i < this.listView2.Items.Count)
				{
					ListViewItem item = this.listView2.Items[i];
					<>c__DisplayClass140_.listitems[num2].Add(item);
					i++;
					num2++;
					bool flag2 = num2 >= (int)this.numericUpDown2.Value;
					if (flag2)
					{
						num2 = 0;
					}
				}
				int k;
				int j;
				for (j = 0; j < (int)this.numericUpDown2.Value; j = k + 1)
				{
					bool flag3 = <>c__DisplayClass140_.listitems[j].Count > 0;
					if (flag3)
					{
						Thread thread = new Thread(delegate
						{
							<>c__DisplayClass140_.<>4__this.threadchecklive(<>c__DisplayClass140_.listitems[j]);
						});
						thread.Start();
						Thread.Sleep(100);
					}
					k = j;
				}
			}
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x0000DE78 File Offset: 0x0000C078
		private void button23_Click(object sender, EventArgs e)
		{
			bool flag = this.button23.Text.Contains("Disable");
			if (flag)
			{
				this.cmd.disableProxy();
				this.button23.Text = "Enable Proxy";
				this.button23.BackColor = Color.Aqua;
			}
			else
			{
				string text = this.ipAddressControl1.Text;
				string[] array = text.Split(new string[]
				{
					"."
				}, StringSplitOptions.None);
				bool flag2 = true;
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					string a = array2[i];
					bool flag3 = a == "";
					if (flag3)
					{
						flag2 = false;
						break;
					}
				}
				bool flag4 = !flag2;
				if (flag4)
				{
					MessageBox.Show("IP Forwarding invalid!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					Thread thread = new Thread(new ThreadStart(this.threadsetsock));
					thread.Start();
				}
			}
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x0000DF6C File Offset: 0x0000C16C
		private void threadsetsock()
		{
			this.cmdResult.changeport = false;
			this.cmd.setProxy(this.ipAddressControl1.Text, (int)this.numericUpDown1.Value);
			DateTime now = DateTime.Now;
			while (!this.cmdResult.changeport)
			{
				Thread.Sleep(100);
				bool flag = (DateTime.Now - now).TotalSeconds > 10.0;
				if (flag)
				{
					this.button2.Invoke(new MethodInvoker(delegate
					{
						bool flag2 = this.button2.Text == "Disconnect";
						if (flag2)
						{
							this.button2_Click(null, null);
						}
					}));
					return;
				}
			}
			MessageBox.Show("Set proxy done.");
			this.button23.Invoke(new MethodInvoker(delegate
			{
				this.button23.Text = "Disable Proxy";
				this.button23.BackColor = Color.Red;
				this.oriadd = this.ipAddressControl1.Text;
				this.oriport = (int)this.numericUpDown1.Value;
			}));
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x000021A5 File Offset: 0x000003A5
		private void listView2_KeyPress(object sender, KeyPressEventArgs e)
		{
		}

		// Token: 0x060000BA RID: 186 RVA: 0x0000E034 File Offset: 0x0000C234
		private void listView2_KeyDown(object sender, KeyEventArgs e)
		{
			bool flag = e.KeyCode == Keys.Delete;
			if (flag)
			{
				this.button8_Click(null, null);
			}
		}

		// Token: 0x060000BB RID: 187 RVA: 0x0000E05C File Offset: 0x0000C25C
		private void Applyvip_Click(object sender, EventArgs e)
		{
			string text = this.ipAddressControl1.Text;
			string[] array = text.Split(new string[]
			{
				"."
			}, StringSplitOptions.None);
			bool flag = true;
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string a = array2[i];
				bool flag2 = a == "";
				if (flag2)
				{
					flag = false;
					break;
				}
			}
			bool flag3 = !flag;
			if (flag3)
			{
				MessageBox.Show("IP Forwarding invalid!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				Thread thread = new Thread(new ThreadStart(this.threadsetsock));
				thread.Start();
			}
		}

		// Token: 0x060000BC RID: 188 RVA: 0x0000E100 File Offset: 0x0000C300
		private void proxytool_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool flag = this.proxytool.Text == "SSH";
			if (flag)
			{
				IEnumerable<ssh> arg_43_0 = this.listssh;
				Func<ssh, string> arg_43_1;
				if ((arg_43_1 = Form1.<>c.<>9__146_0) == null)
				{
					arg_43_1 = (Form1.<>c.<>9__146_0 = new Func<ssh, string>(Form1.<>c.<>9.<proxytool_SelectedIndexChanged>b__146_0));
				}
				IEnumerable<string> enumerable = arg_43_0.Select(arg_43_1).Distinct<string>();
				this.comboBox5.Items.Clear();
				foreach (string current in enumerable)
				{
					this.comboBox5.Items.Add(current);
				}
				bool flag2 = this.comboBox5.Items.Count > 0;
				if (flag2)
				{
					this.comboBox5.Text = this.comboBox5.Items[0].ToString();
				}
			}
			else
			{
				bool flag3 = this.proxytool.Text == "Vip72";
				if (flag3)
				{
					this.comboBox5.Items.Clear();
					foreach (countrycode current2 in this.listcountrycode)
					{
						this.comboBox5.Items.Add(current2.country);
					}
					this.comboBox5.SelectedIndex = 0;
				}
				else
				{
					bool flag4 = this.proxytool.Text == "SSHServer";
					if (flag4)
					{
						HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(this.sshserverurl + "/Home/countrylist");
						httpWebRequest.UserAgent = "autoleadios";
						try
						{
							Stream responseStream = httpWebRequest.GetResponse().GetResponseStream();
							StreamReader streamReader = new StreamReader(responseStream);
							string text = streamReader.ReadToEnd();
							string[] items = text.Split(new string[]
							{
								"|"
							}, StringSplitOptions.None);
							this.comboBox5.Items.Clear();
							this.comboBox5.Items.AddRange(items);
							this.comboBox5.SelectedIndex = 0;
						}
						catch (Exception var_14_21E)
						{
						}
					}
					else
					{
						this.comboBox5.Items.Clear();
					}
				}
			}
			this.saveothersetting();
		}

		// Token: 0x060000BD RID: 189 RVA: 0x000021A5 File Offset: 0x000003A5
		private void tabPage4_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000E378 File Offset: 0x0000C578
		private void button15_Click(object sender, EventArgs e)
		{
			this.listbackup.Clear();
			this.listView4.Items.Clear();
			this.label34.Text = "Total RRS:0";
			this.label35.Text = "Selected RRS:0";
			bool flag = this.button15.Text == "Get Backup list";
			if (flag)
			{
				this.button15.Text = "Getting...";
				this.button15.Enabled = false;
				Thread thread = new Thread(new ThreadStart(this.threadgetbk));
				thread.Start();
			}
		}

		// Token: 0x060000BF RID: 191 RVA: 0x0000E418 File Offset: 0x0000C618
		private void threadgetbk()
		{
			this.cmdResult.getbackup = false;
			this.cmd.getbackup();
			DateTime now = DateTime.Now;
			while (!this.cmdResult.getbackup)
			{
				bool flag = (DateTime.Now - now).TotalSeconds > 20.0;
				if (flag)
				{
					break;
				}
				Thread.Sleep(100);
			}
			this.button15.Invoke(new MethodInvoker(delegate
			{
				this.button15.Text = "Get Backup list";
				this.button15.Enabled = true;
				this.button15.Refresh();
			}));
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0000E4A0 File Offset: 0x0000C6A0
		private void rrsdisableall()
		{
			this.button15.Enabled = false;
			this.button16.Enabled = false;
			this.button17.Enabled = false;
			this.bkreset.Enabled = false;
			this.button27.Enabled = false;
			this.button29.Enabled = false;
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x0000E4FC File Offset: 0x0000C6FC
		private void rssenableall()
		{
			this.button29.Enabled = true;
			this.button27.Enabled = true;
			this.button15.Enabled = true;
			this.button16.Enabled = (this.button19.Text == "START");
			this.button17.Enabled = (this.button19.Text == "START");
			this.bkreset.Enabled = (this.button19.Text == "RESUME");
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x0000E594 File Offset: 0x0000C794
		private void button19_Click(object sender, EventArgs e)
		{
			bool flag = this.button19.Text == "START" || this.button19.Text == "RESUME";
			if (flag)
			{
				bool flag2 = this.button19.Text == "RESUME";
				if (flag2)
				{
					this.cmd.randomtouchresume();
				}
				this.runningstt = 2;
				this.rrsdisableall();
				this.button19.Text = "STOP";
				bool flag3 = this.button7.Text == "STOP";
				if (flag3)
				{
					this.button7_Click(null, null);
				}
				this.button7.Enabled = false;
				bool flag4 = this.bkThread == null || (this.bkThread.ThreadState & System.Threading.ThreadState.Stopped) == System.Threading.ThreadState.Stopped;
				if (flag4)
				{
					this.bkThread = new Thread(new ThreadStart(this.autoRRS));
				}
				bool flag5 = (this.bkThread.ThreadState & System.Threading.ThreadState.Suspended) == System.Threading.ThreadState.Suspended;
				if (flag5)
				{
					this.bkThread.Resume();
				}
				else
				{
					bool flag6 = (this.bkThread.ThreadState & System.Threading.ThreadState.Unstarted) == System.Threading.ThreadState.Unstarted || (this.bkThread.ThreadState & System.Threading.ThreadState.AbortRequested) == System.Threading.ThreadState.AbortRequested || (this.bkThread.ThreadState & System.Threading.ThreadState.Aborted) == System.Threading.ThreadState.Aborted || (this.bkThread.ThreadState & System.Threading.ThreadState.Stopped) == System.Threading.ThreadState.Stopped;
					if (flag6)
					{
						this.bkThread = new Thread(new ThreadStart(this.autoRRS));
						this.bkThread.Start();
					}
				}
			}
			else
			{
				this.runningstt = 0;
				this.cmd.randomtouchpause();
				this.button19.Text = "RESUME";
				this.button19.Refresh();
				this.rssenableall();
				this.button7.Enabled = true;
				try
				{
					this.bkThread.Suspend();
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x0000E7A4 File Offset: 0x0000C9A4
		private void button16_Click(object sender, EventArgs e)
		{
			string text = "";
			int i;
			int j;
			for (i = this.listView4.SelectedItems.Count - 1; i >= 0; i = j - 1)
			{
				text += this.listView4.SelectedItems[i].SubItems[7].Text;
				text += ";";
				this.listbackup.RemoveAll((backup x) => x.filename == this.listView4.SelectedItems[i].SubItems[7].Text);
				this.listView4.Items.Remove(this.listView4.SelectedItems[i]);
				j = i;
			}
			this.cmd.deletebackup(text);
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000E88C File Offset: 0x0000CA8C
		private void button17_Click(object sender, EventArgs e)
		{
			bool flag = MessageBox.Show("Bạn có chắc muốn xóa tất cả rrs không?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
			if (flag)
			{
				string text = "";
				foreach (backup current in this.listbackup)
				{
					text += current.filename;
					text += ";";
				}
				this.cmd.deletebackup(text);
				this.listbackup.Clear();
				this.listView4.Items.Clear();
				this.label34.Text = "Total RRS:0";
				this.label35.Text = "Selected RRS:0";
			}
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x0000E968 File Offset: 0x0000CB68
		private void listView4_KeyDown(object sender, KeyEventArgs e)
		{
			bool flag = e.KeyCode == Keys.Delete;
			if (flag)
			{
				this.button16_Click(null, null);
			}
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000E990 File Offset: 0x0000CB90
		private void autoRRS()
		{
			Random random = new Random();
			using (List<backup>.Enumerator enumerator = this.listbackup.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					Form1.<>c__DisplayClass156_0 <>c__DisplayClass156_ = new Form1.<>c__DisplayClass156_0();
					<>c__DisplayClass156_.<>4__this = this;
					<>c__DisplayClass156_.item = enumerator.Current;
					Form1.<>c__DisplayClass156_1 <>c__DisplayClass156_2 = new Form1.<>c__DisplayClass156_1();
					<>c__DisplayClass156_2.CS$<>8__locals1 = <>c__DisplayClass156_;
					<>c__DisplayClass156_2.ckenable = false;
					backup item = <>c__DisplayClass156_2.CS$<>8__locals1.item;
					<>c__DisplayClass156_2.currentlistview = null;
					this.listView4.Invoke(new MethodInvoker(delegate
					{
						foreach (ListViewItem listViewItem in <>c__DisplayClass156_2.CS$<>8__locals1.<>4__this.listView4.Items)
						{
							bool flag24 = listViewItem.SubItems[7].Text == <>c__DisplayClass156_2.CS$<>8__locals1.item.filename;
							if (flag24)
							{
								<>c__DisplayClass156_2.currentlistview = listViewItem;
								break;
							}
						}
						<>c__DisplayClass156_2.ckenable = <>c__DisplayClass156_2.currentlistview.Checked;
					}));
					bool flag = <>c__DisplayClass156_2.ckenable && <>c__DisplayClass156_2.currentlistview != null;
					if (flag)
					{
						Form1.<>c__DisplayClass156_2 <>c__DisplayClass156_3 = new Form1.<>c__DisplayClass156_2();
						<>c__DisplayClass156_3.CS$<>8__locals2 = <>c__DisplayClass156_2;
						base.Invoke(new MethodInvoker(<>c__DisplayClass156_3.CS$<>8__locals2.<autoRRS>b__1));
						string text = "";
						foreach (string current in <>c__DisplayClass156_3.CS$<>8__locals2.CS$<>8__locals1.item.appList)
						{
							text += current;
							text += ";";
						}
						this.cmdResult.wipe = false;
						this.cmd.close("all");
						<>c__DisplayClass156_3.wipechoose = false;
						this.checkBox2.Invoke(new MethodInvoker(delegate
						{
							<>c__DisplayClass156_3.CS$<>8__locals2.CS$<>8__locals1.<>4__this.label1.Text = "Wiping Application data...";
							bool checked3 = <>c__DisplayClass156_3.CS$<>8__locals2.CS$<>8__locals1.<>4__this.checkBox2.Checked;
							if (checked3)
							{
								<>c__DisplayClass156_3.wipechoose = true;
							}
						}));
						this.cmd.faketype(this.getrandomdevice());
						bool @checked = this.fakeversion.Checked;
						if (@checked)
						{
							bool flag2 = this.checkBox14.Checked || this.checkBox15.Checked;
							if (flag2)
							{
								bool flag3 = this.checkBox14.Checked && this.checkBox15.Checked;
								string text2;
								if (flag3)
								{
									Random random2 = new Random();
									text2 = random2.Next(8, 10).ToString();
								}
								else
								{
									bool checked2 = this.checkBox14.Checked;
									if (checked2)
									{
										text2 = "8";
									}
									else
									{
										text2 = "9";
									}
								}
								this.cmd.fakeversion(text2);
							}
						}
						this.cmd.randominfo();
						bool wipechoose = <>c__DisplayClass156_3.wipechoose;
						if (wipechoose)
						{
							this.cmd.wipefull(text);
						}
						else
						{
							this.cmd.wipe(text);
						}
						DateTime now = DateTime.Now;
						this.button2.Invoke(new MethodInvoker(delegate
						{
							this.maxwait = (int)this.numericUpDown10.Value;
						}));
						while (!this.cmdResult.wipe)
						{
							Thread.Sleep(500);
							bool flag4 = (DateTime.Now - now).TotalSeconds > (double)this.maxwait;
							if (flag4)
							{
								this.button2.Invoke(new MethodInvoker(delegate
								{
									bool flag24 = this.button2.Text == "Disconnect";
									if (flag24)
									{
										this.button2_Click(null, null);
									}
								}));
								return;
							}
							this.cmd.checkwipe();
						}
						string text3;
						while (true)
						{
							<>c__DisplayClass156_3.proxytype = "SSH";
							this.proxytool.Invoke(new MethodInvoker(delegate
							{
								<>c__DisplayClass156_3.proxytype = <>c__DisplayClass156_3.CS$<>8__locals2.CS$<>8__locals1.<>4__this.proxytool.Text;
							}));
							Thread.Sleep(10);
							bool flag5 = <>c__DisplayClass156_3.proxytype != "Direct";
							if (flag5)
							{
							}
							<>c__DisplayClass156_3.svip = false;
							base.Invoke(new MethodInvoker(delegate
							{
								<>c__DisplayClass156_3.svip = <>c__DisplayClass156_3.CS$<>8__locals2.CS$<>8__locals1.<>4__this.sameVip.Checked;
							}));
							bool flag6 = !<>c__DisplayClass156_3.svip;
							object arg;
							if (flag6)
							{
								arg = new Vip72();
							}
							else
							{
								arg = new Vip72Chung();
							}
							if (Form1.<>o__156.<>p__0 == null)
							{
								Form1.<>o__156.<>p__0 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "waitiotherVIP72", null, typeof(Form1), new CSharpArgumentInfo[]
								{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
								}));
							}
							Form1.<>o__156.<>p__0.Target(Form1.<>o__156.<>p__0, arg);
							bool flag7 = <>c__DisplayClass156_3.proxytype == "SSH";
							if (flag7)
							{
								if (Form1.<>o__156.<>p__1 == null)
								{
									Form1.<>o__156.<>p__1 = CallSite<Action<CallSite, object, int>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "clearIpWithPort", null, typeof(Form1), new CSharpArgumentInfo[]
									{
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
									}));
								}
								Form1.<>o__156.<>p__1.Target(Form1.<>o__156.<>p__1, arg, (int)this.numericUpDown1.Value);
								sshcommand.closebitvise((int)this.numericUpDown1.Value);
								try
								{
									bool flag8 = !this.bitproc.HasExited;
									if (flag8)
									{
										this.bitproc.Kill();
									}
								}
								catch (Exception)
								{
								}
								while (true)
								{
									string curcontry = "";
									this.label1.Invoke(new MethodInvoker(delegate
									{
										curcontry = <>c__DisplayClass156_3.CS$<>8__locals2.CS$<>8__locals1.<>4__this.comboBox5.Text;
										<>c__DisplayClass156_3.CS$<>8__locals2.CS$<>8__locals1.<>4__this.label1.Text = "Checking SSH....";
									}));
									ssh _getssh = this.listssh.FirstOrDefault((ssh x) => x.live != "dead" && !x.used && x.country == curcontry);
									bool check32 = false;
									this.label1.Invoke(new MethodInvoker(delegate
									{
										check32 = <>c__DisplayClass156_3.CS$<>8__locals2.CS$<>8__locals1.<>4__this.checkBox17.Checked;
									}));
									bool flag9 = _getssh == null;
									if (flag9)
									{
										break;
									}
									Random random3 = new Random();
									int randomssh = random3.Next(0, this.listssh.Count);
									while (this.listssh.ElementAt(randomssh).live == "dead" || this.listssh.ElementAt(randomssh).used || this.listssh.ElementAt(randomssh).country != curcontry)
									{
										randomssh = random3.Next(0, this.listssh.Count);
									}
									_getssh = this.listssh.ElementAt(randomssh);
									_getssh.used = true;
									this.curip = _getssh.IP;
									this.listView2.Invoke(new MethodInvoker(delegate
									{
										<>c__DisplayClass156_3.CS$<>8__locals2.CS$<>8__locals1.<>4__this.listView2.Items[randomssh].BackColor = Color.Aqua;
										<>c__DisplayClass156_3.CS$<>8__locals2.CS$<>8__locals1.<>4__this.listView2.Refresh();
										<>c__DisplayClass156_3.CS$<>8__locals2.CS$<>8__locals1.<>4__this.savessh();
										<>c__DisplayClass156_3.CS$<>8__locals2.CS$<>8__locals1.<>4__this.ssh_uncheck.Invoke(new MethodInvoker(<>c__DisplayClass156_3.CS$<>8__locals2.CS$<>8__locals1.<>4__this.<autoRRS>b__156_13));
									}));
									this.curip = _getssh.IP;
									bool flag10 = sshcommand.SetSSH(_getssh.IP, _getssh.username, _getssh.password, this.ipAddressControl1.Text, this.numericUpDown1.Value.ToString(), ref this.bitproc);
									if (flag10)
									{
										goto Block_24;
									}
									_getssh.live = "dead";
									this.listView2.Invoke(new MethodInvoker(delegate
									{
										<>c__DisplayClass156_3.CS$<>8__locals2.CS$<>8__locals1.<>4__this.listView2.Items[<>c__DisplayClass156_3.CS$<>8__locals2.CS$<>8__locals1.<>4__this.listssh.IndexOf(_getssh)].BackColor = Color.Red;
										<>c__DisplayClass156_3.CS$<>8__locals2.CS$<>8__locals1.<>4__this.listView2.Refresh();
										<>c__DisplayClass156_3.CS$<>8__locals2.CS$<>8__locals1.<>4__this.savessh();
										<>c__DisplayClass156_3.CS$<>8__locals2.CS$<>8__locals1.<>4__this.ssh_uncheck.Invoke(new MethodInvoker(<>c__DisplayClass156_3.CS$<>8__locals2.CS$<>8__locals1.<>4__this.<autoRRS>b__156_19));
									}));
								}
								bool flag11 = !<>c__DisplayClass156_4.check32;
								if (flag11)
								{
									MessageBox.Show("All SSH are used or dead, please update new SSH list!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
									this.label1.Invoke(new MethodInvoker(delegate
									{
										this.button7_Click(null, null);
									}));
								}
								else
								{
									this.label1.Invoke(new MethodInvoker(delegate
									{
										this.button24_Click(null, null);
									}));
								}
							}
							else
							{
								bool flag12 = <>c__DisplayClass156_3.proxytype == "Vip72";
								if (!flag12)
								{
									goto IL_D62;
								}
								Form1.<>c__DisplayClass156_4 <>c__DisplayClass156_5 = new Form1.<>c__DisplayClass156_4();
								<>c__DisplayClass156_5.CS$<>8__locals4 = <>c__DisplayClass156_3;
								try
								{
									sshcommand.closebitvise((int)this.numericUpDown1.Value);
									bool flag13 = !this.bitproc.HasExited;
									if (flag13)
									{
										this.bitproc.Kill();
									}
								}
								catch (Exception)
								{
								}
								this.label1.Invoke(new MethodInvoker(delegate
								{
									this.label1.Text = "Đang đợi Để sử dụng Vip72...";
								}));
								if (Form1.<>o__156.<>p__2 == null)
								{
									Form1.<>o__156.<>p__2 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "waitiotherVIP72", null, typeof(Form1), new CSharpArgumentInfo[]
									{
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
									}));
								}
								Form1.<>o__156.<>p__2.Target(Form1.<>o__156.<>p__2, arg);
								this.label1.Invoke(new MethodInvoker(delegate
								{
									this.label1.Text = "Getting Vip72 IP...";
								}));
								Form1.<>c__DisplayClass156_4 arg_832_0 = <>c__DisplayClass156_5;
								IEnumerable<vipaccount> arg_82D_0 = this.listvipacc;
								Func<vipaccount, bool> arg_82D_1;
								if ((arg_82D_1 = Form1.<>c.<>9__156_26) == null)
								{
									arg_82D_1 = (Form1.<>c.<>9__156_26 = new Func<vipaccount, bool>(Form1.<>c.<>9.<autoRRS>b__156_26));
								}
								arg_832_0.vipacc = arg_82D_0.FirstOrDefault(arg_82D_1);
								bool flag14 = <>c__DisplayClass156_5.vipacc == null;
								if (flag14)
								{
									bool flag15 = this.listvipacc.Count == 0;
									if (flag15)
									{
										MessageBox.Show("All vip72 are limited or there is no account, Please add other Vip72 account to use", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
										this.label1.Invoke(new MethodInvoker(delegate
										{
											this.label1.Text = "Vip72 account is out";
										}));
										this.button7.Invoke(new MethodInvoker(delegate
										{
											bool flag24 = this.button7.Text == "STOP";
											if (flag24)
											{
												this.button7_Click(null, null);
											}
											bool flag25 = this.button19.Text == "STOP";
											if (flag25)
											{
												this.button19_Click(null, null);
											}
										}));
									}
									else
									{
										foreach (vipaccount current2 in this.listvipacc)
										{
											current2.limited = false;
										}
									}
								}
								else
								{
									int num = 0;
									this.listView3.Invoke(new MethodInvoker(delegate
									{
										<>c__DisplayClass156_5.CS$<>8__locals4.CS$<>8__locals2.CS$<>8__locals1.<>4__this.listView3.Items[<>c__DisplayClass156_5.CS$<>8__locals4.CS$<>8__locals2.CS$<>8__locals1.<>4__this.listvipacc.IndexOf(<>c__DisplayClass156_5.vipacc)].BackColor = Color.Yellow;
										<>c__DisplayClass156_5.CS$<>8__locals4.CS$<>8__locals2.CS$<>8__locals1.<>4__this.listView3.Refresh();
									}));
									bool flag16;
									do
									{
										if (Form1.<>o__156.<>p__5 == null)
										{
											Form1.<>o__156.<>p__5 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Form1), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										Func<CallSite, object, bool> arg_A6B_0 = Form1.<>o__156.<>p__5.Target;
										CallSite arg_A6B_1 = Form1.<>o__156.<>p__5;
										if (Form1.<>o__156.<>p__4 == null)
										{
											Form1.<>o__156.<>p__4 = CallSite<Func<CallSite, object, object>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.Not, typeof(Form1), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										Func<CallSite, object, object> arg_A66_0 = Form1.<>o__156.<>p__4.Target;
										CallSite arg_A66_1 = Form1.<>o__156.<>p__4;
										if (Form1.<>o__156.<>p__3 == null)
										{
											Form1.<>o__156.<>p__3 = CallSite<Func<CallSite, object, string, string, int, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "vip72login", null, typeof(Form1), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
											}));
										}
										if (!arg_A6B_0(arg_A6B_1, arg_A66_0(arg_A66_1, Form1.<>o__156.<>p__3.Target(Form1.<>o__156.<>p__3, arg, <>c__DisplayClass156_5.vipacc.username, <>c__DisplayClass156_5.vipacc.password, (int)this.numericUpDown1.Value))))
										{
											goto Block_36;
										}
										num++;
										flag16 = (num > 0);
									}
									while (!flag16);
									<>c__DisplayClass156_5.vipacc.limited = true;
									this.listView3.Invoke(new MethodInvoker(delegate
									{
										<>c__DisplayClass156_5.CS$<>8__locals4.CS$<>8__locals2.CS$<>8__locals1.<>4__this.listView3.Items[<>c__DisplayClass156_5.CS$<>8__locals4.CS$<>8__locals2.CS$<>8__locals1.<>4__this.listvipacc.IndexOf(<>c__DisplayClass156_5.vipacc)].BackColor = Color.Red;
										<>c__DisplayClass156_5.CS$<>8__locals4.CS$<>8__locals2.CS$<>8__locals1.<>4__this.listView3.Refresh();
									}));
									continue;
									Block_36:
									this.listView3.Invoke(new MethodInvoker(delegate
									{
										<>c__DisplayClass156_5.CS$<>8__locals4.CS$<>8__locals2.CS$<>8__locals1.<>4__this.listView3.Items[<>c__DisplayClass156_5.CS$<>8__locals4.CS$<>8__locals2.CS$<>8__locals1.<>4__this.listvipacc.IndexOf(<>c__DisplayClass156_5.vipacc)].BackColor = Color.Lime;
										<>c__DisplayClass156_5.CS$<>8__locals4.CS$<>8__locals2.CS$<>8__locals1.<>4__this.listView3.Refresh();
									}));
									string a;
									while (true)
									{
										<>c__DisplayClass156_5.txt = "";
										this.label1.Invoke(new MethodInvoker(delegate
										{
											<>c__DisplayClass156_5.txt = <>c__DisplayClass156_5.CS$<>8__locals4.CS$<>8__locals2.CS$<>8__locals1.<>4__this.comboBox5.Text;
										}));
										if (Form1.<>o__156.<>p__7 == null)
										{
											Form1.<>o__156.<>p__7 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Form1), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										Func<CallSite, object, bool> arg_B72_0 = Form1.<>o__156.<>p__7.Target;
										CallSite arg_B72_1 = Form1.<>o__156.<>p__7;
										if (Form1.<>o__156.<>p__6 == null)
										{
											Form1.<>o__156.<>p__6 = CallSite<Func<CallSite, object, byte, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "getip", null, typeof(Form1), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
											}));
										}
										bool flag17 = arg_B72_0(arg_B72_1, Form1.<>o__156.<>p__6.Target(Form1.<>o__156.<>p__6, arg, this.listcountrycode.FirstOrDefault((countrycode x) => x.country == <>c__DisplayClass156_5.txt).code));
										if (!flag17)
										{
											goto IL_D5C;
										}
										Control arg_BA6_0 = this.label1;
										MethodInvoker arg_BA6_1;
										if ((arg_BA6_1 = Form1.<>c.<>9__156_34) == null)
										{
											arg_BA6_1 = (Form1.<>c.<>9__156_34 = new MethodInvoker(Form1.<>c.<>9.<autoRRS>b__156_34));
										}
										arg_BA6_0.Invoke(arg_BA6_1);
										if (Form1.<>o__156.<>p__9 == null)
										{
											Form1.<>o__156.<>p__9 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(Form1)));
										}
										Func<CallSite, object, string> arg_C51_0 = Form1.<>o__156.<>p__9.Target;
										CallSite arg_C51_1 = Form1.<>o__156.<>p__9;
										if (Form1.<>o__156.<>p__8 == null)
										{
											Form1.<>o__156.<>p__8 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "clickip", null, typeof(Form1), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
											}));
										}
										text3 = arg_C51_0(arg_C51_1, Form1.<>o__156.<>p__8.Target(Form1.<>o__156.<>p__8, arg, (int)this.numericUpDown1.Value));
										a = text3;
										if (a == "not running")
										{
											break;
										}
										if (!(a == "no IP"))
										{
											if (!(a == "dead"))
											{
												if (a == "limited")
												{
													goto IL_CC7;
												}
												if (!(a == "maximum"))
												{
													goto Block_47;
												}
												if (Form1.<>o__156.<>p__10 == null)
												{
													Form1.<>o__156.<>p__10 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "clearip", null, typeof(Form1), new CSharpArgumentInfo[]
													{
														CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
													}));
												}
												Form1.<>o__156.<>p__10.Target(Form1.<>o__156.<>p__10, arg);
											}
										}
									}
									continue;
									IL_CC7:
									<>c__DisplayClass156_5.vipacc.limited = true;
									this.listView3.Invoke(new MethodInvoker(delegate
									{
										<>c__DisplayClass156_5.CS$<>8__locals4.CS$<>8__locals2.CS$<>8__locals1.<>4__this.listView3.Items[<>c__DisplayClass156_5.CS$<>8__locals4.CS$<>8__locals2.CS$<>8__locals1.<>4__this.listvipacc.IndexOf(<>c__DisplayClass156_5.vipacc)].BackColor = Color.Red;
										<>c__DisplayClass156_5.CS$<>8__locals4.CS$<>8__locals2.CS$<>8__locals1.<>4__this.listView3.Refresh();
									}));
									continue;
									Block_47:
									if (!(a == "timeout"))
									{
										goto Block_48;
									}
								}
							}
						}
						IL_1092:
						this.button2.Invoke(new MethodInvoker(delegate
						{
							bool flag24 = !this.fakedevice.Checked;
							if (flag24)
							{
								this.cmd.changename("orig");
							}
							bool flag25 = this.fakedevice.Checked && this.checkBox11.Checked && File.Exists(this.fileofname.Text);
							if (flag25)
							{
								string[] array2 = File.ReadAllLines(this.fileofname.Text);
								Random random4 = new Random();
								this.cmd.changename(array2[random4.Next(0, array2.Count<string>())]);
							}
							bool checked3 = this.checkBox20.Checked;
							if (checked3)
							{
								this.fakeLocationByIP(this.curip);
							}
							bool checked4 = this.fakelang.Checked;
							if (checked4)
							{
								this.cmd.changelanguage(this.listlanguagecode.FirstOrDefault((languagecode x) => x.langname == this.comboBox1.Text).langcode);
							}
							bool checked5 = this.fakeregion.Checked;
							if (checked5)
							{
								this.cmd.changeregion(this.listcountrycodeiOS.FirstOrDefault((countrycodeiOS x) => x.countryname == this.comboBox2.Text).countrycode);
							}
							bool checked6 = this.checkBox5.Checked;
							if (checked6)
							{
								this.cmd.changetimezone(this.ltimezone.Text);
							}
							else
							{
								this.cmd.changetimezone("orig");
							}
							bool checked7 = this.checkBox13.Checked;
							if (checked7)
							{
								bool checked8 = this.checkBox9.Checked;
								if (checked8)
								{
									List<Carrier> list = (from x in this.carrierList
									where x.country == this.carrierBox.Text
									select x).ToList<Carrier>();
									Random random5 = new Random();
									Carrier carrier = list.ElementAt(random5.Next(0, list.Count));
									this.cmd.changecarrier(carrier.CarrierName, carrier.mobileCountryCode, carrier.mobileCarrierCode, carrier.ISOCountryCode.ToLower());
								}
								else
								{
									Random random6 = new Random();
									Carrier carrier2 = this.carrierList.ElementAt(random6.Next(0, this.carrierList.Count));
									this.cmd.changecarrier(carrier2.CarrierName, carrier2.mobileCountryCode, carrier2.mobileCarrierCode, carrier2.ISOCountryCode.ToLower());
								}
							}
							else
							{
								this.cmd.changecarrier("orig", "orig", "orig", "orig");
							}
							bool checked9 = this.checkBox19.Checked;
							if (checked9)
							{
								this.cmd.fakeGPS(true, (double)this.latitude.Value, (double)this.longtitude.Value);
							}
							else
							{
								this.cmd.fakeGPS(false);
							}
						}));
						this.label1.Invoke(new MethodInvoker(delegate
						{
							this.label1.Text = "Restoring data....";
						}));
						this.cmdResult.restore = false;
						this.cmd.restore(item.filename);
						DateTime now2 = DateTime.Now;
						this.button2.Invoke(new MethodInvoker(delegate
						{
							this.maxwait = (int)this.numericUpDown10.Value;
						}));
						while (!this.cmdResult.restore)
						{
							Thread.Sleep(500);
							bool flag18 = (DateTime.Now - now2).TotalSeconds > (double)this.maxwait;
							if (flag18)
							{
								this.button2.Invoke(new MethodInvoker(delegate
								{
									bool flag24 = this.button2.Text == "Disconnect";
									if (flag24)
									{
										this.button2_Click(null, null);
									}
								}));
								return;
							}
							this.cmd.checkrestore();
						}
						Thread.Sleep(1000);
						this.label1.Invoke(new MethodInvoker(delegate
						{
							this.label1.Text = "Opening application....";
						}));
						now2 = DateTime.Now;
						foreach (string current3 in item.appList)
						{
							Form1.<>c__DisplayClass156_8 <>c__DisplayClass156_6 = new Form1.<>c__DisplayClass156_8();
							<>c__DisplayClass156_6.CS$<>8__locals8 = <>c__DisplayClass156_3;
							this.cmdResult.openApp = 0;
							this.cmd.openApp(current3);
							while (this.cmdResult.openApp != 0)
							{
								Thread.Sleep(1000);
								bool flag19 = (DateTime.Now - now2).TotalSeconds > (double)this.maxwait1;
								if (flag19)
								{
									this.button2.Invoke(new MethodInvoker(delegate
									{
										bool flag24 = this.button2.Text == "Disconnect";
										if (flag24)
										{
											this.button2_Click(null, null);
										}
									}));
									return;
								}
							}
							<>c__DisplayClass156_6.waittime = 20;
							this.rsswaitnum.Invoke(new MethodInvoker(delegate
							{
								<>c__DisplayClass156_6.waittime = (int)<>c__DisplayClass156_6.CS$<>8__locals8.CS$<>8__locals2.CS$<>8__locals1.<>4__this.rsswaitnum.Value;
							}));
							int j;
							int i;
							for (i = 0; i < <>c__DisplayClass156_6.waittime; i = j + 1)
							{
								Thread.Sleep(1000);
								this.label1.Invoke(new MethodInvoker(delegate
								{
									<>c__DisplayClass156_6.CS$<>8__locals8.CS$<>8__locals2.CS$<>8__locals1.<>4__this.label1.Text = "Application will be closed in " + (<>c__DisplayClass156_6.waittime - i - 1).ToString() + " seconds";
								}));
								j = i;
							}
							<>c__DisplayClass156_6.currentscript = new Script();
							this.label1.Invoke(new MethodInvoker(delegate
							{
								bool flag24 = <>c__DisplayClass156_6.CS$<>8__locals8.CS$<>8__locals2.CS$<>8__locals1.<>4__this.checkBox6.Checked && <>c__DisplayClass156_6.CS$<>8__locals8.CS$<>8__locals2.CS$<>8__locals1.<>4__this.comboBox3.SelectedIndex != -1;
								if (flag24)
								{
									bool checked3 = <>c__DisplayClass156_6.CS$<>8__locals8.CS$<>8__locals2.CS$<>8__locals1.<>4__this.checkBox7.Checked;
									if (checked3)
									{
										List<Script> list = <>c__DisplayClass156_6.CS$<>8__locals8.CS$<>8__locals2.CS$<>8__locals1.<>4__this.listscript.Where(new Func<Script, bool>(<>c__DisplayClass156_6.CS$<>8__locals8.CS$<>8__locals2.CS$<>8__locals1.<>4__this.<autoRRS>b__156_52)).ToList<Script>();
										Random random4 = new Random();
										<>c__DisplayClass156_6.currentscript = list.ElementAt(random4.Next(0, list.Count));
									}
									else
									{
										<>c__DisplayClass156_6.currentscript = <>c__DisplayClass156_6.CS$<>8__locals8.CS$<>8__locals2.CS$<>8__locals1.<>4__this.listscript.ElementAt(<>c__DisplayClass156_6.CS$<>8__locals8.CS$<>8__locals2.CS$<>8__locals1.<>4__this.comboBox3.SelectedIndex);
									}
									<>c__DisplayClass156_6.CS$<>8__locals8.CS$<>8__locals2.CS$<>8__locals1.<>4__this.label1.Text = "Running script " + <>c__DisplayClass156_6.currentscript.scriptname;
								}
							}));
							this.excuteScript(<>c__DisplayClass156_6.currentscript.script);
						}
						base.Invoke(new MethodInvoker(<>c__DisplayClass156_3.CS$<>8__locals2.<autoRRS>b__53));
						this.saverrsthread(<>c__DisplayClass156_3.CS$<>8__locals2.currentlistview);
						this.listView4.Invoke(new MethodInvoker(<>c__DisplayClass156_3.CS$<>8__locals2.<autoRRS>b__54));
						continue;
						IL_1091:
						IL_D5C:
						Block_24:
						goto IL_1092;
						IL_D62:
						bool flag20 = <>c__DisplayClass156_3.proxytype == "SSHServer";
						if (flag20)
						{
							Form1.<>c__DisplayClass156_5 <>c__DisplayClass156_8 = new Form1.<>c__DisplayClass156_5();
							<>c__DisplayClass156_8.CS$<>8__locals5 = <>c__DisplayClass156_3;
							<>c__DisplayClass156_8.checktrung = false;
							<>c__DisplayClass156_8.offer_id = "";
							if (Form1.<>o__156.<>p__11 == null)
							{
								Form1.<>o__156.<>p__11 = CallSite<Action<CallSite, object, int>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "clearIpWithPort", null, typeof(Form1), new CSharpArgumentInfo[]
								{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
								}));
							}
							object arg;
							Form1.<>o__156.<>p__11.Target(Form1.<>o__156.<>p__11, arg, (int)this.numericUpDown1.Value);
							sshcommand.closebitvise((int)this.numericUpDown1.Value);
							while (true)
							{
								string curcontry;
								while (true)
								{
									Control arg_E76_0 = this.label1;
									MethodInvoker arg_E76_1;
									if ((arg_E76_1 = <>c__DisplayClass156_8.<>9__36) == null)
									{
										arg_E76_1 = (<>c__DisplayClass156_8.<>9__36 = new MethodInvoker(<>c__DisplayClass156_8.<autoRRS>b__36));
									}
									arg_E76_0.Invoke(arg_E76_1);
									curcontry = "";
									this.label1.Invoke(new MethodInvoker(delegate
									{
										curcontry = <>c__DisplayClass156_8.CS$<>8__locals5.CS$<>8__locals2.CS$<>8__locals1.<>4__this.comboBox5.Text;
									}));
									string text4 = this.sshserverurl + "/Home/getssh?country=" + curcontry;
									bool checktrung = <>c__DisplayClass156_8.checktrung;
									if (checktrung)
									{
										text4 = text4 + "&offerID=" + <>c__DisplayClass156_8.offer_id;
									}
									HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text4);
									httpWebRequest.UserAgent = "autoleadios";
									try
									{
										Stream responseStream = httpWebRequest.GetResponse().GetResponseStream();
										StreamReader streamReader = new StreamReader(responseStream);
										string text5 = streamReader.ReadToEnd();
										bool flag21 = text5 == "hetssh";
										if (flag21)
										{
											base.Invoke(new MethodInvoker(delegate
											{
												this.label1.Text = "SSh trên server đã hết, đang đợi ssh mới ...";
											}));
											int j;
											int i;
											for (i = 0; i < 10; i = j + 1)
											{
												Thread.Sleep(1000);
												base.Invoke(new MethodInvoker(delegate
												{
													<>c__DisplayClass156_8.CS$<>8__locals5.CS$<>8__locals2.CS$<>8__locals1.<>4__this.label1.Text = "Đợi để lấy SSH trên server trong " + (10 - i).ToString() + " giây";
												}));
												j = i;
											}
											continue;
										}
										string[] array = text5.Split(new string[]
										{
											"|"
										}, StringSplitOptions.None);
										bool flag22 = array.Count<string>() < 4;
										if (flag22)
										{
											continue;
										}
										this.curip = array[1];
										bool flag23 = sshcommand.SetSSH(array[1], array[2], array[3], this.ipAddressControl1.Text, this.numericUpDown1.Value.ToString(), ref this.bitproc);
										if (flag23)
										{
											goto IL_108F;
										}
										string requestUriString = this.sshserverurl + "/Home/xoassh?ID=" + array[0];
										HttpWebRequest httpWebRequest2 = (HttpWebRequest)WebRequest.Create(requestUriString);
										httpWebRequest2.UserAgent = "autoleadios";
										try
										{
											Stream responseStream2 = httpWebRequest2.GetResponse().GetResponseStream();
											StreamReader streamReader2 = new StreamReader(responseStream2);
											string text6 = streamReader.ReadToEnd();
										}
										catch (Exception var_71_1077)
										{
										}
									}
									catch (Exception var_72_1080)
									{
									}
									break;
								}
							}
							IL_108F:;
						}
						goto IL_1091;
						Block_48:
						this.curip = text3;
						goto IL_D5C;
					}
				}
			}
			this.label1.Invoke(new MethodInvoker(delegate
			{
				this.label1.Text = "RRS done.";
				this.button19.Text = "START";
				this.button19.Refresh();
				this.rssenableall();
				this.enableAll();
			}));
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0000FE14 File Offset: 0x0000E014
		private void bkreset_Click(object sender, EventArgs e)
		{
			bool flag = this.button19.Text == "RESUME";
			if (flag)
			{
				foreach (ListViewItem listViewItem in this.listView4.Items)
				{
					listViewItem.SubItems[0].ResetStyle();
					this.listView4.Refresh();
				}
				this.button19.Text = "START";
				this.button19.Refresh();
				bool flag2 = this.bkThread != null;
				if (flag2)
				{
					bool flag3 = this.bkThread.ThreadState != System.Threading.ThreadState.Unstarted;
					if (flag3)
					{
						bool flag4 = this.bkThread.ThreadState == System.Threading.ThreadState.Suspended;
						if (flag4)
						{
							this.bkThread.Resume();
							Thread.Sleep(100);
						}
						try
						{
							try
							{
								this.bkThread.Abort();
							}
							catch (Exception)
							{
							}
						}
						catch (Exception)
						{
						}
					}
				}
				this.rssenableall();
			}
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00002276 File Offset: 0x00000476
		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			this.button23.Text = "Apply";
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x000021A5 File Offset: 0x000003A5
		private void ipAddressControl1_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x060000CA RID: 202 RVA: 0x0000FF5C File Offset: 0x0000E15C
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.textBox3.Text = string.Concat(new string[]
			{
				"Touch(",
				this.textBox7.Text,
				",",
				this.textBox8.Text,
				")"
			});
			bool flag = this.button30.Text == "Stop Record";
			if (flag)
			{
				double num = Math.Round((DateTime.Now - this.clicklast).TotalMilliseconds / 1000.0, 2);
				bool flag2 = num < 1.0 && ((MouseEventArgs)e).X * this.trackBar1.Value == this.prevx && ((MouseEventArgs)e).Y * this.trackBar1.Value == this.prevy;
				if (flag2)
				{
					RichTextBox richTextBox = this.textBox2;
					richTextBox.Text = string.Concat(new string[]
					{
						richTextBox.Text,
						"Touch(",
						this.textBox7.Text,
						",",
						this.textBox8.Text,
						")"
					});
				}
				else
				{
					RichTextBox richTextBox = this.textBox2;
					richTextBox.Text = string.Concat(new string[]
					{
						richTextBox.Text,
						"swipe(",
						this.prevx.ToString(),
						",",
						this.prevy.ToString(),
						",",
						this.textBox7.Text,
						",",
						this.textBox8.Text,
						",",
						num.ToString(),
						")"
					});
				}
				RichTextBox expr_1E6 = this.textBox2;
				expr_1E6.Text += "\r\n";
				this.textBox2.Focus();
				this.textBox2.SelectionStart = this.textBox2.Text.Length;
				this.textBox2.ScrollToCaret();
				this.cmd.mouseup(((MouseEventArgs)e).X * this.trackBar1.Value, ((MouseEventArgs)e).Y * this.trackBar1.Value);
			}
		}

		// Token: 0x060000CB RID: 203 RVA: 0x000101D4 File Offset: 0x0000E3D4
		private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
		{
			this.textBox7.Text = (e.X * this.trackBar1.Value).ToString();
			this.textBox8.Text = (e.Y * this.trackBar1.Value).ToString();
			bool flag = this.button26.Text == "Disable Mouse";
			if (flag)
			{
				bool flag2 = e.Button == MouseButtons.Left && this.button30.Text == "Stop Record";
				if (flag2)
				{
					this.cmd.mousedown(e.X * this.trackBar1.Value, e.Y * this.trackBar1.Value);
				}
				else
				{
					this.cmd.movemouse(e.X * this.trackBar1.Value, e.Y * this.trackBar1.Value);
				}
			}
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0000228A File Offset: 0x0000048A
		private void button20_Click(object sender, EventArgs e)
		{
			this.textBox3.Text = "";
		}

		// Token: 0x060000CD RID: 205 RVA: 0x000102DC File Offset: 0x0000E4DC
		private void button10_Click(object sender, EventArgs e)
		{
			List<string> list = this.vipid.Text.Split(new string[]
			{
				"\r\n"
			}, StringSplitOptions.None).ToList<string>();
			using (List<string>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					string item = enumerator.Current;
					bool flag = item != "" && this.vippassword.Text != "";
					if (flag)
					{
						vipaccount vipaccount = this.listvipacc.FirstOrDefault((vipaccount x) => x.username == item);
						bool flag2 = vipaccount == null;
						if (flag2)
						{
							vipaccount = new vipaccount();
							vipaccount.username = item;
							vipaccount.password = this.vippassword.Text;
							vipaccount.limited = false;
							this.listvipacc.Add(vipaccount);
							ListViewItem value = new ListViewItem(new string[]
							{
								vipaccount.username,
								vipaccount.password
							});
							this.listView3.Items.Add(value);
						}
						else
						{
							vipaccount.password = this.vippassword.Text;
							this.listView3.Items[this.listvipacc.IndexOf(vipaccount)].SubItems[1].Text = this.vippassword.Text;
						}
					}
					else
					{
						string[] array = item.Split(new string[]
						{
							"|"
						}, StringSplitOptions.None);
						bool flag3 = array.Count<string>() == 2;
						if (flag3)
						{
							string usname = array[0];
							string text = array[1];
							vipaccount vipaccount2 = this.listvipacc.FirstOrDefault((vipaccount x) => x.username == usname);
							bool flag4 = vipaccount2 == null;
							if (flag4)
							{
								vipaccount2 = new vipaccount();
								vipaccount2.username = usname;
								vipaccount2.password = text;
								vipaccount2.limited = false;
								this.listvipacc.Add(vipaccount2);
								ListViewItem value2 = new ListViewItem(new string[]
								{
									vipaccount2.username,
									vipaccount2.password
								});
								this.listView3.Items.Add(value2);
							}
							else
							{
								vipaccount2.password = text;
								this.listView3.Items[this.listvipacc.IndexOf(vipaccount2)].SubItems[1].Text = text;
							}
						}
					}
					this.savevip72();
				}
			}
		}

		// Token: 0x060000CE RID: 206 RVA: 0x000105B0 File Offset: 0x0000E7B0
		private void vipdelete_Click(object sender, EventArgs e)
		{
			bool flag = this.listView3.SelectedItems.Count > 0;
			if (flag)
			{
				for (int i = this.listView3.SelectedItems.Count - 1; i >= 0; i--)
				{
					this.listvipacc.RemoveAt(this.listView3.SelectedItems[i].Index);
					this.listView3.Items.Remove(this.listView3.SelectedItems[i]);
				}
			}
			this.savevip72();
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00010648 File Offset: 0x0000E848
		private void listView3_KeyDown(object sender, KeyEventArgs e)
		{
			bool flag = e.KeyCode == Keys.Delete;
			if (flag)
			{
				this.vipdelete_Click(null, null);
			}
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0000229E File Offset: 0x0000049E
		private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00010670 File Offset: 0x0000E870
		private void button10_Click_1(object sender, EventArgs e)
		{
			Thread thread = new Thread(new ThreadStart(this.wipethread));
			thread.Start();
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00010698 File Offset: 0x0000E898
		private void wipethread()
		{
			string appwipe = "";
			this.cmd.close("all");
			this.cmdResult.wipe = false;
			this.label1.Invoke(new MethodInvoker(delegate
			{
				appwipe = this.AppList[this.wipecombo.SelectedIndex].appID;
				bool flag4 = appwipe == "";
				if (flag4)
				{
					this.cmdResult.wipe = true;
				}
				this.label1.Text = "Wiping Application " + appwipe;
			}));
			this.cmd.faketype(this.getrandomdevice());
			bool @checked = this.fakeversion.Checked;
			if (@checked)
			{
				bool flag = this.checkBox14.Checked || this.checkBox15.Checked;
				if (flag)
				{
					bool flag2 = this.checkBox14.Checked && this.checkBox15.Checked;
					string text;
					if (flag2)
					{
						Random random = new Random();
						text = random.Next(8, 10).ToString();
					}
					else
					{
						bool checked2 = this.checkBox14.Checked;
						if (checked2)
						{
							text = "8";
						}
						else
						{
							text = "9";
						}
					}
					this.cmd.fakeversion(text);
				}
			}
			bool wipechoose = false;
			this.checkBox2.Invoke(new MethodInvoker(delegate
			{
				bool checked3 = this.checkBox2.Checked;
				if (checked3)
				{
					wipechoose = true;
				}
			}));
			this.cmd.randominfo();
			bool wipechoose2 = wipechoose;
			if (wipechoose2)
			{
				this.cmd.wipefull(appwipe);
			}
			else
			{
				this.cmd.wipe(appwipe);
			}
			DateTime now = DateTime.Now;
			this.button2.Invoke(new MethodInvoker(delegate
			{
				this.maxwait = (int)this.numericUpDown10.Value;
			}));
			while (!this.cmdResult.wipe)
			{
				Thread.Sleep(500);
				bool flag3 = (DateTime.Now - now).TotalSeconds > (double)this.maxwait;
				if (flag3)
				{
					this.button2.Invoke(new MethodInvoker(delegate
					{
						bool flag4 = this.button2.Text == "Disconnect";
						if (flag4)
						{
							this.button2_Click(null, null);
						}
					}));
					return;
				}
				this.cmd.checkwipe();
			}
			this.button2.Invoke(new MethodInvoker(delegate
			{
				bool flag4 = !this.fakedevice.Checked;
				if (flag4)
				{
					this.cmd.changename("orig");
				}
				bool flag5 = this.fakedevice.Checked && this.checkBox11.Checked && File.Exists(this.fileofname.Text);
				if (flag5)
				{
					string[] array = File.ReadAllLines(this.fileofname.Text);
					Random random2 = new Random();
					this.cmd.changename(array[random2.Next(0, array.Count<string>())]);
				}
				else
				{
					this.cmd.changetimezone("orig");
				}
				bool checked3 = this.checkBox20.Checked;
				if (checked3)
				{
					this.fakeLocationByIP(this.curip);
				}
				bool checked4 = this.checkBox5.Checked;
				if (checked4)
				{
					this.cmd.changetimezone(this.ltimezone.Text);
				}
				bool checked5 = this.fakelang.Checked;
				if (checked5)
				{
					this.cmd.changelanguage(this.listlanguagecode.FirstOrDefault((languagecode x) => x.langname == this.comboBox1.Text).langcode);
				}
				bool checked6 = this.fakeregion.Checked;
				if (checked6)
				{
					this.cmd.changeregion(this.listcountrycodeiOS.FirstOrDefault((countrycodeiOS x) => x.countryname == this.comboBox2.Text).countrycode);
				}
				bool checked7 = this.checkBox13.Checked;
				if (checked7)
				{
					bool checked8 = this.checkBox9.Checked;
					if (checked8)
					{
						List<Carrier> list = (from x in this.carrierList
						where x.country == this.carrierBox.Text
						select x).ToList<Carrier>();
						Random random3 = new Random();
						Carrier carrier = list.ElementAt(random3.Next(0, list.Count));
						this.cmd.changecarrier(carrier.CarrierName, carrier.mobileCountryCode, carrier.mobileCarrierCode, carrier.ISOCountryCode.ToLower());
					}
					else
					{
						Random random4 = new Random();
						Carrier carrier2 = this.carrierList.ElementAt(random4.Next(0, this.carrierList.Count));
						this.cmd.changecarrier(carrier2.CarrierName, carrier2.mobileCountryCode, carrier2.mobileCarrierCode, carrier2.ISOCountryCode.ToLower());
					}
				}
				else
				{
					this.cmd.changecarrier("orig", "orig", "orig", "orig");
				}
				bool checked9 = this.checkBox19.Checked;
				if (checked9)
				{
					this.cmd.fakeGPS(true, (double)this.latitude.Value, (double)this.longtitude.Value);
				}
				else
				{
					this.cmd.fakeGPS(false);
				}
			}));
			this.label1.Invoke(new MethodInvoker(delegate
			{
				appwipe = this.wipecombo.SelectedText;
				this.label1.Text = "Wipe finished...";
			}));
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x000108CC File Offset: 0x0000EACC
		private void button20_Click_1(object sender, EventArgs e)
		{
			bool flag = this.ipAddressControl1.Text.Split(new string[]
			{
				"."
			}, StringSplitOptions.None).Count<string>() == 4 && this.numericUpDown1.Validate();
			if (flag)
			{
				this.button20.Enabled = false;
				Thread thread = new Thread(new ThreadStart(this.threadchangeIP));
				thread.Start();
			}
			else
			{
				MessageBox.Show("IP and Port invalid!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00010954 File Offset: 0x0000EB54
		private void threadchangeIP()
		{
			Form1.<>c__DisplayClass170_0 <>c__DisplayClass170_ = new Form1.<>c__DisplayClass170_0();
			<>c__DisplayClass170_.<>4__this = this;
			object arg;
			string text;
			while (true)
			{
				<>c__DisplayClass170_.proxytype = "SSH";
				this.proxytool.Invoke(new MethodInvoker(delegate
				{
					<>c__DisplayClass170_.proxytype = <>c__DisplayClass170_.<>4__this.proxytool.Text;
				}));
				Thread.Sleep(10);
				<>c__DisplayClass170_.svip = false;
				base.Invoke(new MethodInvoker(delegate
				{
					<>c__DisplayClass170_.svip = <>c__DisplayClass170_.<>4__this.sameVip.Checked;
				}));
				bool flag = !<>c__DisplayClass170_.svip;
				if (flag)
				{
					arg = new Vip72();
				}
				else
				{
					arg = new Vip72Chung();
				}
				bool flag2 = <>c__DisplayClass170_.proxytype == "SSH";
				if (flag2)
				{
					break;
				}
				bool flag3 = <>c__DisplayClass170_.proxytype == "Vip72";
				if (!flag3)
				{
					goto IL_9D8;
				}
				Form1.<>c__DisplayClass170_2 <>c__DisplayClass170_2 = new Form1.<>c__DisplayClass170_2();
				<>c__DisplayClass170_2.CS$<>8__locals2 = <>c__DisplayClass170_;
				try
				{
					sshcommand.closebitvise((int)this.numericUpDown1.Value);
					bool flag4 = !this.bitproc.HasExited;
					if (flag4)
					{
						this.bitproc.Kill();
					}
				}
				catch (Exception)
				{
				}
				this.label1.Invoke(new MethodInvoker(delegate
				{
					this.label1.Text = "Đang đợi Để sử dụng Vip72...";
				}));
				if (Form1.<>o__170.<>p__1 == null)
				{
					Form1.<>o__170.<>p__1 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "waitiotherVIP72", null, typeof(Form1), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Form1.<>o__170.<>p__1.Target(Form1.<>o__170.<>p__1, arg);
				this.label1.Invoke(new MethodInvoker(delegate
				{
					this.label1.Text = "Getting Vip72 IP...";
				}));
				Form1.<>c__DisplayClass170_2 arg_480_0 = <>c__DisplayClass170_2;
				IEnumerable<vipaccount> arg_47B_0 = this.listvipacc;
				Func<vipaccount, bool> arg_47B_1;
				if ((arg_47B_1 = Form1.<>c.<>9__170_21) == null)
				{
					arg_47B_1 = (Form1.<>c.<>9__170_21 = new Func<vipaccount, bool>(Form1.<>c.<>9.<threadchangeIP>b__170_21));
				}
				arg_480_0.vipacc = arg_47B_0.FirstOrDefault(arg_47B_1);
				bool flag5 = <>c__DisplayClass170_2.vipacc == null;
				if (flag5)
				{
					goto Block_14;
				}
				int num = 0;
				this.listView3.Invoke(new MethodInvoker(delegate
				{
					<>c__DisplayClass170_2.CS$<>8__locals2.<>4__this.listView3.Items[<>c__DisplayClass170_2.CS$<>8__locals2.<>4__this.listvipacc.IndexOf(<>c__DisplayClass170_2.vipacc)].BackColor = Color.Yellow;
					<>c__DisplayClass170_2.CS$<>8__locals2.<>4__this.listView3.Refresh();
				}));
				bool flag6;
				do
				{
					if (Form1.<>o__170.<>p__4 == null)
					{
						Form1.<>o__170.<>p__4 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Form1), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					Func<CallSite, object, bool> arg_6E9_0 = Form1.<>o__170.<>p__4.Target;
					CallSite arg_6E9_1 = Form1.<>o__170.<>p__4;
					if (Form1.<>o__170.<>p__3 == null)
					{
						Form1.<>o__170.<>p__3 = CallSite<Func<CallSite, object, object>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.Not, typeof(Form1), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					Func<CallSite, object, object> arg_6E4_0 = Form1.<>o__170.<>p__3.Target;
					CallSite arg_6E4_1 = Form1.<>o__170.<>p__3;
					if (Form1.<>o__170.<>p__2 == null)
					{
						Form1.<>o__170.<>p__2 = CallSite<Func<CallSite, object, string, string, int, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "vip72login", null, typeof(Form1), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
						}));
					}
					if (!arg_6E9_0(arg_6E9_1, arg_6E4_0(arg_6E4_1, Form1.<>o__170.<>p__2.Target(Form1.<>o__170.<>p__2, arg, <>c__DisplayClass170_2.vipacc.username, <>c__DisplayClass170_2.vipacc.password, (int)this.numericUpDown1.Value))))
					{
						goto Block_21;
					}
					num++;
					flag6 = (num > 0);
				}
				while (!flag6);
				<>c__DisplayClass170_2.vipacc.limited = true;
				this.listView3.Invoke(new MethodInvoker(delegate
				{
					<>c__DisplayClass170_2.CS$<>8__locals2.<>4__this.listView3.Items[<>c__DisplayClass170_2.CS$<>8__locals2.<>4__this.listvipacc.IndexOf(<>c__DisplayClass170_2.vipacc)].BackColor = Color.Red;
					<>c__DisplayClass170_2.CS$<>8__locals2.<>4__this.listView3.Refresh();
				}));
				continue;
				Block_21:
				this.listView3.Invoke(new MethodInvoker(delegate
				{
					<>c__DisplayClass170_2.CS$<>8__locals2.<>4__this.listView3.Items[<>c__DisplayClass170_2.CS$<>8__locals2.<>4__this.listvipacc.IndexOf(<>c__DisplayClass170_2.vipacc)].BackColor = Color.Lime;
					<>c__DisplayClass170_2.CS$<>8__locals2.<>4__this.listView3.Refresh();
				}));
				string a;
				while (true)
				{
					<>c__DisplayClass170_2.txt = "";
					this.label1.Invoke(new MethodInvoker(delegate
					{
						<>c__DisplayClass170_2.txt = <>c__DisplayClass170_2.CS$<>8__locals2.<>4__this.comboBox5.Text;
					}));
					if (Form1.<>o__170.<>p__6 == null)
					{
						Form1.<>o__170.<>p__6 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Form1), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					Func<CallSite, object, bool> arg_7EF_0 = Form1.<>o__170.<>p__6.Target;
					CallSite arg_7EF_1 = Form1.<>o__170.<>p__6;
					if (Form1.<>o__170.<>p__5 == null)
					{
						Form1.<>o__170.<>p__5 = CallSite<Func<CallSite, object, byte, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "getip", null, typeof(Form1), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
						}));
					}
					bool flag7 = arg_7EF_0(arg_7EF_1, Form1.<>o__170.<>p__5.Target(Form1.<>o__170.<>p__5, arg, this.listcountrycode.FirstOrDefault((countrycode x) => x.country == <>c__DisplayClass170_2.txt).code));
					if (!flag7)
					{
						goto IL_9D7;
					}
					Control arg_823_0 = this.label1;
					MethodInvoker arg_823_1;
					if ((arg_823_1 = Form1.<>c.<>9__170_31) == null)
					{
						arg_823_1 = (Form1.<>c.<>9__170_31 = new MethodInvoker(Form1.<>c.<>9.<threadchangeIP>b__170_31));
					}
					arg_823_0.Invoke(arg_823_1);
					if (Form1.<>o__170.<>p__8 == null)
					{
						Form1.<>o__170.<>p__8 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(Form1)));
					}
					Func<CallSite, object, string> arg_8CD_0 = Form1.<>o__170.<>p__8.Target;
					CallSite arg_8CD_1 = Form1.<>o__170.<>p__8;
					if (Form1.<>o__170.<>p__7 == null)
					{
						Form1.<>o__170.<>p__7 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "clickip", null, typeof(Form1), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
						}));
					}
					text = arg_8CD_0(arg_8CD_1, Form1.<>o__170.<>p__7.Target(Form1.<>o__170.<>p__7, arg, (int)this.numericUpDown1.Value));
					a = text;
					if (a == "not running")
					{
						break;
					}
					if (!(a == "no IP"))
					{
						if (!(a == "dead"))
						{
							if (a == "limited")
							{
								goto IL_943;
							}
							if (!(a == "maximum"))
							{
								goto Block_32;
							}
							if (Form1.<>o__170.<>p__9 == null)
							{
								Form1.<>o__170.<>p__9 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "clearip", null, typeof(Form1), new CSharpArgumentInfo[]
								{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
								}));
							}
							Form1.<>o__170.<>p__9.Target(Form1.<>o__170.<>p__9, arg);
						}
					}
				}
				continue;
				IL_943:
				this.listView3.Invoke(new MethodInvoker(delegate
				{
					<>c__DisplayClass170_2.CS$<>8__locals2.<>4__this.listView3.Items[<>c__DisplayClass170_2.CS$<>8__locals2.<>4__this.listvipacc.IndexOf(<>c__DisplayClass170_2.vipacc)].BackColor = Color.Red;
					<>c__DisplayClass170_2.CS$<>8__locals2.<>4__this.listView3.Refresh();
				}));
				<>c__DisplayClass170_2.vipacc.limited = true;
				continue;
				Block_32:
				if (!(a == "timeout"))
				{
					goto Block_33;
				}
			}
			if (Form1.<>o__170.<>p__0 == null)
			{
				Form1.<>o__170.<>p__0 = CallSite<Action<CallSite, object, int>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "clearIpWithPort", null, typeof(Form1), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
				}));
			}
			Form1.<>o__170.<>p__0.Target(Form1.<>o__170.<>p__0, arg, (int)this.numericUpDown1.Value);
			sshcommand.closebitvise((int)this.numericUpDown1.Value);
			try
			{
				bool flag8 = !this.bitproc.HasExited;
				if (flag8)
				{
					this.bitproc.Kill();
				}
			}
			catch (Exception)
			{
			}
			while (true)
			{
				string curcountry = "";
				this.label1.Invoke(new MethodInvoker(delegate
				{
					curcountry = <>c__DisplayClass170_.<>4__this.comboBox5.Text;
					<>c__DisplayClass170_.<>4__this.label1.Text = "Checking SSH....";
				}));
				ssh _getssh = this.listssh.FirstOrDefault((ssh x) => x.live != "dead" && !x.used && x.country == curcountry);
				bool flag9 = _getssh == null;
				if (flag9)
				{
					break;
				}
				Random random = new Random();
				int index = random.Next(0, this.listssh.Count);
				while (this.listssh.ElementAt(index).live == "dead" || this.listssh.ElementAt(index).used || this.listssh.ElementAt(index).country != curcountry)
				{
					index = random.Next(0, this.listssh.Count);
				}
				_getssh = this.listssh.ElementAt(index);
				_getssh.used = true;
				this.listView2.Invoke(new MethodInvoker(delegate
				{
					<>c__DisplayClass170_.<>4__this.listView2.Items[<>c__DisplayClass170_.<>4__this.listssh.IndexOf(_getssh)].BackColor = Color.Aqua;
					<>c__DisplayClass170_.<>4__this.listView2.Refresh();
					<>c__DisplayClass170_.<>4__this.savessh();
					<>c__DisplayClass170_.<>4__this.ssh_uncheck.Invoke(new MethodInvoker(<>c__DisplayClass170_.<>4__this.<threadchangeIP>b__170_8));
				}));
				this.curip = _getssh.IP;
				bool flag10 = sshcommand.SetSSH(_getssh.IP, _getssh.username, _getssh.password, this.ipAddressControl1.Text, this.numericUpDown1.Value.ToString(), ref this.bitproc);
				if (flag10)
				{
					goto Block_9;
				}
				_getssh.live = "dead";
				this.listView2.Invoke(new MethodInvoker(delegate
				{
					<>c__DisplayClass170_.<>4__this.listView2.Items[<>c__DisplayClass170_.<>4__this.listssh.IndexOf(_getssh)].BackColor = Color.Red;
					<>c__DisplayClass170_.<>4__this.listView2.Refresh();
					<>c__DisplayClass170_.<>4__this.savessh();
					<>c__DisplayClass170_.<>4__this.ssh_uncheck.Invoke(new MethodInvoker(<>c__DisplayClass170_.<>4__this.<threadchangeIP>b__170_14));
				}));
			}
			MessageBox.Show("All SSH are used or dead, please update new SSH list!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			this.label1.Invoke(new MethodInvoker(delegate
			{
				this.label1.Text = "SSH is out!";
			}));
			this.button7.Invoke(new MethodInvoker(delegate
			{
				bool flag16 = this.button7.Text == "STOP";
				if (flag16)
				{
					this.button7_Click(null, null);
				}
				bool flag17 = this.button19.Text == "STOP";
				if (flag17)
				{
					this.button19_Click(null, null);
				}
			}));
			this.button20.Invoke(new MethodInvoker(delegate
			{
				this.button20.Enabled = true;
			}));
			return;
			Block_9:
			goto IL_D03;
			Block_14:
			bool flag11 = this.listvipacc.Count == 0;
			if (flag11)
			{
				MessageBox.Show("There is no account, Please add other Vip72 account to use", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				this.label1.Invoke(new MethodInvoker(delegate
				{
					this.label1.Text = "Vip72 account is out";
				}));
				this.button7.Invoke(new MethodInvoker(delegate
				{
					bool flag16 = this.button7.Text == "STOP";
					if (flag16)
					{
						this.button7_Click(null, null);
					}
					bool flag17 = this.button19.Text == "STOP";
					if (flag17)
					{
						this.button19_Click(null, null);
					}
				}));
				this.button20.Invoke(new MethodInvoker(delegate
				{
					this.button20.Enabled = true;
				}));
				return;
			}
			foreach (vipaccount current in this.listvipacc)
			{
				current.limited = false;
			}
			this.button10.Invoke(new MethodInvoker(delegate
			{
				this.button20.Enabled = true;
			}));
			return;
			Block_33:
			this.curip = text;
			IL_9D7:
			IL_9D8:
			bool flag12 = <>c__DisplayClass170_.proxytype == "SSHServer";
			if (flag12)
			{
				Form1.<>c__DisplayClass170_3 <>c__DisplayClass170_4 = new Form1.<>c__DisplayClass170_3();
				<>c__DisplayClass170_4.CS$<>8__locals3 = <>c__DisplayClass170_;
				<>c__DisplayClass170_4.checktrung = false;
				<>c__DisplayClass170_4.offer_id = "";
				if (Form1.<>o__170.<>p__10 == null)
				{
					Form1.<>o__170.<>p__10 = CallSite<Action<CallSite, object, int>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "clearIpWithPort", null, typeof(Form1), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
					}));
				}
				Form1.<>o__170.<>p__10.Target(Form1.<>o__170.<>p__10, arg, (int)this.numericUpDown1.Value);
				sshcommand.closebitvise((int)this.numericUpDown1.Value);
				while (true)
				{
					string curcontry;
					while (true)
					{
						Control arg_AE8_0 = this.label1;
						MethodInvoker arg_AE8_1;
						if ((arg_AE8_1 = <>c__DisplayClass170_4.<>9__33) == null)
						{
							arg_AE8_1 = (<>c__DisplayClass170_4.<>9__33 = new MethodInvoker(<>c__DisplayClass170_4.<threadchangeIP>b__33));
						}
						arg_AE8_0.Invoke(arg_AE8_1);
						curcontry = "";
						this.label1.Invoke(new MethodInvoker(delegate
						{
							curcontry = <>c__DisplayClass170_4.CS$<>8__locals3.<>4__this.comboBox5.Text;
						}));
						string text2 = this.sshserverurl + "/Home/getssh?country=" + curcontry;
						bool checktrung = <>c__DisplayClass170_4.checktrung;
						if (checktrung)
						{
							text2 = text2 + "&offerID=" + <>c__DisplayClass170_4.offer_id;
						}
						HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text2);
						httpWebRequest.UserAgent = "autoleadios";
						try
						{
							Stream responseStream = httpWebRequest.GetResponse().GetResponseStream();
							StreamReader streamReader = new StreamReader(responseStream);
							string text3 = streamReader.ReadToEnd();
							bool flag13 = text3 == "hetssh";
							if (flag13)
							{
								base.Invoke(new MethodInvoker(delegate
								{
									this.label1.Text = "SSh trên server đã hết, đang đợi ssh mới ...";
								}));
								int j;
								int i;
								for (i = 0; i < 10; i = j + 1)
								{
									Thread.Sleep(1000);
									base.Invoke(new MethodInvoker(delegate
									{
										<>c__DisplayClass170_4.CS$<>8__locals3.<>4__this.label1.Text = "Đợi để lấy SSH trên server trong " + (10 - i).ToString() + " giây";
									}));
									j = i;
								}
								continue;
							}
							string[] array = text3.Split(new string[]
							{
								"|"
							}, StringSplitOptions.None);
							bool flag14 = array.Count<string>() < 4;
							if (flag14)
							{
								continue;
							}
							this.curip = array[1];
							bool flag15 = sshcommand.SetSSH(array[1], array[2], array[3], this.ipAddressControl1.Text, this.numericUpDown1.Value.ToString(), ref this.bitproc);
							if (flag15)
							{
								goto IL_D01;
							}
							string requestUriString = this.sshserverurl + "/Home/xoassh?ID=" + array[0];
							HttpWebRequest httpWebRequest2 = (HttpWebRequest)WebRequest.Create(requestUriString);
							httpWebRequest2.UserAgent = "autoleadios";
							try
							{
								Stream responseStream2 = httpWebRequest2.GetResponse().GetResponseStream();
								StreamReader streamReader2 = new StreamReader(responseStream2);
								string text4 = streamReader.ReadToEnd();
							}
							catch (Exception var_48_CE9)
							{
							}
						}
						catch (Exception var_49_CF2)
						{
						}
						break;
					}
				}
				IL_D01:;
			}
			IL_D03:
			this.label1.Invoke(new MethodInvoker(delegate
			{
				this.label1.Text = "IP changed...";
			}));
			this.button20.Invoke(new MethodInvoker(delegate
			{
				this.button20.Enabled = true;
			}));
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00011710 File Offset: 0x0000F910
		public static string IPAddresses()
		{
			string result = string.Empty;
			IPAddress[] hostAddresses = Dns.GetHostAddresses(Dns.GetHostName());
			for (int i = 0; i < hostAddresses.Length; i++)
			{
				IPAddress iPAddress = hostAddresses[i];
				bool flag = iPAddress.AddressFamily == AddressFamily.InterNetwork;
				if (flag)
				{
					result = iPAddress.ToString();
					break;
				}
			}
			return result;
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00011764 File Offset: 0x0000F964
		private void button11_Click(object sender, EventArgs e)
		{
			Uri uri;
			bool flag = Uri.TryCreate(this.textBox1.Text, UriKind.Absolute, out uri) && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
			bool flag2 = !flag;
			if (flag2)
			{
				MessageBox.Show("Offer URL is invalid!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				this.cmd.openURL(this.anaURL(this.textBox1.Text));
			}
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x0000229E File Offset: 0x0000049E
		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x000022A8 File Offset: 0x000004A8
		private void button12_Click(object sender, EventArgs e)
		{
			this.cmd.openApp(this.AppList[this.wipecombo.SelectedIndex].appID);
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x000117EC File Offset: 0x0000F9EC
		private void button13_Click(object sender, EventArgs e)
		{
			this.button13.Enabled = false;
			Thread thread = new Thread(new ThreadStart(this.backupthread));
			thread.Start();
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00011820 File Offset: 0x0000FA20
		private void excutescriptthread()
		{
			string script = "";
			this.label1.Invoke(new MethodInvoker(delegate
			{
				this.label1.Text = "Running Script...";
				script = this.textBox2.Text;
			}));
			this.excuteScript(script);
			this.label1.Invoke(new MethodInvoker(delegate
			{
				this.IPThread.Abort();
				this.button18.BackgroundImage = Resources.Play_icon__1_;
				this.scriptstatus = "stop";
				this.pausescript.Enabled = false;
				this.label1.Text = "Script done...";
				this.button18.Enabled = true;
			}));
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00011884 File Offset: 0x0000FA84
		private void excutescriptthread1()
		{
			this.label1.Invoke(new MethodInvoker(delegate
			{
				this.label1.Text = "Running Script...";
			}));
			this.excuteScript(this.textBox6.Text);
			this.label1.Invoke(new MethodInvoker(delegate
			{
				this.label1.Text = "Script done...";
				this.button32.Enabled = true;
			}));
		}

		// Token: 0x060000DC RID: 220 RVA: 0x000118D4 File Offset: 0x0000FAD4
		private void backupthread()
		{
			string filename = "";
			this.label1.Invoke(new MethodInvoker(delegate
			{
				this.label1.Text = "Backing Up the application...";
				filename = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss_fff");
				this.cmd.backupfull(this.AppList[this.wipecombo.SelectedIndex].appID, filename, "[]" + this.comboBox5.Text, "", "");
			}));
			this.cmdResult.backup = false;
			this.button2.Invoke(new MethodInvoker(delegate
			{
				this.maxwait = (int)this.numericUpDown10.Value;
			}));
			DateTime now = DateTime.Now;
			while (!this.cmdResult.backup)
			{
				Thread.Sleep(500);
				bool flag = (DateTime.Now - now).TotalSeconds > (double)this.maxwait;
				if (flag)
				{
					this.label1.Invoke(new MethodInvoker(delegate
					{
						this.label1.Text = "Request timeout...";
					}));
					return;
				}
				this.cmd.checkbackup(filename);
			}
			this.label1.Invoke(new MethodInvoker(delegate
			{
				this.label1.Text = "Backup done";
				this.button13.Enabled = true;
			}));
		}

		// Token: 0x060000DD RID: 221 RVA: 0x000119C8 File Offset: 0x0000FBC8
		private void button18_Click(object sender, EventArgs e)
		{
			this.pausescript.Enabled = true;
			string a = this.scriptstatus;
			if (!(a == "stop"))
			{
				if (!(a == "running"))
				{
					if (a == "pause")
					{
						this.IPThread.Resume();
						this.scriptstatus = "running";
						this.cmd.randomtouchresume();
						this.button18.BackgroundImage = Resources.Pause_icon;
					}
				}
				else
				{
					this.IPThread.Suspend();
					this.scriptstatus = "pause";
					this.button18.BackgroundImage = Resources.Resume_Button_48;
					this.cmd.randomtouchpause();
				}
			}
			else
			{
				this.IPThread = new Thread(new ThreadStart(this.excutescriptthread));
				this.IPThread.Start();
				this.button18.BackgroundImage = Resources.Pause_icon;
				this.scriptstatus = "running";
			}
		}

		// Token: 0x060000DE RID: 222 RVA: 0x000022D2 File Offset: 0x000004D2
		private void button21_Click(object sender, EventArgs e)
		{
			this.cmd.clearipa();
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00011AC4 File Offset: 0x0000FCC4
		private void button26_Click(object sender, EventArgs e)
		{
			bool flag = this.button26.Text == "Enable Mouse";
			if (flag)
			{
				this.cmd.enablemouse();
				this.button26.Text = "Disable Mouse";
			}
			else
			{
				this.cmd.disablemouse();
				this.button26.Text = "Enable Mouse";
			}
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x000022E1 File Offset: 0x000004E1
		private void button28_Click(object sender, EventArgs e)
		{
			this.button28.Enabled = false;
			this.getApp();
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00011B2C File Offset: 0x0000FD2C
		private void button27_Click(object sender, EventArgs e)
		{
			this.button27.Enabled = false;
			this.label1.Text = "Restoring App data...";
			bool flag = this.listView4.SelectedItems.Count == 1;
			if (flag)
			{
				Thread thread = new Thread(new ThreadStart(this.restorethread));
				thread.Start();
			}
			else
			{
				bool flag2 = this.listView4.SelectedItems.Count > 1;
				if (flag2)
				{
					MessageBox.Show("Please select 1 item only", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00011BBC File Offset: 0x0000FDBC
		private void restorethread()
		{
			int selectedindex = 0;
			backup currentbk = new backup();
			this.listView4.Invoke(new MethodInvoker(delegate
			{
				selectedindex = this.listView4.Items.IndexOf(this.listView4.SelectedItems[0]);
				currentbk = this.listbackup.FirstOrDefault((backup x) => x.filename == this.listView4.Items[selectedindex].SubItems[7].Text);
				this.listView4.SelectedItems[0].BackColor = Color.Yellow;
			}));
			this.cmdResult.wipe = false;
			bool wipechoose = false;
			this.checkBox2.Invoke(new MethodInvoker(delegate
			{
				bool @checked = this.checkBox2.Checked;
				if (@checked)
				{
					wipechoose = true;
				}
			}));
			this.button2.Invoke(new MethodInvoker(delegate
			{
				this.maxwait = (int)this.numericUpDown10.Value;
			}));
			this.cmd.wipe(string.Join(";", currentbk.appList.ToArray()));
			DateTime now = DateTime.Now;
			while (!this.cmdResult.wipe)
			{
				Thread.Sleep(1000);
				bool flag = (DateTime.Now - now).TotalSeconds > (double)this.maxwait;
				if (flag)
				{
					this.button2.Invoke(new MethodInvoker(delegate
					{
						bool flag3 = this.button2.Text == "Disconnect";
						if (flag3)
						{
							this.button2_Click(null, null);
						}
					}));
					return;
				}
				this.cmd.checkwipe();
			}
			this.button2.Invoke(new MethodInvoker(delegate
			{
				bool @checked = this.fakelang.Checked;
				if (@checked)
				{
					this.cmd.changelanguage(this.listlanguagecode.FirstOrDefault((languagecode x) => x.langname == this.comboBox1.Text).langcode);
				}
				bool checked2 = this.checkBox5.Checked;
				if (checked2)
				{
					this.cmd.changetimezone(this.ltimezone.Text);
				}
				else
				{
					this.cmd.changetimezone("orig");
				}
				bool checked3 = this.fakeregion.Checked;
				if (checked3)
				{
					this.cmd.changeregion(this.listcountrycodeiOS.FirstOrDefault((countrycodeiOS x) => x.countryname == this.comboBox2.Text).countrycode);
				}
			}));
			this.cmdResult.restore = false;
			this.cmd.restore(currentbk.filename);
			DateTime now2 = DateTime.Now;
			this.button2.Invoke(new MethodInvoker(delegate
			{
				this.maxwait = (int)this.numericUpDown10.Value;
			}));
			while (!this.cmdResult.restore)
			{
				Thread.Sleep(500);
				bool flag2 = (DateTime.Now - now2).TotalSeconds > (double)this.maxwait;
				if (flag2)
				{
					return;
				}
				this.cmd.checkrestore();
			}
			this.listView4.Invoke(new MethodInvoker(delegate
			{
				this.listView4.Items[selectedindex].BackColor = Color.Lime;
				this.label1.Text = "App restored";
				this.button27.Enabled = true;
			}));
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x000021A5 File Offset: 0x000003A5
		private void tabPage8_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00011DA8 File Offset: 0x0000FFA8
		private void removeandreplace()
		{
			bool flag = AppDomain.CurrentDomain.FriendlyName == "_AutoLead.exe";
			if (flag)
			{
				Thread.Sleep(100);
				Process[] processesByName = Process.GetProcessesByName("AutoLead");
				while (processesByName.Count<Process>() > 0)
				{
					Process[] array = processesByName;
					for (int i = 0; i < array.Length; i++)
					{
						Process process = array[i];
						try
						{
							process.Kill();
						}
						catch (Exception)
						{
						}
					}
					processesByName = Process.GetProcessesByName("AutoLead");
					Thread.Sleep(100);
				}
				File.Delete(AppDomain.CurrentDomain.BaseDirectory + "AutoLead.exe");
				File.Copy(AppDomain.CurrentDomain.BaseDirectory + "_AutoLead.exe", AppDomain.CurrentDomain.BaseDirectory + "AutoLead.exe", true);
				Process.Start(new ProcessStartInfo
				{
					FileName = "AutoLead.exe",
					WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory
				});
				Application.Exit();
				Environment.Exit(0);
			}
			else
			{
				Process[] processesByName2 = Process.GetProcessesByName("_AutoLead");
				while (processesByName2.Count<Process>() > 0)
				{
					Thread.Sleep(100);
					Process[] array2 = processesByName2;
					for (int j = 0; j < array2.Length; j++)
					{
						Process process2 = array2[j];
						try
						{
							process2.Kill();
						}
						catch (Exception)
						{
						}
					}
					processesByName2 = Process.GetProcessesByName("_AutoLead");
				}
				try
				{
					bool flag2 = File.Exists(AppDomain.CurrentDomain.BaseDirectory + "_AutoLead.exe");
					if (flag2)
					{
						MessageBox.Show("Để bật chức năng check IP trước khi mở off và mở ứng dụng, vào tab Setting-> Tick vào ô \"Check IP trước khi mở Link Offer và trước khi mở Ứng dụng \"");
					}
					File.Delete(AppDomain.CurrentDomain.BaseDirectory + "_AutoLead.exe");
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00011FA0 File Offset: 0x000101A0
		private void savecheckedssh()
		{
			string path = AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\checkssh.dat";
			string text = "";
			foreach (ListViewItem listViewItem in this.listView4.Items)
			{
				bool flag = listViewItem != null && listViewItem.Checked;
				if (flag)
				{
					text += listViewItem.SubItems[7].Text;
					text += "\r\n";
				}
			}
			bool flag2 = !Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber);
			if (flag2)
			{
				Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber);
			}
			File.WriteAllText(path, text);
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x000120B0 File Offset: 0x000102B0
		private void saveofferlist()
		{
			bool flag = this.DeviceInfo.SerialNumber != null;
			if (flag)
			{
				string path = AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\offerlist.dat";
				string text = this.offerListItem.Count.ToString();
				foreach (offerItem current in this.offerListItem)
				{
					text += "\r\n";
					text += current.offerEnable.ToString();
					text += "||";
					text += current.offerName;
					text += "||";
					text += current.offerURL;
					text += "||";
					text += current.appName;
					text += "||";
					text += current.appID;
					text += "||";
					text += current.timeSleepBefore.ToString();
					text += "||";
					text += current.timeSleepBeforeRandom.ToString();
					text += "||";
					text += current.range1.ToString();
					text += "||";
					text += current.range2.ToString();
					text += "||";
					text += current.timeSleep.ToString();
					text += "||";
					text += current.useScript.ToString();
					text += "||";
					text += current.script.Replace("\r\n", "__");
					text += "||";
					text += current.referer.Replace("\r\n", "__");
				}
				bool flag2 = !Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber);
				if (flag2)
				{
					Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber);
				}
				File.WriteAllText(path, text);
			}
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x0001235C File Offset: 0x0001055C
		private void loadofferlist()
		{
			bool flag = this.DeviceInfo.SerialNumber != null;
			if (flag)
			{
				this.offerListItem.Clear();
				this.listView1.Items.Clear();
				bool flag2 = File.Exists(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\offerlist.dat");
				if (flag2)
				{
					string[] array = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\offerlist.dat").Split(new string[]
					{
						"\r\n"
					}, StringSplitOptions.None);
					int num = (int)Convert.ToInt16(array[0]);
					bool flag3 = num != array.Count<string>() - 1;
					if (!flag3)
					{
						for (int i = 0; i < array.Count<string>() - 1; i++)
						{
							string text = array[i + 1];
							string[] array2 = text.Split(new string[]
							{
								"||"
							}, StringSplitOptions.None);
							offerItem offerItem = new offerItem();
							try
							{
								offerItem.offerEnable = Convert.ToBoolean(array2[0]);
								offerItem.offerName = array2[1];
								offerItem.offerURL = array2[2];
								offerItem.appName = array2[3];
								offerItem.appID = array2[4];
								offerItem.timeSleepBefore = Convert.ToInt32(array2[5]);
								offerItem.timeSleepBeforeRandom = Convert.ToBoolean(array2[6]);
								offerItem.range1 = Convert.ToInt32(array2[7]);
								offerItem.range2 = Convert.ToInt32(array2[8]);
								offerItem.timeSleep = Convert.ToInt32(array2[9]);
								offerItem.useScript = Convert.ToBoolean(array2[10]);
								offerItem.script = array2[11].Replace("__", "\r\n");
								offerItem.referer = "";
								offerItem.referer = array2[12].Replace("__", "\r\n");
							}
							catch (Exception var_10_1DE)
							{
							}
							this.offerListItem.Add(offerItem);
							ListViewItem value = new ListViewItem(new string[]
							{
								offerItem.offerName,
								offerItem.offerURL,
								offerItem.appName,
								offerItem.timeSleep.ToString(),
								offerItem.useScript.ToString()
							});
							this.listView1.Items.Add(value);
						}
						foreach (offerItem current in this.offerListItem)
						{
							bool offerEnable = current.offerEnable;
							if (offerEnable)
							{
								this.listView1.Items[this.offerListItem.IndexOf(current)].Checked = true;
							}
						}
					}
				}
			}
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00012664 File Offset: 0x00010864
		private void savescripts()
		{
			bool flag = this.DeviceInfo.SerialNumber != null;
			if (flag)
			{
				string path = AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\scripts.dat";
				bool flag2 = !Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber);
				if (flag2)
				{
					Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber);
				}
				string text = this.listView7.Items.Count + "||";
				foreach (Script current in this.listscript)
				{
					text = string.Concat(new string[]
					{
						text,
						current.scriptname,
						"##",
						current.script,
						"##",
						current.slot.ToString(),
						"@@"
					});
				}
				File.WriteAllText(path, text);
			}
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x000127AC File Offset: 0x000109AC
		private void loadscripts()
		{
			bool flag = this.DeviceInfo.SerialNumber != null;
			if (flag)
			{
				this.listscript.Clear();
				bool flag2 = File.Exists(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\scripts.dat");
				if (flag2)
				{
					string[] array = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\scripts.dat").Split(new string[]
					{
						"||"
					}, StringSplitOptions.None);
					try
					{
						for (int i = 1; i < Convert.ToInt32(array[0]); i++)
						{
							this.listView7.Items.Add(new ListViewItem("Slot " + i.ToString()));
						}
						string[] array2 = array[1].Split(new string[]
						{
							"@@"
						}, StringSplitOptions.None);
						string[] array3 = array2;
						for (int j = 0; j < array3.Length; j++)
						{
							string text = array3[j];
							string[] array4 = text.Split(new string[]
							{
								"##"
							}, StringSplitOptions.None);
							Script script = new Script();
							script.scriptname = array4[0];
							script.script = array4[1];
							script.slot = Convert.ToInt32(array4[2]);
							this.listscript.Add(script);
						}
					}
					catch (Exception var_11_160)
					{
					}
				}
			}
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00012934 File Offset: 0x00010B34
		private void saveothersetting()
		{
			bool flag = this.DeviceInfo.SerialNumber != null;
			if (flag)
			{
				string path = AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\setting.dat";
				bool flag2 = !Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber);
				if (flag2)
				{
					Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber);
				}
				string text = string.Concat(new string[]
				{
					this.checkBox1.Checked.ToString(),
					"||",
					this.checkBox3.Checked.ToString(),
					"||",
					this.checkBox2.Checked.ToString(),
					"||",
					this.safariX.Value.ToString(),
					"||"
				});
				text = string.Concat(new string[]
				{
					text,
					this.safariY.Value.ToString(),
					"||",
					this.itunesX.Value.ToString(),
					"||",
					this.itunesY.Value.ToString(),
					"||",
					this.numericUpDown2.Value.ToString(),
					"||",
					this.rsswaitnum.Value.ToString()
				});
				text = string.Concat(new string[]
				{
					text,
					"||",
					this.textBox1.Text,
					"||",
					this.textBox2.Text.Replace("\r\n", "__")
				});
				text = string.Concat(new string[]
				{
					text,
					"||",
					this.proxytool.Text,
					"||",
					this.comboBox5.Text,
					"||",
					this.autoreconnect.Checked.ToString(),
					"||",
					this.comment.Text,
					"||",
					this.numericUpDown3.Value.ToString()
				});
				text = string.Concat(new string[]
				{
					text,
					"||",
					this.checkBox13.Checked.ToString(),
					"||",
					this.fakedevice.Checked.ToString(),
					"||",
					this.checkBox11.Checked.ToString(),
					"||",
					this.fileofname.Text,
					"||",
					this.fakeversion.Checked.ToString()
				});
				text = string.Concat(new string[]
				{
					text,
					"||",
					this.fakemodel.Checked.ToString(),
					"||",
					this.ipad.Checked.ToString(),
					"||",
					this.iphone.Checked.ToString(),
					"||",
					this.ipod.Checked.ToString()
				});
				text = string.Concat(new string[]
				{
					text,
					"||",
					this.fakelang.Checked.ToString(),
					"||",
					this.comboBox1.Text,
					"||",
					this.fakeregion.Checked.ToString(),
					"||",
					this.comboBox2.Text,
					"||",
					this.numericUpDown4.Value.ToString(),
					"||",
					this.checkBox4.Checked.ToString(),
					"||",
					this.numericUpDown5.Value.ToString()
				});
				text = string.Concat(new string[]
				{
					text,
					"||",
					this.checkBox5.Checked.ToString(),
					"||",
					this.ltimezone.Text
				});
				text = string.Concat(new string[]
				{
					text,
					"||",
					this.checkBox6.Checked.ToString(),
					"||",
					this.checkBox7.Checked.ToString(),
					"||",
					this.comboBox3.Text,
					"||true"
				});
				text = string.Concat(new string[]
				{
					text,
					"||",
					this.checkBox9.Checked.ToString(),
					"||",
					this.carrierBox.Text
				});
				text = string.Concat(new string[]
				{
					text,
					"||",
					this.checkBox10.Checked.ToString(),
					"||",
					this.numericUpDown6.Value.ToString()
				});
				text = text + "||" + this.checkBox12.Checked.ToString();
				text = text + "||" + this.checkBox14.Checked.ToString();
				text = text + "||" + this.checkBox15.Checked.ToString();
				text = text + "||" + this.checkBox17.Checked.ToString();
				text = text + "||" + this.checkBox18.Checked.ToString();
				text = text + "||" + this.textBox11.Text;
				text = text + "||" + this.numericUpDown10.Value.ToString();
				text = text + "||" + this.checkBox19.Checked.ToString();
				text = string.Concat(new string[]
				{
					text,
					"||",
					this.latitude.Value.ToString(),
					"||",
					this.longtitude.Value.ToString()
				});
				text = text + "||" + this.checkBox20.Checked.ToString();
				text = text + "||" + this.sameVip.Checked.ToString();
				File.WriteAllText(path, text);
			}
		}

		// Token: 0x060000EB RID: 235 RVA: 0x000130AC File Offset: 0x000112AC
		private void loadothresetting()
		{
			bool flag = this.DeviceInfo.SerialNumber != null;
			if (flag)
			{
				bool flag2 = File.Exists(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\setting.dat");
				if (flag2)
				{
					string[] array = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\setting.dat").Split(new string[]
					{
						"||"
					}, StringSplitOptions.None);
					try
					{
						this.checkBox1.Checked = Convert.ToBoolean(array[0]);
						this.checkBox3.Checked = Convert.ToBoolean(array[1]);
						this.checkBox2.Checked = Convert.ToBoolean(array[2]);
						this.safariX.Value = Convert.ToDecimal(array[3]);
						this.safariY.Value = Convert.ToDecimal(array[4]);
						this.itunesX.Value = Convert.ToDecimal(array[5]);
						this.itunesY.Value = Convert.ToDecimal(array[6]);
						this.numericUpDown2.Value = Convert.ToDecimal(array[7]);
						this.rsswaitnum.Value = Convert.ToDecimal(array[8]);
						this.textBox1.Text = array[9];
						this.textBox2.Text = array[10].Replace("__", "\r\n");
						this.proxytool.Text = array[11];
						this.proxytool.Refresh();
						this.comboBox5.Text = array[12];
						this.comment.Text = array[14];
						this.autoreconnect.Checked = Convert.ToBoolean(array[13]);
						this.numericUpDown3.Value = Convert.ToDecimal(array[15]);
						this.checkBox13.Checked = Convert.ToBoolean(array[16]);
						this.fakedevice.Checked = Convert.ToBoolean(array[17]);
						this.checkBox11.Checked = Convert.ToBoolean(array[18]);
						this.fileofname.Text = array[19];
						this.fakeversion.Checked = Convert.ToBoolean(array[20]);
						this.fakemodel.Checked = Convert.ToBoolean(array[21]);
						this.ipad.Checked = Convert.ToBoolean(array[22]);
						this.iphone.Checked = Convert.ToBoolean(array[23]);
						this.ipod.Checked = Convert.ToBoolean(array[24]);
						this.fakelang.Checked = Convert.ToBoolean(array[25]);
						this.comboBox1.Text = array[26];
						this.fakeregion.Checked = Convert.ToBoolean(array[27]);
						this.comboBox2.Text = array[28];
						this.numericUpDown4.Value = Convert.ToDecimal(array[29]);
						this.checkBox4.Checked = Convert.ToBoolean(array[30]);
						this.numericUpDown5.Value = Convert.ToDecimal(array[31]);
						this.checkBox5.Checked = Convert.ToBoolean(array[32]);
						this.ltimezone.Text = array[33];
						this.checkBox6.Checked = Convert.ToBoolean(array[34]);
						this.checkBox7.Checked = Convert.ToBoolean(array[35]);
						this.checkBox6_CheckedChanged(null, null);
						this.comboBox3.Text = array[36];
						this.checkBox9.Checked = Convert.ToBoolean(array[38]);
						this.carrierBox.Text = array[39];
						this.checkBox10.Checked = Convert.ToBoolean(array[40]);
						this.numericUpDown6.Value = Convert.ToDecimal(array[41]);
						this.checkBox12.Checked = Convert.ToBoolean(array[42]);
						this.checkBox14.Checked = Convert.ToBoolean(array[43]);
						this.checkBox15.Checked = Convert.ToBoolean(array[44]);
						this.checkBox17.Checked = Convert.ToBoolean(array[45]);
						this.checkBox18.Checked = Convert.ToBoolean(array[46]);
						this.textBox11.Text = array[47];
						this.numericUpDown10.Value = Convert.ToInt32(array[48]);
						this.checkBox19.Checked = Convert.ToBoolean(array[49]);
						this.latitude.Value = Convert.ToDecimal(array[50]);
						this.longtitude.Value = Convert.ToDecimal(array[51]);
						this.checkBox20.Checked = Convert.ToBoolean(array[52]);
						this.sameVip.Checked = Convert.ToBoolean(array[53]);
					}
					catch (Exception)
					{
					}
				}
			}
		}

		// Token: 0x060000EC RID: 236 RVA: 0x0001359C File Offset: 0x0001179C
		private void savessh()
		{
			bool flag = this.DeviceInfo.SerialNumber != null;
			if (flag)
			{
				string path = AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\ssh.dat";
				bool flag2 = !Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber);
				if (flag2)
				{
					Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber);
				}
				List<string> list = new List<string>();
				foreach (ssh current in this.listssh)
				{
					string item = string.Concat(new string[]
					{
						current.IP,
						"||",
						current.username,
						"||",
						current.password,
						"||",
						current.country,
						"||",
						current.countrycode,
						"||",
						current.used.ToString(),
						"||",
						current.live
					});
					list.Add(item);
				}
				File.WriteAllText(path, string.Join("\r\n", list));
			}
		}

		// Token: 0x060000ED RID: 237 RVA: 0x0001372C File Offset: 0x0001192C
		private void savevip72()
		{
			bool flag = this.DeviceInfo.SerialNumber != null;
			if (flag)
			{
				string path = AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\vip72.dat";
				bool flag2 = !Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber);
				if (flag2)
				{
					Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber);
				}
				string text = "";
				foreach (vipaccount current in this.listvipacc)
				{
					text = string.Concat(new string[]
					{
						text,
						current.username,
						"||",
						current.password,
						"\r\n"
					});
				}
				Encryptor encryptor = new Encryptor();
				File.WriteAllText(path, encryptor.Encrypt(text, this.privatekey));
			}
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00013854 File Offset: 0x00011A54
		private void loadvip72()
		{
			bool flag = this.DeviceInfo.SerialNumber != null;
			if (flag)
			{
				this.listvipacc.Clear();
				this.listView3.Items.Clear();
				bool flag2 = File.Exists(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\vip72.dat");
				if (flag2)
				{
					Decryptor decryptor = new Decryptor();
					string[] array = decryptor.Decrypt(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\vip72.dat"), this.privatekey).Split(new string[]
					{
						"\r\n"
					}, StringSplitOptions.None);
					string[] array2 = array;
					for (int i = 0; i < array2.Length; i++)
					{
						string text = array2[i];
						string[] array3 = text.Split(new string[]
						{
							"||"
						}, StringSplitOptions.None);
						bool flag3 = array3.Count<string>() == 2;
						if (flag3)
						{
							vipaccount vipaccount = new vipaccount();
							vipaccount.username = array3[0];
							vipaccount.password = array3[1];
							vipaccount.limited = false;
							this.listvipacc.Add(vipaccount);
							ListViewItem value = new ListViewItem(new string[]
							{
								vipaccount.username,
								vipaccount.password
							});
							this.listView3.Items.Add(value);
						}
					}
				}
			}
		}

		// Token: 0x060000EF RID: 239 RVA: 0x000139C8 File Offset: 0x00011BC8
		private void loadssh()
		{
			bool flag = this.DeviceInfo.SerialNumber != null;
			if (flag)
			{
				this.listssh.Clear();
				this.listView2.Items.Clear();
				bool flag2 = File.Exists(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\ssh.dat");
				if (flag2)
				{
					string[] array = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\ssh.dat").Split(new string[]
					{
						"\r\n"
					}, StringSplitOptions.None);
					string[] array2 = array;
					for (int i = 0; i < array2.Length; i++)
					{
						string text = array2[i];
						string[] array3 = text.Split(new string[]
						{
							"||"
						}, StringSplitOptions.None);
						bool flag3 = array3.Count<string>() == 7;
						if (flag3)
						{
							ssh ssh = new ssh();
							ssh.IP = array3[0];
							ssh.username = array3[1];
							ssh.password = array3[2];
							ssh.country = array3[3];
							ssh.countrycode = array3[4];
							ssh.used = Convert.ToBoolean(array3[5]);
							ssh.live = array3[6];
							this.listssh.Add(ssh);
							ListViewItem listViewItem = new ListViewItem(new string[]
							{
								ssh.IP,
								ssh.username,
								ssh.password,
								ssh.country
							});
							bool flag4 = ssh.live == "alive";
							if (flag4)
							{
								listViewItem.BackColor = Color.Lime;
							}
							bool flag5 = ssh.live == "dead";
							if (flag5)
							{
								listViewItem.BackColor = Color.Red;
							}
							bool used = ssh.used;
							if (used)
							{
								listViewItem.BackColor = Color.Aqua;
							}
							this.listView2.Items.Add(listViewItem);
						}
					}
				}
				this.ssh_uncheck.Invoke(new MethodInvoker(delegate
				{
					Control arg_43_0 = this.ssh_uncheck;
					string arg_3E_0 = "Uncheck:";
					IEnumerable<ssh> arg_31_0 = this.listssh;
					Func<ssh, bool> arg_31_1;
					if ((arg_31_1 = Form1.<>c.<>9__197_1) == null)
					{
						arg_31_1 = (Form1.<>c.<>9__197_1 = new Func<ssh, bool>(Form1.<>c.<>9.<loadssh>b__197_1));
					}
					arg_43_0.Text = arg_3E_0 + arg_31_0.Count(arg_31_1).ToString();
					Control arg_8B_0 = this.ssh_used;
					string arg_86_0 = "Used:";
					IEnumerable<ssh> arg_79_0 = this.listssh;
					Func<ssh, bool> arg_79_1;
					if ((arg_79_1 = Form1.<>c.<>9__197_2) == null)
					{
						arg_79_1 = (Form1.<>c.<>9__197_2 = new Func<ssh, bool>(Form1.<>c.<>9.<loadssh>b__197_2));
					}
					arg_8B_0.Text = arg_86_0 + arg_79_0.Count(arg_79_1).ToString();
					Control arg_D3_0 = this.ssh_live;
					string arg_CE_0 = "Live:";
					IEnumerable<ssh> arg_C1_0 = this.listssh;
					Func<ssh, bool> arg_C1_1;
					if ((arg_C1_1 = Form1.<>c.<>9__197_3) == null)
					{
						arg_C1_1 = (Form1.<>c.<>9__197_3 = new Func<ssh, bool>(Form1.<>c.<>9.<loadssh>b__197_3));
					}
					arg_D3_0.Text = arg_CE_0 + arg_C1_0.Count(arg_C1_1).ToString();
					Control arg_11B_0 = this.ss_dead;
					string arg_116_0 = "Dead:";
					IEnumerable<ssh> arg_109_0 = this.listssh;
					Func<ssh, bool> arg_109_1;
					if ((arg_109_1 = Form1.<>c.<>9__197_4) == null)
					{
						arg_109_1 = (Form1.<>c.<>9__197_4 = new Func<ssh, bool>(Form1.<>c.<>9.<loadssh>b__197_4));
					}
					arg_11B_0.Text = arg_116_0 + arg_109_0.Count(arg_109_1).ToString();
				}));
			}
			bool flag6 = this.proxytool.Text == "SSH";
			if (flag6)
			{
				IEnumerable<ssh> arg_265_0 = this.listssh;
				Func<ssh, string> arg_265_1;
				if ((arg_265_1 = Form1.<>c.<>9__197_5) == null)
				{
					arg_265_1 = (Form1.<>c.<>9__197_5 = new Func<ssh, string>(Form1.<>c.<>9.<loadssh>b__197_5));
				}
				IEnumerable<string> enumerable = arg_265_0.Select(arg_265_1).Distinct<string>();
				IEnumerable<string> arg_292_0 = enumerable;
				Func<string, string> arg_292_1;
				if ((arg_292_1 = Form1.<>c.<>9__197_6) == null)
				{
					arg_292_1 = (Form1.<>c.<>9__197_6 = new Func<string, string>(Form1.<>c.<>9.<loadssh>b__197_6));
				}
				arg_292_0.OrderBy(arg_292_1);
				this.comboBox5.Items.Clear();
				foreach (string current in enumerable)
				{
					this.comboBox5.Items.Add(current);
				}
			}
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x000022F8 File Offset: 0x000004F8
		private void loadsetting()
		{
			this.loadssh();
			this.loadvip72();
			this.loadscripts();
			this.loadofferlist();
			this.loadothresetting();
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00013CD4 File Offset: 0x00011ED4
		private void checkversion()
		{
			bool flag = !File.Exists(AppDomain.CurrentDomain.BaseDirectory + "Routrek.granados.dll");
			if (flag)
			{
				WebClient webClient = new WebClient();
				webClient.DownloadFile("http://5.249.146.35/Routrek.granados.dll", AppDomain.CurrentDomain.BaseDirectory + "Routrek.granados.dll");
			}
			string productVersion = Application.ProductVersion;
			string text = "";
			try
			{
				text = new WebClient().DownloadString("http://5.249.146.35/version.txt");
			}
			catch (Exception)
			{
				MessageBox.Show("Can't conenct to server, please try again", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				Application.Exit();
				Environment.Exit(0);
			}
			if (!(productVersion != text.Replace("\r\n", "")))
			{
				DialogResult dialogResult = MessageBox.Show("Đã có phiên bản mới, bạn có muốn update không?", Application.ProductName, MessageBoxButtons.YesNo);
				DialogResult dialogResult2 = dialogResult;
				if (dialogResult2 != DialogResult.Yes)
				{
					if (dialogResult2 != DialogResult.No)
					{
					}
				}
				else
				{
					using (WebClient webClient2 = new WebClient())
					{
						try
						{
							webClient2.Credentials = CredentialCache.DefaultNetworkCredentials;
							webClient2.DownloadProgressChanged += new DownloadProgressChangedEventHandler(this.client_DownloadProgressChanged);
							webClient2.DownloadFileCompleted += new AsyncCompletedEventHandler(this.downloadcompleted);
							webClient2.DownloadFileAsync(new Uri("http://autoleadios.com/AutoLead.txt"), AppDomain.CurrentDomain.BaseDirectory + "_AutoLead.exe");
						}
						catch (Exception)
						{
						}
						this.downloadform.ShowDialog();
					}
				}
			}
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00013E70 File Offset: 0x00012070
		private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			double num = double.Parse(e.BytesReceived.ToString());
			double num2 = double.Parse(e.TotalBytesToReceive.ToString());
			double d = num / num2 * 100.0;
			this.downloadform.progressBar1.Value = int.Parse(Math.Truncate(d).ToString());
			this.downloadform.progressBar1.Refresh();
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00013EEC File Offset: 0x000120EC
		private void downloadcompleted(object sender, AsyncCompletedEventArgs e)
		{
			bool flag = e.Error == null;
			if (flag)
			{
				Process.Start(new ProcessStartInfo
				{
					FileName = "_AutoLead.exe",
					WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory
				});
				Application.Exit();
				Environment.Exit(0);
			}
			else
			{
				MessageBox.Show("Can't download file, please try again", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				this.downloadform.Hide();
			}
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x0000229E File Offset: 0x0000049E
		private void safariX_ValueChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x0000229E File Offset: 0x0000049E
		private void safariY_ValueChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x0000229E File Offset: 0x0000049E
		private void itunesX_ValueChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x0000229E File Offset: 0x0000049E
		private void itunesY_ValueChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x0000229E File Offset: 0x0000049E
		private void numericUpDown2_ValueChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x0000229E File Offset: 0x0000049E
		private void rsswaitnum_ValueChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x060000FA RID: 250 RVA: 0x0000229E File Offset: 0x0000049E
		private void textBox2_TextChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x060000FB RID: 251 RVA: 0x0000229E File Offset: 0x0000049E
		private void checkBox3_CheckedChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x060000FC RID: 252 RVA: 0x0000229E File Offset: 0x0000049E
		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00013F64 File Offset: 0x00012164
		private void listView4_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			bool flag = e.Column != 0;
			if (flag)
			{
				bool flag2 = e.Column == this.lvwColumnSorter.SortColumn;
				if (flag2)
				{
					bool flag3 = this.lvwColumnSorter.Order == SortOrder.Ascending;
					if (flag3)
					{
						this.lvwColumnSorter.Order = SortOrder.Descending;
					}
					else
					{
						this.lvwColumnSorter.Order = SortOrder.Ascending;
					}
				}
				else
				{
					this.lvwColumnSorter.SortColumn = e.Column;
					this.lvwColumnSorter.Order = SortOrder.Ascending;
				}
				bool flag4 = this.lvwColumnSorter.Order == SortOrder.Ascending;
				if (flag4)
				{
					switch (e.Column)
					{
					case 1:
					{
						IEnumerable<backup> arg_EE_0 = this.listbackup;
						Func<backup, string> arg_EE_1;
						if ((arg_EE_1 = Form1.<>c.<>9__211_0) == null)
						{
							arg_EE_1 = (Form1.<>c.<>9__211_0 = new Func<backup, string>(Form1.<>c.<>9.<listView4_ColumnClick>b__211_0));
						}
						this.listbackup = arg_EE_0.OrderBy(arg_EE_1).ToList<backup>();
						break;
					}
					case 2:
					{
						IEnumerable<backup> arg_128_0 = this.listbackup;
						Func<backup, string> arg_128_1;
						if ((arg_128_1 = Form1.<>c.<>9__211_1) == null)
						{
							arg_128_1 = (Form1.<>c.<>9__211_1 = new Func<backup, string>(Form1.<>c.<>9.<listView4_ColumnClick>b__211_1));
						}
						this.listbackup = arg_128_0.OrderBy(arg_128_1).ToList<backup>();
						break;
					}
					case 3:
					{
						IEnumerable<backup> arg_162_0 = this.listbackup;
						Func<backup, string> arg_162_1;
						if ((arg_162_1 = Form1.<>c.<>9__211_2) == null)
						{
							arg_162_1 = (Form1.<>c.<>9__211_2 = new Func<backup, string>(Form1.<>c.<>9.<listView4_ColumnClick>b__211_2));
						}
						this.listbackup = arg_162_0.OrderBy(arg_162_1).ToList<backup>();
						break;
					}
					case 4:
					{
						IEnumerable<backup> arg_19C_0 = this.listbackup;
						Func<backup, string> arg_19C_1;
						if ((arg_19C_1 = Form1.<>c.<>9__211_3) == null)
						{
							arg_19C_1 = (Form1.<>c.<>9__211_3 = new Func<backup, string>(Form1.<>c.<>9.<listView4_ColumnClick>b__211_3));
						}
						this.listbackup = arg_19C_0.OrderBy(arg_19C_1).ToList<backup>();
						break;
					}
					case 5:
					{
						IEnumerable<backup> arg_1D6_0 = this.listbackup;
						Func<backup, string> arg_1D6_1;
						if ((arg_1D6_1 = Form1.<>c.<>9__211_4) == null)
						{
							arg_1D6_1 = (Form1.<>c.<>9__211_4 = new Func<backup, string>(Form1.<>c.<>9.<listView4_ColumnClick>b__211_4));
						}
						this.listbackup = arg_1D6_0.OrderBy(arg_1D6_1).ToList<backup>();
						break;
					}
					case 6:
					{
						IEnumerable<backup> arg_20D_0 = this.listbackup;
						Func<backup, string> arg_20D_1;
						if ((arg_20D_1 = Form1.<>c.<>9__211_5) == null)
						{
							arg_20D_1 = (Form1.<>c.<>9__211_5 = new Func<backup, string>(Form1.<>c.<>9.<listView4_ColumnClick>b__211_5));
						}
						this.listbackup = arg_20D_0.OrderBy(arg_20D_1).ToList<backup>();
						break;
					}
					case 7:
					{
						IEnumerable<backup> arg_244_0 = this.listbackup;
						Func<backup, string> arg_244_1;
						if ((arg_244_1 = Form1.<>c.<>9__211_6) == null)
						{
							arg_244_1 = (Form1.<>c.<>9__211_6 = new Func<backup, string>(Form1.<>c.<>9.<listView4_ColumnClick>b__211_6));
						}
						this.listbackup = arg_244_0.OrderBy(arg_244_1).ToList<backup>();
						break;
					}
					}
				}
				else
				{
					switch (e.Column)
					{
					case 1:
					{
						IEnumerable<backup> arg_2B6_0 = this.listbackup;
						Func<backup, string> arg_2B6_1;
						if ((arg_2B6_1 = Form1.<>c.<>9__211_7) == null)
						{
							arg_2B6_1 = (Form1.<>c.<>9__211_7 = new Func<backup, string>(Form1.<>c.<>9.<listView4_ColumnClick>b__211_7));
						}
						this.listbackup = arg_2B6_0.OrderByDescending(arg_2B6_1).ToList<backup>();
						break;
					}
					case 2:
					{
						IEnumerable<backup> arg_2F0_0 = this.listbackup;
						Func<backup, string> arg_2F0_1;
						if ((arg_2F0_1 = Form1.<>c.<>9__211_8) == null)
						{
							arg_2F0_1 = (Form1.<>c.<>9__211_8 = new Func<backup, string>(Form1.<>c.<>9.<listView4_ColumnClick>b__211_8));
						}
						this.listbackup = arg_2F0_0.OrderByDescending(arg_2F0_1).ToList<backup>();
						break;
					}
					case 3:
					{
						IEnumerable<backup> arg_32A_0 = this.listbackup;
						Func<backup, string> arg_32A_1;
						if ((arg_32A_1 = Form1.<>c.<>9__211_9) == null)
						{
							arg_32A_1 = (Form1.<>c.<>9__211_9 = new Func<backup, string>(Form1.<>c.<>9.<listView4_ColumnClick>b__211_9));
						}
						this.listbackup = arg_32A_0.OrderByDescending(arg_32A_1).ToList<backup>();
						break;
					}
					case 4:
					{
						IEnumerable<backup> arg_364_0 = this.listbackup;
						Func<backup, string> arg_364_1;
						if ((arg_364_1 = Form1.<>c.<>9__211_10) == null)
						{
							arg_364_1 = (Form1.<>c.<>9__211_10 = new Func<backup, string>(Form1.<>c.<>9.<listView4_ColumnClick>b__211_10));
						}
						this.listbackup = arg_364_0.OrderByDescending(arg_364_1).ToList<backup>();
						break;
					}
					case 5:
					{
						IEnumerable<backup> arg_39E_0 = this.listbackup;
						Func<backup, string> arg_39E_1;
						if ((arg_39E_1 = Form1.<>c.<>9__211_11) == null)
						{
							arg_39E_1 = (Form1.<>c.<>9__211_11 = new Func<backup, string>(Form1.<>c.<>9.<listView4_ColumnClick>b__211_11));
						}
						this.listbackup = arg_39E_0.OrderByDescending(arg_39E_1).ToList<backup>();
						break;
					}
					case 6:
					{
						IEnumerable<backup> arg_3D5_0 = this.listbackup;
						Func<backup, string> arg_3D5_1;
						if ((arg_3D5_1 = Form1.<>c.<>9__211_12) == null)
						{
							arg_3D5_1 = (Form1.<>c.<>9__211_12 = new Func<backup, string>(Form1.<>c.<>9.<listView4_ColumnClick>b__211_12));
						}
						this.listbackup = arg_3D5_0.OrderByDescending(arg_3D5_1).ToList<backup>();
						break;
					}
					case 7:
					{
						IEnumerable<backup> arg_40C_0 = this.listbackup;
						Func<backup, string> arg_40C_1;
						if ((arg_40C_1 = Form1.<>c.<>9__211_13) == null)
						{
							arg_40C_1 = (Form1.<>c.<>9__211_13 = new Func<backup, string>(Form1.<>c.<>9.<listView4_ColumnClick>b__211_13));
						}
						this.listbackup = arg_40C_0.OrderByDescending(arg_40C_1).ToList<backup>();
						break;
					}
					}
				}
				this.listView4.Sort();
			}
		}

		// Token: 0x060000FE RID: 254 RVA: 0x0000229E File Offset: 0x0000049E
		private void autoreconnect_CheckedChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x060000FF RID: 255 RVA: 0x000143A0 File Offset: 0x000125A0
		private string getrandomdevice()
		{
			bool flag = !this.fakemodel.Checked || (this.fakemodel.Checked && !this.ipad.Checked && !this.iphone.Checked && !this.ipod.Checked);
			string result;
			if (flag)
			{
				result = "";
			}
			else
			{
				string value = "abcxyz";
				string value2 = "abcxyz";
				string value3 = "abcxyz";
				bool @checked = this.ipad.Checked;
				if (@checked)
				{
					value = "iPad";
				}
				bool checked2 = this.iphone.Checked;
				if (checked2)
				{
					value2 = "iPhone";
				}
				bool checked3 = this.ipod.Checked;
				if (checked3)
				{
					value3 = "iPod";
				}
				List<string> list = Resources.iDevice.Split(new string[]
				{
					"\r\n"
				}, StringSplitOptions.None).ToList<string>();
				Random random = new Random();
				int index = random.Next(0, list.Count);
				while (!list.ElementAt(index).Contains(value) && !list.ElementAt(index).Contains(value2) && !list.ElementAt(index).Contains(value3))
				{
					index = random.Next(0, list.Count);
				}
				result = list.ElementAt(index).Substring(0, list.ElementAt(index).Length - 3);
			}
			return result;
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00014508 File Offset: 0x00012708
		private void button29_Click(object sender, EventArgs e)
		{
			bool flag = this.listView4.SelectedItems.Count == 1;
			if (flag)
			{
				this.button29.Enabled = false;
				this.textBox4.Enabled = false;
				this.button29.Text = "Saving";
				Thread thread = new Thread(delegate
				{
					this.saverrsthread(this.listView4.SelectedItems[0]);
				});
				thread.Start();
			}
			else
			{
				bool flag2 = this.listView4.SelectedItems.Count > 1;
				if (flag2)
				{
					MessageBox.Show("Please select 1 item only", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
		}

		// Token: 0x06000101 RID: 257 RVA: 0x000145A4 File Offset: 0x000127A4
		private void saverrsthread(ListViewItem currentSeletectItem)
		{
			backup currentbk = this.listbackup.FirstOrDefault((backup x) => x.filename == currentSeletectItem.SubItems[7].Text);
			this.listView4.Invoke(new MethodInvoker(delegate
			{
				currentSeletectItem.BackColor = Color.Yellow;
			}));
			string filename = "";
			base.Invoke(new MethodInvoker(delegate
			{
				this.label1.Text = "Saving RRS...";
				currentbk.timemod = DateTime.Now;
				backup expr_2E = currentbk;
				int num = expr_2E.runtime;
				expr_2E.runtime = num + 1;
				filename = currentbk.filename.Replace(".zip", "");
				this.cmd.backupfull(string.Join(";", currentbk.appList.ToArray()), currentbk.filename.Replace(".zip", ""), this.textBox4.Text + "[]" + currentbk.country, currentbk.timemod.ToString("MM/dd/yyyy HH:mm:ss"), currentbk.runtime.ToString());
			}));
			this.cmdResult.backup = false;
			DateTime now = DateTime.Now;
			this.button2.Invoke(new MethodInvoker(delegate
			{
				this.maxwait = (int)this.numericUpDown10.Value;
			}));
			while (!this.cmdResult.backup)
			{
				Thread.Sleep(500);
				bool flag = (DateTime.Now - now).TotalSeconds > (double)this.maxwait;
				if (flag)
				{
					this.label1.Invoke(new MethodInvoker(delegate
					{
						this.label1.Text = "Request timeout...";
					}));
					return;
				}
				this.cmd.checkbackup(filename);
			}
			this.label1.Invoke(new MethodInvoker(delegate
			{
				currentSeletectItem.SubItems[5].Text = this.textBox4.Text;
				currentSeletectItem.SubItems[2].Text = currentbk.timemod.ToString("MM/dd/yyyy HH:mm:ss");
				currentSeletectItem.SubItems[3].Text = currentbk.runtime.ToString();
				this.label1.Text = "Saved RRS";
				this.button29.Enabled = true;
				this.textBox4.Enabled = true;
				this.button29.Text = "Save";
				currentSeletectItem.BackColor = Color.Lime;
			}));
		}

		// Token: 0x06000102 RID: 258 RVA: 0x000146CC File Offset: 0x000128CC
		private void listView4_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool flag = this.listView4.SelectedItems.Count > 0;
			if (flag)
			{
				this.textBox4.Text = this.listView4.SelectedItems[0].SubItems[5].Text;
			}
			this.label35.Text = "Selected RRS:" + this.listView4.SelectedItems.Count.ToString();
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00014750 File Offset: 0x00012950
		private void button30_Click(object sender, EventArgs e)
		{
			bool flag = this.button30.Text == "Record";
			if (flag)
			{
				this.recordstep = 0;
				this.button30.Text = "Stop Record";
				this.button30.BackColor = Color.Red;
			}
			else
			{
				this.button30.BackColor = Color.WhiteSmoke;
				this.button30.Text = "Record";
			}
		}

		// Token: 0x06000104 RID: 260 RVA: 0x000147C8 File Offset: 0x000129C8
		private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = this.button30.Text == "Stop Record";
			if (flag)
			{
				bool flag2 = this.recordstep == 0;
				if (flag2)
				{
					this.recprev = DateTime.Now;
				}
				else
				{
					RichTextBox expr_44 = this.textBox2;
					expr_44.Text = expr_44.Text + "wait(" + Math.Round((DateTime.Now - this.recprev).TotalMilliseconds / 1000.0, 2).ToString() + ")";
					RichTextBox expr_96 = this.textBox2;
					expr_96.Text += "\r\n";
					this.textBox2.Focus();
					this.textBox2.SelectionStart = this.textBox2.Text.Length;
					this.textBox2.ScrollToCaret();
					this.recprev = DateTime.Now;
				}
				this.cmd.mousedown(e.X * this.trackBar1.Value, e.Y * this.trackBar1.Value);
				this.prevx = Convert.ToInt32(this.textBox7.Text);
				this.prevy = Convert.ToInt32(this.textBox8.Text);
				this.clicklast = DateTime.Now;
				this.recordstep++;
			}
		}

		// Token: 0x06000105 RID: 261 RVA: 0x0000229E File Offset: 0x0000049E
		private void comment_TextChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00014938 File Offset: 0x00012B38
		private void listView4_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
		{
			bool flag = e.ColumnIndex == 0 && this.first == 0;
			if (flag)
			{
				this.first = 1;
				CheckBox checkBox = new CheckBox();
				base.Visible = true;
				this.listView4.SuspendLayout();
				e.DrawBackground();
				checkBox.BackColor = Color.Transparent;
				checkBox.UseVisualStyleBackColor = true;
				checkBox.SetBounds(e.Bounds.X, e.Bounds.Y, checkBox.GetPreferredSize(new Size(e.Bounds.Width, e.Bounds.Height)).Width, checkBox.GetPreferredSize(new Size(e.Bounds.Width, e.Bounds.Height)).Width);
				checkBox.Size = new Size(checkBox.GetPreferredSize(new Size(e.Bounds.Width - 1, e.Bounds.Height)).Width + 1, e.Bounds.Height);
				checkBox.Location = new Point(3, 0);
				this.listView4.Controls.Add(checkBox);
				checkBox.Show();
				checkBox.BringToFront();
				e.DrawText(TextFormatFlags.VerticalCenter);
				checkBox.Click += new EventHandler(this.Bink);
				this.listView4.ResumeLayout(true);
			}
			else
			{
				e.DrawDefault = true;
			}
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00014AD0 File Offset: 0x00012CD0
		private void Bink(object sender, EventArgs e)
		{
			CheckBox checkBox = sender as CheckBox;
			for (int i = 0; i < this.listView4.Items.Count; i++)
			{
				this.listView4.Items[i].Checked = checkBox.Checked;
			}
		}

		// Token: 0x06000108 RID: 264 RVA: 0x0000231E File Offset: 0x0000051E
		private void listView4_DrawItem(object sender, DrawListViewItemEventArgs e)
		{
			e.DrawDefault = true;
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00002329 File Offset: 0x00000529
		private void listView4_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
		{
			e.DrawDefault = true;
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00014B24 File Offset: 0x00012D24
		private void button31_Click(object sender, EventArgs e)
		{
			int index = this.listView4.Items.IndexOf(this.listView4.SelectedItems[0]);
			this.cmd.savecomment(this.listbackup.ElementAt(index).filename.Replace(".zip", ""), this.textBox4.Text + "[]" + this.listbackup.ElementAt(index).country);
			this.listView4.Items[index].SubItems[5].Text = this.textBox4.Text;
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00014BD8 File Offset: 0x00012DD8
		private void savecommentthread()
		{
			this.cmdResult.savecomment = false;
			this.label1.Invoke(new MethodInvoker(delegate
			{
				this.label1.Text = "Saving comment..";
				this.label1.Refresh();
			}));
			DateTime now = DateTime.Now;
			while (!this.cmdResult.savecomment)
			{
				Thread.Sleep(100);
				bool flag = (DateTime.Now - now).TotalSeconds > 20.0;
				if (flag)
				{
					this.label1.Invoke(new MethodInvoker(delegate
					{
						this.label1.Text = "Request timeout...";
					}));
					return;
				}
			}
			this.label1.Invoke(new MethodInvoker(delegate
			{
				this.label1.Text = "Comment saved...";
			}));
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00014C84 File Offset: 0x00012E84
		private void fakedevice_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.fakedevice.Checked;
			if (@checked)
			{
				this.checkBox11.Enabled = true;
			}
			else
			{
				this.checkBox11.Enabled = false;
			}
			this.saveothersetting();
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00014CC8 File Offset: 0x00012EC8
		private void checkBox11_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.checkBox11.Checked;
			if (@checked)
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				bool flag = openFileDialog.ShowDialog() == DialogResult.OK;
				if (flag)
				{
					this.fileofname.Text = openFileDialog.FileName;
				}
				else
				{
					bool flag2 = this.fileofname.Text == "";
					if (flag2)
					{
						this.checkBox11.Checked = false;
					}
				}
			}
			this.saveothersetting();
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00014D44 File Offset: 0x00012F44
		private void fakemodel_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.fakemodel.Checked;
			if (@checked)
			{
				this.ipad.Enabled = true;
				this.iphone.Enabled = true;
				this.ipod.Enabled = true;
			}
			else
			{
				this.ipad.Enabled = false;
				this.iphone.Enabled = false;
				this.ipod.Enabled = false;
			}
			this.saveothersetting();
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00002334 File Offset: 0x00000534
		private void fakelang_CheckedChanged(object sender, EventArgs e)
		{
			this.comboBox1.Enabled = (this.fakelang.Checked && !this.checkBox20.Checked);
			this.saveothersetting();
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00002368 File Offset: 0x00000568
		private void fakeregion_CheckedChanged(object sender, EventArgs e)
		{
			this.comboBox2.Enabled = (this.fakeregion.Checked && !this.checkBox20.Checked);
			this.saveothersetting();
		}

		// Token: 0x06000111 RID: 273 RVA: 0x0000229E File Offset: 0x0000049E
		private void checkBox13_CheckedChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x06000112 RID: 274 RVA: 0x0000239C File Offset: 0x0000059C
		private void fakeversion_CheckedChanged(object sender, EventArgs e)
		{
			this.checkBox14.Enabled = this.fakeversion.Checked;
			this.checkBox15.Enabled = this.fakeversion.Checked;
			this.saveothersetting();
		}

		// Token: 0x06000113 RID: 275 RVA: 0x0000229E File Offset: 0x0000049E
		private void ipad_CheckedChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x06000114 RID: 276 RVA: 0x0000229E File Offset: 0x0000049E
		private void iphone_CheckedChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x06000115 RID: 277 RVA: 0x0000229E File Offset: 0x0000049E
		private void ipod_CheckedChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x06000116 RID: 278 RVA: 0x0000229E File Offset: 0x0000049E
		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00014DBC File Offset: 0x00012FBC
		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			string text = this._listcountry.FirstOrDefault((string x) => x == this.comboBox2.Text);
			bool flag = text == null;
			if (flag)
			{
				text = this._listcountry.FirstOrDefault((string x) => x.Contains(this.comboBox2.Text));
			}
			this.carrierBox.Text = text;
			this.comboBox1.Text = this.listlanguagecode.FirstOrDefault((languagecode x) => x.langcode == this.listcountrycodeiOS.FirstOrDefault((countrycodeiOS y) => y.countryname == this.comboBox2.Text).languageCode).langname;
		}

		// Token: 0x06000118 RID: 280 RVA: 0x0000229E File Offset: 0x0000049E
		private void numericUpDown4_ValueChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x06000119 RID: 281 RVA: 0x0000229E File Offset: 0x0000049E
		private void checkBox4_CheckedChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x0600011A RID: 282 RVA: 0x0000229E File Offset: 0x0000049E
		private void numericUpDown5_ValueChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x0600011B RID: 283 RVA: 0x000021A5 File Offset: 0x000003A5
		private void groupBox7_Enter(object sender, EventArgs e)
		{
		}

		// Token: 0x0600011C RID: 284 RVA: 0x000021A5 File Offset: 0x000003A5
		private void tabPage7_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600011D RID: 285 RVA: 0x000023D4 File Offset: 0x000005D4
		private void DeviceIpControl_Click(object sender, EventArgs e)
		{
			Settings.Default.ipaddress = this.DeviceIpControl.Text;
		}

		// Token: 0x0600011E RID: 286 RVA: 0x000023ED File Offset: 0x000005ED
		private void DeviceIpControl_TextChanged(object sender, EventArgs e)
		{
			Settings.Default.ipaddress = this.DeviceIpControl.Text;
			Settings.Default.Save();
		}

		// Token: 0x0600011F RID: 287 RVA: 0x000021A5 File Offset: 0x000003A5
		private void comboBox1_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000120 RID: 288 RVA: 0x000021A5 File Offset: 0x000003A5
		private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00014E38 File Offset: 0x00013038
		private void ltimezone_Click(object sender, EventArgs e)
		{
			bool visible = this.listView5.Visible;
			if (visible)
			{
				this.listView5.Hide();
				this.textBox5.Hide();
			}
			else
			{
				this.listView5.Show();
				this.textBox5.Show();
			}
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00002411 File Offset: 0x00000611
		private void tabPage6_MouseClick(object sender, MouseEventArgs e)
		{
			this.listView5.Hide();
			this.textBox5.Hide();
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00014E88 File Offset: 0x00013088
		private void textBox5_TextChanged(object sender, EventArgs e)
		{
			bool flag = this.textBox5.Text != "";
			if (flag)
			{
				this.listView5.Clear();
				List<string> list = (from x in this.listtimezone
				where x.ToLower().Contains(this.textBox5.Text.ToLower())
				select x).ToList<string>();
				foreach (string current in list)
				{
					this.listView5.Items.Add(new ListViewItem(current));
				}
			}
		}

		// Token: 0x06000124 RID: 292 RVA: 0x000021A5 File Offset: 0x000003A5
		private void listView5_MouseDoubleClick(object sender, MouseEventArgs e)
		{
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00014F30 File Offset: 0x00013130
		private void listView5_MouseClick(object sender, MouseEventArgs e)
		{
			bool flag = this.listView5.SelectedItems.Count > 0;
			if (flag)
			{
				this.ltimezone.Text = this.listView5.SelectedItems[0].Text;
				this.listView5.Hide();
				this.textBox5.Hide();
			}
		}

		// Token: 0x06000126 RID: 294 RVA: 0x0000229E File Offset: 0x0000049E
		private void ltimezone_TextChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x06000127 RID: 295 RVA: 0x0000229E File Offset: 0x0000049E
		private void checkBox5_CheckedChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00014F94 File Offset: 0x00013194
		private void textBox9_TextChanged(object sender, EventArgs e)
		{
			bool flag = this.listView6.SelectedItems.Count > 0;
			if (flag)
			{
				this.listView6.SelectedItems[0].Text = this.textBox9.Text;
				List<Script> source = (from x in this.listscript
				where x.slot == this.listView7.SelectedItems[0].Index || this.listView7.SelectedItems[0].Index == 0
				select x).ToList<Script>();
				source.ElementAt(this.listView6.SelectedItems[0].Index).scriptname = this.textBox9.Text;
				this.savescripts();
			}
		}

		// Token: 0x06000129 RID: 297 RVA: 0x000021A5 File Offset: 0x000003A5
		private void listView7_MouseDown(object sender, MouseEventArgs e)
		{
		}

		// Token: 0x0600012A RID: 298 RVA: 0x000021A5 File Offset: 0x000003A5
		private void listView6_MouseDown(object sender, MouseEventArgs e)
		{
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00015030 File Offset: 0x00013230
		private void listView7_MouseClick(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Right;
			if (flag)
			{
				this.contextMenuStrip1.Show(this.listView7.PointToScreen(e.Location));
			}
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00015070 File Offset: 0x00013270
		private void listView6_MouseClick(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Right;
			if (flag)
			{
				this.moveToSlotToolStripMenuItem.DropDownItems.Clear();
				this.moveToSlotToolStripMenuItem.DropDownItems.Add("None", null, new EventHandler(this.toolStripMenuItem1_Click));
				foreach (ListViewItem listViewItem in this.listView7.Items)
				{
					bool flag2 = listViewItem.Text != "All Script";
					if (flag2)
					{
						this.moveToSlotToolStripMenuItem.DropDownItems.Add(listViewItem.Text, null, new EventHandler(this.toolStripMenuItem1_Click));
					}
				}
				this.contextMenuStrip2.Show(this.listView6.PointToScreen(e.Location));
			}
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00015170 File Offset: 0x00013370
		private void button33_Click(object sender, EventArgs e)
		{
			ListViewItem value = new ListViewItem("Slot " + this.listView7.Items.Count.ToString());
			this.listView7.Items.Add(value);
			this.savescripts();
		}

		// Token: 0x0600012E RID: 302 RVA: 0x000151C0 File Offset: 0x000133C0
		private void listview7_DeleteSlot()
		{
			bool flag = this.listView7.SelectedItems.Count > 0;
			if (flag)
			{
			}
		}

		// Token: 0x0600012F RID: 303 RVA: 0x000151E8 File Offset: 0x000133E8
		private void button34_Click(object sender, EventArgs e)
		{
			Script script = new Script();
			script.scriptname = "Script " + (this.listscript.Count + 1).ToString();
			bool flag = this.listView7.SelectedItems.Count > 0;
			if (flag)
			{
				script.slot = this.listView7.SelectedItems[0].Index;
			}
			else
			{
				this.listView7.Items[0].Selected = true;
			}
			this.listscript.Add(script);
			this.listView6.Items.Add(new ListViewItem(script.scriptname));
			this.savescripts();
		}

		// Token: 0x06000130 RID: 304 RVA: 0x000152A4 File Offset: 0x000134A4
		private void listView6_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool flag = this.listView6.SelectedItems.Count > 0;
			if (flag)
			{
				this.textBox9.Enabled = true;
				this.textBox6.Enabled = true;
				List<Script> source = (from x in this.listscript
				where x.slot == this.listView7.SelectedItems[0].Index || this.listView7.SelectedItems[0].Index == 0
				select x).ToList<Script>();
				this.textBox9.Text = source.ElementAt(this.listView6.SelectedItems[0].Index).scriptname;
				this.textBox6.Text = source.ElementAt(this.listView6.SelectedItems[0].Index).script;
			}
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00015360 File Offset: 0x00013560
		private void listView6_MouseUp(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				bool flag2 = this.listView6.SelectedItems.Count == 0;
				if (flag2)
				{
					this.textBox6.Enabled = false;
					this.textBox9.Enabled = false;
					this.textBox6.Text = "";
					this.textBox9.Text = "";
				}
			}
		}

		// Token: 0x06000132 RID: 306 RVA: 0x000153D8 File Offset: 0x000135D8
		private void textBox6_TextChanged(object sender, EventArgs e)
		{
			bool flag = this.listView6.SelectedItems.Count > 0;
			if (flag)
			{
				List<Script> source = (from x in this.listscript
				where x.slot == this.listView7.SelectedItems[0].Index || this.listView7.SelectedItems[0].Index == 0
				select x).ToList<Script>();
				source.ElementAt(this.listView6.SelectedItems[0].Index).script = this.textBox6.Text;
				this.savescripts();
			}
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00015450 File Offset: 0x00013650
		private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			bool flag = this.listView6.SelectedItems.Count > 0;
			if (flag)
			{
				List<Script> source = (from x in this.listscript
				where x.slot == this.listView7.SelectedItems[0].Index || this.listView7.SelectedItems[0].Index == 0
				select x).ToList<Script>();
				this.listscript.Remove(source.ElementAt(this.listView6.SelectedItems[0].Index));
				this.listView6.Items.Remove(this.listView6.SelectedItems[0]);
				this.textBox6.Enabled = false;
				this.textBox6.Text = "";
				this.textBox9.Enabled = false;
				this.textBox9.Text = "";
				this.checkBox6_CheckedChanged(null, null);
				this.savescripts();
			}
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00015530 File Offset: 0x00013730
		private void listView7_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool flag = this.listView7.SelectedItems.Count > 0;
			if (flag)
			{
				this.listView6.Items.Clear();
				List<Script> list = (from x in this.listscript
				where x.slot == this.listView7.SelectedItems[0].Index || this.listView7.SelectedItems[0].Index == 0
				select x).ToList<Script>();
				foreach (Script current in list)
				{
					this.listView6.Items.Add(new ListViewItem(current.scriptname));
				}
			}
		}

		// Token: 0x06000135 RID: 309 RVA: 0x000155E0 File Offset: 0x000137E0
		private void listView6_KeyDown(object sender, KeyEventArgs e)
		{
			bool flag = this.listView6.SelectedItems.Count > 0 && e.KeyCode == Keys.Delete;
			if (flag)
			{
				this.deleteToolStripMenuItem1_Click(null, null);
			}
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00015620 File Offset: 0x00013820
		private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			bool flag = this.listView6.SelectedItems.Count > 0;
			if (flag)
			{
				List<Script> source = (from x in this.listscript
				where x.slot == this.listView7.SelectedItems[0].Index || this.listView7.SelectedItems[0].Index == 0
				select x).ToList<Script>();
				source.ElementAt(this.listView6.SelectedItems[0].Index).slot = 0;
				foreach (ListViewItem listViewItem in this.listView7.Items)
				{
					bool flag2 = listViewItem.Text == ((ToolStripMenuItem)sender).Text;
					if (flag2)
					{
						source.ElementAt(this.listView6.SelectedItems[0].Index).slot = listViewItem.Index;
						break;
					}
				}
				bool flag3 = this.listView7.SelectedItems.Count > 0;
				if (flag3)
				{
					bool flag4 = this.listView7.SelectedItems[0].Index > 0 && this.listView7.SelectedItems[0].Text != ((ToolStripMenuItem)sender).Text;
					if (flag4)
					{
						this.listView6.SelectedItems[0].Remove();
					}
				}
				this.savescripts();
			}
		}

		// Token: 0x06000137 RID: 311 RVA: 0x000157A8 File Offset: 0x000139A8
		private void listView7_MouseUp(object sender, MouseEventArgs e)
		{
			bool flag = this.listView7.SelectedItems.Count == 0;
			if (flag)
			{
				this.listView6.Items.Clear();
			}
		}

		// Token: 0x06000138 RID: 312 RVA: 0x000157E0 File Offset: 0x000139E0
		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			bool flag = this.listView7.SelectedItems.Count > 0;
			if (flag)
			{
				this.listView6.Items.Clear();
				this.listscript.RemoveAll((Script x) => x.slot == this.listView7.SelectedItems[0].Index);
				IEnumerable<Script> enumerable = from x in this.listscript
				where x.slot > this.listView7.SelectedItems[0].Index
				select x;
				foreach (Script current in enumerable)
				{
					Script expr_70 = current;
					int slot = expr_70.slot;
					expr_70.slot = slot - 1;
				}
				bool flag2 = this.listView7.SelectedItems[0].Index > 0;
				if (flag2)
				{
					for (int i = this.listView7.SelectedItems[0].Index + 1; i < this.listView7.Items.Count; i++)
					{
						this.listView7.Items[i].Text = "Slot " + (i - 1).ToString();
					}
					this.listView7.SelectedItems[0].Remove();
				}
				else
				{
					this.listscript.Clear();
				}
				this.checkBox6_CheckedChanged(null, null);
				this.savescripts();
			}
		}

		// Token: 0x06000139 RID: 313 RVA: 0x0001595C File Offset: 0x00013B5C
		private void listView7_KeyDown(object sender, KeyEventArgs e)
		{
			bool flag = e.KeyCode == Keys.Delete;
			if (flag)
			{
				this.deleteToolStripMenuItem_Click(null, null);
			}
		}

		// Token: 0x0600013A RID: 314 RVA: 0x00015984 File Offset: 0x00013B84
		private void button32_Click(object sender, EventArgs e)
		{
			this.button32.Enabled = false;
			Thread thread = new Thread(new ThreadStart(this.excutescriptthread1));
			thread.Start();
		}

		// Token: 0x0600013B RID: 315 RVA: 0x000159B8 File Offset: 0x00013BB8
		private void checkBox6_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.checkBox6.Checked;
			if (@checked)
			{
				this.checkBox7.Enabled = true;
				this.comboBox3.Enabled = true;
			}
			else
			{
				this.checkBox7.Enabled = false;
				this.comboBox3.Enabled = false;
			}
			this.checkBox7_CheckedChanged(null, null);
			this.saveothersetting();
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00015A20 File Offset: 0x00013C20
		private void checkBox7_CheckedChanged(object sender, EventArgs e)
		{
			this.comboBox3.Items.Clear();
			bool @checked = this.checkBox7.Checked;
			if (@checked)
			{
				foreach (ListViewItem listViewItem in this.listView7.Items)
				{
					this.comboBox3.Items.Add(listViewItem.Text);
				}
			}
			else
			{
				foreach (Script current in this.listscript)
				{
					this.comboBox3.Items.Add(current.scriptname);
				}
			}
			this.saveothersetting();
		}

		// Token: 0x0600013D RID: 317 RVA: 0x0000229E File Offset: 0x0000049E
		private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x0600013E RID: 318 RVA: 0x0000229E File Offset: 0x0000049E
		private void checkBox8_CheckedChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x0600013F RID: 319 RVA: 0x0000242C File Offset: 0x0000062C
		private void checkBox9_CheckedChanged(object sender, EventArgs e)
		{
			this.carrierBox.Enabled = (this.checkBox9.Checked && !this.checkBox20.Checked);
			this.saveothersetting();
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00015B1C File Offset: 0x00013D1C
		private void button35_Click(object sender, EventArgs e)
		{
			bool flag = this.button35.Text == "Mở rộng";
			if (flag)
			{
				this.textBox2.Location = new Point(114, 31);
				this.textBox2.Size = new Size(224, 348);
				this.button35.Text = "Thu nhỏ";
			}
			else
			{
				this.textBox2.Location = new Point(114, 281);
				this.textBox2.Size = new Size(224, 98);
				this.button35.Text = "Mở rộng";
			}
		}

		// Token: 0x06000141 RID: 321 RVA: 0x000021A5 File Offset: 0x000003A5
		private void textBox2_KeyUp(object sender, KeyEventArgs e)
		{
		}

		// Token: 0x06000142 RID: 322 RVA: 0x000021A5 File Offset: 0x000003A5
		private void listcmd_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000143 RID: 323 RVA: 0x0000229E File Offset: 0x0000049E
		private void checkBox10_CheckedChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x06000144 RID: 324 RVA: 0x0000229E File Offset: 0x0000049E
		private void numericUpDown6_ValueChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x06000145 RID: 325 RVA: 0x0000229E File Offset: 0x0000049E
		private void carrierBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00002276 File Offset: 0x00000476
		private void ipAddressControl1_Click(object sender, EventArgs e)
		{
			this.button23.Text = "Apply";
		}

		// Token: 0x06000147 RID: 327 RVA: 0x0000229E File Offset: 0x0000049E
		private void checkBox12_CheckedChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x06000148 RID: 328 RVA: 0x0000229E File Offset: 0x0000049E
		private void numericUpDown3_ValueChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x06000149 RID: 329 RVA: 0x0000229E File Offset: 0x0000049E
		private void checkBox14_CheckedChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x0600014A RID: 330 RVA: 0x0000229E File Offset: 0x0000049E
		private void checkBox15_CheckedChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00015BCC File Offset: 0x00013DCC
		private void button36_Click(object sender, EventArgs e)
		{
			bool flag = this.code.Text == "" || this.deviceseri.Text == "";
			if (flag)
			{
				this.napcodestt.Text = "Vui lòng nhập đầy đủ thông tin";
				MessageBox.Show("Vui lòng nhập đầy đủ thông tin", base.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				this.button36.Enabled = false;
				string requestUriString = "http://5.249.146.35/random/napcode?code=" + this.code.Text + "&serial=" + this.deviceseri.Text;
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
				httpWebRequest.UserAgent = "autoleadios";
				try
				{
					Stream responseStream = httpWebRequest.GetResponse().GetResponseStream();
					StreamReader streamReader = new StreamReader(responseStream);
					string text = streamReader.ReadToEnd();
					bool flag2 = text == "notexist";
					if (flag2)
					{
						this.napcodestt.Text = "Mã code không tồn tại";
						this.napcodestt.ForeColor = Color.Red;
						MessageBox.Show("Mã code không tồn tại", base.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						this.code.Text = "";
						this.button36.Enabled = true;
					}
					else
					{
						bool flag3 = text == "redeemed";
						if (flag3)
						{
							this.napcodestt.Text = "Mã code đã được nạp";
							this.napcodestt.ForeColor = Color.Red;
							MessageBox.Show("Mã code đã được nạp", base.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
							this.button36.Enabled = true;
						}
						else
						{
							this.napcodestt.Text = "Bạn đã nạp thành công " + text + " ngày vào thiết bị";
							this.napcodestt.ForeColor = Color.Green;
							this.button36.Enabled = true;
							this.code.Text = "";
						}
					}
				}
				catch (Exception var_8_1DE)
				{
					this.napcodestt.Text = "Không thể kết nối với máy chủ";
					MessageBox.Show("Không thể kết nối với máy chủ", base.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					this.button36.Enabled = true;
				}
			}
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00002460 File Offset: 0x00000660
		private void button37_Click(object sender, EventArgs e)
		{
			this.button38_Click(null, null);
			this.button39_Click(null, null);
			this.button40_Click(null, null);
			this.button41_Click(null, null);
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00015E0C File Offset: 0x0001400C
		private void button38_Click(object sender, EventArgs e)
		{
			string sourceFileName = AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\offerlist.dat";
			string destFileName = AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting\\offerlist.dat";
			bool flag = !Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting");
			if (flag)
			{
				Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting");
			}
			try
			{
				File.Copy(sourceFileName, destFileName, true);
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x0600014E RID: 334 RVA: 0x00015EAC File Offset: 0x000140AC
		private void button39_Click(object sender, EventArgs e)
		{
			string sourceFileName = AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\ssh.dat";
			string destFileName = AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting\\ssh.dat";
			bool flag = !Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting");
			if (flag)
			{
				Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting");
			}
			try
			{
				File.Copy(sourceFileName, destFileName, true);
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00015F4C File Offset: 0x0001414C
		private void button40_Click(object sender, EventArgs e)
		{
			string sourceFileName = AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\vip72.dat";
			string destFileName = AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting\\vip72.dat";
			bool flag = !Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting");
			if (flag)
			{
				Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting");
			}
			try
			{
				File.Copy(sourceFileName, destFileName, true);
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000150 RID: 336 RVA: 0x00015FEC File Offset: 0x000141EC
		private void button41_Click(object sender, EventArgs e)
		{
			string sourceFileName = AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\setting.dat";
			string sourceFileName2 = AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\scripts.dat";
			string destFileName = AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting\\setting.dat";
			string destFileName2 = AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting\\scripts.dat";
			bool flag = !Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting");
			if (flag)
			{
				Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting");
			}
			try
			{
				File.Copy(sourceFileName, destFileName, true);
				File.Copy(sourceFileName2, destFileName2, true);
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000151 RID: 337 RVA: 0x000160CC File Offset: 0x000142CC
		private void button43_Click(object sender, EventArgs e)
		{
			string destFileName = AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\offerlist.dat";
			string sourceFileName = AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting\\offerlist.dat";
			bool flag = !Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting");
			if (flag)
			{
				Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting");
			}
			try
			{
				File.Copy(sourceFileName, destFileName, true);
			}
			catch (Exception)
			{
			}
			this.loadofferlist();
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00016174 File Offset: 0x00014374
		private void button44_Click(object sender, EventArgs e)
		{
			string destFileName = AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\ssh.dat";
			string sourceFileName = AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting\\ssh.dat";
			bool flag = !Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting");
			if (flag)
			{
				Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting");
			}
			try
			{
				File.Copy(sourceFileName, destFileName, true);
			}
			catch (Exception var_3_7E)
			{
			}
			this.loadssh();
		}

		// Token: 0x06000153 RID: 339 RVA: 0x0001621C File Offset: 0x0001441C
		private void button45_Click(object sender, EventArgs e)
		{
			string destFileName = AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\vip72.dat";
			string sourceFileName = AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting\\vip72.dat";
			bool flag = !Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting");
			if (flag)
			{
				Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting");
			}
			try
			{
				File.Copy(sourceFileName, destFileName, true);
			}
			catch (Exception)
			{
			}
			this.loadvip72();
		}

		// Token: 0x06000154 RID: 340 RVA: 0x000162C4 File Offset: 0x000144C4
		private void button46_Click(object sender, EventArgs e)
		{
			string destFileName = AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\setting.dat";
			string destFileName2 = AppDomain.CurrentDomain.BaseDirectory + this.DeviceInfo.SerialNumber + "\\scripts.dat";
			string sourceFileName = AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting\\setting.dat";
			string sourceFileName2 = AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting\\scripts.dat";
			bool flag = !Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting");
			if (flag)
			{
				Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting");
			}
			try
			{
				File.Copy(sourceFileName, destFileName, true);
				File.Copy(sourceFileName2, destFileName2, true);
			}
			catch (Exception)
			{
			}
			this.loadothresetting();
			this.loadscripts();
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00002487 File Offset: 0x00000687
		private void button42_Click(object sender, EventArgs e)
		{
			this.button43_Click(null, null);
			this.button44_Click(null, null);
			this.button45_Click(null, null);
			this.button46_Click(null, null);
		}

		// Token: 0x06000156 RID: 342 RVA: 0x000163B4 File Offset: 0x000145B4
		private void exportchanges()
		{
			bool flag = !this.checkBox16.Checked;
			if (flag)
			{
				string contents = string.Concat(new string[]
				{
					this.changes.ToString(),
					"|",
					this.c_listoff.ToString(),
					"|",
					this.c_othersetting.ToString(),
					"|",
					this.c_ssh.ToString(),
					"|",
					this.c_vip.ToString(),
					"|",
					this.c_startall.ToString(),
					"|",
					this.c_stopall.ToString(),
					"|",
					this.c_resetall.ToString()
				});
				File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "GlobalSetting\\changes.dat", contents);
			}
			else
			{
				string contents2 = string.Concat(new string[]
				{
					this.changeslocal.ToString(),
					"|",
					this.c_listofflocal.ToString(),
					"|",
					this.c_othersettinglocal.ToString(),
					"|",
					this.c_sshlocal.ToString(),
					"|",
					this.c_viplocal.ToString(),
					"|",
					this.c_startalllocal.ToString(),
					"|",
					this.c_stopalllocal.ToString(),
					"|",
					this.c_resetalllocal.ToString()
				});
				File.WriteAllText(this.documentfolder + "changes.dat", contents2);
			}
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00016588 File Offset: 0x00014788
		private void button47_Click(object sender, EventArgs e)
		{
			bool flag = !this.checkBox16.Checked;
			if (flag)
			{
				this.changes = 1 - this.changes;
				this.c_listoff = 1 - this.c_listoff;
				this.c_othersetting = 1 - this.c_othersetting;
				this.c_ssh = 1 - this.c_ssh;
				this.c_vip = 1 - this.c_vip;
			}
			else
			{
				this.changeslocal = 1 - this.changeslocal;
				this.c_listofflocal = 1 - this.c_listofflocal;
				this.c_othersettinglocal = 1 - this.c_othersettinglocal;
				this.c_sshlocal = 1 - this.c_sshlocal;
				this.c_viplocal = 1 - this.c_viplocal;
			}
			this.button37_Click(null, null);
			this.exportchanges();
		}

		// Token: 0x06000158 RID: 344 RVA: 0x0001664C File Offset: 0x0001484C
		private void button48_Click(object sender, EventArgs e)
		{
			bool flag = !this.checkBox16.Checked;
			if (flag)
			{
				this.changes = 1 - this.changes;
				this.c_listoff = 1 - this.c_listoff;
			}
			else
			{
				this.changeslocal = 1 - this.changeslocal;
				this.c_listofflocal = 1 - this.c_listofflocal;
			}
			this.button53_Click(null, null);
			this.button38_Click(null, null);
			this.exportchanges();
		}

		// Token: 0x06000159 RID: 345 RVA: 0x000166C4 File Offset: 0x000148C4
		private void button49_Click(object sender, EventArgs e)
		{
			bool flag = !this.checkBox16.Checked;
			if (flag)
			{
				this.changes = 1 - this.changes;
				this.c_ssh = 1 - this.c_ssh;
			}
			else
			{
				this.changeslocal = 1 - this.changeslocal;
				this.c_sshlocal = 1 - this.c_sshlocal;
			}
			this.button39_Click(null, null);
			this.exportchanges();
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00016734 File Offset: 0x00014934
		private void button50_Click(object sender, EventArgs e)
		{
			bool flag = !this.checkBox16.Checked;
			if (flag)
			{
				this.changes = 1 - this.changes;
				this.c_vip = 1 - this.c_vip;
			}
			else
			{
				this.changeslocal = 1 - this.changeslocal;
				this.c_viplocal = 1 - this.c_viplocal;
			}
			this.button40_Click(null, null);
			this.exportchanges();
		}

		// Token: 0x0600015B RID: 347 RVA: 0x000167A4 File Offset: 0x000149A4
		private void button51_Click(object sender, EventArgs e)
		{
			bool flag = !this.checkBox16.Checked;
			if (flag)
			{
				this.changes = 1 - this.changes;
				this.c_othersetting = 1 - this.c_othersetting;
			}
			else
			{
				this.changeslocal = 1 - this.changeslocal;
				this.c_othersettinglocal = 1 - this.c_othersettinglocal;
			}
			this.button41_Click(null, null);
			this.exportchanges();
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00016814 File Offset: 0x00014A14
		private void button52_Click(object sender, EventArgs e)
		{
			bool flag = !this.checkBox16.Checked;
			if (flag)
			{
				this.changes = 1 - this.changes;
				this.c_startall = 1 - this.c_startall;
			}
			else
			{
				this.changeslocal = 1 - this.changeslocal;
				this.c_startalllocal = 1 - this.c_startalllocal;
			}
			this.exportchanges();
		}

		// Token: 0x0600015D RID: 349 RVA: 0x0001687C File Offset: 0x00014A7C
		private void button53_Click(object sender, EventArgs e)
		{
			bool flag = !this.checkBox16.Checked;
			if (flag)
			{
				this.changes = 1 - this.changes;
				this.c_resetall = 1 - this.c_resetall;
			}
			else
			{
				this.changeslocal = 1 - this.changeslocal;
				this.c_resetalllocal = 1 - this.c_resetalllocal;
			}
			this.exportchanges();
		}

		// Token: 0x0600015E RID: 350 RVA: 0x000168E4 File Offset: 0x00014AE4
		private void button54_Click(object sender, EventArgs e)
		{
			bool flag = !this.checkBox16.Checked;
			if (flag)
			{
				this.changes = 1 - this.changes;
				this.c_stopall = 1 - this.c_stopall;
			}
			else
			{
				this.changeslocal = 1 - this.changeslocal;
				this.c_stopalllocal = 1 - this.c_stopalllocal;
			}
			this.exportchanges();
		}

		// Token: 0x0600015F RID: 351 RVA: 0x000024AE File Offset: 0x000006AE
		private void numericUpDown10_ValueChanged(object sender, EventArgs e)
		{
			this.maxwait = (int)this.numericUpDown10.Value;
			this.saveothersetting();
		}

		// Token: 0x06000160 RID: 352 RVA: 0x0001694C File Offset: 0x00014B4C
		private void button58_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			bool flag = saveFileDialog.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				string text = "";
				List<string> list = new List<string>();
				foreach (ssh current in this.listssh)
				{
					string item = current.username + "|" + current.password;
					list.Add(item);
				}
				IEnumerable<string> enumerable = list.Distinct<string>();
				using (IEnumerator<string> enumerator2 = enumerable.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						string _item = enumerator2.Current;
						text += _item;
						text += " ";
						text += list.Count((string x) => x == _item).ToString();
						text += "\r\n";
					}
				}
				File.WriteAllText(saveFileDialog.FileName, text);
			}
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00016A8C File Offset: 0x00014C8C
		private void listView4_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			bool flag = !this._sshssh;
			if (flag)
			{
				this.savecheckedssh();
			}
		}

		// Token: 0x06000162 RID: 354 RVA: 0x000021A5 File Offset: 0x000003A5
		private void listView4_ItemCheck(object sender, ItemCheckEventArgs e)
		{
		}

		// Token: 0x06000163 RID: 355 RVA: 0x000024CE File Offset: 0x000006CE
		private void Contact_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.Text = this.DeviceIpControl.Text.Split(new string[]
			{
				"."
			}, StringSplitOptions.None)[3];
		}

		// Token: 0x06000164 RID: 356 RVA: 0x0000229E File Offset: 0x0000049E
		private void checkBox17_CheckedChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x06000165 RID: 357 RVA: 0x0000229E File Offset: 0x0000049E
		private void checkBox18_CheckedChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x06000166 RID: 358 RVA: 0x0000229E File Offset: 0x0000049E
		private void textBox11_TextChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x06000167 RID: 359 RVA: 0x0000229E File Offset: 0x0000049E
		private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x06000168 RID: 360 RVA: 0x0000229E File Offset: 0x0000049E
		private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x06000169 RID: 361 RVA: 0x0000229E File Offset: 0x0000049E
		private void randomSelectRRS_CheckedChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x0600016A RID: 362 RVA: 0x000021A5 File Offset: 0x000003A5
		private void listApp_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600016B RID: 363 RVA: 0x000021A5 File Offset: 0x000003A5
		private void listView8_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600016C RID: 364 RVA: 0x000024F9 File Offset: 0x000006F9
		private void button64_Click(object sender, EventArgs e)
		{
			this.cmd.resping();
		}

		// Token: 0x0600016D RID: 365 RVA: 0x0000229E File Offset: 0x0000049E
		private void checkBox19_CheckedChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x0600016E RID: 366 RVA: 0x00016AB0 File Offset: 0x00014CB0
		public ipData getIPData(string IpAddress)
		{
			ipData result;
			try
			{
				string s = new WebClient().DownloadString("http://pro.ip-api.com/json/" + IpAddress + "?key=iUMpTiybEvs8wJl");
				DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(ipData));
				MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(s));
				result = (ipData)dataContractJsonSerializer.ReadObject(stream);
			}
			catch (Exception var_4_4D)
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600016F RID: 367 RVA: 0x000021A5 File Offset: 0x000003A5
		private void fakeGPS(string IpAddress, double range)
		{
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00016B24 File Offset: 0x00014D24
		private void checkBox20_CheckedChanged(object sender, EventArgs e)
		{
			this.carrierBox.Enabled = (this.checkBox9.Checked && !this.checkBox20.Checked);
			this.comboBox1.Enabled = (this.fakelang.Checked && !this.checkBox20.Checked);
			this.comboBox2.Enabled = (this.fakeregion.Checked && !this.checkBox20.Checked);
			this.ltimezone.Enabled = (this.longtitude.Enabled = (this.latitude.Enabled = !this.checkBox20.Checked));
			bool @checked = this.checkBox20.Checked;
			if (@checked)
			{
				this.checkBox5.Checked = (this.checkBox9.Checked = (this.checkBox13.Checked = (this.fakelang.Checked = (this.fakeregion.Checked = (this.checkBox19.Checked = true)))));
			}
			this.saveothersetting();
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00016C5C File Offset: 0x00014E5C
		private void fakeLocationByIP(string IP)
		{
			ipData _ipdata = this.getIPData(IP);
			bool flag = _ipdata != null;
			if (flag)
			{
				this.ltimezone.Text = _ipdata.timezone;
				countrycodeiOS countrycodeiOS = this.listcountrycodeiOS.FirstOrDefault((countrycodeiOS x) => x.countrycode == _ipdata.countryCode);
				bool flag2 = countrycodeiOS != null;
				if (flag2)
				{
					this.comboBox2.Text = this.listcountrycodeiOS.FirstOrDefault((countrycodeiOS x) => x.countrycode == _ipdata.countryCode).countryname;
				}
				double num = (double)Form1.GetRandomNumber(-10000, 10000) / 100000.0;
				double num2 = (double)Form1.GetRandomNumber(-10000, 10000) / 100000.0;
				this.latitude.Value = (decimal)(_ipdata.lat + num);
				this.longtitude.Value = (decimal)(_ipdata.lon + num2);
			}
		}

		// Token: 0x06000172 RID: 370 RVA: 0x0000229E File Offset: 0x0000049E
		private void latitude_ValueChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x06000173 RID: 371 RVA: 0x0000229E File Offset: 0x0000049E
		private void longtitude_ValueChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00002508 File Offset: 0x00000708
		private void button66_Click(object sender, EventArgs e)
		{
			this.cmd.randomtouchpause();
		}

		// Token: 0x06000175 RID: 373 RVA: 0x00002517 File Offset: 0x00000717
		private void button67_Click(object sender, EventArgs e)
		{
			this.cmd.randomtouchresume();
		}

		// Token: 0x06000176 RID: 374 RVA: 0x0000229E File Offset: 0x0000049E
		private void textBox2_TextChanged_1(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x06000177 RID: 375 RVA: 0x0000229E File Offset: 0x0000049E
		private void sameVip_CheckedChanged(object sender, EventArgs e)
		{
			this.saveothersetting();
		}

		// Token: 0x06000178 RID: 376 RVA: 0x000021A5 File Offset: 0x000003A5
		private void button66_Click_1(object sender, EventArgs e)
		{
		}

		// Token: 0x06000179 RID: 377 RVA: 0x000021A5 File Offset: 0x000003A5
		private void wipecombo_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00016D64 File Offset: 0x00014F64
		private void pausescript_Click(object sender, EventArgs e)
		{
			bool flag = this.scriptstatus == "pause";
			if (flag)
			{
				this.IPThread.Resume();
			}
			this.IPThread.Abort();
			this.button18.BackgroundImage = Resources.Play_icon__1_;
			this.scriptstatus = "stop";
			this.pausescript.Enabled = false;
			this.cmd.randomtouchstop();
		}

		// Token: 0x0400003A RID: 58
		private System.Windows.Forms.Timer settingtime = new System.Windows.Forms.Timer();

		// Token: 0x0400003B RID: 59
		public int changes = 0;

		// Token: 0x0400003C RID: 60
		public int c_listoff = 0;

		// Token: 0x0400003D RID: 61
		public int c_ssh = 0;

		// Token: 0x0400003E RID: 62
		public int c_vip = 0;

		// Token: 0x0400003F RID: 63
		public int c_othersetting = 0;

		// Token: 0x04000040 RID: 64
		public int c_startall = 0;

		// Token: 0x04000041 RID: 65
		public int c_resetall = 0;

		// Token: 0x04000042 RID: 66
		public int c_stopall = 0;

		// Token: 0x04000043 RID: 67
		public int changeslocal = 0;

		// Token: 0x04000044 RID: 68
		public int changesssh = 0;

		// Token: 0x04000045 RID: 69
		public int c_listofflocal = 0;

		// Token: 0x04000046 RID: 70
		public int c_sshlocal = 0;

		// Token: 0x04000047 RID: 71
		public int c_viplocal = 0;

		// Token: 0x04000048 RID: 72
		public int c_othersettinglocal = 0;

		// Token: 0x04000049 RID: 73
		public int c_startalllocal = 0;

		// Token: 0x0400004A RID: 74
		public int c_resetalllocal = 0;

		// Token: 0x0400004B RID: 75
		public int c_stopalllocal = 0;

		// Token: 0x0400004C RID: 76
		public string scriptstatus = "stop";

		// Token: 0x0400004D RID: 77
		public string clientver = "6.5";

		// Token: 0x0400004E RID: 78
		public string curip = "";

		// Token: 0x0400004F RID: 79
		private bool clicked = false;

		// Token: 0x04000050 RID: 80
		private Thread IPThread;

		// Token: 0x04000051 RID: 81
		public List<geo> listGeo = new List<geo>();

		// Token: 0x04000052 RID: 82
		private CheckBoxState state;

		// Token: 0x04000053 RID: 83
		private bool _sshssh = false;

		// Token: 0x04000054 RID: 84
		private string privatekey = "autoleadios";

		// Token: 0x04000055 RID: 85
		public string documentfolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\";

		// Token: 0x04000056 RID: 86
		private string serverurl = "http://nam72.lake.gq/random1/deviceinfo/";

		// Token: 0x04000057 RID: 87
		private string sshserverurl = "http://none.com";

		// Token: 0x04000058 RID: 88
		private Socket _clientSocket;

		// Token: 0x04000059 RID: 89
		private List<string> _listcountry = new List<string>();

		// Token: 0x0400005A RID: 90
		private List<offerItem> offerListItem = new List<offerItem>();

		// Token: 0x0400005B RID: 91
		private bool isconnected = false;

		// Token: 0x0400005C RID: 92
		private command cmd = new command();

		// Token: 0x0400005D RID: 93
		private byte[] _buffer;

		// Token: 0x0400005E RID: 94
		private string dataleft;

		// Token: 0x0400005F RID: 95
		private deviceInfo DeviceInfo = new deviceInfo();

		// Token: 0x04000060 RID: 96
		private List<appDetail> AppList = new List<appDetail>();

		// Token: 0x04000061 RID: 97
		private List<appDetail> AppList1 = new List<appDetail>();

		// Token: 0x04000062 RID: 98
		private OfferOption optionform = new OfferOption();

		// Token: 0x04000063 RID: 99
		private DownloadProgress downloadform = new DownloadProgress();

		// Token: 0x04000064 RID: 100
		public commandResult cmdResult = new commandResult();

		// Token: 0x04000065 RID: 101
		private int maxwait = 120;

		// Token: 0x04000066 RID: 102
		private int maxwait1 = 60;

		// Token: 0x04000067 RID: 103
		private List<Carrier> carrierList = new List<Carrier>();

		// Token: 0x04000068 RID: 104
		private List<countrycodeiOS> listcountrycodeiOS = new List<countrycodeiOS>();

		// Token: 0x04000069 RID: 105
		private List<languagecode> listlanguagecode = new List<languagecode>();

		// Token: 0x0400006A RID: 106
		private List<ssh> listssh = new List<ssh>();

		// Token: 0x0400006B RID: 107
		private List<backup> listbackup = new List<backup>();

		// Token: 0x0400006C RID: 108
		private string oriadd = "";

		// Token: 0x0400006D RID: 109
		private bool sort = true;

		// Token: 0x0400006E RID: 110
		private bool isGetSubFolder;

		// Token: 0x0400006F RID: 111
		private int oriport = 0;

		// Token: 0x04000070 RID: 112
		private List<string> listcommand = new List<string>();

		// Token: 0x04000071 RID: 113
		private List<vipaccount> listvipacc = new List<vipaccount>();

		// Token: 0x04000072 RID: 114
		private List<countrycode> listcountrycode = new List<countrycode>();

		// Token: 0x04000073 RID: 115
		private List<Script> listscript = new List<Script>();

		// Token: 0x04000074 RID: 116
		private Process bitproc = new Process();

		// Token: 0x04000075 RID: 117
		private Thread oThread;

		// Token: 0x04000076 RID: 118
		private string usCulture = "en-US";

		// Token: 0x04000077 RID: 119
		private IFormatProvider usformat;

		// Token: 0x04000078 RID: 120
		private int runningstt = 0;

		// Token: 0x04000079 RID: 121
		private ListViewColumnSorter lvwColumnSorter;

		// Token: 0x0400007A RID: 122
		private Thread bkThread;

		// Token: 0x0400007B RID: 123
		private Thread vipThread;

		// Token: 0x0400007C RID: 124
		private int iOSversion;

		// Token: 0x0400007D RID: 125
		private int recordstep = 0;

		// Token: 0x0400007E RID: 126
		private int prevx = 0;

		// Token: 0x0400007F RID: 127
		private int first = 0;

		// Token: 0x04000080 RID: 128
		private int runtime = 0;

		// Token: 0x04000081 RID: 129
		private int backuptime = 0;

		// Token: 0x04000082 RID: 130
		private int prevy = 0;

		// Token: 0x04000083 RID: 131
		private bool isGetProtectData;

		// Token: 0x04000084 RID: 132
		private ssh _getssh;

		// Token: 0x04000085 RID: 133
		private vipaccount vipacc;

		// Token: 0x04000086 RID: 134
		private string currentvipip;

		// Token: 0x04000087 RID: 135
		private List<string> listfirstname = new List<string>();

		// Token: 0x04000088 RID: 136
		private List<string> listlastname = new List<string>();

		// Token: 0x04000089 RID: 137
		private List<string> listemaildomain = new List<string>();

		// Token: 0x0400008A RID: 138
		private List<string> listtimezone = new List<string>();

		// Token: 0x0400008B RID: 139
		private DateTime clicklast;

		// Token: 0x0400008C RID: 140
		private DateTime recprev;

		// Token: 0x0400008D RID: 141
		private ReadOnlyCollection<TimeZoneInfo> tz = TimeZoneInfo.GetSystemTimeZones();

		// Token: 0x0400008E RID: 142
		private static readonly Random getrandom = new Random();

		// Token: 0x0400008F RID: 143
		private static readonly object syncLock = new object();

		// Token: 0x04000090 RID: 144
		private List<NumericUpDown> listRRSmin = new List<NumericUpDown>();

		// Token: 0x04000091 RID: 145
		private List<NumericUpDown> listRRSmax = new List<NumericUpDown>();

		// Token: 0x02000019 RID: 25
		[CompilerGenerated]
		[Serializable]
		private sealed class <>c
		{
			// Token: 0x06000224 RID: 548 RVA: 0x00002AD8 File Offset: 0x00000CD8
			internal bool <setInfo>b__113_1(string x)
			{
				return !x.Contains("changes.dat");
			}

			// Token: 0x06000225 RID: 549 RVA: 0x00002AD8 File Offset: 0x00000CD8
			internal bool <setInfo>b__113_2(string x)
			{
				return !x.Contains("changes.dat");
			}

			// Token: 0x06000226 RID: 550 RVA: 0x00002AE8 File Offset: 0x00000CE8
			internal bool <setInfo>b__113_4(ssh x)
			{
				return x.live == "uncheck";
			}

			// Token: 0x06000227 RID: 551 RVA: 0x00002AFA File Offset: 0x00000CFA
			internal bool <setInfo>b__113_5(ssh x)
			{
				return x.used;
			}

			// Token: 0x06000228 RID: 552 RVA: 0x00002B02 File Offset: 0x00000D02
			internal bool <setInfo>b__113_6(ssh x)
			{
				return x.live == "alive";
			}

			// Token: 0x06000229 RID: 553 RVA: 0x00002B14 File Offset: 0x00000D14
			internal bool <setInfo>b__113_7(ssh x)
			{
				return x.live == "dead";
			}

			// Token: 0x0600022A RID: 554 RVA: 0x00002B26 File Offset: 0x00000D26
			internal string <getListApp>b__116_0(appDetail x)
			{
				return x.appName;
			}

			// Token: 0x0600022B RID: 555 RVA: 0x00002B26 File Offset: 0x00000D26
			internal string <getListApp>b__116_1(appDetail x)
			{
				return x.appName;
			}

			// Token: 0x0600022C RID: 556 RVA: 0x00002B2E File Offset: 0x00000D2E
			internal bool <autoLeadThread>b__121_0(offerItem x)
			{
				return x.offerEnable;
			}

			// Token: 0x0600022D RID: 557 RVA: 0x00002AE8 File Offset: 0x00000CE8
			internal bool <autoLeadThread>b__121_11(ssh x)
			{
				return x.live == "uncheck";
			}

			// Token: 0x0600022E RID: 558 RVA: 0x00002AFA File Offset: 0x00000CFA
			internal bool <autoLeadThread>b__121_12(ssh x)
			{
				return x.used;
			}

			// Token: 0x0600022F RID: 559 RVA: 0x00002B02 File Offset: 0x00000D02
			internal bool <autoLeadThread>b__121_13(ssh x)
			{
				return x.live == "alive";
			}

			// Token: 0x06000230 RID: 560 RVA: 0x00002B14 File Offset: 0x00000D14
			internal bool <autoLeadThread>b__121_14(ssh x)
			{
				return x.live == "dead";
			}

			// Token: 0x06000231 RID: 561 RVA: 0x00002AE8 File Offset: 0x00000CE8
			internal bool <autoLeadThread>b__121_17(ssh x)
			{
				return x.live == "uncheck";
			}

			// Token: 0x06000232 RID: 562 RVA: 0x00002AFA File Offset: 0x00000CFA
			internal bool <autoLeadThread>b__121_18(ssh x)
			{
				return x.used;
			}

			// Token: 0x06000233 RID: 563 RVA: 0x00002B02 File Offset: 0x00000D02
			internal bool <autoLeadThread>b__121_19(ssh x)
			{
				return x.live == "alive";
			}

			// Token: 0x06000234 RID: 564 RVA: 0x00002B14 File Offset: 0x00000D14
			internal bool <autoLeadThread>b__121_20(ssh x)
			{
				return x.live == "dead";
			}

			// Token: 0x06000235 RID: 565 RVA: 0x00002B36 File Offset: 0x00000D36
			internal bool <autoLeadThread>b__121_23(vipaccount x)
			{
				return !x.limited;
			}

			// Token: 0x06000236 RID: 566 RVA: 0x000021A5 File Offset: 0x000003A5
			internal void <autoLeadThread>b__121_31()
			{
			}

			// Token: 0x06000237 RID: 567 RVA: 0x00002AE8 File Offset: 0x00000CE8
			internal bool <autoLeadThread>b__121_59(ssh x)
			{
				return x.live == "uncheck";
			}

			// Token: 0x06000238 RID: 568 RVA: 0x00002AFA File Offset: 0x00000CFA
			internal bool <autoLeadThread>b__121_60(ssh x)
			{
				return x.used;
			}

			// Token: 0x06000239 RID: 569 RVA: 0x00002B02 File Offset: 0x00000D02
			internal bool <autoLeadThread>b__121_61(ssh x)
			{
				return x.live == "alive";
			}

			// Token: 0x0600023A RID: 570 RVA: 0x00002B14 File Offset: 0x00000D14
			internal bool <autoLeadThread>b__121_62(ssh x)
			{
				return x.live == "dead";
			}

			// Token: 0x0600023B RID: 571 RVA: 0x00002AE8 File Offset: 0x00000CE8
			internal bool <autoLeadThread>b__121_65(ssh x)
			{
				return x.live == "uncheck";
			}

			// Token: 0x0600023C RID: 572 RVA: 0x00002AFA File Offset: 0x00000CFA
			internal bool <autoLeadThread>b__121_66(ssh x)
			{
				return x.used;
			}

			// Token: 0x0600023D RID: 573 RVA: 0x00002B02 File Offset: 0x00000D02
			internal bool <autoLeadThread>b__121_67(ssh x)
			{
				return x.live == "alive";
			}

			// Token: 0x0600023E RID: 574 RVA: 0x00002B14 File Offset: 0x00000D14
			internal bool <autoLeadThread>b__121_68(ssh x)
			{
				return x.live == "dead";
			}

			// Token: 0x0600023F RID: 575 RVA: 0x00002B36 File Offset: 0x00000D36
			internal bool <autoLeadThread>b__121_73(vipaccount x)
			{
				return !x.limited;
			}

			// Token: 0x06000240 RID: 576 RVA: 0x000021A5 File Offset: 0x000003A5
			internal void <autoLeadThread>b__121_85()
			{
			}

			// Token: 0x06000241 RID: 577 RVA: 0x00002B41 File Offset: 0x00000D41
			internal string <importssh>b__132_0(ssh x)
			{
				return x.country;
			}

			// Token: 0x06000242 RID: 578 RVA: 0x00002B49 File Offset: 0x00000D49
			internal string <importssh>b__132_1(string x)
			{
				return x;
			}

			// Token: 0x06000243 RID: 579 RVA: 0x00002AE8 File Offset: 0x00000CE8
			internal bool <importfromfile_Click>b__133_1(ssh x)
			{
				return x.live == "uncheck";
			}

			// Token: 0x06000244 RID: 580 RVA: 0x00002AFA File Offset: 0x00000CFA
			internal bool <importfromfile_Click>b__133_2(ssh x)
			{
				return x.used;
			}

			// Token: 0x06000245 RID: 581 RVA: 0x00002B02 File Offset: 0x00000D02
			internal bool <importfromfile_Click>b__133_3(ssh x)
			{
				return x.live == "alive";
			}

			// Token: 0x06000246 RID: 582 RVA: 0x00002B14 File Offset: 0x00000D14
			internal bool <importfromfile_Click>b__133_4(ssh x)
			{
				return x.live == "dead";
			}

			// Token: 0x06000247 RID: 583 RVA: 0x00002AE8 File Offset: 0x00000CE8
			internal bool <button14_Click>b__134_1(ssh x)
			{
				return x.live == "uncheck";
			}

			// Token: 0x06000248 RID: 584 RVA: 0x00002AFA File Offset: 0x00000CFA
			internal bool <button14_Click>b__134_2(ssh x)
			{
				return x.used;
			}

			// Token: 0x06000249 RID: 585 RVA: 0x00002B02 File Offset: 0x00000D02
			internal bool <button14_Click>b__134_3(ssh x)
			{
				return x.live == "alive";
			}

			// Token: 0x0600024A RID: 586 RVA: 0x00002B14 File Offset: 0x00000D14
			internal bool <button14_Click>b__134_4(ssh x)
			{
				return x.live == "dead";
			}

			// Token: 0x0600024B RID: 587 RVA: 0x00002B4C File Offset: 0x00000D4C
			internal bool <button24_Click>b__135_0(ssh x)
			{
				return x.live == "dead" || x.used;
			}

			// Token: 0x0600024C RID: 588 RVA: 0x00002B69 File Offset: 0x00000D69
			internal string <button24_Click>b__135_1(ssh x)
			{
				return x.IP;
			}

			// Token: 0x0600024D RID: 589 RVA: 0x00002AE8 File Offset: 0x00000CE8
			internal bool <button24_Click>b__135_3(ssh x)
			{
				return x.live == "uncheck";
			}

			// Token: 0x0600024E RID: 590 RVA: 0x00002AFA File Offset: 0x00000CFA
			internal bool <button24_Click>b__135_4(ssh x)
			{
				return x.used;
			}

			// Token: 0x0600024F RID: 591 RVA: 0x00002B02 File Offset: 0x00000D02
			internal bool <button24_Click>b__135_5(ssh x)
			{
				return x.live == "alive";
			}

			// Token: 0x06000250 RID: 592 RVA: 0x00002B14 File Offset: 0x00000D14
			internal bool <button24_Click>b__135_6(ssh x)
			{
				return x.live == "dead";
			}

			// Token: 0x06000251 RID: 593 RVA: 0x00002AE8 File Offset: 0x00000CE8
			internal bool <button8_Click>b__136_1(ssh x)
			{
				return x.live == "uncheck";
			}

			// Token: 0x06000252 RID: 594 RVA: 0x00002AFA File Offset: 0x00000CFA
			internal bool <button8_Click>b__136_2(ssh x)
			{
				return x.used;
			}

			// Token: 0x06000253 RID: 595 RVA: 0x00002B02 File Offset: 0x00000D02
			internal bool <button8_Click>b__136_3(ssh x)
			{
				return x.live == "alive";
			}

			// Token: 0x06000254 RID: 596 RVA: 0x00002B14 File Offset: 0x00000D14
			internal bool <button8_Click>b__136_4(ssh x)
			{
				return x.live == "dead";
			}

			// Token: 0x06000255 RID: 597 RVA: 0x00002AE8 File Offset: 0x00000CE8
			internal bool <threadchecklive>b__139_3(ssh x)
			{
				return x.live == "uncheck";
			}

			// Token: 0x06000256 RID: 598 RVA: 0x00002AFA File Offset: 0x00000CFA
			internal bool <threadchecklive>b__139_4(ssh x)
			{
				return x.used;
			}

			// Token: 0x06000257 RID: 599 RVA: 0x00002B02 File Offset: 0x00000D02
			internal bool <threadchecklive>b__139_5(ssh x)
			{
				return x.live == "alive";
			}

			// Token: 0x06000258 RID: 600 RVA: 0x00002B14 File Offset: 0x00000D14
			internal bool <threadchecklive>b__139_6(ssh x)
			{
				return x.live == "dead";
			}

			// Token: 0x06000259 RID: 601 RVA: 0x00002AE8 File Offset: 0x00000CE8
			internal bool <threadchecklive>b__139_9(ssh x)
			{
				return x.live == "uncheck";
			}

			// Token: 0x0600025A RID: 602 RVA: 0x00002AFA File Offset: 0x00000CFA
			internal bool <threadchecklive>b__139_10(ssh x)
			{
				return x.used;
			}

			// Token: 0x0600025B RID: 603 RVA: 0x00002B02 File Offset: 0x00000D02
			internal bool <threadchecklive>b__139_11(ssh x)
			{
				return x.live == "alive";
			}

			// Token: 0x0600025C RID: 604 RVA: 0x00002B14 File Offset: 0x00000D14
			internal bool <threadchecklive>b__139_12(ssh x)
			{
				return x.live == "dead";
			}

			// Token: 0x0600025D RID: 605 RVA: 0x00002B41 File Offset: 0x00000D41
			internal string <proxytool_SelectedIndexChanged>b__146_0(ssh x)
			{
				return x.country;
			}

			// Token: 0x0600025E RID: 606 RVA: 0x00002AE8 File Offset: 0x00000CE8
			internal bool <autoRRS>b__156_14(ssh x)
			{
				return x.live == "uncheck";
			}

			// Token: 0x0600025F RID: 607 RVA: 0x00002AFA File Offset: 0x00000CFA
			internal bool <autoRRS>b__156_15(ssh x)
			{
				return x.used;
			}

			// Token: 0x06000260 RID: 608 RVA: 0x00002B02 File Offset: 0x00000D02
			internal bool <autoRRS>b__156_16(ssh x)
			{
				return x.live == "alive";
			}

			// Token: 0x06000261 RID: 609 RVA: 0x00002B14 File Offset: 0x00000D14
			internal bool <autoRRS>b__156_17(ssh x)
			{
				return x.live == "dead";
			}

			// Token: 0x06000262 RID: 610 RVA: 0x00002AE8 File Offset: 0x00000CE8
			internal bool <autoRRS>b__156_20(ssh x)
			{
				return x.live == "uncheck";
			}

			// Token: 0x06000263 RID: 611 RVA: 0x00002AFA File Offset: 0x00000CFA
			internal bool <autoRRS>b__156_21(ssh x)
			{
				return x.used;
			}

			// Token: 0x06000264 RID: 612 RVA: 0x00002B02 File Offset: 0x00000D02
			internal bool <autoRRS>b__156_22(ssh x)
			{
				return x.live == "alive";
			}

			// Token: 0x06000265 RID: 613 RVA: 0x00002B14 File Offset: 0x00000D14
			internal bool <autoRRS>b__156_23(ssh x)
			{
				return x.live == "dead";
			}

			// Token: 0x06000266 RID: 614 RVA: 0x00002B36 File Offset: 0x00000D36
			internal bool <autoRRS>b__156_26(vipaccount x)
			{
				return !x.limited;
			}

			// Token: 0x06000267 RID: 615 RVA: 0x000021A5 File Offset: 0x000003A5
			internal void <autoRRS>b__156_34()
			{
			}

			// Token: 0x06000268 RID: 616 RVA: 0x00002AE8 File Offset: 0x00000CE8
			internal bool <threadchangeIP>b__170_9(ssh x)
			{
				return x.live == "uncheck";
			}

			// Token: 0x06000269 RID: 617 RVA: 0x00002AFA File Offset: 0x00000CFA
			internal bool <threadchangeIP>b__170_10(ssh x)
			{
				return x.used;
			}

			// Token: 0x0600026A RID: 618 RVA: 0x00002B02 File Offset: 0x00000D02
			internal bool <threadchangeIP>b__170_11(ssh x)
			{
				return x.live == "alive";
			}

			// Token: 0x0600026B RID: 619 RVA: 0x00002B14 File Offset: 0x00000D14
			internal bool <threadchangeIP>b__170_12(ssh x)
			{
				return x.live == "dead";
			}

			// Token: 0x0600026C RID: 620 RVA: 0x00002AE8 File Offset: 0x00000CE8
			internal bool <threadchangeIP>b__170_15(ssh x)
			{
				return x.live == "uncheck";
			}

			// Token: 0x0600026D RID: 621 RVA: 0x00002AFA File Offset: 0x00000CFA
			internal bool <threadchangeIP>b__170_16(ssh x)
			{
				return x.used;
			}

			// Token: 0x0600026E RID: 622 RVA: 0x00002B02 File Offset: 0x00000D02
			internal bool <threadchangeIP>b__170_17(ssh x)
			{
				return x.live == "alive";
			}

			// Token: 0x0600026F RID: 623 RVA: 0x00002B14 File Offset: 0x00000D14
			internal bool <threadchangeIP>b__170_18(ssh x)
			{
				return x.live == "dead";
			}

			// Token: 0x06000270 RID: 624 RVA: 0x00002B36 File Offset: 0x00000D36
			internal bool <threadchangeIP>b__170_21(vipaccount x)
			{
				return !x.limited;
			}

			// Token: 0x06000271 RID: 625 RVA: 0x000021A5 File Offset: 0x000003A5
			internal void <threadchangeIP>b__170_31()
			{
			}

			// Token: 0x06000272 RID: 626 RVA: 0x00002AE8 File Offset: 0x00000CE8
			internal bool <loadssh>b__197_1(ssh x)
			{
				return x.live == "uncheck";
			}

			// Token: 0x06000273 RID: 627 RVA: 0x00002AFA File Offset: 0x00000CFA
			internal bool <loadssh>b__197_2(ssh x)
			{
				return x.used;
			}

			// Token: 0x06000274 RID: 628 RVA: 0x00002B02 File Offset: 0x00000D02
			internal bool <loadssh>b__197_3(ssh x)
			{
				return x.live == "alive";
			}

			// Token: 0x06000275 RID: 629 RVA: 0x00002B14 File Offset: 0x00000D14
			internal bool <loadssh>b__197_4(ssh x)
			{
				return x.live == "dead";
			}

			// Token: 0x06000276 RID: 630 RVA: 0x00002B41 File Offset: 0x00000D41
			internal string <loadssh>b__197_5(ssh x)
			{
				return x.country;
			}

			// Token: 0x06000277 RID: 631 RVA: 0x00002B49 File Offset: 0x00000D49
			internal string <loadssh>b__197_6(string x)
			{
				return x;
			}

			// Token: 0x06000278 RID: 632 RVA: 0x00023514 File Offset: 0x00021714
			internal string <listView4_ColumnClick>b__211_0(backup x)
			{
				return x.timecreate.ToString("MM/dd/yyyy HH:mm:ss");
			}

			// Token: 0x06000279 RID: 633 RVA: 0x00023534 File Offset: 0x00021734
			internal string <listView4_ColumnClick>b__211_1(backup x)
			{
				return x.timemod.ToString("MM/dd/yyyy HH:mm:ss");
			}

			// Token: 0x0600027A RID: 634 RVA: 0x00023554 File Offset: 0x00021754
			internal string <listView4_ColumnClick>b__211_2(backup x)
			{
				return x.runtime.ToString();
			}

			// Token: 0x0600027B RID: 635 RVA: 0x00002B71 File Offset: 0x00000D71
			internal string <listView4_ColumnClick>b__211_3(backup x)
			{
				return string.Join(";", x.appList.ToList<string>()).ToString();
			}

			// Token: 0x0600027C RID: 636 RVA: 0x00002B8D File Offset: 0x00000D8D
			internal string <listView4_ColumnClick>b__211_4(backup x)
			{
				return x.comment.ToString();
			}

			// Token: 0x0600027D RID: 637 RVA: 0x00002B9A File Offset: 0x00000D9A
			internal string <listView4_ColumnClick>b__211_5(backup x)
			{
				return x.country.ToString();
			}

			// Token: 0x0600027E RID: 638 RVA: 0x00002BA7 File Offset: 0x00000DA7
			internal string <listView4_ColumnClick>b__211_6(backup x)
			{
				return x.filename.ToString();
			}

			// Token: 0x0600027F RID: 639 RVA: 0x00023514 File Offset: 0x00021714
			internal string <listView4_ColumnClick>b__211_7(backup x)
			{
				return x.timecreate.ToString("MM/dd/yyyy HH:mm:ss");
			}

			// Token: 0x06000280 RID: 640 RVA: 0x00023534 File Offset: 0x00021734
			internal string <listView4_ColumnClick>b__211_8(backup x)
			{
				return x.timemod.ToString("MM/dd/yyyy HH:mm:ss");
			}

			// Token: 0x06000281 RID: 641 RVA: 0x00023554 File Offset: 0x00021754
			internal string <listView4_ColumnClick>b__211_9(backup x)
			{
				return x.runtime.ToString();
			}

			// Token: 0x06000282 RID: 642 RVA: 0x00002B71 File Offset: 0x00000D71
			internal string <listView4_ColumnClick>b__211_10(backup x)
			{
				return string.Join(";", x.appList.ToList<string>()).ToString();
			}

			// Token: 0x06000283 RID: 643 RVA: 0x00002B8D File Offset: 0x00000D8D
			internal string <listView4_ColumnClick>b__211_11(backup x)
			{
				return x.comment.ToString();
			}

			// Token: 0x06000284 RID: 644 RVA: 0x00002B9A File Offset: 0x00000D9A
			internal string <listView4_ColumnClick>b__211_12(backup x)
			{
				return x.country.ToString();
			}

			// Token: 0x06000285 RID: 645 RVA: 0x00002BA7 File Offset: 0x00000DA7
			internal string <listView4_ColumnClick>b__211_13(backup x)
			{
				return x.filename.ToString();
			}

			// Token: 0x04000196 RID: 406
			public static readonly Form1.<>c <>9 = new Form1.<>c();

			// Token: 0x04000197 RID: 407
			public static Func<string, bool> <>9__113_1;

			// Token: 0x04000198 RID: 408
			public static Func<string, bool> <>9__113_2;

			// Token: 0x04000199 RID: 409
			public static Func<ssh, bool> <>9__113_4;

			// Token: 0x0400019A RID: 410
			public static Func<ssh, bool> <>9__113_5;

			// Token: 0x0400019B RID: 411
			public static Func<ssh, bool> <>9__113_6;

			// Token: 0x0400019C RID: 412
			public static Func<ssh, bool> <>9__113_7;

			// Token: 0x0400019D RID: 413
			public static Func<appDetail, string> <>9__116_0;

			// Token: 0x0400019E RID: 414
			public static Func<appDetail, string> <>9__116_1;

			// Token: 0x0400019F RID: 415
			public static Func<offerItem, bool> <>9__121_0;

			// Token: 0x040001A0 RID: 416
			public static Func<ssh, bool> <>9__121_11;

			// Token: 0x040001A1 RID: 417
			public static Func<ssh, bool> <>9__121_12;

			// Token: 0x040001A2 RID: 418
			public static Func<ssh, bool> <>9__121_13;

			// Token: 0x040001A3 RID: 419
			public static Func<ssh, bool> <>9__121_14;

			// Token: 0x040001A4 RID: 420
			public static Func<ssh, bool> <>9__121_17;

			// Token: 0x040001A5 RID: 421
			public static Func<ssh, bool> <>9__121_18;

			// Token: 0x040001A6 RID: 422
			public static Func<ssh, bool> <>9__121_19;

			// Token: 0x040001A7 RID: 423
			public static Func<ssh, bool> <>9__121_20;

			// Token: 0x040001A8 RID: 424
			public static Func<vipaccount, bool> <>9__121_23;

			// Token: 0x040001A9 RID: 425
			public static MethodInvoker <>9__121_31;

			// Token: 0x040001AA RID: 426
			public static Func<ssh, bool> <>9__121_59;

			// Token: 0x040001AB RID: 427
			public static Func<ssh, bool> <>9__121_60;

			// Token: 0x040001AC RID: 428
			public static Func<ssh, bool> <>9__121_61;

			// Token: 0x040001AD RID: 429
			public static Func<ssh, bool> <>9__121_62;

			// Token: 0x040001AE RID: 430
			public static Func<ssh, bool> <>9__121_65;

			// Token: 0x040001AF RID: 431
			public static Func<ssh, bool> <>9__121_66;

			// Token: 0x040001B0 RID: 432
			public static Func<ssh, bool> <>9__121_67;

			// Token: 0x040001B1 RID: 433
			public static Func<ssh, bool> <>9__121_68;

			// Token: 0x040001B2 RID: 434
			public static Func<vipaccount, bool> <>9__121_73;

			// Token: 0x040001B3 RID: 435
			public static MethodInvoker <>9__121_85;

			// Token: 0x040001B4 RID: 436
			public static Func<ssh, string> <>9__132_0;

			// Token: 0x040001B5 RID: 437
			public static Func<string, string> <>9__132_1;

			// Token: 0x040001B6 RID: 438
			public static Func<ssh, bool> <>9__133_1;

			// Token: 0x040001B7 RID: 439
			public static Func<ssh, bool> <>9__133_2;

			// Token: 0x040001B8 RID: 440
			public static Func<ssh, bool> <>9__133_3;

			// Token: 0x040001B9 RID: 441
			public static Func<ssh, bool> <>9__133_4;

			// Token: 0x040001BA RID: 442
			public static Func<ssh, bool> <>9__134_1;

			// Token: 0x040001BB RID: 443
			public static Func<ssh, bool> <>9__134_2;

			// Token: 0x040001BC RID: 444
			public static Func<ssh, bool> <>9__134_3;

			// Token: 0x040001BD RID: 445
			public static Func<ssh, bool> <>9__134_4;

			// Token: 0x040001BE RID: 446
			public static Predicate<ssh> <>9__135_0;

			// Token: 0x040001BF RID: 447
			public static Func<ssh, string> <>9__135_1;

			// Token: 0x040001C0 RID: 448
			public static Func<ssh, bool> <>9__135_3;

			// Token: 0x040001C1 RID: 449
			public static Func<ssh, bool> <>9__135_4;

			// Token: 0x040001C2 RID: 450
			public static Func<ssh, bool> <>9__135_5;

			// Token: 0x040001C3 RID: 451
			public static Func<ssh, bool> <>9__135_6;

			// Token: 0x040001C4 RID: 452
			public static Func<ssh, bool> <>9__136_1;

			// Token: 0x040001C5 RID: 453
			public static Func<ssh, bool> <>9__136_2;

			// Token: 0x040001C6 RID: 454
			public static Func<ssh, bool> <>9__136_3;

			// Token: 0x040001C7 RID: 455
			public static Func<ssh, bool> <>9__136_4;

			// Token: 0x040001C8 RID: 456
			public static Func<ssh, bool> <>9__139_3;

			// Token: 0x040001C9 RID: 457
			public static Func<ssh, bool> <>9__139_4;

			// Token: 0x040001CA RID: 458
			public static Func<ssh, bool> <>9__139_5;

			// Token: 0x040001CB RID: 459
			public static Func<ssh, bool> <>9__139_6;

			// Token: 0x040001CC RID: 460
			public static Func<ssh, bool> <>9__139_9;

			// Token: 0x040001CD RID: 461
			public static Func<ssh, bool> <>9__139_10;

			// Token: 0x040001CE RID: 462
			public static Func<ssh, bool> <>9__139_11;

			// Token: 0x040001CF RID: 463
			public static Func<ssh, bool> <>9__139_12;

			// Token: 0x040001D0 RID: 464
			public static Func<ssh, string> <>9__146_0;

			// Token: 0x040001D1 RID: 465
			public static Func<ssh, bool> <>9__156_14;

			// Token: 0x040001D2 RID: 466
			public static Func<ssh, bool> <>9__156_15;

			// Token: 0x040001D3 RID: 467
			public static Func<ssh, bool> <>9__156_16;

			// Token: 0x040001D4 RID: 468
			public static Func<ssh, bool> <>9__156_17;

			// Token: 0x040001D5 RID: 469
			public static Func<ssh, bool> <>9__156_20;

			// Token: 0x040001D6 RID: 470
			public static Func<ssh, bool> <>9__156_21;

			// Token: 0x040001D7 RID: 471
			public static Func<ssh, bool> <>9__156_22;

			// Token: 0x040001D8 RID: 472
			public static Func<ssh, bool> <>9__156_23;

			// Token: 0x040001D9 RID: 473
			public static Func<vipaccount, bool> <>9__156_26;

			// Token: 0x040001DA RID: 474
			public static MethodInvoker <>9__156_34;

			// Token: 0x040001DB RID: 475
			public static Func<ssh, bool> <>9__170_9;

			// Token: 0x040001DC RID: 476
			public static Func<ssh, bool> <>9__170_10;

			// Token: 0x040001DD RID: 477
			public static Func<ssh, bool> <>9__170_11;

			// Token: 0x040001DE RID: 478
			public static Func<ssh, bool> <>9__170_12;

			// Token: 0x040001DF RID: 479
			public static Func<ssh, bool> <>9__170_15;

			// Token: 0x040001E0 RID: 480
			public static Func<ssh, bool> <>9__170_16;

			// Token: 0x040001E1 RID: 481
			public static Func<ssh, bool> <>9__170_17;

			// Token: 0x040001E2 RID: 482
			public static Func<ssh, bool> <>9__170_18;

			// Token: 0x040001E3 RID: 483
			public static Func<vipaccount, bool> <>9__170_21;

			// Token: 0x040001E4 RID: 484
			public static MethodInvoker <>9__170_31;

			// Token: 0x040001E5 RID: 485
			public static Func<ssh, bool> <>9__197_1;

			// Token: 0x040001E6 RID: 486
			public static Func<ssh, bool> <>9__197_2;

			// Token: 0x040001E7 RID: 487
			public static Func<ssh, bool> <>9__197_3;

			// Token: 0x040001E8 RID: 488
			public static Func<ssh, bool> <>9__197_4;

			// Token: 0x040001E9 RID: 489
			public static Func<ssh, string> <>9__197_5;

			// Token: 0x040001EA RID: 490
			public static Func<string, string> <>9__197_6;

			// Token: 0x040001EB RID: 491
			public static Func<backup, string> <>9__211_0;

			// Token: 0x040001EC RID: 492
			public static Func<backup, string> <>9__211_1;

			// Token: 0x040001ED RID: 493
			public static Func<backup, string> <>9__211_2;

			// Token: 0x040001EE RID: 494
			public static Func<backup, string> <>9__211_3;

			// Token: 0x040001EF RID: 495
			public static Func<backup, string> <>9__211_4;

			// Token: 0x040001F0 RID: 496
			public static Func<backup, string> <>9__211_5;

			// Token: 0x040001F1 RID: 497
			public static Func<backup, string> <>9__211_6;

			// Token: 0x040001F2 RID: 498
			public static Func<backup, string> <>9__211_7;

			// Token: 0x040001F3 RID: 499
			public static Func<backup, string> <>9__211_8;

			// Token: 0x040001F4 RID: 500
			public static Func<backup, string> <>9__211_9;

			// Token: 0x040001F5 RID: 501
			public static Func<backup, string> <>9__211_10;

			// Token: 0x040001F6 RID: 502
			public static Func<backup, string> <>9__211_11;

			// Token: 0x040001F7 RID: 503
			public static Func<backup, string> <>9__211_12;

			// Token: 0x040001F8 RID: 504
			public static Func<backup, string> <>9__211_13;
		}

		// Token: 0x0200001C RID: 28
		[CompilerGenerated]
		private static class <>o__121
		{
			// Token: 0x040001FC RID: 508
			public static CallSite<Action<CallSite, object, int>> <>p__0;

			// Token: 0x040001FD RID: 509
			public static CallSite<Action<CallSite, object>> <>p__1;

			// Token: 0x040001FE RID: 510
			public static CallSite<Func<CallSite, object, string, string, int, object>> <>p__2;

			// Token: 0x040001FF RID: 511
			public static CallSite<Func<CallSite, object, object>> <>p__3;

			// Token: 0x04000200 RID: 512
			public static CallSite<Func<CallSite, object, bool>> <>p__4;

			// Token: 0x04000201 RID: 513
			public static CallSite<Func<CallSite, object, byte, object>> <>p__5;

			// Token: 0x04000202 RID: 514
			public static CallSite<Func<CallSite, object, bool>> <>p__6;

			// Token: 0x04000203 RID: 515
			public static CallSite<Func<CallSite, object, int, object>> <>p__7;

			// Token: 0x04000204 RID: 516
			public static CallSite<Func<CallSite, object, string>> <>p__8;

			// Token: 0x04000205 RID: 517
			public static CallSite<Action<CallSite, object>> <>p__9;

			// Token: 0x04000206 RID: 518
			public static CallSite<Action<CallSite, object, int>> <>p__10;

			// Token: 0x04000207 RID: 519
			public static CallSite<Action<CallSite, object, int>> <>p__11;

			// Token: 0x04000208 RID: 520
			public static CallSite<Action<CallSite, object>> <>p__12;

			// Token: 0x04000209 RID: 521
			public static CallSite<Func<CallSite, object, string, string, int, object>> <>p__13;

			// Token: 0x0400020A RID: 522
			public static CallSite<Func<CallSite, object, object>> <>p__14;

			// Token: 0x0400020B RID: 523
			public static CallSite<Func<CallSite, object, bool>> <>p__15;

			// Token: 0x0400020C RID: 524
			public static CallSite<Func<CallSite, object, byte, object>> <>p__16;

			// Token: 0x0400020D RID: 525
			public static CallSite<Func<CallSite, object, bool>> <>p__17;

			// Token: 0x0400020E RID: 526
			public static CallSite<Func<CallSite, object, int, object>> <>p__18;

			// Token: 0x0400020F RID: 527
			public static CallSite<Func<CallSite, object, string>> <>p__19;

			// Token: 0x04000210 RID: 528
			public static CallSite<Action<CallSite, object>> <>p__20;

			// Token: 0x04000211 RID: 529
			public static CallSite<Action<CallSite, object, int>> <>p__21;
		}

		// Token: 0x02000037 RID: 55
		[CompilerGenerated]
		private static class <>o__156
		{
			// Token: 0x04000252 RID: 594
			public static CallSite<Action<CallSite, object>> <>p__0;

			// Token: 0x04000253 RID: 595
			public static CallSite<Action<CallSite, object, int>> <>p__1;

			// Token: 0x04000254 RID: 596
			public static CallSite<Action<CallSite, object>> <>p__2;

			// Token: 0x04000255 RID: 597
			public static CallSite<Func<CallSite, object, string, string, int, object>> <>p__3;

			// Token: 0x04000256 RID: 598
			public static CallSite<Func<CallSite, object, object>> <>p__4;

			// Token: 0x04000257 RID: 599
			public static CallSite<Func<CallSite, object, bool>> <>p__5;

			// Token: 0x04000258 RID: 600
			public static CallSite<Func<CallSite, object, byte, object>> <>p__6;

			// Token: 0x04000259 RID: 601
			public static CallSite<Func<CallSite, object, bool>> <>p__7;

			// Token: 0x0400025A RID: 602
			public static CallSite<Func<CallSite, object, int, object>> <>p__8;

			// Token: 0x0400025B RID: 603
			public static CallSite<Func<CallSite, object, string>> <>p__9;

			// Token: 0x0400025C RID: 604
			public static CallSite<Action<CallSite, object>> <>p__10;

			// Token: 0x0400025D RID: 605
			public static CallSite<Action<CallSite, object, int>> <>p__11;
		}

		// Token: 0x02000045 RID: 69
		[CompilerGenerated]
		private static class <>o__170
		{
			// Token: 0x04000281 RID: 641
			public static CallSite<Action<CallSite, object, int>> <>p__0;

			// Token: 0x04000282 RID: 642
			public static CallSite<Action<CallSite, object>> <>p__1;

			// Token: 0x04000283 RID: 643
			public static CallSite<Func<CallSite, object, string, string, int, object>> <>p__2;

			// Token: 0x04000284 RID: 644
			public static CallSite<Func<CallSite, object, object>> <>p__3;

			// Token: 0x04000285 RID: 645
			public static CallSite<Func<CallSite, object, bool>> <>p__4;

			// Token: 0x04000286 RID: 646
			public static CallSite<Func<CallSite, object, byte, object>> <>p__5;

			// Token: 0x04000287 RID: 647
			public static CallSite<Func<CallSite, object, bool>> <>p__6;

			// Token: 0x04000288 RID: 648
			public static CallSite<Func<CallSite, object, int, object>> <>p__7;

			// Token: 0x04000289 RID: 649
			public static CallSite<Func<CallSite, object, string>> <>p__8;

			// Token: 0x0400028A RID: 650
			public static CallSite<Action<CallSite, object>> <>p__9;

			// Token: 0x0400028B RID: 651
			public static CallSite<Action<CallSite, object, int>> <>p__10;
		}
	}
}
