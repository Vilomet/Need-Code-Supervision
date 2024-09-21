using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustFlame : MonoBehaviour
{
    public static AudioSource ThruterSound;

    public GameObject ThrustFire;

    [SerializeField] private GameObject _player;

    void Start() 
    {
        ThruterSound = _player.GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            ThrustFire.SetActive(true);

            ThruterSound.Play(0);
        }

        if(Input.GetKeyUp(KeyCode.W))
        {
            ThrustFire.SetActive(false);

            ThruterSound.Stop();
        }
    }
}
