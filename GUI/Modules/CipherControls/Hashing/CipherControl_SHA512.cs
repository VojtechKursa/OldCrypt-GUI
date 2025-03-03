namespace OldCrypt.GUI.GUI.Modules.CipherControls
{
	public class CipherControl_SHA512 : CipherControl_LabelOnly
	{
		public CipherControl_SHA512() : base("SHA512")
		{ }

		protected override void CreateCipher()
		{
			cipher = new OldCrypt.Library.Hashing.SHA512();
		}
	}
}
