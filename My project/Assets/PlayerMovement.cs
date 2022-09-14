using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float input;

    private Rigidbody2D rb;

    [SerializeField] private float maxSpeed;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        MoveHorizontal();
    }


    float acceleration;
    float deceleration;
    float velocityPow;

    float speed;
    private void MoveHorizontal()
    {
        float targetSpeed = input * maxSpeed;


        float speedDifference = targetSpeed - rb.velocity.x;

        float accelerationRate =(Mathf.Abs(speedDifference) > 0.01f) ? acceleration : deceleration;

        speed = Mathf.Pow(Mathf.Abs(speedDifference) * accelerationRate, velocityPow) * Mathf.Sign(speedDifference);

        rb.AddForce(Vector2.right * speed);

    }

}
