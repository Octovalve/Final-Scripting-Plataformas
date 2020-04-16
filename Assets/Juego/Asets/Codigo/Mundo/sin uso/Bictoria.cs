using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bictoria : MonoBehaviour
{
    public bool active;
    public Canvas canvas;

    private void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }
    private void Update()
    {
        canvas.enabled = active;
    }
   
   /* private void OnCollisionEnter2D(Collision2D collision)
    {
        active = !active;
        canvas.enabled = active;
    }*/
}
