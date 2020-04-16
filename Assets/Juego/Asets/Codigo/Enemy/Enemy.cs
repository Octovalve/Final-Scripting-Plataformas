using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //radio de vicion del monstruo y velocidad de movimiento
    public float visionRad;
    public float speed;
    public int vida;
    public int damage;
    Player jugador;
    public GameObject Drop;
    

    //Quien es el jugador
    GameObject player;

    //posicision inicial
    Vector3 inicialP;

    // Start is called before the first frame update
    void Start()
    {
        //Encontrar al jugador
        //player = GameObject.FindGameObjectWithTag("Player");
        jugador = GetComponent<Player>(); 
        //guardar la pocicion inicial
        inicialP = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //para que regrese el targuet debe ser la pocision inicial
        Vector3 target = inicialP;

        //detectar al distancia al jugador y atacar
        float dist = Vector2.Distance(player.transform.position, transform.position);
        if(dist <= visionRad) { target = player.transform.position;}

        //mobemos al enemigo al target
        float fixedspid = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, fixedspid);

        //debug
        Debug.DrawLine(transform.position, target, Color.green);

        
    }

    public void TakeDamage(int damage)
    {
        vida -= damage;
        if (vida<= 0)
        {
            Instantiate(Drop,transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {  
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.vida -= damage;
        }
    }
}
