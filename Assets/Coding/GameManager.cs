using System;
using Game.Menu;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Action = System.Action;

namespace Assets.Coding
{
    public enum CoinType
    {
        Default, Red, Blue, Yellow, Green
    }
    
    public class GameManager : MonoBehaviour
    {
        [SerializeField] CoinType _coinType;
        
        void Start()
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
                _ => default
            };
            
            coinColor!.Invoke();
        }
    }
}
