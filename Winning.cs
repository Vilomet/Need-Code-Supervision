using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Winning : MonoBehaviour
{
    private Behaviour _playerController;
    private Behaviour _thrustFlame;
    private Behaviour _playerHealth;
    private Rigidbody2D _rigidbody;

    [SerializeField] private GameObject _winningScreen;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _playerBody;
    [SerializeField] private GameObject _timer;
    [SerializeField] private GameObject _healthBar;

    [SerializeField] private Text _bestTimeText;
    [SerializeField] private Text _curTimeText;

    void Start() 
    {
        _playerController = _player.GetComponent<PlayerController>();

        _playerHealth = _playerBody.GetComponent<PlayerHealth>();

        _thrustFlame = _playerBody.GetComponent<ThrustFlame>();

        _rigidbody = _player.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        _rigidbody.bodyType = RigidbodyType2D.Static;

        _timer.SetActive(false);
        _healthBar.SetActive(false);

        _playerHealth.enabled = false;
        _playerController.enabled = false;
        _thrustFlame.enabled = false;

        if (Timer.BestTime == 0)
        {
            Timer.BestTime = Timer.GameTime;
        }
        else if (Timer.GameTime < Timer.BestTime)
        {
            Timer.BestTime = Timer.GameTime;
        }

        _winningScreen.SetActive(true);

        _curTimeText.text = "Current time: " + Timer.GameTime;
        _bestTimeText.text = "Best time: " + Timer.BestTime;

        Timer.GameTime = 0;
    }
}
