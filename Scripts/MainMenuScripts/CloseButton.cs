using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour
{
    [SerializeField] private GameObject sourceAudioObject;
    // Start is called before the first frame update
    public void closeWindow(AudioSource audio)
    {
        sourceAudioObject.GetComponent<MenuButtonScript>().ProcessSound(audio);
        transform.parent.gameObject.SetActive(false);
    }
}
