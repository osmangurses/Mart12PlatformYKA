using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PrefScript : MonoBehaviour
{

    [SerializeField] TMP_InputField input;
    [SerializeField] TextMeshProUGUI output;

    public void VeriyiKaydet()
    {
        PlayerPrefs.SetInt("yas",int.Parse(input.text));
    }
    public void VeriyiGoster()
    {
        PlayerPrefs.SetInt("yas",PlayerPrefs.GetInt("yas")+1);
        output.text = PlayerPrefs.GetInt("yas").ToString();
    }

}