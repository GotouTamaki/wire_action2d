using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringManager : MonoBehaviour
{
    [SerializeField]
    private float _jumpForce = 20.0f;

    AudioSource _audio = default;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // �������������Rigidbody�R���|�[�l���g���擾���āA������̗͂�������
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _audio.Play();
        }
    }
}
