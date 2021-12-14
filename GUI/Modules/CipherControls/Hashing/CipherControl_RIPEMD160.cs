namespace OldCrypt_GUI.GUI.Modules.CipherControls
{
    public class CipherControl_RIPEMD160 : CipherControl_LabelOnly
    {
        public CipherControl_RIPEMD160() : base("RIPEMD160")
        { }

        protected override void CreateCipher()
        {
            cipher = new OldCrypt_Library.Hashing.RIPEMD160();
        }
    }
}
