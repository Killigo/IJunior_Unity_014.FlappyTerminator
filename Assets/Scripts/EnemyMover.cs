using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 2;
    [SerializeField] private float _offset = 2;

    private Vector2 _target;

    private void Start()
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Vector2 rightPosition = new Vector2(screenBounds.x - _offset, transform.position.y);

        _target = rightPosition;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _target, _speed * Time.deltaTime);
    }
}
