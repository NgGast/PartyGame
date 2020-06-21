using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// объект BoxSpawn

public class BoxSpawn : MonoBehaviour
{
    public GameObject box;
    private Box _actionTarget;

    public float minXpos, maxXpos;
    public float Zpos;
    
    public float timeBetweenBoxes;
    public float timeBetweenBoxesUpadate;
    public int timeBetweenUpdate;
    
    public float speedUp;

    void Start()
    {
        _actionTarget = box.GetComponent<Box>();
        StartCoroutine(SpawnBox());
    }

    IEnumerator SpawnBox()
    {
        Zpos = GameObject.Find("BoxSpawner").transform.position.z;
        //get a random position on the x axis
        Vector3 boxPos = new Vector3(Random.Range(minXpos, maxXpos), 0, Zpos);

        //spawn the box
        Instantiate(box, boxPos, Quaternion.Euler(0, 0, 0));

        // В теории должен прибавлять скорость коробок на speedUp каждые 5 секунд
        InvokeRepeating("UpdateSpeed", timeBetweenUpdate, timeBetweenUpdate);
        //let the code wait a certain time
        yield return new WaitForSeconds(timeBetweenBoxes);

        StartCoroutine(SpawnBox());
    }

    void UpdateSpeed()
    {
        _actionTarget.UpdateSpeed(speedUp);

        if(timeBetweenBoxes >= 0.1f ){
            Debug.Log("Время уменьшено");
            timeBetweenBoxes -= timeBetweenBoxesUpadate;
        } else {
            Debug.Log("Достигнуто минимальное время спавна");
            timeBetweenBoxes = 0.1f;
        }
    }
}