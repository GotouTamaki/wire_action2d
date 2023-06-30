using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessegeWindowManager : MonoBehaviour
{
    [SerializeField] Text _messegeWindow = null;
    [SerializeField] GameObject _target = null;
    [SerializeField] float _onMessegeDistance = 1;

    float distance = 0;

    // Start is called before the first frame update
    void Start()
    {
        _messegeWindow.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distance = Vector2.Distance(this.transform.position, _target.transform.position);

        if (distance < _onMessegeDistance) 
        {
            _messegeWindow.enabled = true;
        }
        else
        {
            _messegeWindow.enabled = false;
        }
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag("Target"))
    //    {
    //        _messegeWindow.enabled = true;
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag("Target"))
    //    {
    //        _messegeWindow.enabled = false;
    //    }
    //}
}
