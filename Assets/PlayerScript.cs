using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D rb2D;

    public float speed;

    public float maxRotationSpeed;
    public float rotationSpeed;
    private float rotationAccel;

    public float interval;
    private float timer;
    

    // Start is called before the first frame update
    void Start()
    {
        timer = interval;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            rotationAccel = Random.Range(-10f, 10f);
            timer = 0;
        }

        rotationSpeed += rotationAccel * Time.deltaTime;

        rotationSpeed = Mathf.Min(rotationSpeed, maxRotationSpeed);
        rotationSpeed = Mathf.Max(rotationSpeed, -maxRotationSpeed);
    }

    private void FixedUpdate()
    {
        rb2D.SetRotation(rb2D.rotation + rotationSpeed * Time.fixedDeltaTime);
        rb2D.AddForce(transform.up * speed * Time.fixedDeltaTime);
    }
}
