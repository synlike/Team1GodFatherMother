using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class TestGrab : MonoBehaviour
{
    public CircleCollider2D col;
    private Vector3 wallPoint;
    public Rigidbody2D rb;

    [SerializeField] private int playerID = 0;
    private Player player;

    [SerializeField]
    private bool isGrab = false;

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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Grable") && player.GetButton("GrabArm"))
        {
            isGrab = true;
        }
    }

    
}
