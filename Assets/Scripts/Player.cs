using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int lives = 5;
    public float rotationSpeed = 50f;
    public float acceleration = 50f;
    public float deceleration = 0.1f;

    private Rigidbody2D rigid; // Default value is null

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // If user presses W OR up arrow
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            // Move forward
            rigid.AddForce(transform.right * acceleration);
        }

        // If user presses S OR down arrow
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            // Move backwards
            rigid.AddForce(-transform.right * acceleration);
        }

        // If user presses A OR left arrow
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            // Rotate left
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }


        // If user presses D or right arrow
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            // Rotate right
            transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }

        /*
        Arithmetic Operators
        +, -, *, /
        +=, -=, *=, /=
        Logic Operators 
        == (equal to)
        != (not equal to)
        */

        // Decelerating
        rigid.velocity += -rigid.velocity * deceleration;
    }
}
