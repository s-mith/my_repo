using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowEnemyAI : MonoBehaviour
{
    // determines the speed of the enemy
    public float speed;
    // determines the distance in which the enemy will attack
    public float attackRadius;

    // determines if the enemy should change directions
    public bool shouldRotate;

    // transform of the target
    private Transform target;
    private float distanceFromTarget;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 movement;
    public Vector3 dir;

    private bool isInAttackRange;

    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        anim = transform.GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        anim.SetBool("attacking", false);
    }

    void Update()
    {
        // updates the distance the enemy is from the player
        distanceFromTarget = Vector3.Distance(transform.position, target.position);
        
        // if enemy is in attack distance
        if (distanceFromTarget <= attackRadius)
        {
            isInAttackRange = true;

            // move the enemy away from player (half speed)
            var step = (-speed / 2) * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position + new Vector3(Random.Range(0, 10), Random.Range(0, 10), 0), step);
            
            // PUT STUFF YOU WANT AI TO DO WHEN ATTACKING HERE
            /*



            */
        }
        // if enemy is NOT in attack distance
        else
        {
            isInAttackRange = false;

            // move the enemy towards player
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
        anim.SetBool("attacking", isInAttackRange);
    }
}
