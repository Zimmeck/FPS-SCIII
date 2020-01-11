using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadSceneAsync(AppConstant.AppScenes.GAME_SCENE, LoadSceneMode.Additive);
        SceneManager.sceneLoaded += FinishLoading;
    }
    void FinishLoading(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= FinishLoading;
        Destroy(this.gameObject, 8f);
    }
}
