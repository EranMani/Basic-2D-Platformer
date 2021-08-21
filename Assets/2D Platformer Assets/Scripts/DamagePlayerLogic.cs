using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (gameObject.transform.name == "Death_Area")
            {
                LevelManager.instance.RespawnPlayer();
            }
            else
            {
                PlayerHealthLogic.instance.DealDamage();
            }
            
        }
    }
}
