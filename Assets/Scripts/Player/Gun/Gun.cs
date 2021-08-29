using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public InputReader reader;
    public PlayerLife player;
    private Vector2 direction;
    [SerializeField] private float ShotTime = .5f;
    [SerializeField] private float ShotForce = 5f;
    private float currentTime = .5f;

    public GameObject bulletPrefab;

    private void OnEnable()
    {
        reader.ShootEvent += Fire;
        ShotTime = player.ShotTime;
    }

    private void OnDisable()
    {
        reader.ShootEvent -= Fire;
    }

    void Update()
    {
        Shoot();

    }

    private void Fire(Vector2 dir)
    {
        direction = dir;
        currentTime = 0;
    }

    private void Shoot()
    {
        if (currentTime < 0 && direction != Vector2.zero)
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
            gb.GetComponent<Rigidbody2D>().velocity = direction * ShotForce;
        }
        currentTime -= Time.deltaTime;
    }
}
