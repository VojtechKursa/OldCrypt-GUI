namespace OldCrypt.GUI.GUI.Modules.CipherControls
{
	public class CipherControl_MD5 : CipherControl_LabelOnly
	{
		public CipherControl_MD5() : base("MD5")
		{ }

		protected override void CreateCipher()
		{
			cipher = new OldCrypt.Library.Hashing.MD5();
		}
	}
}
