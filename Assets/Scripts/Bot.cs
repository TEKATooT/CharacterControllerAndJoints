using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bot : MonoBehaviour
{
    [SerializeField] Player _target;
    [SerializeField] float _speed;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveForPlayer();
    }

    private void MoveForPlayer()
    {
        Vector3 targetPosition = Vector3.Lerp(transform.position, _target.transform.position, _speed * Time.deltaTime);

        _rigidbody.Move(targetPosition, Quaternion.identity);
    }
}
