using Game.Menu;
using UnityEngine;

namespace Assets.Coding
{
    public class GameManager : MonoBehaviour
    {
        AudioManager _audioManager;
        public bool isMute = false;
        public float saveVolume = 0;
        
        void Awake()
        {
            _audioManager = FindObjectOfType<AudioManager>();
        }
        
        void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (isMute)
                {
                    UnMute();
                    isMute = false;
                }
                else
                {
                    Mute();
                    isMute = true;
                }
            }
        }

        void SaveVolume()
        {
            saveVolume = _audioManager.source.volume;
        }

        void Mute()
        {
            // _source.volume = 0;
        }

        void UnMute()
        {
            // _source.volume = saveVolume;
        }
    }
}
