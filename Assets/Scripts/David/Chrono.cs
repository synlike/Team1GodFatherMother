using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chrono : MonoBehaviour
{
    public TextMeshProUGUI textChrono;
    float chrono = 0;


    void Update()
    {
        chrono += Time.deltaTime;

        textChrono.text = ((int)chrono).ToString();
    }
}
