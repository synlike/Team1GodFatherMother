using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class TestGrab : MonoBehaviour
{
    public GravityManager gravityManager;
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
        if (player.GetButtonUp("GrabArm") && !isLeg)
        {
            UnGrab();

            if (ropeGrab)
                Destroy(GetComponent<FixedJoint2D>());
            ropeGrab = false;
        }
        
        if (player.GetButtonUp("GrabLeg") && isLeg)
        {
            UnGrab();

            if (ropeGrab)
                Destroy(GetComponent<FixedJoint2D>());
            ropeGrab = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
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
            {
                if (!isGrab)
                {
                    Grab();
                }
                
                isGrab = true;
            }
        }
    }

    private void Grab()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        rb.bodyType = RigidbodyType2D.Kinematic;
        StartCoroutine(gravityManager.Lerp(gravityManager.highGrav, gravityManager.initGrav, 0));
    }

    private void UnGrab()
    {
        rb.constraints = RigidbodyConstraints2D.None;
        rb.bodyType = RigidbodyType2D.Dynamic;
        StartCoroutine(gravityManager.Lerp(gravityManager.initGrav, gravityManager.highGrav, gravityManager.lerpDuration));


        isGrab = false;
    }
}
