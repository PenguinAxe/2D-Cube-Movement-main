using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour
{
    public int Maxhealth;
    public bool death;
    Animator animator;
    public static int amount;
    
    public int Currenthealth;

    // Start is called before the first frame update
    private void Start()
    {
        amount = 0;
        animator = GetComponent<Animator>();
        Currenthealth = Maxhealth;
        gameObject.GetComponent<NavMeshAgent>().enabled = true;
        gameObject.GetComponent<Collider2D>().enabled = true;
        
    }

    // Update is called once per frame
    public void Heal(int HealAmount) // this is unused right now
    {
        Currenthealth -= HealAmount;
    }
    public void TakeDamage(int total)
    {
        Currenthealth -= total;
    }
    private void Update()
    {
        if (Currenthealth <=0 )
        {
            animator.SetBool("death", true);
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
            Die1();//die
        }
    }
    public void Die1()
    {
    amount = amount+1;
    StartCoroutine(ExampleCoroutine());
    IEnumerator ExampleCoroutine()
    {
        amount = amount+1;
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
    }
}
