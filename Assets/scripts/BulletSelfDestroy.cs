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
        if (collisionCount >= 5)
        {
            Destroy(gameObject);
        }
        
        if (collisionCount == 1)
        {
            // change the color of the bullet to light yellow
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 0.5f, 1f);
        }
        else if (collisionCount == 2)
        {
            // change the color of the bullet to light orange
            GetComponent<SpriteRenderer>().color = new Color(1f, 0.5f, 0.1f, 1f);
        }
        else if (collisionCount == 3)
        {
            // change the color of the bullet to light red
            GetComponent<SpriteRenderer>().color = new Color(1f, 0.3f, 0.3f, 1f);
        }
        else if (collisionCount == 4)
        {
            // change the color of the bullet to light pink
            GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
        }
        else if (collisionCount == 5)
        {
            // change the color of the bullet to light purple
            GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 0.5f);
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
