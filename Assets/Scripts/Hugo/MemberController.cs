using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class MemberController : MonoBehaviour
{
    public Rigidbody2D rbarm;
    public Rigidbody2D rbleg;
    Vector2 direction;
    public float force;

    [SerializeField] private int playerID = 0;
    private Player player;

    private Vector3 armVector;
    private Vector3 legVector;

    // Members

   

    void Awake()
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

    private void Start()
    {
        
        direction = new Vector2(-force, 0) * Time.deltaTime;
    }

    private void Update()
    {
        
                

            GetInput();
            ProcessInput();
        
    }

   


    private void GetInput()
    {
        // Get the input from the Rewired Player. All controllers that the Player owns will contribute, so it doesn't matter
        // whether the input is coming from a joystick, the keyboard, mouse, or a custom controller.

        armVector.x = player.GetAxis("ArmHorizontal");
        armVector.y = player.GetAxis("ArmVertical");

        legVector.x = player.GetAxis("LegHorizontal");
        legVector.y = player.GetAxis("LegVertical");

        if (player.GetButton("GrabArm"))
        {
            Debug.Log("Grabbing Arm");
        }

        if (player.GetButton("GrabLeg"))
        {
            Debug.Log("Grabbing Leg");
        }

        if (player.GetButtonDown("Validate"))
        {
            Debug.Log("Validate");
        }

        if (player.GetButtonDown("Back"))
        {
            Debug.Log("Back");
        }

        if (armVector.x != 0 || armVector.y != 0)
        {
            rbarm.AddForce(new Vector2(armVector.x,armVector.y)* force);
            
        }

        if (legVector.x != 0 || legVector.y != 0)
        {
            rbleg.AddForce(new Vector2(legVector.x, legVector.y) * force);
        }   
    }

    private void ProcessInput()
    {
        if (armVector.x > 0)
        {
            Debug.Log("MovingArm");
        }

        if (legVector.x > 0)
        {
            Debug.Log("MovingLeg");
        }
    }
}
