using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GeneralOptions : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public int quality;
    public GameObject frame, switchLevelFrame;
    [SerializeField] Slider volumeSlider;
    [SerializeField] TextMeshProUGUI playersCounterText;
    [SerializeField] Button minusButton;
    [SerializeField] Toggle godMode;

    PlayerScript playerScript;
    int playersCounter;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        /* Audio options */
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
        }
        else
        {
            Load();
        }

        quality = PlayerPrefs.GetInt("numeroDeCalidad", 6);
        dropdown.value = quality;
        AjustarCalidad();
    }

    // Update is called once per frame
    void Update()
    {
        minusButton.interactable = playersCounter > 0;

        if (Input.GetKeyUp("escape"))
        {
            playersCounter = GameObject.FindGameObjectsWithTag("Ally").Length;
            UpdatePlayersCounterText();
            if (frame.active)
            {
                Time.timeScale = 1;
                AudioListener.pause = false;
            }
            else
            {
                Time.timeScale = 0;
                AudioListener.pause = true;
            }

            frame.SetActive(!frame.active);
        }
        // For stopping the game
        if (Time.timeScale == 0) return;
    }

    public void AjustarCalidad()
    {
        QualitySettings.SetQualityLevel(dropdown.value);
        PlayerPrefs.SetInt("numeroDeCalidad", dropdown.value);
        quality = dropdown.value;
    }

    public void SetFullScreen(bool isFullScreen)
    {
        if (Screen.fullScreen)
        {
            Screen.SetResolution(1920, 1080, false);
        }
        else
        {
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
        }
    }

    public void AjustarVolumen()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

    public void GoBackToOptions()
    {
        frame.gameObject.SetActive(true);
        switchLevelFrame.gameObject.SetActive(false);
    }

    public void GoToSwitchLevel()
    {
        frame.gameObject.SetActive(false);
        switchLevelFrame.gameObject.SetActive(true);
    }

    public void UpdateGodmode(bool gm)
    {
        GameManager.godMode = godMode.isOn;
        print("godMode: " + GameManager.godMode);
    }

    public void AddFollower()
    {
        playerScript.collectAlly(GameObject.FindGameObjectsWithTag("Ally").Length, null);
        playersCounter++;
        UpdatePlayersCounterText();
    }

    public void RemoveFollower()
    {
        playerScript.RemoveAlly();
        playersCounter--;
        UpdatePlayersCounterText();
    }

    public void LoadScene(string scene)
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        SceneManager.LoadScene(scene);
    }

    void UpdatePlayersCounterText()
    {
        playersCounterText.text = playersCounter + " FOLLOWERS";
    }
}
