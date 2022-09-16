using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool shot;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!shot)
        {
            shot = true;
            Invoke(nameof(DestroyBullet), 4f);
            Vector3 camPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rb.AddForce((camPos - transform.position) * 10, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.layer == 9)
        {
            Debug.Log("Hit Enemy");
        }
    }


    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
