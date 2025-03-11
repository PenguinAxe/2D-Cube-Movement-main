using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectdamage : MonoBehaviour
{ 
    public GameObject enemy;
    public int damage;
    public int weight;
    public int total;
    public int objecthealth;
    void Start()
    {
        total = damage * weight;
        objecthealth = total*2;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {   
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), enemy.GetComponent<Collider2D>());
            collision.GetComponent<Health>().TakeDamage(total);
            objecthealth=objecthealth-damage;
            Debug.Log("Enemy " + "took " + damage + " damage");

            if (objecthealth<0)
            {
                Destroy(gameObject);
            }
        }
    }
}
