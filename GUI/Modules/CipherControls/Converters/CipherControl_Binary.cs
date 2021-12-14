namespace OldCrypt_GUI.GUI.Modules.CipherControls
{
    public class CipherControl_Binary : CipherControl_LabelOnly
    {
        public CipherControl_Binary() : base("Binary")
        { }

        protected override void CreateCipher()
        {
            cipher = new OldCrypt_Library.Converters.Binary();
        }
    }
}
