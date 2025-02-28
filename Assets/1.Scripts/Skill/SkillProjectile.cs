
using UnityEngine;
namespace IdleGame{


public class SkillProjectile : MonoBehaviour
{
    public float speed = 10f;  // ����ü �ӵ�
    public int damage = 20;    // ������
    public float maxDistance = 5f;  // �ִ� ��Ÿ�

    private Transform target;  // Ÿ��(���� ����� ��)
    private Vector3 startPosition;  // ����ü ���� ��ġ
    private Vector3 direction;  // �̵� ����

    void Start()
    {
        target = FindClosestEnemy();
        startPosition = transform.position;  // ���� ��ġ ����

        if (target != null)
        {
            // ���� ������ Ÿ�� ���� ����
            direction = (target.position - transform.position).normalized;
        }
        else
        {
            // ���� ������ ������(X ��� ����)���� �̵�
            direction = Vector3.right;
            transform.rotation = Quaternion.Euler(0, 0, -45f);  // Z�� -45�� ȸ��
        }
    }

    void Update()
    {
        // ����ü �̵�
        transform.position += direction * speed * Time.deltaTime;

        // ���� �ִ� ��� ȸ�� ����
        if (target != null)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 45f));

            // Ÿ�ٰ� �浹�ϸ� ����
            if (Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                ApplyDamage(target);
                Destroy(gameObject);
            }
        }

        // ��Ÿ��� �ʰ��ϸ� ����
        if (Vector3.Distance(startPosition, transform.position) >= maxDistance)
        {
            Destroy(gameObject);
        }
    }

    // ���� ����� ���� ã�� �Լ�
    Transform FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Transform closestEnemy = null;
        float minDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                closestEnemy = enemy.transform;
                minDistance = distance;
            }
        }

        return closestEnemy;
    }

    // ������ ���� �Լ�
    void ApplyDamage(Transform enemy)
    {
        EnemyStatus enemyScript = enemy.GetComponent<EnemyStatus>();  // �� ��ũ��Ʈ ��������
        if (enemyScript != null)
        {
            enemyScript.TakeDamage(damage);  // ������ ����
        }
    }
}
}