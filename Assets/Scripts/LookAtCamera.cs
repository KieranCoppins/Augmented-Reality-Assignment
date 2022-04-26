using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Pretty basic look at camera script - mainly for labels
public class LookAtCamera : MonoBehaviour
{

    public bool flipped;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (flipped){      
            transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
        }
        else{
            transform.LookAt(Camera.main.transform.position);
        }
    }
}
