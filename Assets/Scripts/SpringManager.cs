using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringManager : MonoBehaviour
{
    // 相手に与える力の強さを設定する
    [SerializeField]
    private float _jumpForce = 20.0f;

    // 効果音用のAudioSource
    AudioSource _audio = default;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // 当たった相手のRigidbodyコンポーネントを取得して、上向きの力を加える
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _audio.Play();
        }
    }
}
