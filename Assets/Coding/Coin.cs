using UnityEngine;

namespace Assets.Coding
{
    public class Coin : MonoBehaviour
    {
        public int coinScore = 100;
        
        private UIManager _uiManager;

        void Awake()
        {
            _uiManager = FindObjectOfType<UIManager>();
        }
        
        void OnTriggerEnter(Collider other)
        {
            gameObject.SetActive(false);
            
            PlusScore();
            Effect();
        }

        void PlusScore()
        {
            _uiManager.Score += coinScore;
            _uiManager.scoreText.text = _uiManager.Score.ToString();
        }

        void Effect()
        {
            
        }
    }
}
