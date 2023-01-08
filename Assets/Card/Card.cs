using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public float speed = 8f;
    public float lifeDuration = 2f;
    float lifeTimer;

    void Start()
    {
        lifeTimer = lifeDuration;
    }
    void UpdateLifeTimer()
    {
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0f)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        UpdateLifeTimer();
    }
}
