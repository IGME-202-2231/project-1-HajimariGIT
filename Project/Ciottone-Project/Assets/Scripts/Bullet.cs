using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject bulletIntake;
    [SerializeField] float speed = 13f;
    [SerializeField] GameObject spawn;
    private bool bulletInTravel;
    GameObject bullet;
    List<GameObject> bulletList;
    private float totalCamheight;
    private float totalCamwidth;





    // Start is called before the first frame update
    void Start()
    {
        totalCamheight = 2f * Camera.main.orthographicSize;
        totalCamwidth = totalCamheight * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Vector3 spawnPos = spawn.transform.position;

          

             bullet = Instantiate(bulletIntake, spawnPos, Quaternion.identity);
             bulletList.Add(bullet);

            


        }

        if(bulletInTravel != null)
        {
         

            Vector3 direction = Vector3.right;
            bullet.transform.Translate(direction * speed * Time.deltaTime);
        }
    }

   /* public void BulletCleanUp()
    {
       foreach(GameObject b in bulletList)
       {
            if (b.y > totalCamheight / 2f)
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
        }
        
        
    }*/



   
}
