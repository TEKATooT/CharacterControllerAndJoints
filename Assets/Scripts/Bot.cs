using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
public class Bot : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private float _speed;

    private Material _startMaterials;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _startMaterials = GetComponent<Renderer>().material;

        Color newColor = _startMaterials.color;

        newColor.a = 0;

        _startMaterials.color = newColor;
    }

    private void FixedUpdate()
    {
        MoveForPlayer();

        Invisible();
    }

    private void MoveForPlayer()
    {
        Vector3 targetPosition = Vector3.Lerp(transform.position, _target.transform.position, _speed * Time.deltaTime);

        _rigidbody.Move(targetPosition, Quaternion.identity);
    }

    private void Invisible()
    {
        Color newColor = _startMaterials.color;
        float _alfa = _startMaterials.color.a;

        float newAlfa = Mathf.Lerp(_alfa, 1, 1 * Time.deltaTime);
        Debug.Log(newColor.a);
        newColor.a = newAlfa;

        _startMaterials.color = newColor;
    }
}