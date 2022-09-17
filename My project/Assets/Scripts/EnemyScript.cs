using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    [SerializeField] private Transform playerTransform;
    [SerializeField] private float sightRange;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float attackSpeed;

    private float currentTime = 0.2f;

    private Rigidbody2D rb;
    Vector2 distance;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
            Attack();


        distance = transform.position - playerTransform.position;
        if (distance.magnitude <= sightRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, moveSpeed);
            rb.MovePosition(playerTransform.position);
        }
    }


    void Attack()
    {
        currentTime = attackSpeed;
        Instantiate(projectile,transform.position,Quaternion.identity);
    }

}
