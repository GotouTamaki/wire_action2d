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
        //BGM�����ɂ��邩�𔻒肷��
        if (_instance != null)
        {
            GameObject.Destroy(this);
            return;
        }

        _instance = this;
        _source = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
        //�ŏ���BGM�Đ�
        _source.clip = _BGM_Title;
        _source.Play();
        //�V�[�����؂�ւ�������ɌĂ΂�郁�\�b�h��o�^
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    //�V�[�����؂�ւ�������ɌĂ΂�郁�\�b�h
    void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
    {
        //�V�[�����ǂ��ς�������Ŕ���

        //�X�e�[�W�I������`���[�g���A����
        if (_beforeScene == "StageSelectScene" && nextScene.name == "Stage_Tutorial")
        {
            _source.Stop();
            _source.clip = _BGM_Tutorial; //�����N���b�v��؂�ւ���
            _source.Play();
        }

        //�X�e�[�W�I������X�e�[�W��
        if (_beforeScene == "StageSelectScene" && (nextScene.name == "Stage_1" || nextScene.name == "Stage_2" || nextScene.name == "Stage_3"))
        {
            _source.Stop();
            _source.clip = _BGM_Stage;    //�����N���b�v��؂�ւ���
            _source.Play();
        }

        //�X�e�[�W����^�C�g���A�X�e�[�W�I����
        if ((_beforeScene == "Stage_Tutorial" || _beforeScene == "Stage_1" || _beforeScene == "Stage_2" || _beforeScene == "Stage_3") && (nextScene.name == "TitleScene" || nextScene.name == "StageSelectScene"))
        {
            _source.Stop();
            _source.clip = _BGM_Title;    //�����N���b�v��؂�ւ���
            _source.Play();
        }

        //�X�e�[�W����N���A��ʂ�
        if ((_beforeScene == "Stage_Tutorial" || _beforeScene == "Stage_1" || _beforeScene == "Stage_2" || _beforeScene == "Stage_3") && nextScene.name == "ClearScene")
        {
            _source.Stop();
        }

        //�N���A��ʂ���^�C�g���A�X�e�[�W�I����
        if (_beforeScene == "ClearScene" && (nextScene.name == "TitleScene" || nextScene.name == "StageSelectScene"))
        {
            _source.clip = _BGM_Title; //�����N���b�v��؂�ւ���
            _source.Play();
        }

        //�J�ڌ�̃V�[�������u�P�O�̃V�[�����v�Ƃ��ĕێ�
        _beforeScene = nextScene.name;
    }
}
