using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    void Start()
    {
        Flash.SetActive(false);
    }
    public int Playerdamage = 2;
    public GameObject Flash;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {   
            collision.GetComponent<PlayerHealth>().PlayerTakeDamage(Playerdamage) ;
            Debug.Log("Player " + "took " + Playerdamage + " damage");
            Flash.SetActive(true);
        }
    }
}
