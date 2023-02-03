using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyMain : MonoBehaviour
{   
    public Button btnStart;
    public Button btnGun1; //�⺻
    public Button btnGun2; //��Ƽ
    public Text textSelectedGun;
    private GameEnums.eGunType selectedGunType;

    public GameEnums.eGunType SelectedGunType
    {
        set
        {
            this.selectedGunType = value;
            this.textSelectedGun.text = string.Format("{0}�� �����߽��ϴ�.", this.selectedGunType);
        }
    }
    void Start()
    {
        this.SelectedGunType = GameEnums.eGunType.Default;

        this.btnStart.onClick.AddListener(() =>
        {   
            Debug.Log("���ӽ���");
            //���õ� ���� Ÿ�� ���
            Debug.Log(this.selectedGunType);
            AsyncOperation oper = SceneManager.LoadSceneAsync("Game");
            oper.completed += (obj) =>
            {
                //Game���� �ε��
                GameMain gameMain = GameObject.FindObjectOfType<GameMain>();
                gameMain.Init(selectedGunType);
            };
        });
        
        this.btnGun1.onClick.AddListener(() =>
        {
            Debug.Log("�⺻�� ����");
            this.SelectedGunType = GameEnums.eGunType.Default;
        });
        
        this.btnGun2.onClick.AddListener(() =>
        {
            Debug.Log("��Ƽ�� ����");
            this.SelectedGunType = GameEnums.eGunType.Multiple;
        });


    }

}
