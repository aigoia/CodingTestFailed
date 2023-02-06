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
            _player.IsRight = !_player.IsRight;
            _player.GunShip.rotation = Quaternion.Euler(-_player.GunShip.rotation.eulerAngles);
        }
    }
}
