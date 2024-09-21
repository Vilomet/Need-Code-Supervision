using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _health = 100;
    [SerializeField] private float _damageCoefficient;
    [SerializeField] private GameObject _loosingScreen;
    [SerializeField] private GameObject _thruster;
    [SerializeField] private GameObject _timer;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _hitAudioSource;
    [SerializeField] private Slider _healthFill;
    
    private Rigidbody2D _rigidbody;
    private AudioSource _explosionSound;
    private AudioSource _hitSound;
    private Animator _animator;
    private Behaviour _playerController;
    private Behaviour _thrustFlame;

    void Start()
    {
        _healthFill.maxValue = _health;
        _healthFill.value = _health;

        _animator = gameObject.GetComponent<Animator>();
        _thrustFlame = gameObject.GetComponent<ThrustFlame>();
        _explosionSound = gameObject.GetComponent<AudioSource>();
        _hitSound = _hitAudioSource.GetComponent<AudioSource>();

        _playerController = _player.GetComponent<PlayerController>();
        _rigidbody = _player.GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        _hitSound.Play();

        _health = _health - _damageCoefficient * col.relativeVelocity.magnitude;

        _healthFill.value = _health;

        if(_health <= 0)
        {
            Death();
        }
    }

    public void PlayerDestruction()
    {
        _loosingScreen.SetActive(true);
        
        Destroy(gameObject);
    }

    private void Death()
    {
        _rigidbody.bodyType = RigidbodyType2D.Static;

        _thrustFlame.enabled = false;
        _playerController.enabled = false;
        _timer.SetActive(false);

        Timer.GameTime = 0;

        Destroy(_thruster);

        _explosionSound.Play(0);
        ThrustFlame.ThruterSound.Stop();

        _animator.Play("Death Animation");
    }
}
