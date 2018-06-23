using System;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Routrek.SSHC;

namespace AutoLead
{
	// Token: 0x02000062 RID: 98
	public class Reader : ISSHConnectionEventReceiver, ISSHChannelEventReceiver
	{
		// Token: 0x060003D5 RID: 981 RVA: 0x00027434 File Offset: 0x00025634
		public void SetHTTPRequestTimeout()
		{
			this.StartRequest = DateTime.Now;
			int i = SshChecker._sshTimeOut;
			while (i > 0)
			{
				i--;
				Thread.Sleep(1000);
				DateTime arg_2A_0 = this.EndRequest;
				bool flag = true;
				if (flag)
				{
					break;
				}
			}
			bool arg_4A_0;
			if (i <= 0)
			{
				DateTime arg_45_0 = this.EndRequest;
				arg_4A_0 = false;
			}
			else
			{
				arg_4A_0 = false;
			}
			bool flag2 = arg_4A_0;
			if (flag2)
			{
				try
				{
					this._conn.CancelForwardedPort("localhost", 80);
				}
				catch
				{
				}
				try
				{
					this._pf.Close();
				}
				catch
				{
				}
				try
				{
					this._conn.Disconnect("");
				}
				catch
				{
				}
				try
				{
					this._conn.Close();
				}
				catch
				{
				}
				throw new Exception("SSH Connect Timeout");
			}
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x00027534 File Offset: 0x00025734
		public void OnData(byte[] data, int offset, int length)
		{
			this.EndRequest = DateTime.Now;
			TimeSpan timeSpan = this.EndRequest - this.StartRequest;
			string @string = Encoding.ASCII.GetString(data, offset, length);
			bool flag = @string.Length > 0;
			try
			{
				this._conn.CancelForwardedPort("localhost", 80);
			}
			catch
			{
			}
			try
			{
				this._pf.Close();
			}
			catch
			{
			}
			try
			{
				this._conn.Disconnect("");
			}
			catch
			{
			}
			try
			{
				this._conn.Close();
			}
			catch
			{
			}
			Match match = Regex.Match(@string, "\"country\"\\:\\s?\"(?<country>[^\"]+)\"", RegexOptions.IgnoreCase | RegexOptions.Multiline);
			bool success = match.Success;
			if (success)
			{
				string value = match.Groups["country"].Value;
			}
			match = Regex.Match(@string, "\"region\"\\:\\s?\"(?<region>[^\"]+)\"", RegexOptions.IgnoreCase | RegexOptions.Multiline);
			bool success2 = match.Success;
			if (success2)
			{
				string value2 = match.Groups["region"].Value;
			}
			match = Regex.Match(@string, "\"city\"\\:\\s?\"(?<city>[^\"]+)\"", RegexOptions.IgnoreCase | RegexOptions.Multiline);
			bool success3 = match.Success;
			if (success3)
			{
				string value3 = match.Groups["city"].Value;
			}
			bool flag2 = !flag;
			if (flag2)
			{
				throw new Exception("HTTP Response is empty");
			}
			SshChecker.checkDone = true;
			bool flag3 = flag;
			if (flag3)
			{
				SshChecker.isFresh = true;
			}
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x00003790 File Offset: 0x00001990
		public void OnDebugMessage(bool always_display, byte[] data)
		{
			Debug.WriteLine("DEBUG: " + Encoding.ASCII.GetString(data));
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x000037AE File Offset: 0x000019AE
		public void OnIgnoreMessage(byte[] data)
		{
			Debug.WriteLine("Ignore: " + Encoding.ASCII.GetString(data));
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x000037CC File Offset: 0x000019CC
		public void OnAuthenticationPrompt(string[] msg)
		{
			Debug.WriteLine("Auth Prompt " + msg[0]);
		}

		// Token: 0x060003DA RID: 986 RVA: 0x000037E2 File Offset: 0x000019E2
		public void OnError(Exception error, string msg)
		{
			Debug.WriteLine("ERROR: " + msg);
		}

		// Token: 0x060003DB RID: 987 RVA: 0x000037F6 File Offset: 0x000019F6
		public void OnChannelClosed()
		{
			Debug.WriteLine("Channel closed");
			this._conn.Disconnect("");
		}

		// Token: 0x060003DC RID: 988 RVA: 0x00003815 File Offset: 0x00001A15
		public void OnChannelEOF()
		{
			this._pf.Close();
			Debug.WriteLine("Channel EOF");
		}

		// Token: 0x060003DD RID: 989 RVA: 0x0000382F File Offset: 0x00001A2F
		public void OnExtendedData(int type, byte[] data)
		{
			Debug.WriteLine("EXTENDED DATA");
		}

		// Token: 0x060003DE RID: 990 RVA: 0x0000383D File Offset: 0x00001A3D
		public void OnConnectionClosed()
		{
			Debug.WriteLine("Connection closed");
		}

		// Token: 0x060003DF RID: 991 RVA: 0x0000384B File Offset: 0x00001A4B
		public void OnUnknownMessage(byte type, byte[] data)
		{
			Debug.WriteLine("Unknown Message " + type);
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x00003864 File Offset: 0x00001A64
		public void OnChannelReady()
		{
			this._ready = true;
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x0000386E File Offset: 0x00001A6E
		public void OnChannelError(Exception error, string msg)
		{
			Debug.WriteLine("Channel ERROR: " + msg);
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x000021A5 File Offset: 0x000003A5
		public void OnMiscPacket(byte type, byte[] data, int offset, int length)
		{
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x000276E8 File Offset: 0x000258E8
		public PortForwardingCheckResult CheckPortForwardingRequest(string host, int port, string originator_host, int originator_port)
		{
			return new PortForwardingCheckResult
			{
				allowed = true,
				channel = this
			};
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x00003882 File Offset: 0x00001A82
		public void EstablishPortforwarding(ISSHChannelEventReceiver rec, SSHChannel channel)
		{
			this._pf = channel;
		}

		// Token: 0x04000314 RID: 788
		public SSHConnection _conn;

		// Token: 0x04000315 RID: 789
		public SSHChannel _pf;

		// Token: 0x04000316 RID: 790
		public bool _ready;

		// Token: 0x04000317 RID: 791
		public int LineIndex;

		// Token: 0x04000318 RID: 792
		public string Host;

		// Token: 0x04000319 RID: 793
		public string User;

		// Token: 0x0400031A RID: 794
		public string Pass;

		// Token: 0x0400031B RID: 795
		private DateTime StartRequest;

		// Token: 0x0400031C RID: 796
		private DateTime EndRequest;
	}
}
