using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    private Rigidbody2D rb;

    private Transform player;
    private bool isShot;

    [SerializeField] private float fireBallForce;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject.transform;
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        if (!isShot)
        {
            isShot = true;

            rb.AddForce(player.position - transform.position * fireBallForce, ForceMode2D.Impulse);
            Invoke(nameof(DestroyFireball), 5f);
        }
    }
    private void DestroyFireball()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            collision.gameObject.GetComponent<PlayerStats>().Damage(5f);
        }
        Destroy(gameObject);
    }

}
