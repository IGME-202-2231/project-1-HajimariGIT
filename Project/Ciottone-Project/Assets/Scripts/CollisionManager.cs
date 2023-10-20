using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class CollisionManager : MonoBehaviour
{
    //controls collidables on screen and stores
    [SerializeField]
    public List<SpriteInfo> collideables;
    //contros what equation to use
    bool control=true;
    public List<GameObject> gameObjects = new List<GameObject>();
    public EnemyManager enemyManager;// = new EnemyManager();
    public score scoreCount;
    public Bullet bulletPrefab;
    //controls text

    // Start is called before the first frame update
   
    /// <summary>
    /// controls current mode
    /// </summary> 
    public enum Mode
    {
        Sqaure,
        Circle
    }
   
    //starting state
    Mode modeState=Mode.Sqaure;
   
    // Update is called once per frame
    void Update()
    {
        //if the user presses right click 
      

        //check state/text and change accordingly


        //assign a staring value of false

        foreach (SpriteInfo sprite in collideables)
        {
            sprite.IsColliding = false;
        }

        //check for collisions
        onTouch();
        dead();

       
       


    }
    void onTouch()
    {


        //compare each object with each object 
        for (int i = 0; i < collideables.Count - 1; i++)
        {

            for (int j = i + 1; j < collideables.Count; j++)
            {
                //store them
                SpriteInfo spriteA = collideables[i];
                SpriteInfo spriteB = collideables[j];

                //assume they are not collding 
                bool isColliding = false;
                //if control is false
               
                
                    isColliding = AABBCheck(spriteA, spriteB);

                    if (isColliding)
                    {
                        if (spriteA.type == SpriteInfo.typeState.PlayerBullet && spriteB.type == SpriteInfo.typeState.Enemy || (spriteB.type == SpriteInfo.typeState.PlayerBullet && spriteA.type == SpriteInfo.typeState.Enemy))
                        {
                            //have to know if player
                            //have to know if bullet
                            //set both to true 
                            spriteA.IsColliding = true;
                            spriteB.IsColliding = true;






                         


                          if (spriteA.type == SpriteInfo.typeState.Enemy)
                          {
                           
                            gameObjects.Add(spriteA.gameObject);
                            collideables.RemoveAt(i);
                            enemyManager.enemies.Remove(spriteA.gameObject);
                            
                             scoreCount.scoreIndex++;


                          








                        }

                          if (spriteB.type == SpriteInfo.typeState.Enemy)
                          {
                          
                            gameObjects.Add(spriteB.gameObject);
                            collideables.RemoveAt(j);
                            enemyManager.enemies.Remove(spriteB.gameObject);
                            scoreCount.scoreIndex++;

                           








                        }

                    








                        }

                        
                    }
                
              

                //otherwise 

                
            }
        }
    }
    

    

    /// <summary>
    /// Equation for checking boxes
    /// </summary>
    /// <param name="spriteA"></param>
    /// <param name="spriteB"></param>
    /// <returns></returns>
    bool AABBCheck(SpriteInfo spriteA, SpriteInfo spriteB)
     {
      // Check for collisions

      if(spriteB.RectMin.x < spriteA.RectMax.x &&
          spriteB.RectMax.x > spriteA.RectMin.x &&
          spriteB.RectMin.y < spriteA.RectMax.y &&
          spriteB.RectMax.y > spriteA.RectMin.y)
      {
            //there is one 
            return true;
      }
      else
      {
            //there is not one
            return false;
      }
        
      
     }

    public void dead()
    {
        for (int i = 0; i < gameObjects.Count; i++)
        {
            Destroy(gameObjects[i]);
        }
    }

    bool Circle(SpriteInfo spriteA, SpriteInfo spriteB)
    {
        //Pythagorean theorem
        double x= spriteB.center.x- spriteA.center.x;
        double y= spriteB.center.y -spriteA.center.y;
        double total =Math.Sqrt(x*x + y*y);
        //check if they intersect
        if(total < spriteA.Radius + spriteB.Radius)
        {
            return true;
        }
        else
        {
            return false;
        } 
    }

   /// <summary>
   /// checks words and updates control to switch equations 
   /// </summary>
   /// <returns></returns>

    bool CheckState()
    {
        if (modeState == Mode.Sqaure)
        {
           // collisionText.text = "Square";
            return control = false;
        }
        else
        {
           // collisionText.text = "circle";
            return control = true;
        
        }

    }
    /// <summary>
    /// switches current state 
    /// </summary>

    void StateChange()
    {
       if(modeState == Mode.Sqaure)
        {
            modeState = Mode.Circle;
            CheckState();
        }
        else
        {
            modeState= Mode.Sqaure;
            CheckState();   
        }
       
        


    }

    public void AddSprite(SpriteInfo sprite)
    {
        collideables.Add(sprite);
    }








}
