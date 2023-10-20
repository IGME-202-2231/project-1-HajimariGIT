using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> lifeList = new List<GameObject>();
    public GameObject Life;
    public GameObject LifeTwo;
    public GameObject LifeThree;
    void Start()
    {
        lifeList.Add(Life);
        lifeList.Add(LifeTwo);
        lifeList.Add(LifeThree);
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    public void GameOver()
    {
        if(lifeList.Count >= 0) 
        {
            
        }
    }

}
