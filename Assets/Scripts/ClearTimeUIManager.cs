using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearTimeUIManager : MonoBehaviour
{
    [SerializeField] Text _clearTimeUI = default;

    // Start is called before the first frame update
    void Start()
    {
        // �N���A�^�C����\������
        _clearTimeUI.text = PlayerUIManager._clearTime.ToString("F2");
    }
}
