using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventsManager : MonoBehaviour
{



    public IEnumerator WaitTime(List<string> sceneNames)
    {
        // TODO
        yield return new WaitForSeconds(1);
    }
}
