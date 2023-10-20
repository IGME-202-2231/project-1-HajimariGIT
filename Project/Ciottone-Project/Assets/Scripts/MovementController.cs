using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    // Start is called before the first frame update
    
    float speed = 4.0f;
    Vector3 velocity = Vector3.zero;
    private float totalCamheight;
    int test;
    private float totalCamwidth;
    float x;
    private float y;
    float accel = 10;
    float deccel=2;
    

    void Start()
    {
     
        totalCamheight = 2f * Camera.main.orthographicSize;
        totalCamwidth = totalCamheight * Camera.main.aspect;
        
        
    }

    // Update is called once per frame
    void Update()
    {


    

        if (transform.position.y > totalCamheight / 2f + .5)
        {
            transform.position = new Vector3(transform.position.x, totalCamheight / 2f +.5f, transform.position.z);
        }
        else if (transform.position.y < -totalCamheight / 2f + .5)
        {
            transform.position = new Vector3(transform.position.x, -totalCamheight / 2f + .5f, transform.position.z);
        }

        if (transform.position.x > totalCamwidth / 2f + .5)
        {
            transform.position = new Vector3(totalCamwidth / 2f + 5f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -totalCamwidth / 2f + .5)
        {
            transform.position = new Vector3(-totalCamwidth / 2f + 5f, transform.position.y, transform.position.z);
        }


        Vector3 direction = new Vector3(0, 0, 0);




        if(Input.GetKey(KeyCode.W))
        {
            direction.y = 1;

        }
        if (Input.GetKey(KeyCode.A))
        {
            direction.x =- 1;

        }
        if (Input.GetKey(KeyCode.D))
        {
            direction.x = 1;

        }
        if (Input.GetKey(KeyCode.S))
        {
            direction.y = -1;

        }

        

        velocity += direction * accel * Time.deltaTime;


        if (direction == Vector3.zero)
        {
            velocity -= velocity * deccel * Time.deltaTime;

            if(velocity.magnitude <0.1)
            {
                velocity = Vector3.zero;
            }
        }


        transform.position += velocity * Time.deltaTime;



       

        


    }


    public void SetDirection(Vector2 input)
    {
      if(input != null)
      {
           

            

        }
        
       
    }


}
