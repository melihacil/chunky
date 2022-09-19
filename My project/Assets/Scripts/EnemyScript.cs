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

    private bool enemyForward = true;
    private bool playerSide = false;

    private Rigidbody2D rb;
    Vector2 distance;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        playerTransform = FindObjectOfType<PlayerMovement>().gameObject.transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            collision.gameObject.GetComponent<PlayerMovement>().AddKnockBack(transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {

        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
            Attack();


        distance = transform.position - playerTransform.position;
        //turn block
        //starts with false (looking right)
        playerSide = distance.x < 0;
        if (playerSide)
        {
            if (playerSide != enemyForward) { 
            
                enemyForward = playerSide;
                transform.forward *= -1;
            }
        }
        else
        {
            if (playerSide != enemyForward)
            {

                enemyForward = playerSide;
                transform.forward *= -1;
            }
        }
        
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
