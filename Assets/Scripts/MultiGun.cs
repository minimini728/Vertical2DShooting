using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiGun : Gun
{   
    [Tooltip("right fire point")]
    public Transform firePoint2; //right

    public override void Shoot()
    {
        //총알을 생성
        GameObject go1 = Instantiate(this.bulletPrefab); //left
        GameObject go2 = Instantiate(this.bulletPrefab); //right
        //위치 설정
        go1.transform.position = this.firePoint.position;
        go2.transform.position = this.firePoint2.position;
    }
}
