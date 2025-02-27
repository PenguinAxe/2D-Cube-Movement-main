using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraShake : MonoBehaviour
{ 
    void start()
    {}
// Then assign a new vector3
        public float speed = 1.0f; //how fast it shakes
        public float amount = 0.2f; //how much it shakes
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {   
            float x = gameObject.transform.position.x * Mathf.Sin(Time.time * .10f) * .10f;
            float y = gameObject.transform.position.y;
            float z = gameObject.transform.position.z;
            gameObject.transform.position = new Vector3 (x + amount,y + amount,x + amount);
        }
    }
}