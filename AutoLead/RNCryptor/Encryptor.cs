using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace RNCryptor
{
	// Token: 0x0200000C RID: 12
	public class Encryptor : Cryptor
	{
		// Token: 0x06000019 RID: 25 RVA: 0x00004104 File Offset: 0x00002304
		public string Encrypt(string plaintext, string password)
		{
			return this.Encrypt(plaintext, password, this.defaultSchemaVersion);
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00004124 File Offset: 0x00002324
		public string Encrypt(string plaintext, string password, Schema schemaVersion)
		{
			base.configureSettings(schemaVersion);
			byte[] bytes = base.TextEncoding.GetBytes(plaintext);
			PayloadComponents payloadComponents = default(PayloadComponents);
			payloadComponents.schema = new byte[]
			{
				(byte)schemaVersion
			};
			payloadComponents.options = new byte[]
			{
				(byte)this.options
			};
			payloadComponents.salt = this.generateRandomBytes(8);
			payloadComponents.hmacSalt = this.generateRandomBytes(8);
			payloadComponents.iv = this.generateRandomBytes(16);
			byte[] key = base.generateKey(payloadComponents.salt, password);
			AesMode aesMode = this.aesMode;
			if (aesMode != AesMode.CTR)
			{
				if (aesMode == AesMode.CBC)
				{
					payloadComponents.ciphertext = this.encryptAesCbcPkcs7(bytes, key, payloadComponents.iv);
				}
			}
			else
			{
				payloadComponents.ciphertext = base.encryptAesCtrLittleEndianNoPadding(bytes, key, payloadComponents.iv);
			}
			payloadComponents.hmac = base.generateHmac(payloadComponents, password);
			List<byte> list = new List<byte>();
			list.AddRange(base.assembleHeader(payloadComponents));
			list.AddRange(payloadComponents.ciphertext);
			list.AddRange(payloadComponents.hmac);
			return Convert.ToBase64String(list.ToArray());
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00004244 File Offset: 0x00002444
		private byte[] encryptAesCbcPkcs7(byte[] plaintext, byte[] key, byte[] iv)
		{
			Aes aes = Aes.Create();
			aes.Mode = CipherMode.CBC;
			aes.Padding = PaddingMode.PKCS7;
			ICryptoTransform transform = aes.CreateEncryptor(key, iv);
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
				{
					cryptoStream.Write(plaintext, 0, plaintext.Length);
				}
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000042D8 File Offset: 0x000024D8
		private byte[] generateRandomBytes(int length)
		{
			byte[] array = new byte[length];
			RNGCryptoServiceProvider rNGCryptoServiceProvider = new RNGCryptoServiceProvider();
			rNGCryptoServiceProvider.GetBytes(array);
			return array;
		}

		// Token: 0x0400002B RID: 43
		private Schema defaultSchemaVersion = Schema.V2;
	}
}
