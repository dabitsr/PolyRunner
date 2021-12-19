using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct initBoxColliderStruct
{
    public Vector3 size;
    public Vector3 center;
};

public class PlayerScript : MonoBehaviour
{
    public Vector3 spawnPoint;
    public GameObject playerAllyPrefab;
    public float expandX, expandZ;
    [SerializeField] BoxCollider boxCollider;

    float distanceAllies;
    Dictionary<Vector2, bool> positions = new();
    Animator anim;
    initBoxColliderStruct initBox;
    Vector2 posFarAlly, negFarAlly = new Vector2(0, 0); // Los aliados más alejados del jugador (se usa para calcular el collider del grupo)
    int allies;
    AudioSource audio;
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isRunning", true);
        transform.position = spawnPoint;
        //boxCollider = GetComponent<BoxCollider>();
        initBox.size = boxCollider.size;
        initBox.center = boxCollider.center;
        distanceAllies = boxCollider.bounds.size.x;

        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Ally").Length < allies)
        {
            RepositionAllies();
            allies = GameObject.FindGameObjectsWithTag("Ally").Length;
        }
        else allies = GameObject.FindGameObjectsWithTag("Ally").Length;
    }

    public void collectAlly(int n, GameObject existingAlly)
    {
        // Assign position relative to player
        //int n = GameObject.FindGameObjectsWithTag("Ally").Length;
        int a = n / 4;
        Vector2 v;

        if (a == 0) v = new Vector2(distanceAllies, 0);
        else if (a == 1) v = new Vector2(distanceAllies, distanceAllies);
        else if (a == 2) v = new Vector2(distanceAllies*2, 0);
        else if (a == 3) v = new Vector2(distanceAllies*2, distanceAllies);
        else if (a == 4) v = new Vector2(distanceAllies, distanceAllies*2);
        else if (a == 5) v = new Vector2(distanceAllies*2, distanceAllies*2);
        else v = new Vector2(-1, -1);

        if (v != new Vector2(-1, -1)) v = getPos(n % 4, v);
        else print("Max allies reached!");

        // Box collider
        if (v.x > posFarAlly.x)
        {
            posFarAlly.x = v.x;
            boxCollider.size += Vector3.right * expandX;
            boxCollider.center += Vector3.right * (expandX/2);
        } else if (v.x < negFarAlly.x)
        {
            negFarAlly.x = v.x;
            boxCollider.size += Vector3.right * expandX;
            boxCollider.center += Vector3.left * (expandX / 2);
        }

        if (v.y > posFarAlly.y)
        {
            posFarAlly.y = v.y;
            boxCollider.size += Vector3.forward * expandZ;
            boxCollider.center += Vector3.forward * (expandZ / 2);
        } else if (v.y < negFarAlly.y)
        {
            negFarAlly.y = v.y;
            boxCollider.size += Vector3.forward * expandZ;
            boxCollider.center += Vector3.back * (expandZ / 2);
        }

        if (existingAlly == null)
        {
            // Create Ally
            Vector3 initPos = new Vector3(transform.position.x + v.x, transform.position.y, transform.position.z + v.y);
            GameObject ally = Instantiate(playerAllyPrefab, initPos, Quaternion.Euler(new Vector3(0, 180, 0)));
            ally.transform.localScale = transform.localScale;
            ally.GetComponent<Movement>().setPosRelativeToPlayer(v);
        } else
        {
            existingAlly.GetComponent<Movement>().setPosRelativeToPlayer(v);
        }
    }

    Vector2 getPos(int r, Vector2 v)
    {
        if (r == 0) return setPos(v);
        if (r == 1) return setPos(v * -1);
        if (r == 2) return setPos(v * new Vector2(-1, 1));
        if (r == 3) return setPos(v * new Vector2(1, -1));
        else return Vector2.zero;
    }

    Vector2 setPos(Vector2 v)
    {
        try
        {
            bool b = positions[v];  // Ya está ocupado, cogemos el de ejes inversos
            Vector2 w = new Vector2(v.y, v.x);
            positions[w] = true;
            return w;
        }
        catch
        {
            positions[v] = true;
            return v;
        }
    }

    public void RepositionAllies()
    {
        GameObject[] allies = GameObject.FindGameObjectsWithTag("Ally");
        positions.Clear();
        posFarAlly = negFarAlly = new Vector2(0, 0);
        boxCollider.size = initBox.size;
        boxCollider.center = initBox.center;
        for (int i = 0; i < allies.Length; i++)
        {
            collectAlly(i, allies[i]);
        }
    }

    public void deletePos(Vector2 v)
    {
        //positions[v] = false;
    }

    public Vector3 getPosition()
    {
        return transform.position;
    }

    public void PlayAudio(AudioClip a)
    {
        audio.clip = a;
        audio.Play();
    }
}

