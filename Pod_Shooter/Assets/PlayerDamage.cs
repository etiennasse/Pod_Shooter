using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour {
    playerlife playerLife;
	// Use this for initialization
    public void TakeDamage(int damage)
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
