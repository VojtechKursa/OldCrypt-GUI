using OldCrypt_Library;
using System;

namespace OldCrypt_GUI.Interfaces.OldCrypt_Library_Interface
{
    /// <summary>
    /// Provides a way to pass parameters to the <see cref="OldCrypt_Interface.Encrypt(object)"/> and <see cref="OldCrypt_Interface.Decrypt(object)"/> methods
    /// </summary>
    /// <typeparam name="Type">
    /// Desired datatype of the input and output of the <see cref="OldCrypt_Interface.Encrypt(object)"/> or <see cref="OldCrypt_Interface.Decrypt(object)"/> method.<br />
    /// Has to be either <see cref="string"/> or <see cref="Array"/> of <see cref="byte"/>.
    /// </typeparam>
    public class Parameters<Type>
    {
        private readonly Cipher cipher;
        private readonly Type input;

        /// <summary>
        /// Initiates a new instance of the <see cref="Parameters{Type}"/> class.
        /// </summary>
        /// <param name="cipher"><see cref="OldCrypt_Library.Cipher"/> to use in the <see cref="OldCrypt_Interface.Encrypt(object)"/> or <see cref="OldCrypt_Interface.Decrypt(object)"/> methods.</param>
        /// <param name="input">The input data that will be encrypted or decrypted.</param>
        public Parameters(Cipher cipher, Type input)
        {
            this.cipher = cipher;
            this.input = input;
        }

        public Cipher Cipher
        { get => cipher; }

        public Type Input
        { get => input; }
    }
}
