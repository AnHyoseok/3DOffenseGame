using UnityEngine;
using System.Collections.Generic;

namespace IdleGame{
public class DropManager : MonoBehaviour
{
    // �̱��� �ν��Ͻ�
    public static DropManager Instance { get; private set; }

    public List<DropTable> dropTables;

    private void Awake()
    {
        // �̱��� �ν��Ͻ� ����
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("DropManager �ν��Ͻ��� �̹� �����մϴ�. ���ο� �ν��Ͻ��� ���õ˴ϴ�.");
            Destroy(gameObject);
        }
    }
    public void DropItem(Vector3 dropPosition)
    {
        // 1. ��ü ��� ���̺����� �ϳ��� ���̺��� Ȯ�������� ����
        DropTable selectedTable = GetRandomDropTable();

        if (selectedTable != null)
        {
            // 2. ���õ� ���̺����� �������� Ȯ�������� ����
            Item droppedItem = GetRandomItemFromTable(selectedTable);

            if (droppedItem != null)
            {
                // 3. ������ ���
                Instantiate(droppedItem.itemPrefab, dropPosition, Quaternion.identity);
                Debug.Log($"����� ������: {droppedItem.itemName}");
            }
        }
    }

    private DropTable GetRandomDropTable()
    {
        float totalRate = 0f;
        foreach (var table in dropTables)
        {
            totalRate += table.dropRate;
        }

        float randomValue = Random.Range(0f, totalRate);
        float cumulative = 0f;

        foreach (var table in dropTables)
        {
            cumulative += table.dropRate;
            if (randomValue <= cumulative)
            {
                return table;
            }
        }

        return null;
    }

    private Item GetRandomItemFromTable(DropTable table)
    {
        float totalChance = 0f;
        foreach (var item in table.items)
        {
            totalChance += item.dropChance;
        }

        float randomValue = Random.Range(0f, totalChance);
        float cumulative = 0f;

        foreach (var item in table.items)
        {
            cumulative += item.dropChance;
            if (randomValue <= cumulative)
            {
                return item;
            }
        }

        return null;
    }
}
}