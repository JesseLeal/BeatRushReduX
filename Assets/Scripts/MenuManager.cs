using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject m_TitleScreen = null;
    [SerializeField] GameObject m_OptionsScreen = null;
    [SerializeField] GameObject m_LevelScreen = null;

    [SerializeField] Toggle m_TiltToggle = null;
    [SerializeField] Slider m_MusicSlider = null;
    //[SerializeField] Slider m_SFXSlider = null;

    [SerializeField] TextMeshProUGUI m_HighScoreText1 = null;
    [SerializeField] TextMeshProUGUI m_HighScoreText2 = null;
    [SerializeField] TextMeshProUGUI m_HighScoreText3 = null;

    void Start()
    {
        m_TiltToggle.isOn = PlayerPrefs.GetInt("TiltControls", 0) == 1;
        m_MusicSlider.value = PlayerPrefs.GetInt("MusicVolume", 100);
        AudioListener.volume = PlayerPrefs.GetInt("MusicVolume", 100) / 100.0f; 
        //m_SFXSlider.value = PlayerPrefs.GetInt("SFXVolume", 100);

        m_HighScoreText1.text = "High Score\n" + PlayerPrefs.GetInt("HighScore1", 0).ToString("D8");
        m_HighScoreText2.text = "High Score\n" + PlayerPrefs.GetInt("HighScore2", 0).ToString("D8");
        m_HighScoreText3.text = "High Score\n" + PlayerPrefs.GetInt("HighScore3", 0).ToString("D8");

        ToTitle();
    }
    
    void Update()
    {
        PlayerPrefs.SetInt("TiltControls", m_TiltToggle.isOn ? 1 : 0);
        PlayerPrefs.SetInt("MusicVolume", Mathf.FloorToInt(m_MusicSlider.value));
        AudioListener.volume = PlayerPrefs.GetInt("MusicVolume", 100) / 100.0f;
        //PlayerPrefs.SetInt("SFXVolume", Mathf.FloorToInt(m_SFXSlider.value));

        //also set the groups inside the audiomixer
        //needs a bit more research first
        //AkSoundEngine.SetRTPCValue("", Mathf.FloorToInt(m_MusicSlider.value));
        //AkSoundEngine.SetRTPCValue("", Mathf.FloorToInt(m_SFXSlider.value));
    }

    public void ToTitle()
    {
        m_TitleScreen.SetActive(true);

        m_OptionsScreen.SetActive(false);
        m_LevelScreen.SetActive(false);
    }

    public void ToOptions()
    {
        m_OptionsScreen.SetActive(true);

        m_TitleScreen.SetActive(false);
        m_LevelScreen.SetActive(false);
    }

    public void ToLevel()
    {
        m_LevelScreen.SetActive(true);

        m_TitleScreen.SetActive(false);
        m_OptionsScreen.SetActive(false);
    }

    public void PlayLevel(int level)
    {
        SceneManager.LoadScene("Track" + level);
    }
}