using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour
{
    public Rigidbody2D rb;
    public float initGrav = 1f;
    public float highGrav = 1.5f;

    public float lerpDuration = 1;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
    }

    public IEnumerator Lerp(float origin, float target, float lerpDuration)
    {
        float timeElapsed = 0;

        while (timeElapsed < lerpDuration)
        {
            rb.gravityScale = Mathf.Lerp(origin, target, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;

            yield return null;
        }

        rb.gravityScale = target;
    }
}
