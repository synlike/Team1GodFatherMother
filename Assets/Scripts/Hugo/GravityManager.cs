using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool Isgrapled = false;
    public float InitGrav;
    public float LowGrav;
    public float TimeGrav1;
    public float TimeGrav2;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    

    public void BeginScaling(bool Grapled) 
    {
        if (Grapled)
        {
            rb.gravityScale = Mathf.Lerp(InitGrav, LowGrav, TimeGrav1);
        }
        else
        {
            rb.gravityScale = Mathf.Lerp(LowGrav, InitGrav, TimeGrav2);
        }
    
    
    }

    


}
