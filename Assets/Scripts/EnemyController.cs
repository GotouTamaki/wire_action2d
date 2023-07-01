using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] MoveMode _moveMode;
    [Tooltip("�I�u�W�F�N�g�̈ړ����x")]
    [SerializeField] float _moveSpeed = 5f;
    [Tooltip("�^�[�Q�b�g�ɓ��B�����Ɣ��f���鋗���i�P��:���[�g���j")]
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
        _initialPosition = this.transform.position;
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (InsideCamera() == true)
        {
            _time += Time.deltaTime;
        }
        else if (InsideCamera() == false)
        {
            _rb.velocity = new Vector2(0, 0);
            //Debug.Log("�~�܂�");
        }
    }

    private void FixedUpdate()
    {
        if (InsideCamera())
        {
            if (_moveMode == MoveMode.MoveStope)
            {
                MoveStope();
            }
            else if (_moveMode == MoveMode.MovePoint0)
            {
                MovePoint0();
            }
            else if (_moveMode == MoveMode.Patrol)
            {
                Patrol();
            }
            else if (_moveMode == MoveMode.HoriSinCurveMove)
            {
                HoriSinCurveMove();
            }
            else if (_moveMode == MoveMode.VertSinCurveMove)
            {
                VertSinCurveMove();
            }
            else if (_moveMode == MoveMode.CatchMove)
            {
                CatchMove();
            }
        }
    }

    enum MoveMode
    {
        MoveStope,
        MovePoint0,
        Patrol,
        HoriSinCurveMove,
        VertSinCurveMove,
        CatchMove,
    }

    // �����������Ȃ�
    void MoveStope()
    {
        //Debug.Log("�G��~");
    }

    // ���̏ꏊ�ɖ߂낤�Ƃ���
    void MovePoint0() 
    {
        // �������g�ƃ^�[�Q�b�g�̋��������߂�
        float distance = Vector2.Distance(this.transform.position, _initialPosition);

        if (distance > _stoppingDistance)  // �^�[�Q�b�g�ɓ��B����܂ŏ�������
        {
            Vector3 dir = (_initialPosition - this.transform.position).normalized * _moveSpeed; // �ړ������̃x�N�g�������߂�
            _rb.AddForce(dir * _moveSpeed, ForceMode2D.Force);
        }
    }

    void Patrol()
    {

    }

    // ���̉����ړ�
    void HoriSinCurveMove()
    {
        _wave = Mathf.Sin(_time * _moveSpeed) * _amplitude;
        //Debug.Log(_x);
        _rb.velocity = new Vector2(_wave, _rb.velocity.y);
    }

    // �c�̉����ړ�
    void VertSinCurveMove()
    {
        _wave = Mathf.Sin(_time * _moveSpeed) * _amplitude;
        //Debug.Log(_x);
        _rb.velocity = new Vector2(_rb.velocity.x, _wave);
    }

    void CatchMove()
    {

    }

    // �J���������ǂ����𔻒肷��
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

    