using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    // 各ステージ用のBGM
    [SerializeField] AudioClip _BGM_Title;
    [SerializeField] AudioClip _BGM_Tutorial;
    [SerializeField] AudioClip _BGM_Stage;

    private AudioSource _source;
    static private BGMManager _instance = null;

    // シングルトンの設定
    private void Awake()
    {
        //BGMが既にあるかを判定する
        if (_instance == null)
        {
            // このオブジェクトはシーンをまたいでも消されない
            DontDestroyOnLoad(gameObject);
            _instance = this;
            // 最初のBGM再生
            _source = GetComponent<AudioSource>();
            _source.clip = _BGM_Title;
            _source.Play();
            // シーンが切り替わった時に呼ばれるメソッドを登録
            SceneManager.activeSceneChanged += OnActiveSceneChanged;
        }
        else
        {
            // 既にあるならDestroyする
            GameObject.Destroy(this);
        }

    }

    // シーンが切り替わった時に呼ばれるメソッド
    void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
    {
        // シーンがどう変わったかで判定

        // チュートリアルへ
        if (nextScene.name == "Stage_Tutorial")
        {
            _source.Stop();
            _source.clip = _BGM_Tutorial;   // 流すクリップを切り替える
            _source.Play();
        }

        // ステージへ
        if (nextScene.name == "Stage_1" || nextScene.name == "Stage_2" || nextScene.name == "Stage_3")
        {
            _source.Stop();
            _source.clip = _BGM_Stage;  // 流すクリップを切り替える
            _source.Play();
        }

        // タイトル、ステージ選択へ
        if (nextScene.name == "TitleScene" || nextScene.name == "StageSelectScene")
        {
            _source.Stop();
            _source.clip = _BGM_Title;  // 流すクリップを切り替える
            _source.Play();
        }

        // クリア画面へ
        if (nextScene.name == "ClearScene")
        {
            _source.Stop();
        }

    }
}
