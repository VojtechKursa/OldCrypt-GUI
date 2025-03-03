namespace OldCrypt.GUI.GUI.Modules.CipherControls
{
	public class CipherControl_AES : CipherControl_Symmetrical
	{
		public CipherControl_AES() : base("AES")
		{ }

		protected override void CreateTempCipher()
		{
			tempCipher = new OldCrypt.Library.Modern.Symmetrical.AES();
		}
	}
}
