using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject _menuWindow;

    AudioSource _audio = default;

    // Start is called before the first frame update
    void Start()
    {
        _menuWindow.SetActive(false);
        Time.timeScale = 1;
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Time.timeScale = 1;

        // メニュー画面の切り替え
        if (Input.GetKeyDown("escape"))
        {
            //_audio.Play();
            _menuWindow.SetActive(!_menuWindow.activeSelf);

            // メニュー画面が開かれているならゲームを止める
            if (!_menuWindow.activeSelf)
            {
                Time.timeScale = 1;
                //Debug.Log("memu crose");
            }
            else
            {
                Time.timeScale = 0;
                //Debug.Log("memu ");
            }
        }
    }
}
