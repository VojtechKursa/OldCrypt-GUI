namespace OldCrypt_GUI.GUI.Modules.CipherControls
{
    public class CipherControl_ReverseNeighbors : CipherControl_LabelOnly
    {
        public CipherControl_ReverseNeighbors() : base("Reverse neighbors")
        { }

        protected override void CreateCipher()
        {
            cipher = new OldCrypt_Library.Old.Transposition.ReverseNeighbors();
        }
    }
}
