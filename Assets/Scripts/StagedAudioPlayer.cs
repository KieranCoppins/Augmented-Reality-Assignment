using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Play relevant audio clips, subtitles and titles per stage
public class StagedAudioPlayer : MonoBehaviour
{
    int stage = 0;
    public AudioClip[] audioClips;
    public string[] subtitles;

    public string title;

    public TextMeshProUGUI titleText;
    public TextMeshProUGUI subtitleText;

    AudioSource audioSource;

    //Get all our components
    private void Start() {
        audioSource = this.GetComponent<AudioSource>();
        titleText = GameObject.FindGameObjectWithTag("Title").GetComponent<TextMeshProUGUI>();
        subtitleText = GameObject.FindGameObjectWithTag("Subtitle").GetComponent<TextMeshProUGUI>();
        titleText.text = title;
        NextStage();
    }

    public void NextStage(){
        //Stop our existing audio
        audioSource.Stop();
        //Load relevant audio clip
        audioSource.clip = audioClips[stage];
        //Play the new clip
        audioSource.Play();
        //Update subtitle text
        subtitleText.text = subtitles[stage];
        //Increment our stage
        stage++;
    }
}
