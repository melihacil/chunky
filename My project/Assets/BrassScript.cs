using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrassScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool firstLaunch = false;
    private float upwardsForce = 5f;

    private void Awake()
    {
        
            rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (!firstLaunch)
        {
            
            rb.AddForce(Vector2.up * upwardsForce, ForceMode2D.Impulse);
            Invoke(nameof(DestroyBrass), 5f);
            Invoke(nameof(DisableRb), 1.3f);
            firstLaunch = true;
        }
    }

    void DisableRb()
    {
        //rb.isKinematic = true;
        rb.velocity = Vector2.zero;
        rb.gravityScale = 0f;
        
    }

    void DestroyBrass()
    {
        Destroy(gameObject);
    }
}
