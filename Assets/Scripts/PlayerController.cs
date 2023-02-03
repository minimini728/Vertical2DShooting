using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3f;
    public GameObject playerBulletPrefabs;

    public Gun gun;
    
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

    }

    private void Shoot()
    {
        //내가 가지고 있는 Gun이 총알을 발사
        this.gun.Shoot();
    }
}
