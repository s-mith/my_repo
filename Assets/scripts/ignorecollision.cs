using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ignorecollision : MonoBehaviour
{
    public GameObject player;
    
    // clones of the bullet
    public GameObject bullet;
    // ignore collision between the player and the bullet
  
    // Start is called before the first frame update
    void Start()
    {
        // ignore collision between the player and children of the bullet layer
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), bullet.GetComponent<Collider2D>());


    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
