using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float health;
    private float maxHealth;
    [SerializeField] private float damageVal;
    [SerializeField] private float maxDamage;


    [SerializeField] private Slider healthBar;

    [SerializeField] private float damageUpTimer;
    private float resetTimer;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        healthBar.maxValue = health;
        healthBar.value = health;
        resetTimer = damageUpTimer;
    }

    // Update is called once per frame
    void Update()
    {
        damageUpTimer -= Time.deltaTime;
        if (damageUpTimer <= 0 && damageVal < maxDamage)
        {
            damageVal += 1;
            damageUpTimer = resetTimer;
        }
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

    public void Damage(float val)
    {
        health -= val;
        if (health < 0)
        {
            Debug.Log("Ded");
        }
    }
}
