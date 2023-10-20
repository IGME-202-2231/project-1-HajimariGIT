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
    float deccel=5;
    

    void Start()
    {
     
        totalCamheight = 2f * Camera.main.orthographicSize;
        totalCamwidth = totalCamheight * Camera.main.aspect;
        
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 current = transform.position;

    

        if (current.y < -10.8)
        {
            current.y = -10.8f;
        }
        else if (current.y > 10.44)
        {
            current.y = 10.44f;
        }

        if (current.x > 24.96)
        {
            current.x = 24.96f;
        }
        else if (current.x < -25.53)
        {
            current.x = -25.53f;
        }
        transform.position = current;


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
