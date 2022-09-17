using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float damageVal;


    [SerializeField] private Slider healthBar;


    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxValue = health;
        healthBar.value = health;

    }

    // Update is called once per frame
    void Update()
    {
         health -= damageVal * Time.deltaTime;
        Debug.Log(health);
        healthBar.value = health;
    }
}
