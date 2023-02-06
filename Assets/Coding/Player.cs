using System.Collections;
using UnityEngine;

namespace Assets.Coding
{
    public class Player : MonoBehaviour
    {
        Rigidbody _rigidbody;

        public readonly float Force = 500;
        public readonly float Distance = 1000;
        public readonly float WaitTime = 2f;
        public readonly float GoDistance = 1000f;
        public readonly float GoTime = 5f;
        public readonly float Speed = 20f;
        
        public bool IsJumping = false;
        public bool IsRight = true;
        public Transform GunShip;
        
        void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            GunShip = transform.Find("GunShip");
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (IsJumping == false)
                {
                    StartCoroutine(Jump());
                }
            }

            GoAhead(IsRight ? Vector3.right : Vector3.left);
            transform.rotation = Quaternion.Euler(Vector3.zero);
        }

        void GoAhead(Vector3 direction)
        {
            transform.Translate(direction * Time.deltaTime * Speed);
        }
        
        IEnumerator Jump()
        {
            IsJumping = true;
            print("Jump");
            _rigidbody.AddForce(transform.up * Force, ForceMode.Force);
            
            yield return new WaitForSeconds(WaitTime);

            IsJumping = false;
        }
    }
}
