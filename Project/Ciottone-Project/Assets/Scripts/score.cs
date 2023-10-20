using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMesh scoreSprite;
    public float scoreIndex = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreSprite.text = "score " + scoreIndex;
        
    }
}
