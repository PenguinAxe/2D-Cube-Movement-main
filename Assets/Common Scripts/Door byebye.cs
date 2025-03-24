using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Doorbyebye : MonoBehaviour
{
    public int amount1;
    public GameObject enemy;
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        door.SetActive(true);
       Health amount1=enemy.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Health.amount>=3)
        {
            door.SetActive(false);
        }
    }
}
