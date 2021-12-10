using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGateController : MonoBehaviour
{
    [SerializeField] GateController gateController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Ally"))
        {
            gateController.Open();
            Destroy(gameObject);
        }
    }
}
