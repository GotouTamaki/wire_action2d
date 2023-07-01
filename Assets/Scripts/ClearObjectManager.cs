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
        // このオブジェクトがあるシーンを取得する
        _sceneName = SceneManager.GetActiveScene().name;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // クリアタイムを記録
            PlayerUIManager.Result();
            // ベストタイムかを判定、記録する
            BestTimeManager.BestTime();
            // リザルトへ移動
            SceneManager.LoadScene("ClearScene");
        }
    }

    public static string GetSceneName()
    {
        // クリアしたシーンを呼び出せるようにする
        return _sceneName;
    }
}
