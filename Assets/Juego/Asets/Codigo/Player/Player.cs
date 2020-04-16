using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float spid;
    public float jumpforce;
    public int monedas;
    public int vida;
    public int maxvida;
    public float maxJump;
    public float maxSpid;
    
    float t = 3;
    private SpriteRenderer sr;
    private bool jump = true;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        monedas = PlayerPrefs.GetInt("Monedas", monedas);
        maxvida = PlayerPrefs.GetInt("VidaMax", maxvida);
    }
   
    private void Update()
    {
        GameControler.score = monedas;
        GameControler.vida = vida;
        if (vida >= maxvida ) { vida = maxvida; }
        if (jumpforce > maxJump) {t -= Time.deltaTime ;if (t <= 0) { jumpforce = maxJump; t = 3; } }
        if (spid> maxSpid) { t -= Time.deltaTime; if (t <= 0) { spid = maxSpid; t = 3; } }
        if (vida <= 0) {GameControler.Derrota(); vida = 0; Time.timeScale = 0; Destroy(gameObject); }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * spid * Time.deltaTime;
            if (sr.flipX == false) { sr.flipX = true; }
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * spid * Time.deltaTime;
            if (sr.flipX == true) { sr.flipX = false; }
        }
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) &&jump==true)
        {
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            jump = false;
        }
        if(jump == false)
        {
            t -= Time.deltaTime;
            if (t <= 0) { jump = true;t = 3; }
        }
        PlayerPrefs.SetInt("Monedas", monedas);
        PlayerPrefs.SetInt("VidaMax", maxvida);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ppiso" )
        {
            jump = true;
        }
    }
}
