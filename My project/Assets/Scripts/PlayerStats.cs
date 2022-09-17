using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float health;
    private float maxHealth;
    [SerializeField] private float damageVal;


    [SerializeField] private Slider healthBar;


    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        healthBar.maxValue = health;
        healthBar.value = health;

    }

    // Update is called once per frame
    void Update()
    {
         health -= damageVal * Time.deltaTime;
        
        healthBar.value = health;

        if (health <= 0)
        {
            Debug.Log("Died");
        }
    }

    public void AddHealth(float value)
    {
        health += value;
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
