using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musicsource : MonoBehaviour
{
    private static Musicsource _instance;

    public static Musicsource Instance { get { return _instance; } }


    void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
            GetComponent<AudioSource>().Play();
        }
        else
        {
            Destroy(this);
        }
    }
}
