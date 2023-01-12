﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

namespace Game.Menu
{
    public enum WindowMode
    {
        Non, Nine, Ten,
    }
    
    public class AudioManager : MonoBehaviour
    {
        public AudioMixer audioMixer;
        public List<AudioClip> randomSoundList = new List<AudioClip>();
        public AudioSource Source;
        public AudioClip menu;
        public AudioClip wait;
        public AudioClip open;
        public AudioClip battleBase;
        public AudioClip battleStillness;
        public AudioClip battleDynamic;

        private bool _keepFadeIn;
        private bool _keepFadeOut; 
        private readonly WaitForSeconds _waitForSeconds = new WaitForSeconds(0.1f);
        private WaitForSeconds _wait = new WaitForSeconds(1f);
        public bool click = false;
        
        float maxVolumeFade = 1;
        float speedFade = 0.01f;
        public float durationTime = 1f;
        public float waitTime = 1.5f;
        public float waitMoreTime = 1.5f;
        public float delayTime = 5f;
        bool _notEnd = false;

        private static AudioManager _instance;

        public bool enemyMove = true;
        public bool fastMove = false;
        
        private void Awake()
        {
            Source = GetComponent<AudioSource>();

            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }
        }

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void PlaySound()
        {
            StartCoroutine(PlaySceneSound());
        }

        IEnumerator PlaySceneSound()
        {
            Scene thisScene = SceneManager.GetActiveScene();
            print(thisScene.name);
            
            while (_notEnd)
            {
                yield return null;
            }

            if (thisScene.name == "Menu")
            {
                Source.clip = menu;
                Invoke(nameof(Play), 0);
                Source.volume = 1;
                // Invoke(nameof(PlaySound), _source.clip.length + delayTime);
            }
            else if (thisScene.name == "Main")
            {
                // _source.clip = battleBase;
                // _source.clip = battleDynamic;
                // _source.clip = battleStillness;
                
                while (!click)
                {
                    print("Wait");
                    yield return null;
                }
                Invoke(nameof(RandomPlay), 0);
                Source.volume = 1;
                click = false;
                // Invoke(nameof(PlaySound), _source.clip.length + delayTime);
            }
            else if (thisScene.name == "Window")
            {
                Source.clip = wait;
                print("Play");
                Invoke(nameof(Play), waitTime);
                Source.volume = 1;
                // Invoke(nameof(PlaySound), _source.clip.length + delayTime);
            }
        }

        public void VolumeUp()
        {
            Source.volume = 1;
        }
        public void VolumeDown()
        {
            Source.volume = 0;
        }

        public void PlayWindow()
        {
            if (!_notEnd) return;

            Source.clip = wait;
            print("Play");
            Invoke(nameof(Play), waitTime);
            Source.volume = 1;
            // Invoke(nameof(PlaySound), _source.clip.length + delayTime);
        }

        void Play()
        {
            Source.Play();
        }

        void RandomPlay()
        {
            Source.clip = randomSoundList[Random.Range(0, randomSoundList.Count)];
                            Source.Play();
        }

        void PlayNextSong()
        {
            Source.clip = randomSoundList[Random.Range(0, randomSoundList.Count)];
            Source.Play();
            Invoke(nameof(PlayNextSong), Source.clip.length);
        }

        public void FadeInCaller()
        {
            _instance.StartCoroutine(FadeIn(1, speedFade, maxVolumeFade));
        }
        
        public void FadeOutCaller()
        {
            // _instance.StartCoroutine(FadeOut(1, speedFade));
            click = false;
            _instance.StartCoroutine(StartFade(Source, durationTime, 0));
        }

        IEnumerator FadeIn(int track, float speed, float maxVolume)
        {
            _keepFadeIn = true;
            _keepFadeOut = false;
            Source.volume = 0;
            var audioVolume = Source.volume;
            
            while (Source.volume < maxVolume && _keepFadeIn)
            {
                audioVolume += speed;
                Source.volume = audioVolume;
                yield return _waitForSeconds;
            }
        }

        public void FastMove()
        {
            fastMove = true;
        }

        public IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
        {
            float currentTime = 0;
            float start = audioSource.volume;

            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
                _notEnd = true;
                yield return null;
            }
            
            _notEnd = false;
            yield break;
        }

        IEnumerator FadeOut(int track, float speed)
        {
            _keepFadeIn = false;
            _keepFadeOut = true;
            
            var audioVolume = Source.volume;
            
            while (Source.volume >= 0.01f && _keepFadeIn)
            {
                audioVolume -= speed;
                Source.volume = audioVolume;
                yield return _waitForSeconds;
            }
        }
    }
}