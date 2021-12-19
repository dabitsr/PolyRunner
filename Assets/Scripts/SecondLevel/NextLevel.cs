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
            SceneManager.LoadScene(LevelConverter(nextLevel));
        }
    }

    string LevelConverter(int lvl)
    {
        switch(lvl)
        {
            case 0:
                return "MainMenu";
            case 1:
                return "PolyRunnerFirstScene";
            case 2:
                return "PolyRunnerSecondScene";
            case 3:
                return "PolyRunnerThirdScene";
            case 4:
                return "PolyRunnerFourthScene";
            case 5:
                return "PolyRunnerFifthScene";
            default:
                return "";
        }
    }
}
