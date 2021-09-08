using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTestLeft : MonoBehaviour
{
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(new Vector2(-50, 75));
        }
    }
}
