using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class TestGrab : MonoBehaviour
{
    public CircleCollider2D col;
    public Rigidbody2D rb;

    [SerializeField] private int playerID = 0;
    private Player player;

    [SerializeField]
    private bool isLeg = false;
    private bool isGrab = false;
    private bool ropeGrab = false;

    private void Awake()
    {
        if (playerID == 0)
        {
            player = ReInput.players.GetPlayer(0);
        }
        else
        {
            player = ReInput.players.GetPlayer(1);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetButtonUp("GrabArm"))
        {
            isGrab = false;
            if (ropeGrab)
                Destroy(GetComponent<FixedJoint2D>());
            ropeGrab = false;
        }
        
        if (player.GetButtonUp("GrabLeg"))
        {
            isGrab = false;
            if (ropeGrab)
                Destroy(GetComponent<FixedJoint2D>());
            ropeGrab = false;
        }

        if (isGrab)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (((player.GetButton("GrabArm") && !isLeg)) || ((player.GetButton("GrabLeg") && isLeg)))
        {
            if(other.gameObject.CompareTag("Rope") && !ropeGrab)
            {
                Debug.Log("GRAB ROPE");
                ropeGrab = true;
                Rigidbody2D rb = other.transform.GetComponent<Rigidbody2D>();
                if(rb != null)
                {
                    FixedJoint2D fixedJoint = transform.gameObject.AddComponent(typeof(FixedJoint2D)) as FixedJoint2D;
                    fixedJoint.connectedBody = rb;
                }
                else
                {
                    FixedJoint2D fixedJoint = transform.gameObject.AddComponent(typeof(FixedJoint2D)) as FixedJoint2D;
                }

            }

            if (other.gameObject.CompareTag("Grable"))
                isGrab = true;
        }
    }
}
