using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteUnmute : MonoBehaviour
{
    public bool isMuted;
    private bool isMuteClicked;
    public Sprite mutedSprite; public Sprite unMutedSprite;

    // Start is called before the first frame update
    void Start()
    {
        isMuted = false;
        isMuteClicked = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void mute()
    {
        FindObjectOfType<Camera>().GetComponent<AudioListener>().enabled = false;
    }

    public void unmute()
    {
        FindObjectOfType<Camera>().GetComponent<AudioListener>().enabled = true;
    }

    public void muteUnmute()
    {
        if (!isMuteClicked)
        {
            FindObjectOfType<Camera>().GetComponent<AudioListener>().enabled = false;
            isMuteClicked = true;
            this.gameObject.GetComponent<Image>().sprite = mutedSprite;
        } else if (isMuteClicked)
        {
            FindObjectOfType<Camera>().GetComponent<AudioListener>().enabled = true;
            isMuteClicked = false;
            this.gameObject.GetComponent<Image>().sprite = unMutedSprite;
        }
    }
}
