using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessegeWindowManager : MonoBehaviour
{
    // �e�L�X�g��\������
    [SerializeField] Text _messegeWindow = null;
    [SerializeField] GameObject _target = null;
    // �\�������郁�b�Z�[�W�ƃJ�[�\���Ƃ̋���
    [SerializeField] float _onMessegeDistance = 1;

    float distance = 0;

    // Start is called before the first frame update
    void Start()
    {
        // �ŏ��͕\�����Ȃ�
        _messegeWindow.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // �������v�Z����
        distance = Vector2.Distance(this.transform.position, _target.transform.position);

        // �����ŕ\�������邩�����߂�
        if (distance < _onMessegeDistance) 
        {
            _messegeWindow.enabled = true;
        }
        else
        {
            _messegeWindow.enabled = false;
        }
    }
}
