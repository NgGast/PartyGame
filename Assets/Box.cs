using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// объект Box

public class Box : MonoBehaviour
{
    private float minSize = 1.7f; //minimum size
    private float maxSize = 2; //maximum size
    private float moveSpeed = 2f;
    
    void Start()
    {
        
        

        //changes the size of the object to random values
        transform.localScale = new Vector3(Random.Range(minSize, maxSize), Random.Range(minSize, maxSize), Random.Range(minSize, maxSize));
    }

    void Update()
    {
        //moves the box in -z axis
        transform.Translate(new Vector3(0, 0, 1) * moveSpeed * Time.deltaTime);

        // В теории должен прибавлять скорость коробок на speedUp каждые 5 секунд
        // InvokeRepeating("UpdateSpeed", 5, 5);
        
        //destroys gameobject after a number of seconds (OPTIONAL BUT RECOMMENDED)
        Destroy(gameObject, 15);
        
    }

    public void UpdateSpeed(float speedUp)
    {
        moveSpeed += speedUp;
        Debug.Log(moveSpeed);
        
    }
}