using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float ShotTime = .5f;
    [SerializeField] private float ShotForce = 5f;
    private float currentTime = .5f;

    [SerializeField] private float SightRadius;
    [SerializeField] private LayerMask playerLayer;

    void Update()
    {
        if (Physics2D.OverlapCircle((Vector2)this.transform.position, SightRadius, playerLayer))
        {
            Shoot();
        }

    }
    private void Shoot()
    {
        if (currentTime < 0 )
        {
            currentTime = ShotTime;
            GameObject gb = gameObject.GetComponent<ObjectPooler>().GetPooledObject();
            if (gb == null)
            {
                return;
            }
            else
            {
                gb.transform.position = this.transform.position;
                gb.transform.rotation = this.transform.rotation;
                gb.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                gb.SetActive(true);
            }
            Vector2 direction = Physics2D.OverlapCircle((Vector2)this.transform.position, SightRadius, playerLayer).gameObject.transform.position - this.transform.position;
            gb.GetComponent<Rigidbody2D>().velocity = direction * ShotForce;
        }
        currentTime -= Time.deltaTime;
    }
}
