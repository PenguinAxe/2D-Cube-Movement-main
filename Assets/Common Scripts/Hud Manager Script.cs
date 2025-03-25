using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManagerScript : MonoBehaviour
{
    public GameObject lowtaperfade;
    // Start is called before the first frame update
    public Slider healthSlider;
    void Start()
    {
        lowtaperfade=GameObject.Find("Low taper Fade");
        StartCoroutine(WaitAndPrint());
    }
    // Update is called once per frame
    public void updatehealthbar(float value)
    {
        healthSlider.value = value;
    }
    private IEnumerator WaitAndPrint()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            lowtaperfade.SetActive(false);
        }
    }
}
