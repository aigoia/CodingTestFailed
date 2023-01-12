using System.Collections;
using UnityEngine;

namespace Assets.Coding
{
    public class Player : MonoBehaviour
    {
        public Rigidbody rigidbody;
        public float Force = 500;
        public float Distace = 1000;
        public bool isJumping = false;
        public float waitTime = 2f;
        public float goDistance = 1000f;
        public float goTime = 5f;
        public float speed = 20f;
        
        void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
            
        }

        void Start()
        {
            
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (isJumping == false)
                {
                    StartCoroutine(Jump());
                }
            }
            
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        IEnumerator Jump()
        {
            isJumping = true;
            print("Jump");
            rigidbody.AddForce(transform.up * Force, ForceMode.Force);
            
            // 추후 시간이 되면 제대로된 메커니즘을 설계한다 
            yield return new WaitForSeconds(waitTime);

            isJumping = false;

        }
    }
}
