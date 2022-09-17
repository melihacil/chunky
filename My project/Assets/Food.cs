using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{


    [SerializeField] private float healthVal;
    [SerializeField] private float radius;

    private void Update()
    {
        Collider2D[] collisions = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach(Collider2D collision in collisions)
        {
            if (collision.gameObject.layer == 10)
            {
                collision.gameObject.GetComponent<PlayerStats>().AddHealth(healthVal);
                Destroy(gameObject);
            }
        }
        
    }

}
