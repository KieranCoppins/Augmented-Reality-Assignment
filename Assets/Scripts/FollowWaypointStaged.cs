using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypointStaged : MonoBehaviour
{
    public Stage[] Stages;
    public float speed;
    int currentStage = 0;
    int currentWaypointIndex = 0;
    GameObject currentWaypoint;
    bool move = false;

    public int killPercentage;

    List <Animator> animators;

    private void Start() {
        FollowWaypoint(Stages[currentStage].Waypoints);
        animators = new List<Animator>();
        foreach (Transform soldier in transform){
            animators.Add(soldier.GetComponent<Animator>());
        }
    }

    //Start the next stage
    public void NextStage(){
        //IOf we're moving mid stage or the current stage is out of range, just return
        if (move || currentStage >= Stages.Length){
            return;
        }
        //If we on stage 1 or over, then we need to disable any labels in the previous stage
        if (currentStage > 0){
            foreach(GameObject currLabel in Stages[currentStage-1].Labels){
                currLabel.SetActive(false);
            }
        }
        //Activate all labels in the current stage
        foreach(GameObject currLabel in Stages[currentStage].Labels){
            currLabel.SetActive(true);
        }

        //Call any functions for this stage
        foreach (string function in Stages[currentStage].functionNames)
        {
            this.gameObject.SendMessage(function);
        }
        //Follow the waypoints for this stage
        FollowWaypoint(Stages[currentStage].Waypoints);
    }

    private void FollowWaypoint(GameObject[] waypoints){
        //set move to say we're currently moving in the current stage
        move = true;
        //Load the current waypoints from the stage
        currentWaypoint = waypoints[currentWaypointIndex];
    }

    //Fixed update incase of fps issues (I have optimised with LOD & animation disabling which worked for me)
    private void FixedUpdate()
    {
        //Set walking to move variable becuase we're about to move to our waypoint
        //True means we're about to go to a waypoint
        foreach (Animator soldierAnimator in animators)
        {
            soldierAnimator.SetBool("Walking", move);
        }
        //If we are moving
        if(move){
            //Move towards the next waypoint
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.transform.position, speed * Time.deltaTime);

            //If we have reached the waypoint
            if (Vector3.Distance(transform.position, currentWaypoint.transform.position) < 0.001){
                //Stop moving
                move = false;
                //Increment waypoint
                currentWaypointIndex++;
                //If waypoint is out of range
                if (currentWaypointIndex == Stages[currentStage].Waypoints.Length){
                    //Reset waypoint index and increment stage
                    currentStage++;
                    currentWaypointIndex = 0;
                }
                else{    
                    //Otherwise follow the waypoint
                    FollowWaypoint(Stages[currentStage].Waypoints);
                }
            }
        }
    }

    //Kill a percentage of the legion
    public void Kill(){
        //Get each animator
        foreach (Animator soldierAnimator in animators)
        {
            //Generate random chance
            int killChance = Random.Range(0, 10);
            //Kill a percentage of the soldiers
            if (killChance < killPercentage){
                //Play animations and disconnect from parent so they die in place
                soldierAnimator.SetBool("Dead", true);
                soldierAnimator.transform.parent = transform.parent;
            }
        }
    }

    //Same as kill but just to each soldier
    public void KillAll(){
        foreach (Animator soldierAnimator in animators)
        {
            soldierAnimator.SetBool("Dead", true);
            soldierAnimator.transform.parent = transform.parent;
            
        }
    }
}
