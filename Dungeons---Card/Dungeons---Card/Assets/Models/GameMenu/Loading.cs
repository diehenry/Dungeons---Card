using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Loading : MonoBehaviour {

    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;
    public void LoadLevel()
    {
        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync("GameMap");
        loadingScreen.SetActive(true);
        while(!op.isDone)
        {
            float progress = Mathf.Clamp01(op.progress / .9f);
            slider.value = progress;
            progressText.text = progress * 100f +"%" ;
            yield return null;
        }
    }
}
