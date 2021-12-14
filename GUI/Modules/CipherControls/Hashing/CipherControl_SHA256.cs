namespace OldCrypt_GUI.GUI.Modules.CipherControls
{
    public class CipherControl_SHA256 : CipherControl_LabelOnly
    {
        public CipherControl_SHA256() : base("SHA256")
        { }

        protected override void CreateCipher()
        {
            cipher = new OldCrypt_Library.Hashing.SHA256();
        }
    }
}
