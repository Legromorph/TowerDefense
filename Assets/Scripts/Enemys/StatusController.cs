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
        var existingEffect = activeEffects.Find(e => e.Name == effect.Name);

        if (existingEffect != null)
        {
            if (!existingEffect.IsStackable)
            {
                Debug.Log("Stack schon drauf!");
                return;
            }
            else
            {
                Debug.Log("Add Stack");
                existingEffect.AddStack();
                return;
            }
        }
        else
        {
            Debug.Log($"Neuer Effekt angewendet: {effect.Name}");
            effect.ApplyEffect();
            activeEffects.Add(effect);
            CheckForCombinations();
        }
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
        bool hasFrost = activeEffects.Exists(e => e.Name == "FrostSlow");
        bool hasSuperFrost = activeEffects.Exists(e => e.Name == "SuperFrost");

        if (hasFrost && hasSuperFrost)
        {
            ApplyFreeze();
        }
    }

    private void ApplyFreeze()
    {
        enemy.AddSpeedModifier(0);
    }
}