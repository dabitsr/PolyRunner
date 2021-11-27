using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartGame : MonoBehaviour
{
    public GameObject westTrain;
    public GameObject scifiBalloon;
    public GameObject cityBalloon;

    public void LoadScene(string sceneName)
    {
        if (sceneName == "PolyRunnerFirstScene")
        {
            westTrain.transform.position += westTrain.transform.right * Time.deltaTime * 2;
        }

        if (westTrain.transform.position.x > 90) SceneManager.LoadScene(sceneName);
    }
}
