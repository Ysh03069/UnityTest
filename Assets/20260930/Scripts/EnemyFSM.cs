using System.Collections;
using UnityEngine;

// 몬스터 유한상태머신
public class EnemyFSM : MonoBehaviour
{
    // 몬스터 상태
    enum EnemyState
    {
        Idle,
        Move,
        Attack,
        Return,
        Damaged,
        Die
    }

    EnemyState state;

    [Header("플레이어")]
    [SerializeField] private Transform player;

    [Header("이동 설정")]
    [SerializeField] private float moveSpeed = 3f;

    [Header("범위 설정")]
    [SerializeField] private float detectionRange = 10f; // 탐지 범위
    [SerializeField] private float attackRange = 1f;     // 공격 범위
    [SerializeField] private float returnRange = 30f;    // 최대 추격 범위

    [Header("공격 설정")]
    [SerializeField] private float attackDelay = 2f;     // 공격 간격
    [SerializeField] private int attackDamage = 10;

    [Header("체력")]
    [SerializeField] private int maxHP = 100;

    private int currentHP;

    // 몬스터의 처음 위치
    private Vector3 startPosition;

    // 공격 시간 체크
    private float attackTimer;


    void Start()
    {
        // 처음 위치 저장
        startPosition = transform.position;

        // 체력 초기화
        currentHP = maxHP;

        // 몬스터 상태 초기화
        state = EnemyState.Idle;
    }

    void Update()
    {
        switch (state)
        {
            case EnemyState.Idle:
                Idle();
                break;

            case EnemyState.Move:
                Move();
                break;

            case EnemyState.Attack:
                Attack();
                break;

            case EnemyState.Return:
                Retrun();
                break;

            case EnemyState.Damaged:
                Damaged();
                break;

            case EnemyState.Die:
                Die();
                break;
        }
    }


    private void Idle()
    {
        // 1. 플레이어와 일정 범위가 되면 이동상태로 변경
        // 2. 플레이어와 몬스터 거리 계산
        // 3. detectionRange 안에 들어오면 Move 상태로 변경
    }


    private void Move()
    {
        // 1. 플레이어 방향 구하기

        // 2. 플레이어 방향으로 이동
        // CharacterController를 이용해서 구현 예정

        // 3. 플레이어와의 거리가 attackRange 이하라면
        // Attack 상태로 변경

        // 4. 처음 위치에서 returnRange 이상 멀어졌다면
        // Return 상태로 변경
    }


    private void Attack()
    {
        // 1. 플레이어와 거리 계산

        // 2. attackRange 밖으로 나갔다면
        // Move 상태로 변경

        // 3. attackDelay마다 플레이어 공격

        // 4. 플레이어에게 attackDamage만큼 데미지
    }


    private void Retrun()
    {
        // 1. 처음 위치 방향 구하기

        // 2. 처음 위치를 향해서 이동

        // 3. 처음 위치에 거의 도착했다면
        // Idle 상태로 변경
    }


    private void Damaged()
    {
        // 이 함수에서 매 프레임 코루틴을 실행하면 안 됨

        // TakeDamage() 같은 별도의 함수에서
        // Damaged 상태로 변경하고

        // DamagedCoroutine() 실행 예정
    }


    private void Die()
    {
        // Die 상태에 들어왔을 때
        // DieCoroutine() 실행 예정

        // 일정 시간 후
        // Destroy(gameObject);
    }


    // 데미지를 받는 함수
    public void TakeDamage(int damage)
    {
        // currentHP 감소

        // HP가 0 이하라면
        // Die 상태로 변경

        // 살아있다면
        // Damaged 상태로 변경
    }


    IEnumerator DamagedCoroutine()
    {
        // 피격 상태

        // 일정 시간 대기

        // 이전 상태 또는 Idle/Move 상태로 복귀

        yield return null;
    }


    IEnumerator DieCoroutine()
    {
        // 죽는 애니메이션 등을 처리

        // 일정 시간 대기

        // 몬스터 삭제

        yield return null;
    }
}