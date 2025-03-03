using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectdamage : MonoBehaviour
{ 
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {   
            collision.GetComponent<Health>().TakeDamage(damage) ;
            Debug.Log("Enemy " + "took " + damage + " damage");
            Destroy(gameObject);
        }
    }
}
