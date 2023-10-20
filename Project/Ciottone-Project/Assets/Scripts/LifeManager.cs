using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Android;

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

        SpawnZero.x = -25.71f;
        SpawnZero.y = -12.38f;

        SpawnOne.x = -23.74f;
        SpawnOne.y = -12.38f;

        SpawnTwo.x = -21.74f ;
        SpawnTwo.y = -12.38f;

        SpawnThree.x = -19.85f;
        SpawnThree.y = -12.38f;

        SpawnFour.x = -17.87f;
        SpawnFour.y = -12.38f;

        SpawnFive.x = -15.97f;
        SpawnFive.y = -12.38f;

        SpawnSix.x = -14.06f;
        SpawnSix.y = -12.38f;


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
       if(enemyManager.counter == 30 )
       {
            Debug.Log("hi");
            lifeList.Remove(HeartSeven);
            Destroy(HeartSeven);
       }

        if (enemyManager.counter == 25)
        {
            lifeList.Remove(HeartSix);
            Destroy(HeartSix);
        }

        if (enemyManager.counter == 20)
        {
            lifeList.Remove(HeartFive);
            Destroy(HeartFive);
        }

        if (enemyManager.counter == 15)
        {
            lifeList.Remove(HeartFour);
            Destroy(HeartFour);
        }

        if (enemyManager.counter == 10)
        {
            lifeList.Remove(HeartThree);
            Destroy(HeartThree);
        }
        if (enemyManager.counter == 5)
        {
            lifeList.Remove(HeartTwo);
            Destroy(HeartTwo);
        }
        if (enemyManager.counter == 0)
        {
            lifeList.Remove(HeartOne);
            Destroy(HeartOne);
        }
    }

}
