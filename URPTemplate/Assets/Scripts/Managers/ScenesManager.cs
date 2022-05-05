using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator AsyncLoadScenes(List<string> sceneNames)
    {
        // TODO
        yield return new WaitForSeconds(1);
    }

    /// <summary>
    /// @author     Kataoka
    /// @date       2022-05-06 00:54:58
    /// </summary>
    public void UnloadScene(string sceneName)
    {
        StartCoroutine(CoUnloadScene(sceneName));
    }

    /// <summary>
    /// @author     Kataoka
    /// @date       2022-05-06 00:54:58
    /// </summary>
    private IEnumerator CoUnloadScene(string sceneName)
    {
        AsyncOperation op = SceneManager.UnloadSceneAsync(sceneName);
        yield return op;
    }

    /// <summary>
    /// @author     Kataoka
    /// @date       2022-05-06 00:54:58
    /// @attention  This takes lots of times.
    /// </summary>
    public void UnloadUnusedAssets()
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
