namespace AutoLead
{
	// Token: 0x02000013 RID: 19
	public partial class Form1 : global::System.Windows.Forms.Form
	{
		// Token: 0x0600017B RID: 379 RVA: 0x00016DD4 File Offset: 0x00014FD4
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600017C RID: 380 RVA: 0x00016E0C File Offset: 0x0001500C
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::AutoLead.Form1));
			global::System.Windows.Forms.ListViewItem listViewItem = new global::System.Windows.Forms.ListViewItem("All Script");
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.button20 = new global::System.Windows.Forms.Button();
			this.button23 = new global::System.Windows.Forms.Button();
			this.proxytool = new global::System.Windows.Forms.ComboBox();
			this.label21 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label20 = new global::System.Windows.Forms.Label();
			this.ipAddressControl1 = new global::IPAddressControlLib.IPAddressControl();
			this.label3 = new global::System.Windows.Forms.Label();
			this.numericUpDown1 = new global::System.Windows.Forms.NumericUpDown();
			this.comboBox5 = new global::System.Windows.Forms.ComboBox();
			this.label6 = new global::System.Windows.Forms.Label();
			this.button1 = new global::System.Windows.Forms.Button();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.button2 = new global::System.Windows.Forms.Button();
			this.DeviceIpControl = new global::IPAddressControlLib.IPAddressControl();
			this.label4 = new global::System.Windows.Forms.Label();
			this.labelSerial = new global::System.Windows.Forms.Label();
			this.label12 = new global::System.Windows.Forms.Label();
			this.imageList1 = new global::System.Windows.Forms.ImageList(this.components);
			this.autoreconnect = new global::System.Windows.Forms.CheckBox();
			this.contextMenuStrip1 = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.deleteToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip2 = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.deleteToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.moveToSlotToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip3 = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.bảoVệDữLiệuToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip4 = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.deleteToolStripMenuItem2 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.tabPage5 = new global::System.Windows.Forms.TabPage();
			this.label25 = new global::System.Windows.Forms.Label();
			this.label24 = new global::System.Windows.Forms.Label();
			this.label23 = new global::System.Windows.Forms.Label();
			this.label13 = new global::System.Windows.Forms.Label();
			this.pictureBox5 = new global::System.Windows.Forms.PictureBox();
			this.pictureBox4 = new global::System.Windows.Forms.PictureBox();
			this.pictureBox3 = new global::System.Windows.Forms.PictureBox();
			this.pictureBox2 = new global::System.Windows.Forms.PictureBox();
			this.tabPage10 = new global::System.Windows.Forms.TabPage();
			this.button54 = new global::System.Windows.Forms.Button();
			this.checkBox16 = new global::System.Windows.Forms.CheckBox();
			this.button53 = new global::System.Windows.Forms.Button();
			this.button52 = new global::System.Windows.Forms.Button();
			this.button51 = new global::System.Windows.Forms.Button();
			this.button50 = new global::System.Windows.Forms.Button();
			this.button49 = new global::System.Windows.Forms.Button();
			this.button48 = new global::System.Windows.Forms.Button();
			this.button47 = new global::System.Windows.Forms.Button();
			this.button46 = new global::System.Windows.Forms.Button();
			this.button45 = new global::System.Windows.Forms.Button();
			this.button44 = new global::System.Windows.Forms.Button();
			this.button43 = new global::System.Windows.Forms.Button();
			this.button42 = new global::System.Windows.Forms.Button();
			this.button41 = new global::System.Windows.Forms.Button();
			this.button40 = new global::System.Windows.Forms.Button();
			this.button39 = new global::System.Windows.Forms.Button();
			this.button38 = new global::System.Windows.Forms.Button();
			this.button37 = new global::System.Windows.Forms.Button();
			this.tabPage9 = new global::System.Windows.Forms.TabPage();
			this.groupBox8 = new global::System.Windows.Forms.GroupBox();
			this.napcodestt = new global::System.Windows.Forms.Label();
			this.deviceseri = new global::System.Windows.Forms.TextBox();
			this.button36 = new global::System.Windows.Forms.Button();
			this.label36 = new global::System.Windows.Forms.Label();
			this.code = new global::System.Windows.Forms.TextBox();
			this.label37 = new global::System.Windows.Forms.Label();
			this.Script = new global::System.Windows.Forms.TabPage();
			this.textBox9 = new global::System.Windows.Forms.TextBox();
			this.label33 = new global::System.Windows.Forms.Label();
			this.button34 = new global::System.Windows.Forms.Button();
			this.button33 = new global::System.Windows.Forms.Button();
			this.button32 = new global::System.Windows.Forms.Button();
			this.listView7 = new global::System.Windows.Forms.ListView();
			this.columnHeader14 = new global::System.Windows.Forms.ColumnHeader();
			this.textBox6 = new global::System.Windows.Forms.TextBox();
			this.listView6 = new global::System.Windows.Forms.ListView();
			this.columnHeader13 = new global::System.Windows.Forms.ColumnHeader();
			this.tabPage6 = new global::System.Windows.Forms.TabPage();
			this.textBox5 = new global::System.Windows.Forms.TextBox();
			this.listView5 = new global::System.Windows.Forms.ListView();
			this.groupBox6 = new global::System.Windows.Forms.GroupBox();
			this.checkBox20 = new global::System.Windows.Forms.CheckBox();
			this.longtitude = new global::System.Windows.Forms.NumericUpDown();
			this.ltimezone = new global::System.Windows.Forms.Label();
			this.checkBox19 = new global::System.Windows.Forms.CheckBox();
			this.checkBox13 = new global::System.Windows.Forms.CheckBox();
			this.label41 = new global::System.Windows.Forms.Label();
			this.checkBox5 = new global::System.Windows.Forms.CheckBox();
			this.label40 = new global::System.Windows.Forms.Label();
			this.checkBox9 = new global::System.Windows.Forms.CheckBox();
			this.latitude = new global::System.Windows.Forms.NumericUpDown();
			this.carrierBox = new global::System.Windows.Forms.ComboBox();
			this.fakelang = new global::System.Windows.Forms.CheckBox();
			this.comboBox2 = new global::System.Windows.Forms.ComboBox();
			this.fakeregion = new global::System.Windows.Forms.CheckBox();
			this.comboBox1 = new global::System.Windows.Forms.ComboBox();
			this.groupBox7 = new global::System.Windows.Forms.GroupBox();
			this.label63 = new global::System.Windows.Forms.Label();
			this.label43 = new global::System.Windows.Forms.Label();
			this.numericUpDown10 = new global::System.Windows.Forms.NumericUpDown();
			this.label31 = new global::System.Windows.Forms.Label();
			this.label32 = new global::System.Windows.Forms.Label();
			this.numericUpDown5 = new global::System.Windows.Forms.NumericUpDown();
			this.checkBox4 = new global::System.Windows.Forms.CheckBox();
			this.numericUpDown4 = new global::System.Windows.Forms.NumericUpDown();
			this.label30 = new global::System.Windows.Forms.Label();
			this.groupBox9 = new global::System.Windows.Forms.GroupBox();
			this.fakeversion = new global::System.Windows.Forms.CheckBox();
			this.iphone = new global::System.Windows.Forms.CheckBox();
			this.ipad = new global::System.Windows.Forms.CheckBox();
			this.ipod = new global::System.Windows.Forms.CheckBox();
			this.checkBox11 = new global::System.Windows.Forms.CheckBox();
			this.fakemodel = new global::System.Windows.Forms.CheckBox();
			this.fileofname = new global::System.Windows.Forms.Label();
			this.fakedevice = new global::System.Windows.Forms.CheckBox();
			this.checkBox15 = new global::System.Windows.Forms.CheckBox();
			this.checkBox14 = new global::System.Windows.Forms.CheckBox();
			this.tabPage8 = new global::System.Windows.Forms.TabPage();
			this.pausescript = new global::System.Windows.Forms.Button();
			this.textBox2 = new global::System.Windows.Forms.RichTextBox();
			this.button64 = new global::System.Windows.Forms.Button();
			this.button35 = new global::System.Windows.Forms.Button();
			this.button30 = new global::System.Windows.Forms.Button();
			this.trackBar1 = new global::System.Windows.Forms.TrackBar();
			this.groupBox4 = new global::System.Windows.Forms.GroupBox();
			this.button11 = new global::System.Windows.Forms.Button();
			this.textBox1 = new global::System.Windows.Forms.TextBox();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.button26 = new global::System.Windows.Forms.Button();
			this.textBox7 = new global::System.Windows.Forms.TextBox();
			this.label18 = new global::System.Windows.Forms.Label();
			this.label19 = new global::System.Windows.Forms.Label();
			this.textBox8 = new global::System.Windows.Forms.TextBox();
			this.textBox3 = new global::System.Windows.Forms.TextBox();
			this.button18 = new global::System.Windows.Forms.Button();
			this.groupBox5 = new global::System.Windows.Forms.GroupBox();
			this.button28 = new global::System.Windows.Forms.Button();
			this.label11 = new global::System.Windows.Forms.Label();
			this.button13 = new global::System.Windows.Forms.Button();
			this.button12 = new global::System.Windows.Forms.Button();
			this.button10 = new global::System.Windows.Forms.Button();
			this.wipecombo = new global::System.Windows.Forms.ComboBox();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.tabPage7 = new global::System.Windows.Forms.TabPage();
			this.label35 = new global::System.Windows.Forms.Label();
			this.label34 = new global::System.Windows.Forms.Label();
			this.checkBox7 = new global::System.Windows.Forms.CheckBox();
			this.comboBox3 = new global::System.Windows.Forms.ComboBox();
			this.checkBox6 = new global::System.Windows.Forms.CheckBox();
			this.button31 = new global::System.Windows.Forms.Button();
			this.label26 = new global::System.Windows.Forms.Label();
			this.textBox4 = new global::System.Windows.Forms.TextBox();
			this.button29 = new global::System.Windows.Forms.Button();
			this.button27 = new global::System.Windows.Forms.Button();
			this.label9 = new global::System.Windows.Forms.Label();
			this.rsswaitnum = new global::System.Windows.Forms.NumericUpDown();
			this.label8 = new global::System.Windows.Forms.Label();
			this.bkreset = new global::System.Windows.Forms.Button();
			this.button19 = new global::System.Windows.Forms.Button();
			this.button17 = new global::System.Windows.Forms.Button();
			this.button16 = new global::System.Windows.Forms.Button();
			this.button15 = new global::System.Windows.Forms.Button();
			this.listView4 = new global::System.Windows.Forms.ListView();
			this.columnHeader10 = new global::System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new global::System.Windows.Forms.ColumnHeader();
			this.columnHeader11 = new global::System.Windows.Forms.ColumnHeader();
			this.columnHeader12 = new global::System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new global::System.Windows.Forms.ColumnHeader();
			this.columnHeader9 = new global::System.Windows.Forms.ColumnHeader();
			this.columnHeader15 = new global::System.Windows.Forms.ColumnHeader();
			this.columnHeader16 = new global::System.Windows.Forms.ColumnHeader();
			this.tabPage2 = new global::System.Windows.Forms.TabPage();
			this.tabControl2 = new global::System.Windows.Forms.TabControl();
			this.tabPage3 = new global::System.Windows.Forms.TabPage();
			this.checkBox17 = new global::System.Windows.Forms.CheckBox();
			this.ss_dead = new global::System.Windows.Forms.Label();
			this.ssh_used = new global::System.Windows.Forms.Label();
			this.ssh_live = new global::System.Windows.Forms.Label();
			this.ssh_uncheck = new global::System.Windows.Forms.Label();
			this.numericUpDown2 = new global::System.Windows.Forms.NumericUpDown();
			this.label14 = new global::System.Windows.Forms.Label();
			this.labeltotalssh = new global::System.Windows.Forms.Label();
			this.button25 = new global::System.Windows.Forms.Button();
			this.button24 = new global::System.Windows.Forms.Button();
			this.button22 = new global::System.Windows.Forms.Button();
			this.button8 = new global::System.Windows.Forms.Button();
			this.button14 = new global::System.Windows.Forms.Button();
			this.button9 = new global::System.Windows.Forms.Button();
			this.importfromfile = new global::System.Windows.Forms.Button();
			this.listView2 = new global::System.Windows.Forms.ListView();
			this.columnHeader1 = new global::System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new global::System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new global::System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new global::System.Windows.Forms.ColumnHeader();
			this.tabPage4 = new global::System.Windows.Forms.TabPage();
			this.sameVip = new global::System.Windows.Forms.CheckBox();
			this.button57 = new global::System.Windows.Forms.Button();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.vippassword = new global::System.Windows.Forms.TextBox();
			this.vipid = new global::System.Windows.Forms.TextBox();
			this.label10 = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.vipadd = new global::System.Windows.Forms.Button();
			this.vipdelete = new global::System.Windows.Forms.Button();
			this.listView3 = new global::System.Windows.Forms.ListView();
			this.columnHeader5 = new global::System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new global::System.Windows.Forms.ColumnHeader();
			this.tabPage1 = new global::System.Windows.Forms.TabPage();
			this.textBox11 = new global::System.Windows.Forms.TextBox();
			this.comment = new global::System.Windows.Forms.TextBox();
			this.label44 = new global::System.Windows.Forms.Label();
			this.checkBox18 = new global::System.Windows.Forms.CheckBox();
			this.checkBox12 = new global::System.Windows.Forms.CheckBox();
			this.numericUpDown6 = new global::System.Windows.Forms.NumericUpDown();
			this.checkBox10 = new global::System.Windows.Forms.CheckBox();
			this.backuprate = new global::System.Windows.Forms.Label();
			this.backupoftime = new global::System.Windows.Forms.Label();
			this.runoftime = new global::System.Windows.Forms.Label();
			this.label29 = new global::System.Windows.Forms.Label();
			this.label28 = new global::System.Windows.Forms.Label();
			this.numericUpDown3 = new global::System.Windows.Forms.NumericUpDown();
			this.label27 = new global::System.Windows.Forms.Label();
			this.itunesY = new global::System.Windows.Forms.NumericUpDown();
			this.label22 = new global::System.Windows.Forms.Label();
			this.itunesX = new global::System.Windows.Forms.NumericUpDown();
			this.label17 = new global::System.Windows.Forms.Label();
			this.safariY = new global::System.Windows.Forms.NumericUpDown();
			this.label16 = new global::System.Windows.Forms.Label();
			this.safariX = new global::System.Windows.Forms.NumericUpDown();
			this.label15 = new global::System.Windows.Forms.Label();
			this.button21 = new global::System.Windows.Forms.Button();
			this.Reset = new global::System.Windows.Forms.Button();
			this.checkBox3 = new global::System.Windows.Forms.CheckBox();
			this.checkBox2 = new global::System.Windows.Forms.CheckBox();
			this.button7 = new global::System.Windows.Forms.Button();
			this.checkBox1 = new global::System.Windows.Forms.CheckBox();
			this.button6 = new global::System.Windows.Forms.Button();
			this.button5 = new global::System.Windows.Forms.Button();
			this.button4 = new global::System.Windows.Forms.Button();
			this.button3 = new global::System.Windows.Forms.Button();
			this.listView1 = new global::System.Windows.Forms.ListView();
			this.offername = new global::System.Windows.Forms.ColumnHeader();
			this.offerurl = new global::System.Windows.Forms.ColumnHeader();
			this.appname = new global::System.Windows.Forms.ColumnHeader();
			this.timedelay = new global::System.Windows.Forms.ColumnHeader();
			this.usescript = new global::System.Windows.Forms.ColumnHeader();
			this.Contact = new global::System.Windows.Forms.TabControl();
			this.l_autover = new global::System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown1).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			this.contextMenuStrip2.SuspendLayout();
			this.contextMenuStrip3.SuspendLayout();
			this.tabPage5.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox5).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox4).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
			this.tabPage10.SuspendLayout();
			this.tabPage9.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.Script.SuspendLayout();
			this.tabPage6.SuspendLayout();
			this.groupBox6.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.longtitude).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.latitude).BeginInit();
			this.groupBox7.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown10).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown5).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown4).BeginInit();
			this.groupBox9.SuspendLayout();
			this.tabPage8.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.trackBar1).BeginInit();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox5.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			this.tabPage7.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.rsswaitnum).BeginInit();
			this.tabPage2.SuspendLayout();
			this.tabControl2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown2).BeginInit();
			this.tabPage4.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown6).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown3).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.itunesY).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.itunesX).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.safariY).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.safariX).BeginInit();
			this.Contact.SuspendLayout();
			base.SuspendLayout();
			this.groupBox1.BackColor = global::System.Drawing.SystemColors.GradientInactiveCaption;
			this.groupBox1.Controls.Add(this.button20);
			this.groupBox1.Controls.Add(this.button23);
			this.groupBox1.Controls.Add(this.proxytool);
			this.groupBox1.Controls.Add(this.label21);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label20);
			this.groupBox1.Controls.Add(this.ipAddressControl1);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.numericUpDown1);
			this.groupBox1.Controls.Add(this.comboBox5);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Location = new global::System.Drawing.Point(14, 442);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(626, 86);
			this.groupBox1.TabIndex = 17;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Proxy Setting";
			this.button20.Location = new global::System.Drawing.Point(266, 49);
			this.button20.Name = "button20";
			this.button20.Size = new global::System.Drawing.Size(75, 23);
			this.button20.TabIndex = 17;
			this.button20.Text = "Change IP";
			this.button20.UseVisualStyleBackColor = true;
			this.button20.Click += new global::System.EventHandler(this.button20_Click_1);
			this.button23.BackColor = global::System.Drawing.Color.Aqua;
			this.button23.Location = new global::System.Drawing.Point(478, 19);
			this.button23.Name = "button23";
			this.button23.Size = new global::System.Drawing.Size(96, 33);
			this.button23.TabIndex = 16;
			this.button23.Text = "Apply";
			this.button23.UseVisualStyleBackColor = false;
			this.button23.Click += new global::System.EventHandler(this.button23_Click);
			this.proxytool.DisplayMember = "SSH";
			this.proxytool.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.proxytool.FormattingEnabled = true;
			this.proxytool.Items.AddRange(new object[]
			{
				"Vip72",
				"SSH",
				"Direct"
			});
			this.proxytool.Location = new global::System.Drawing.Point(98, 23);
			this.proxytool.Name = "proxytool";
			this.proxytool.Size = new global::System.Drawing.Size(69, 21);
			this.proxytool.TabIndex = 11;
			this.proxytool.SelectedIndexChanged += new global::System.EventHandler(this.proxytool_SelectedIndexChanged);
			this.label21.AutoSize = true;
			this.label21.Location = new global::System.Drawing.Point(225, 28);
			this.label21.Name = "label21";
			this.label21.Size = new global::System.Drawing.Size(20, 13);
			this.label21.TabIndex = 9;
			this.label21.Text = "IP:";
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(21, 26);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(60, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "Proxy Tool:";
			this.label20.AutoSize = true;
			this.label20.Location = new global::System.Drawing.Point(25, 52);
			this.label20.Name = "label20";
			this.label20.Size = new global::System.Drawing.Size(46, 13);
			this.label20.TabIndex = 7;
			this.label20.Text = "Country:";
			this.ipAddressControl1.AllowInternalTab = false;
			this.ipAddressControl1.AutoHeight = true;
			this.ipAddressControl1.BackColor = global::System.Drawing.SystemColors.Window;
			this.ipAddressControl1.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.ipAddressControl1.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.ipAddressControl1.Enabled = false;
			this.ipAddressControl1.Location = new global::System.Drawing.Point(260, 25);
			this.ipAddressControl1.MinimumSize = new global::System.Drawing.Size(87, 20);
			this.ipAddressControl1.Name = "ipAddressControl1";
			this.ipAddressControl1.ReadOnly = false;
			this.ipAddressControl1.Size = new global::System.Drawing.Size(87, 20);
			this.ipAddressControl1.TabIndex = 8;
			this.ipAddressControl1.Text = "...";
			this.ipAddressControl1.TextChanged += new global::System.EventHandler(this.ipAddressControl1_TextChanged);
			this.ipAddressControl1.Click += new global::System.EventHandler(this.ipAddressControl1_Click);
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(58, 53);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(0, 13);
			this.label3.TabIndex = 7;
			this.numericUpDown1.Enabled = false;
			this.numericUpDown1.Location = new global::System.Drawing.Point(411, 26);
			global::System.Windows.Forms.NumericUpDown arg_1349_0 = this.numericUpDown1;
			int[] expr_133C = new int[4];
			expr_133C[0] = 65535;
			arg_1349_0.Maximum = new decimal(expr_133C);
			global::System.Windows.Forms.NumericUpDown arg_1364_0 = this.numericUpDown1;
			int[] expr_135B = new int[4];
			expr_135B[0] = 1;
			arg_1364_0.Minimum = new decimal(expr_135B);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new global::System.Drawing.Size(50, 20);
			this.numericUpDown1.TabIndex = 4;
			global::System.Windows.Forms.NumericUpDown arg_13B6_0 = this.numericUpDown1;
			int[] expr_13A9 = new int[4];
			expr_13A9[0] = 1080;
			arg_13B6_0.Value = new decimal(expr_13A9);
			this.numericUpDown1.ValueChanged += new global::System.EventHandler(this.numericUpDown1_ValueChanged);
			this.comboBox5.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox5.FormattingEnabled = true;
			this.comboBox5.Location = new global::System.Drawing.Point(98, 49);
			this.comboBox5.Name = "comboBox5";
			this.comboBox5.Size = new global::System.Drawing.Size(91, 21);
			this.comboBox5.TabIndex = 6;
			this.comboBox5.SelectedIndexChanged += new global::System.EventHandler(this.comboBox5_SelectedIndexChanged);
			this.label6.AutoSize = true;
			this.label6.Location = new global::System.Drawing.Point(376, 28);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(29, 13);
			this.label6.TabIndex = 3;
			this.label6.Text = "Port:";
			this.button1.Location = new global::System.Drawing.Point(541, 600);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Close";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.label1.AutoSize = true;
			this.label1.FlatStyle = global::System.Windows.Forms.FlatStyle.System;
			this.label1.Location = new global::System.Drawing.Point(39, 605);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(37, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Status";
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(39, 542);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(57, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Device IP:";
			this.button2.Location = new global::System.Drawing.Point(280, 534);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(75, 23);
			this.button2.TabIndex = 5;
			this.button2.Text = "Connect";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			this.DeviceIpControl.AllowInternalTab = false;
			this.DeviceIpControl.AutoHeight = true;
			this.DeviceIpControl.BackColor = global::System.Drawing.SystemColors.Window;
			this.DeviceIpControl.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.DeviceIpControl.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.DeviceIpControl.Location = new global::System.Drawing.Point(117, 536);
			this.DeviceIpControl.MinimumSize = new global::System.Drawing.Size(87, 20);
			this.DeviceIpControl.Name = "DeviceIpControl";
			this.DeviceIpControl.ReadOnly = false;
			this.DeviceIpControl.Size = new global::System.Drawing.Size(118, 20);
			this.DeviceIpControl.TabIndex = 6;
			this.DeviceIpControl.Text = "...";
			this.DeviceIpControl.TextChanged += new global::System.EventHandler(this.DeviceIpControl_TextChanged);
			this.DeviceIpControl.Click += new global::System.EventHandler(this.DeviceIpControl_Click);
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(52, 575);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(0, 13);
			this.label4.TabIndex = 8;
			this.labelSerial.AutoSize = true;
			this.labelSerial.Location = new global::System.Drawing.Point(39, 575);
			this.labelSerial.Name = "labelSerial";
			this.labelSerial.Size = new global::System.Drawing.Size(76, 13);
			this.labelSerial.TabIndex = 12;
			this.labelSerial.Text = "Serial Number:";
			this.label12.AutoSize = true;
			this.label12.Location = new global::System.Drawing.Point(184, 575);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(71, 13);
			this.label12.TabIndex = 18;
			this.label12.Text = "Date Expired:";
			this.imageList1.ImageStream = (global::System.Windows.Forms.ImageListStreamer)componentResourceManager.GetObject("imageList1.ImageStream");
			this.imageList1.TransparentColor = global::System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "Folder.png");
			this.autoreconnect.AutoSize = true;
			this.autoreconnect.Location = new global::System.Drawing.Point(412, 538);
			this.autoreconnect.Name = "autoreconnect";
			this.autoreconnect.Size = new global::System.Drawing.Size(104, 17);
			this.autoreconnect.TabIndex = 19;
			this.autoreconnect.Text = "Auto Reconnect";
			this.autoreconnect.UseVisualStyleBackColor = true;
			this.autoreconnect.CheckedChanged += new global::System.EventHandler(this.autoreconnect_CheckedChanged);
			this.contextMenuStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.deleteToolStripMenuItem
			});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new global::System.Drawing.Size(108, 26);
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new global::System.Drawing.Size(107, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new global::System.EventHandler(this.deleteToolStripMenuItem_Click);
			this.contextMenuStrip2.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.deleteToolStripMenuItem1,
				this.moveToSlotToolStripMenuItem
			});
			this.contextMenuStrip2.Name = "contextMenuStrip2";
			this.contextMenuStrip2.Size = new global::System.Drawing.Size(144, 48);
			this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
			this.deleteToolStripMenuItem1.Size = new global::System.Drawing.Size(143, 22);
			this.deleteToolStripMenuItem1.Text = "Delete";
			this.deleteToolStripMenuItem1.Click += new global::System.EventHandler(this.deleteToolStripMenuItem1_Click);
			this.moveToSlotToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.toolStripMenuItem1
			});
			this.moveToSlotToolStripMenuItem.Name = "moveToSlotToolStripMenuItem";
			this.moveToSlotToolStripMenuItem.Size = new global::System.Drawing.Size(143, 22);
			this.moveToSlotToolStripMenuItem.Text = "Move To Slot";
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new global::System.Drawing.Size(103, 22);
			this.toolStripMenuItem1.Text = "None";
			this.toolStripMenuItem1.Click += new global::System.EventHandler(this.toolStripMenuItem1_Click);
			this.contextMenuStrip3.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.bảoVệDữLiệuToolStripMenuItem
			});
			this.contextMenuStrip3.Name = "contextMenuStrip3";
			this.contextMenuStrip3.Size = new global::System.Drawing.Size(68, 26);
			this.bảoVệDữLiệuToolStripMenuItem.Name = "bảoVệDữLiệuToolStripMenuItem";
			this.bảoVệDữLiệuToolStripMenuItem.Size = new global::System.Drawing.Size(67, 22);
			this.contextMenuStrip4.Name = "contextMenuStrip4";
			this.contextMenuStrip4.Size = new global::System.Drawing.Size(61, 4);
			this.deleteToolStripMenuItem2.Name = "deleteToolStripMenuItem2";
			this.deleteToolStripMenuItem2.Size = new global::System.Drawing.Size(32, 19);
			this.tabPage5.Controls.Add(this.label25);
			this.tabPage5.Controls.Add(this.label24);
			this.tabPage5.Controls.Add(this.label23);
			this.tabPage5.Controls.Add(this.label13);
			this.tabPage5.Controls.Add(this.pictureBox5);
			this.tabPage5.Controls.Add(this.pictureBox4);
			this.tabPage5.Controls.Add(this.pictureBox3);
			this.tabPage5.Controls.Add(this.pictureBox2);
			this.tabPage5.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage5.Size = new global::System.Drawing.Size(620, 398);
			this.tabPage5.TabIndex = 5;
			this.tabPage5.Text = "Contact";
			this.tabPage5.UseVisualStyleBackColor = true;
			this.label25.AutoSize = true;
			this.label25.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label25.Location = new global::System.Drawing.Point(133, 281);
			this.label25.Name = "label25";
			this.label25.Size = new global::System.Drawing.Size(150, 16);
			this.label25.TabIndex = 8;
			this.label25.Text = "";
			this.label24.AutoSize = true;
			this.label24.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label24.Location = new global::System.Drawing.Point(133, 205);
			this.label24.Name = "label24";
			this.label24.Size = new global::System.Drawing.Size(169, 16);
			this.label24.TabIndex = 7;
			this.label24.Text = "https://facebook.com/phatdatpq";
			this.label23.AutoSize = true;
			this.label23.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label23.Location = new global::System.Drawing.Point(133, 133);
			this.label23.Name = "label23";
			this.label23.Size = new global::System.Drawing.Size(58, 16);
			this.label23.TabIndex = 6;
			this.label23.Text = "";
			this.label13.AutoSize = true;
			this.label13.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label13.Location = new global::System.Drawing.Point(133, 57);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(96, 16);
			this.label13.TabIndex = 5;
			this.label13.Text = "";
			this.pictureBox5.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox5.Image");
			this.pictureBox5.Location = new global::System.Drawing.Point(40, 261);
			this.pictureBox5.Name = "pictureBox5";
			this.pictureBox5.Size = new global::System.Drawing.Size(51, 60);
			this.pictureBox5.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox5.TabIndex = 4;
			this.pictureBox5.TabStop = false;
			this.pictureBox4.Image = global::AutoLead.Properties.Resources.social_facebook_box_blue_icon;
			this.pictureBox4.Location = new global::System.Drawing.Point(43, 185);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new global::System.Drawing.Size(48, 50);
			this.pictureBox4.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox4.TabIndex = 3;
			this.pictureBox4.TabStop = false;
			this.pictureBox3.Image = global::AutoLead.Properties.Resources.Skype_icon;
			this.pictureBox3.Location = new global::System.Drawing.Point(43, 113);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new global::System.Drawing.Size(48, 50);
			this.pictureBox3.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox3.TabIndex = 2;
			this.pictureBox3.TabStop = false;
			this.pictureBox2.Image = global::AutoLead.Properties.Resources.Phone_icon;
			this.pictureBox2.Location = new global::System.Drawing.Point(40, 31);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new global::System.Drawing.Size(51, 62);
			this.pictureBox2.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox2.TabIndex = 1;
			this.pictureBox2.TabStop = false;
			this.tabPage10.Controls.Add(this.button54);
			this.tabPage10.Controls.Add(this.checkBox16);
			this.tabPage10.Controls.Add(this.button53);
			this.tabPage10.Controls.Add(this.button52);
			this.tabPage10.Controls.Add(this.button51);
			this.tabPage10.Controls.Add(this.button50);
			this.tabPage10.Controls.Add(this.button49);
			this.tabPage10.Controls.Add(this.button48);
			this.tabPage10.Controls.Add(this.button47);
			this.tabPage10.Controls.Add(this.button46);
			this.tabPage10.Controls.Add(this.button45);
			this.tabPage10.Controls.Add(this.button44);
			this.tabPage10.Controls.Add(this.button43);
			this.tabPage10.Controls.Add(this.button42);
			this.tabPage10.Controls.Add(this.button41);
			this.tabPage10.Controls.Add(this.button40);
			this.tabPage10.Controls.Add(this.button39);
			this.tabPage10.Controls.Add(this.button38);
			this.tabPage10.Controls.Add(this.button37);
			this.tabPage10.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage10.Name = "tabPage10";
			this.tabPage10.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage10.Size = new global::System.Drawing.Size(620, 398);
			this.tabPage10.TabIndex = 9;
			this.tabPage10.Text = "ExSetting";
			this.tabPage10.UseVisualStyleBackColor = true;
			this.button54.Location = new global::System.Drawing.Point(215, 343);
			this.button54.Name = "button54";
			this.button54.Size = new global::System.Drawing.Size(98, 34);
			this.button54.TabIndex = 18;
			this.button54.Text = "STOP ALL";
			this.button54.UseVisualStyleBackColor = true;
			this.button54.Click += new global::System.EventHandler(this.button54_Click);
			this.checkBox16.AutoSize = true;
			this.checkBox16.Checked = true;
			this.checkBox16.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.checkBox16.Location = new global::System.Drawing.Point(478, 352);
			this.checkBox16.Name = "checkBox16";
			this.checkBox16.Size = new global::System.Drawing.Size(114, 17);
			this.checkBox16.TabIndex = 17;
			this.checkBox16.Text = "Phạm Vi Máy Tính";
			this.checkBox16.UseVisualStyleBackColor = true;
			this.checkBox16.Visible = false;
			this.button53.Location = new global::System.Drawing.Point(358, 342);
			this.button53.Name = "button53";
			this.button53.Size = new global::System.Drawing.Size(101, 34);
			this.button53.TabIndex = 16;
			this.button53.Text = "RESET ALL";
			this.button53.UseVisualStyleBackColor = true;
			this.button53.Click += new global::System.EventHandler(this.button53_Click);
			this.button52.Location = new global::System.Drawing.Point(59, 342);
			this.button52.Name = "button52";
			this.button52.Size = new global::System.Drawing.Size(95, 35);
			this.button52.TabIndex = 15;
			this.button52.Text = "START ALL";
			this.button52.UseVisualStyleBackColor = true;
			this.button52.Click += new global::System.EventHandler(this.button52_Click);
			this.button51.Location = new global::System.Drawing.Point(39, 289);
			this.button51.Name = "button51";
			this.button51.Size = new global::System.Drawing.Size(117, 23);
			this.button51.TabIndex = 14;
			this.button51.Text = "Set Other Setting";
			this.button51.UseVisualStyleBackColor = true;
			this.button51.Click += new global::System.EventHandler(this.button51_Click);
			this.button50.Location = new global::System.Drawing.Point(39, 229);
			this.button50.Name = "button50";
			this.button50.Size = new global::System.Drawing.Size(117, 23);
			this.button50.TabIndex = 13;
			this.button50.Text = "Set Vip72";
			this.button50.UseVisualStyleBackColor = true;
			this.button50.Click += new global::System.EventHandler(this.button50_Click);
			this.button49.Location = new global::System.Drawing.Point(39, 170);
			this.button49.Name = "button49";
			this.button49.Size = new global::System.Drawing.Size(117, 23);
			this.button49.TabIndex = 12;
			this.button49.Text = "Set SSH";
			this.button49.UseVisualStyleBackColor = true;
			this.button49.Click += new global::System.EventHandler(this.button49_Click);
			this.button48.Location = new global::System.Drawing.Point(39, 118);
			this.button48.Name = "button48";
			this.button48.Size = new global::System.Drawing.Size(117, 23);
			this.button48.TabIndex = 11;
			this.button48.Text = "Set Offer List";
			this.button48.UseVisualStyleBackColor = true;
			this.button48.Click += new global::System.EventHandler(this.button48_Click);
			this.button47.Location = new global::System.Drawing.Point(39, 63);
			this.button47.Name = "button47";
			this.button47.Size = new global::System.Drawing.Size(117, 23);
			this.button47.TabIndex = 10;
			this.button47.Text = "Set All Setting";
			this.button47.UseVisualStyleBackColor = true;
			this.button47.Click += new global::System.EventHandler(this.button47_Click);
			this.button46.Location = new global::System.Drawing.Point(431, 288);
			this.button46.Name = "button46";
			this.button46.Size = new global::System.Drawing.Size(116, 23);
			this.button46.TabIndex = 9;
			this.button46.Text = "Paste Other Setting";
			this.button46.UseVisualStyleBackColor = true;
			this.button46.Click += new global::System.EventHandler(this.button46_Click);
			this.button45.Location = new global::System.Drawing.Point(431, 228);
			this.button45.Name = "button45";
			this.button45.Size = new global::System.Drawing.Size(116, 23);
			this.button45.TabIndex = 8;
			this.button45.Text = "Paste Vip72";
			this.button45.UseVisualStyleBackColor = true;
			this.button45.Click += new global::System.EventHandler(this.button45_Click);
			this.button44.Location = new global::System.Drawing.Point(431, 169);
			this.button44.Name = "button44";
			this.button44.Size = new global::System.Drawing.Size(116, 23);
			this.button44.TabIndex = 7;
			this.button44.Text = "Paste SSH";
			this.button44.UseVisualStyleBackColor = true;
			this.button44.Click += new global::System.EventHandler(this.button44_Click);
			this.button43.Location = new global::System.Drawing.Point(431, 118);
			this.button43.Name = "button43";
			this.button43.Size = new global::System.Drawing.Size(116, 23);
			this.button43.TabIndex = 6;
			this.button43.Text = "Paste Offer List";
			this.button43.UseVisualStyleBackColor = true;
			this.button43.Click += new global::System.EventHandler(this.button43_Click);
			this.button42.Location = new global::System.Drawing.Point(431, 63);
			this.button42.Name = "button42";
			this.button42.Size = new global::System.Drawing.Size(116, 23);
			this.button42.TabIndex = 5;
			this.button42.Text = "Paste All Setting";
			this.button42.UseVisualStyleBackColor = true;
			this.button42.Click += new global::System.EventHandler(this.button42_Click);
			this.button41.Location = new global::System.Drawing.Point(234, 289);
			this.button41.Name = "button41";
			this.button41.Size = new global::System.Drawing.Size(111, 23);
			this.button41.TabIndex = 4;
			this.button41.Text = "Copy Other Setting";
			this.button41.UseVisualStyleBackColor = true;
			this.button41.Click += new global::System.EventHandler(this.button41_Click);
			this.button40.Location = new global::System.Drawing.Point(234, 229);
			this.button40.Name = "button40";
			this.button40.Size = new global::System.Drawing.Size(111, 23);
			this.button40.TabIndex = 3;
			this.button40.Text = "Copy Vip72";
			this.button40.UseVisualStyleBackColor = true;
			this.button40.Click += new global::System.EventHandler(this.button40_Click);
			this.button39.Location = new global::System.Drawing.Point(234, 170);
			this.button39.Name = "button39";
			this.button39.Size = new global::System.Drawing.Size(111, 23);
			this.button39.TabIndex = 2;
			this.button39.Text = "Copy SSH";
			this.button39.UseVisualStyleBackColor = true;
			this.button39.Click += new global::System.EventHandler(this.button39_Click);
			this.button38.Location = new global::System.Drawing.Point(234, 118);
			this.button38.Name = "button38";
			this.button38.Size = new global::System.Drawing.Size(111, 23);
			this.button38.TabIndex = 1;
			this.button38.Text = "Copy Offer List";
			this.button38.UseVisualStyleBackColor = true;
			this.button38.Click += new global::System.EventHandler(this.button38_Click);
			this.button37.Location = new global::System.Drawing.Point(234, 63);
			this.button37.Name = "button37";
			this.button37.Size = new global::System.Drawing.Size(111, 23);
			this.button37.TabIndex = 0;
			this.button37.Text = "Copy All Setting";
			this.button37.UseVisualStyleBackColor = true;
			this.button37.Click += new global::System.EventHandler(this.button37_Click);
			this.tabPage9.Controls.Add(this.groupBox8);
			this.tabPage9.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage9.Name = "tabPage9";
			this.tabPage9.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage9.Size = new global::System.Drawing.Size(620, 398);
			this.tabPage9.TabIndex = 8;
			this.tabPage9.Text = "Nạp Code";
			this.tabPage9.UseVisualStyleBackColor = true;
			this.groupBox8.Controls.Add(this.napcodestt);
			this.groupBox8.Controls.Add(this.deviceseri);
			this.groupBox8.Controls.Add(this.button36);
			this.groupBox8.Controls.Add(this.label36);
			this.groupBox8.Controls.Add(this.code);
			this.groupBox8.Controls.Add(this.label37);
			this.groupBox8.Location = new global::System.Drawing.Point(110, 80);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new global::System.Drawing.Size(404, 207);
			this.groupBox8.TabIndex = 5;
			this.groupBox8.TabStop = false;
			this.napcodestt.AutoSize = true;
			this.napcodestt.Location = new global::System.Drawing.Point(63, 179);
			this.napcodestt.Name = "napcodestt";
			this.napcodestt.Size = new global::System.Drawing.Size(0, 13);
			this.napcodestt.TabIndex = 5;
			this.deviceseri.Location = new global::System.Drawing.Point(138, 68);
			this.deviceseri.Name = "deviceseri";
			this.deviceseri.Size = new global::System.Drawing.Size(192, 20);
			this.deviceseri.TabIndex = 3;
			this.button36.Location = new global::System.Drawing.Point(154, 112);
			this.button36.Name = "button36";
			this.button36.Size = new global::System.Drawing.Size(96, 33);
			this.button36.TabIndex = 4;
			this.button36.Text = "Nạp Code";
			this.button36.UseVisualStyleBackColor = true;
			this.button36.Click += new global::System.EventHandler(this.button36_Click);
			this.label36.AutoSize = true;
			this.label36.Location = new global::System.Drawing.Point(56, 33);
			this.label36.Name = "label36";
			this.label36.Size = new global::System.Drawing.Size(35, 13);
			this.label36.TabIndex = 0;
			this.label36.Text = "Code:";
			this.code.Location = new global::System.Drawing.Point(138, 30);
			this.code.Name = "code";
			this.code.Size = new global::System.Drawing.Size(192, 20);
			this.code.TabIndex = 1;
			this.label37.AutoSize = true;
			this.label37.Location = new global::System.Drawing.Point(56, 71);
			this.label37.Name = "label37";
			this.label37.Size = new global::System.Drawing.Size(73, 13);
			this.label37.TabIndex = 2;
			this.label37.Text = "Device Serial:";
			this.Script.Controls.Add(this.textBox9);
			this.Script.Controls.Add(this.label33);
			this.Script.Controls.Add(this.button34);
			this.Script.Controls.Add(this.button33);
			this.Script.Controls.Add(this.button32);
			this.Script.Controls.Add(this.listView7);
			this.Script.Controls.Add(this.textBox6);
			this.Script.Controls.Add(this.listView6);
			this.Script.Location = new global::System.Drawing.Point(4, 22);
			this.Script.Name = "Script";
			this.Script.Padding = new global::System.Windows.Forms.Padding(3);
			this.Script.Size = new global::System.Drawing.Size(620, 398);
			this.Script.TabIndex = 7;
			this.Script.Text = "Script";
			this.Script.UseVisualStyleBackColor = true;
			this.textBox9.Enabled = false;
			this.textBox9.Location = new global::System.Drawing.Point(435, 22);
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new global::System.Drawing.Size(117, 20);
			this.textBox9.TabIndex = 9;
			this.textBox9.TextChanged += new global::System.EventHandler(this.textBox9_TextChanged);
			this.label33.AutoSize = true;
			this.label33.Location = new global::System.Drawing.Point(359, 25);
			this.label33.Name = "label33";
			this.label33.Size = new global::System.Drawing.Size(68, 13);
			this.label33.TabIndex = 8;
			this.label33.Text = "Script Name:";
			this.button34.Enabled = false;
			this.button34.Location = new global::System.Drawing.Point(177, 325);
			this.button34.Name = "button34";
			this.button34.Size = new global::System.Drawing.Size(75, 23);
			this.button34.TabIndex = 7;
			this.button34.Text = "Add Script";
			this.button34.UseVisualStyleBackColor = true;
			this.button34.Click += new global::System.EventHandler(this.button34_Click);
			this.button33.Enabled = false;
			this.button33.Location = new global::System.Drawing.Point(39, 325);
			this.button33.Name = "button33";
			this.button33.Size = new global::System.Drawing.Size(75, 23);
			this.button33.TabIndex = 6;
			this.button33.Text = "Add Slot";
			this.button33.UseVisualStyleBackColor = true;
			this.button33.Click += new global::System.EventHandler(this.button33_Click);
			this.button32.Enabled = false;
			this.button32.Location = new global::System.Drawing.Point(425, 325);
			this.button32.Name = "button32";
			this.button32.Size = new global::System.Drawing.Size(75, 23);
			this.button32.TabIndex = 5;
			this.button32.Text = "Test Script";
			this.button32.UseVisualStyleBackColor = true;
			this.button32.Click += new global::System.EventHandler(this.button32_Click);
			this.listView7.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.columnHeader14
			});
			this.listView7.Enabled = false;
			this.listView7.Items.AddRange(new global::System.Windows.Forms.ListViewItem[]
			{
				listViewItem
			});
			this.listView7.Location = new global::System.Drawing.Point(22, 22);
			this.listView7.Name = "listView7";
			this.listView7.Size = new global::System.Drawing.Size(103, 297);
			this.listView7.TabIndex = 2;
			this.listView7.UseCompatibleStateImageBehavior = false;
			this.listView7.View = global::System.Windows.Forms.View.Details;
			this.listView7.SelectedIndexChanged += new global::System.EventHandler(this.listView7_SelectedIndexChanged);
			this.listView7.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.listView7_KeyDown);
			this.listView7.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.listView7_MouseClick);
			this.listView7.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.listView7_MouseDown);
			this.listView7.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.listView7_MouseUp);
			this.columnHeader14.Text = "Slot";
			this.columnHeader14.Width = 89;
			this.textBox6.AutoCompleteCustomSource.AddRange(new string[]
			{
				"wait",
				"randomtext",
				"randomnumber",
				"send",
				"randomemail",
				"randomfirstname",
				"randomlastname",
				"waitrandom",
				"touch",
				"swipe",
				"close",
				"open"
			});
			this.textBox6.AutoCompleteMode = global::System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.textBox6.AutoCompleteSource = global::System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.textBox6.Enabled = false;
			this.textBox6.Location = new global::System.Drawing.Point(360, 55);
			this.textBox6.Multiline = true;
			this.textBox6.Name = "textBox6";
			this.textBox6.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
			this.textBox6.Size = new global::System.Drawing.Size(204, 264);
			this.textBox6.TabIndex = 1;
			this.textBox6.TextChanged += new global::System.EventHandler(this.textBox6_TextChanged);
			this.listView6.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.columnHeader13
			});
			this.listView6.Enabled = false;
			this.listView6.Location = new global::System.Drawing.Point(150, 22);
			this.listView6.Name = "listView6";
			this.listView6.Size = new global::System.Drawing.Size(140, 297);
			this.listView6.TabIndex = 0;
			this.listView6.UseCompatibleStateImageBehavior = false;
			this.listView6.View = global::System.Windows.Forms.View.Details;
			this.listView6.SelectedIndexChanged += new global::System.EventHandler(this.listView6_SelectedIndexChanged);
			this.listView6.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.listView6_KeyDown);
			this.listView6.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.listView6_MouseClick);
			this.listView6.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.listView6_MouseDown);
			this.listView6.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.listView6_MouseUp);
			this.columnHeader13.Text = "Script";
			this.columnHeader13.Width = 132;
			this.tabPage6.Controls.Add(this.textBox5);
			this.tabPage6.Controls.Add(this.listView5);
			this.tabPage6.Controls.Add(this.groupBox6);
			this.tabPage6.Controls.Add(this.groupBox7);
			this.tabPage6.Controls.Add(this.groupBox9);
			this.tabPage6.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage6.Size = new global::System.Drawing.Size(620, 398);
			this.tabPage6.TabIndex = 6;
			this.tabPage6.Text = "Setting";
			this.tabPage6.UseVisualStyleBackColor = true;
			this.tabPage6.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.tabPage6_MouseClick);
			this.textBox5.Location = new global::System.Drawing.Point(403, 48);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new global::System.Drawing.Size(193, 20);
			this.textBox5.TabIndex = 16;
			this.textBox5.Visible = false;
			this.textBox5.TextChanged += new global::System.EventHandler(this.textBox5_TextChanged);
			this.listView5.GridLines = true;
			this.listView5.Location = new global::System.Drawing.Point(403, 68);
			this.listView5.Name = "listView5";
			this.listView5.Size = new global::System.Drawing.Size(193, 150);
			this.listView5.TabIndex = 15;
			this.listView5.UseCompatibleStateImageBehavior = false;
			this.listView5.View = global::System.Windows.Forms.View.Tile;
			this.listView5.Visible = false;
			this.listView5.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.listView5_MouseClick);
			this.listView5.MouseDoubleClick += new global::System.Windows.Forms.MouseEventHandler(this.listView5_MouseDoubleClick);
			this.groupBox6.Controls.Add(this.checkBox20);
			this.groupBox6.Controls.Add(this.longtitude);
			this.groupBox6.Controls.Add(this.ltimezone);
			this.groupBox6.Controls.Add(this.checkBox19);
			this.groupBox6.Controls.Add(this.checkBox13);
			this.groupBox6.Controls.Add(this.label41);
			this.groupBox6.Controls.Add(this.checkBox5);
			this.groupBox6.Controls.Add(this.label40);
			this.groupBox6.Controls.Add(this.checkBox9);
			this.groupBox6.Controls.Add(this.latitude);
			this.groupBox6.Controls.Add(this.carrierBox);
			this.groupBox6.Controls.Add(this.fakelang);
			this.groupBox6.Controls.Add(this.comboBox2);
			this.groupBox6.Controls.Add(this.fakeregion);
			this.groupBox6.Controls.Add(this.comboBox1);
			this.groupBox6.Location = new global::System.Drawing.Point(22, 15);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new global::System.Drawing.Size(578, 141);
			this.groupBox6.TabIndex = 14;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Fake Location Setting";
			this.checkBox20.AutoSize = true;
			this.checkBox20.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox20.ForeColor = global::System.Drawing.SystemColors.Highlight;
			this.checkBox20.Location = new global::System.Drawing.Point(9, 16);
			this.checkBox20.Name = "checkBox20";
			this.checkBox20.Size = new global::System.Drawing.Size(227, 19);
			this.checkBox20.TabIndex = 26;
			this.checkBox20.Text = "Tự Động Fake Location Theo IP";
			this.checkBox20.UseVisualStyleBackColor = true;
			this.checkBox20.CheckedChanged += new global::System.EventHandler(this.checkBox20_CheckedChanged);
			this.longtitude.DecimalPlaces = 6;
			this.longtitude.Location = new global::System.Drawing.Point(338, 106);
			global::System.Windows.Forms.NumericUpDown arg_3D78_0 = this.longtitude;
			int[] expr_3D6B = new int[4];
			expr_3D6B[0] = 180;
			arg_3D78_0.Maximum = new decimal(expr_3D6B);
			this.longtitude.Minimum = new decimal(new int[]
			{
				180,
				0,
				0,
				-2147483648
			});
			this.longtitude.Name = "longtitude";
			this.longtitude.Size = new global::System.Drawing.Size(67, 20);
			this.longtitude.TabIndex = 25;
			this.longtitude.ValueChanged += new global::System.EventHandler(this.longtitude_ValueChanged);
			this.ltimezone.AutoSize = true;
			this.ltimezone.Location = new global::System.Drawing.Point(381, 16);
			this.ltimezone.Name = "ltimezone";
			this.ltimezone.Size = new global::System.Drawing.Size(96, 13);
			this.ltimezone.TabIndex = 14;
			this.ltimezone.Text = "Asia/Ho_Chi_Minh";
			this.ltimezone.TextChanged += new global::System.EventHandler(this.ltimezone_TextChanged);
			this.ltimezone.Click += new global::System.EventHandler(this.ltimezone_Click);
			this.checkBox19.AutoSize = true;
			this.checkBox19.Location = new global::System.Drawing.Point(9, 106);
			this.checkBox19.Name = "checkBox19";
			this.checkBox19.Size = new global::System.Drawing.Size(75, 17);
			this.checkBox19.TabIndex = 21;
			this.checkBox19.Text = "Fake GPS";
			this.checkBox19.UseVisualStyleBackColor = true;
			this.checkBox19.CheckedChanged += new global::System.EventHandler(this.checkBox19_CheckedChanged);
			this.checkBox13.AutoSize = true;
			this.checkBox13.Checked = true;
			this.checkBox13.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.checkBox13.Location = new global::System.Drawing.Point(9, 47);
			this.checkBox13.Name = "checkBox13";
			this.checkBox13.Size = new global::System.Drawing.Size(83, 17);
			this.checkBox13.TabIndex = 12;
			this.checkBox13.Text = "Fake Carrier";
			this.checkBox13.UseVisualStyleBackColor = true;
			this.checkBox13.CheckedChanged += new global::System.EventHandler(this.checkBox13_CheckedChanged);
			this.label41.AutoSize = true;
			this.label41.Location = new global::System.Drawing.Point(270, 108);
			this.label41.Name = "label41";
			this.label41.Size = new global::System.Drawing.Size(57, 13);
			this.label41.TabIndex = 24;
			this.label41.Text = "Longitude:";
			this.checkBox5.AutoSize = true;
			this.checkBox5.Location = new global::System.Drawing.Point(277, 15);
			this.checkBox5.Name = "checkBox5";
			this.checkBox5.Size = new global::System.Drawing.Size(101, 17);
			this.checkBox5.TabIndex = 13;
			this.checkBox5.Text = "Fake TimeZone";
			this.checkBox5.UseVisualStyleBackColor = true;
			this.checkBox5.CheckedChanged += new global::System.EventHandler(this.checkBox5_CheckedChanged);
			this.label40.AutoSize = true;
			this.label40.Location = new global::System.Drawing.Point(121, 108);
			this.label40.Name = "label40";
			this.label40.Size = new global::System.Drawing.Size(48, 13);
			this.label40.TabIndex = 22;
			this.label40.Text = "Latitude:";
			this.checkBox9.AutoSize = true;
			this.checkBox9.Location = new global::System.Drawing.Point(130, 47);
			this.checkBox9.Name = "checkBox9";
			this.checkBox9.Size = new global::System.Drawing.Size(100, 17);
			this.checkBox9.TabIndex = 17;
			this.checkBox9.Text = "Custom Country";
			this.checkBox9.UseVisualStyleBackColor = true;
			this.checkBox9.CheckedChanged += new global::System.EventHandler(this.checkBox9_CheckedChanged);
			this.latitude.DecimalPlaces = 6;
			this.latitude.Location = new global::System.Drawing.Point(173, 106);
			global::System.Windows.Forms.NumericUpDown arg_41E7_0 = this.latitude;
			int[] expr_41DD = new int[4];
			expr_41DD[0] = 90;
			arg_41E7_0.Maximum = new decimal(expr_41DD);
			this.latitude.Minimum = new decimal(new int[]
			{
				90,
				0,
				0,
				-2147483648
			});
			this.latitude.Name = "latitude";
			this.latitude.Size = new global::System.Drawing.Size(74, 20);
			this.latitude.TabIndex = 23;
			this.latitude.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.latitude.ValueChanged += new global::System.EventHandler(this.latitude_ValueChanged);
			this.carrierBox.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.carrierBox.Enabled = false;
			this.carrierBox.FormattingEnabled = true;
			this.carrierBox.Location = new global::System.Drawing.Point(262, 45);
			this.carrierBox.Name = "carrierBox";
			this.carrierBox.Size = new global::System.Drawing.Size(194, 21);
			this.carrierBox.Sorted = true;
			this.carrierBox.TabIndex = 18;
			this.carrierBox.SelectedIndexChanged += new global::System.EventHandler(this.carrierBox_SelectedIndexChanged);
			this.fakelang.AutoSize = true;
			this.fakelang.Location = new global::System.Drawing.Point(9, 77);
			this.fakelang.Name = "fakelang";
			this.fakelang.Size = new global::System.Drawing.Size(101, 17);
			this.fakelang.TabIndex = 5;
			this.fakelang.Text = "Fake Language";
			this.fakelang.UseVisualStyleBackColor = true;
			this.fakelang.CheckedChanged += new global::System.EventHandler(this.fakelang_CheckedChanged);
			this.comboBox2.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox2.Enabled = false;
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Location = new global::System.Drawing.Point(380, 73);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new global::System.Drawing.Size(118, 21);
			this.comboBox2.Sorted = true;
			this.comboBox2.TabIndex = 8;
			this.comboBox2.SelectedIndexChanged += new global::System.EventHandler(this.comboBox2_SelectedIndexChanged);
			this.fakeregion.AutoSize = true;
			this.fakeregion.Location = new global::System.Drawing.Point(287, 77);
			this.fakeregion.Name = "fakeregion";
			this.fakeregion.Size = new global::System.Drawing.Size(87, 17);
			this.fakeregion.TabIndex = 7;
			this.fakeregion.Text = "Fake Region";
			this.fakeregion.UseVisualStyleBackColor = true;
			this.fakeregion.CheckedChanged += new global::System.EventHandler(this.fakeregion_CheckedChanged);
			this.comboBox1.AutoCompleteMode = global::System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.comboBox1.AutoCompleteSource = global::System.Windows.Forms.AutoCompleteSource.ListItems;
			this.comboBox1.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.Enabled = false;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new global::System.Drawing.Point(143, 73);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new global::System.Drawing.Size(108, 21);
			this.comboBox1.Sorted = true;
			this.comboBox1.TabIndex = 6;
			this.comboBox1.SelectedIndexChanged += new global::System.EventHandler(this.comboBox1_SelectedIndexChanged);
			this.comboBox1.TextChanged += new global::System.EventHandler(this.comboBox1_TextChanged);
			this.comboBox1.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.comboBox1_KeyPress);
			this.groupBox7.Controls.Add(this.label63);
			this.groupBox7.Controls.Add(this.label43);
			this.groupBox7.Controls.Add(this.numericUpDown10);
			this.groupBox7.Controls.Add(this.label31);
			this.groupBox7.Controls.Add(this.label32);
			this.groupBox7.Controls.Add(this.numericUpDown5);
			this.groupBox7.Controls.Add(this.checkBox4);
			this.groupBox7.Controls.Add(this.numericUpDown4);
			this.groupBox7.Controls.Add(this.label30);
			this.groupBox7.Location = new global::System.Drawing.Point(22, 276);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new global::System.Drawing.Size(578, 116);
			this.groupBox7.TabIndex = 13;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Tool Setting";
			this.groupBox7.Enter += new global::System.EventHandler(this.groupBox7_Enter);
			this.label63.AutoSize = true;
			this.label63.Location = new global::System.Drawing.Point(214, 48);
			this.label63.Name = "label63";
			this.label63.Size = new global::System.Drawing.Size(28, 13);
			this.label63.TabIndex = 9;
			this.label63.Text = "Giây";
			this.label43.AutoSize = true;
			this.label43.Location = new global::System.Drawing.Point(6, 47);
			this.label43.Name = "label43";
			this.label43.Size = new global::System.Drawing.Size(128, 13);
			this.label43.TabIndex = 8;
			this.label43.Text = "Thời gian wipe App tối đa";
			this.numericUpDown10.Location = new global::System.Drawing.Point(144, 45);
			global::System.Windows.Forms.NumericUpDown arg_47F1_0 = this.numericUpDown10;
			int[] expr_47E4 = new int[4];
			expr_47E4[0] = 10000;
			arg_47F1_0.Maximum = new decimal(expr_47E4);
			this.numericUpDown10.Name = "numericUpDown10";
			this.numericUpDown10.Size = new global::System.Drawing.Size(55, 20);
			this.numericUpDown10.TabIndex = 7;
			global::System.Windows.Forms.NumericUpDown arg_4840_0 = this.numericUpDown10;
			int[] expr_4836 = new int[4];
			expr_4836[0] = 120;
			arg_4840_0.Value = new decimal(expr_4836);
			this.numericUpDown10.ValueChanged += new global::System.EventHandler(this.numericUpDown10_ValueChanged);
			this.label31.AutoSize = true;
			this.label31.Location = new global::System.Drawing.Point(240, 21);
			this.label31.Name = "label31";
			this.label31.Size = new global::System.Drawing.Size(49, 13);
			this.label31.TabIndex = 2;
			this.label31.Text = "Seconds";
			this.label32.AutoSize = true;
			this.label32.Location = new global::System.Drawing.Point(384, 77);
			this.label32.Name = "label32";
			this.label32.Size = new global::System.Drawing.Size(25, 13);
			this.label32.TabIndex = 5;
			this.label32.Text = "Lần";
			this.numericUpDown5.Location = new global::System.Drawing.Point(305, 70);
			this.numericUpDown5.Name = "numericUpDown5";
			this.numericUpDown5.Size = new global::System.Drawing.Size(55, 20);
			this.numericUpDown5.TabIndex = 4;
			global::System.Windows.Forms.NumericUpDown arg_4990_0 = this.numericUpDown5;
			int[] expr_4987 = new int[4];
			expr_4987[0] = 4;
			arg_4990_0.Value = new decimal(expr_4987);
			this.numericUpDown5.ValueChanged += new global::System.EventHandler(this.numericUpDown5_ValueChanged);
			this.checkBox4.AutoSize = true;
			this.checkBox4.Location = new global::System.Drawing.Point(9, 73);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new global::System.Drawing.Size(275, 17);
			this.checkBox4.TabIndex = 3;
			this.checkBox4.Text = "Tự động bỏ tick offer nếu offer không vào AppStore ";
			this.checkBox4.UseVisualStyleBackColor = true;
			this.checkBox4.CheckedChanged += new global::System.EventHandler(this.checkBox4_CheckedChanged);
			this.numericUpDown4.Location = new global::System.Drawing.Point(181, 19);
			global::System.Windows.Forms.NumericUpDown arg_4A6D_0 = this.numericUpDown4;
			int[] expr_4A60 = new int[4];
			expr_4A60[0] = 1000;
			arg_4A6D_0.Maximum = new decimal(expr_4A60);
			this.numericUpDown4.Name = "numericUpDown4";
			this.numericUpDown4.Size = new global::System.Drawing.Size(47, 20);
			this.numericUpDown4.TabIndex = 1;
			global::System.Windows.Forms.NumericUpDown arg_4ABC_0 = this.numericUpDown4;
			int[] expr_4AB2 = new int[4];
			expr_4AB2[0] = 60;
			arg_4ABC_0.Value = new decimal(expr_4AB2);
			this.numericUpDown4.ValueChanged += new global::System.EventHandler(this.numericUpDown4_ValueChanged);
			this.label30.AutoSize = true;
			this.label30.Location = new global::System.Drawing.Point(4, 21);
			this.label30.Name = "label30";
			this.label30.Size = new global::System.Drawing.Size(155, 13);
			this.label30.TabIndex = 0;
			this.label30.Text = "Thời gian load Offer URL tối đa";
			this.groupBox9.Controls.Add(this.fakeversion);
			this.groupBox9.Controls.Add(this.iphone);
			this.groupBox9.Controls.Add(this.ipad);
			this.groupBox9.Controls.Add(this.ipod);
			this.groupBox9.Controls.Add(this.checkBox11);
			this.groupBox9.Controls.Add(this.fakemodel);
			this.groupBox9.Controls.Add(this.fileofname);
			this.groupBox9.Controls.Add(this.fakedevice);
			this.groupBox9.Controls.Add(this.checkBox15);
			this.groupBox9.Controls.Add(this.checkBox14);
			this.groupBox9.Location = new global::System.Drawing.Point(22, 171);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new global::System.Drawing.Size(578, 99);
			this.groupBox9.TabIndex = 15;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Fake Device Setting";
			this.fakeversion.AutoSize = true;
			this.fakeversion.Checked = true;
			this.fakeversion.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.fakeversion.Location = new global::System.Drawing.Point(9, 49);
			this.fakeversion.Name = "fakeversion";
			this.fakeversion.Size = new global::System.Drawing.Size(125, 17);
			this.fakeversion.TabIndex = 11;
			this.fakeversion.Text = "Fake Device Version";
			this.fakeversion.UseVisualStyleBackColor = true;
			this.fakeversion.CheckedChanged += new global::System.EventHandler(this.fakeversion_CheckedChanged);
			this.iphone.AutoSize = true;
			this.iphone.Checked = true;
			this.iphone.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.iphone.Location = new global::System.Drawing.Point(276, 77);
			this.iphone.Name = "iphone";
			this.iphone.Size = new global::System.Drawing.Size(59, 17);
			this.iphone.TabIndex = 3;
			this.iphone.Text = "iPhone";
			this.iphone.UseVisualStyleBackColor = true;
			this.iphone.CheckedChanged += new global::System.EventHandler(this.iphone_CheckedChanged);
			this.ipad.AutoSize = true;
			this.ipad.Checked = true;
			this.ipad.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.ipad.Location = new global::System.Drawing.Point(183, 77);
			this.ipad.Name = "ipad";
			this.ipad.Size = new global::System.Drawing.Size(47, 17);
			this.ipad.TabIndex = 2;
			this.ipad.Text = "iPad";
			this.ipad.UseVisualStyleBackColor = true;
			this.ipad.CheckedChanged += new global::System.EventHandler(this.ipad_CheckedChanged);
			this.ipod.AutoSize = true;
			this.ipod.Location = new global::System.Drawing.Point(366, 77);
			this.ipod.Name = "ipod";
			this.ipod.Size = new global::System.Drawing.Size(77, 17);
			this.ipod.TabIndex = 4;
			this.ipod.Text = "iPod touch";
			this.ipod.UseVisualStyleBackColor = true;
			this.ipod.CheckedChanged += new global::System.EventHandler(this.ipod_CheckedChanged);
			this.checkBox11.AutoSize = true;
			this.checkBox11.Location = new global::System.Drawing.Point(183, 18);
			this.checkBox11.Name = "checkBox11";
			this.checkBox11.Size = new global::System.Drawing.Size(68, 17);
			this.checkBox11.TabIndex = 9;
			this.checkBox11.Text = "From file:";
			this.checkBox11.UseVisualStyleBackColor = true;
			this.checkBox11.CheckedChanged += new global::System.EventHandler(this.checkBox11_CheckedChanged);
			this.fakemodel.AutoSize = true;
			this.fakemodel.Checked = true;
			this.fakemodel.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.fakemodel.Location = new global::System.Drawing.Point(9, 77);
			this.fakemodel.Name = "fakemodel";
			this.fakemodel.Size = new global::System.Drawing.Size(119, 17);
			this.fakemodel.TabIndex = 1;
			this.fakemodel.Text = "Fake Device Model";
			this.fakemodel.UseVisualStyleBackColor = true;
			this.fakemodel.CheckedChanged += new global::System.EventHandler(this.fakemodel_CheckedChanged);
			this.fileofname.AutoSize = true;
			this.fileofname.Location = new global::System.Drawing.Point(273, 17);
			this.fileofname.Name = "fileofname";
			this.fileofname.Size = new global::System.Drawing.Size(0, 13);
			this.fileofname.TabIndex = 10;
			this.fakedevice.AutoSize = true;
			this.fakedevice.Checked = true;
			this.fakedevice.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.fakedevice.Location = new global::System.Drawing.Point(9, 19);
			this.fakedevice.Name = "fakedevice";
			this.fakedevice.Size = new global::System.Drawing.Size(118, 17);
			this.fakedevice.TabIndex = 0;
			this.fakedevice.Text = "Fake Device Name";
			this.fakedevice.UseVisualStyleBackColor = true;
			this.fakedevice.CheckedChanged += new global::System.EventHandler(this.fakedevice_CheckedChanged);
			this.checkBox15.AutoSize = true;
			this.checkBox15.Checked = true;
			this.checkBox15.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.checkBox15.Location = new global::System.Drawing.Point(276, 49);
			this.checkBox15.Name = "checkBox15";
			this.checkBox15.Size = new global::System.Drawing.Size(52, 17);
			this.checkBox15.TabIndex = 20;
			this.checkBox15.Text = "iOS 9";
			this.checkBox15.UseVisualStyleBackColor = true;
			this.checkBox15.CheckedChanged += new global::System.EventHandler(this.checkBox15_CheckedChanged);
			this.checkBox14.AutoSize = true;
			this.checkBox14.Checked = true;
			this.checkBox14.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.checkBox14.Location = new global::System.Drawing.Point(183, 49);
			this.checkBox14.Name = "checkBox14";
			this.checkBox14.Size = new global::System.Drawing.Size(52, 17);
			this.checkBox14.TabIndex = 19;
			this.checkBox14.Text = "iOS 10";
			this.checkBox14.UseVisualStyleBackColor = true;
			this.checkBox14.CheckedChanged += new global::System.EventHandler(this.checkBox14_CheckedChanged);
			this.tabPage8.Controls.Add(this.pausescript);
			this.tabPage8.Controls.Add(this.textBox2);
			this.tabPage8.Controls.Add(this.button64);
			this.tabPage8.Controls.Add(this.button35);
			this.tabPage8.Controls.Add(this.button30);
			this.tabPage8.Controls.Add(this.trackBar1);
			this.tabPage8.Controls.Add(this.groupBox4);
			this.tabPage8.Controls.Add(this.groupBox3);
			this.tabPage8.Controls.Add(this.button18);
			this.tabPage8.Controls.Add(this.groupBox5);
			this.tabPage8.Controls.Add(this.pictureBox1);
			this.tabPage8.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage8.Name = "tabPage8";
			this.tabPage8.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage8.Size = new global::System.Drawing.Size(620, 398);
			this.tabPage8.TabIndex = 4;
			this.tabPage8.Text = "Support";
			this.tabPage8.UseVisualStyleBackColor = true;
			this.tabPage8.Click += new global::System.EventHandler(this.tabPage8_Click);
			this.pausescript.BackgroundImage = global::AutoLead.Properties.Resources.red_stop_playback;
			this.pausescript.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Stretch;
			this.pausescript.Enabled = false;
			this.pausescript.Location = new global::System.Drawing.Point(82, 307);
			this.pausescript.Name = "pausescript";
			this.pausescript.Size = new global::System.Drawing.Size(31, 29);
			this.pausescript.TabIndex = 26;
			this.pausescript.UseVisualStyleBackColor = true;
			this.pausescript.Click += new global::System.EventHandler(this.pausescript_Click);
			this.textBox2.Location = new global::System.Drawing.Point(119, 271);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new global::System.Drawing.Size(220, 111);
			this.textBox2.TabIndex = 25;
			this.textBox2.Text = "";
			this.textBox2.TextChanged += new global::System.EventHandler(this.textBox2_TextChanged_1);
			this.button64.BackgroundImage = global::AutoLead.Properties.Resources.fast_delivery_3;
			this.button64.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Stretch;
			this.button64.Location = new global::System.Drawing.Point(341, 24);
			this.button64.Name = "button64";
			this.button64.Size = new global::System.Drawing.Size(40, 39);
			this.button64.TabIndex = 22;
			this.button64.UseVisualStyleBackColor = true;
			this.button64.Click += new global::System.EventHandler(this.button64_Click);
			this.button35.Location = new global::System.Drawing.Point(29, 351);
			this.button35.Name = "button35";
			this.button35.Size = new global::System.Drawing.Size(75, 23);
			this.button35.TabIndex = 20;
			this.button35.Text = "Mở rộng";
			this.button35.UseVisualStyleBackColor = true;
			this.button35.Click += new global::System.EventHandler(this.button35_Click);
			this.button30.Location = new global::System.Drawing.Point(377, 353);
			this.button30.Name = "button30";
			this.button30.Size = new global::System.Drawing.Size(82, 31);
			this.button30.TabIndex = 19;
			this.button30.Text = "Record";
			this.button30.UseVisualStyleBackColor = true;
			this.button30.Click += new global::System.EventHandler(this.button30_Click);
			this.trackBar1.Location = new global::System.Drawing.Point(468, 347);
			this.trackBar1.Maximum = 6;
			this.trackBar1.Minimum = 1;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new global::System.Drawing.Size(117, 45);
			this.trackBar1.TabIndex = 18;
			this.trackBar1.Value = 2;
			this.groupBox4.Controls.Add(this.button11);
			this.groupBox4.Controls.Add(this.textBox1);
			this.groupBox4.Location = new global::System.Drawing.Point(6, 101);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new global::System.Drawing.Size(340, 82);
			this.groupBox4.TabIndex = 16;
			this.groupBox4.TabStop = false;
			this.button11.Enabled = false;
			this.button11.Location = new global::System.Drawing.Point(138, 12);
			this.button11.Name = "button11";
			this.button11.Size = new global::System.Drawing.Size(75, 23);
			this.button11.TabIndex = 9;
			this.button11.Text = "Open URL";
			this.button11.UseVisualStyleBackColor = true;
			this.button11.Click += new global::System.EventHandler(this.button11_Click);
			this.textBox1.Location = new global::System.Drawing.Point(23, 45);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new global::System.Drawing.Size(293, 20);
			this.textBox1.TabIndex = 10;
			this.textBox1.TextChanged += new global::System.EventHandler(this.textBox1_TextChanged);
			this.groupBox3.Controls.Add(this.button26);
			this.groupBox3.Controls.Add(this.textBox7);
			this.groupBox3.Controls.Add(this.label18);
			this.groupBox3.Controls.Add(this.label19);
			this.groupBox3.Controls.Add(this.textBox8);
			this.groupBox3.Controls.Add(this.textBox3);
			this.groupBox3.Location = new global::System.Drawing.Point(11, 8);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new global::System.Drawing.Size(286, 92);
			this.groupBox3.TabIndex = 15;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Touch Support";
			this.button26.Location = new global::System.Drawing.Point(156, 19);
			this.button26.Name = "button26";
			this.button26.Size = new global::System.Drawing.Size(91, 23);
			this.button26.TabIndex = 7;
			this.button26.Text = "Enable Mouse";
			this.button26.UseVisualStyleBackColor = true;
			this.button26.Click += new global::System.EventHandler(this.button26_Click);
			this.textBox7.Location = new global::System.Drawing.Point(69, 19);
			this.textBox7.Name = "textBox7";
			this.textBox7.ReadOnly = true;
			this.textBox7.Size = new global::System.Drawing.Size(58, 20);
			this.textBox7.TabIndex = 2;
			this.label18.AutoSize = true;
			this.label18.Location = new global::System.Drawing.Point(6, 22);
			this.label18.Name = "label18";
			this.label18.Size = new global::System.Drawing.Size(57, 13);
			this.label18.TabIndex = 1;
			this.label18.Text = "Position X:";
			this.label19.AutoSize = true;
			this.label19.Location = new global::System.Drawing.Point(6, 59);
			this.label19.Name = "label19";
			this.label19.Size = new global::System.Drawing.Size(57, 13);
			this.label19.TabIndex = 3;
			this.label19.Text = "Position Y:";
			this.textBox8.Location = new global::System.Drawing.Point(69, 56);
			this.textBox8.Name = "textBox8";
			this.textBox8.ReadOnly = true;
			this.textBox8.Size = new global::System.Drawing.Size(58, 20);
			this.textBox8.TabIndex = 4;
			this.textBox3.Location = new global::System.Drawing.Point(156, 59);
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
			this.textBox3.Size = new global::System.Drawing.Size(91, 20);
			this.textBox3.TabIndex = 6;
			this.button18.BackgroundImage = global::AutoLead.Properties.Resources.Play_icon__1_;
			this.button18.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Stretch;
			this.button18.Enabled = false;
			this.button18.Location = new global::System.Drawing.Point(20, 286);
			this.button18.Name = "button18";
			this.button18.Size = new global::System.Drawing.Size(54, 50);
			this.button18.TabIndex = 13;
			this.button18.UseVisualStyleBackColor = true;
			this.button18.Click += new global::System.EventHandler(this.button18_Click);
			this.groupBox5.Controls.Add(this.button28);
			this.groupBox5.Controls.Add(this.label11);
			this.groupBox5.Controls.Add(this.button13);
			this.groupBox5.Controls.Add(this.button12);
			this.groupBox5.Controls.Add(this.button10);
			this.groupBox5.Controls.Add(this.wipecombo);
			this.groupBox5.Location = new global::System.Drawing.Point(6, 184);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new global::System.Drawing.Size(335, 74);
			this.groupBox5.TabIndex = 17;
			this.groupBox5.TabStop = false;
			this.button28.Location = new global::System.Drawing.Point(234, 44);
			this.button28.Name = "button28";
			this.button28.Size = new global::System.Drawing.Size(75, 23);
			this.button28.TabIndex = 14;
			this.button28.Text = "Update List";
			this.button28.UseVisualStyleBackColor = true;
			this.button28.Click += new global::System.EventHandler(this.button28_Click);
			this.label11.AutoSize = true;
			this.label11.Location = new global::System.Drawing.Point(36, 47);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(58, 13);
			this.label11.TabIndex = 13;
			this.label11.Text = "App name:";
			this.button13.Enabled = false;
			this.button13.Location = new global::System.Drawing.Point(249, 15);
			this.button13.Name = "button13";
			this.button13.Size = new global::System.Drawing.Size(75, 23);
			this.button13.TabIndex = 12;
			this.button13.Text = "Backup";
			this.button13.UseVisualStyleBackColor = true;
			this.button13.Click += new global::System.EventHandler(this.button13_Click);
			this.button12.Enabled = false;
			this.button12.Location = new global::System.Drawing.Point(33, 15);
			this.button12.Name = "button12";
			this.button12.Size = new global::System.Drawing.Size(75, 23);
			this.button12.TabIndex = 11;
			this.button12.Text = "Open App";
			this.button12.UseVisualStyleBackColor = true;
			this.button12.Click += new global::System.EventHandler(this.button12_Click);
			this.button10.Enabled = false;
			this.button10.Location = new global::System.Drawing.Point(134, 15);
			this.button10.Name = "button10";
			this.button10.Size = new global::System.Drawing.Size(75, 23);
			this.button10.TabIndex = 7;
			this.button10.Text = "Wipe";
			this.button10.UseVisualStyleBackColor = true;
			this.button10.Click += new global::System.EventHandler(this.button10_Click_1);
			this.wipecombo.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.wipecombo.Enabled = false;
			this.wipecombo.FormattingEnabled = true;
			this.wipecombo.Location = new global::System.Drawing.Point(107, 44);
			this.wipecombo.Name = "wipecombo";
			this.wipecombo.Size = new global::System.Drawing.Size(100, 21);
			this.wipecombo.Sorted = true;
			this.wipecombo.TabIndex = 8;
			this.wipecombo.SelectedIndexChanged += new global::System.EventHandler(this.wipecombo_SelectedIndexChanged);
			this.pictureBox1.Image = global::AutoLead.Properties.Resources._1234;
			this.pictureBox1.InitialImage = null;
			this.pictureBox1.Location = new global::System.Drawing.Point(387, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(198, 335);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new global::System.EventHandler(this.pictureBox1_Click);
			this.pictureBox1.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
			this.pictureBox1.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
			this.tabPage7.Controls.Add(this.label35);
			this.tabPage7.Controls.Add(this.label34);
			this.tabPage7.Controls.Add(this.checkBox7);
			this.tabPage7.Controls.Add(this.comboBox3);
			this.tabPage7.Controls.Add(this.checkBox6);
			this.tabPage7.Controls.Add(this.button31);
			this.tabPage7.Controls.Add(this.label26);
			this.tabPage7.Controls.Add(this.textBox4);
			this.tabPage7.Controls.Add(this.button29);
			this.tabPage7.Controls.Add(this.button27);
			this.tabPage7.Controls.Add(this.label9);
			this.tabPage7.Controls.Add(this.rsswaitnum);
			this.tabPage7.Controls.Add(this.label8);
			this.tabPage7.Controls.Add(this.bkreset);
			this.tabPage7.Controls.Add(this.button19);
			this.tabPage7.Controls.Add(this.button17);
			this.tabPage7.Controls.Add(this.button16);
			this.tabPage7.Controls.Add(this.button15);
			this.tabPage7.Controls.Add(this.listView4);
			this.tabPage7.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage7.Name = "tabPage7";
			this.tabPage7.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage7.Size = new global::System.Drawing.Size(620, 398);
			this.tabPage7.TabIndex = 3;
			this.tabPage7.Text = "RRS";
			this.tabPage7.UseVisualStyleBackColor = true;
			this.tabPage7.Click += new global::System.EventHandler(this.tabPage7_Click);
			this.label35.AutoSize = true;
			this.label35.ForeColor = global::System.Drawing.Color.ForestGreen;
			this.label35.Location = new global::System.Drawing.Point(128, 317);
			this.label35.Name = "label35";
			this.label35.Size = new global::System.Drawing.Size(72, 13);
			this.label35.TabIndex = 19;
			this.label35.Text = "Seleted RRS:";
			this.label34.AutoSize = true;
			this.label34.ForeColor = global::System.Drawing.SystemColors.Highlight;
			this.label34.Location = new global::System.Drawing.Point(20, 317);
			this.label34.Name = "label34";
			this.label34.Size = new global::System.Drawing.Size(66, 13);
			this.label34.TabIndex = 18;
			this.label34.Text = "Total RRS:0";
			this.checkBox7.AutoSize = true;
			this.checkBox7.Enabled = false;
			this.checkBox7.Location = new global::System.Drawing.Point(360, 311);
			this.checkBox7.Name = "checkBox7";
			this.checkBox7.Size = new global::System.Drawing.Size(96, 17);
			this.checkBox7.TabIndex = 17;
			this.checkBox7.Text = "Random Script";
			this.checkBox7.UseVisualStyleBackColor = true;
			this.checkBox7.CheckedChanged += new global::System.EventHandler(this.checkBox7_CheckedChanged);
			this.comboBox3.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox3.Enabled = false;
			this.comboBox3.FormattingEnabled = true;
			this.comboBox3.Location = new global::System.Drawing.Point(489, 309);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new global::System.Drawing.Size(110, 21);
			this.comboBox3.TabIndex = 16;
			this.comboBox3.SelectedIndexChanged += new global::System.EventHandler(this.comboBox3_SelectedIndexChanged);
			this.checkBox6.AutoSize = true;
			this.checkBox6.Enabled = false;
			this.checkBox6.Location = new global::System.Drawing.Point(279, 311);
			this.checkBox6.Name = "checkBox6";
			this.checkBox6.Size = new global::System.Drawing.Size(75, 17);
			this.checkBox6.TabIndex = 15;
			this.checkBox6.Text = "Use Script";
			this.checkBox6.UseVisualStyleBackColor = true;
			this.checkBox6.CheckedChanged += new global::System.EventHandler(this.checkBox6_CheckedChanged);
			this.button31.Location = new global::System.Drawing.Point(518, 281);
			this.button31.Name = "button31";
			this.button31.Size = new global::System.Drawing.Size(101, 23);
			this.button31.TabIndex = 14;
			this.button31.Text = "Save Comment";
			this.button31.UseVisualStyleBackColor = true;
			this.button31.Click += new global::System.EventHandler(this.button31_Click);
			this.label26.AutoSize = true;
			this.label26.Location = new global::System.Drawing.Point(16, 286);
			this.label26.Name = "label26";
			this.label26.Size = new global::System.Drawing.Size(54, 13);
			this.label26.TabIndex = 13;
			this.label26.Text = "Comment:";
			this.textBox4.Location = new global::System.Drawing.Point(82, 283);
			this.textBox4.Multiline = true;
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new global::System.Drawing.Size(405, 20);
			this.textBox4.TabIndex = 12;
			this.button29.Enabled = false;
			this.button29.Location = new global::System.Drawing.Point(245, 245);
			this.button29.Name = "button29";
			this.button29.Size = new global::System.Drawing.Size(89, 29);
			this.button29.TabIndex = 11;
			this.button29.Text = "Save";
			this.button29.UseVisualStyleBackColor = true;
			this.button29.Click += new global::System.EventHandler(this.button29_Click);
			this.button27.Enabled = false;
			this.button27.Location = new global::System.Drawing.Point(131, 247);
			this.button27.Name = "button27";
			this.button27.Size = new global::System.Drawing.Size(91, 27);
			this.button27.TabIndex = 10;
			this.button27.Text = "Restore";
			this.button27.UseVisualStyleBackColor = true;
			this.button27.Click += new global::System.EventHandler(this.button27_Click);
			this.label9.AutoSize = true;
			this.label9.Location = new global::System.Drawing.Point(175, 355);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(44, 13);
			this.label9.TabIndex = 9;
			this.label9.Text = "Second";
			this.rsswaitnum.Location = new global::System.Drawing.Point(100, 353);
			global::System.Windows.Forms.NumericUpDown arg_69A7_0 = this.rsswaitnum;
			int[] expr_699A = new int[4];
			expr_699A[0] = 10000;
			arg_69A7_0.Maximum = new decimal(expr_699A);
			this.rsswaitnum.Name = "rsswaitnum";
			this.rsswaitnum.Size = new global::System.Drawing.Size(64, 20);
			this.rsswaitnum.TabIndex = 8;
			global::System.Windows.Forms.NumericUpDown arg_69F6_0 = this.rsswaitnum;
			int[] expr_69EC = new int[4];
			expr_69EC[0] = 20;
			arg_69F6_0.Value = new decimal(expr_69EC);
			this.rsswaitnum.ValueChanged += new global::System.EventHandler(this.rsswaitnum_ValueChanged);
			this.label8.AutoSize = true;
			this.label8.Location = new global::System.Drawing.Point(25, 355);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(72, 13);
			this.label8.TabIndex = 7;
			this.label8.Text = "Waiting Time:";
			this.bkreset.Enabled = false;
			this.bkreset.Location = new global::System.Drawing.Point(410, 354);
			this.bkreset.Name = "bkreset";
			this.bkreset.Size = new global::System.Drawing.Size(75, 23);
			this.bkreset.TabIndex = 6;
			this.bkreset.Text = "Reset";
			this.bkreset.UseVisualStyleBackColor = true;
			this.bkreset.Click += new global::System.EventHandler(this.bkreset_Click);
			this.button19.Enabled = false;
			this.button19.Location = new global::System.Drawing.Point(259, 341);
			this.button19.Name = "button19";
			this.button19.Size = new global::System.Drawing.Size(103, 38);
			this.button19.TabIndex = 5;
			this.button19.Text = "START";
			this.button19.UseVisualStyleBackColor = true;
			this.button19.Click += new global::System.EventHandler(this.button19_Click);
			this.button17.Enabled = false;
			this.button17.Location = new global::System.Drawing.Point(491, 247);
			this.button17.Name = "button17";
			this.button17.Size = new global::System.Drawing.Size(91, 25);
			this.button17.TabIndex = 3;
			this.button17.Text = "Remove All";
			this.button17.UseVisualStyleBackColor = true;
			this.button17.Click += new global::System.EventHandler(this.button17_Click);
			this.button16.Enabled = false;
			this.button16.Location = new global::System.Drawing.Point(365, 245);
			this.button16.Name = "button16";
			this.button16.Size = new global::System.Drawing.Size(91, 28);
			this.button16.TabIndex = 2;
			this.button16.Text = "Remove";
			this.button16.UseVisualStyleBackColor = true;
			this.button16.Click += new global::System.EventHandler(this.button16_Click);
			this.button15.Enabled = false;
			this.button15.Location = new global::System.Drawing.Point(10, 246);
			this.button15.Name = "button15";
			this.button15.Size = new global::System.Drawing.Size(91, 28);
			this.button15.TabIndex = 1;
			this.button15.Text = "Get Backup list";
			this.button15.UseVisualStyleBackColor = true;
			this.button15.Click += new global::System.EventHandler(this.button15_Click);
			this.listView4.CheckBoxes = true;
			this.listView4.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.columnHeader10,
				this.columnHeader7,
				this.columnHeader11,
				this.columnHeader12,
				this.columnHeader8,
				this.columnHeader9,
				this.columnHeader15,
				this.columnHeader16
			});
			this.listView4.FullRowSelect = true;
			this.listView4.GridLines = true;
			this.listView4.Location = new global::System.Drawing.Point(6, 6);
			this.listView4.Name = "listView4";
			this.listView4.Size = new global::System.Drawing.Size(610, 233);
			this.listView4.TabIndex = 0;
			this.listView4.UseCompatibleStateImageBehavior = false;
			this.listView4.View = global::System.Windows.Forms.View.Details;
			this.listView4.ColumnClick += new global::System.Windows.Forms.ColumnClickEventHandler(this.listView4_ColumnClick);
			this.listView4.DrawColumnHeader += new global::System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listView4_DrawColumnHeader);
			this.listView4.DrawItem += new global::System.Windows.Forms.DrawListViewItemEventHandler(this.listView4_DrawItem);
			this.listView4.DrawSubItem += new global::System.Windows.Forms.DrawListViewSubItemEventHandler(this.listView4_DrawSubItem);
			this.listView4.ItemCheck += new global::System.Windows.Forms.ItemCheckEventHandler(this.listView4_ItemCheck);
			this.listView4.ItemChecked += new global::System.Windows.Forms.ItemCheckedEventHandler(this.listView4_ItemChecked);
			this.listView4.SelectedIndexChanged += new global::System.EventHandler(this.listView4_SelectedIndexChanged);
			this.listView4.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.listView4_KeyDown);
			this.columnHeader10.Text = "";
			this.columnHeader10.Width = 23;
			this.columnHeader7.Text = "Ngày tạo";
			this.columnHeader7.Width = 82;
			this.columnHeader11.Text = "Ngày điều chỉnh";
			this.columnHeader11.Width = 95;
			this.columnHeader12.Text = "Số lần chạy";
			this.columnHeader12.Width = 51;
			this.columnHeader8.Text = "D.sách ứng dụng";
			this.columnHeader8.Width = 101;
			this.columnHeader9.Text = "Comment";
			this.columnHeader9.Width = 133;
			this.columnHeader15.Text = "Country";
			this.columnHeader15.Width = 90;
			this.columnHeader16.Text = "File Name";
			this.tabPage2.Controls.Add(this.tabControl2);
			this.tabPage2.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new global::System.Drawing.Size(620, 398);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Proxy";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.tabControl2.Controls.Add(this.tabPage3);
			this.tabControl2.Controls.Add(this.tabPage4);
			this.tabControl2.Location = new global::System.Drawing.Point(-4, 0);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new global::System.Drawing.Size(630, 480);
			this.tabControl2.TabIndex = 0;
			this.tabPage3.Controls.Add(this.checkBox17);
			this.tabPage3.Controls.Add(this.ss_dead);
			this.tabPage3.Controls.Add(this.ssh_used);
			this.tabPage3.Controls.Add(this.ssh_live);
			this.tabPage3.Controls.Add(this.ssh_uncheck);
			this.tabPage3.Controls.Add(this.numericUpDown2);
			this.tabPage3.Controls.Add(this.label14);
			this.tabPage3.Controls.Add(this.labeltotalssh);
			this.tabPage3.Controls.Add(this.button25);
			this.tabPage3.Controls.Add(this.button24);
			this.tabPage3.Controls.Add(this.button22);
			this.tabPage3.Controls.Add(this.button8);
			this.tabPage3.Controls.Add(this.button14);
			this.tabPage3.Controls.Add(this.button9);
			this.tabPage3.Controls.Add(this.importfromfile);
			this.tabPage3.Controls.Add(this.listView2);
			this.tabPage3.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new global::System.Drawing.Size(622, 454);
			this.tabPage3.TabIndex = 0;
			this.tabPage3.Text = "SSH";
			this.tabPage3.UseVisualStyleBackColor = true;
			this.tabPage3.Click += new global::System.EventHandler(this.tabPage3_Click);
			this.checkBox17.AutoSize = true;
			this.checkBox17.Location = new global::System.Drawing.Point(448, 276);
			this.checkBox17.Name = "checkBox17";
			this.checkBox17.Size = new global::System.Drawing.Size(152, 17);
			this.checkBox17.TabIndex = 29;
			this.checkBox17.Text = "Refresh SSH nếu hết SSH";
			this.checkBox17.UseVisualStyleBackColor = true;
			this.checkBox17.CheckedChanged += new global::System.EventHandler(this.checkBox17_CheckedChanged);
			this.ss_dead.AutoSize = true;
			this.ss_dead.ForeColor = global::System.Drawing.Color.Red;
			this.ss_dead.Location = new global::System.Drawing.Point(517, 359);
			this.ss_dead.Name = "ss_dead";
			this.ss_dead.Size = new global::System.Drawing.Size(36, 13);
			this.ss_dead.TabIndex = 21;
			this.ss_dead.Text = "Dead:";
			this.ssh_used.AutoSize = true;
			this.ssh_used.ForeColor = global::System.Drawing.SystemColors.Highlight;
			this.ssh_used.Location = new global::System.Drawing.Point(406, 359);
			this.ssh_used.Name = "ssh_used";
			this.ssh_used.Size = new global::System.Drawing.Size(35, 13);
			this.ssh_used.TabIndex = 20;
			this.ssh_used.Text = "Used:";
			this.ssh_live.AutoSize = true;
			this.ssh_live.ForeColor = global::System.Drawing.Color.FromArgb(0, 192, 0);
			this.ssh_live.Location = new global::System.Drawing.Point(303, 359);
			this.ssh_live.Name = "ssh_live";
			this.ssh_live.Size = new global::System.Drawing.Size(30, 13);
			this.ssh_live.TabIndex = 19;
			this.ssh_live.Text = "Live:";
			this.ssh_uncheck.AutoSize = true;
			this.ssh_uncheck.ForeColor = global::System.Drawing.Color.Gray;
			this.ssh_uncheck.Location = new global::System.Drawing.Point(178, 359);
			this.ssh_uncheck.Name = "ssh_uncheck";
			this.ssh_uncheck.Size = new global::System.Drawing.Size(54, 13);
			this.ssh_uncheck.TabIndex = 18;
			this.ssh_uncheck.Text = "Uncheck:";
			this.numericUpDown2.Location = new global::System.Drawing.Point(208, 278);
			global::System.Windows.Forms.NumericUpDown arg_75CD_0 = this.numericUpDown2;
			int[] expr_75C4 = new int[4];
			expr_75C4[0] = 1;
			arg_75CD_0.Minimum = new decimal(expr_75C4);
			this.numericUpDown2.Name = "numericUpDown2";
			this.numericUpDown2.Size = new global::System.Drawing.Size(56, 20);
			this.numericUpDown2.TabIndex = 17;
			global::System.Windows.Forms.NumericUpDown arg_761D_0 = this.numericUpDown2;
			int[] expr_7613 = new int[4];
			expr_7613[0] = 10;
			arg_761D_0.Value = new decimal(expr_7613);
			this.numericUpDown2.ValueChanged += new global::System.EventHandler(this.numericUpDown2_ValueChanged);
			this.label14.AutoSize = true;
			this.label14.Location = new global::System.Drawing.Point(106, 280);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(96, 13);
			this.label14.TabIndex = 16;
			this.label14.Text = "Number of Thread:";
			this.labeltotalssh.AutoSize = true;
			this.labeltotalssh.Location = new global::System.Drawing.Point(47, 359);
			this.labeltotalssh.Name = "labeltotalssh";
			this.labeltotalssh.Size = new global::System.Drawing.Size(59, 13);
			this.labeltotalssh.TabIndex = 15;
			this.labeltotalssh.Text = "Total SSH:";
			this.button25.Location = new global::System.Drawing.Point(391, 309);
			this.button25.Name = "button25";
			this.button25.Size = new global::System.Drawing.Size(109, 23);
			this.button25.TabIndex = 14;
			this.button25.Text = "Export To File";
			this.button25.UseVisualStyleBackColor = true;
			this.button25.Click += new global::System.EventHandler(this.button25_Click);
			this.button24.Location = new global::System.Drawing.Point(476, 167);
			this.button24.Name = "button24";
			this.button24.Size = new global::System.Drawing.Size(75, 25);
			this.button24.TabIndex = 13;
			this.button24.Text = "Refresh";
			this.button24.UseVisualStyleBackColor = true;
			this.button24.Click += new global::System.EventHandler(this.button24_Click);
			this.button22.Location = new global::System.Drawing.Point(476, 108);
			this.button22.Name = "button22";
			this.button22.Size = new global::System.Drawing.Size(75, 23);
			this.button22.TabIndex = 11;
			this.button22.Text = "Delete All";
			this.button22.UseVisualStyleBackColor = true;
			this.button22.Click += new global::System.EventHandler(this.button22_Click);
			this.button8.Location = new global::System.Drawing.Point(476, 56);
			this.button8.Name = "button8";
			this.button8.Size = new global::System.Drawing.Size(75, 23);
			this.button8.TabIndex = 10;
			this.button8.Text = "Delete";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new global::System.EventHandler(this.button8_Click);
			this.button14.Location = new global::System.Drawing.Point(217, 309);
			this.button14.Name = "button14";
			this.button14.Size = new global::System.Drawing.Size(115, 23);
			this.button14.TabIndex = 5;
			this.button14.Text = "Import from Clipboard";
			this.button14.UseVisualStyleBackColor = true;
			this.button14.Click += new global::System.EventHandler(this.button14_Click);
			this.button9.Enabled = false;
			this.button9.Location = new global::System.Drawing.Point(13, 275);
			this.button9.Name = "button9";
			this.button9.Size = new global::System.Drawing.Size(75, 23);
			this.button9.TabIndex = 2;
			this.button9.Text = "Check Live";
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Click += new global::System.EventHandler(this.button9_Click);
			this.importfromfile.Location = new global::System.Drawing.Point(50, 309);
			this.importfromfile.Name = "importfromfile";
			this.importfromfile.Size = new global::System.Drawing.Size(99, 23);
			this.importfromfile.TabIndex = 1;
			this.importfromfile.Text = "Import from File";
			this.importfromfile.UseVisualStyleBackColor = true;
			this.importfromfile.Click += new global::System.EventHandler(this.importfromfile_Click);
			this.listView2.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.columnHeader1,
				this.columnHeader2,
				this.columnHeader3,
				this.columnHeader4
			});
			this.listView2.ForeColor = global::System.Drawing.SystemColors.WindowText;
			this.listView2.GridLines = true;
			this.listView2.Location = new global::System.Drawing.Point(11, 6);
			this.listView2.Name = "listView2";
			this.listView2.Size = new global::System.Drawing.Size(428, 256);
			this.listView2.TabIndex = 0;
			this.listView2.UseCompatibleStateImageBehavior = false;
			this.listView2.View = global::System.Windows.Forms.View.Details;
			this.listView2.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.listView2_KeyDown);
			this.listView2.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.listView2_KeyPress);
			this.columnHeader1.Text = "IP";
			this.columnHeader1.Width = 121;
			this.columnHeader2.Text = "username";
			this.columnHeader2.Width = 80;
			this.columnHeader3.Text = "password";
			this.columnHeader3.Width = 97;
			this.columnHeader4.Text = "Country";
			this.columnHeader4.Width = 134;
			this.tabPage4.Controls.Add(this.sameVip);
			this.tabPage4.Controls.Add(this.button57);
			this.tabPage4.Controls.Add(this.groupBox2);
			this.tabPage4.Controls.Add(this.vipdelete);
			this.tabPage4.Controls.Add(this.listView3);
			this.tabPage4.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new global::System.Drawing.Size(622, 454);
			this.tabPage4.TabIndex = 1;
			this.tabPage4.Text = "VIP72";
			this.tabPage4.UseVisualStyleBackColor = true;
			this.tabPage4.Click += new global::System.EventHandler(this.tabPage4_Click);
			this.sameVip.AutoSize = true;
			this.sameVip.Checked = true;
			this.sameVip.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.sameVip.Location = new global::System.Drawing.Point(39, 353);
			this.sameVip.Name = "sameVip";
			this.sameVip.Size = new global::System.Drawing.Size(176, 17);
			this.sameVip.TabIndex = 13;
			this.sameVip.Text = "Sử dụng chung Vip72 với nhau.";
			this.sameVip.UseVisualStyleBackColor = true;
			this.sameVip.CheckedChanged += new global::System.EventHandler(this.sameVip_CheckedChanged);
			this.button57.Location = new global::System.Drawing.Point(180, 304);
			this.button57.Name = "button57";
			this.button57.Size = new global::System.Drawing.Size(101, 23);
			this.button57.TabIndex = 12;
			this.button57.Text = "Check Account";
			this.button57.UseVisualStyleBackColor = true;
			this.groupBox2.Controls.Add(this.vippassword);
			this.groupBox2.Controls.Add(this.vipid);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.vipadd);
			this.groupBox2.Location = new global::System.Drawing.Point(343, 40);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(229, 252);
			this.groupBox2.TabIndex = 11;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Add account";
			this.vippassword.Location = new global::System.Drawing.Point(100, 164);
			this.vippassword.Name = "vippassword";
			this.vippassword.Size = new global::System.Drawing.Size(100, 20);
			this.vippassword.TabIndex = 5;
			this.vipid.Location = new global::System.Drawing.Point(100, 36);
			this.vipid.Multiline = true;
			this.vipid.Name = "vipid";
			this.vipid.Size = new global::System.Drawing.Size(100, 106);
			this.vipid.TabIndex = 4;
			this.label10.AutoSize = true;
			this.label10.Location = new global::System.Drawing.Point(26, 167);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(53, 13);
			this.label10.TabIndex = 3;
			this.label10.Text = "Password";
			this.label7.AutoSize = true;
			this.label7.Location = new global::System.Drawing.Point(42, 82);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(18, 13);
			this.label7.TabIndex = 2;
			this.label7.Text = "ID";
			this.vipadd.Location = new global::System.Drawing.Point(86, 214);
			this.vipadd.Name = "vipadd";
			this.vipadd.Size = new global::System.Drawing.Size(91, 23);
			this.vipadd.TabIndex = 1;
			this.vipadd.Text = "Add Account";
			this.vipadd.UseVisualStyleBackColor = true;
			this.vipadd.Click += new global::System.EventHandler(this.button10_Click);
			this.vipdelete.Location = new global::System.Drawing.Point(39, 304);
			this.vipdelete.Name = "vipdelete";
			this.vipdelete.Size = new global::System.Drawing.Size(89, 23);
			this.vipdelete.TabIndex = 2;
			this.vipdelete.Text = "Delete Account";
			this.vipdelete.UseVisualStyleBackColor = true;
			this.vipdelete.Click += new global::System.EventHandler(this.vipdelete_Click);
			this.listView3.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.columnHeader5,
				this.columnHeader6
			});
			this.listView3.Location = new global::System.Drawing.Point(34, 20);
			this.listView3.Name = "listView3";
			this.listView3.Size = new global::System.Drawing.Size(237, 257);
			this.listView3.TabIndex = 0;
			this.listView3.UseCompatibleStateImageBehavior = false;
			this.listView3.View = global::System.Windows.Forms.View.Details;
			this.listView3.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.listView3_KeyDown);
			this.columnHeader5.Text = "Username";
			this.columnHeader5.Width = 112;
			this.columnHeader6.Text = "Password";
			this.columnHeader6.Width = 107;
			this.tabPage1.Controls.Add(this.textBox11);
			this.tabPage1.Controls.Add(this.comment);
			this.tabPage1.Controls.Add(this.label44);
			this.tabPage1.Controls.Add(this.checkBox18);
			this.tabPage1.Controls.Add(this.checkBox12);
			this.tabPage1.Controls.Add(this.numericUpDown6);
			this.tabPage1.Controls.Add(this.checkBox10);
			this.tabPage1.Controls.Add(this.backuprate);
			this.tabPage1.Controls.Add(this.backupoftime);
			this.tabPage1.Controls.Add(this.runoftime);
			this.tabPage1.Controls.Add(this.label29);
			this.tabPage1.Controls.Add(this.label28);
			this.tabPage1.Controls.Add(this.numericUpDown3);
			this.tabPage1.Controls.Add(this.label27);
			this.tabPage1.Controls.Add(this.itunesY);
			this.tabPage1.Controls.Add(this.label22);
			this.tabPage1.Controls.Add(this.itunesX);
			this.tabPage1.Controls.Add(this.label17);
			this.tabPage1.Controls.Add(this.safariY);
			this.tabPage1.Controls.Add(this.label16);
			this.tabPage1.Controls.Add(this.safariX);
			this.tabPage1.Controls.Add(this.label15);
			this.tabPage1.Controls.Add(this.button21);
			this.tabPage1.Controls.Add(this.Reset);
			this.tabPage1.Controls.Add(this.checkBox3);
			this.tabPage1.Controls.Add(this.checkBox2);
			this.tabPage1.Controls.Add(this.button7);
			this.tabPage1.Controls.Add(this.checkBox1);
			this.tabPage1.Controls.Add(this.button6);
			this.tabPage1.Controls.Add(this.button5);
			this.tabPage1.Controls.Add(this.button4);
			this.tabPage1.Controls.Add(this.button3);
			this.tabPage1.Controls.Add(this.listView1);
			this.tabPage1.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new global::System.Drawing.Size(620, 398);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "AutoLead";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.textBox11.Location = new global::System.Drawing.Point(488, 369);
			this.textBox11.Name = "textBox11";
			this.textBox11.Size = new global::System.Drawing.Size(100, 20);
			this.textBox11.TabIndex = 37;
			this.textBox11.Text = "00000";
			this.textBox11.Visible = false;
			this.textBox11.TextChanged += new global::System.EventHandler(this.textBox11_TextChanged);
			this.comment.Location = new global::System.Drawing.Point(66, 207);
			this.comment.Name = "comment";
			this.comment.Size = new global::System.Drawing.Size(260, 20);
			this.comment.TabIndex = 25;
			this.comment.TextChanged += new global::System.EventHandler(this.comment_TextChanged);
			this.label44.AutoSize = true;
			this.label44.Location = new global::System.Drawing.Point(435, 375);
			this.label44.Name = "label44";
			this.label44.Size = new global::System.Drawing.Size(41, 13);
			this.label44.TabIndex = 36;
			this.label44.Text = "OfferID";
			this.label44.Visible = false;
			this.checkBox18.AutoSize = true;
			this.checkBox18.Location = new global::System.Drawing.Point(463, 338);
			this.checkBox18.Name = "checkBox18";
			this.checkBox18.Size = new global::System.Drawing.Size(101, 17);
			this.checkBox18.TabIndex = 35;
			this.checkBox18.Text = "Check Trùng IP";
			this.checkBox18.UseVisualStyleBackColor = true;
			this.checkBox18.Visible = false;
			this.checkBox18.CheckedChanged += new global::System.EventHandler(this.checkBox18_CheckedChanged);
			this.checkBox12.AutoSize = true;
			this.checkBox12.Location = new global::System.Drawing.Point(332, 210);
			this.checkBox12.Name = "checkBox12";
			this.checkBox12.Size = new global::System.Drawing.Size(127, 17);
			this.checkBox12.TabIndex = 34;
			this.checkBox12.Text = "Lưu IP trên comment.";
			this.checkBox12.UseVisualStyleBackColor = true;
			this.checkBox12.CheckedChanged += new global::System.EventHandler(this.checkBox12_CheckedChanged);
			this.numericUpDown6.Location = new global::System.Drawing.Point(343, 239);
			global::System.Windows.Forms.NumericUpDown arg_88BA_0 = this.numericUpDown6;
			int[] expr_88AD = new int[4];
			expr_88AD[0] = 10000;
			arg_88BA_0.Maximum = new decimal(expr_88AD);
			this.numericUpDown6.Name = "numericUpDown6";
			this.numericUpDown6.Size = new global::System.Drawing.Size(75, 20);
			this.numericUpDown6.TabIndex = 33;
			global::System.Windows.Forms.NumericUpDown arg_890D_0 = this.numericUpDown6;
			int[] expr_8900 = new int[4];
			expr_8900[0] = 200;
			arg_890D_0.Value = new decimal(expr_8900);
			this.numericUpDown6.ValueChanged += new global::System.EventHandler(this.numericUpDown6_ValueChanged);
			this.checkBox10.AutoSize = true;
			this.checkBox10.Location = new global::System.Drawing.Point(207, 240);
			this.checkBox10.Name = "checkBox10";
			this.checkBox10.Size = new global::System.Drawing.Size(130, 17);
			this.checkBox10.TabIndex = 32;
			this.checkBox10.Text = "Hạn chế số lượt chạy:";
			this.checkBox10.UseVisualStyleBackColor = true;
			this.checkBox10.CheckedChanged += new global::System.EventHandler(this.checkBox10_CheckedChanged);
			this.backuprate.AutoSize = true;
			this.backuprate.ForeColor = global::System.Drawing.Color.FromArgb(192, 64, 0);
			this.backuprate.Location = new global::System.Drawing.Point(26, 375);
			this.backuprate.Name = "backuprate";
			this.backuprate.Size = new global::System.Drawing.Size(87, 13);
			this.backuprate.TabIndex = 31;
			this.backuprate.Text = "Backup Rate:0%";
			this.backupoftime.AutoSize = true;
			this.backupoftime.ForeColor = global::System.Drawing.SystemColors.MenuHighlight;
			this.backupoftime.Location = new global::System.Drawing.Point(26, 356);
			this.backupoftime.Name = "backupoftime";
			this.backupoftime.Size = new global::System.Drawing.Size(56, 13);
			this.backupoftime.TabIndex = 30;
			this.backupoftime.Text = "Backup: 0";
			this.runoftime.AutoSize = true;
			this.runoftime.ForeColor = global::System.Drawing.Color.DarkCyan;
			this.runoftime.Location = new global::System.Drawing.Point(26, 338);
			this.runoftime.Name = "runoftime";
			this.runoftime.Size = new global::System.Drawing.Size(39, 13);
			this.runoftime.TabIndex = 29;
			this.runoftime.Text = "Run: 0";
			this.label29.AutoSize = true;
			this.label29.Location = new global::System.Drawing.Point(182, 243);
			this.label29.Name = "label29";
			this.label29.Size = new global::System.Drawing.Size(15, 13);
			this.label29.TabIndex = 28;
			this.label29.Text = "%";
			this.label28.AutoSize = true;
			this.label28.Location = new global::System.Drawing.Point(92, 240);
			this.label28.Name = "label28";
			this.label28.Size = new global::System.Drawing.Size(33, 13);
			this.label28.TabIndex = 27;
			this.label28.Text = "Tỷ lệ:";
			this.numericUpDown3.Location = new global::System.Drawing.Point(130, 239);
			this.numericUpDown3.Name = "numericUpDown3";
			this.numericUpDown3.Size = new global::System.Drawing.Size(46, 20);
			this.numericUpDown3.TabIndex = 26;
			global::System.Windows.Forms.NumericUpDown arg_8C75_0 = this.numericUpDown3;
			int[] expr_8C6B = new int[4];
			expr_8C6B[0] = 50;
			arg_8C75_0.Value = new decimal(expr_8C6B);
			this.numericUpDown3.ValueChanged += new global::System.EventHandler(this.numericUpDown3_ValueChanged);
			this.label27.AutoSize = true;
			this.label27.Location = new global::System.Drawing.Point(6, 212);
			this.label27.Name = "label27";
			this.label27.Size = new global::System.Drawing.Size(54, 13);
			this.label27.TabIndex = 24;
			this.label27.Text = "Comment:";
			this.itunesY.Location = new global::System.Drawing.Point(502, 271);
			global::System.Windows.Forms.NumericUpDown arg_8D30_0 = this.itunesY;
			int[] expr_8D23 = new int[4];
			expr_8D23[0] = 100000;
			arg_8D30_0.Maximum = new decimal(expr_8D23);
			this.itunesY.Minimum = new decimal(new int[]
			{
				1,
				0,
				0,
				-2147483648
			});
			this.itunesY.Name = "itunesY";
			this.itunesY.Size = new global::System.Drawing.Size(60, 20);
			this.itunesY.TabIndex = 23;
			this.itunesY.Value = new decimal(new int[]
			{
				1,
				0,
				0,
				-2147483648
			});
			this.itunesY.ValueChanged += new global::System.EventHandler(this.itunesY_ValueChanged);
			this.label22.AutoSize = true;
			this.label22.Location = new global::System.Drawing.Point(451, 273);
			this.label22.Name = "label22";
			this.label22.Size = new global::System.Drawing.Size(50, 13);
			this.label22.TabIndex = 22;
			this.label22.Text = "ITunesY:";
			this.itunesX.Location = new global::System.Drawing.Point(354, 271);
			global::System.Windows.Forms.NumericUpDown arg_8E69_0 = this.itunesX;
			int[] expr_8E5C = new int[4];
			expr_8E5C[0] = 100000;
			arg_8E69_0.Maximum = new decimal(expr_8E5C);
			this.itunesX.Minimum = new decimal(new int[]
			{
				1,
				0,
				0,
				-2147483648
			});
			this.itunesX.Name = "itunesX";
			this.itunesX.Size = new global::System.Drawing.Size(60, 20);
			this.itunesX.TabIndex = 21;
			this.itunesX.Value = new decimal(new int[]
			{
				1,
				0,
				0,
				-2147483648
			});
			this.itunesX.ValueChanged += new global::System.EventHandler(this.itunesX_ValueChanged);
			this.label17.AutoSize = true;
			this.label17.Location = new global::System.Drawing.Point(296, 273);
			this.label17.Name = "label17";
			this.label17.Size = new global::System.Drawing.Size(49, 13);
			this.label17.TabIndex = 20;
			this.label17.Text = "iTunesX:";
			this.safariY.Enabled = false;
			this.safariY.Location = new global::System.Drawing.Point(211, 271);
			global::System.Windows.Forms.NumericUpDown arg_8FAF_0 = this.safariY;
			int[] expr_8FA2 = new int[4];
			expr_8FA2[0] = 100000;
			arg_8FAF_0.Maximum = new decimal(expr_8FA2);
			this.safariY.Minimum = new decimal(new int[]
			{
				1,
				0,
				0,
				-2147483648
			});
			this.safariY.Name = "safariY";
			this.safariY.Size = new global::System.Drawing.Size(58, 20);
			this.safariY.TabIndex = 19;
			this.safariY.Value = new decimal(new int[]
			{
				1,
				0,
				0,
				-2147483648
			});
			this.safariY.ValueChanged += new global::System.EventHandler(this.safariY_ValueChanged);
			this.label16.AutoSize = true;
			this.label16.Location = new global::System.Drawing.Point(161, 273);
			this.label16.Name = "label16";
			this.label16.Size = new global::System.Drawing.Size(44, 13);
			this.label16.TabIndex = 18;
			this.label16.Text = "SafariY:";
			this.safariX.Enabled = false;
			this.safariX.Location = new global::System.Drawing.Point(76, 271);
			global::System.Windows.Forms.NumericUpDown arg_90F2_0 = this.safariX;
			int[] expr_90E5 = new int[4];
			expr_90E5[0] = 100000;
			arg_90F2_0.Maximum = new decimal(expr_90E5);
			this.safariX.Minimum = new decimal(new int[]
			{
				1,
				0,
				0,
				-2147483648
			});
			this.safariX.Name = "safariX";
			this.safariX.Size = new global::System.Drawing.Size(60, 20);
			this.safariX.TabIndex = 17;
			this.safariX.Value = new decimal(new int[]
			{
				1,
				0,
				0,
				-2147483648
			});
			this.safariX.ValueChanged += new global::System.EventHandler(this.safariX_ValueChanged);
			this.label15.AutoSize = true;
			this.label15.Location = new global::System.Drawing.Point(26, 273);
			this.label15.Name = "label15";
			this.label15.Size = new global::System.Drawing.Size(44, 13);
			this.label15.TabIndex = 16;
			this.label15.Text = "SafariX:";
			this.button21.Location = new global::System.Drawing.Point(519, 237);
			this.button21.Name = "button21";
			this.button21.Size = new global::System.Drawing.Size(97, 25);
			this.button21.TabIndex = 15;
			this.button21.Text = "Clear Install File";
			this.button21.UseVisualStyleBackColor = true;
			this.button21.Click += new global::System.EventHandler(this.button21_Click);
			this.Reset.Enabled = false;
			this.Reset.Location = new global::System.Drawing.Point(343, 369);
			this.Reset.Name = "Reset";
			this.Reset.Size = new global::System.Drawing.Size(75, 23);
			this.Reset.TabIndex = 14;
			this.Reset.Text = "Reset";
			this.Reset.UseVisualStyleBackColor = true;
			this.Reset.Click += new global::System.EventHandler(this.Reset_Click);
			this.checkBox3.AutoSize = true;
			this.checkBox3.Checked = true;
			this.checkBox3.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.checkBox3.Location = new global::System.Drawing.Point(115, 352);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new global::System.Drawing.Size(82, 17);
			this.checkBox3.TabIndex = 13;
			this.checkBox3.Text = "Full Backup";
			this.checkBox3.UseVisualStyleBackColor = true;
			this.checkBox3.Visible = false;
			this.checkBox3.CheckedChanged += new global::System.EventHandler(this.checkBox3_CheckedChanged);
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new global::System.Drawing.Point(438, 240);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new global::System.Drawing.Size(70, 17);
			this.checkBox2.TabIndex = 12;
			this.checkBox2.Text = "Full Wipe";
			this.checkBox2.UseVisualStyleBackColor = true;
			this.checkBox2.CheckedChanged += new global::System.EventHandler(this.checkBox2_CheckedChanged);
			this.button7.BackColor = global::System.Drawing.Color.Transparent;
			this.button7.Enabled = false;
			this.button7.Font = new global::System.Drawing.Font("Segoe UI Black", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button7.Location = new global::System.Drawing.Point(245, 347);
			this.button7.Name = "button7";
			this.button7.Size = new global::System.Drawing.Size(87, 45);
			this.button7.TabIndex = 9;
			this.button7.Text = "START";
			this.button7.UseVisualStyleBackColor = false;
			this.button7.Click += new global::System.EventHandler(this.button7_Click);
			this.checkBox1.AutoSize = true;
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Location = new global::System.Drawing.Point(22, 240);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new global::System.Drawing.Size(63, 17);
			this.checkBox1.TabIndex = 8;
			this.checkBox1.Text = "Backup";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new global::System.EventHandler(this.checkBox1_CheckedChanged);
			this.button6.Location = new global::System.Drawing.Point(476, 300);
			this.button6.Name = "button6";
			this.button6.Size = new global::System.Drawing.Size(75, 23);
			this.button6.TabIndex = 7;
			this.button6.Text = "Remove All";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new global::System.EventHandler(this.button6_Click);
			this.button5.Location = new global::System.Drawing.Point(329, 300);
			this.button5.Name = "button5";
			this.button5.Size = new global::System.Drawing.Size(75, 23);
			this.button5.TabIndex = 6;
			this.button5.Text = "Remove";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new global::System.EventHandler(this.button5_Click);
			this.button4.Location = new global::System.Drawing.Point(164, 300);
			this.button4.Name = "button4";
			this.button4.Size = new global::System.Drawing.Size(75, 23);
			this.button4.TabIndex = 5;
			this.button4.Text = "Edit";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new global::System.EventHandler(this.button4_Click);
			this.button3.Location = new global::System.Drawing.Point(23, 300);
			this.button3.Name = "button3";
			this.button3.Size = new global::System.Drawing.Size(75, 23);
			this.button3.TabIndex = 4;
			this.button3.Text = "Add";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new global::System.EventHandler(this.button3_Click);
			this.listView1.BackColor = global::System.Drawing.SystemColors.Window;
			this.listView1.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.listView1.CheckBoxes = true;
			this.listView1.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.offername,
				this.offerurl,
				this.appname,
				this.timedelay,
				this.usescript
			});
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.Location = new global::System.Drawing.Point(3, 3);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new global::System.Drawing.Size(610, 198);
			this.listView1.TabIndex = 3;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = global::System.Windows.Forms.View.Details;
			this.listView1.ItemCheck += new global::System.Windows.Forms.ItemCheckEventHandler(this.listView1_ItemCheck);
			this.listView1.SelectedIndexChanged += new global::System.EventHandler(this.listView1_SelectedIndexChanged);
			this.offername.Text = "Tên Offer";
			this.offername.Width = 110;
			this.offerurl.Text = "Link Offer";
			this.offerurl.Width = 190;
			this.appname.Text = "Tên ứng dụng";
			this.appname.Width = 112;
			this.timedelay.Text = "T.gian mở App";
			this.timedelay.Width = 90;
			this.usescript.Text = "Thao tác khác";
			this.usescript.Width = 88;
			this.Contact.Controls.Add(this.tabPage1);
			this.Contact.Controls.Add(this.tabPage2);
			this.Contact.Controls.Add(this.tabPage7);
			this.Contact.Controls.Add(this.tabPage8);
			this.Contact.Controls.Add(this.tabPage6);
			this.Contact.Controls.Add(this.Script);
			this.Contact.Controls.Add(this.tabPage9);
			this.Contact.Controls.Add(this.tabPage10);
			this.Contact.Controls.Add(this.tabPage5);
			this.Contact.Location = new global::System.Drawing.Point(12, 12);
			this.Contact.Name = "Contact";
			this.Contact.SelectedIndex = 0;
			this.Contact.Size = new global::System.Drawing.Size(628, 424);
			this.Contact.TabIndex = 0;
			this.Contact.SelectedIndexChanged += new global::System.EventHandler(this.Contact_SelectedIndexChanged);
			this.l_autover.AutoSize = true;
			this.l_autover.Location = new global::System.Drawing.Point(312, 575);
			this.l_autover.Name = "l_autover";
			this.l_autover.Size = new global::System.Drawing.Size(94, 13);
			this.l_autover.TabIndex = 20;
			this.l_autover.Text = "AutoLead Version:";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(654, 638);
			base.Controls.Add(this.l_autover);
			base.Controls.Add(this.autoreconnect);
			base.Controls.Add(this.label12);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.labelSerial);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.DeviceIpControl);
			base.Controls.Add(this.button2);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.Contact);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "Form1";
			this.Text = "Auto Lead for iOS";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown1).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			this.contextMenuStrip2.ResumeLayout(false);
			this.contextMenuStrip3.ResumeLayout(false);
			this.tabPage5.ResumeLayout(false);
			this.tabPage5.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox5).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox4).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
			this.tabPage10.ResumeLayout(false);
			this.tabPage10.PerformLayout();
			this.tabPage9.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			this.groupBox8.PerformLayout();
			this.Script.ResumeLayout(false);
			this.Script.PerformLayout();
			this.tabPage6.ResumeLayout(false);
			this.tabPage6.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.longtitude).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.latitude).EndInit();
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown10).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown5).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown4).EndInit();
			this.groupBox9.ResumeLayout(false);
			this.groupBox9.PerformLayout();
			this.tabPage8.ResumeLayout(false);
			this.tabPage8.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.trackBar1).EndInit();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			this.tabPage7.ResumeLayout(false);
			this.tabPage7.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.rsswaitnum).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.tabControl2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown2).EndInit();
			this.tabPage4.ResumeLayout(false);
			this.tabPage4.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown6).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown3).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.itunesY).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.itunesX).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.safariY).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.safariX).EndInit();
			this.Contact.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000092 RID: 146
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000093 RID: 147
		private global::System.Windows.Forms.Button button1;

		// Token: 0x04000094 RID: 148
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000095 RID: 149
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000096 RID: 150
		private global::System.Windows.Forms.Button button2;

		// Token: 0x04000097 RID: 151
		private global::IPAddressControlLib.IPAddressControl DeviceIpControl;

		// Token: 0x04000098 RID: 152
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000099 RID: 153
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400009A RID: 154
		private global::System.Windows.Forms.ComboBox proxytool;

		// Token: 0x0400009B RID: 155
		private global::System.Windows.Forms.Label label5;

		// Token: 0x0400009C RID: 156
		private global::System.Windows.Forms.Label labelSerial;

		// Token: 0x0400009D RID: 157
		private global::System.Windows.Forms.NumericUpDown numericUpDown1;

		// Token: 0x0400009E RID: 158
		private global::System.Windows.Forms.Label label6;

		// Token: 0x0400009F RID: 159
		private global::System.Windows.Forms.Label label20;

		// Token: 0x040000A0 RID: 160
		private global::System.Windows.Forms.ComboBox comboBox5;

		// Token: 0x040000A1 RID: 161
		private global::System.Windows.Forms.Label label21;

		// Token: 0x040000A2 RID: 162
		private global::IPAddressControlLib.IPAddressControl ipAddressControl1;

		// Token: 0x040000A3 RID: 163
		private global::System.Windows.Forms.Button button23;

		// Token: 0x040000A4 RID: 164
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x040000A5 RID: 165
		private global::System.Windows.Forms.Button button20;

		// Token: 0x040000A6 RID: 166
		private global::System.Windows.Forms.Label label12;

		// Token: 0x040000A7 RID: 167
		private global::System.Windows.Forms.CheckBox autoreconnect;

		// Token: 0x040000A8 RID: 168
		private global::System.Windows.Forms.ContextMenuStrip contextMenuStrip1;

		// Token: 0x040000A9 RID: 169
		private global::System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;

		// Token: 0x040000AA RID: 170
		private global::System.Windows.Forms.ContextMenuStrip contextMenuStrip2;

		// Token: 0x040000AB RID: 171
		private global::System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;

		// Token: 0x040000AC RID: 172
		private global::System.Windows.Forms.ToolStripMenuItem moveToSlotToolStripMenuItem;

		// Token: 0x040000AD RID: 173
		private global::System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;

		// Token: 0x040000AE RID: 174
		private global::System.Windows.Forms.ImageList imageList1;

		// Token: 0x040000AF RID: 175
		private global::System.Windows.Forms.ContextMenuStrip contextMenuStrip3;

		// Token: 0x040000B0 RID: 176
		private global::System.Windows.Forms.ToolStripMenuItem bảoVệDữLiệuToolStripMenuItem;

		// Token: 0x040000B1 RID: 177
		private global::System.Windows.Forms.ContextMenuStrip contextMenuStrip4;

		// Token: 0x040000B2 RID: 178
		private global::System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem2;

		// Token: 0x040000B3 RID: 179
		private global::System.Windows.Forms.TabPage tabPage5;

		// Token: 0x040000B4 RID: 180
		private global::System.Windows.Forms.Label label25;

		// Token: 0x040000B5 RID: 181
		private global::System.Windows.Forms.Label label24;

		// Token: 0x040000B6 RID: 182
		private global::System.Windows.Forms.Label label23;

		// Token: 0x040000B7 RID: 183
		private global::System.Windows.Forms.Label label13;

		// Token: 0x040000B8 RID: 184
		private global::System.Windows.Forms.PictureBox pictureBox5;

		// Token: 0x040000B9 RID: 185
		private global::System.Windows.Forms.PictureBox pictureBox4;

		// Token: 0x040000BA RID: 186
		private global::System.Windows.Forms.PictureBox pictureBox3;

		// Token: 0x040000BB RID: 187
		private global::System.Windows.Forms.PictureBox pictureBox2;

		// Token: 0x040000BC RID: 188
		private global::System.Windows.Forms.TabPage tabPage10;

		// Token: 0x040000BD RID: 189
		private global::System.Windows.Forms.Button button54;

		// Token: 0x040000BE RID: 190
		private global::System.Windows.Forms.CheckBox checkBox16;

		// Token: 0x040000BF RID: 191
		private global::System.Windows.Forms.Button button53;

		// Token: 0x040000C0 RID: 192
		private global::System.Windows.Forms.Button button52;

		// Token: 0x040000C1 RID: 193
		private global::System.Windows.Forms.Button button51;

		// Token: 0x040000C2 RID: 194
		private global::System.Windows.Forms.Button button50;

		// Token: 0x040000C3 RID: 195
		private global::System.Windows.Forms.Button button49;

		// Token: 0x040000C4 RID: 196
		private global::System.Windows.Forms.Button button48;

		// Token: 0x040000C5 RID: 197
		private global::System.Windows.Forms.Button button47;

		// Token: 0x040000C6 RID: 198
		private global::System.Windows.Forms.Button button46;

		// Token: 0x040000C7 RID: 199
		private global::System.Windows.Forms.Button button45;

		// Token: 0x040000C8 RID: 200
		private global::System.Windows.Forms.Button button44;

		// Token: 0x040000C9 RID: 201
		private global::System.Windows.Forms.Button button43;

		// Token: 0x040000CA RID: 202
		private global::System.Windows.Forms.Button button42;

		// Token: 0x040000CB RID: 203
		private global::System.Windows.Forms.Button button41;

		// Token: 0x040000CC RID: 204
		private global::System.Windows.Forms.Button button40;

		// Token: 0x040000CD RID: 205
		private global::System.Windows.Forms.Button button39;

		// Token: 0x040000CE RID: 206
		private global::System.Windows.Forms.Button button38;

		// Token: 0x040000CF RID: 207
		private global::System.Windows.Forms.Button button37;

		// Token: 0x040000D0 RID: 208
		private global::System.Windows.Forms.TabPage tabPage9;

		// Token: 0x040000D1 RID: 209
		private global::System.Windows.Forms.GroupBox groupBox8;

		// Token: 0x040000D2 RID: 210
		private global::System.Windows.Forms.Label napcodestt;

		// Token: 0x040000D3 RID: 211
		private global::System.Windows.Forms.TextBox deviceseri;

		// Token: 0x040000D4 RID: 212
		private global::System.Windows.Forms.Button button36;

		// Token: 0x040000D5 RID: 213
		private global::System.Windows.Forms.Label label36;

		// Token: 0x040000D6 RID: 214
		private global::System.Windows.Forms.TextBox code;

		// Token: 0x040000D7 RID: 215
		private global::System.Windows.Forms.Label label37;

		// Token: 0x040000D8 RID: 216
		private global::System.Windows.Forms.TabPage Script;

		// Token: 0x040000D9 RID: 217
		private global::System.Windows.Forms.TextBox textBox9;

		// Token: 0x040000DA RID: 218
		private global::System.Windows.Forms.Label label33;

		// Token: 0x040000DB RID: 219
		private global::System.Windows.Forms.Button button34;

		// Token: 0x040000DC RID: 220
		private global::System.Windows.Forms.Button button33;

		// Token: 0x040000DD RID: 221
		private global::System.Windows.Forms.Button button32;

		// Token: 0x040000DE RID: 222
		private global::System.Windows.Forms.ListView listView7;

		// Token: 0x040000DF RID: 223
		private global::System.Windows.Forms.ColumnHeader columnHeader14;

		// Token: 0x040000E0 RID: 224
		private global::System.Windows.Forms.TextBox textBox6;

		// Token: 0x040000E1 RID: 225
		private global::System.Windows.Forms.ListView listView6;

		// Token: 0x040000E2 RID: 226
		private global::System.Windows.Forms.ColumnHeader columnHeader13;

		// Token: 0x040000E3 RID: 227
		private global::System.Windows.Forms.TabPage tabPage6;

		// Token: 0x040000E4 RID: 228
		private global::System.Windows.Forms.TextBox textBox5;

		// Token: 0x040000E5 RID: 229
		private global::System.Windows.Forms.ListView listView5;

		// Token: 0x040000E6 RID: 230
		private global::System.Windows.Forms.GroupBox groupBox6;

		// Token: 0x040000E7 RID: 231
		private global::System.Windows.Forms.CheckBox checkBox20;

		// Token: 0x040000E8 RID: 232
		private global::System.Windows.Forms.NumericUpDown longtitude;

		// Token: 0x040000E9 RID: 233
		private global::System.Windows.Forms.Label ltimezone;

		// Token: 0x040000EA RID: 234
		private global::System.Windows.Forms.CheckBox checkBox19;

		// Token: 0x040000EB RID: 235
		private global::System.Windows.Forms.CheckBox checkBox13;

		// Token: 0x040000EC RID: 236
		private global::System.Windows.Forms.Label label41;

		// Token: 0x040000ED RID: 237
		private global::System.Windows.Forms.CheckBox checkBox5;

		// Token: 0x040000EE RID: 238
		private global::System.Windows.Forms.Label label40;

		// Token: 0x040000EF RID: 239
		private global::System.Windows.Forms.CheckBox checkBox9;

		// Token: 0x040000F0 RID: 240
		private global::System.Windows.Forms.NumericUpDown latitude;

		// Token: 0x040000F1 RID: 241
		private global::System.Windows.Forms.ComboBox carrierBox;

		// Token: 0x040000F2 RID: 242
		private global::System.Windows.Forms.CheckBox fakelang;

		// Token: 0x040000F3 RID: 243
		private global::System.Windows.Forms.ComboBox comboBox2;

		// Token: 0x040000F4 RID: 244
		private global::System.Windows.Forms.ComboBox comboBox1;

		// Token: 0x040000F5 RID: 245
		private global::System.Windows.Forms.GroupBox groupBox7;

		// Token: 0x040000F6 RID: 246
		private global::System.Windows.Forms.Label label63;

		// Token: 0x040000F7 RID: 247
		private global::System.Windows.Forms.Label label43;

		// Token: 0x040000F8 RID: 248
		private global::System.Windows.Forms.NumericUpDown numericUpDown10;

		// Token: 0x040000F9 RID: 249
		private global::System.Windows.Forms.Label label31;

		// Token: 0x040000FA RID: 250
		private global::System.Windows.Forms.Label label32;

		// Token: 0x040000FB RID: 251
		private global::System.Windows.Forms.NumericUpDown numericUpDown5;

		// Token: 0x040000FC RID: 252
		private global::System.Windows.Forms.CheckBox checkBox4;

		// Token: 0x040000FD RID: 253
		private global::System.Windows.Forms.NumericUpDown numericUpDown4;

		// Token: 0x040000FE RID: 254
		private global::System.Windows.Forms.Label label30;

		// Token: 0x040000FF RID: 255
		private global::System.Windows.Forms.GroupBox groupBox9;

		// Token: 0x04000100 RID: 256
		private global::System.Windows.Forms.CheckBox fakeversion;

		// Token: 0x04000101 RID: 257
		private global::System.Windows.Forms.CheckBox iphone;

		// Token: 0x04000102 RID: 258
		private global::System.Windows.Forms.CheckBox ipad;

		// Token: 0x04000103 RID: 259
		private global::System.Windows.Forms.CheckBox ipod;

		// Token: 0x04000104 RID: 260
		private global::System.Windows.Forms.CheckBox checkBox11;

		// Token: 0x04000105 RID: 261
		private global::System.Windows.Forms.CheckBox fakemodel;

		// Token: 0x04000106 RID: 262
		private global::System.Windows.Forms.Label fileofname;

		// Token: 0x04000107 RID: 263
		private global::System.Windows.Forms.CheckBox fakedevice;

		// Token: 0x04000108 RID: 264
		private global::System.Windows.Forms.CheckBox checkBox15;

		// Token: 0x04000109 RID: 265
		private global::System.Windows.Forms.CheckBox checkBox14;

		// Token: 0x0400010A RID: 266
		private global::System.Windows.Forms.TabPage tabPage8;

		// Token: 0x0400010B RID: 267
		private global::System.Windows.Forms.RichTextBox textBox2;

		// Token: 0x0400010C RID: 268
		private global::System.Windows.Forms.Button button64;

		// Token: 0x0400010D RID: 269
		private global::System.Windows.Forms.Button button35;

		// Token: 0x0400010E RID: 270
		private global::System.Windows.Forms.Button button30;

		// Token: 0x0400010F RID: 271
		private global::System.Windows.Forms.TrackBar trackBar1;

		// Token: 0x04000110 RID: 272
		private global::System.Windows.Forms.GroupBox groupBox4;

		// Token: 0x04000111 RID: 273
		private global::System.Windows.Forms.Button button11;

		// Token: 0x04000112 RID: 274
		private global::System.Windows.Forms.TextBox textBox1;

		// Token: 0x04000113 RID: 275
		private global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x04000114 RID: 276
		private global::System.Windows.Forms.Button button26;

		// Token: 0x04000115 RID: 277
		private global::System.Windows.Forms.TextBox textBox7;

		// Token: 0x04000116 RID: 278
		private global::System.Windows.Forms.Label label18;

		// Token: 0x04000117 RID: 279
		private global::System.Windows.Forms.Label label19;

		// Token: 0x04000118 RID: 280
		private global::System.Windows.Forms.TextBox textBox8;

		// Token: 0x04000119 RID: 281
		private global::System.Windows.Forms.TextBox textBox3;

		// Token: 0x0400011A RID: 282
		private global::System.Windows.Forms.Button button18;

		// Token: 0x0400011B RID: 283
		private global::System.Windows.Forms.GroupBox groupBox5;

		// Token: 0x0400011C RID: 284
		private global::System.Windows.Forms.Button button28;

		// Token: 0x0400011D RID: 285
		private global::System.Windows.Forms.Label label11;

		// Token: 0x0400011E RID: 286
		private global::System.Windows.Forms.Button button13;

		// Token: 0x0400011F RID: 287
		private global::System.Windows.Forms.Button button12;

		// Token: 0x04000120 RID: 288
		private global::System.Windows.Forms.Button button10;

		// Token: 0x04000121 RID: 289
		private global::System.Windows.Forms.ComboBox wipecombo;

		// Token: 0x04000122 RID: 290
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x04000123 RID: 291
		private global::System.Windows.Forms.TabPage tabPage7;

		// Token: 0x04000124 RID: 292
		private global::System.Windows.Forms.Label label35;

		// Token: 0x04000125 RID: 293
		private global::System.Windows.Forms.Label label34;

		// Token: 0x04000126 RID: 294
		private global::System.Windows.Forms.CheckBox checkBox7;

		// Token: 0x04000127 RID: 295
		private global::System.Windows.Forms.ComboBox comboBox3;

		// Token: 0x04000128 RID: 296
		private global::System.Windows.Forms.CheckBox checkBox6;

		// Token: 0x04000129 RID: 297
		private global::System.Windows.Forms.Button button31;

		// Token: 0x0400012A RID: 298
		private global::System.Windows.Forms.Label label26;

		// Token: 0x0400012B RID: 299
		private global::System.Windows.Forms.TextBox textBox4;

		// Token: 0x0400012C RID: 300
		private global::System.Windows.Forms.Button button29;

		// Token: 0x0400012D RID: 301
		private global::System.Windows.Forms.Button button27;

		// Token: 0x0400012E RID: 302
		private global::System.Windows.Forms.Label label9;

		// Token: 0x0400012F RID: 303
		private global::System.Windows.Forms.NumericUpDown rsswaitnum;

		// Token: 0x04000130 RID: 304
		private global::System.Windows.Forms.Label label8;

		// Token: 0x04000131 RID: 305
		private global::System.Windows.Forms.Button bkreset;

		// Token: 0x04000132 RID: 306
		private global::System.Windows.Forms.Button button19;

		// Token: 0x04000133 RID: 307
		private global::System.Windows.Forms.Button button17;

		// Token: 0x04000134 RID: 308
		private global::System.Windows.Forms.Button button16;

		// Token: 0x04000135 RID: 309
		private global::System.Windows.Forms.Button button15;

		// Token: 0x04000136 RID: 310
		private global::System.Windows.Forms.ListView listView4;

		// Token: 0x04000137 RID: 311
		private global::System.Windows.Forms.ColumnHeader columnHeader10;

		// Token: 0x04000138 RID: 312
		private global::System.Windows.Forms.ColumnHeader columnHeader7;

		// Token: 0x04000139 RID: 313
		private global::System.Windows.Forms.ColumnHeader columnHeader11;

		// Token: 0x0400013A RID: 314
		private global::System.Windows.Forms.ColumnHeader columnHeader12;

		// Token: 0x0400013B RID: 315
		private global::System.Windows.Forms.ColumnHeader columnHeader8;

		// Token: 0x0400013C RID: 316
		private global::System.Windows.Forms.ColumnHeader columnHeader9;

		// Token: 0x0400013D RID: 317
		private global::System.Windows.Forms.ColumnHeader columnHeader15;

		// Token: 0x0400013E RID: 318
		private global::System.Windows.Forms.ColumnHeader columnHeader16;

		// Token: 0x0400013F RID: 319
		private global::System.Windows.Forms.TabPage tabPage2;

		// Token: 0x04000140 RID: 320
		private global::System.Windows.Forms.TabControl tabControl2;

		// Token: 0x04000141 RID: 321
		private global::System.Windows.Forms.TabPage tabPage3;

		// Token: 0x04000142 RID: 322
		private global::System.Windows.Forms.CheckBox checkBox17;

		// Token: 0x04000143 RID: 323
		private global::System.Windows.Forms.Label ss_dead;

		// Token: 0x04000144 RID: 324
		private global::System.Windows.Forms.Label ssh_used;

		// Token: 0x04000145 RID: 325
		private global::System.Windows.Forms.Label ssh_live;

		// Token: 0x04000146 RID: 326
		private global::System.Windows.Forms.Label ssh_uncheck;

		// Token: 0x04000147 RID: 327
		private global::System.Windows.Forms.NumericUpDown numericUpDown2;

		// Token: 0x04000148 RID: 328
		private global::System.Windows.Forms.Label label14;

		// Token: 0x04000149 RID: 329
		private global::System.Windows.Forms.Label labeltotalssh;

		// Token: 0x0400014A RID: 330
		private global::System.Windows.Forms.Button button25;

		// Token: 0x0400014B RID: 331
		private global::System.Windows.Forms.Button button24;

		// Token: 0x0400014C RID: 332
		private global::System.Windows.Forms.Button button22;

		// Token: 0x0400014D RID: 333
		private global::System.Windows.Forms.Button button8;

		// Token: 0x0400014E RID: 334
		private global::System.Windows.Forms.Button button14;

		// Token: 0x0400014F RID: 335
		private global::System.Windows.Forms.Button button9;

		// Token: 0x04000150 RID: 336
		private global::System.Windows.Forms.Button importfromfile;

		// Token: 0x04000151 RID: 337
		private global::System.Windows.Forms.ListView listView2;

		// Token: 0x04000152 RID: 338
		private global::System.Windows.Forms.ColumnHeader columnHeader1;

		// Token: 0x04000153 RID: 339
		private global::System.Windows.Forms.ColumnHeader columnHeader2;

		// Token: 0x04000154 RID: 340
		private global::System.Windows.Forms.ColumnHeader columnHeader3;

		// Token: 0x04000155 RID: 341
		private global::System.Windows.Forms.ColumnHeader columnHeader4;

		// Token: 0x04000156 RID: 342
		private global::System.Windows.Forms.TabPage tabPage4;

		// Token: 0x04000157 RID: 343
		private global::System.Windows.Forms.CheckBox sameVip;

		// Token: 0x04000158 RID: 344
		private global::System.Windows.Forms.Button button57;

		// Token: 0x04000159 RID: 345
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x0400015A RID: 346
		private global::System.Windows.Forms.TextBox vippassword;

		// Token: 0x0400015B RID: 347
		private global::System.Windows.Forms.TextBox vipid;

		// Token: 0x0400015C RID: 348
		private global::System.Windows.Forms.Label label10;

		// Token: 0x0400015D RID: 349
		private global::System.Windows.Forms.Label label7;

		// Token: 0x0400015E RID: 350
		private global::System.Windows.Forms.Button vipadd;

		// Token: 0x0400015F RID: 351
		private global::System.Windows.Forms.Button vipdelete;

		// Token: 0x04000160 RID: 352
		private global::System.Windows.Forms.ListView listView3;

		// Token: 0x04000161 RID: 353
		private global::System.Windows.Forms.ColumnHeader columnHeader5;

		// Token: 0x04000162 RID: 354
		private global::System.Windows.Forms.ColumnHeader columnHeader6;

		// Token: 0x04000163 RID: 355
		private global::System.Windows.Forms.TabPage tabPage1;

		// Token: 0x04000164 RID: 356
		private global::System.Windows.Forms.TextBox textBox11;

		// Token: 0x04000165 RID: 357
		private global::System.Windows.Forms.TextBox comment;

		// Token: 0x04000166 RID: 358
		private global::System.Windows.Forms.Label label44;

		// Token: 0x04000167 RID: 359
		private global::System.Windows.Forms.CheckBox checkBox18;

		// Token: 0x04000168 RID: 360
		private global::System.Windows.Forms.CheckBox checkBox12;

		// Token: 0x04000169 RID: 361
		private global::System.Windows.Forms.NumericUpDown numericUpDown6;

		// Token: 0x0400016A RID: 362
		private global::System.Windows.Forms.CheckBox checkBox10;

		// Token: 0x0400016B RID: 363
		private global::System.Windows.Forms.Label backuprate;

		// Token: 0x0400016C RID: 364
		private global::System.Windows.Forms.Label backupoftime;

		// Token: 0x0400016D RID: 365
		private global::System.Windows.Forms.Label runoftime;

		// Token: 0x0400016E RID: 366
		private global::System.Windows.Forms.Label label29;

		// Token: 0x0400016F RID: 367
		private global::System.Windows.Forms.Label label28;

		// Token: 0x04000170 RID: 368
		private global::System.Windows.Forms.NumericUpDown numericUpDown3;

		// Token: 0x04000171 RID: 369
		private global::System.Windows.Forms.Label label27;

		// Token: 0x04000172 RID: 370
		private global::System.Windows.Forms.NumericUpDown itunesY;

		// Token: 0x04000173 RID: 371
		private global::System.Windows.Forms.Label label22;

		// Token: 0x04000174 RID: 372
		private global::System.Windows.Forms.NumericUpDown itunesX;

		// Token: 0x04000175 RID: 373
		private global::System.Windows.Forms.Label label17;

		// Token: 0x04000176 RID: 374
		private global::System.Windows.Forms.NumericUpDown safariY;

		// Token: 0x04000177 RID: 375
		private global::System.Windows.Forms.Label label16;

		// Token: 0x04000178 RID: 376
		private global::System.Windows.Forms.NumericUpDown safariX;

		// Token: 0x04000179 RID: 377
		private global::System.Windows.Forms.Label label15;

		// Token: 0x0400017A RID: 378
		private global::System.Windows.Forms.Button button21;

		// Token: 0x0400017B RID: 379
		private global::System.Windows.Forms.Button Reset;

		// Token: 0x0400017C RID: 380
		private global::System.Windows.Forms.CheckBox checkBox3;

		// Token: 0x0400017D RID: 381
		private global::System.Windows.Forms.CheckBox checkBox2;

		// Token: 0x0400017E RID: 382
		private global::System.Windows.Forms.Button button7;

		// Token: 0x0400017F RID: 383
		private global::System.Windows.Forms.CheckBox checkBox1;

		// Token: 0x04000180 RID: 384
		private global::System.Windows.Forms.Button button6;

		// Token: 0x04000181 RID: 385
		private global::System.Windows.Forms.Button button5;

		// Token: 0x04000182 RID: 386
		private global::System.Windows.Forms.Button button4;

		// Token: 0x04000183 RID: 387
		private global::System.Windows.Forms.Button button3;

		// Token: 0x04000184 RID: 388
		private global::System.Windows.Forms.ListView listView1;

		// Token: 0x04000185 RID: 389
		private global::System.Windows.Forms.ColumnHeader offername;

		// Token: 0x04000186 RID: 390
		private global::System.Windows.Forms.ColumnHeader offerurl;

		// Token: 0x04000187 RID: 391
		private global::System.Windows.Forms.ColumnHeader appname;

		// Token: 0x04000188 RID: 392
		private global::System.Windows.Forms.ColumnHeader timedelay;

		// Token: 0x04000189 RID: 393
		private global::System.Windows.Forms.ColumnHeader usescript;

		// Token: 0x0400018A RID: 394
		private global::System.Windows.Forms.TabControl Contact;

		// Token: 0x0400018B RID: 395
		private global::System.Windows.Forms.CheckBox fakeregion;

		// Token: 0x0400018C RID: 396
		private global::System.Windows.Forms.Button pausescript;

		// Token: 0x0400018D RID: 397
		private global::System.Windows.Forms.Label l_autover;
	}
}
