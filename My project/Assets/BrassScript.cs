using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrassScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool firstLaunch;
    private float upwardsForce = 5f;

    private void Awake()
    {
        
            rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (!firstLaunch)
            rb.AddForce(Vector2.up * upwardsForce);
    }
}
