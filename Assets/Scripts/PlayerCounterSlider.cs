using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCounterSlider : MonoBehaviour
{
    float val;
    // Start is called before the first frame update
    void Start()
    {
        val = 0;
        gameObject.GetComponent<Slider>().value = val;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
