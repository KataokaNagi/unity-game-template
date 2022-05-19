
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScenesLoader : MonoBehaviour
{
    [SerializeField] Text loadProgress;
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject loadingView;

    //�e�V�[�����ƂɕK�v�ȃV�[����錾���Ă���
    public static List<string> TitleScenesNames = new List<string> { "GameManager", "Title", "Load", "Option" };
    public static List<string> Stage1ScenesNames = new List<string> { "GameManager", "Room1-2", "Load", "Option", "Stage1", "Gameover", "CutScene1" };
    public static List<string> Stage2ScenesNames = new List<string> { "GameManager", "Room1-2", "Load", "Option", "Stage2", "Result", "Gameover", "CutScene2" };
    public static List<string> Stage3ScenesNames = new List<string> { "GameManager", "Room3", "Load", "Option", "Stage3", "Result", "Gameover", "CutScene3" };
    public static List<string> CreditScenesNames = new List<string> { "GameManager", "Credit", "Load", "Option" };

    private void Start()
    {
        loadingView.SetActive(false);
        StartCoroutine(AsyncLoadScenes(TitleScenesNames));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="nextScenes">Scenes Name List of ScenesLoader.cs</param>
    /// <returns></returns>
    public List<AsyncOperation> LoadAndUnloadScenes(List<string> nextScenes)
    {
        List<string> currentScenes = new List<string>();
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            string currentSceneName = SceneManager.GetSceneAt(i).name;
            currentScenes.Add(currentSceneName);
        }

        var loadScenes = nextScenes.Except(currentScenes).ToList();
        var unloadScenes = currentScenes.Except(nextScenes).ToList();

        List<AsyncOperation> asyncScenes = new List<AsyncOperation>();
        List<AsyncOperation> asyncProcess = new List<AsyncOperation>();

        foreach (string sceneName in loadScenes)
        {
            //Debug.Log(sceneName + " is load scene");
            var asyncScene = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);//�񓯊��ŃV�[����ǂݍ���
            asyncScene.allowSceneActivation = false;
            asyncScenes.Add(asyncScene);
            asyncProcess.Add(asyncScene);
        }

        foreach (string sceneName in unloadScenes)
        {
            //Debug.Log(sceneName + " is unload scene");
            var asyncScene = SceneManager.UnloadSceneAsync(sceneName);//�񓯊��ŃV�[��������
            asyncProcess.Add(asyncScene);
        }
        // TODO: To no async.
        UnloadUnusedAssets();

        return asyncScenes; //�ǂݍ��ݏI�����V�[����Ԃ�
    }

    private IEnumerator AsyncLoadScenes(List<string> nextScenes)
    {
        gameManager.isLoading = true;
        loadingView.SetActive(true);
        var loadScenes = LoadAndUnloadScenes(nextScenes);

        yield return new WaitForSeconds(1);

        foreach (AsyncOperation async in loadScenes)
        {
            async.allowSceneActivation = true;
        }
        gameManager.isLoading = false;
        loadingView.SetActive(false);
    }

    /// <summary>
    /// @author     Kataoka
    /// @date       2022-05-06 00:54:58
    /// @attention  This takes lots of times.
    /// </summary>
    private void UnloadUnusedAssets()
    {
        StartCoroutine(CoUnloadUnusedAssets());
    }

    /// <summary>
    /// @author     Kataoka
    /// @date       2022-05-06 00:54:58
    /// </summary>
    private IEnumerator CoUnloadUnusedAssets()
    {
        yield return Resources.UnloadUnusedAssets();
    }
}
