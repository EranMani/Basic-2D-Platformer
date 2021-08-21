using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTankHitboxLogic : MonoBehaviour
{
    public BossTankLogic bossTank;

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
        if (other.tag == "Player" && PlayerLogic.instance.transform.position.y > transform.position.y)
        {
            bossTank.TakeHit();

            PlayerLogic.instance.Bounce();

            gameObject.SetActive(false);
        }
    }
}
