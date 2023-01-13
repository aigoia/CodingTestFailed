using UnityEngine;

namespace Game.Menu
{
    public class AudioManager : MonoBehaviour
    {
        public AudioSource source;

        void Awake()
        {
            source = GetComponent<AudioSource>();
        }
    }
}