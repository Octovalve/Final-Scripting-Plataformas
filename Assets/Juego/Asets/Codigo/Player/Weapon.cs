using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float offset;
    public GameObject projectile;
    public Transform ShotPoint;
    private float attspid;
    public float starttime;
    // el arma apunta a la pocision del moudse
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        if (attspid<=0)
        {
            if (Input.GetMouseButtonDown(0)) 
            {
                Instantiate(projectile, ShotPoint.position, transform.rotation);
                attspid = starttime;
            }
        }
        else {attspid -= Time.deltaTime;}
    }
}
