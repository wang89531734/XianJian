using System;
using System.IO;
using System.Security.Cryptography;

public class C_FileCodec
{
	public static void EncodeFile(string strPath)
	{
		try
		{
			int num = strPath.LastIndexOf("\\") + 1;
			int length = strPath.Length;
			string text = strPath.Substring(num, length - num);
			int length2 = text.LastIndexOf(".");
			string text2 = text.Substring(0, length2);
			text2 = strPath.Substring(0, strPath.LastIndexOf("\\") + 1) + text2 + ".dbfs";
			FileStream fileStream = File.Open(strPath, FileMode.Open, FileAccess.Read);
			FileStream fileStream2 = File.Open(text2, FileMode.Create, FileAccess.Write);
			byte[] rgbKey = new byte[]
			{
				39,
				73,
				99,
				26,
				84,
				19,
				77,
				65,
				18,
				96,
				22,
				118,
				55,
				51,
				121,
				27,
				151,
				86,
				24,
				87,
				212,
				24,
				14,
				6,
				78,
				103,
				93,
				2,
				49,
				69,
				73,
				135
			};
			byte[] rgbIV = new byte[]
			{
				30,
				255,
				66,
				5,
				137,
				31,
				74,
				24,
				23,
				96,
				24,
				98,
				26,
				67,
				59,
				2
			};
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			CryptoStream cryptoStream = new CryptoStream(fileStream2, rijndaelManaged.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
			BinaryReader binaryReader = new BinaryReader(fileStream);
			cryptoStream.Write(binaryReader.ReadBytes((int)fileStream.Length), 0, (int)fileStream.Length);
			cryptoStream.FlushFinalBlock();
			cryptoStream.Close();
			fileStream.Close();
			fileStream2.Close();
			Console.WriteLine("輸出:{0}", text2);
		}
		catch (Exception ex)
		{
			Console.WriteLine("Exception:" + ex.Message);
			Console.Read();
		}
	}

	public static void DecodeFile(string strPath)
	{
		int num = strPath.LastIndexOf("\\") + 1;
		int length = strPath.Length;
		string text = strPath.Substring(num, length - num);
		int length2 = text.LastIndexOf(".");
		text = text.Substring(0, length2);
		text += "Org.dbf";
		string path = strPath.Substring(0, strPath.LastIndexOf("\\") + 1) + text;
		FileStream fileStream = File.Open(strPath, FileMode.Open, FileAccess.Read);
		byte[] rgbKey = new byte[]
		{
			39,
			73,
			99,
			26,
			84,
			19,
			77,
			65,
			18,
			96,
			22,
			118,
			55,
			51,
			121,
			27,
			151,
			86,
			24,
			87,
			212,
			24,
			14,
			6,
			78,
			103,
			93,
			2,
			49,
			69,
			73,
			135
		};
		byte[] rgbIV = new byte[]
		{
			30,
			255,
			66,
			5,
			137,
			31,
			74,
			24,
			23,
			96,
			24,
			98,
			26,
			67,
			59,
			2
		};
		RijndaelManaged rijndaelManaged = new RijndaelManaged();
		CryptoStream stream = new CryptoStream(fileStream, rijndaelManaged.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Read);
		StreamReader streamReader = new StreamReader(stream);
		StreamWriter streamWriter = new StreamWriter(path);
		streamWriter.Write(streamReader.ReadToEnd());
		streamWriter.Flush();
		streamWriter.Close();
		streamReader.Close();
		fileStream.Close();
	}

	public static string DecodeFile2(string strPath)
	{
		FileStream input = File.Open(strPath, FileMode.Open, FileAccess.Read);
		byte[] bytes = new byte[0];
		BinaryReader binaryReader = new BinaryReader(input);
		binaryReader.BaseStream.Seek(0L, SeekOrigin.Begin);
		bytes = binaryReader.ReadBytes((int)binaryReader.BaseStream.Length);
		return C_FileCodec.DecodeBytes(bytes);
	}

	public static string DecodeBytes(byte[] bytes)
	{
		MemoryStream stream = new MemoryStream(bytes);
		byte[] rgbKey = new byte[]
		{
			39,
			73,
			99,
			26,
			84,
			19,
			77,
			65,
			18,
			96,
			22,
			118,
			55,
			51,
			121,
			27,
			151,
			86,
			24,
			87,
			212,
			24,
			14,
			6,
			78,
			103,
			93,
			2,
			49,
			69,
			73,
			135
		};
		byte[] rgbIV = new byte[]
		{
			30,
			255,
			66,
			5,
			137,
			31,
			74,
			24,
			23,
			96,
			24,
			98,
			26,
			67,
			59,
			2
		};
		RijndaelManaged rijndaelManaged = new RijndaelManaged();
		CryptoStream stream2 = new CryptoStream(stream, rijndaelManaged.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Read);
		StreamReader streamReader = new StreamReader(stream2);
		return streamReader.ReadToEnd();
	}
}
