using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class end : MonoBehaviour
{
    public GameObject player;
    public GameObject camera;
    bool first = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z >= 475)
        {
            player.SetActive(false);
            camera.GetComponent<FollowTarget>().enabled = false;
            if (first)
            {
                camera.transform.position = new Vector3(0.0f, 6.0f, -10.0f);
                camera.transform.Rotate(16.39f, 0.0f, 0.0f, Space.Self);
                first = false;
            }
            camera.transform.position += transform.up * Time.deltaTime;
            if (camera.transform.position.y >= 76) SceneManager.LoadScene("MainMenu");
        }
    }
}
