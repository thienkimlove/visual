using System;

namespace RNCryptor
{
	// Token: 0x02000009 RID: 9
	public struct PayloadComponents
	{
		// Token: 0x04000016 RID: 22
		public byte[] schema;

		// Token: 0x04000017 RID: 23
		public byte[] options;

		// Token: 0x04000018 RID: 24
		public byte[] salt;

		// Token: 0x04000019 RID: 25
		public byte[] hmacSalt;

		// Token: 0x0400001A RID: 26
		public byte[] iv;

		// Token: 0x0400001B RID: 27
		public int headerLength;

		// Token: 0x0400001C RID: 28
		public byte[] hmac;

		// Token: 0x0400001D RID: 29
		public byte[] ciphertext;
	}
}
