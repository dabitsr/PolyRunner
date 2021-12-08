using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbductController : MonoBehaviour
{
    [SerializeField] float abductForce;
    public bool abducting = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (abducting && (other.CompareTag("Player") || other.CompareTag("Ally")))
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * abductForce * Time.deltaTime, ForceMode.Impulse);
    }
}
