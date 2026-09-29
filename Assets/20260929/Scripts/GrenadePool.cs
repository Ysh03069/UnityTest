using UnityEngine;
using System.Collections.Generic;

public class GrenadePool : MonoBehaviour
{
    public GameObject grenadePrefab;
    public int poolSize = 10;

    private List<GameObject> grenadePool = new List<GameObject>();


    void Start()
    {
        // 게임 시작 시 수류탄을 미리 생성
        for (int i = 0; i < poolSize; i++)
        {
            GameObject grenade = Instantiate(grenadePrefab);

            grenade.SetActive(false);

            grenadePool.Add(grenade);
        }
    }


    public GameObject GetGrenade()
    {
        // 비활성화되어 있는 수류탄 찾기
        for (int i = 0; i < grenadePool.Count; i++)
        {
            if (grenadePool[i].activeSelf == false)
            {
                return grenadePool[i];
            }
        }

        // 사용할 수 있는 수류탄이 없으면
        return null;
    }
}