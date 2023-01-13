using UnityEngine;

namespace Game.Menu
{
    public enum WindowMode
    {
        Non, Nine, Ten,
    }
    
    public class AudioManager : MonoBehaviour
    {
        public AudioSource source;

        void Awake()
        {
            source = GetComponent<AudioSource>();
        }
    }
}