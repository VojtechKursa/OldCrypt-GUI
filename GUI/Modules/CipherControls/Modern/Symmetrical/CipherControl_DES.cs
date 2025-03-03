namespace OldCrypt.GUI.GUI.Modules.CipherControls
{
	public class CipherControl_DES : CipherControl_Symmetrical
	{
		public CipherControl_DES() : base("DES")
		{ }

		protected override void CreateTempCipher()
		{
			tempCipher = new OldCrypt.Library.Modern.Symmetrical.DES();
		}
	}
}
