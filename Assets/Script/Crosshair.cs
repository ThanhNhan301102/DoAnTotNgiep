using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private float phamvi;
    [SerializeField] private Transform weapon;
    private float dx;    //khoang cach ngam ban den player
    private float dy;
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        if(mousePos.x > weapon.position.x - phamvi && mousePos.x < weapon.position.x + phamvi && mousePos.y > weapon.position.y - phamvi && mousePos.y < weapon.position.y + phamvi)
            transform.position = mousePos;
    }
}
