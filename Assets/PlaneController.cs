using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [SerializeField] float speed, rotationSpeed;
    [SerializeField] GameObject activate;
    public bool move = false, fly = false;
    float angle = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(transform.eulerAngles);
        if (move)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            if (fly)
            {
                //angle = Mathf.LerpAngle(angle, 30, rotationSpeed);
                //transform.eulerAngles = Vector3.right * (360 - angle);
                if (transform.eulerAngles.x > 320 || transform.eulerAngles.x == 0)
                    transform.eulerAngles = transform.eulerAngles + Vector3.right * -Time.deltaTime * rotationSpeed;
                else if (transform.eulerAngles.x > 300)
                    Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Plane Sensor"))
            Fly();
    }

    public void Fly()
    {
        fly = true;

        activate.SetActive(true);
    }
}
