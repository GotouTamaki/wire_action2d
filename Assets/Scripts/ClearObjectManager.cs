using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;

public class ClearObjectManager : MonoBehaviour
{
    static string _sceneName = null;

    // Start is called before the first frame update
    void Start()
    {
        _sceneName = SceneManager.GetActiveScene().name;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerUIManager.Result();
            BestTimeManager.BestTime();
            SceneManager.LoadScene("ClearScene");
        }
    }

    public static string GetSceneName()
    {
        return _sceneName;
    }
}
