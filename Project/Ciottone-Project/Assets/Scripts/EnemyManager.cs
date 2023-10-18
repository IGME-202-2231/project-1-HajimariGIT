using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemyNew;
    public SpriteInfo spriteInfo;
    public CollisionManager collisionManager;
    public Enemy enemyRef;
    public List<GameObject> enemies;
    public int spawnNum = 10;
    Vector3 spawnPos;
    private float totalCamheight;
    private float totalCamwidth;


    // Start is called before the first frame update
    void Start()
    {
        totalCamheight = 2f * Camera.main.orthographicSize;
        totalCamwidth = totalCamheight * Camera.main.aspect;

        for (int i = 0; i < spawnNum; i++)
        {
            spawnPos.x = Random.Range(-10, 10);
            spawnPos.y = Random.Range(6, 20);

            enemy = Instantiate(enemy, spawnPos, Quaternion.identity);
            enemies.Add(enemy);
            // enemyRef.add
            collisionManager.AddSprite(enemies[i].GetComponent<SpriteInfo>());

        }
    }

    // Update is called once per frame
    void Update()
    {

        if (enemies.Count < 1)
        {


            for (int i = 0; i < spawnNum; i++)
            {
                GameObject NewEnemy;
                Vector3 SpawnNew = new Vector3();
                SpawnNew.x = Random.Range(-10, 10);
                SpawnNew.y = Random.Range(6, 20);
                NewEnemy = Instantiate(enemyNew, SpawnNew, Quaternion.identity);
                enemies.Add(NewEnemy);
                SpriteInfo NewSprite = NewEnemy.GetComponent<SpriteInfo>();
                collisionManager.collideables.Add(NewSprite);
                SpawnNew.x = Random.Range(-10,10);
                SpawnNew.y = Random.Range(6, 20);



            }
        }




    }





    public void SpawnMore()
    {

       

    }
}
