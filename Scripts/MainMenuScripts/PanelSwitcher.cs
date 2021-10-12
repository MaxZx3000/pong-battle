using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSwitcher : MonoBehaviour
{
    private int currentIndex = 0;
    public int CurrentIndex { set => currentIndex =value; }
    public GameObject[] panels;
    public void switchPanels(int before, int after)
    {
        panels[before].SetActive(false);
        panels[after].SetActive(true);
    }
    public void NextPanelPage(AudioSource audio)
    {
        audio.Play();
        if (currentIndex < panels.Length - 1) { currentIndex += 1; switchPanels(currentIndex - 1, currentIndex); }
        else { currentIndex = 0; switchPanels(panels.Length - 1, currentIndex); }
    }
    public void previousPanelPage(AudioSource audio)
    {
        audio.Play();
        if (currentIndex > 0) { currentIndex -= 1; switchPanels(currentIndex + 1, currentIndex); }
        else { currentIndex = panels.Length - 1; switchPanels(0, currentIndex);  }
    }
}
