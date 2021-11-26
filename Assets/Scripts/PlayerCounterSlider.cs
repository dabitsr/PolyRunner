using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCounterSlider : MonoBehaviour
{
    float val, newVal;
    // Start is called before the first frame update
    void Start()
    {
        newVal = val = 0;
        gameObject.GetComponent<Slider>().value = val;
    }

    // Update is called once per frame
    void Update()
    {
        val = Mathf.Lerp(val, newVal, Time.deltaTime * 5);
        gameObject.GetComponent<Slider>().value = val;
    }

    public void IncreaseSlider()
    {
        newVal += 1;
    }

    public void DecreaseSlider()
    {
        newVal -= 1;
    }
}
