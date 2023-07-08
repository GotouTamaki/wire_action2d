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
            TimerManager.Result();

            // ベストタイムかを判定、記録する
            if (BestTimeManager._instance._bestTime[_sceneName] > TimerManager._clearTime )
            {
                BestTimeManager._instance._bestTime[_sceneName] = TimerManager._clearTime;
            }

            // クリアシーンへ移動
            SceneManager.LoadScene("ClearScene");
        }
    }
}
