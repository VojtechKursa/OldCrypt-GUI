namespace OldCrypt_GUI.GUI.Modules.CipherControls
{
    public class CipherControl_Atbash : CipherControl_LabelOnly
    {
        public CipherControl_Atbash() : base("Atbash")
        { }

        protected override void CreateCipher()
        {
            cipher = new OldCrypt_Library.Old.Substitution.Atbash();
        }
    }
}
