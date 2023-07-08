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
        // ���̃I�u�W�F�N�g������V�[�����擾����
        _sceneName = SceneManager.GetActiveScene().name;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // �N���A�^�C�����L�^
            TimerManager.Result();

            // �x�X�g�^�C�����𔻒�A�L�^����
            if (BestTimeManager._instance._bestTime[_sceneName] > TimerManager._clearTime )
            {
                BestTimeManager._instance._bestTime[_sceneName] = TimerManager._clearTime;
            }

            // �N���A�V�[���ֈړ�
            SceneManager.LoadScene("ClearScene");
        }
    }
}
