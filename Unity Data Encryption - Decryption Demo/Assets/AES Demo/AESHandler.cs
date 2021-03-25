using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using System.Security.Cryptography;


public class AESHandler : MonoBehaviour
{
    //Text
    public InputField inputTextField;
    public InputField outputTextField;

    string key = "A60A5770FE5E7AB200BA9CFC94E4E8B0"; //set any string of 32 chars
    string iv = "1234567887654321"; //set any string of 16 chars

    // Start is called before the first frame update
    void Start()
    {
    }

    public void OnEncrypt()
    {
        outputTextField.text = AESEncryption(inputTextField.text);
    }

    public void OnDecrypt()
    {
        outputTextField.text = AESDecryption(inputTextField.text);
    }

    //AES - Encription 
    public string AESEncryption(string inputData)
    {
        AesCryptoServiceProvider AEScryptoProvider = new AesCryptoServiceProvider();
        AEScryptoProvider.BlockSize = 128;
        AEScryptoProvider.KeySize = 256;
        AEScryptoProvider.Key = ASCIIEncoding.ASCII.GetBytes(key);
        AEScryptoProvider.IV = ASCIIEncoding.ASCII.GetBytes(iv);
        AEScryptoProvider.Mode = CipherMode.CBC;
        AEScryptoProvider.Padding = PaddingMode.PKCS7;

        byte[] txtByteData = ASCIIEncoding.ASCII.GetBytes(inputData);
        ICryptoTransform trnsfrm = AEScryptoProvider.CreateEncryptor(AEScryptoProvider.Key, AEScryptoProvider.IV);

        byte[] result = trnsfrm.TransformFinalBlock(txtByteData, 0, txtByteData.Length);
        return Convert.ToBase64String(result);
    }

    //AES -  Decryption
    public string AESDecryption(string inputData)
    {
        AesCryptoServiceProvider AEScryptoProvider = new AesCryptoServiceProvider();
        AEScryptoProvider.BlockSize = 128;
        AEScryptoProvider.KeySize = 256;
        AEScryptoProvider.Key = ASCIIEncoding.ASCII.GetBytes(key);
        AEScryptoProvider.IV = ASCIIEncoding.ASCII.GetBytes(iv);
        AEScryptoProvider.Mode = CipherMode.CBC;
        AEScryptoProvider.Padding = PaddingMode.PKCS7;

        byte[] txtByteData = Convert.FromBase64String(inputData);
        ICryptoTransform trnsfrm = AEScryptoProvider.CreateDecryptor();

        byte[] result = trnsfrm.TransformFinalBlock(txtByteData, 0, txtByteData.Length);
        return ASCIIEncoding.ASCII.GetString(result);
    }
}
