using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public GameObject cardPrefab;
    public Camera playerCamera;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Fire!");
            GameObject cardObject = Instantiate(cardPrefab);
            cardObject.transform.position = playerCamera.transform.position + playerCamera.transform.forward;
            cardObject.transform.rotation = playerCamera.transform.rotation;

        }
    }
}
