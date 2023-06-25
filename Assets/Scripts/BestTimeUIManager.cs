using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestTimeUIManager : MonoBehaviour
{
    [SerializeField]  Text _bestTimeText = null;
    [SerializeField] Stagename _stageName;

    // Start is called before the first frame update
    void Start()
    {
        if (_bestTimeText != null)
        {
            if (_stageName == Stagename.StageTutorial)
            {
                StageTutorial();
            }
            else if (_stageName == Stagename.Stage1)
            {
                Stage1();
            }
            else if (_stageName == Stagename.Stage2)
            {
                Stage2();
            }
            else if (_stageName == Stagename.Stage3)
            {
                Stage3();
            }
        }       
    }

    enum Stagename
    {
        StageTutorial,
        Stage1,
        Stage2,
        Stage3,
    }

    void StageTutorial()
    {
        _bestTimeText.text = BestTimeManager._bestTimeT.ToString("F2");
    }

    void Stage1()
    {
        _bestTimeText.text = BestTimeManager._bestTime1.ToString("F2");
    }

    void Stage2()
    {
        _bestTimeText.text = BestTimeManager._bestTime2.ToString("F2");
    }

    void Stage3()
    {
        _bestTimeText.text = BestTimeManager._bestTime3.ToString("F2");
    }
}
