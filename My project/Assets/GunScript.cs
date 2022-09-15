using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{

    Vector2 mousePos;
    Vector2 mouseDelta;
    [SerializeField] private Transform barrelPos;
    float angle;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {

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
        angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        /*
        if (angle < 90 || angle < -90)
        {
            if (gameObject.transform.eulerAngles.y == 0)
            {
                transform.localRotation = Quaternion.Euler(190f, 0f, -angle);
            }
            else if (gameObject.transform.eulerAngles.y == 180)
            {
                transform.localRotation = Quaternion.Euler(180, 180, angle);
            }
        }
        */
    }
}
