using TMPro;
using UnityEngine;

namespace Assets.Jump
{
    public class UIManager : MonoBehaviour
    {
        public TextMeshProUGUI ScoreText;
        public int Score = 0;

        void Awake()
        {
            ScoreText = transform.Find("Score").GetComponent<TextMeshProUGUI>();
        }
    }
}
