using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestTimeUIManager : MonoBehaviour
{
    // テキストにベストタイムを記録する
    [SerializeField] Text _bestTimeText = null;
    [SerializeField] StageName _stageName;

    // Start is called before the first frame update
    void Start()
    {
        // 表示するタイムを切り替える
        if (_bestTimeText != null)
        {
            if (_stageName == StageName.StageTutorial)
            {
                StageTutorial();
            }
            else if (_stageName == StageName.Stage1)
            {
                Stage1();
            }
            else if (_stageName == StageName.Stage2)
            {
                Stage2();
            }
            else if (_stageName == StageName.Stage3)
            {
                Stage3();
            }
        }       
    }

    enum StageName
    {
        StageTutorial,
        Stage1,
        Stage2,
        Stage3,
    }

    void StageTutorial()
    {
        _bestTimeText.text = BestTimeManager.GetBestTimeT().ToString("F2");
    }

    void Stage1()
    {
        _bestTimeText.text = BestTimeManager.GetBestTime1().ToString("F2");
    }

    void Stage2()
    {
        _bestTimeText.text = BestTimeManager.GetBestTime2().ToString("F2");
    }

    void Stage3()
    {
        _bestTimeText.text = BestTimeManager.GetBestTime3().ToString("F2");
    }
}
