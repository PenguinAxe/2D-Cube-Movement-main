using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour
{
    public int Maxhealth;
    public bool death;
    Animator animator;
    
    public int Currenthealth;
    GameObject navmesh;
    // Start is called before the first frame update
    private void Start()
    {
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
    void Die1()
    {
    StartCoroutine(ExampleCoroutine());
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
    }
}
