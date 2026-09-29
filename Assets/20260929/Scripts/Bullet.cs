using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 2f;

    private float timer;


    private void OnEnable()
    {
        // 총알이 다시 활성화될 때마다
        // 타이머 초기화
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
        // 무언가와 충돌해도 비활성화
        gameObject.SetActive(false);
    }
}