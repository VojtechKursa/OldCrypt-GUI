using System;
using System.IO;
using System.Threading.Tasks;

namespace OldCrypt.GUI.Functions
{
	public static class IO
	{
		public static async Task<string> ReadFile(string path)
		{
			StreamReader reader = new StreamReader(new FileStream(path, FileMode.Open, FileAccess.Read));
			string result = await reader.ReadToEndAsync();
			reader.Close();

			return result;
		}

		public static async Task<byte[]> ReadBinary(string path)
		{
			FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);

			byte[] result = new byte[Convert.ToInt32(stream.Length)];
			_ = await stream.ReadAsync(result, 0, result.Length);

			stream.Close();

			return result;
		}

		public static async Task WriteFile(string path, string textToWrite)
		{
			StreamWriter writer = new StreamWriter(new FileStream(path, FileMode.Create, FileAccess.Write));
			await writer.WriteAsync(textToWrite);
			writer.Close();
		}

		public static async Task WriteBinary(string path, byte[] dataToWrite)
		{
			FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write);
			await stream.WriteAsync(dataToWrite, 0, dataToWrite.Length);
			stream.Close();
		}

		public static string GetFileName(string path)
		{
			string[] pathSplit = path.Split('\\', '/');
			return pathSplit[pathSplit.Length - 1];
		}

		public static string GetExtension(string path)
		{
			string[] pathSplit = path.Split('.');
			return pathSplit[pathSplit.Length - 1];
		}
	}
}
