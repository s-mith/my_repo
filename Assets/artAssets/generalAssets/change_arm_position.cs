using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_arm_position : MonoBehaviour
{
    // parameters int named point
    public int point = 1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if  w is pressed decrease point by 1
        if (Input.GetKeyDown(KeyCode.W))
        {
            point--;
            if (point < 1)
            {
                point = 3;
                // set the animator parameter to point
                
            }
            GetComponent<Animator>().SetInteger("point", point);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            point++;
            if (point > 3)
            {
                point = 1;

            }
            GetComponent<Animator>().SetInteger("point", point);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (point == 1)
            {
                // go to a different scene
                Application.LoadLevel("Level");
            }
            else if (point == 2)
            {
                return;
            }
            else if (point == 3)
            {
                // quit the game
                Application.Quit();
            }   
        }
    }
}
