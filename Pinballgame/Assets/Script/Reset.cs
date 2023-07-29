using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public Transform position;
    public Collider bolaCol;
    public GameObject bola;

    private Transform bolaPosition;
    

    private void Start()
    {
        bolaPosition = bola.GetComponent<Transform>();
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other == bolaCol)
        {
            bolaPosition.position = position.position;
        }
    }
}
