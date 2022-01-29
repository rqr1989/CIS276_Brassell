using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Vector3 cameraOffset;

    //Start method
    private void Start()
    {
        cameraOffset = transform.position - player.transform.position;
        //player2.colorName = "Blue";
    }

    private void Update()
    {
        transform.position = cameraOffset + player.transform.position;
    }
}
