using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    //enemy object
    [SerializeField] Enemy m_Enemy;
    [SerializeField] int number;
    //moving left to right if needed
    public float amp=.5f;
    public float speed=.5f;
    //loaction of spawn
    public GameObject spawn;
    //spawn position
    Vector3 spawnPos;
    //abillity
    public string abillity;
    //tells if its a forward enemy
    bool movingUp;
    //controls direction
    Vector3 direcion;
    //health
    public int health;
    //camera varibles
    private float totalCamwidth;
    private float totalCamheight;
    //refrence 
    HealthManager healthManager;
    //controls movemnet
   public float type;
    //refrence
    public EnemyManager enemyManager;


    public int Number
    {
        get { return number; }
        set { number = value; }
    } 
    void Start()
    {
        //sets camera and spawn 
        spawnPos = spawn.transform.position;
        totalCamheight = 2f * Camera.main.orthographicSize;
        totalCamwidth = totalCamheight * Camera.main.aspect;

    }

    // Update is called once per frame
    void Update()
    {
    
        //if 0 move down and left
        if(type == 0)
        {
            float X = speed * Time.deltaTime;
            float Y = speed * Time.deltaTime;

           
            transform.Translate(new Vector3(X, Y, 0));

          
            //if 1 move down and right
        }
        if(type == 1)
        {
           
            float X = -speed * Time.deltaTime; 
            float Y = -speed * Time.deltaTime;

            //if it hits then game over
            transform.Translate(new Vector3(X,Y, 0));
            if (transform.position.y <= -9)
            {
                
                enemyManager.counter = 0;


            }
        }
        //otherwise move down
        else
        {
            speed = Random.Range(5f, 6.8f);

            Vector3 move = transform.position;
            float y = move.y - speed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, y, transform.position.x);


            //wraps
            if (transform.position.y <= -9)
            {
                transform.position = new Vector3(transform.position.x, Random.Range(25,70), transform.position.z);


            }

        }



       

        













    }




}
