using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    // �e�X�e�[�W�p��BGM
    [SerializeField] AudioClip _BGM_Title;
    [SerializeField] AudioClip _BGM_Tutorial;
    [SerializeField] AudioClip _BGM_Stage;

    private AudioSource _source;
    static private BGMManager _instance = null;

    // �V���O���g���̐ݒ�
    private void Awake()
    {
        //BGM�����ɂ��邩�𔻒肷��
        if (_instance == null)
        {
            // ���̃I�u�W�F�N�g�̓V�[�����܂����ł�������Ȃ�
            DontDestroyOnLoad(gameObject);
            _instance = this;
            // �ŏ���BGM�Đ�
            _source = GetComponent<AudioSource>();
            _source.clip = _BGM_Title;
            _source.Play();
            // �V�[�����؂�ւ�������ɌĂ΂�郁�\�b�h��o�^
            SceneManager.activeSceneChanged += OnActiveSceneChanged;
        }
        else
        {
            // ���ɂ���Ȃ�Destroy����
            GameObject.Destroy(this);
        }

    }

    // �V�[�����؂�ւ�������ɌĂ΂�郁�\�b�h
    void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
    {
        // �V�[�����ǂ��ς�������Ŕ���

        // �`���[�g���A����
        if (nextScene.name == "Stage_Tutorial")
        {
            _source.Stop();
            _source.clip = _BGM_Tutorial;   // �����N���b�v��؂�ւ���
            _source.Play();
        }

        // �X�e�[�W��
        if (nextScene.name == "Stage_1" || nextScene.name == "Stage_2" || nextScene.name == "Stage_3")
        {
            _source.Stop();
            _source.clip = _BGM_Stage;  // �����N���b�v��؂�ւ���
            _source.Play();
        }

        // �^�C�g���A�X�e�[�W�I����
        if (nextScene.name == "TitleScene" || nextScene.name == "StageSelectScene")
        {
            _source.Stop();
            _source.clip = _BGM_Title;  // �����N���b�v��؂�ւ���
            _source.Play();
        }

        // �N���A��ʂ�
        if (nextScene.name == "ClearScene")
        {
            _source.Stop();
        }

    }
}
