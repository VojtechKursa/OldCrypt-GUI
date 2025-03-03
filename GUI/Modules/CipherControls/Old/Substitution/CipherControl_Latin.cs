namespace OldCrypt.GUI.GUI.Modules.CipherControls
{
	public class CipherControl_Latin : CipherControl_LabelOnly
	{
		public CipherControl_Latin() : base("Latin code")
		{ }

		protected override void CreateCipher()
		{
			cipher = new OldCrypt.Library.Old.Substitution.Latin();
		}
	}
}
