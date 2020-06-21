using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {
    
    float vertical;
    float horizontal;
    
    float verticalRaw;
    float horizontalRaw;
    
    public float speedForce;

    Vector3 targetRotation;
    
    private float rotationSpeed = 10f;
    private float speed = 250f;


    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void FixedUpdate() {
        
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        horizontalRaw = Input.GetAxisRaw("Horizontal");
        verticalRaw = Input.GetAxisRaw("Vertical");

        Vector3 input = new Vector3(horizontal, 0, vertical);
        Vector3 inputRaw = new Vector3(horizontalRaw, 0, verticalRaw);

        if(input.sqrMagnitude > 1f)
        {
            input.Normalize();
        }

        if(inputRaw.sqrMagnitude>1f)
        {
            inputRaw.Normalize();
        }
        
        if(inputRaw != Vector3.zero)
        {
            targetRotation = Quaternion.LookRotation(input).eulerAngles;    
        }

        rb.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(targetRotation.x,Mathf.Round(targetRotation.y / 45) * 45, targetRotation.z) , Time.deltaTime * rotationSpeed);

        Vector3 vel = input * speed * Time.deltaTime;
        rb.velocity = vel;

    }
    void OnCollisionEnter(Collision myCollision) {
        // определение столкновения с двумя разноименными объектами
        if (myCollision.gameObject.tag == "Enemy") {    // Если сталкнулся с dangeon master
            Debug.Log("Есть пробитие");
        }
    
    }
}
