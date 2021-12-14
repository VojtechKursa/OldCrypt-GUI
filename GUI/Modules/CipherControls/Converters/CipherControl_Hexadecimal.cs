namespace OldCrypt_GUI.GUI.Modules.CipherControls
{
    public class CipherControl_Hexadecimal : CipherControl_LabelOnly
    {
        public CipherControl_Hexadecimal() : base("Hexadecimal")
        { }

        protected override void CreateCipher()
        {
            cipher = new OldCrypt_Library.Converters.Hexadecimal();
        }
    }
}
