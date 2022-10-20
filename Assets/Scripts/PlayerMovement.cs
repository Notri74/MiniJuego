using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    private float movementX;
    private float movementY;
    public float movementjump;

    public TMP_Text countText;
    public int count;
   

    void Start()
    {
        rb = GetComponent<Rigidbody>();
       movementjump = 0;
        count =0;
        setText();
        Console.WriteLine("empezamos");
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movement = movementValue.Get<Vector2>();

        movementX = movement.x;
        movementY = movement.y;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        /*Vector3 movement = new Vector3(movementX, 0.0f, movementY);*/
        Vector3 movement = new Vector3(movementX, movementjump, movementY);
        rb.AddForce(movement* speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        count++;
        Console.WriteLine(count.ToString());
        Console.WriteLine("Chocaste");
    }

    private void setText()
    {
        
        countText.text = "Score "+ count.ToString();
    }

    private void onJump() {
        if (transform.position.y > 0.5)
        {
            movementjump=10.0f;
        }
    
    }
}
