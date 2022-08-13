using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetCustomers : MonoBehaviour
{
    [SerializeField] private Text customers;
    [SerializeField] private Text coins;
    private int customersCount;
    public RandomGenerate notPickedCustomers;
    private int coinsCount;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Customer"))
        {
            Destroy(other.gameObject);
            customersCount++;
            customers.text = "Customers: " + customersCount;
        }
        else if (other.CompareTag("Station") && customersCount>0)
        {
            for(int i = 0; i < customersCount; i++)
            {
                coinsCount += Random.Range(5, 30);
                Debug.Log(coinsCount);
            }
            notPickedCustomers.notPickedCustomers = 3-customersCount;
            customersCount = 0;
            customers.text = "Customers: " + customersCount;
            coins.text = "Coins: " + coinsCount;
        }
    }
}
