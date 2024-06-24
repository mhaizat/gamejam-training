using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CurrencyManager : MonoBehaviour
{
    #region Instance
    private static CurrencyManager instance;
    public static CurrencyManager Instance
    { 
        get 
        {
            if (instance == null)
                instance = FindObjectOfType<CurrencyManager>();
            return instance; 
        } 
    }
    #endregion

    [Tooltip("Move this variable to relevant place")]
    [SerializeField] private int currencyAmount;

    [Header("Events")]
    [Space]
    public UnityEvent<int> OnCurrencyChanged;
    public UnityEvent OnCurrencyNotEnough;

    private void Awake()
    {
        instance = this;
    }

    public bool IsCurrencyEnough(int amount)
    {
        if(currencyAmount >= amount)
            return true;
        return false;
    }

    public void BuyUnit(int amount)
    {
        if (IsCurrencyEnough(amount))
        {
            currencyAmount -= amount;
            OnCurrencyChanged?.Invoke(currencyAmount);
        }
        else
        {
            OnCurrencyNotEnough?.Invoke();
        }
    }

    public void SellUnit(int amount)
    {
        currencyAmount += amount;
        OnCurrencyChanged?.Invoke(amount);
    }
}
