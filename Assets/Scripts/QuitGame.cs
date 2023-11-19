using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{
	public Button QuitButton;
    void Start()
    {
        Button btn = QuitButton.GetComponent<Button>();
		btn.onClick.AddListener(QuitGameSystem);
    }

    void QuitGameSystem()
	{
		Application.Quit();
		Debug.Log("Quit Game!");
	}
}
