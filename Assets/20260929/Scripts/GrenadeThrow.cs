using UnityEngine;

public class GrenadeThrow : MonoBehaviour
{
    public GrenadePool grenadePool;

    public Transform throwPoint;

    public float throwPower = 10f;
    public float throwUpPower = 5f;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            ThrowGrenade();
        }
    }


    void ThrowGrenade()
    {
        // 풀에서 수류탄 가져오기
        GameObject grenade = grenadePool.GetGrenade();

        // 사용할 수 있는 수류탄이 없으면 종료
        if (grenade == null)
        {
            return;
        }


        // 위치와 회전 설정
        grenade.transform.position = throwPoint.position;
        grenade.transform.rotation = throwPoint.rotation;


        // 수류탄 활성화
        grenade.SetActive(true);


        Rigidbody rb = grenade.GetComponent<Rigidbody>();


        // 이전에 사용했던 물리값 초기화
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;


        // 던질 방향 계산
        Vector3 throwDirection =
            throwPoint.forward * throwPower +
            Vector3.up * throwUpPower;


        // 수류탄 던지기
        rb.AddForce(throwDirection, ForceMode.Impulse);
    }
}