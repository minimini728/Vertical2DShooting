using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyMain : MonoBehaviour
{   
    public Button btnStart;
    public Button btnGun1; //기본
    public Button btnGun2; //멀티
    public Text textSelectedGun;
    private GameEnums.eGunType selectedGunType;

    public GameEnums.eGunType SelectedGunType
    {
        set
        {
            this.selectedGunType = value;
            this.textSelectedGun.text = string.Format("{0}를 선택했습니다.", this.selectedGunType);
        }
    }
    void Start()
    {
        this.SelectedGunType = GameEnums.eGunType.Default;

        this.btnStart.onClick.AddListener(() =>
        {   
            Debug.Log("게임시작");
            //선택된 건의 타입 출력
            Debug.Log(this.selectedGunType);
            AsyncOperation oper = SceneManager.LoadSceneAsync("Game");
            oper.completed += (obj) =>
            {
                //Game씬이 로드됨
                GameMain gameMain = GameObject.FindObjectOfType<GameMain>();
                gameMain.Init(selectedGunType);
            };
        });
        
        this.btnGun1.onClick.AddListener(() =>
        {
            Debug.Log("기본건 선택");
            this.SelectedGunType = GameEnums.eGunType.Default;
        });
        
        this.btnGun2.onClick.AddListener(() =>
        {
            Debug.Log("멀티건 선택");
            this.SelectedGunType = GameEnums.eGunType.Multiple;
        });


    }

}
