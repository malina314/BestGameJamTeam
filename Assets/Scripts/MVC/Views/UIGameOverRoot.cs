using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIGameOverRoot : UIRoot
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI goodbyeMessage;
    [SerializeField] private Button returnToMenu;
    public override void InitView()
    {
        base.InitView();
        returnToMenu.onClick.AddListener(ResetGame);
    }
    public override void HideView()
    {
        base.HideView();
    }

    public void ResetGame()
    {
        Time.timeScale = 1f;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void UpdateTitle(string value)
    {
        title.text = value;
    }

    public void UpdateMessage(string value)
    {
        goodbyeMessage.text = value;
    }
}
