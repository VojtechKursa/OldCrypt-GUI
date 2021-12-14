namespace OldCrypt_GUI.GUI.Modules.CipherControls
{
    public class CipherControl_DES : CipherControl_Symmetrical
    {
        public CipherControl_DES() : base("DES")
        { }

        protected override void CreateTempCipher()
        {
            tempCipher = new OldCrypt_Library.Modern.Symmetrical.DES();
        }
    }
}
