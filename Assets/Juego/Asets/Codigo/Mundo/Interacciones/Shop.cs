using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            GameControler.TiendaOn();
            
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        GameControler.TiendaOf();
    }
}
