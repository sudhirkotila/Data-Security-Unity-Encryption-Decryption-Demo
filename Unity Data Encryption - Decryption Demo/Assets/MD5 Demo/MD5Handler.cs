using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using System.Security.Cryptography;


public class MD5Handler : MonoBehaviour
{
    //Text
    public InputField inputTextField;
    public InputField outputTextField;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnEncrypt()
    {
        outputTextField.text = MD5Encryption(inputTextField.text);
    }

    public void OnDecrypt()
    {
        outputTextField.text = MD5Decryption(inputTextField.text);
    }

    //MD5 - Encription 
    public string MD5Encryption(string inputData)
    {
        string hasKey = "Password@SudhirKotila12:34"; //You can use any string here as haskey
        byte[] bData = UTF8Encoding.UTF8.GetBytes(inputData);

        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        TripleDESCryptoServiceProvider tripalDES = new TripleDESCryptoServiceProvider();

        tripalDES.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hasKey));
        tripalDES.Mode = CipherMode.ECB;

        ICryptoTransform trnsfrm = tripalDES.CreateEncryptor();
        byte[] result = trnsfrm.TransformFinalBlock(bData, 0, bData.Length);

        return Convert.ToBase64String(result);
    }

    //MD5 -  Decryption
    public string MD5Decryption(string inputData)
    {
        string hasKey = "Password@SudhirKotila12:34"; //You can use any string here as haskey
        byte[] bData = Convert.FromBase64String(inputData);

        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        TripleDESCryptoServiceProvider tripalDES = new TripleDESCryptoServiceProvider();

        tripalDES.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hasKey));
        tripalDES.Mode = CipherMode.ECB;

        ICryptoTransform trnsfrm = tripalDES.CreateDecryptor();
        byte[] result = trnsfrm.TransformFinalBlock(bData, 0, bData.Length);

        return UTF8Encoding.UTF8.GetString(result);
    }
}
