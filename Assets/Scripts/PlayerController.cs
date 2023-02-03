using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3f;
    public GameObject playerBulletPrefabs;
    public GameObject boomPrefab;

    public Gun gun;
    public System.Action<Power> onGetPower;
    
    public void Init(Gun gun)
    {
        this.gun = gun;
        this.gun.gameObject.transform.SetParent(this.transform);
        this.gun.transform.localPosition = Vector3.zero;
    }
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(h, v, 0);
        //Debug.Log(dir);
        this.transform.Translate(dir.normalized * this.speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.Shoot();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            this.Boom();
        }

    }

    private void Boom()
    {
        GameObject go = Instantiate(this.boomPrefab);
        go.GetComponent<Boom>().Init();
        go.transform.position = Vector3.zero;
    }

    private void Shoot()
    {
        //내가 가지고 있는 Gun이 총알을 발사
        this.gun.Shoot();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Power")
        {
            Debug.Log("아이템획득");

            Power power = collision.gameObject.GetComponent<Power>();

            //멀티건으로 변경
            this.onGetPower(power);

            Destroy(collision.gameObject); //아이템 제거
        }
    }

    public void AttachGun(Gun gun)
    {
        this.gun = gun;
        this.gun.transform.SetParent(this.transform);
    }

    public void DettackGun()
    {
        //자식으로 붙은 Gun게임 오브젝트를 제거
        Destroy(this.gun.gameObject);
        Debug.LogFormat("gun : {0}", this.gun);
        this.gun = null;
    }
}
