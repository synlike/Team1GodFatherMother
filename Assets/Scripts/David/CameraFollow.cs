using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public Vector2 offset;
    public float speed = 2f;

    public float minY = 0f, maxY = 0f;

    private Vector2 treshold;
    private Rigidbody2D rb;


    void Start()
    {
        treshold = CalculateTreshold();
        rb = target.GetComponent<Rigidbody2D>();
    }



    void FixedUpdate()
    {
        Vector2 follow = target.transform.position;

        float xDif = Vector2.Distance(Vector2.right * transform.position.x, Vector2.right * follow.x);
        float yDif = Vector2.Distance(Vector2.up * transform.position.y, Vector2.up * follow.y);

        Vector3 newPosition = transform.position;
        if(Mathf.Abs(xDif) >= treshold.x)
        {
            newPosition.x = follow.x;
        }
        if(Mathf.Abs(yDif) >= treshold.y)
        {
            newPosition.y = follow.y;
        }


        transform.position = Vector3.Lerp(transform.position, newPosition, speed * Time.deltaTime);

        /*
        float moveSpeed = rb.velocity.magnitude > speed ? rb.velocity.magnitude : speed;

        transform.position = Vector3.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);
        */

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, minY, maxY), transform.position.z);
    }

    private Vector3 CalculateTreshold()
    {
        Rect aspect = Camera.main.pixelRect;
        Vector2 t = new Vector2(Camera.main.orthographicSize * aspect.width / aspect.height, Camera.main.orthographicSize);

        t.x -= offset.x;
        t.y -= offset.y;

        return t;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector2 border = CalculateTreshold();

        Vector3 offsetY = new Vector3(0f, 4f, 0f);
        Gizmos.DrawWireCube(transform.position - offsetY, new Vector3(border.x * 2, border.y * 2, 1));
    }
}
