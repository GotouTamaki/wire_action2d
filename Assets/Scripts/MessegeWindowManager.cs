using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessegeWindowManager : MonoBehaviour
{
    // テキストを表示する
    [SerializeField] Text _messegeWindow = null;
    [SerializeField] GameObject _target = null;
    // 表示させるメッセージとカーソルとの距離
    [SerializeField] float _onMessegeDistance = 1;

    float distance = 0;

    // Start is called before the first frame update
    void Start()
    {
        // 最初は表示しない
        _messegeWindow.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // 距離を計算する
        distance = Vector2.Distance(this.transform.position, _target.transform.position);

        // 距離で表示させるかを決める
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
