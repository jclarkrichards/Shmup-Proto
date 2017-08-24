using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    bool followMouse = false;
    Vector3 offset;
    DragEffect drag;
    
    // Use this for initialization
    void Start ()
    {
        drag = new DragEffect(transform.position, -25, 25, 2, 5);      
	}
	
	// Update is called once per frame
	void Update ()
    {      
        if (followMouse)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0.0f;
            transform.position = offset + mousePosition;          
            transform.rotation = drag.Tilt(transform.position);
        }
        else
        {
            transform.rotation = drag.ResetTilt();
        }      
    }

    private void OnMouseDown()
    {
        followMouse = true;
        drag.StartLerpTime();
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset.z = 0.0f;
    }

    private void OnMouseUp()
    {
        followMouse = false;
        drag.ResetTiltValues();
    }

}
