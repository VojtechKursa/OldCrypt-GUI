﻿namespace OldCrypt_GUI.GUI.Modules.CipherControls
{
    public class CipherControl_SHA1 : CipherControl_LabelOnly
    {
        public CipherControl_SHA1() : base("SHA1")
        { }

        protected override void CreateCipher()
        {
            cipher = new OldCrypt_Library.Hashing.SHA1();
        }
    }
}
