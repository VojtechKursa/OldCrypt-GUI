namespace OldCrypt_GUI.GUI.Modules.CipherControls
{
    public class CipherControl_SHA384 : CipherControl_LabelOnly
    {
        public CipherControl_SHA384() : base("SHA384")
        { }

        protected override void CreateCipher()
        {
            cipher = new OldCrypt_Library.Hashing.SHA384();
        }
    }
}
