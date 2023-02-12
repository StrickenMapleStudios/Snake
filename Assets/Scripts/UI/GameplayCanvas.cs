using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayCanvas : MonoBehaviour
{
    [SerializeField]
    private RectTransform hud, gameOver;
    private HUD hudScript;

    private void Awake()
    {
        hudScript = hud.GetComponent<HUD>();
    }

    public HUD HUD
    {
        get { return hudScript; }
    }

    public GameObject GameOver
    {
        get { return gameOver.gameObject; }
    }
}
