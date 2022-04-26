using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Loads different UI elements for the main menu
public class EventManager : MonoBehaviour
{
    public GameObject mainScreen;
    public GameObject levelSelectScreen;
    public GameObject aboutScreen;

    GameObject  currentScreen;
    // Start is called before the first frame update
    void Start()
    {
        //Default our current screen to the main screen
        currentScreen  = mainScreen;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Load the about screen
    public void LoadScreen_AboutScreen(){
        mainScreen.SetActive(false);
        aboutScreen.SetActive(true);
        currentScreen = aboutScreen;
    }

    //Load the level selection screen
    public void LoadScreen_LevelSelection()
    {
        mainScreen.SetActive(false);
        levelSelectScreen.SetActive(true);
        currentScreen = levelSelectScreen;
    }

    //Load the main menu screen
    public void LoadScreen_MainScreen(){
        mainScreen.SetActive(true);
        currentScreen.SetActive(false);
    }

    //Quit the application
    public void Quit(){
        Application.Quit();
    }

    //Load a scene by scene int
    public void LoadScene(int scene){
        SceneManager.LoadScene(scene);
    }
}
