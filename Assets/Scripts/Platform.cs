using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private void Update()
    {
        if(!Input.GetMouseButton(0))return;
        var currentPosition = gameObject.transform.position;
        var mousePositionX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        gameObject.transform.position = new Vector3(mousePositionX, currentPosition.y);
    }
}
