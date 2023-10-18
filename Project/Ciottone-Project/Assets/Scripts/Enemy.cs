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
    

    public int Number
    {
        get { return number; }
        set { number = value; }
    } 
    void Start()
    {
        spawnPos = spawn.transform.position;
       
    }

    // Update is called once per frame
    void Update()
    {
        ///abilltiy determinds spawn 
        /////random direction via vector
 
        Vector3 move = transform.position;
        float y = move.y - speed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, y, transform.position.x);
       












    }

    

    
}
