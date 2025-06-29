using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.VersionControl;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public bool pickable = false; //can pick up this item
    public GameObject pickedup; //what was picked up
    public string placepickeditem1;
    public string placepickeditem2; //used to have 2 different objects and then when you click again it spawns a different object depending on name meaning you dont have to assign it
    public string pickeditem; //new game object of pickedup which is used to instantiate the projectile version
    public string removeplace;
    public string removeend; // removes place from the start of placeable objects so they can be instantiated
    public Transform firePointRotation; //firepoint rotation from bullet script
    public Transform bulletSpawnPoint; //spawnpoint from bullet script
    public GameObject kill; //used to destroy the placed versions of the projectiles
    public GameObject triggerdisable; //disables the trigger which detects if you can or cant pick up an object - caused a bug where you were holding something different then what was thrown
    public bool itemheld; //are you holding anything?
    public int objectspeed; // how fast it moves
    public int damage;// the amount of damage it does when hitting an enemy
    public int shooty; // (sorry for bad naming) - allows you to pick up an item first without immidiatly throwing it
    public int objweight;
    public int speed;

    //all below are throwables
    public GameObject hexagon;//crosshair
    public GameObject testbox1;
    public GameObject testbox2;

    // Start is called before the first frame update
    void Start()
    {
        shooty=0;
        speed=100;
        removeplace=("place ");

        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
    if (collision.gameObject.CompareTag("Object"))
    {   
        
         pickable=true;
        placepickeditem1 = collision.gameObject.name;
        if(placepickeditem1.Length>14)
        {
            kill=GameObject.Find(placepickeditem1);
            placepickeditem2 = placepickeditem1.Remove(placepickeditem1.Length - 4);
        }
        else
        {
            kill=GameObject.Find(placepickeditem1);
        }
        
        
    }
    }   
    private void OnTriggerExit2D(Collider2D collision)
    {
        pickable=false;
    }
    void Update()
    {
        if(placepickeditem1.Length>14)
        {
            pickeditem= placepickeditem2.Replace(removeplace, "");
        }
        else
        {
            pickeditem= placepickeditem1.Replace(removeplace, "");
        }
        Debug.Log(pickeditem);
        if (Input.GetButtonDown("Fire1") && itemheld==true)
        {
            shooty = shooty + 1;
        }
        if (Input.GetButtonDown("Fire1") && pickable==true)
        {
            hexagon.SetActive(false);
            if (pickeditem == ("pickup 1"))
            {
                testbox1.SetActive(true);
            }
            if (pickeditem == ("pickup 2"))
            {
                testbox2.SetActive(true);
            }
            Destroy(kill);
            itemheld=true;
            shooty = shooty + 1;
            triggerdisable.GetComponent<Collider2D>().enabled = false;
        }
        if (Input.GetButtonDown("Fire1") && itemheld==true && shooty >=2)
        {
            GameObject pickedup = (GameObject)Instantiate(Resources.Load(pickeditem),bulletSpawnPoint.position, firePointRotation.rotation);
             Rigidbody2D rb = pickedup.GetComponent<Rigidbody2D>();
            objectspeed=speed-pickedup.GetComponent<objectdamage>().weight;
            rb.velocity = firePointRotation.right * objectspeed;
            pickedup.GetComponent<objectdamage>().damage = damage;
            itemheld = false;
            Debug.Log(pickedup);
            pickedup = (null);
            pickeditem= (null);
            hexagon.SetActive(true);
            testbox1.SetActive(false);
            testbox2.SetActive(false);
            shooty = 0;
            kill=(null);
            triggerdisable.GetComponent<Collider2D>().enabled = true;
        }
    }
}
