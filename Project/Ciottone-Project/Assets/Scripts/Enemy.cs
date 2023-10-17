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
       if(abillity == "1")
       {
            float upAndDown = spawnPos.y + Mathf.Sin(Time.time * speed) * amp;
            transform.position = new Vector3(transform.position.x, upAndDown, transform.position.z);

           
                
           
       }

       if(abillity == "2")
       {
           
            float leftAndRight = spawnPos.x + Mathf.Cos(Time.time * speed) * amp;
            transform.position = new Vector3(leftAndRight, transform.position.y, transform.position.z);
       }
       
       


    }
}
