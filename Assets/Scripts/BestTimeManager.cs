using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BestTimeManager : MonoBehaviour
{
    public static BestTimeManager _instance;
    // ベストタイム用のDictionary
    public Dictionary<string, float> _bestTime = new Dictionary<string, float>();

    // シングルトンの設定
    void Awake()
    {
        //BestTimeManagerが既にあるかを判定する
        if (_instance == null)
        {
            // このオブジェクトはシーンをまたいでも消されない
            DontDestroyOnLoad(gameObject);
            _instance = this;
            SceneManager.sceneLoaded += SceneLoaded;
        }
        else 
        {
            // 既にあるならDestroyする
            GameObject.Destroy(this);
        }

    }

    // シーンが読み込まれた時に移動先のシーンの名前とベストタイムの初期値をDictionaryに追加する
    void SceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        if (!_bestTime.ContainsKey(nextScene.name) && nextScene.name.Contains("Stage"))
        {
            _bestTime.Add(nextScene.name, 9999.99f);
        }         
    }
}
