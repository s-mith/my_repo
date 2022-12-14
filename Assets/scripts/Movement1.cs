using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement1 : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;
    


   

 

 
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
    }
 
    void Update()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
 
        rb2d.velocity = new Vector2 (moveHorizontal*speed, moveVertical*speed);

        // when moving animate
        if (moveHorizontal != 0 || moveVertical != 0)
        {
            GetComponent<Animator>().SetBool("walking", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("walking", false);
        }

        
        

        // if the mouse is to the left of the player, flip the player
        if (Input.mousePosition.x < Camera.main.WorldToScreenPoint(transform.position).x)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
 
 
        // Try out this delta time method??
        //rb2d.transform.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
    }
 
    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
    }
}
