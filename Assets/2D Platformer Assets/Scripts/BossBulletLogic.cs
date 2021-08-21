using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletLogic : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlaySFX(2);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-speed * transform.localScale.x * Time.deltaTime, 0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerHealthLogic.instance.DealDamage();
        }

        AudioManager.instance.PlaySFX(1);

        Destroy(gameObject);
    }


}
