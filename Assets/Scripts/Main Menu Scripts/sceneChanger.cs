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
    public GameObject fadeINandOUTTransition; //Reference the FADE IN AND OUT Game Object

    [Header("GAME OBJECT")]
    public GameObject HomeUI; //Reference the HOME UI SCREEN Game Object

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

    //SCENE START TO MAIN MENU
    public void startBtn()
    {
        fadeOUTTransition.SetActive(false);
        StartCoroutine(startScreen(1));

    }

    IEnumerator startScreen(float duration)
    {
        fadeOUTTransition.SetActive(true);

        yield return new WaitForSeconds(duration);

        HomeUI.SetActive(true);
    }

#endregion
}
