using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BestTimeManager : MonoBehaviour
{
    public static BestTimeManager _instance;
    // �x�X�g�^�C���p��Dictionary
    public Dictionary<string, float> _bestTime = new Dictionary<string, float>();

    // �V���O���g���̐ݒ�
    void Awake()
    {
        //BestTimeManager�����ɂ��邩�𔻒肷��
        if (_instance == null)
        {
            // ���̃I�u�W�F�N�g�̓V�[�����܂����ł�������Ȃ�
            DontDestroyOnLoad(gameObject);
            _instance = this;
            SceneManager.sceneLoaded += SceneLoaded;
        }
        else 
        {
            // ���ɂ���Ȃ�Destroy����
            GameObject.Destroy(this);
        }

    }

    // �V�[�����ǂݍ��܂ꂽ���Ɉړ���̃V�[���̖��O�ƃx�X�g�^�C���̏����l��Dictionary�ɒǉ�����
    void SceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        if (!_bestTime.ContainsKey(nextScene.name) && nextScene.name.Contains("Stage"))
        {
            _bestTime.Add(nextScene.name, 9999.99f);
        }         
    }
}
