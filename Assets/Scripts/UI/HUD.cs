using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField]
    private RectTransform lengthText, scoreText;

    private TextMeshProUGUI length, score;

    private void Awake()
    {
        length = lengthText.GetComponent<TextMeshProUGUI>();
        score = scoreText.GetComponent<TextMeshProUGUI>();
    }

    public void RefreshInfo(int lengthValue, int scoreValue)
    {
        length.text = string.Format("Length: {0}", lengthValue);
        score.text = string.Format("Score: {0}", scoreValue);
    }
}
