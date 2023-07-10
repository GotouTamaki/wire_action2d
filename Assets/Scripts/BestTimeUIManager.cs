using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestTimeUIManager : BestTimeManager
{
    [SerializeField] StageName _stageName;

    Text _bestTimeText = null;

    // Start is called before the first frame update
    void Start()
    {
        _bestTimeText = GetComponent<Text>();

        // �\������^�C����؂�ւ���
        if (_bestTimeText != null)
        {
            // �e�L�X�g�Ƀx�X�g�^�C����\������
            if (_instance._bestTime.ContainsKey(_stageName.ToString()))
            {
                _bestTimeText.text = _instance._bestTime[_stageName.ToString()].ToString("F2");
            }           
        }       
    }

    enum StageName
    {
        // �X�e�[�W�̖��O�Ɗ��S�Ɉ�v���ĂȂ��Ƃ����Ȃ�
        Stage_Tutorial,
        Stage_1,
        Stage_2,
        Stage_3,
    }
}
