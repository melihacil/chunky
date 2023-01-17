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

    [SerializeField] private GameObject DeathPanel;
    [SerializeField] private GameObject ResumePanel;

    [SerializeField] private Slider healthBar;

    [SerializeField] private float damageUpTimer;
    private float resetTimer;


    private void Awake()
    {
        DeathPanel.SetActive(false);
        ResumePanel.SetActive(false);
    }
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

        if (Input.GetButtonDown("Cancel"))
        {
            ResumePanel.SetActive(true);
            PauseLevel();
        }

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
            PauseLevel();
            ResumePanel.SetActive(false);
            DeathPanel.SetActive(true);
            //FindObjectOfType
            Debug.Log("Died");
        }
    }

    public void ResetLevel()
    {
        Time.timeScale = 1f;
        FindObjectOfType<GameManager>().NextLevel();
    }

    public void PauseLevel()
    {
        //ResumePanel?.SetActive(false);
        Time.timeScale = 0f;
    }

    public void ResumeLevel()
    {
        ResumePanel?.SetActive(false);
        Time.timeScale = 1f;
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
