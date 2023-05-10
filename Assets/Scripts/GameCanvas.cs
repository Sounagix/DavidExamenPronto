using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;

    [SerializeField]
    private TextMeshProUGUI winTitleText;

    [SerializeField]
    private Button playAgainButton;


    private void Start()
    {
        SetUp();
    }

    private void SetUp()
    {
        if (panel == null)
            panel = transform.GetChild(1).gameObject.transform.GetChild(0).gameObject;

        if (winTitleText == null)
            winTitleText = panel.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();

        if (playAgainButton == null)
            playAgainButton = panel.transform.GetChild(1).gameObject.GetComponent<Button>();
    }

    public void WinPanel()
    {
        SetUp();
        panel.SetActive(true);
        winTitleText.transform.parent.gameObject.SetActive(true);
        winTitleText.text = "YOU WIN!";
    }

    public void LosePanel()
    {
        SetUp();
        panel.SetActive(true);
        winTitleText.transform.parent.gameObject.SetActive(true);
        winTitleText.text = "YOU LOSE!";
    }
}
