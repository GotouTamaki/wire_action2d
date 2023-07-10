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

        // 表示するタイムを切り替える
        if (_bestTimeText != null)
        {
            // テキストにベストタイムを表示する
            if (_instance._bestTime.ContainsKey(_stageName.ToString()))
            {
                _bestTimeText.text = _instance._bestTime[_stageName.ToString()].ToString("F2");
            }           
        }       
    }

    enum StageName
    {
        // ステージの名前と完全に一致してないといけない
        Stage_Tutorial,
        Stage_1,
        Stage_2,
        Stage_3,
    }
}
