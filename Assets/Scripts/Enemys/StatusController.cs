using System.Collections.Generic;
using UnityEngine;

public class StatusController : MonoBehaviour
{
    private EnemyBase enemy;
    private List<StatusEffect> activeEffects = new List<StatusEffect>();

    private void Awake()
    {
        enemy = GetComponent<EnemyBase>();
    }

    public void AddEffect(StatusEffect effect)
    {
        activeEffects.Add(effect);
        effect.ApplyEffect();

        CheckForCombinations();
    }

    public void RemoveEffect(StatusEffect effect)
    {
        effect.RemoveEffect();
        activeEffects.Remove(effect);
    }

    private void Update()
    {
        for (int i = activeEffects.Count - 1; i >= 0; i--)
        {
            activeEffects[i].UpdateEffect(Time.deltaTime);
            if (activeEffects[i].IsExpired)
            {
                RemoveEffect(activeEffects[i]);
            }
        }
    }

    private void CheckForCombinations()
    {
        bool hasFrost = activeEffects.Exists(e => e.name == "FrostSlow");
        bool hasSuperFrost = activeEffects.Exists(e => e.name == "SuperFrost");

        if (hasFrost && hasSuperFrost)
        {
            ApplyFreeze();
        }
    }

    private void ApplyFreeze()
    {
        enemy.currentSpeed = 0;
    }
}