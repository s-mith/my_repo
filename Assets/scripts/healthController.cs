using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthController : MonoBehaviour
{

    public int health = 100;
    public float tickrate = 2;  // The number of bullets fired per second
     public float lasttick;
    public GameObject player;

    // if player collides with an enemy, with tag "smallEnemy", take 5 damage
       

    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        if (Time.time - lasttick > 1 / tickrate)
        {
            lasttick = Time.time;
            // if player collides with an enemy, with tag "smallEnemy", take 5 damage
            // get list of all collisions with the player
            Collider2D[] collisions = Physics2D.OverlapCircleAll(player.transform.position, 0.5f);
            // loop through the list of collisions
            foreach (Collider2D collision in collisions)
            {
                // if the collision is an enemy
                if (collision.gameObject.tag == "smallEnemy")
                {
                    // take 5 damage
                    health -= 5;
                    // destroy the enemy
                }
            }
        }
        if (health <= 0)
        {
            // go to game over scene
            Application.LoadLevel("LeaderBoard");
        }

        
        
        
    }
}
