using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessegeWindowManager : MonoBehaviour
{
    [SerializeField] Text _messegeWindow = null;

    // Start is called before the first frame update
    void Start()
    {
        _messegeWindow.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            _messegeWindow.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            _messegeWindow.enabled = false;
        }
    }
}
