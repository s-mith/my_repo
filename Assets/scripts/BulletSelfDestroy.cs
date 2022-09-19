using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSelfDestroy : MonoBehaviour
{

    // destroy the bullet after 5 collisions

    public int collisionCount = 0;

    


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
