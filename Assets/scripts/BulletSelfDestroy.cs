using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletSelfDestroy : MonoBehaviour
{

    // destroy the bullet after 5 collisions

    public int collisionCount = 0;

    public GameObject score;

    public static int scoreValue = 0;
    


    void OnCollisionEnter2D(Collision2D col)
    {
        collisionCount++;
        if (collisionCount > 5)
        {

            Destroy(gameObject);
            
        }
        
        // log to console
        // increment the animator parameter bounce
        GetComponent<Animator>().SetInteger("bounce", collisionCount);

        // if the bullet collides with enemy, destroy enemy
        if (col.gameObject.tag == "smallEnemy")
        {
            Destroy(col.gameObject);
            // get the value of scores text
            scoreValue = int.Parse(score.GetComponent<Text>().text);
            // increment the score
            scoreValue += 1;
            // set the score text to the new value
            score.GetComponent<Text>().text = scoreValue.ToString();

        }

        

    }



    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {


        
    }
}
