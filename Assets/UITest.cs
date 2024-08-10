using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UITest : MonoBehaviour
{

    public TextMeshProUGUI input_text;
    public Toggle toggle;
    public TMP_Dropdown dropdown;
    public Slider slider;
    public AudioSource audioSource;
    private void Start()
    {
        Debug.Log("Input text: " + input_text.text);
        if (toggle.isOn)
        {
            Debug.Log("Toggle Açýk");
        }
        else
        {
            Debug.Log("Toggle Kapalý");
        }
        Debug.Log("Dropdown value: "+dropdown.value);
        Debug.Log("Slider value: "+slider.value);
        audioSource.volume = slider.value;

    }
    public void changeSound()
    {
        audioSource.volume = slider.value;
    }
}
