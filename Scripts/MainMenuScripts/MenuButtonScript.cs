using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuButtonScript: MonoBehaviour
{
    [SerializeField]private GameObject panelStartGame;
    [SerializeField]private GameObject panelHowToPlay;
    [SerializeField]private GameObject panelCredits;
    [SerializeField] private AudioSource audioSource;

    void Start()
    {
        panelStartGame.SetActive(false);
        panelCredits.SetActive(false);
        panelHowToPlay.SetActive(false);
    }
    public void ProcessSound(AudioSource audio)
    {
        audioSource.clip = audio.clip;
        audioSource.Play();
    }
    public void startGameWindow(AudioSource audio)
    {
        ProcessSound(audio);
        panelStartGame.SetActive(true);
    }
    public void startCreditsWindow(AudioSource audio)
    {
        ProcessSound(audio);
        panelCredits.SetActive(true);
    }
    public void ExitButton(AudioSource audio)
    {
        ProcessSound(audio);
        Application.Quit();
    }
    public void OnePlayerButton(AudioSource audio)
    {
        ProcessSound(audio);
        SceneManager.LoadScene("MainGameOnePlayer");
    }
    public void howToPlayPanel(AudioSource audio)
    {
        ProcessSound(audio);
        GetComponent<PanelSwitcher>().CurrentIndex = 0;
        GetComponent<PanelSwitcher>().switchPanels(1, 0);
        panelHowToPlay.SetActive(true);
    }
}
