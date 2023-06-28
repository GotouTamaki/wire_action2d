using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestTimeManager : MonoBehaviour
{
    static float _bestTime1 = 9999.99f;
    static float _bestTime2 = 9999.99f;
    static float _bestTime3 = 9999.99f;
    static float _bestTimeT = 9999.99f;

    public static void BestTime()
    {
        if (ClearObjectManager.GetSceneName() == "Stage_Tutorial")
        {
            if (_bestTimeT > PlayerUIManager._clearTime)
            {
                _bestTimeT = PlayerUIManager._clearTime;
            }
        }
        else if (ClearObjectManager.GetSceneName() == "Stage_1")
        {
            if (_bestTime1 > PlayerUIManager._clearTime)
            {
                _bestTime1 = PlayerUIManager._clearTime;
            }
        }
        else if (ClearObjectManager.GetSceneName() == "Stage_2")
        {
            if (_bestTime2 > PlayerUIManager._clearTime)
            {
                _bestTime2 = PlayerUIManager._clearTime;
            }
        }
        else if (ClearObjectManager.GetSceneName() == "Stage_3")
        {
            if (_bestTime3 > PlayerUIManager._clearTime)
            {
                _bestTime3 = PlayerUIManager._clearTime;
            }
        }
    }

    public static float GetBestTimeT()
    {
        return _bestTimeT;
    }

    public static float GetBestTime1()
    {
        return _bestTime1;
    }

    public static float GetBestTime2()
    {
        return _bestTime2;
    }

    public static float GetBestTime3()
    {
        return _bestTime3;
    }
}
