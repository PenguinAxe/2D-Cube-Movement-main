using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlashRedDamage : MonoBehaviour
{
    public GameObject Flash;
    // Start is called before the first frame update
    public void Flashes()
    {
        Flash.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
