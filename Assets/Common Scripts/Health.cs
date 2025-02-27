using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int Maxhealth;
    int Currenthealth;
    // Start is called before the first frame update
    private void Start()
    {
        Currenthealth = Maxhealth;
    }

    // Update is called once per frame
    public void Heal(int HealAmount) // this is unused right now
    {
        Currenthealth -= HealAmount;
    }
    public void TakeDamage(int damage)
    {
        Currenthealth -= damage;
        if (Currenthealth <=0 )
        {
            Die();//die
        }
    }
    void Die()
    {
        Debug.Log(gameObject.name + " was destroyed");
        Destroy(gameObject);
    }
}
