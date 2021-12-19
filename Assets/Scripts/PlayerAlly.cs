using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAlly : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).GetChild(GameManager.GetCurrentSkin()).gameObject.SetActive(true);

        GameObject player = GameObject.Find("Player");
        transform.localScale = player.transform.localScale;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}