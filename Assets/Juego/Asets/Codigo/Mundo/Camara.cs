using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    //radio de vicion del monstruo y velocidad de movimiento
    public float visionRad;
    public float speed;
    public int vida;
    public int damage;
    Player jugador;


    //Quien es el jugador
    GameObject player;

    //posicision inicial
    Vector3 inicialP;

    // Start is called before the first frame update
    void Start()
    {
        //Encontrar al jugador
        player = GameObject.FindGameObjectWithTag("Player");
        jugador = GetComponent<Player>();
        //guardar la pocicion inicial
        inicialP = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        //para que regrese el targuet debe ser la pocision inicial
        Vector3 target =  player.transform.position;

        //detectar al distancia al jugador y atacar
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < visionRad) { target = player.transform.position; }

        //mobemos al enemigo al target
        float fixedspid = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, fixedspid);

        //debug
        Debug.DrawLine(transform.position, target, Color.green);
    }

    
    
}
