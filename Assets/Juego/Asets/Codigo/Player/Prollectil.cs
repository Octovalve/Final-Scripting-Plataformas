using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prollectil : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distancia = 0;
    public LayerMask solido;
    public int damage;
    public Vector2 direcion;

    private void Start()
    {
        Invoke("DestruirProllectil", lifeTime);
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitinfo= Physics2D.Raycast(transform.position,transform.up,distancia,solido);
        if (hitinfo.collider != null)
        {
            if (hitinfo.collider.CompareTag("Enemy"))
            {
                hitinfo.collider.GetComponent<Enemy>().TakeDamage(damage);
                DestruirProllectil();
            }
            if (hitinfo.collider.CompareTag("Ppiso"))
            {
                DestruirProllectil();
            }
        }
        transform.Translate(direcion * speed * Time.deltaTime);
    }
    void DestruirProllectil()
    {
        Destroy(gameObject);
    }
}
