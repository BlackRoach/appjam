using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadingScript : MonoBehaviour
{

    bool IsDone = false;
    float fTime = 0f;
    int m_chapternum;
    int m_istomain;
    AsyncOperation async_operation;

    void Start()
    {
        m_chapternum = PlayerPrefs.GetInt("StageNum");
        m_istomain = PlayerPrefs.GetInt("istomain");
        if (m_istomain == 0)  // 게임씬
            StartCoroutine(StartLoad("MainScene"));
        else if (m_istomain == 1) // 메인으로
            StartCoroutine(StartLoad("TitleScene"));
    }

    void Update()
    {
        fTime += Time.deltaTime;

        if (fTime >= 2)
        {
            async_operation.allowSceneActivation = true;
        }
    }

    public IEnumerator StartLoad(string strSceneName)
    {
       
        async_operation = SceneManager.LoadSceneAsync(strSceneName); 
       
        async_operation.allowSceneActivation = false;

        if (IsDone == false)
        {
            IsDone = true;

            while (async_operation.progress < 0.9f)
            {
                yield return true;
            }
        }
    }


}
