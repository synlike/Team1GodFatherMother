using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemberController : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 direction;
    public float force;
    
    private void Start()
    {
        
        direction = new Vector2(-force, 0) * Time.deltaTime;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Mouvement();
        }
    }

    void Mouvement() 
    {
        rb.AddForce(direction);
    }
}
