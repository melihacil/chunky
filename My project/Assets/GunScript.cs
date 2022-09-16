using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{

    Vector2 mousePos;
    Vector2 mouseDelta;
    [SerializeField] private Transform barrelPos;
    float angle;
    [SerializeField] private AudioClip gunShot;
    [SerializeField] private AudioSource source;
    [SerializeField] private GameObject brass;
    [SerializeField] private Slider reloadSlider;
    [SerializeField] private SpriteRenderer magazine;
    [SerializeField] private Animator ammoAnimator;
    [SerializeField] private float reloadDelay;
    [SerializeField] private GameObject bullet;
    private float currentDelay;
    private bool isReloading;
    private bool reloadInput;


     bool flipped;
    // Start is called before the first frame update
    void Start()
    {
        ammoAnimator.SetTrigger("Ammo7");
        currentDelay = reloadDelay;
        reloadSlider.maxValue = reloadDelay;
        reloadSlider.value = 0;
    }


    int ammoCount = 7;

    // Update is called once per frame
    void Update()
    {
        reloadInput = Input.GetButtonDown("Reload");
        if (reloadInput)
        {
            isReloading = true;
            magazine.enabled = false;
        }
        if (Input.GetButtonDown("Fire1") && !isReloading)
        {
            currentDelay = reloadDelay;
            ammoCount--;
            if (ammoCount >= 0)
            {
                ammoAnimator.SetTrigger("Ammo" + ammoCount);
                Instantiate(brass, transform.position, Quaternion.identity);
                Instantiate(bullet, transform.position, Quaternion.identity);
                GetComponent<Animator>().SetTrigger("Shoot");
                source.Play();
            }              
            Debug.Log(ammoCount);
            
        }
        else if (isReloading)
        {
            
            ReloadFunction();
        }

    }

    private void ReloadFunction()
    {
        
        reloadSlider.value = currentDelay;
        currentDelay -= Time.deltaTime;
        //Resetting everything
        if (currentDelay <= 0)
        {
            isReloading = false;
            ammoAnimator.SetTrigger("Ammo7");
            magazine.enabled = true;
            //magazine.isVisible = false;
            
            ammoCount = 7;
        }
    }

    private void FixedUpdate()
    {
        RotateGun();

    }

    private void RotateGun()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //difference.Normalize();
        difference.x = difference.x - barrelPos.position.x;
        difference.y = difference.y - barrelPos.position.y;
        difference.Normalize();
        angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        if (angle > 90.01f || angle < -90.01f)
        {
            
            if (!flipped)
            {
                Vector3 scaleTemp = transform.localScale;
                //scaleTemp.x *= -1;
                scaleTemp.y *= -1;
                flipped = true;

                transform.localScale = scaleTemp;
            }
            //transform.localScale *= -1;
            
        }
        else
        {
            if (flipped)
            {
                Vector3 scaleTemp = transform.localScale;
                //scaleTemp.x *= -1;
                scaleTemp.y *= -1;
                flipped = true;

                transform.localScale = scaleTemp;
            }
            flipped=false;
            transform.localRotation = Quaternion.Euler(0f,0f, angle);
        }
        //transform.localScale *= -1;
    }
}
