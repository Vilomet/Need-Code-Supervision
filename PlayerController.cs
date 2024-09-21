using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float ThrustForce;
    public float TorqueForce;
    public static float Speed;

    private Rigidbody2D rigidBody2D;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigidBody2D.AddForce(transform.up * ThrustForce);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rigidBody2D.AddForce(transform.up * -ThrustForce);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rigidBody2D.AddTorque(-TorqueForce);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rigidBody2D.AddTorque(TorqueForce);
        }
    }
}
