﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour
{
    public int valor;
    //public GameObject item;
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            player.jumpforce = player.jumpforce + valor ;
            Destroy(gameObject);
        }
    }
}
