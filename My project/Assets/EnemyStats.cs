using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    [Header("Health Attributes")]
    [SerializeField] private float maxHealth;
    private float health;

    [SerializeField] private Slider healthSlider;



    private void Start()
    {
        health = maxHealth;
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }

    public void DamageHealth(float damage)
    {
         health -= damage;
        healthSlider.value -= damage;
    }
}
