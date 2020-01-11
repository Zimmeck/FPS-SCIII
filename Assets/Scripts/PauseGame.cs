using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{

    public bool GameIsPuased = false;

    public GameObject pauseMenuUI;

  

    // Start is called before the first frame update
    void Start()
    {

        

    }

    // Update is called once per frame
    void Update()

    {

   
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (GameIsPuased)
            {
                Return();
               
            } else
            {
                Pause();
            }

        }
    }

    public void Return()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPuased = false;
        
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPuased = true;

        Cursor.visible = (true);


    }
   public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;

    }
    public void QUIT ()
    {
        Application.Quit();
    }
    private void OnEnable()
    {
        Cursor.visible = (true);
    }



}
