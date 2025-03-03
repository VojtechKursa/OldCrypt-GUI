namespace OldCrypt.GUI.GUI.Modules.CipherControls
{
	public class CipherControl_Binary : CipherControl_LabelOnly
	{
		public CipherControl_Binary() : base("Binary")
		{ }

		protected override void CreateCipher()
		{
			cipher = new OldCrypt.Library.Converters.Binary();
		}
	}
}
