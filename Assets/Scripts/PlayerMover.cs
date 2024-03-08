using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    //[SerializeField] private float _speed = 3;
    [SerializeField] private float _tapForce = 500;
    [SerializeField] private KeyCode _key = KeyCode.Space;
    [SerializeField] private Vector3 _startPosition;

    private Rigidbody2D _rigidbody;
    private Camera _camera;
    private Vector2 screenBounds;

    private float playerWidthPosition;
    private float playerHeightPosition;
    private float minXPosition;
    private float maxXPosition;
    private float minYPosition;
    private float maxYPosition;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
        screenBounds = _camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, _camera.transform.position.z));

        ResetPlayer();
    }

    private void Update()
    {
        if (Input.GetKeyDown(_key))
        {
            //_rigidbody.velocity = new Vector2(_speed, 0);
            _rigidbody.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);
        }

        playerWidthPosition = transform.localScale.x / 2;
        playerHeightPosition = transform.localScale.y / 2;

        maxXPosition = screenBounds.x - playerWidthPosition;
        minXPosition = -screenBounds.x + playerWidthPosition;
        maxYPosition = screenBounds.y - playerHeightPosition;
        minYPosition = -screenBounds.y + playerHeightPosition;

        if (transform.position.x <= minXPosition || transform.position.x >= maxXPosition || transform.position.y <= minYPosition || transform.position.y >= maxYPosition)
        {
            Vector3 clampedPosition = transform.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, minXPosition, maxXPosition);
            clampedPosition.y = Mathf.Clamp(clampedPosition.y, minYPosition, maxYPosition);
            
            transform.position = clampedPosition;
            _rigidbody.velocity = Vector2.zero;
        }
    }

    public void ResetPlayer()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;
        _rigidbody.velocity = Vector2.zero;
    }
}
