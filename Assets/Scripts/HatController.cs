using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatController : MonoBehaviour
{
    public Camera cam;

    private float maxWidth;
    private bool canControll;

    private void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
            canControll = false;
            Vector3 upperCorner = new Vector3(Screen.width, Screen.height, .0f);
            Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
            float hatWidth = GetComponentInChildren<Renderer>().bounds.extents.x;
            maxWidth = targetWidth.x - hatWidth;
        }
    }

    private void FixedUpdate()
    {
        if (canControll) 
        {
            float yPos = GetComponent<Transform>().position.y;
            Vector3 rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 targetPosition = new Vector3(rawPosition.x, yPos, .0f);
            float targetWith = Mathf.Clamp(targetPosition.x, -maxWidth, maxWidth);
            targetPosition = new Vector3(targetWith, targetPosition.y, targetPosition.z);
            GetComponent<Rigidbody2D>().MovePosition(targetPosition);
        }
    }

    public void ToggleControll (bool toggle)
    {
        canControll = toggle;
    }
}
