using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamiteController : MonoBehaviour
{
    [SerializeField] ParticleSystem explosion, fire;
    [SerializeField] float timeToExplode;
    [SerializeField] Collider explosionCollider;

    Color c;

    // Start is called before the first frame update
    void Start()
    {
        c = GetComponent<MeshRenderer>().material.color;
        explosionCollider.tag = "Untagged";
        Invoke("Explode", timeToExplode);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Explode()
    {
        explosion.Play();
        int a = 0;
        gameObject.GetComponent<MeshRenderer>().material.color = new Color(c.r, c.g, c.b, a);
        explosionCollider.tag = "Obstacle";

        Invoke("DisableCollision", 0.5f);
        Invoke("Delete", 2);
    }

    void DisableCollision() => explosionCollider.tag = "Untagged";
    void Delete() => Destroy(gameObject);
}
