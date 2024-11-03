using Unity.VisualScripting;
using UnityEngine;

public class PlayerCharacter : Character
{
    public void Start()
    {
        Initialize();
        OnCharacterDeath += character =>
        {
            Debug.Log(character + " says: Im died");
        };
    }

    protected  override void Update()
    {
        if (HealthComponent.IsAlive)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 moveDirection = new Vector3(x, 0, z).normalized;

            MovementComponent.Move(moveDirection);
            MovementComponent.Rotation(moveDirection);
        }
        else
        {
            // todo make animation
            // todo show game over screen
            Debug.Log("Всё, геймовер");
        }
    }
}