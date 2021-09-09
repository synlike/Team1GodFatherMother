using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGrounded : MonoBehaviour
{
    public bool isGrounded;
    private bool testGrounded;

    public bool isGrab;
    private bool testGrab;


    private CheckCollision[] listColliderElements;
    public TestGrab[] listGrab;
    public GravityManager gravityManager;
    

    private void Start()
    {
        listColliderElements = GetComponentsInChildren<CheckCollision>();
        listGrab = GetComponentsInChildren<TestGrab>();
    }

    // Update is called once per frame
    void Update()
    {
        testGrounded = false;
        testGrab = false;

        foreach (CheckCollision collider in listColliderElements)
        {
            if (collider.isGrounded)
                testGrounded = true;
        }

        foreach(TestGrab grab in listGrab)
        {
            if (grab.isGrab)
                testGrab = true;
        }

        if (testGrounded)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (testGrab)
        {
            isGrab = true;
        }
        else
        {
            isGrab = false;
        }

        if(!isGrab && !isGrounded)
        {
            if(gravityManager.rb.gravityScale == gravityManager.initGrav)
            {
                StartCoroutine(gravityManager.Lerp(gravityManager.initGrav, gravityManager.highGrav, gravityManager.lerpDuration));
            }
        }
        else if(isGrounded && !isGrab)
        {
            if (gravityManager.rb.gravityScale == gravityManager.highGrav)
            {
                StartCoroutine(gravityManager.Lerp(gravityManager.highGrav, gravityManager.initGrav, 0));
            }
        }
    }
}
