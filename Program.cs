using Converter.Models;
using System;
using System.Linq;

namespace Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            //getting name
            Console.WriteLine("enter your name: ");
            name = Console.ReadLine();
            string unicodeString = name;
            //binary conversion


            BinaryConverter binaryConverter = new BinaryConverter();
            string binaryValue = binaryConverter.ConvertTo(name);
            Console.WriteLine($"{name} as Binary: {binaryValue}");
            Console.WriteLine($"{name} from Binary to ASCII: {binaryConverter.ConvertBinaryToString(binaryValue)}");

            HexadecimalConverter hexadecimalConverter = new HexadecimalConverter();
            string hexadecimalValue = hexadecimalConverter.ConvertTo(name);
            Console.WriteLine($"{name} as Hexadecimal: {hexadecimalValue}");
            Console.WriteLine($"{name} from Hexadecimal to ASCII: {hexadecimalConverter.ConveryFromHexToASCII(hexadecimalValue)}");

            int[] cipher = new[] { 1, 1, 2, 3, 5, 8, 13 }; //Fibonacci Sequence
            string cipherasString = String.Join(",", cipher.Select(x => x.ToString())); //FOr display

            int encryptionDepth = 20;

            encrypter encrypter = new encrypter(unicodeString, cipher, encryptionDepth);

            //Single Level Encrytion
            string nameEncryptWithCipher = encrypter.EncryptWithCipher(unicodeString, cipher);
            Console.WriteLine($"Encrypted once using the cipher {{{cipherasString}}} {nameEncryptWithCipher}");

            string nameDecryptWithCipher = encrypter.DecryptWithCipher(nameEncryptWithCipher, cipher);
            Console.WriteLine($"Decrypted once using the cipher {{{cipherasString}}} {nameDecryptWithCipher}");

            //Deep Encrytion
            string nameDeepEncryptWithCipher = encrypter.DeepEncryptWithCipher(unicodeString, cipher, encryptionDepth);
            Console.WriteLine($"Deep Encrypted {encryptionDepth} times using the cipher {{{cipherasString}}} {nameDeepEncryptWithCipher}");

            string nameDeepDecryptWithCipher = encrypter.DeepDecryptWithCipher(nameDeepEncryptWithCipher, cipher, encryptionDepth);
            Console.WriteLine($"Deep Decrypted {encryptionDepth} times using the cipher {{{cipherasString}}} {nameDeepDecryptWithCipher}");

            //Base64 Encoded
            Console.WriteLine($"Base64 encoded {unicodeString} {encrypter.Base64}");

            string base64toPlainText = encrypter.Base64ToString(encrypter.Base64);
            Console.WriteLine($"Base64 decoded {encrypter.Base64} {base64toPlainText}");
        }
    }
}