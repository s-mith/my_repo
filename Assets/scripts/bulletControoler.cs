using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControoler : MonoBehaviour
{

     public float bulletSpeed = 10;
     public Rigidbody2D bullet;
    // Start is called before the first frame update
    

    void FireBullet(){

        // get the mouse position
        Vector3 mousePos = Input.mousePosition;
        // get the position of the player
        Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);
        // send the bullet in the direction of the mouse
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        // create the bullet
        // instantiate the bullet as a child of another object
        Rigidbody2D bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
        // send the bullet in the direction of the mouse
        bulletInstance.velocity = new Vector2(mousePos.x, mousePos.y).normalized * bulletSpeed;

        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space)){
            FireBullet();
        }
    }
}
