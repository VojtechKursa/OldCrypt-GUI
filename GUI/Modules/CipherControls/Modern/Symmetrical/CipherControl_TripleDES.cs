namespace OldCrypt.GUI.GUI.Modules.CipherControls
{
	public class CipherControl_TripleDES : CipherControl_Symmetrical
	{
		public CipherControl_TripleDES() : base("TripleDES")
		{ }

		protected override void CreateTempCipher()
		{
			tempCipher = new OldCrypt.Library.Modern.Symmetrical.TripleDES();
		}
	}
}
