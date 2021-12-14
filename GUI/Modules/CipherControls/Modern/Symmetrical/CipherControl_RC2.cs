namespace OldCrypt_GUI.GUI.Modules.CipherControls
{
    public class CipherControl_RC2 : CipherControl_Symmetrical
    {
        public CipherControl_RC2() : base("RC2")
        { }

        protected override void CreateTempCipher()
        {
            tempCipher = new OldCrypt_Library.Modern.Symmetrical.RC2();
        }
    }
}
