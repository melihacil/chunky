using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
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
        Invoke(nameof(DestroyBullet), 4f);
    }

    private void FixedUpdate()
    {
        rb.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
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
