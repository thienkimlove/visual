namespace AutoLead
{
	// Token: 0x0200005B RID: 91
	public partial class OfferOption : global::System.Windows.Forms.Form
	{
		// Token: 0x060003B0 RID: 944 RVA: 0x00026040 File Offset: 0x00024240
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x00026078 File Offset: 0x00024278
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::AutoLead.OfferOption));
			this.label1 = new global::System.Windows.Forms.Label();
			this.textBox1 = new global::System.Windows.Forms.TextBox();
			this.checkBox1 = new global::System.Windows.Forms.CheckBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.textBox2 = new global::System.Windows.Forms.TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.comboBox1 = new global::System.Windows.Forms.ComboBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.checkBox2 = new global::System.Windows.Forms.CheckBox();
			this.textBox4 = new global::System.Windows.Forms.TextBox();
			this.button1 = new global::System.Windows.Forms.Button();
			this.button2 = new global::System.Windows.Forms.Button();
			this.button3 = new global::System.Windows.Forms.Button();
			this.label5 = new global::System.Windows.Forms.Label();
			this.numericUpDown1 = new global::System.Windows.Forms.NumericUpDown();
			this.label7 = new global::System.Windows.Forms.Label();
			this.numericUpDown2 = new global::System.Windows.Forms.NumericUpDown();
			this.label8 = new global::System.Windows.Forms.Label();
			this.checkBox3 = new global::System.Windows.Forms.CheckBox();
			this.numericUpDown3 = new global::System.Windows.Forms.NumericUpDown();
			this.label9 = new global::System.Windows.Forms.Label();
			this.numericUpDown4 = new global::System.Windows.Forms.NumericUpDown();
			this.label10 = new global::System.Windows.Forms.Label();
			this.label11 = new global::System.Windows.Forms.Label();
			this.Referer = new global::System.Windows.Forms.Label();
			this.textBox3 = new global::System.Windows.Forms.TextBox();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown1).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown2).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown3).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown4).BeginInit();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(32, 19);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(62, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Offer name:";
			this.textBox1.Location = new global::System.Drawing.Point(110, 16);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new global::System.Drawing.Size(100, 20);
			this.textBox1.TabIndex = 1;
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new global::System.Drawing.Point(304, 18);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new global::System.Drawing.Size(59, 17);
			this.checkBox1.TabIndex = 2;
			this.checkBox1.Text = "Enable";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(32, 44);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(58, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Offer URL:";
			this.textBox2.Location = new global::System.Drawing.Point(37, 60);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new global::System.Drawing.Size(378, 31);
			this.textBox2.TabIndex = 4;
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(32, 269);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(51, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Tên App:";
			this.comboBox1.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new global::System.Drawing.Point(89, 265);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new global::System.Drawing.Size(121, 21);
			this.comboBox1.Sorted = true;
			this.comboBox1.TabIndex = 6;
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(32, 304);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(119, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Thời gian mở ứng dụng:";
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new global::System.Drawing.Point(35, 343);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new global::System.Drawing.Size(260, 17);
			this.checkBox2.TabIndex = 9;
			this.checkBox2.Text = "Sử dụng script sau khi hết thời gian mở ứng dụng:";
			this.checkBox2.UseVisualStyleBackColor = true;
			this.textBox4.Location = new global::System.Drawing.Point(35, 366);
			this.textBox4.Multiline = true;
			this.textBox4.Name = "textBox4";
			this.textBox4.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
			this.textBox4.Size = new global::System.Drawing.Size(369, 99);
			this.textBox4.TabIndex = 10;
			this.textBox4.Text = "Touch(x,y)\r\nSwipe(x1,y1,x2,y2)\r\nSend(\"text\")\r\nWait(sec)";
			this.button1.Location = new global::System.Drawing.Point(218, 483);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(75, 23);
			this.button1.TabIndex = 11;
			this.button1.Text = "OK";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.button2.Location = new global::System.Drawing.Point(340, 483);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(75, 23);
			this.button2.TabIndex = 12;
			this.button2.Text = "Cancel";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			this.button3.Enabled = false;
			this.button3.Location = new global::System.Drawing.Point(231, 269);
			this.button3.Name = "button3";
			this.button3.Size = new global::System.Drawing.Size(75, 23);
			this.button3.TabIndex = 13;
			this.button3.Text = "Get List App:";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new global::System.EventHandler(this.button3_Click);
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(228, 304);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(26, 13);
			this.label5.TabIndex = 14;
			this.label5.Text = "Sec";
			this.numericUpDown1.Location = new global::System.Drawing.Point(167, 302);
			global::System.Windows.Forms.NumericUpDown arg_7BD_0 = this.numericUpDown1;
			int[] expr_7B0 = new int[4];
			expr_7B0[0] = 9999;
			arg_7BD_0.Maximum = new decimal(expr_7B0);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new global::System.Drawing.Size(55, 20);
			this.numericUpDown1.TabIndex = 15;
			global::System.Windows.Forms.NumericUpDown arg_80D_0 = this.numericUpDown1;
			int[] expr_803 = new int[4];
			expr_803[0] = 20;
			arg_80D_0.Value = new decimal(expr_803);
			this.label7.AutoSize = true;
			this.label7.Location = new global::System.Drawing.Point(32, 205);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(118, 13);
			this.label7.TabIndex = 17;
			this.label7.Text = "Thời gian mở AppStore:";
			this.numericUpDown2.Location = new global::System.Drawing.Point(174, 203);
			global::System.Windows.Forms.NumericUpDown arg_8B1_0 = this.numericUpDown2;
			int[] expr_8A4 = new int[4];
			expr_8A4[0] = 1000;
			arg_8B1_0.Maximum = new decimal(expr_8A4);
			this.numericUpDown2.Name = "numericUpDown2";
			this.numericUpDown2.Size = new global::System.Drawing.Size(48, 20);
			this.numericUpDown2.TabIndex = 18;
			global::System.Windows.Forms.NumericUpDown arg_901_0 = this.numericUpDown2;
			int[] expr_8F7 = new int[4];
			expr_8F7[0] = 10;
			arg_901_0.Value = new decimal(expr_8F7);
			this.label8.AutoSize = true;
			this.label8.Location = new global::System.Drawing.Point(228, 205);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(26, 13);
			this.label8.TabIndex = 19;
			this.label8.Text = "Sec";
			this.checkBox3.AutoSize = true;
			this.checkBox3.Location = new global::System.Drawing.Point(35, 234);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new global::System.Drawing.Size(110, 17);
			this.checkBox3.TabIndex = 20;
			this.checkBox3.Text = "Ngẫu nhiên mở từ";
			this.checkBox3.UseVisualStyleBackColor = true;
			this.checkBox3.CheckedChanged += new global::System.EventHandler(this.checkBox3_CheckedChanged);
			this.numericUpDown3.Enabled = false;
			this.numericUpDown3.Location = new global::System.Drawing.Point(147, 232);
			this.numericUpDown3.Name = "numericUpDown3";
			this.numericUpDown3.Size = new global::System.Drawing.Size(52, 20);
			this.numericUpDown3.TabIndex = 21;
			global::System.Windows.Forms.NumericUpDown arg_A74_0 = this.numericUpDown3;
			int[] expr_A6B = new int[4];
			expr_A6B[0] = 2;
			arg_A74_0.Value = new decimal(expr_A6B);
			this.label9.AutoSize = true;
			this.label9.Location = new global::System.Drawing.Point(237, 234);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(27, 13);
			this.label9.TabIndex = 22;
			this.label9.Text = "Đến";
			this.numericUpDown4.Enabled = false;
			this.numericUpDown4.Location = new global::System.Drawing.Point(266, 231);
			global::System.Windows.Forms.NumericUpDown arg_B28_0 = this.numericUpDown4;
			int[] expr_B1B = new int[4];
			expr_B1B[0] = 1000;
			arg_B28_0.Maximum = new decimal(expr_B1B);
			this.numericUpDown4.Name = "numericUpDown4";
			this.numericUpDown4.Size = new global::System.Drawing.Size(46, 20);
			this.numericUpDown4.TabIndex = 23;
			global::System.Windows.Forms.NumericUpDown arg_B78_0 = this.numericUpDown4;
			int[] expr_B6E = new int[4];
			expr_B6E[0] = 60;
			arg_B78_0.Value = new decimal(expr_B6E);
			this.label10.AutoSize = true;
			this.label10.Location = new global::System.Drawing.Point(205, 234);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(28, 13);
			this.label10.TabIndex = 24;
			this.label10.Text = "Giây";
			this.label11.AutoSize = true;
			this.label11.Location = new global::System.Drawing.Point(318, 234);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(28, 13);
			this.label11.TabIndex = 25;
			this.label11.Text = "Giây";
			this.Referer.AutoSize = true;
			this.Referer.Location = new global::System.Drawing.Point(32, 101);
			this.Referer.Name = "Referer";
			this.Referer.Size = new global::System.Drawing.Size(45, 13);
			this.Referer.TabIndex = 26;
			this.Referer.Text = "Referer:";
			this.textBox3.Location = new global::System.Drawing.Point(35, 117);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
			this.textBox3.Size = new global::System.Drawing.Size(378, 65);
			this.textBox3.TabIndex = 27;
			this.textBox3.Text = "https://google.com\r\nhttps://bing.com\r\nhttps://facebook.com\r\nhttps://yahoo.com";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(442, 524);
			base.Controls.Add(this.textBox3);
			base.Controls.Add(this.Referer);
			base.Controls.Add(this.label11);
			base.Controls.Add(this.label10);
			base.Controls.Add(this.numericUpDown4);
			base.Controls.Add(this.label9);
			base.Controls.Add(this.numericUpDown3);
			base.Controls.Add(this.checkBox3);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.numericUpDown2);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.numericUpDown1);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.button3);
			base.Controls.Add(this.button2);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.textBox4);
			base.Controls.Add(this.checkBox2);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.comboBox1);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.textBox2);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.checkBox1);
			base.Controls.Add(this.textBox1);
			base.Controls.Add(this.label1);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "OfferOption";
			this.Text = "OfferOption";
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown1).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown2).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown3).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown4).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040002E4 RID: 740
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040002E5 RID: 741
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040002E6 RID: 742
		private global::System.Windows.Forms.TextBox textBox1;

		// Token: 0x040002E7 RID: 743
		private global::System.Windows.Forms.CheckBox checkBox1;

		// Token: 0x040002E8 RID: 744
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040002E9 RID: 745
		private global::System.Windows.Forms.TextBox textBox2;

		// Token: 0x040002EA RID: 746
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040002EB RID: 747
		private global::System.Windows.Forms.ComboBox comboBox1;

		// Token: 0x040002EC RID: 748
		private global::System.Windows.Forms.Label label4;

		// Token: 0x040002ED RID: 749
		private global::System.Windows.Forms.CheckBox checkBox2;

		// Token: 0x040002EE RID: 750
		private global::System.Windows.Forms.TextBox textBox4;

		// Token: 0x040002EF RID: 751
		private global::System.Windows.Forms.Button button1;

		// Token: 0x040002F0 RID: 752
		private global::System.Windows.Forms.Button button2;

		// Token: 0x040002F1 RID: 753
		private global::System.Windows.Forms.Button button3;

		// Token: 0x040002F2 RID: 754
		private global::System.Windows.Forms.Label label5;

		// Token: 0x040002F3 RID: 755
		private global::System.Windows.Forms.NumericUpDown numericUpDown1;

		// Token: 0x040002F4 RID: 756
		private global::System.Windows.Forms.Label label7;

		// Token: 0x040002F5 RID: 757
		private global::System.Windows.Forms.NumericUpDown numericUpDown2;

		// Token: 0x040002F6 RID: 758
		private global::System.Windows.Forms.Label label8;

		// Token: 0x040002F7 RID: 759
		private global::System.Windows.Forms.CheckBox checkBox3;

		// Token: 0x040002F8 RID: 760
		private global::System.Windows.Forms.NumericUpDown numericUpDown3;

		// Token: 0x040002F9 RID: 761
		private global::System.Windows.Forms.Label label9;

		// Token: 0x040002FA RID: 762
		private global::System.Windows.Forms.NumericUpDown numericUpDown4;

		// Token: 0x040002FB RID: 763
		private global::System.Windows.Forms.Label label10;

		// Token: 0x040002FC RID: 764
		private global::System.Windows.Forms.Label label11;

		// Token: 0x040002FD RID: 765
		private global::System.Windows.Forms.Label Referer;

		// Token: 0x040002FE RID: 766
		private global::System.Windows.Forms.TextBox textBox3;
	}
}
