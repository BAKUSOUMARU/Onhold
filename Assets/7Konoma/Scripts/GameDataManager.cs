using UnityEngine;
using System.IO;
using System.Security.Cryptography;
using System.Collections.Generic;

public class GameData
{
	public int level;
	public List<int> characterIds;
}

public class GameDataManager
{

	static string fileName = "GameData";

	public static void Save(GameData gameData)
	{
        string json = JsonUtility.ToJson(gameData);
		json += "[END]"; // 復号化の際にPaddingされたデータを除去するためのデリミタの追記
		string crypted = Crypt.Encrypt(json);
		string filePath = GetFilePath();
		FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
		BinaryWriter writer = new BinaryWriter(fileStream);
		writer.Write(crypted);
		writer.Close();
	}

	public static GameData Load()
	{
		string filePath = GetFilePath();
		FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
		BinaryReader reader = new BinaryReader(fileStream);
		GameData gameData = new GameData();
		if (reader != null)
		{
			string str = reader.ReadString();
			string decrypted = Crypt.Decrypt(str);
			decrypted = System.Text.RegularExpressions.Regex.Replace(decrypted, @"\[END\].*$", "");
			//gameData = JsonMapper.ToObject<GameData>(decrypted);
			reader.Close();
		}
		return gameData;
	}

	static string GetFilePath()
	{
		return Application.persistentDataPath + "/" + fileName;
	}

	// via http://yukimemo.hatenadiary.jp/entry/2014/04/15/023802
	private class Crypt
	{

		private const string AesIV = @"jCddaOybW3zEh0Kl";
		private const string AesKey = @"giVJrbHRlWBDIggF";

		public static string Encrypt(string text)
		{

			RijndaelManaged aes = new RijndaelManaged();
			aes.BlockSize = 128;
			aes.KeySize = 128;
			aes.Padding = PaddingMode.Zeros;
			aes.Mode = CipherMode.CBC;
			aes.Key = System.Text.Encoding.UTF8.GetBytes(AesKey);
			aes.IV = System.Text.Encoding.UTF8.GetBytes(AesIV);

			ICryptoTransform encrypt = aes.CreateEncryptor();
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptStream = new CryptoStream(memoryStream, encrypt, CryptoStreamMode.Write);

			byte[] text_bytes = System.Text.Encoding.UTF8.GetBytes(text);

			cryptStream.Write(text_bytes, 0, text_bytes.Length);
			cryptStream.FlushFinalBlock();

			byte[] encrypted = memoryStream.ToArray();

			return (System.Convert.ToBase64String(encrypted));
		}

		public static string Decrypt(string cryptText)
		{

			RijndaelManaged aes = new RijndaelManaged();
			aes.BlockSize = 128;
			aes.KeySize = 128;
			aes.Padding = PaddingMode.Zeros;
			aes.Mode = CipherMode.CBC;
			aes.Key = System.Text.Encoding.UTF8.GetBytes(AesKey);
			aes.IV = System.Text.Encoding.UTF8.GetBytes(AesIV);

			ICryptoTransform decryptor = aes.CreateDecryptor();

			byte[] encrypted = System.Convert.FromBase64String(cryptText);
			byte[] planeText = new byte[encrypted.Length];

			MemoryStream memoryStream = new MemoryStream(encrypted);
			CryptoStream cryptStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

			cryptStream.Read(planeText, 0, planeText.Length);

			return (System.Text.Encoding.UTF8.GetString(planeText));
		}
	}
}