namespace AutoLead
{
	// Token: 0x02000012 RID: 18
	public partial class DownloadProgress : global::System.Windows.Forms.Form
	{
		// Token: 0x06000080 RID: 128 RVA: 0x00005814 File Offset: 0x00003A14
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000081 RID: 129 RVA: 0x0000584C File Offset: 0x00003A4C
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::AutoLead.DownloadProgress));
			this.progressBar1 = new global::System.Windows.Forms.ProgressBar();
			base.SuspendLayout();
			this.progressBar1.Location = new global::System.Drawing.Point(39, 26);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new global::System.Drawing.Size(284, 23);
			this.progressBar1.TabIndex = 0;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(362, 81);
			base.Controls.Add(this.progressBar1);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "DownloadProgress";
			this.Text = "DownloadProgress";
			base.ResumeLayout(false);
		}

		// Token: 0x04000038 RID: 56
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000039 RID: 57
		public global::System.Windows.Forms.ProgressBar progressBar1;
	}
}
