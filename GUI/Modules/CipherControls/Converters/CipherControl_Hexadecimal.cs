namespace OldCrypt.GUI.GUI.Modules.CipherControls
{
	public class CipherControl_Hexadecimal : CipherControl_LabelOnly
	{
		public CipherControl_Hexadecimal() : base("Hexadecimal")
		{ }

		protected override void CreateCipher()
		{
			cipher = new OldCrypt.Library.Converters.Hexadecimal();
		}
	}
}
