using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessegeWindowManager : MonoBehaviour
{
    [SerializeField]
    private Transform _targetTfm;
    [SerializeField]
    private Vector3 _offset = new Vector3(0, 1.5f, 0);

    private RectTransform _myRectTfm;

    // Start is called before the first frame update
    void Start()
    {
        _myRectTfm = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        _myRectTfm.position = RectTransformUtility.WorldToScreenPoint(Camera.main, _targetTfm.position + _offset);
    }
}
