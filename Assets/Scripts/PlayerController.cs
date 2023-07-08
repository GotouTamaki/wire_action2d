using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
//using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{
    // Action���C���X�y�N�^�[����ҏW�ł���悤�ɂ���
    [SerializeField] private InputAction _action;

    // ���E�ړ������
    [SerializeField] float _movePower = 5f;
    // �W�����v�����
    [SerializeField] float _jumpPower = 15f;
    // ���͂ɉ����č��E�𔽓]�����邩�ǂ����̃t���O
    [SerializeField] bool _flipX = false;
    // �^�[�Q�b�g�J�[�\��
    [SerializeField] GameObject _target;
    // ���������鋭��
    [SerializeField] float _springPower = 1f;
    // ���ʉ�
    [SerializeField] AudioClip _landing = default;
    [SerializeField] AudioClip _grap = default;
    // _grap�̉��ʒ���
    [SerializeField] float _grapAudioScale = 1f;

    // �e�평����
    Rigidbody2D _rb = default;
    SpriteRenderer _sprite = default;
    // _colors �Ɏg���Y��
    //int _colorIndex;
    // ���������̓��͒l
    float _h;
    float _scaleX;
    // �ŏ��ɏo���������W
    Vector3 _initialPosition;
    // �ڒn����
    bool _isGrounded = false;
    int _jumpCount = 0;
    //this._target.transform.position��this.transform.position�̍�
    Vector2 _diff;
    //���C���[�A�N�V�����̉�
    public bool _CanHook = false;
    //������X�e�[�W�̏����L�^����
    string _stage = default;
    AudioSource _audioSource; 

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        // �����ʒu���o���Ă���
        _initialPosition = this.transform.position;
        _stage = SceneManager.GetActiveScene().name;
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // ���͂��󂯎��
        _h = Input.GetAxisRaw("Horizontal");
        //m_h = 0;
        _sprite = GetComponent<SpriteRenderer>();

        // �e����͂��󂯎��
        if (Input.GetButtonDown("Jump") && (_isGrounded || _jumpCount < 2))
        {
            _jumpCount++;
            //Debug.Log("�����ɃW�����v���鏈���������B");
            _rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        }

        if (Input.GetButtonDown("Fire1") && _CanHook)
        {
            _audioSource.PlayOneShot(_grap, _grapAudioScale);
        }

        if (Input.GetButton("Fire1") && _CanHook)
        {
            //Debug.Log("���C���[�A�N�V�����I");
            _diff = this._target.transform.position - this.transform.position;     
        }       
        else
        {
            _diff = Vector2.zero;
        }

        // ���ɍs���������珉���ʒu�ɖ߂�
        if (this.transform.position.y < -10f)
        {
            this.transform.position = _initialPosition;
        }

        // �ݒ�ɉ����č��E�𔽓]������
        if (_flipX)
        {
            FlipX(_h);

        }
    }

    private void FixedUpdate()
    {
        // ���ړ��̗͂�������̂� FixedUpdate �ōs��
        _rb.AddForce(Vector2.right * _h * _movePower, ForceMode2D.Force);
        //���C���[�A�N�V�����̗͂�������
        _rb.AddForce(_diff * _springPower, ForceMode2D.Force);
    }

    /// <summary>
    /// ���E�𔽓]������
    /// </summary>
    /// <param name="horizontal">���������̓��͒l</param>
    void FlipX(float horizontal)
    {
        /*
         * ������͂��ꂽ��L�����N�^�[�����Ɍ�����B
         * ���E�𔽓]������ɂ́ATransform:Scale:X �� -1 ���|����B
         * Sprite Renderer �� Flip:X �𑀍삵�Ă����]����B
         * */
        _scaleX = this.transform.localScale.x;

        if (horizontal > 0)
        {
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
            //lookingright = true;
        }
        else if (horizontal < 0)
        {
            this.transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
            //lookingright = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Target" || collision.gameObject.tag != "MessegeWindow")
        {
            //Debug.Log("�ڒn����");
            _isGrounded = true;
            _jumpCount = 0;
            _audioSource.PlayOneShot(_landing);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Target" || collision.gameObject.tag == "MessegeWindow")
        {
            //Debug.Log("�W�����v����");
            _isGrounded = false; 
        }
    }
}
