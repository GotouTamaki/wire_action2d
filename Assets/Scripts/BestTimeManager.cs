using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BestTimeManager : MonoBehaviour
{
    public static Text _bestTimeText = default;
    public static float _bestTime = 9999.99f;
    public static string _beforeScene = "Default";
    public static float _bestTime1 = 9999.99f;
    public static float _bestTime2 = 9999.99f;
    public static float _bestTime3 = 9999.99f;
    public static float _bestTimeT = 9999.99f;

    // Start is called before the first frame update
    void Start()
    {
        _beforeScene = SceneManager.GetActiveScene().name;
        _bestTimeText.text = _bestTime.ToString("F2");
    } 
    
    void BestTime()
    {
        if (_bestTime > PlayerUIManager._clearTime)
        {
            _bestTime = PlayerUIManager._clearTime;
        }

        switch (_beforeScene)
        {
            case "Stage_Tutorial":
                _bestTimeT = _bestTime;
                break;
            case "Stage_1":
                _bestTime1 = _bestTime;
                break;
            case "Stage_2":
                _bestTime2 = _bestTime;
                break;
            case "Stage_3":
                _bestTime3 = _bestTime;
                break;
        }    
    }

    void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
    {
        //遷移後のシーン名を「１つ前のシーン名」として保持
        _beforeScene = nextScene.name;
    }
}
