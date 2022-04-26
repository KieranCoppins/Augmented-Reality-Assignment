using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Serializable class top store waypoints, labels and function names for each stage
[System.Serializable]
public class Stage
{
    public GameObject[] Waypoints;
    public GameObject[] Labels;
    public string[] functionNames;
}
