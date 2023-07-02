using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
//using static UnityEngine.GraphicsBuffer;

public class TargetController : MonoBehaviour
{
    // プレイヤーを取得
    [SerializeField] GameObject _player;
    // カーソルの色変更
    [SerializeField] Color _defaultColor;
    [SerializeField] Color _catchColor;


    LineRenderer _line;
    bool _canHook = false;
    GameObject _target;
    //AudioSource _audio = default;

    // Start is called before the first frame update
    void Start()
    {
        // LineRenderere関連の設定
        // コンポーネントを取得する
        this._line = GetComponent<LineRenderer>();
        // 線の幅を決める
        this._line.startWidth = 0.1f;
        this._line.endWidth = 0.1f;
        // 頂点の数を決める
        this._line.positionCount = 2;
        // マテリアルの設定
        _line.material = new Material(Shader.Find("Sprites/Default"));
    }

    // Update is called once per frame
    void Update()
    {
        // LineRenderereの始点と終点
        _line.SetPosition(0, this.transform.position);
        _line.SetPosition(1, this._player.transform.position);

        //フックを掛けられるかどうか
        _player.GetComponent<PlayerController>()._CanHook = _canHook;

        if (Input.GetButton("Fire1") && _canHook)
        {
            // カーソルの位置を固定する
            this.transform.position = this.transform.position;
            // 色を指定する
            _line.startColor = _catchColor;
            _line.endColor = _catchColor;
        }
        else
        {
            TargetMove();
            // 色を指定する
            _line.startColor = _defaultColor;
            _line.endColor = _defaultColor;
        }
    }

    // カーソルの動きを設定する
    private void TargetMove()
    {
        // Camera.main でメインカメラ（MainCamera タグの付いた Camera）を取得する
        // Camera.ScreenToWorldPoint 関数で、スクリーン座標をワールド座標に変換する
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // ターゲットが見えなくなってしまうため、Z 座標を調整している
        mousePosition.z = -5;
        this.transform.position = mousePosition;
    }


    // フックを掛けられるかどうかの判定
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_target && (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Anchor" || collision.gameObject.tag == "Item"))
        {
            _target = collision.gameObject;
            //Debug.Log($"Target: {_target.name}");
            SpriteRenderer Cr = GetComponent<SpriteRenderer>();
            Cr.color = Color.green;
            _canHook = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_target)
        {
            _target = null;
            //Debug.Log($"Target: null");
            SpriteRenderer Cr = GetComponent<SpriteRenderer>();
            Cr.color = Color.white;
            _canHook = false;
        } 
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!_target && (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Anchor" || collision.gameObject.tag == "Item"))
        {
            _target = collision.gameObject;
            //Debug.Log($"Target: {_target.name}");
            SpriteRenderer Cr = GetComponent<SpriteRenderer>();
            Cr.color = Color.green;
            _canHook = true;
        }
    }
}
