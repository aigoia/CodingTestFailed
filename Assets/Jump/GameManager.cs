using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Action = System.Action;

namespace Assets.Jump
{
    public enum CoinType
    { 
        Normal, Easy, Hard
    }
    
    public class GameManager : MonoBehaviour
    {
        [SerializeField] CoinType _difficultType;
        public List<Coin> Coins;
        
        void Awake()
        {
            Coins = FindObjectsOfType<Coin>().ToList();
        }
        
        void Start()
        {
            SetCoinColor();
        }

        void SetCoinColor()
        {
            void Normal()
            {
                print("Normal");
            }
            
            void Easy()
            {
                print("Easy");
            }
            
            void Hard()
            {
                print("Hard");
            }
            
            Action coinColor = _difficultType switch
            {
                CoinType.Normal => Normal,
                CoinType.Easy => Easy,
                CoinType.Hard => Hard,
                _ => Normal
            };
            
            coinColor!.Invoke();
        }
        
    }
}
