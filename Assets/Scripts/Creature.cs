using System;
using System.Collections.Generic;

public class Creature
{
    public string Name;
    
    // Stats
    public int Level; // pour l'instant pas de système d'xp
    public int CurrentHp;
    public int MaxHp;
    public int Attack;
    public int Defense;
    public int Speed;
    public List<Type> Types;
    public List<Attack> Attacks;

    // todo IV / EV ?

    private void ModifyHp(int hp)
    {
        CurrentHp = Math.Min(CurrentHp + hp, MaxHp);
    }

    public bool IsDead()
    {
        return CurrentHp <= 0;
    }
    
    // Attacks related
    public void ReceiveAttack(Attack attack, Creature attacker)
    // Calculate damage done by an attack
    // Cf Bulbapedia article
    {
        var typeEfficiency = new TypeEfficiency();
        
        var baseDamage = (2 * attacker.Level / 5) + 2 * attack.Power * attacker.Attack / Defense / 50 + 2;
        var effectiveness = typeEfficiency.GetTypeEffectiveness(attack.Type, Types);
        var stab = typeEfficiency.GetSTABMultiplier(attack.Type, attacker.Types);

        var lostHp = (int) (baseDamage * effectiveness * stab);

        ModifyHp(-lostHp);
        if (IsDead())
        {
            // todo
        }
    }

    public void Heal(HealingItem potion)
    {
        ModifyHp(potion.HealedHp);
    }

    public float GetModifiedCatchRate(CaptureOrb ball)
    // Cf Bulbapedia
    {
        var baseValue = 1 - 2 * CurrentHp / 3 / MaxHp;
        var creatureCatchRate = 1f; // TODO plusieurs valeurs
        var ballBonus = ball.CaptureMultiplier;

        return baseValue * creatureCatchRate * ballBonus;
    }

}