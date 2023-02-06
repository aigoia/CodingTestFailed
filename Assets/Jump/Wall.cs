using UnityEngine;

namespace Assets.Jump
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
            if (_player == null) return;
            if (_player.GunShip == null) return;

            _player.IsRight = !_player.IsRight;
            _player.GunShip.rotation = Quaternion.Euler(-_player.GunShip.rotation.eulerAngles);
        }
    }
}
