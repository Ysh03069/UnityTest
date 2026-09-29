using UnityEngine;
using System.Collections.Generic;

public class BulletPool : MonoBehaviour
{
    public GameObject bulletPrefab;

    public int poolSize = 20;

    private List<GameObject> bulletPool = new List<GameObject>();


    void Start()
    {
        // 시작할 때 총알을 미리 생성
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);

            bullet.SetActive(false);

            bulletPool.Add(bullet);
        }
    }


    public GameObject GetBullet()
    {
        // 사용하지 않는 총알 찾기
        for (int i = 0; i < bulletPool.Count; i++)
        {
            if (bulletPool[i].activeSelf == false)
            {
                return bulletPool[i];
            }
        }

        // 사용할 수 있는 총알이 없으면
        return null;
    }
}