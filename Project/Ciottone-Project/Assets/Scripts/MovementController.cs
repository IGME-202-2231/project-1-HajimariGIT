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

        Vector3 current = transform.position;

    

        if (current.y < -9.1f)
        {
            current.y = -9.1f;
        }
        else if (current.y > 8.1f)
        {
            current.y = 8.1f;
        }

        if (current.x > 19.7f)
        {
            current.x = 19.7f;
        }
        else if (current.x < -21.2)
        {
            current.x = -21.2f;
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


        


        transform.position += velocity * Time.deltaTime;



       

        


    }


    public void SetDirection(Vector2 input)
    {
      if(input != null)
      {
           

            

        }
        
       
    }


}
