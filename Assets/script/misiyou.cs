using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class misiyou : MonoBehaviour
{
    private Vector3 mousePos;
    private Vector3 target;

    void Update()
    {
        mousePos = Input.mousePosition;
        target = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x*2, mousePos.y*2, 0));
        transform.LookAt(target);
    }
}