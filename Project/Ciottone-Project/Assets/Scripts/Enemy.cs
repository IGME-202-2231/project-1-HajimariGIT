using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField] Enemy m_Enemy;
    [SerializeField] int number;

    public int Number
    {
        get { return number; }
        set { number = value; }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
       
    }
}
