namespace OldCrypt.GUI.Data
{
	public class CipherInfo
	{
		public CipherInfo(string name, bool modern, string type, bool binaryAvailable)
		{
			Name = name;
			Modern = modern;
			Type = type;
			BinaryAvailable = binaryAvailable;
		}

		public string Name { get; }

		public bool Modern { get; set; }

		public string Type { get; }

		public bool BinaryAvailable { get; set; }
	}
}
