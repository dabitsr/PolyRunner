using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public CinemachineBrain mainCamera;
    public CinemachineVirtualCamera frame0_cam;
    public CinemachineVirtualCamera frame1_cam;
    public CinemachineVirtualCamera frame2_cam;
    public CinemachineVirtualCamera frame3_cam;
    public CinemachineVirtualCamera frame4_cam;
    public CinemachineVirtualCamera frame5_cam;
    public CinemachineVirtualCamera frame6_cam;
    public CinemachineVirtualCamera frame7_cam;

    public GameObject[] frame;
    public GameObject startButton;
    public EventSystem ES;

    public Button StartGameButton;

    public Button FirstLevelButton;
    public Button SecondLevelButton;
    public Button ThirdLevelButton;
    public Button FourthLevelButton;
    public Button FifthLevelButton;

    public Button InstructionsButton;
    public Button CreditsButton;
    public Button OptionsButton;

    public GameObject westTrain;
    public GameObject scifiBalloon;
    public GameObject cityBalloon;

    private bool pressedFirst;
    private bool pressedSecond;
    private bool pressedThird;
    private bool pressedFourth;
    private bool pressedFifth;

    // Start is called before the first frame update
    void Start()
    {

                /* START GAME AND LEVELS */

        Button btn = StartGameButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        pressedFirst = false;

        Button btn2 = FirstLevelButton.GetComponent<Button>();
        btn2.onClick.AddListener(TaskOnClickFirst);

        pressedSecond = false;

        Button btn3 = SecondLevelButton.GetComponent<Button>();
        btn3.onClick.AddListener(TaskOnClickSecond);

        pressedThird = false;

        Button btn4 = ThirdLevelButton.GetComponent<Button>();
        btn4.onClick.AddListener(TaskOnClickThird);

        pressedFourth = false;

        Button btn5 = FourthLevelButton.GetComponent<Button>();
        btn5.onClick.AddListener(TaskOnClickFourth);

        pressedFifth = false;

        Button btn6 = FifthLevelButton.GetComponent<Button>();
        btn6.onClick.AddListener(TaskOnClickFifth);

                /* INSTRUCTIONS */

        Button instButton = InstructionsButton.GetComponent<Button>();
        instButton.onClick.AddListener(TaskOnClickInstructions);

                /* CREDITS */

        Button credButton = CreditsButton.GetComponent<Button>();
        credButton.onClick.AddListener(TaskOnClickCredits);

                /* OPTIONS */

        Button optButton = OptionsButton.GetComponent<Button>();
        optButton.onClick.AddListener(TaskOnClickOptions);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && frame[0].activeInHierarchy)
        {
            frame[0].SetActive(false);
            frame[1].SetActive(true);
            ES.SetSelectedGameObject(startButton);
            frame0_cam.gameObject.SetActive(false);
            frame1_cam.gameObject.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (frame[1].activeInHierarchy)
            {
                frame[0].SetActive(true);
                frame[1].SetActive(false);
                ES.SetSelectedGameObject(startButton);
                frame0_cam.gameObject.SetActive(true);
                frame1_cam.gameObject.SetActive(false);
            } 
            
            else if (frame[2].activeInHierarchy)
            {
                frame[1].SetActive(true);
                frame[2].SetActive(false);
                ES.SetSelectedGameObject(startButton);
                frame1_cam.gameObject.SetActive(true);
                frame2_cam.gameObject.SetActive(false);
            }
            
            else if (frame[3].activeInHierarchy)
            {
                frame[1].SetActive(true);
                frame[3].SetActive(false);
                ES.SetSelectedGameObject(startButton);
                frame1_cam.gameObject.SetActive(true);
                frame6_cam.gameObject.SetActive(false);
            }

            else if (frame[4].activeInHierarchy)
            {
                frame[1].SetActive(true);
                frame[4].SetActive(false);
                ES.SetSelectedGameObject(startButton);
                frame1_cam.gameObject.SetActive(true);
                frame7_cam.gameObject.SetActive(false);
            }
            else if (frame[5].activeInHierarchy)
            {
                frame[1].SetActive(true);
                frame[5].SetActive(false);
                ES.SetSelectedGameObject(startButton);
                frame1_cam.gameObject.SetActive(true);
                frame7_cam.gameObject.SetActive(false);
            }
        }

        if (pressedFirst)
        {
            frame[2].SetActive(false);
            frame2_cam.gameObject.SetActive(false);
            frame3_cam.gameObject.SetActive(true);
            frame3_cam.transform.position += frame3_cam.transform.forward * Time.deltaTime * 2;
            westTrain.transform.position += westTrain.transform.forward * Time.deltaTime * 2;

            if (westTrain.transform.position.x > 65) SceneManager.LoadScene("PolyRunnerFirstScene");
        } 
        
        else if (pressedSecond)
        {
            frame[2].SetActive(false);
            frame2_cam.gameObject.SetActive(false);
            frame4_cam.gameObject.SetActive(true);
            frame4_cam.transform.position += frame4_cam.transform.up * Time.deltaTime * 4;
            scifiBalloon.transform.position += scifiBalloon.transform.up * Time.deltaTime * 4;

            if (scifiBalloon.transform.position.y > 20) SceneManager.LoadScene("PolyRunnerSecondScene");
        } 

        else if (pressedThird)
        {
            frame[2].SetActive(false);
            frame2_cam.gameObject.SetActive(false);
            frame5_cam.gameObject.SetActive(true);
            frame5_cam.transform.position += frame5_cam.transform.up * Time.deltaTime * 4;
            cityBalloon.transform.position += cityBalloon.transform.up * Time.deltaTime * 4;

            if (cityBalloon.transform.position.y > 20) SceneManager.LoadScene("PolyRunnerThirdScene");
        }

        else if (pressedFourth)
        {
            frame[2].SetActive(false);
            frame2_cam.gameObject.SetActive(false);
            frame3_cam.gameObject.SetActive(true);
            frame3_cam.transform.position += frame3_cam.transform.forward * Time.deltaTime * 2;
            westTrain.transform.position += westTrain.transform.forward * Time.deltaTime * 2;

            if (westTrain.transform.position.x > 65) SceneManager.LoadScene("PolyRunnerFourthScene");
        }

        else if (pressedFifth)
        {
            frame[2].SetActive(false);
            frame2_cam.gameObject.SetActive(false);
            frame3_cam.gameObject.SetActive(true);
            frame3_cam.transform.position += frame3_cam.transform.forward * Time.deltaTime * 2;
            westTrain.transform.position += westTrain.transform.forward * Time.deltaTime * 2;

            if (westTrain.transform.position.x > 65) SceneManager.LoadScene("PolyRunnerFifthScene");
        }


    }

    void TaskOnClick()
    {        
        frame[1].SetActive(false);
        frame[2].SetActive(true);
        ES.SetSelectedGameObject(startButton);
        frame0_cam.gameObject.SetActive(false);
        frame1_cam.gameObject.SetActive(false);
        frame2_cam.gameObject.SetActive(true);
        frame3_cam.gameObject.SetActive(false);
        frame4_cam.gameObject.SetActive(false);
        frame5_cam.gameObject.SetActive(false);
        frame6_cam.gameObject.SetActive(false);
        frame7_cam.gameObject.SetActive(false);
    }

    void TaskOnClickFirst()
    {
        pressedFirst = true;
    }

    void TaskOnClickSecond()
    {
        pressedSecond = true;
    }

    void TaskOnClickThird()
    {
        pressedThird = true;
    }

    void TaskOnClickFourth()
    {
        pressedFourth = true;
    }

    void TaskOnClickFifth()
    {
        pressedFifth = true;
    }

    void TaskOnClickInstructions()
    {
        frame[1].SetActive(false);
        frame[3].SetActive(true);
        ES.SetSelectedGameObject(startButton);
        frame0_cam.gameObject.SetActive(false);
        frame1_cam.gameObject.SetActive(false);
        frame2_cam.gameObject.SetActive(false);
        frame3_cam.gameObject.SetActive(false);
        frame4_cam.gameObject.SetActive(false);
        frame5_cam.gameObject.SetActive(false);
        frame6_cam.gameObject.SetActive(true);
    }

    void TaskOnClickCredits()
    {
        frame[1].SetActive(false);
        frame[4].SetActive(true);
        ES.SetSelectedGameObject(startButton);
        frame0_cam.gameObject.SetActive(false);
        frame1_cam.gameObject.SetActive(false);
        frame2_cam.gameObject.SetActive(false);
        frame3_cam.gameObject.SetActive(false);
        frame4_cam.gameObject.SetActive(false);
        frame5_cam.gameObject.SetActive(false);
        frame6_cam.gameObject.SetActive(false);
        frame7_cam.gameObject.SetActive(true);
    }

    void TaskOnClickOptions()
    {
        frame[1].SetActive(false);
        frame[5].SetActive(true);
        ES.SetSelectedGameObject(startButton);
        frame0_cam.gameObject.SetActive(false);
        frame1_cam.gameObject.SetActive(false);
        frame2_cam.gameObject.SetActive(false);
        frame3_cam.gameObject.SetActive(false);
        frame4_cam.gameObject.SetActive(false);
        frame5_cam.gameObject.SetActive(false);
        frame6_cam.gameObject.SetActive(false);
        frame7_cam.gameObject.SetActive(true);
    }

}
