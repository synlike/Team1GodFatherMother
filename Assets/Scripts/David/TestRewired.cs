using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class TestRewired : MonoBehaviour
{
    [SerializeField] private int playerID = 0;

    // The Rewired Player
    private Player player;
    private Vector3 armVector;
    private Vector3 legVector;

    // Members

    [SerializeField] private GameObject arm;
    [SerializeField] private GameObject leg;


    void Awake()
    {
        if(playerID == 0)
        {
            player = ReInput.players.GetPlayer(0);
        }
        else
        {
            player = ReInput.players.GetPlayer(1);
        }
    }


    void Update()
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
    }

    private void ProcessInput()
    {
        if(armVector.x > 0)
        {
            Debug.Log("MovingArm");
        }

        if(legVector.x > 0)
        {
            Debug.Log("MovingLeg");
        }
    }
}
