using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemberController : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 direction;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        direction = new Vector2(-2, 0) * Time.deltaTime;
    }

    void Mouvement() 
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            rb.AddForce(direction);

        }
    
    }
}
