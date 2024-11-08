using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    [SerializeField] private ColorData enemyColor; 
    [SerializeField] private int damage = 1;
    [SerializeField] GameObject vfxFire;

    public static event Action<ColorData, int> OnEnter;
    public static event Action OnExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnEnter?.Invoke(enemyColor, damage);
            Destroy(this.gameObject);
            GameObject explosion = Instantiate(vfxFire, transform.position, transform.rotation);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnExit?.Invoke();
        }
    }
}