using System.Collections;
using UnityEngine;

namespace Assets.Coding
{
    public class Player : MonoBehaviour
    {
        public Rigidbody rigidbody;
        public float force = 500;
        public float distace = 1000;
        public bool isJumping = false;
        public float waitTime = 2f;
        public float goDistance = 1000f;
        public float goTime = 5f;
        public float speed = 20f;

        public bool isRight = true;
        public Transform gunShip;
        
        void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
            gunShip = transform.Find("GunShip");
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

            if (isRight)
            {
                GoAhead(Vector3.right);    
            }
            else
            {
                GoAhead(Vector3.left);
            }
            
            transform.rotation = Quaternion.Euler(Vector3.zero);
        }

        void GoAhead(Vector3 direction)
        {
            transform.Translate(direction * Time.deltaTime * speed);
        }
        
        IEnumerator Jump()
        {
            isJumping = true;
            print("Jump");
            rigidbody.AddForce(transform.up * force, ForceMode.Force);
            
            yield return new WaitForSeconds(waitTime);

            isJumping = false;

        }
    }
}
