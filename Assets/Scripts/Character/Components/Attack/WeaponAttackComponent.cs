using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttackComponent : IAttackComponent
{
    public float Damage { get; }
    public float AttackRange { get; }
    
    
    public void Initialize(CharacterData characterData, Character targetPlayer)
    {
        Debug.Log("MakeAttack() Not realized yet");
    }

    public void MakeAttack()
    {
        Debug.Log("MakeAttack() Not realized yet");   
    }
}
