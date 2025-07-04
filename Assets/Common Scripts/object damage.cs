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

    public Transform firePointRotation1;
    public GameObject brokenbits;

    void Start()
    {
        damage = 5;
        total = weight/damage;
        objecthealth = total;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("wall"))
        {
						BreakIt();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {   
            Physics2D.IgnoreCollision(gameObject.GetComponent<BoxCollider2D>(), enemy.GetComponent<CircleCollider2D>());
            collision.GetComponent<Health>().TakeDamage(total);
            objecthealth=objecthealth-damage;
            Debug.Log("Enemy " + "took " + total + " damage");

            if (objecthealth<0)
            {
                BreakIt();
            }
        }
        
    }
    public void BreakIt()
	{
		Destroy (this.gameObject);
		 GameObject broke = (GameObject)    Instantiate (brokenbits, transform.position, transform.rotation);

		foreach (Transform child in broke.transform) {


			child.GetComponent<Rigidbody2D>().velocity= new Vector2(Random.Range(-0.5f,1f),Random.Range(-1f,1.5f));
				}


	}
}
