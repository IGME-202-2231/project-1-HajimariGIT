using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 objectPosition = Vector3.zero;
    float speed = 4.0f;
    Vector3 direction = Vector3.up;
    Vector3 velocity = Vector3.zero;
    private float totalCamheight;
    int test;
    private float totalCamwidth;
    [SerializeField] GameObject bullet;
    Vector3 bulletPos;
    bool bulletActive = false;
    

    void Start()
    {
        objectPosition = transform.position;
        totalCamheight = 2f * Camera.main.orthographicSize;
        totalCamwidth = totalCamheight * Camera.main.aspect;
        direction = Vector3.zero;
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletPos = new Vector3(objectPosition.y, objectPosition.x);

        if (Input.GetMouseButtonDown(0))
        {
            //change the state of game to opposite equation 

            Instantiate(bullet, bulletPos, Quaternion.identity);
            bulletActive = true;

            if(bulletActive)
            {
                bulletPos += Vector3.forward;
                bullet.transform.position = bulletPos;
            }
        }




        velocity = direction * speed * Time.deltaTime;
       objectPosition += velocity;

        if (objectPosition.y > totalCamheight / 2f)
        {
            objectPosition = new Vector3(objectPosition.x, -totalCamheight / 2f, objectPosition.z);
        }
        else if (objectPosition.y < -totalCamheight / 2f)
        {
            objectPosition = new Vector3(objectPosition.x, totalCamheight / 2f, objectPosition.z);
        }

        if (objectPosition.x > totalCamwidth /2f)
        {
            objectPosition= new Vector3(-totalCamwidth/2f,objectPosition.y,objectPosition.z);
        }
        else if(objectPosition.x < -totalCamwidth / 2f)
        {
            objectPosition = new Vector3(totalCamwidth / 2f, objectPosition.y,objectPosition.z);
        }

        

        transform.position = objectPosition;

        


    }


    public void SetDirection(Vector2 input)
    {
      if(input != null)
      {
            direction = input;

            

        }
        
       
    }


}
