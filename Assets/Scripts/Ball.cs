using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    public float JumpForce;
    public GameManager GameManager;
    public Platform Platform;
    public AudioClip HitSound;
                                                                                                     
    private AudioSource _audiosource;
    private Rigidbody2D _rigidboby;
    private Vector3 _reversedDirection;
    private Vector3 _positionBall;
    private Vector3 _platformPosition;
    private Transform _transform;

    private void Awake()
    {
        _rigidboby = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        _audiosource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        _rigidboby.velocity = Vector3.up + Vector3.right * Random.Range(-1f, 1f) * JumpForce;
        _positionBall = _transform.position;
        _platformPosition = Platform.transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _rigidboby.velocity = Vector3.zero;
        var pointBall = collision.contacts[0].normal;
        _rigidboby.velocity = Vector3.Reflect(_reversedDirection, pointBall).normalized * JumpForce;

        if (collision.gameObject.tag == "Cub's")
        {
            var cubePoint = collision.contacts[0];
            BlockExplosion.Instance.KillCubeEffect(cubePoint.point);
            GameManager._score++;
            Destroy(collision.gameObject);
            _audiosource.PlayOneShot(HitSound);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager._lives--;
        ResetBallPosition();

    }
    private void Update()
    {
        _reversedDirection = _rigidboby.velocity;
    }
    private void ResetBallPosition()
    {
        _transform.position = _positionBall;
        Platform.transform.position = _platformPosition;
    }
}
