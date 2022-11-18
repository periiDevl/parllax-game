using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viewBobb : MonoBehaviour
{
    [SerializeField] private bool _enable = true;

    [SerializeField, Range(0, 0.05f)] private float _amplitude = 0.015f;
    [SerializeField, Range(0, 50)] private float _frequency = 10.0f;

    [SerializeField] private Transform _camera = null;
    [SerializeField] private Transform _cameraHolder = null;

    private Vector3 _startPos;
    private CharacterController _controller;
    public movement movementScript;
    public float Start;



    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _startPos = _camera.localPosition;
    }



    void Update()
    {
        if (!_enable) return;

        CheckMotion();
        ResetPosition();
        _camera.LookAt(FocusTarget());
    }



    private void PlayMotion(Vector3 motion)
    {
        _camera.localPosition += motion;
    }



    private void CheckMotion()
    {
        float speed = new Vector3(_controller.velocity.x, 0, _controller.velocity.z).magnitude;

        if (movementScript.speed < Start) return;
        if (!movementScript.isGrounded) return;

        PlayMotion(FootStepMotion());
    }



    private Vector3 FootStepMotion()
    {
        Vector3 pos = Vector3.zero;
        pos.y += Mathf.Sin(Time.time * _frequency) * _amplitude;
        pos.x += Mathf.Cos(Time.time * _frequency / 2) * _amplitude * 2;
        return pos;
    }



    private void ResetPosition()
    {
        if (_camera.localPosition == _startPos) return;
        _camera.localPosition = Vector3.Lerp(_camera.localPosition, _startPos, 1 * Time.deltaTime);
    }




    private Vector3 FocusTarget()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + _cameraHolder.localPosition.y, transform.position.z);
        pos += _cameraHolder.forward * 15.0f;
        return pos;
    }
}
