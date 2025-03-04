# OldCrypt

## Introduction

OldCrypt is an open-source program that performs encryption and decryption of data (either text or binary) using old (pre-digital) encryption methods.
It uses a GUI built on the Windows Presentation Foundation (WPF).

The main purpose of this program is entertainment (i.e. roleplay or just messing around with old cryptography) or education (introduction into cryptography).

## Important note

As this program is a simulator of old encryption methods, most of the methods in this program are by no means secure and shouldn't be used as such. Nowadays they can be cracked within seconds even on low-end phones.
In short, this program might encrypt your 18+ folder against your parents, but will be just a good entertainment for people who actually want to dig in your private data.

## Using the program

To use this program you can either download a build from the [releases](https://github.com/VojtechKursa/OldCrypt-GUI/releases) section or build the program yourself using a C# compiler.

After running the program, you'll be presented by a (very poorly made) graphical user interface, containing a table for selecting a cipher to work with.
After selecting the desired cipher and clicking the "Create" button at the bottom of the window, a new tab, containing a simulator of the selected cipher, will open.
Then select cipher parameters in the middle (help button is available (`?` button)), input your data into the input field, then click either "Encrypt" or "Decrypt" button to perform the selected operation.

Multiple tabs can be opened at the same time allowing to work with multiple ciphers at once. Tabs can be closed by right-clicking on them and clicking on the "Close" option.

### Working with files

If a selected cipher supports binary mode, you will be presented with an option to switch to a **Binary** mode of the cipher through the "Mode" selector in the middle of the cipher simulator.
The input and output text elements will be replaced by a file dialogs, where you can select the input and output files.

The files will be encrypted or decrypted in binary mode.
To work with files in textual mode, use the "Load" and "Save" buttons below "Input" and "Output" fields in **Text** mode.

## Contributing

This program is licensed under the **GNU General Public License v3** so anyone can use it for free and modify it as long as that person follows the conditions stated by the license.
If you have suggestions that would optimize or otherwise improve this program, feel free to share them by creating an issue or submitting a pull request with your implemented ideas in the GitHub repository (see section *Source code & Repository*).

## Libraries

This program uses the **OldCrypt Library** for the actual encryption/decryption. This library is licensed under the **GNU General Public License v3**.
For more information, please refer to the `Libraries/OldCrypt Library` folder.

## Source code & Repository

The source code for this program and it's public repository can be found on [GitHub](https://github.com/VojtechKursa/OldCrypt-GUI).
