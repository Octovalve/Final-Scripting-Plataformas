using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private float velocidadDeataque;

    public float inicioAtaque;
    public Transform attackPose;
    public float attackRange;
    public LayerMask enemy;
    public int damage;
    // Update is called once per frame
    void Update()
    {
        if(velocidadDeataque <= 0)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPose.position,attackRange,enemy);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
                velocidadDeataque = inicioAtaque;
            }
        }
        else
        {
            velocidadDeataque -= Time.deltaTime;
        }
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(attackPose.position, attackRange);
    }
}
