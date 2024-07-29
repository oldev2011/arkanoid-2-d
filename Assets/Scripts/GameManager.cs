using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TMP_Text ScoreText;
    public Slider Slider;
    public GameObject[] Blocks;

    internal int _score = 0;
    internal int _lives = 5;

    private void Awake()
    {
        Blocks = GameObject.FindGameObjectsWithTag("Cub's");
    }
    private void Update()
    {
        ScoreText.text = "Score: " + _score.ToString();
        Slider.value = _lives;
        if (Blocks.Count(Block => Block != null) == 0) 
        {
            SceneManager.LoadScene(1);
        }
    }
}