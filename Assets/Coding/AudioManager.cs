using UnityEngine;

namespace Game.Menu
{
    public class AudioManager : MonoBehaviour
    {
        public AudioSource source;
        public bool isMute = false;
        public float saveVolume = 0;
        
        AudioManager _audioManager;
        
        void Awake()
        {
            source = GetComponent<AudioSource>();
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