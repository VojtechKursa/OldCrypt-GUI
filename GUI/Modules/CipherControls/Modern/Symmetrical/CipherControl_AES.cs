namespace OldCrypt_GUI.GUI.Modules.CipherControls
{
    public class CipherControl_AES : CipherControl_Symmetrical
    {
        public CipherControl_AES() : base("AES")
        { }

        protected override void CreateTempCipher()
        {
            tempCipher = new OldCrypt_Library.Modern.Symmetrical.AES();
        }
    }
}
