using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject bulletIntake;
    [SerializeField] float speed = 17f;
    [SerializeField] GameObject spawn;
    private bool bulletInTravel;
   public List<GameObject> bulletList = new List<GameObject>();
    private float totalCamheight;
    private float totalCamwidth;
   public CollisionManager collisionManager;
    SpriteInfo spriteInfo;
    bool isBullet;
    public bool hit = false;
    EnemyManager enemy;
    public int bulletFired;
    public bool on = false;
    public GameObject player;
    private float buttonCooldown = 0.15f;
    private float lastButtonPressTime = -0.20f;


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
      


        if (Input.GetMouseButtonDown(0)  && Time.time - lastButtonPressTime >= buttonCooldown)
        {
            Vector3 spawnPos = spawn.transform.position;
            spawnPos.x = spawnPos.x + .5f;
            spawnPos.y = spawnPos.y +2;

            GameObject bullet = Instantiate(bulletIntake, spawnPos, Quaternion.identity);
            bulletList.Add(bullet);
            SpriteInfo bulletSpriteInfo = bullet.GetComponent<SpriteInfo>();
            collisionManager.AddSprite(bulletSpriteInfo);
            bulletFired = bulletFired + 1;
            lastButtonPressTime = Time.time;

        }

        for (int i = 0; i < bulletList.Count; i++)
        {
            Vector3 direction = Vector3.up; 
            Vector3 bulletPosition = bulletList[i].transform.position;
            bulletPosition += direction * speed * Time.deltaTime;
            bulletList[i].transform.position = bulletPosition;
            Bullet check = bulletList[i].GetComponent<Bullet>();

            if (bulletPosition.y > player.transform.position.y + 8f )
            {
             
                SpriteInfo sprite = bulletList[i].GetComponent<SpriteInfo>();
                Destroy(bulletList[i]);
                bulletList.RemoveAt(i);
                collisionManager.collideables.Remove(sprite);
                i--;
            }



          






            
        }

        BulletCleanUp();






    }

    void BulletCleanUp()
    {
        for (int i = 0; i < bulletList.Count; i++)
        {
            if (on == true)
            {
                
                SpriteInfo sprite = bulletList[i].GetComponent<SpriteInfo>();
                Destroy(bulletList[i]);
                bulletList.RemoveAt(i);
                collisionManager.collideables.Remove(sprite);
                i--;
            }
          

        }


    }


   
}
