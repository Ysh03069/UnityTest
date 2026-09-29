using UnityEngine;

public class Gun : MonoBehaviour
{
    public BulletPool bulletPool;

    public Transform firePoint;

    public float bulletSpeed = 20f;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }


    void Fire()
    {
        // 풀에서 사용하지 않는 총알 가져오기
        GameObject bullet = bulletPool.GetBullet();

        // 남아있는 총알이 없으면 발사하지 않음
        if (bullet == null)
        {
            return;
        }


        // 총알 위치 설정
        bullet.transform.position = firePoint.position;

        // 총알 방향 설정
        bullet.transform.rotation = firePoint.rotation;


        // 총알 활성화
        bullet.SetActive(true);


        // Rigidbody 가져오기
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        // 총알 속도 설정
        rb.linearVelocity = firePoint.forward * bulletSpeed;
    }
}