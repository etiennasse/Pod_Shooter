using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour , Damagable {
    playerlife playerLife;

    public void DealDamage(int damage)
    {
        playerLife.TakeDamage(damage);
    }



	void Start () {
        playerLife = GetComponent<playerlife>();
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
