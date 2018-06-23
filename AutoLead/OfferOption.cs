using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AutoLead
{
	// Token: 0x0200005B RID: 91
	public partial class OfferOption : Form
	{
		// Token: 0x060003A5 RID: 933 RVA: 0x0000366C File Offset: 0x0000186C
		public OfferOption()
		{
			this.InitializeComponent();
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x00003684 File Offset: 0x00001884
		private void button2_Click(object sender, EventArgs e)
		{
			base.Hide();
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x00025AAC File Offset: 0x00023CAC
		public void setFormData(bool offerenable, string offername, string offerurl, string appname, int sleeptimebefore, bool sleeptimebeforeenable, int range1, int range2, int sleeptime, bool usescript, string script, string referer)
		{
			this.add = false;
			this.checkBox1.Checked = offerenable;
			this.textBox1.Text = offername;
			this.textBox2.Text = offerurl;
			this.comboBox1.Text = appname;
			this.checkBox2.Checked = usescript;
			this.checkBox3.Checked = sleeptimebeforeenable;
			this.numericUpDown3.Value = range1;
			this.numericUpDown4.Value = range2;
			this.numericUpDown2.Value = sleeptimebefore;
			this.textBox4.Text = script;
			this.numericUpDown1.Value = sleeptime;
			this.textBox3.Text = referer;
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x00025B7C File Offset: 0x00023D7C
		public void resetFormData()
		{
			this.add = true;
			this.checkBox1.Checked = false;
			this.textBox1.Text = "";
			this.textBox2.Text = "";
			this.comboBox1.Text = "";
			this.checkBox2.Checked = false;
			this.checkBox3.Checked = false;
			this.numericUpDown3.Value = 2m;
			this.numericUpDown4.Value = 5m;
			this.numericUpDown2.Value = 2m;
			this.numericUpDown3.Enabled = false;
			this.numericUpDown4.Enabled = false;
			this.textBox4.Text = "";
			this.numericUpDown1.Value = 25m;
			this.textBox3.Text = "https://google.com\r\nhttps://yahoo.com\r\nhttps://bing.com\r\nhttps://facebook.com";
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x00025C70 File Offset: 0x00023E70
		public void setComboBoxItem(object appList)
		{
			this.comboBox1.Items.Clear();
			bool flag = appList != null;
			if (flag)
			{
				foreach (appDetail current in ((List<appDetail>)appList))
				{
					this.comboBox1.Items.Add(current.appName);
				}
			}
		}

		// Token: 0x060003AA RID: 938 RVA: 0x00025CF4 File Offset: 0x00023EF4
		private void button1_Click(object sender, EventArgs e)
		{
			bool flag = this.textBox1.Text == "";
			if (flag)
			{
				MessageBox.Show("Offer name is required!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				bool flag2 = this.textBox2.Text == "";
				if (flag2)
				{
					MessageBox.Show("Offer URL is required!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					Uri uri;
					bool flag3 = Uri.TryCreate(this.textBox2.Text, UriKind.Absolute, out uri) && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
					bool flag4 = !flag3;
					if (flag4)
					{
						MessageBox.Show("Offer URL is invalid!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					else
					{
						bool flag5 = this.passControl != null;
						if (flag5)
						{
							offerItem offerItem = new offerItem();
							offerItem.appName = this.comboBox1.Text;
							offerItem.appID = this.comboBox1.SelectedIndex.ToString();
							offerItem.offerEnable = this.checkBox1.Checked;
							offerItem.offerName = this.textBox1.Text;
							offerItem.offerURL = this.textBox2.Text;
							offerItem.timeSleepBefore = (int)this.numericUpDown2.Value;
							offerItem.timeSleepBeforeRandom = this.checkBox3.Checked;
							offerItem.range1 = (int)this.numericUpDown3.Value;
							offerItem.range2 = (int)this.numericUpDown4.Value;
							offerItem.timeSleep = (int)this.numericUpDown1.Value;
							offerItem.useScript = this.checkBox2.Checked;
							offerItem.script = this.textBox4.Text;
							offerItem.referer = this.textBox3.Text;
							this.passControl(this.add, offerItem);
							base.Hide();
						}
					}
				}
			}
		}

		// Token: 0x060003AB RID: 939 RVA: 0x00025F18 File Offset: 0x00024118
		private void button3_Click(object sender, EventArgs e)
		{
			bool flag = this.UpdateCombo != null;
			if (flag)
			{
				this.UpdateCombo();
			}
		}

		// Token: 0x060003AC RID: 940 RVA: 0x00025F44 File Offset: 0x00024144
		public void setButton3(bool getting)
		{
			if (getting)
			{
				this.button3.Text = "Getting";
				this.button3.Enabled = false;
			}
			else
			{
				this.button3.Text = "Get list";
				this.button3.Enabled = true;
			}
		}

		// Token: 0x060003AD RID: 941 RVA: 0x0000368E File Offset: 0x0000188E
		public void disableButton3()
		{
			this.button3.Enabled = false;
		}

		// Token: 0x060003AE RID: 942 RVA: 0x00025F9C File Offset: 0x0002419C
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			bool flag = keyData == Keys.Escape;
			bool result;
			if (flag)
			{
				base.Hide();
				result = true;
			}
			else
			{
				result = base.ProcessCmdKey(ref msg, keyData);
			}
			return result;
		}

		// Token: 0x060003AF RID: 943 RVA: 0x00025FCC File Offset: 0x000241CC
		private void checkBox3_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.checkBox3.Checked;
			if (@checked)
			{
				this.numericUpDown2.Enabled = false;
				this.numericUpDown3.Enabled = true;
				this.numericUpDown4.Enabled = true;
			}
			else
			{
				this.numericUpDown2.Enabled = true;
				this.numericUpDown3.Enabled = false;
				this.numericUpDown4.Enabled = false;
			}
		}

		// Token: 0x040002E1 RID: 737
		public bool add;

		// Token: 0x040002E2 RID: 738
		public OfferOption.updateCombo UpdateCombo;

		// Token: 0x040002E3 RID: 739
		public OfferOption.PassControl passControl;

		// Token: 0x0200005C RID: 92
		// Token: 0x060003B3 RID: 947
		public delegate void PassControl(bool add, object sender);

		// Token: 0x0200005D RID: 93
		// Token: 0x060003B7 RID: 951
		public delegate void updateCombo();
	}
}
