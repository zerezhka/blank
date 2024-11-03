public interface IAttackComponent
{
    public float Damage { get; }
    public float AttackRange { get; }


    void Initialize(CharacterData characterData, Character target);
    
    public void MakeAttack();
}
