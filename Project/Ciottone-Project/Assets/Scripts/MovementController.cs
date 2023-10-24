using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    // Start is called before the first frame update
    
    //speed of charcter
    float speed = 4.0f;
    //velocity 
    Vector3 velocity = Vector3.zero;
    private float totalCamheight;
    int test;
    private float totalCamwidth;
    //contols positio
    float x;
    private float y;
    //varible movemnet 
   public  float accel = 23;
    float deccel=3;
    

    void Start()
    {
     
        totalCamheight = 2f * Camera.main.orthographicSize;
        totalCamwidth = totalCamheight * Camera.main.aspect;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //sets 
        Vector3 objectPosition = transform.position;


        //changes new vector to wrap
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


        //transforms
        transform.position = objectPosition;

    

        //zero vector
        Vector3 direction = new Vector3(0, 0, 0);



        //input controller
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

        
        //controls velcity 
        velocity += direction * accel * Time.deltaTime;


        

        //transfrokm according to velocity 
        transform.position += velocity * Time.deltaTime;






    }


    public void SetDirection(Vector2 input)
    {
      if(input != null)
      {
           

            

        }
        
       
    }


}
