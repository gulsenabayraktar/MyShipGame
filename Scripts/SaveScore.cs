using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class SaveScore : MonoBehaviour
{
    [SerializeField] public int SceneNumber;
    public TextMeshProUGUI highScoreText;

    private void Start()
    {
        GetScore(SceneNumber);
    }

    void GetScore(int scene)
    {

        highScoreText.SetText("HighScore: " + PlayerPrefs.GetInt($"HighScore{scene}"));

    }
}
