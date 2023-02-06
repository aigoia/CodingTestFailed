using UnityEngine;

namespace Assets.Coding
{
    public class Coin : MonoBehaviour
    {
        public readonly int CoinScore = 100;
        UIManager _uiManager;
        
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
            _uiManager.Score += CoinScore;
            _uiManager.ScoreText.text = _uiManager.Score.ToString();
        }

        void Effect()
        {
            // add Effect
        }
    }
}
