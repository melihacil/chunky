using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{


    [SerializeField] private float healthVal;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == 10)
        {
            collision.gameObject.GetComponent<PlayerStats>();
        }
    }
}
