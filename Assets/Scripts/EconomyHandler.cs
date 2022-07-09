using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EconomyHandler : MonoBehaviour
{
    [SerializeField]
    private int balance;

    public int Balance { get => balance; set => balance = value; }

    public void addBalance(int amount)
    {
        Balance += amount;
        Debug.Log($"Account balance: {Balance}");
    }
    /// <summary>method <c>subtractBalance</c> returns false if balance is too low, true otherwise.</summary>
    public bool subtractBalance(int amount) //returns false if balance is too low, true otherwise
    {
        if( Balance < amount) return false;
        else
        {
            Balance -= amount;
            return true;
        }
    }
}
