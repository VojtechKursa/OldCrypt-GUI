using OldCrypt.Library;
using System.IO;

namespace OldCrypt.GUI.Interfaces.OldCrypt.Library_Interface
{
	/// <summary>
	/// Provides a way to pass parameters to the <see cref="OldCrypt_Interface.EncryptFile(object)"/> and <see cref="OldCrypt_Interface.DecryptFile(object)"/> methods
	/// </summary>
	public class FileParameters
	{
		private readonly Cipher cipher;
		private readonly BinaryReader reader;
		private readonly BinaryWriter writer;

		/// <summary>
		/// Initiates a new instance of the <see cref="FileParameters"/> class.
		/// </summary>
		/// <param name="cipher"><see cref="OldCrypt.Library.Cipher"/> to use in the <see cref="OldCrypt_Interface.EncryptFile(object)"/> or <see cref="OldCrypt_Interface.DecryptFile(object)"/> methods.</param>
		/// <param name="reader"><see cref="BinaryReader"/> opened on the input file, that will be encrypted or decrypted.</param>
		/// <param name="writer"><see cref="BinaryWriter"/> opened on the output file.</param>
		public FileParameters(Cipher cipher, BinaryReader reader, BinaryWriter writer)
		{
			this.cipher = cipher;
			this.reader = reader;
			this.writer = writer;
		}

		public Cipher Cipher
		{ get => cipher; }

		public BinaryReader Reader
		{ get => reader; }

		public BinaryWriter Writer
		{ get => writer; }
	}
}
