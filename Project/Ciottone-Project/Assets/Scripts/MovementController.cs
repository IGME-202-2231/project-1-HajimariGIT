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
    float accel = 16;
    float deccel=3;
    

    void Start()
    {
     
        totalCamheight = 2f * Camera.main.orthographicSize;
        totalCamwidth = totalCamheight * Camera.main.aspect;
        
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 objectPosition = transform.position;



        if (objectPosition.y > totalCamheight / 2f)
        {
            objectPosition = new Vector3(objectPosition.x, -totalCamheight / 2f, objectPosition.z);
        }
        else if (objectPosition.y < -totalCamheight / 2f)
        {
            objectPosition = new Vector3(objectPosition.x, totalCamheight / 2f, objectPosition.z);
        }

        if (objectPosition.x > totalCamwidth / 2f)
        {
            objectPosition = new Vector3(-totalCamwidth / 2f, objectPosition.y, objectPosition.z);
        }
        else if (objectPosition.x < -totalCamwidth / 2f)
        {
            objectPosition = new Vector3(totalCamwidth / 2f, objectPosition.y, objectPosition.z);
        }



        transform.position = objectPosition;

    


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


        


        transform.position += velocity * Time.deltaTime;



        if (direction == Vector3.zero)
        {
            velocity -= velocity.normalized * deccel * Time.deltaTime;

            // Ensure the velocity does not go below zero
            if (velocity.magnitude < 0.1f)
            {
                velocity = Vector2.zero;
            }
        }
       



    }


    public void SetDirection(Vector2 input)
    {
      if(input != null)
      {
           

            

        }
        
       
    }


}
