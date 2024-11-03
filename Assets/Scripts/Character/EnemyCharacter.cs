using UnityEngine;
using UnityEngine.Serialization;

public class EnemyCharacter : Character
{
    [SerializeField] private AiState _aiState;
    [SerializeField] private Character _targetPlayer;
    [SerializeField] private Transform _targetTransform;
    
    
    public void Start()
    {
        Initialize();
    }

    public override void Initialize()
    {
        base.Initialize();
        AttackComponent = new EnemyHandedAttackComponent();
        AttackComponent.Initialize(characterData, _targetPlayer);
    }
    
    protected override void Update()
    {
        switch (_aiState)
        {
            case AiState.None:
            case AiState.Idle:
                return;
            
            case AiState.MovementToTarget:
                Vector3 direction = _targetTransform.position - characterData.CharacterTransform.position;
                direction = direction.normalized;
                MovementComponent.Move(direction);
                MovementComponent.Rotation(direction);
                AttackComponent.MakeAttack();
                return;
        }
    }
}