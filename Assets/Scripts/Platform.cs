using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float Speed;
    public float BorderPositionX;

    private Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        _transform.Translate(Vector3.right * Speed * horizontal * Time.deltaTime);
        if (_transform.position.x > BorderPositionX)
        {
            _transform.position = new Vector3(BorderPositionX, _transform.position.y, _transform.position.z);
        }
        if (_transform.position.x < -BorderPositionX) 
        {
            _transform.position = new Vector3(-BorderPositionX, _transform.position.y, _transform.position.z);
        }
    }
}
