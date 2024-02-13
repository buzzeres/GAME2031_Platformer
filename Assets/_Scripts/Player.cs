using System;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 1f;

    [SerializeField] private MyButton _rightArrow;
    [SerializeField] private MyButton _leftArrow;
    [SerializeField] private TMP_Text _pointsLabel;
    [SerializeField] private Animator _animator;
    [SerializeField] private string _animParamSpeed = "Speed";
    [SerializeField] private string _animParamIsMoving = "IsMoving";
    [SerializeField] private string _animParamIsDead = "IsDead";

    private float _movement = 0f;
    private Rigidbody2D _rigidBody;
    private int _points = 0;

    private int _hashSpeed, _hashIsMoving, _hashIsDead;

    private void Awake()
    {
        _hashSpeed = Animator.StringToHash(_animParamSpeed);
        _hashIsMoving = Animator.StringToHash(_animParamIsMoving);
        _hashIsDead = Animator.StringToHash(_animParamIsDead);

        _rigidBody = GetComponent<Rigidbody2D>();

        if (_rightArrow != null)
        {
            _rightArrow.OnPointerDownEvent.AddListener(() => Move(1));
            _rightArrow.OnPointerUpEvent.AddListener(() => StopMoving());
        }

        if (_leftArrow != null)
        {
            _leftArrow.OnPointerDownEvent.AddListener(() => Move(-1));
            _leftArrow.OnPointerUpEvent.AddListener(() => StopMoving());
        }
    }

    public void Move(float direction)
    {
        _movement = direction * _movementSpeed;
        UpdateAnimationState();
    }

    public void StopMoving()
    {
        _movement = 0;
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        bool isMoving = _movement != 0;
        _animator.SetBool(_hashIsMoving, isMoving);
        _animator.SetFloat(_hashSpeed, Mathf.Abs(_movement));
    }

    private void FixedUpdate()
    {
        if (_movement != 0)
        {
            _rigidBody.velocity = new Vector2(_movement, _rigidBody.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;

        if (other.GetComponent<ISpawnnable>() is Element e)
        {
            e.Respawn();

            _points += e.Value;
            _pointsLabel.text = "Points: " + _points;

            if (e.Value < 0)
            {
                _animator.SetBool(_hashIsDead, true);
            }
        }
    }
}
