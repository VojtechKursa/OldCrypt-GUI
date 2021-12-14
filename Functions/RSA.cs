using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldCrypt_GUI.Functions
{
    public static class RSA
    {
        /// <summary>
        /// Gets a specified key from the given text, respecting border markers like "-----BEGIN RSA PUBLIC KEY-----".
        /// </summary>
        /// <param name="text">The text from which to extract the key, the text must be split into lines if there is a possibility of a border marker.</param>
        /// <param name="publicKey">True if looking for public key. False if looking for private key.</param>
        /// <returns>
        /// The private or public key or <i>text</i> if no border marker was found. <br />
        /// <i>null</i> if border markers were found but not for the searched key (i.e. looking for public key but only private key markers were found).
        /// </returns>
        public static string GetKeyString(string text, bool publicKey)
        {
            bool hasPublicBorderMarkers = text.Contains("BEGIN RSA PUBLIC KEY") || text.Contains("begin rsa public key");
            bool hasPrivateBorderMarkers = text.Contains("BEGIN RSA PRIVATE KEY") || text.Contains("begin rsa private key");

            if (publicKey)
            {
                if (hasPublicBorderMarkers)
                {
                    string[] textSplit = text.Replace("\r", "").Split('\n');

                    int startLine = 0;
                    int endLine = textSplit.Length;

                    for (int i = 0; i < textSplit.Length; i++)
                    {
                        if (textSplit[i].Trim('-', '=', ' ') == "BEGIN RSA PUBLIC KEY" || textSplit[i].Trim('-', '=', ' ') == "begin rsa public key")
                            startLine = i + 1;
                    }

                    for (int i = startLine; i < textSplit.Length; i++)
                    {
                        if (textSplit[i].Trim('-', '=', ' ') == "END RSA PUBLIC KEY" || textSplit[i].Trim('-', '=', ' ') == "end rsa public key")
                            endLine = i - 1;
                    }

                    string result = "";

                    for (int i = startLine; i <= endLine; i++)
                    {
                        result += textSplit[i];
                    }

                    return result;
                }
                else if (hasPrivateBorderMarkers)
                    return null;
                else    //Has no markers
                    return text;
            }
            else    //looking for Private Key
            {
                if (hasPrivateBorderMarkers)
                {
                    string[] textSplit = text.Replace("\r", "").Split('\n');

                    int startLine = 0;
                    int endLine = textSplit.Length;

                    for (int i = 0; i < textSplit.Length; i++)
                    {
                        if (textSplit[i].Trim('-', '=', ' ') == "BEGIN RSA PRIVATE KEY" || textSplit[i].Trim('-', '=', ' ') == "begin rsa private key")
                            startLine = i + 1;
                    }

                    for (int i = startLine; i < textSplit.Length; i++)
                    {
                        if (textSplit[i].Trim('-', '=', ' ') == "END RSA PRIVATE KEY" || textSplit[i].Trim('-', '=', ' ') == "end rsa private key")
                            endLine = i - 1;
                    }

                    string result = "";

                    for (int i = startLine; i <= endLine; i++)
                    {
                        result += textSplit[i];
                    }

                    return result;
                }
                else if (hasPublicBorderMarkers)
                    return null;
                else    //Has no markers
                    return text;
            }
        }
    }
}
