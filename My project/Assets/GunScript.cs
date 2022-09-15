using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{

    Vector2 mousePos;
    Vector2 mouseDelta;
    [SerializeField] private Transform barrelPos;
    float angle;

    bool flipped;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GetComponent<Animator>().SetTrigger("Shoot");
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
