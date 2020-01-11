using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MenuCanvasController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
        


    }

    // Update is called once per frame
    void Update()
    {
        


    }
    public void Menu()
    {

        SceneManager.LoadScene(AppConstant.AppScenes.MAIN_SCENE);

    }

    public void StartGame()
    {

        SceneManager.LoadScene(AppConstant.AppScenes.GAME_SCENE);

    }
    public void LoadingGame()
    {

        SceneManager.LoadScene(AppConstant.AppScenes.LOADING_SCENE);

    }
  
    public void OptionsGame()
    {

        SceneManager.LoadScene(AppConstant.AppScenes.OPTIONS_SCENE);

    }

    public void Quit()
    {

        Application.Quit();

    }
}
