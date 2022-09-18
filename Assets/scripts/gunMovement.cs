using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunMovement : MonoBehaviour
{

     // make the player face the mouse
    public float strength = 1000.0f;
    private float str;
    private Quaternion targetRotation;
    private float zCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // make the player face the mouse
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = zCam;
        Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        str = Mathf.Atan2 (mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        targetRotation = Quaternion.Euler (0, 0, str + 90);
        transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, strength * Time.deltaTime);
        // prevent the player from rotating from collisions
        transform.rotation = Quaternion.Euler (0, 0, transform.eulerAngles.z); 
    }
}
