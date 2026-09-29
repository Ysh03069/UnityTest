using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float lifeTime = 3f;

    private float timer;


    private void OnEnable()
    {
        // 다시 사용할 때마다 시간 초기화
        timer = 0f;
    }


    void Update()
    {
        timer += Time.deltaTime;

        // 일정 시간이 지나면 비활성화
        if (timer >= lifeTime)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }
}