using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AutoLead
{
	// Token: 0x0200000D RID: 13
	public class EncryptedString
	{
		// Token: 0x0600001E RID: 30 RVA: 0x00004300 File Offset: 0x00002500
		public static string EncryptString(string plainSourceStringToEncrypt, string passPhrase)
		{
			string result;
			using (AesCryptoServiceProvider provider = EncryptedString.GetProvider(Encoding.Default.GetBytes(passPhrase)))
			{
				byte[] bytes = Encoding.ASCII.GetBytes(plainSourceStringToEncrypt);
				ICryptoTransform transform = provider.CreateEncryptor();
				MemoryStream memoryStream = new MemoryStream();
				CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
				cryptoStream.Write(bytes, 0, bytes.Length);
				cryptoStream.FlushFinalBlock();
				byte[] inArray = memoryStream.ToArray();
				result = Convert.ToBase64String(inArray);
			}
			return result;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00004388 File Offset: 0x00002588
		public static string DecryptString(string base64StringToDecrypt, string passphrase)
		{
			string result;
			using (AesCryptoServiceProvider provider = EncryptedString.GetProvider(Encoding.Default.GetBytes(passphrase)))
			{
				byte[] array = Convert.FromBase64String(base64StringToDecrypt);
				ICryptoTransform transform = provider.CreateDecryptor();
				MemoryStream stream = new MemoryStream(array, 0, array.Length);
				CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
				result = new StreamReader(stream2).ReadToEnd();
			}
			return result;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000043F8 File Offset: 0x000025F8
		private static AesCryptoServiceProvider GetProvider(byte[] key)
		{
			AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider();
			aesCryptoServiceProvider.BlockSize = 128;
			aesCryptoServiceProvider.KeySize = 128;
			aesCryptoServiceProvider.Mode = CipherMode.ECB;
			aesCryptoServiceProvider.Padding = PaddingMode.PKCS7;
			aesCryptoServiceProvider.GenerateIV();
			aesCryptoServiceProvider.IV = new byte[16];
			byte[] key2 = EncryptedString.GetKey(key, aesCryptoServiceProvider);
			aesCryptoServiceProvider.Key = key2;
			return aesCryptoServiceProvider;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00004460 File Offset: 0x00002660
		private static byte[] GetKey(byte[] suggestedKey, SymmetricAlgorithm p)
		{
			List<byte> list = new List<byte>();
			for (int i = 0; i < p.LegalKeySizes[0].MinSize; i += 8)
			{
				list.Add(suggestedKey[i / 8 % suggestedKey.Length]);
			}
			return list.ToArray();
		}
	}
}
