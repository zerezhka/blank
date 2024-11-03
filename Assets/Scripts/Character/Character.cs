using System;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public event Action<Character> OnCharacterDeath;

    [SerializeField] protected CharacterData characterData;

    public IMovementComponent MovementComponent { get; protected set; }
    public IHealthComponent HealthComponent { get; protected set; }
    public IAttackComponent AttackComponent { get; protected set; }

    protected abstract void Update();

    public virtual void Initialize()
    {
        MovementComponent = new CharacterControllerMovementComponent();
        MovementComponent.Initialize(characterData);

        HealthComponent = new CharacterHealthComponent();
        HealthComponent.Initialize(characterData.baseHealth);
    }

    // todo implement different realization for enemy and player?
    public virtual void TakeDamage(float damage)
    {
        HealthComponent.Health -= damage;

        Debug.Log("Take " + damage + " damage into face :/ Remaining: " + HealthComponent.Health);
        if (HealthComponent.Health <= 0)
        {
            OnCharacterDeath?.Invoke(this);
        }
    }
}