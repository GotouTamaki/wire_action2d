using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
//using static UnityEngine.GraphicsBuffer;

public class TargetController : MonoBehaviour
{
    // �v���C���[���擾
    [SerializeField] GameObject _player;
    // �J�[�\���̐F�ύX
    [SerializeField] Color _defaultColor;
    [SerializeField] Color _catchColor;


    LineRenderer _line;
    bool _canHook = false;
    GameObject _target;
    //AudioSource _audio = default;

    // Start is called before the first frame update
    void Start()
    {
        // LineRenderere�֘A�̐ݒ�
        // �R���|�[�l���g���擾����
        this._line = GetComponent<LineRenderer>();
        // ���̕������߂�
        this._line.startWidth = 0.1f;
        this._line.endWidth = 0.1f;
        // ���_�̐������߂�
        this._line.positionCount = 2;
        // �}�e���A���̐ݒ�
        _line.material = new Material(Shader.Find("Sprites/Default"));
    }

    // Update is called once per frame
    void Update()
    {
        // LineRenderere�̎n�_�ƏI�_
        _line.SetPosition(0, this.transform.position);
        _line.SetPosition(1, this._player.transform.position);

        //�t�b�N���|�����邩�ǂ���
        _player.GetComponent<PlayerController>()._CanHook = _canHook;

        if (Input.GetButton("Fire1") && _canHook)
        {
            // �J�[�\���̈ʒu���Œ肷��
            this.transform.position = this.transform.position;
            // �F���w�肷��
            _line.startColor = _catchColor;
            _line.endColor = _catchColor;
        }
        else
        {
            TargetMove();
            // �F���w�肷��
            _line.startColor = _defaultColor;
            _line.endColor = _defaultColor;
        }
    }

    // �J�[�\���̓�����ݒ肷��
    private void TargetMove()
    {
        // Camera.main �Ń��C���J�����iMainCamera �^�O�̕t���� Camera�j���擾����
        // Camera.ScreenToWorldPoint �֐��ŁA�X�N���[�����W�����[���h���W�ɕϊ�����
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // �^�[�Q�b�g�������Ȃ��Ȃ��Ă��܂����߁AZ ���W�𒲐����Ă���
        mousePosition.z = -5;
        this.transform.position = mousePosition;
    }


    // �t�b�N���|�����邩�ǂ����̔���
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
