using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//used for spawning the item at button press
public class SpawnObject : MonoBehaviour
{
    public GameObject LocationObject;

    GameObject go;

    private void Update() {
        //Get the location object
        if (LocationObject == null && GameObject.FindGameObjectWithTag("Teutoberg") != null){
            LocationObject = GameObject.FindGameObjectWithTag("Teutoberg");
        }
    }
    //On button press call this
    public void Spawn(GameObject SpawnObject){
        //As long as the item doesnt already exist, spawn it (removes duplicates)
        if(go == null){
            go = Instantiate(SpawnObject, LocationObject.transform.position, LocationObject.transform.rotation);
        }
        //If it does already exist, then move and rotate to new location
        else{
            go.transform.position = LocationObject.transform.position;
            //Only rotate in the Y axis to keep the scene flat and level
            go.transform.Rotate(new Vector3(0, LocationObject.transform.rotation.y, 0));
        }
        //Scale location - stopped working with scale interactable script
        go.transform.localScale = LocationObject.transform.lossyScale;
    }

    //Delete function was added to remove the object, didnt end up using it
    public void Delete(string tag){
        GameObject deleteObject = GameObject.FindGameObjectWithTag(tag);
        if (deleteObject != null){
            Destroy(deleteObject);
        }
    }
}
