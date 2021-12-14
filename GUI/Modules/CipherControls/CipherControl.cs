using OldCrypt_GUI.Interfaces.OldCrypt_Library_Interface;
using OldCrypt_Library;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Controls;

namespace OldCrypt_GUI.GUI.Modules.CipherControls
{
    public abstract class CipherControl : UserControl
    {
        protected Cipher cipher;
        protected ProgressModule progressModule;
        protected StrictnessModule strictnessModule;
        private Timer progressTimer;

        public ProgressModule ProgressModule
        {
            get => progressModule;
            set => progressModule = value;
        }

        public StrictnessModule StrictnessModule
        {
            get => strictnessModule;
            set => strictnessModule = value;
        }

        #region Methods

        private void SetStrictness()
        {
            cipher.IgnoreCase = strictnessModule.IgnoreCase;
            cipher.IgnoreSpace = strictnessModule.IgnoreSpaces;
            cipher.Strict = strictnessModule.StrictMode;
        }

        #region Progress tracking

        protected void StartProgressTracking()
        {
            progressTimer = new Timer(500) { AutoReset = true };
            progressTimer.Elapsed += ProgressTimer_Elapsed;
            progressTimer.Start();
        }

        protected void StopProgressTracking()
        {
            progressTimer.Stop();
        }

        private void ProgressTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (progressModule != null)
                progressModule.Progress = cipher.Progress * 100;
        }

        #endregion

        #region Encryption & Decryption

        /// <summary>
        /// A method that defines the variable <see cref="cipher"/> with the desired <see cref="Cipher"/> with the desired parameters from GUI.
        /// </summary>
        protected abstract void CreateCipher();

        private void PrepareForEncDec()
        {
            CreateCipher();

            SetStrictness();
        }

        public virtual async Task<string> Encrypt(string text)
        {
            PrepareForEncDec();

            Parameters<string> parameters = new Parameters<string>(cipher, text);
            Task<object> task = new Task<object>(new Func<object, object>(OldCrypt_Interface.Encrypt), parameters);
            task.Start();

            return (string)await task;
        }

        public virtual async Task<string> Decrypt(string text)
        {
            PrepareForEncDec();

            Parameters<string> parameters = new Parameters<string>(cipher, text);
            Task<object> task = new Task<object>(new Func<object, object>(OldCrypt_Interface.Decrypt), parameters);
            task.Start();

            return (string)await task;
        }

        public virtual async Task<byte[]> Encrypt(byte[] data)
        {
            PrepareForEncDec();

            Parameters<byte[]> parameters = new Parameters<byte[]>(cipher, data);
            Task<object> task = new Task<object>(new Func<object, object>(OldCrypt_Interface.Encrypt), parameters);
            task.Start();

            return (byte[])await task;
        }

        public virtual async Task<byte[]> Decrypt(byte[] data)
        {
            PrepareForEncDec();

            Parameters<byte[]> parameters = new Parameters<byte[]>(cipher, data);
            Task<object> task = new Task<object>(new Func<object, object>(OldCrypt_Interface.Decrypt), parameters);
            task.Start();

            return (byte[])await task;
        }

        public virtual async Task<bool> Encrypt(BinaryReader reader, BinaryWriter writer)
        {
            PrepareForEncDec();

            FileParameters parameters = new FileParameters(cipher, reader, writer);
            Task<bool> task = new Task<bool>(new Func<object, bool>(OldCrypt_Interface.EncryptFile), parameters);
            task.Start();

            return await task;
        }

        public virtual async Task<bool> Decrypt(BinaryReader reader, BinaryWriter writer)
        {
            PrepareForEncDec();

            FileParameters parameters = new FileParameters(cipher, reader, writer);
            Task<bool> task = new Task<bool>(new Func<object, bool>(OldCrypt_Interface.DecryptFile), parameters);
            task.Start();

            return await task;
        }

        #endregion

        #endregion
    }
}
