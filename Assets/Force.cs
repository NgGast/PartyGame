using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Zolupa
{
    

    public class Force : MonoBehaviour
    {
        public Vector3 direction;
        public float speed;

        void FixedUpdate() {
            transform.Translate(direction.normalized * speed);
        }
    }
}