using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{
    public GameObject objeto;
    public GameObject spawn;
    public int valor;
    public void CargarNivel(string nombre)
    {
        SceneManager.LoadScene(nombre);
        Time.timeScale = 1;
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void Comprar()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Player jugador = player.GetComponent<Player>();
        Debug.Log(player);
        if (player != null && jugador.monedas >= valor)
        {
            //Debug.Log("Comprado");
            jugador.monedas = jugador.monedas - valor;
            Instantiate(objeto, spawn.transform.position, spawn.transform.rotation);
        }
    }
}
