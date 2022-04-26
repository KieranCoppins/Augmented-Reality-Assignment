using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameObject scene;
    public GameObject[] avatars;

    //Play the next stage from waypoint and audio managers
    public void NextStage(){
        foreach (GameObject avatar in avatars){
            avatar.GetComponent<FollowWaypointStaged>().NextStage();
        }
        scene.GetComponent<StagedAudioPlayer>().NextStage();
    }

    // Update is called once per frame
    void Update()
    {
        //Find our scene and avatars as soon as possible
        if (scene == null){
            scene = GameObject.FindGameObjectWithTag("Scene");
        }
        else{
            if (avatars.Length == 0){
                avatars = GameObject.FindGameObjectsWithTag("Avatar");
            }
        }
    }
}
