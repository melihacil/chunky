using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{

    Vector2 mousePos;
    Vector2 mouseDelta;
    [SerializeField] private Transform barrelPos;
    float angle;
    [SerializeField] private AudioClip gunShot;
    [SerializeField] private AudioSource source;
    [SerializeField] private GameObject brass;

    [SerializeField] private Animator ammoAnimator;

     bool flipped;
    // Start is called before the first frame update
    void Start()
    {
        ammoAnimator.SetTrigger("Ammo7");
    }


    int ammoCount = 7;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ammoCount--;
            if (ammoCount >= 0)
            {
                ammoAnimator.SetTrigger("Ammo" + ammoCount);
            }              
            Debug.Log(ammoCount);
            Instantiate(brass, transform.position,Quaternion.identity);
            GetComponent<Animator>().SetTrigger("Shoot");
            source.Play();
        }
        if(Input.GetButtonDown("Reload"))
        {

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
