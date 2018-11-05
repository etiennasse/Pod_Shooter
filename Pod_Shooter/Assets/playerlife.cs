using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class playerlife : NetworkBehaviour {
    [SerializeField]
    public RectTransform healthbar;
    public const int maxlife = 100;
    private NetworkStartPosition[] spawnPoints;
    // Use this for initialization

    [SyncVar(hook ="UpdateLife")]
    int currentLife = maxlife;

	void Start () {
		if (isLocalPlayer)
        {
            spawnPoints = FindObjectsOfType<NetworkStartPosition>();

        }
	}


	
    public void TakeDamage(int damage)
    {
        if(isServer)
        {
            print("asdad");
            currentLife -= damage;
            if (currentLife <= 0)
            {
                currentLife = 0;
                Die();
            }
            
        }
    }

    private void UpdateLife(int newlife)
    {
        healthbar.sizeDelta = new Vector2(newlife, healthbar.sizeDelta.y);
    }

    void Die()
    {
        RpcRespawn();
    }

    [ClientRpc]
    public void RpcRespawn()
    {
        if (isLocalPlayer)
        {
            currentLife = maxlife;
            Vector3 spawnPoint = Vector3.zero;
            if (spawnPoint != null && spawnPoints.Length > 0)
            {
                spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            }
            transform.position = spawnPoint;
        }
    }
}
