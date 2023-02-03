using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleMain : MonoBehaviour
{
    public Text txtVersion;
    
    public void Init(string version)
    {
        this.txtVersion.text = version;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Lobby");
        }
    }

}
