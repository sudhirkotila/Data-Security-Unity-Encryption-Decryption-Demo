using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;


public class XORHandler : MonoBehaviour
{
    //Text
    public InputField inputTextField;
    public InputField outputTextField;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnEncryptDecyptData()
    {
        outputTextField.text = XOREncryptDecrypt(inputTextField.text);
    }

    //XOR - Encription & Decryption
    public string XOREncryptDecrypt(string inputData)
    {
        StringBuilder outSB = new StringBuilder(inputData.Length);
        for (int i = 0; i < inputData.Length; i++)
        {
            char ch = (char)(inputData[i] ^ 1234); //Here 1234 is key for Encrypt/Decrypt, You can use any interger number
            outSB.Append(ch);
        }
        return outSB.ToString();
    }
}
