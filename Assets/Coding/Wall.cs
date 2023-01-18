using UnityEngine;

namespace Assets.Coding
{
    public class Wall : MonoBehaviour
    {
        Player _player;
        
        
        void Awake()
        {
            _player = FindObjectOfType<Player>();
        }

        void OnTriggerEnter(Collider other)
        {
            _player.isRight = !_player.isRight;
            _player.gunShip.rotation = Quaternion.Euler(-_player.gunShip.rotation.eulerAngles);
        }
    }
}
