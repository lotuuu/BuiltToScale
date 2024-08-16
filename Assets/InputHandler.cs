using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    Builder builder;
    Turret turret;

    // Start is called before the first frame update
    void Start()
    {
        builder = FindObjectOfType<Builder>();
        turret = FindObjectOfType<Turret>();
    }

    void OnMoveTurret(InputValue inputValue)
    {
        turret.Move(inputValue);
    }

    void OnJumpTurret()
    {
        turret.Jump();
    }

    void OnMoveBuilder(InputValue inputValue)
    {
        builder.Move(inputValue);
    }

    void OnJumpBuilder()
    {
        builder.Jump();
    }
}
