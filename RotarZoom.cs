using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarZoom : MonoBehaviour
{
   
    private float rotationSpeed = 7f;
    private float zoomSpeed = 7f;

    
    private Vector3 positionBk;
    private Quaternion rotationBk;
    private Vector3 scaleBk;
    private Vector3 scaleFrame;
    private float initialDistance;

   
    private float oldDistance = 0f;

    
    private Vector3 oldPosition = Vector3.zero;

   
    void Start()
    {
        positionBk = transform.localPosition;
        rotationBk = transform.localRotation;
        scaleBk = transform.localScale;
    }

    void Update()
    {
        
        if (Input.touchCount == 1)
        {
           
            if (Input.GetTouch(0).tapCount == 2)
            {
                transform.localRotation = rotationBk;
                transform.localScale = scaleBk;
            }
           
            else if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                transform.Rotate(new Vector3(0f, -Input.GetTouch(0).deltaPosition.x * rotationSpeed * Time.deltaTime, 0f), Space.World);
            }
        }

      
        if (Input.touchCount == 2)
        {
            
            if (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(1).phase == TouchPhase.Began)

            {

                initialDistance = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
                scaleFrame = transform.localScale;

            }
            else
            if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved)
            {
             
                Vector2 position1 = Input.GetTouch(0).position;
                Vector2 position2 = Input.GetTouch(1).position;

                float distance = Vector2.Distance(position1, position2);
                float factor = distance / initialDistance;
                if (transform.localScale.x >= scaleFrame.x * factor)
                {
                    if (transform.localScale.x > (scaleBk.x / 3))
                    {
                        transform.localScale = scaleFrame * factor; 
                    }
                }
                else
                {
                    if (transform.localScale.x <= (scaleBk.x * 3))
                    {
                        transform.localScale = scaleFrame * factor; 
                    }
                }
            }
        }
    }
}

sssssssssssss hi!!!
