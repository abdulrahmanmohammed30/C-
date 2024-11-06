﻿using System;
using System.Security.Cryptography;
using System.Text;


// class Program
// {
//     static void Main()
//     {
//         // Input data
//         string data = "Mohammed Abu-Hadhoud";


//         // Compute the SHA-256 hash of the input data
//         string hashedData = ComputeHash(data);


//         // Display the original data and its hash
//         Console.WriteLine($"Original Data: {data}");
//         Console.WriteLine($"Hashed Data: {hashedData}");


//         // Pause to keep the console window open for viewing the results
//         Console.ReadKey();
//     }


//     static string ComputeHash(string input)
//     {
//         //SHA is Secutred Hash Algorithm.
//         // Create an instance of the SHA-256 algorithm
//         using (SHA256 sha256 = SHA256.Create())
//         {
//             // Compute the hash value from the UTF-8 encoded input string
//             byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));


//             // Convert the byte array to a lowercase hexadecimal string
//             return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
//         }
//     }
// }

var name = "Learning English";
// SHA256 sha256 = SHA256.Create();
// byte[] hashedName = sha256.ComputeHash(Encoding.UTF8.GetBytes(name));
// Console.WriteLine(BitConverter.ToString(hashedName));

string key = "1234567890123456";
var e = Encrypt(name, key);
var d = Decrypt(e, key);
Console.WriteLine(e);
Console.WriteLine(d);

static string Encrypt(string plainText, string key)
{
    using (Aes aesAlg = Aes.Create())
    {
        // Set the key and IV for AES encryption
        aesAlg.Key = Encoding.UTF8.GetBytes(key);
        aesAlg.IV = new byte[aesAlg.BlockSize / 8];


        // Create an encryptor
        ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);


        // Encrypt the data
        using (var msEncrypt = new System.IO.MemoryStream())
        {
            using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
            {
                swEncrypt.Write(plainText);
            }


            // Return the encrypted data as a Base64-encoded string
            return Convert.ToBase64String(msEncrypt.ToArray());
        }
    }
}


static string Decrypt(string cipherText, string key)
{
    using (Aes aesAlg = Aes.Create())
    {
        // Set the key and IV for AES decryption
        aesAlg.Key = Encoding.UTF8.GetBytes(key);
        aesAlg.IV = new byte[aesAlg.BlockSize / 8];


        // Create a decryptor
        ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);


        // Decrypt the data
        using (var msDecrypt = new System.IO.MemoryStream(Convert.FromBase64String(cipherText)))
        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
        using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
        {
            // Read the decrypted data from the StreamReader
            return srDecrypt.ReadToEnd();
        }
    }
}
