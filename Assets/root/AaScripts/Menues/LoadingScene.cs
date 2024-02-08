using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadingScene : MonoBehaviour
{
    [SerializeField] GameObject loadScreen;
    [SerializeField] Image loadingBarFill;
    public void LoadScene(int scene)
    {
        StartCoroutine(LoadSceneAsync(scene));
    }


    IEnumerator LoadSceneAsync(int Scene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(Scene);

        loadScreen.SetActive(true);

        while (!operation.isDone)
        {

            float proggres = Mathf.Clamp01(operation.progress / 0.9f);
            
            loadingBarFill.fillAmount = proggres;
            if(proggres >= 0.5)
            {
                Debug.Log("JSAKODJHDPOSAHJN");
                 //AudioManager.Instance.MainMenuIntoLevel();
            }
            yield return null;

        }
        Debug.Log("HGOLA");
        
    }
}
