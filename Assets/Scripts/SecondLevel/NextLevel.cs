using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] int nextLevel;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z >= transform.position.z)
        {
            print("Loading " + GameManager.LevelConverterIntToString(nextLevel) + " ...");
            SceneManager.LoadScene(GameManager.LevelConverterIntToString(nextLevel));
        }
    }

}
