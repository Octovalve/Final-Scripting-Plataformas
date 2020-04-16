using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControler : MonoBehaviour
{
    public static int score;
    public string scoreString;
    public static int vida;
    public string vidaString;

    //UI de ganar y perder
    public GameObject Perder;
    public static GameObject gameOver;
    public GameObject Ganar;
    public static GameObject Win;
    //Botones del juego
    public static GameObject botonA;
    public static GameObject botonB;
    public static GameObject botonC;
    public static GameObject botonD;
    public GameObject boton1;
    public GameObject boton2;
    public GameObject boton3;
    public GameObject boton4;
    //Botones de la tienda
    public static GameObject botonCorason;
    public static GameObject botonVida;
    public static GameObject botonBelocidad;
    public GameObject corazon;
    public GameObject curacion;
    public GameObject belocidad;
    // textos de la pantalla
    public Text textScore;
    public Text textVida;
    public static GameControler Gamecontroler;

    public bool pausado;
    private void Awake()
    {
        Gamecontroler = this;
        pausado = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        //Ganar y perder
        GameControler.gameOver = Perder;
        GameControler.gameOver.gameObject.SetActive(false);
        GameControler.Win = Ganar;
        GameControler.Win.gameObject.SetActive(false);
        //Botones del juego
        GameControler.botonA = boton1;
        GameControler.botonB = boton2;
        GameControler.botonC = boton3;
        GameControler.botonD = boton4;
        GameControler.botonA.gameObject.SetActive(false);
        GameControler.botonB.gameObject.SetActive(false);
        GameControler.botonC.gameObject.SetActive(false);
        GameControler.botonD.gameObject.SetActive(false);
        //botones de la tienda
        GameControler.botonCorason = corazon;
        GameControler.botonVida = curacion;
        GameControler.botonBelocidad = belocidad;
        GameControler.botonCorason.gameObject.SetActive(false);
        GameControler.botonBelocidad.gameObject.SetActive(false);
        GameControler.botonVida.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (textScore != null)
        {
            textScore.text = scoreString + "   " + score.ToString();

        }
        if (textVida != null)
        {
            textVida.text = vidaString + "   " + vida.ToString();
        }
        if (Input.GetKey(KeyCode.P))
        {
            if (pausado == false)
            {
                PausaON();
                pausado = true;
            }
            if (pausado == true)
            {
                PausaOF();
                pausado = false;
            }
        }

    }
    public static void Derrota()
    {
        GameControler.gameOver.gameObject.SetActive(true);
        GameControler.botonA.gameObject.SetActive(true);
        GameControler.botonB.gameObject.SetActive(true);
        GameControler.botonC.gameObject.SetActive(true);

    }
    public static void Victoria()
    {
        GameControler.Win.gameObject.SetActive(true);
        GameControler.botonA.gameObject.SetActive(true);
        GameControler.botonB.gameObject.SetActive(true);
        GameControler.botonC.gameObject.SetActive(true);
        GameControler.botonD.gameObject.SetActive(true);
    }
    public static void TiendaOn()
    {
        GameControler.botonCorason.gameObject.SetActive(true);
        GameControler.botonBelocidad.gameObject.SetActive(true);
        GameControler.botonVida.gameObject.SetActive(true);
    }
    public static void TiendaOf()
    {
        GameControler.botonCorason.gameObject.SetActive(false);
        GameControler.botonBelocidad.gameObject.SetActive(false);
        GameControler.botonVida.gameObject.SetActive(false);
    }
    public static void PausaON()
    {
        GameControler.botonA.gameObject.SetActive(true);
        GameControler.botonB.gameObject.SetActive(true);
        GameControler.botonC.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public static void PausaOF()
    {
        GameControler.botonA.gameObject.SetActive(false);
        GameControler.botonB.gameObject.SetActive(false);
        GameControler.botonC.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
