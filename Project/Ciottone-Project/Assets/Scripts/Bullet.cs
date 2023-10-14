using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject bulletIntake;
    [SerializeField] float speed = 13f;
    [SerializeField] GameObject spawn;
    private bool bulletInTravel;
    List<GameObject> bulletList = new List<GameObject>();
    private float totalCamheight;
    private float totalCamwidth;
   public CollisionManager collisionManager;
    SpriteInfo spriteInfo =  new SpriteInfo();
    bool isBullet;

    public bool IsBullet
    {
        get { return isBullet; }
        set { value = isBullet; }
    }
    





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

          

             GameObject bullet = Instantiate(bulletIntake, spawnPos, Quaternion.identity);
             bulletList.Add(bullet);

            SpriteInfo bulletSpriteInfo = bullet.GetComponent<SpriteInfo>();
            collisionManager.AddSprite(bulletSpriteInfo);







        }

        for (int i = 0; i < bulletList.Count; i++)
        {
            Vector3 direction = Vector3.right; // Move in the x-direction
            Vector3 bulletPosition = bulletList[i].transform.position;
            bulletPosition += direction * speed * Time.deltaTime;
            bulletList[i].transform.position = bulletPosition;
           
        }

       // BulletCleanUp();
    }

    /*public void BulletCleanUp()
    {
      for(int i =0; i < bulletList.Count; i++)
       {
            if (bulletList[i].transform.position.y> totalCamheight / 2f)
            {
                Destroy(bulletList[i]);
            }
            else if (bulletList[i].transform.position.y < -totalCamheight / 2f)
            {
                Destroy(bulletList[i]);
            }

            if (bulletList[i].transform.position.x > totalCamwidth / 2f)
            {
                Destroy(bulletList[i]);
            }
            else if (bulletList[i].transform.position.x < -totalCamwidth / 2f)
            {
                Destroy(bulletList[i]);
            }
            
        }
        
        
    }*/



   
}
