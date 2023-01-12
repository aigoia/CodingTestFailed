using TMPro;
using UnityEngine;

namespace Assets.Coding
{
    public class UIManager : MonoBehaviour
    {
        public TextMeshProUGUI scoreText;
        public int Score = 0;

        void Awake()
        {
            scoreText = transform.Find("Score").GetComponent<TextMeshProUGUI>();
        }
    }
}
