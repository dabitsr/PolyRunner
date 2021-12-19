using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] float extraOffset;
    public static List<int> skins = new List<int>(6)
        {
            -1, 12, 0, 4, 15, 24
        };
    public List<GameObject> bounds = new();
    public GameObject firstPlatform, floor, floorPlayerPrefab;
    public int floorPlayersCount;
    public static bool godMode = false;

    static float maxLeft, maxRight;
    GameObject player;
    Vector3 firstPlatformPos, platformSize;
    static int currentLevel;
    string currentScene;

    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(gameObject);
        currentScene = SceneManager.GetActiveScene().name;
        currentLevel = LevelConverterStringToInt(currentScene);

        player = GameObject.Find("Player");
        player.transform.GetChild(0).GetChild(skins[currentLevel]).gameObject.SetActive(true);
        
        float offset = player.GetComponent<BoxCollider>().bounds.size.x;
        if (bounds.Count > 1)
        {
            maxLeft = bounds[0].gameObject.transform.position.x + offset + extraOffset;
            maxRight = bounds[1].gameObject.transform.position.x - offset - extraOffset;
        }
        else
        {
            print(bounds[0].transform.position);
            print(bounds[0].GetComponent<BoxCollider>().bounds.size);
        }

        /*
        firstPlatformPos = firstPlatform.transform.position;
        platformSize = firstPlatform.GetComponent<BoxCollider>().bounds.size - Vector3.right*offset*2;
        GenerateFloorPlayers();
        */
    }

    public void ResetPlayerSkin()
    {
        player.transform.GetChild(0).GetChild(skins[currentLevel]).gameObject.SetActive(false);
    }

    public static int GetCurrentSkin()
    {
        return skins[currentLevel];
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (currentScene != SceneManager.GetActiveScene().name)
        {
            ResetPlayerSkin();
        }
        */
    }

    void GenerateFloorPlayers()
    {
        Vector3 floorSize = new Vector3(firstPlatformPos.x + platformSize.x / 2, firstPlatformPos.y, firstPlatformPos.z + (platformSize.z * floor.transform.childCount));
        for (int i = 0; i < floorPlayersCount; i++)
        {
            Vector3 p = new Vector3(Random.Range(maxLeft, maxRight), floorSize.y + 1, Random.Range(firstPlatformPos.z, floorSize.z));
            GameObject a = Instantiate(floorPlayerPrefab, p, Quaternion.Euler(new Vector3(0, 180, 0)));
            a.transform.localScale = player.transform.localScale;
        }
    }

    public static float getMaxLeft()
    {
        return maxLeft;
    }

    public static float getMaxRight()
    {
        return maxRight;
    }

    public static string LevelConverterIntToString(int lvl)
    {
        switch (lvl)
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

    public static int LevelConverterStringToInt(string lvl)
    {
        switch (lvl)
        {
            case "MainMenu":
                return 0;
            case "PolyRunnerFirstScene":
                return 1;
            case "PolyRunnerSecondScene":
                return 2;
            case "PolyRunnerThirdScene":
                return 3;
            case "PolyRunnerFourthScene":
                return 4;
            case "PolyRunnerFifthScene":
                return 5;
            default:
                return -1;
        }
    }
}
