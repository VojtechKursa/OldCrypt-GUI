namespace OldCrypt.GUI.GUI.Modules.CipherControls
{
	public class CipherControl_RC2 : CipherControl_Symmetrical
	{
		public CipherControl_RC2() : base("RC2")
		{ }

		protected override void CreateTempCipher()
		{
			tempCipher = new OldCrypt.Library.Modern.Symmetrical.RC2();
		}
	}
}
