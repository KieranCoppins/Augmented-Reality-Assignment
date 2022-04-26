using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LODAnimation : MonoBehaviour
{
    //Get the renderer component of our highest LOD
    public Renderer LOD0Renderer;
    //Get the game object of the lowest LOD - if they're dead we're just delete it
    public GameObject LOD1Renderer;
    //Get the animator to cancel animations at lower LODs
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        //Check if the highest LOD is visible
        if(LOD0Renderer.isVisible){

            //If it is then enable animations
            animator.enabled = true;
        }
        else{

            //If not then disable animations to save computing power
            animator.enabled = false;
        }
        //If we're dead
        if(animator.GetBool("Dead")){
            //And we havent already deleted our lower LOD
            if(LOD1Renderer != null){
                //Delete lower LOD
                Destroy(LOD1Renderer);
            }
        }
    }
}
