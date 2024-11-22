using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChanger : MonoBehaviour
{
#region Fields and Properties

    [Header("TRANSITION")]
    //GAME OBJECT
    public GameObject fadeINTransition; //Reference the FADE IN Game Object
    public GameObject fadeOUTTransition; //Reference the FADE OUT Game Object
    public GameObject fadeINAndOUTTransition; //Reference the FADE IN AND OUT Game Object

    [Header("GAME OBJECT")]
    public GameObject HomeUI; //Reference the HOME UI SCREEN Game Object
    public GameObject ScreenUI; //Reference the SCREEN UI SCREEN Game Object

#endregion

#region Methods
    //SCENE SWITCH TO GAME
    public void gameScene()
    {
        SceneManager.LoadSceneAsync("scn TOWN");
    }

    //SCENE SWITCH TO MAIN MENU
    public void menuScene()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }

    //SCENE QUIT APPLICATION
    public void quitGame()
    {
        Application.Quit();
    }

    //SCENE START UI TO HOME UI
    public void startBtn()
    {
        
        StartCoroutine(startScreen(2));

    }

    //SCENE HOME UI TO GAME
    public void playBtn()
    {
        fadeINTransition.SetActive(true);
        Invoke("gameScene", 2);
    }

#endregion

#region Transition Anim
    IEnumerator startScreen(float duration) //This is for SCREEN UI to HOME UI
    {

        fadeINAndOUTTransition.SetActive(true);

        yield return new WaitForSeconds(duration);

        fadeINAndOUTTransition.SetActive(false);

        ScreenUI.SetActive(false);

        HomeUI.SetActive(true);
    }

#endregion
}
