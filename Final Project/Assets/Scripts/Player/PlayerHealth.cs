using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Starts the player off with 3 hearts.  Everytime damage is taken, it subtracts one heart. It can also report whether it's dead and how much health remains.
/// </summary>
public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth = 3;
    int _currentHealth;
    private void Awake()
    {
        _currentHealth = MaxHealth;
    }
    public void TakeDamage(int amount)
    {
        _currentHealth = _currentHealth - amount;
    }
    public bool IsDead()
    {
        return _currentHealth <= 0;
    }
    public float GetHealthPercentage()
    {
        return ( (float) _currentHealth / (float) MaxHealth);
    }
}
