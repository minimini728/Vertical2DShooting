using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMain : MonoBehaviour
{
    public GameObject[] gunPrefabs;
    public GameObject explosionPrefab;
    public PlayerController player;
    public Enemy[] enemies;
    public Text txtScore;

    private int score; // total

    public void Init(GameEnums.eGunType selectedGunType)
    {   
        foreach(Enemy enemy in this.enemies)
        {
            enemy.onExplode = (fxPos) =>
            {
                score += enemy.score;
                this.txtScore.text = score.ToString();

                //이펙트 생성
                GameObject go = Instantiate(this.explosionPrefab);
                go.transform.position = fxPos;
            };
        }

        this.player.onGetPower = (power) =>
        {
            if(this.player.gun.type == Gun.eType.Single)
            {
                this.player.DettackGun();
                //멀티건생성 -> AttachGun
                Gun gun = this.CreateGun(GameEnums.eGunType.Multiple);
                this.player.AttachGun(gun);
            }
            else
            {
                score += 200;
                this.txtScore.text = score.ToString();
            }
        };

        //총을 만든다
        Gun gun = this.CreateGun(selectedGunType);
        //플레이어에게 총을 지급한다
        this.player.Init(gun);
    }

    private Gun CreateGun(GameEnums.eGunType gunType)
    {
        int index = (int)gunType;
        GameObject prefab = this.gunPrefabs[index];
        GameObject go = Instantiate(prefab);
        Gun gun = go.GetComponent<Gun>();
        return gun;
    }
}
