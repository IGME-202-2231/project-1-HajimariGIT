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

    public bool IsPlayerBullet
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
            Vector3 direction = Vector3.up; // Move in the y-direction
            Vector3 bulletPosition = bulletList[i].transform.position;
            bulletPosition += direction * speed * Time.deltaTime;
            bulletList[i].transform.position = bulletPosition;

            // Check if the bullet is above the camera's view
            if (bulletPosition.y > totalCamheight / 2f)
            {
                // Destroy the bullet when it goes out of the camera's view
                SpriteInfo sprite = bulletList[i].GetComponent<SpriteInfo>();
                Destroy(bulletList[i]);
                bulletList.RemoveAt(i);
                collisionManager.collideables.Remove(sprite);
                i--;
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



   
}
