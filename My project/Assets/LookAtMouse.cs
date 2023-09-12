using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    
    void Update()
    {
       var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
       var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
       transform.rotation= Quaternion.AngleAxis(angle,Vector3.forward);

       // Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
       // float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
       // Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
       // transform.rotation = rotation;
    }
}
