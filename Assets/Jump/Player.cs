using System.Collections;
using UnityEngine;

namespace Assets.Jump
{
    public class Player : MonoBehaviour
    {
        Rigidbody _rigidbody;
        public Transform GunShip;

        public readonly float Force = 500;
        public readonly float WaitTime = 2f;
        public readonly float Speed = 20f;
        
        public bool IsJumping = false;
        public bool IsRight = true;
        
        void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            GunShip = transform.Find("GunShip");
        }

        void Update()
        {
            Click();
            GoAhead(IsRight ? Vector3.right : Vector3.left);
        }

        void Click()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (IsJumping == false)
                {
                    StartCoroutine(Jump());
                }
            }
        }

        void GoAhead(Vector3 direction)
        {
            transform.Translate(direction * Time.deltaTime * Speed);
            transform.rotation = Quaternion.Euler(Vector3.zero);
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
