namespace OldCrypt_GUI.GUI.Modules.CipherControls
{
    public class CipherControl_Reverse : CipherControl_LabelOnly
    {
        public CipherControl_Reverse() : base("Reverse")
        { }

        protected override void CreateCipher()
        {
            cipher = new OldCrypt_Library.Old.Transposition.Reverse();
        }
    }
}
