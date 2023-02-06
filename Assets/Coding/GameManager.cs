using UnityEngine;
using Action = System.Action;

namespace Assets.Coding
{
    public enum CoinType
    {
        Red, Blue, Yellow, Green
    }
    
    public class GameManager : MonoBehaviour
    {
        [SerializeField] CoinType _coinType;
        
        void Awake()
        {
            
        }
        
        void Start()
        {
            SetCoin();
        }

        void SetCoin()
        {
            void Red()
            {
                print("Red");
            }
            
            void Blue()
            {
                print("Blue");
            }
            
            void Yellow()
            {
                print("Yellow");
            }

            void Green()
            {
                print("Green");
            }
            
            Action coinColor = _coinType switch
            {
                CoinType.Red => Red,
                CoinType.Blue => Blue,
                CoinType.Yellow => Yellow,
                CoinType.Green => Green,
                _ => Red
            };
            
            coinColor!.Invoke();
        }
        
    }
}
