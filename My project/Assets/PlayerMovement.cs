using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float inputH;
    public float inputV;

    private Rigidbody2D rb;

    [Header ("Movement Speeds")]
    [SerializeField] private float maxSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float deceleration;
    [SerializeField] private float velocityPow;
    [SerializeField] private float speedH;
    [SerializeField] private float speedV;
    //[Header("Movement Horizontal")]


    //Horizontal movement
    private float targetSpeedH;
    private float speedDifferenceH;
    private float accelerationRateH;
    //Vertical movement
    private float targetSpeedV;
    private float speedDifferenceV;
    private float accelerationRateV;
    // Start is called before the first frame update

    [SerializeField] private GameObject gun;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }


    //Need to add roll 
    //Bullets
    //Enemys
    //Tilemaps
    //PowerUps
    //Health system with donuts or other food
    //Health will decrease with time so you'll need to eat food and avoid or kill enemies
    // Update is called once per frame
    void Update()
    {
        inputH = Input.GetAxisRaw("Horizontal");
        inputV = Input.GetAxisRaw("Vertical");

        //Debug.Log(rb.velocity);
    }

    private void FixedUpdate()
    {
        MoveHorizontal();
        MoveVertical();
        //Mathf.Clamp(rb.velocity, 0.0f,maxSpeed);
        //Clamping velocity to avoid adding 2 maxSpeeds when moving both horizontally and vertically
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        //RotateGun();
    }

   

    private void MoveVertical()
    {
        targetSpeedV = inputV * maxSpeed;


        speedDifferenceV = targetSpeedV - rb.velocity.y;

        accelerationRateV = (Mathf.Abs(speedDifferenceV) > 0.01f) ? acceleration : deceleration;

        speedV = Mathf.Pow(Mathf.Abs(speedDifferenceV) * accelerationRateV, velocityPow) * Mathf.Sign(speedDifferenceV);

        rb.AddForce(Vector2.up * speedV);
    }

    private void MoveHorizontal()
    {
        targetSpeedH = inputH * maxSpeed;


        speedDifferenceH = targetSpeedH - rb.velocity.x;

        accelerationRateH =(Mathf.Abs(speedDifferenceH) > 0.01f) ? acceleration : deceleration;

        speedH = Mathf.Pow(Mathf.Abs(speedDifferenceH) * accelerationRateH, velocityPow) * Mathf.Sign(speedDifferenceH);

        rb.AddForce(Vector2.right * speedH);

    }

}
