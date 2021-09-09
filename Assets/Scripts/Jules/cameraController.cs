using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform playerBody;
    public Vector3 offset;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newCamPos = new Vector3(transform.position.x + offset.x, playerBody.position.y + offset.y, offset.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, newCamPos, speed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
