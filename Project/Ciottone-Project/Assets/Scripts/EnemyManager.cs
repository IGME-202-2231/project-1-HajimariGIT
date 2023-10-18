using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;
    public SpriteInfo spriteInfo;
    public CollisionManager collisionManager;
    public Enemy enemyRef;
    public List<GameObject> enemies;
    public int spawnNum = 10;
    Vector3 spawnPos;
   
    // Start is called before the first frame update
    void Start()
    {
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
      
       

    }




   
}
