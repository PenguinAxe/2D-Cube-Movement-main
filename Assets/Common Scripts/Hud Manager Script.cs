using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider healthSlider;

    // Update is called once per frame
    public void updatehealthbar(float value)
    {
        healthSlider.value = value;
    }
}
