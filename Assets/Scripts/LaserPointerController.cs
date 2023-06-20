using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointerController : MonoBehaviour
{
    [SerializeField] 
    GameObject _crossehair;
    // –C’e‚Æ‚µ‚Ä¶¬‚·‚éƒvƒŒƒnƒu
    [SerializeField]
    GameObject _shellPrefab = default;

    AudioSource _audio = default;

    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        this.transform.up = _crossehair.transform.position - transform.position;
    }
}
