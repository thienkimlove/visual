using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RNCryptor
{
	// Token: 0x0200000B RID: 11
	public class Decryptor : Cryptor
	{
		// Token: 0x06000014 RID: 20 RVA: 0x00003E34 File Offset: 0x00002034
		public string Decrypt(string encryptedBase64, string password)
		{
			PayloadComponents payloadComponents = this.unpackEncryptedBase64Data(encryptedBase64);
			bool flag = !this.hmacIsValid(payloadComponents, password);
			string result;
			if (flag)
			{
				result = "";
			}
			else
			{
				byte[] key = base.generateKey(payloadComponents.salt, password);
				byte[] bytes = new byte[0];
				AesMode aesMode = this.aesMode;
				if (aesMode != AesMode.CTR)
				{
					if (aesMode == AesMode.CBC)
					{
						bytes = this.decryptAesCbcPkcs7(payloadComponents.ciphertext, key, payloadComponents.iv);
					}
				}
				else
				{
					bytes = base.encryptAesCtrLittleEndianNoPadding(payloadComponents.ciphertext, key, payloadComponents.iv);
				}
				result = Encoding.UTF8.GetString(bytes);
			}
			return result;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00003ECC File Offset: 0x000020CC
		private byte[] decryptAesCbcPkcs7(byte[] encrypted, byte[] key, byte[] iv)
		{
			Aes aes = Aes.Create();
			aes.Mode = CipherMode.CBC;
			aes.Padding = PaddingMode.PKCS7;
			ICryptoTransform transform = aes.CreateDecryptor(key, iv);
			string s;
			using (MemoryStream memoryStream = new MemoryStream(encrypted))
			{
				using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read))
				{
					using (StreamReader streamReader = new StreamReader(cryptoStream))
					{
						s = streamReader.ReadToEnd();
					}
				}
			}
			return base.TextEncoding.GetBytes(s);
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00003F88 File Offset: 0x00002188
		private PayloadComponents unpackEncryptedBase64Data(string encryptedBase64)
		{
			List<byte> list = new List<byte>();
			list.AddRange(Convert.FromBase64String(encryptedBase64));
			int num = 0;
			PayloadComponents payloadComponents;
			payloadComponents.schema = list.GetRange(0, 1).ToArray();
			num++;
			base.configureSettings((Schema)list[0]);
			payloadComponents.options = list.GetRange(1, 1).ToArray();
			num++;
			payloadComponents.salt = list.GetRange(num, 8).ToArray();
			num += payloadComponents.salt.Length;
			payloadComponents.hmacSalt = list.GetRange(num, 8).ToArray();
			num += payloadComponents.hmacSalt.Length;
			payloadComponents.iv = list.GetRange(num, 16).ToArray();
			num += payloadComponents.iv.Length;
			payloadComponents.headerLength = num;
			payloadComponents.ciphertext = list.GetRange(num, list.Count - 32 - payloadComponents.headerLength).ToArray();
			num += payloadComponents.ciphertext.Length;
			payloadComponents.hmac = list.GetRange(num, 32).ToArray();
			return payloadComponents;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00004098 File Offset: 0x00002298
		private bool hmacIsValid(PayloadComponents components, string password)
		{
			byte[] array = base.generateHmac(components, password);
			bool flag = array.Length != components.hmac.Length;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				for (int i = 0; i < components.hmac.Length; i++)
				{
					bool flag2 = array[i] != components.hmac[i];
					if (flag2)
					{
						result = false;
						return result;
					}
				}
				result = true;
			}
			return result;
		}
	}
}
