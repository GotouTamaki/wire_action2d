using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject _statusWindow;

    AudioSource _audio = default;

    // Start is called before the first frame update
    void Start()
    {
        _statusWindow.SetActive(false);
        Time.timeScale = 1;
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Time.timeScale = 1;

        if (Input.GetKeyDown("escape"))
        {
            //_audio.Play();
            _statusWindow.SetActive(!_statusWindow.activeSelf);

            if (!_statusWindow.activeSelf)
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
