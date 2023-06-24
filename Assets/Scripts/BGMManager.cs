using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    [SerializeField]
    AudioClip _BGM_Title;
    [SerializeField]
    AudioClip _BGM_Tutorial;
    [SerializeField]
    AudioClip _BGM_Stage;

    private AudioSource _source;
    private string _beforeScene = "StageSelectScene";
    static private BGMManager _instance = null;

        // Start is called before the first frame update
        void Start()
    {
        //BGMが既にあるかを判定する
        if (_instance != null)
        {
            GameObject.Destroy(this);
            return;
        }

        _instance = this;
        _source = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
        //最初のBGM再生
        _source.clip = _BGM_Title;
        _source.Play();
        //シーンが切り替わった時に呼ばれるメソッドを登録
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    //シーンが切り替わった時に呼ばれるメソッド
    void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
    {
        //シーンがどう変わったかで判定

        //ステージ選択からチュートリアルへ
        if (_beforeScene == "StageSelectScene" && nextScene.name == "Stage_Tutorial")
        {
            _source.Stop();
            _source.clip = _BGM_Tutorial; //流すクリップを切り替える
            _source.Play();
        }

        //ステージ選択からステージへ
        if (_beforeScene == "StageSelectScene" && (nextScene.name == "Stage_1" || nextScene.name == "Stage_2" || nextScene.name == "Stage_3"))
        {
            _source.Stop();
            _source.clip = _BGM_Stage;    //流すクリップを切り替える
            _source.Play();
        }

        //ステージからタイトル、ステージ選択へ
        if ((_beforeScene == "Stage_Tutorial" || _beforeScene == "Stage_1" || _beforeScene == "Stage_2" || _beforeScene == "Stage_3") && (nextScene.name == "TitleScene" || nextScene.name == "StageSelectScene"))
        {
            _source.Stop();
            _source.clip = _BGM_Title;    //流すクリップを切り替える
            _source.Play();
        }

        //ステージからクリア画面へ
        if ((_beforeScene == "Stage_Tutorial" || _beforeScene == "Stage_1" || _beforeScene == "Stage_2" || _beforeScene == "Stage_3") && nextScene.name == "ClearScene")
        {
            _source.Stop();
        }

        //クリア画面からタイトル、ステージ選択へ
        if (_beforeScene == "ClearScene" && (nextScene.name == "TitleScene" || nextScene.name == "StageSelectScene"))
        {
            _source.clip = _BGM_Title; //流すクリップを切り替える
            _source.Play();
        }

        //遷移後のシーン名を「１つ前のシーン名」として保持
        _beforeScene = nextScene.name;
    }
}
