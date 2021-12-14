using System;

namespace OldCrypt_GUI.Interfaces.OldCrypt_Library_Interface
{
    public static class OldCrypt_Interface
    {
        /// <summary>
        /// Encrypts the input based on the parameters given in it.
        /// </summary>
        /// <param name="input"><see cref="Parameters{Type}"/> for encryption, has to be either Parameters&lt;<see cref="string"/>&gt; or Parameters&lt;byte[]&gt;, otherwise throws an <see cref="ArgumentException"/>.</param>
        /// <returns>The result of the encryption in the form of an <see cref="object"/> which is either <see cref="string"/> if the input was Parameters&lt;<see cref="string"/>&gt; or <see cref="Array"/> of <see cref="byte"/> if the input was Parameters&lt;byte[]&gt;.</returns>
        /// <exception cref="ArgumentException"/>
        /// <exception><inheritdoc cref="OldCrypt_Library.Cipher.Encrypt(string)"/></exception>
        /// <exception><inheritdoc cref="OldCrypt_Library.Cipher.Encrypt(byte[])"/></exception>
        public static object Encrypt(object input)
        {
            if (input is Parameters<string>)
            {
                Parameters<string> parameters = input as Parameters<string>;

                return parameters.Cipher.Encrypt(parameters.Input);
            }
            else if (input is Parameters<byte[]>)
            {
                Parameters<byte[]> parameters = input as Parameters<byte[]>;

                return parameters.Cipher.Encrypt(parameters.Input);
            }
            else
                throw new ArgumentException(nameof(input) + " has to be either Parameters<string> or Parameters<byte[]>.");
        }

        /// <summary>
        /// Decrypts the input based on the parameters given in it.
        /// </summary>
        /// <param name="input"><see cref="Parameters{Type}"/> for decryption, has to be either Parameters&lt;<see cref="string"/>&gt; or Parameters&lt;byte[]&gt;, otherwise throws an <see cref="ArgumentException"/>.</param>
        /// <returns>The result of the decryption in the form of an <see cref="object"/> which is either <see cref="string"/> if the input was Parameters&lt;<see cref="string"/>&gt; or <see cref="Array"/> of <see cref="byte"/> if the input was Parameters&lt;byte[]&gt;.</returns>
        /// <exception cref="ArgumentException"/>
        /// <exception><inheritdoc cref="OldCrypt_Library.Cipher.Decrypt(string)"/></exception>
        /// <exception><inheritdoc cref="OldCrypt_Library.Cipher.Decrypt(byte[])"/></exception>
        public static object Decrypt(object input)
        {
            if (input is Parameters<string>)
            {
                Parameters<string> parameters = input as Parameters<string>;

                return parameters.Cipher.Decrypt(parameters.Input);
            }
            else if (input is Parameters<byte[]>)
            {
                Parameters<byte[]> parameters = input as Parameters<byte[]>;

                return parameters.Cipher.Decrypt(parameters.Input);
            }
            else
                throw new ArgumentException(nameof(input) + " has to be either Parameters<string> or Parameters<byte[]>.");
        }

        /// <summary>
        /// Encrypts the input file and puts the result into the output file based on the parameters given in the input object.
        /// </summary>
        /// <param name="input"><see cref="FileParameters"/> with values set to the desired parameters, if not <see cref="FileParameters"/> throws an <see cref="ArgumentException"/>.</param>
        /// <returns>True if the encryption finished successfully, otherwise false.</returns>
        /// <exception cref="ArgumentException"/>
        /// <exception><inheritdoc cref="OldCrypt_Library.Cipher.EncryptFile(System.IO.BinaryReader, System.IO.BinaryWriter)"/></exception>
        public static bool EncryptFile(object input)
        {
            if (input is FileParameters)
            {
                FileParameters parameters = input as FileParameters;

                return parameters.Cipher.EncryptFile(parameters.Reader, parameters.Writer);
            }
            else
                throw new ArgumentException(nameof(input) + " must be of type FileParameters");
        }

        /// <summary>
        /// Decrypts the input file and puts the result into the output file based on the parameters given in the input object.
        /// </summary>
        /// <param name="input"><see cref="FileParameters"/> with values set to the desired parameters, if not <see cref="FileParameters"/> throws an <see cref="ArgumentException"/>.</param>
        /// <returns>True if the decryption finished successfully, otherwise false.</returns>
        /// <exception cref="ArgumentException"/>
        /// <exception><inheritdoc cref="OldCrypt_Library.Cipher.DecryptFile(System.IO.BinaryReader, System.IO.BinaryWriter)"/></exception>
        public static bool DecryptFile(object input)
        {
            if (input is FileParameters)
            {
                FileParameters parameters = input as FileParameters;

                return parameters.Cipher.DecryptFile(parameters.Reader, parameters.Writer);
            }
            else
                throw new ArgumentException(nameof(input) + " must be of type FileParameters");
        }
    }
}
