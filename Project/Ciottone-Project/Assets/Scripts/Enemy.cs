using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField] Enemy m_Enemy;
    [SerializeField] int number;
    public float amp=.5f;
    public float speed=.5f;
    public GameObject spawn;
    Vector3 spawnPos;
    public string abillity;
    bool movingUp;
    Vector3 direcion;
    public int health;
    private float totalCamwidth;
    private float totalCamheight;
    HealthManager healthManager;
   public float type;
    public EnemyManager enemyManager;


    public int Number
    {
        get { return number; }
        set { number = value; }
    } 
    void Start()
    {
        spawnPos = spawn.transform.position;
        totalCamheight = 2f * Camera.main.orthographicSize;
        totalCamwidth = totalCamheight * Camera.main.aspect;

    }

    // Update is called once per frame
    void Update()
    {
        ///abilltiy determinds spawn 
        /////random direction via vector
        ///
        if(type == 0)
        {
            float deltaX = speed * Time.deltaTime;
            float deltaY = speed * Time.deltaTime;

            // Update the game object's position to move diagonally to the right.
            transform.Translate(new Vector3(deltaX, deltaY, 0));

          
        }
        if(type == 1)
        {
            // Calculate the new position based on the current position and speed.
            float deltaX = -speed * Time.deltaTime; // Negative X direction for left movement
            float deltaY = -speed * Time.deltaTime; // Negative Y direction for downward movement

            // Update the game object's position to move diagonally to the left and downward.
            transform.Translate(new Vector3(deltaX, deltaY, 0));
            if (transform.position.y <= -9)
            {
                
                enemyManager.counter = 0;


            }
        }
        else
        {
            speed = Random.Range(5f, 6.8f);

            Vector3 move = transform.position;
            float y = move.y - speed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, y, transform.position.x);



            if (transform.position.y <= -9)
            {
                transform.position = new Vector3(transform.position.x, Random.Range(25,70), transform.position.z);


            }

        }



       

        













    }




}
