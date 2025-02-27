using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealScript : MonoBehaviour
{ 
    public int HealAmount;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {   
            collision.GetComponent<Health>().Heal(HealAmount) ;
        }
        Destroy(gameObject);
    }
}
