using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zfixer : MonoBehaviour
{

    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if the enemy has a z position of 0, set it to 1
        if (enemy.transform.position.z != -1)
        {
            enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y, -1);
        }
        
    }
}
