using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float moveSpeed;
    private Vector3 _moveDir;

    [SerializeField, Range(1, 20)] private float mouseSensX;
    [SerializeField, Range(1, 20)] private float mouseSensY;

    private float minViewAngle = -90;
    private float maxViewAngle = 90;
    [SerializeField] private Transform followTarget;

    private Vector2 currentAngle;

    [SerializeField] private Rigidbody bulletPrefab;
    [SerializeField] private float bulletForce;
    


    void Start()
    {
        InputManager.Init(myPlayer: this);
        InputManager.GameMode();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.position += transform.rotation * (moveSpeed * Time.deltaTime * _moveDir);
    }
    public void SetMoveDirection(Vector3 newDirection)
    {
        _moveDir = newDirection;
    }
    public void SetLookRotation(Vector3 readValue)
    {
        currentAngle.x += -readValue.x * Time.deltaTime * mouseSensX;
        currentAngle.y += -readValue.y * Time.deltaTime * mouseSensY;

        currentAngle.y = Mathf.Clamp(currentAngle.y, minViewAngle, maxViewAngle);

        transform.rotation = Quaternion.AngleAxis(currentAngle.x, Vector3.down);
        followTarget.localRotation = Quaternion.AngleAxis(currentAngle.y, Vector3.right);
    }

    
}    
