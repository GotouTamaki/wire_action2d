using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BestTimeManager : MonoBehaviour
{
    public static float _bestTime1 = 9999.99f;
    public static float _bestTime2 = 9999.99f;
    public static float _bestTime3 = 9999.99f;
    public static float _bestTimeT = 9999.99f;

    // Start is called before the first frame update
    public static void BestTime()
    {
        if (ClearObjectManager._sceneName == "Stage_Tutorial")
        {
            if (_bestTimeT > PlayerUIManager._clearTime)
            {
                    _bestTimeT = PlayerUIManager._clearTime;
            }
        }
        else if (ClearObjectManager._sceneName == "Stage_1")
        {
            if (_bestTime1 > PlayerUIManager._clearTime)
            {
                _bestTime1 = PlayerUIManager._clearTime;
            }
        }
        else if (ClearObjectManager._sceneName == "Stage_2")
        {
            if (_bestTime2 > PlayerUIManager._clearTime)
            {
                _bestTime2 = PlayerUIManager._clearTime;
            }
        }
        else if (ClearObjectManager._sceneName == "Stage_3")
        {
            if (_bestTime3 > PlayerUIManager._clearTime)
            {
                _bestTime3 = PlayerUIManager._clearTime;
            }
        }
    } 
}
