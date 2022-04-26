using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using TMPro;

//Script from workshop 3
public class ObjectManager : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public GameObject placeableObject;
    public TextMeshProUGUI text;

    public EventSystem eventSystem;

    GameObject selectedObject;
    bool isOverUI = false;

    // Update is called once per frame
    void Update()
    {
        //If we're touching our screen at all
        if (Input.touchCount > 0){
            //Get the touch input of the first finger detected
            var touch = Input.GetTouch(0);
            //If we just began our touch
            if (touch.phase == TouchPhase.Began)
            {
                //Check if our finger is over a UI element - if so just return
                isOverUI = EventSystem.current.IsPointerOverGameObject(touch.fingerId);
            }
            //If we have ended our touch
            if (touch.phase == TouchPhase.Ended){ 
                //And if we only touched the screen with 1 finger
                if (Input.touchCount == 1)
                {
                    if (isOverUI)
                    {
                        return;
                    }
                    //Get a ray position from where our finger was
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    //Cast an object raycast to check if we touched a placeable object - make this our selected object
                    if (Physics.Raycast(ray, out RaycastHit hit))
                    {
                        if (hit.collider.tag == "Placeable"){
                            selectedObject = hit.transform.gameObject;
                            return;
                        }
                    }
                    //Use the AR raycast manager to generate a raycast on our plane
                    List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();
                    if (raycastManager.Raycast(touch.position, raycastHits, UnityEngine.XR.ARSubsystems.TrackableType.Planes))
                    {
                        var pose = raycastHits[0].pose;
                        //Create our placeable object at the position of our touch
                        Instantiate(placeableObject, pose.position, pose.rotation);
                        return;
                    }
                }
            }
        }
    }

    //Change our placeable object to go
    public void ChangePlaceableObject(GameObject go)
    {
        placeableObject = go;
        text.text = "Current Selection: " + placeableObject.name;
    }

    //Destroy our currently selected gameobject
    public void DeleteSelection()
    {
        if (selectedObject != null)
        {
            Destroy(selectedObject);
        }
    }
}
