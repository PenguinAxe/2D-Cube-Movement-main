using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.VersionControl;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public bool pickable = false;
    public GameObject pickedup;
    public string pickeditem;
    public GameObject otherobject;
    public Transform firePointRotation;
    public Transform bulletSpawnPoint;
    public bool itemheld;
    public float objectspeed = 5f;
    public int objectweight= 50;
    public int damage; 
    public int shooty;
    public bool shut;//idk what to call things
    public bool checkshooty;
    public GameObject hexagon;
    // Start is called before the first frame update
    void Start()
    {
        damage = 5 * objectweight;
        shooty=0;
        shut=false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
    if (collision.gameObject.CompareTag("Object") && shut == false)
    {   
         pickable=true;
        //Debug.Log(collision.gameObject.name);//what you are looking at / can pick up
        pickeditem = collision.gameObject.name;
        shut=true;
        Destroy(otherobject);
        
    }
    }   
    private void OnTriggerExit2D(Collider2D collision)
    {
        pickable=false;
        shut=false;
    }
    void Update()
    {
        Debug.Log(pickeditem);
        if (Input.GetButtonDown("Fire1") && itemheld==true)
        {
            shooty = shooty + 1;
        }
        if (Input.GetButtonDown("Fire1") && pickable==true)
        {
            hexagon.SetActive(false);
            itemheld=true;
            shooty = shooty + 1;
        }
        if (Input.GetButtonDown("Fire1") && itemheld==true && shooty >=2)
        {
            GameObject pickedup = (GameObject)Instantiate(Resources.Load(pickeditem),bulletSpawnPoint.position, firePointRotation.rotation);
             Rigidbody2D rb = pickedup.GetComponent<Rigidbody2D>();
            rb.velocity = firePointRotation.right * objectspeed;
            pickedup.GetComponent<objectdamage>().damage = damage;
            shut=false;
            itemheld = false;
            pickedup = (null);
            pickeditem= (null);

        }
    }
}
