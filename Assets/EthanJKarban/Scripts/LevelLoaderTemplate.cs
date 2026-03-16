using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderTemplate : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;


    public void LoadLevelByName(string sceneName)
    {
        StartCoroutine(LoadLevel(sceneName)); //Picks what level is next on the scenemanagement list
    }

    IEnumerator LoadLevel(string sceneName)
    {
        transition.SetTrigger("Start"); // Sets the animation trigger "start" to play scene transition

        yield return new WaitForSeconds(transitionTime); // The Couroutine

        SceneManager.LoadScene(sceneName); // Omg, it's loading the next scene. 
    }
}
