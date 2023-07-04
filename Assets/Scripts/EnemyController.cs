using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] MoveMode _moveMode;
    [Tooltip("オブジェクトの移動速度")]
    [SerializeField] float _moveSpeed = 5f;
    [Tooltip("ターゲットに到達したと判断する距離（単位:メートル）")]
    [SerializeField] float _stoppingDistance = 0.05f;
    //[SerializeField]
    //protected float _vertSpeed = 1f;
    //[SerializeField]
    //protected float _horiSpeed = 1f;
    [SerializeField]
    float _amplitude = 5f;

    Vector3 _initialPosition;
    Rigidbody2D _rb = default;
    float _wave = 0;
    float _time = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        // 初期位置を記録する(MovePoint0用)
        _initialPosition = this.transform.position;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {

        if (InsideCamera())
        {
            // カメラ内でのみ時間を足す(sin用)
            _time += Time.deltaTime;

            if (_moveMode == MoveMode.MoveStope)
            {
                MoveStope();
            }
            else if (_moveMode == MoveMode.MovePoint0)
            {
                MovePoint0();
            }
            else if (_moveMode == MoveMode.HoriSinCurveMove)
            {
                HoriSinCurveMove();
            }
            else if (_moveMode == MoveMode.VertSinCurveMove)
            {
                VertSinCurveMove();
            }
        }
        else if (!InsideCamera())
        {
            _rb.velocity = new Vector2(0, 0);
            //Debug.Log("止まる");
        }

    }

    enum MoveMode
    {
        MoveStope,
        MovePoint0,
        HoriSinCurveMove,
        VertSinCurveMove,
    }

    // 何も動きがない
    void MoveStope()
    {
        //Debug.Log("敵停止");
    }

    // 元の場所に戻ろうとする
    void MovePoint0() 
    {
        // 自分自身とターゲットの距離を求める
        float distance = Vector2.Distance(this.transform.position, _initialPosition);

        if (distance > _stoppingDistance)   // ターゲットに到達するまで処理する
        {
            Vector3 dir = (_initialPosition - this.transform.position).normalized * _moveSpeed; // 移動方向のベクトルを求める
            _rb.AddForce(dir * _moveSpeed, ForceMode2D.Force);
        }
    }

    // 横の往復移動
    void HoriSinCurveMove()
    {
        _wave = Mathf.Sin(_time * _moveSpeed) * _amplitude;
        //Debug.Log(_wave);
        _rb.velocity = new Vector2(_wave, _rb.velocity.y);
    }

    // 縦の往復移動
    void VertSinCurveMove()
    {
        _wave = Mathf.Sin(_time * _moveSpeed) * _amplitude;
        //Debug.Log(_wave);
        _rb.velocity = new Vector2(_rb.velocity.x, _wave);
    }

    // カメラ内かどうかを判定する
    public bool InsideCamera()
    {
        float x = Camera.main.ViewportToWorldPoint(Vector2.one).x;
        float y = Camera.main.ViewportToWorldPoint(Vector2.one).y;
        if (x > transform.position.x && transform.position.x > Camera.main.ViewportToWorldPoint(Vector2.zero).x &&
            y > transform.position.y && transform.position.y > Camera.main.ViewportToWorldPoint(Vector2.zero).y)
        {
            return true;
        }
        return false;
    }
}

    