using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestTimeUIManager : MonoBehaviour
{
    [SerializeField]
    Text _bestTimeText = default;

    public static float _bestTime = 9999.99f;

    // Start is called before the first frame update
    void Start()
    {
        if (_bestTime > PlayerUIManager._clearTime) 
        {
            _bestTime = PlayerUIManager._clearTime;
            _bestTimeText.text = PlayerUIManager._clearTime.ToString("F2");
        }
        else
        {
            _bestTimeText.text = _bestTime.ToString("F2");
        }
    }   
}
