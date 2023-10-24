using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Android;
using UnityEngine.SceneManagement;


public class LifeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> lifeList = new List<GameObject>();
    public GameObject Life;
    Vector3 SpawnZero;
    Vector3 SpawnOne;
    Vector3 SpawnTwo;
    Vector3 SpawnThree;
    Vector3 SpawnFour;
    Vector3 SpawnFive;
    Vector3 SpawnSix;
    GameObject HeartOne;
    GameObject HeartTwo;
    GameObject HeartThree;
    GameObject HeartFour;
    GameObject HeartFive;
    GameObject HeartSix;
    GameObject HeartSeven;
    public EnemyManager enemyManager;
    
   
    void Start()
    {

        SpawnZero.x = -20.12f;
        SpawnZero.y = -9.96f;

        SpawnOne.x = -18.35f;
        SpawnOne.y = -9.98f;

        SpawnTwo.x = -16.58f;
        SpawnTwo.y = -9.93f;

        SpawnThree.x = -14.78f;
        SpawnThree.y = -9.88f;

        SpawnFour.x = -13.11f;
        SpawnFour.y = -9.87f;

        SpawnFive.x = -11.43f;
        SpawnFive.y = -9.91f;

        SpawnSix.x = -9.79f;
        SpawnSix.y = -9.9f;


        HeartOne = Instantiate(Life, SpawnZero, Quaternion.identity);
        HeartTwo = Instantiate(Life, SpawnOne, Quaternion.identity);
        HeartThree = Instantiate(Life, SpawnTwo, Quaternion.identity);
        HeartFour = Instantiate(Life, SpawnThree, Quaternion.identity);
        HeartFive = Instantiate(Life, SpawnFour, Quaternion.identity);
        HeartSix = Instantiate(Life, SpawnFive, Quaternion.identity);
        HeartSeven = Instantiate(Life, SpawnSix, Quaternion.identity);

        lifeList.Add(HeartOne);
        lifeList.Add(HeartTwo);
        lifeList.Add(HeartThree);
        lifeList.Add(HeartFour);
        lifeList.Add(HeartFive);
        lifeList.Add(HeartSix);
        lifeList.Add(HeartSeven);
        
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
    }




    public void GameOver()
    {
       if(enemyManager.counter == 6 )
       {
          
            lifeList.Remove(HeartSeven);
            Destroy(HeartSeven);
       }

        if (enemyManager.counter == 5)
        {
            lifeList.Remove(HeartSix);
            Destroy(HeartSix);
        }

        if (enemyManager.counter == 4)
        {
            lifeList.Remove(HeartFive);
            Destroy(HeartFive);
        }

        if (enemyManager.counter == 3)
        {
            lifeList.Remove(HeartFour);
            Destroy(HeartFour);
        }

        if (enemyManager.counter == 2)
        {
            lifeList.Remove(HeartThree);
            Destroy(HeartThree);
        }
        if (enemyManager.counter == 1)
        {
            lifeList.Remove(HeartTwo);
            Destroy(HeartTwo);
        }
        if (enemyManager.counter == 0)
        {
            lifeList.Remove(HeartOne);
            Destroy(HeartOne);

            SceneManager.LoadScene("Game Over");


        }
    }

}
