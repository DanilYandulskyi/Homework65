using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterControllerMover : Mover
{
    private CharacterController _characterController;
    
    private float _fallMagnitude = 9.8f;
    private Vector3 _direction;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();

        _direction = Vector3.down * (_fallMagnitude * Time.deltaTime);
    }

    public override void Move(Vector3 direction)
    {
        _direction += direction;
        Vector3 offset = direction.normalized * (Speed * Time.deltaTime);

        _characterController.Move(offset);

        _direction = Vector3.down;
    }

    private void Update()
    {
        Move(_direction);
    }
}
