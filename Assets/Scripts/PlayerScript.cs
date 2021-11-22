using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Vector3 spawnPoint;
    public GameObject playerAllyPrefab;
    public float distanceAllies = 0.15f;
    public float expandX, expandZ;

    Dictionary<Vector2, bool> positions = new();
    Animator anim;
    BoxCollider boxCollider;
    Vector2 posFarAlly, negFarAlly = new Vector2(0, 0); // Los aliados m�s alejados del jugador (se usa para calcular el collider del grupo)

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isRunning", true);
        transform.position = spawnPoint;
        boxCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
    }

    public void collectAlly()
    {
        // Assign position
        int n = GameObject.FindGameObjectsWithTag("Ally").Length;
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
        else print("ERROR: v == (-1, -1)");

        // Create Player Ally
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
        }
        else if (v.y < negFarAlly.y)
        {
            negFarAlly.y = v.y;
            boxCollider.size += Vector3.forward * expandZ;
            boxCollider.center += Vector3.back * (expandZ / 2);
        }
        Vector3 initPos = new Vector3(transform.position.x + v.x, transform.position.y, transform.position.z + v.y);
        print(v);
        GameObject ally = Instantiate(playerAllyPrefab, initPos, Quaternion.Euler(new Vector3(0, 180, 0)));
        ally.GetComponent<Movement>().setPosRelativeToPlayer(v);
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
            bool b = positions[v];  // Ya est� ocupado, cogemos el de ejes inversos
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

    public void deletePos(Vector2 v)
    {
        positions[v] = false;
    }

    public Vector3 getPosition()
    {
        return transform.position;
    }
}
