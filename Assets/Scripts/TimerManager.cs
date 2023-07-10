using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    // 経過時間を表示するオブジェクト
    [SerializeField] Text _timer = default;

    public static float _clearTime = 9999.99f;
    static float _time = 0;

    // Start is called before the first frame update
    void Start()
    {
        _time = 0.0f;
        _timer.text = "0.00"; 
    }

    // Update is called once per frame
    void Update()
    {
        // 最大値になるまでタイムを計測する
        if (_time < 9999.99f)
        {
            _time += Time.deltaTime;
        }

        // TimeText にプレイ時間を表示する
        _timer.text = _time.ToString("F2");
    }

    // クリアタイムを記録する
    public static void Result()
    {
        _clearTime = _time;
    }
}
