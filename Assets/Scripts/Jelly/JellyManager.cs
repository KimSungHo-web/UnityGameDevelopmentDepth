using System.Collections.Generic;
using UnityEngine;

public class JellyManager : MonoBehaviour
{
    public List<JellyController> activeJellies = new List<JellyController>();
    public Transform spawnArea;
    public GameObject jellyPrefab;

    public void SpawnJelly(JellyData jellyData)
    {
        // ���� ��ȯ ��ġ ���� (���� ��ġ)
        Vector3 spawnPosition = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(-1.5f, 1.5f), 0);
        GameObject newJelly = Instantiate(jellyPrefab, spawnPosition, Quaternion.identity);
        JellyController jellyController = newJelly.GetComponent<JellyController>();

        // ���� ������ ����
        jellyController.Initialize(jellyData);

        // Ȱ�� ���� ����Ʈ�� �߰�
        activeJellies.Add(jellyController);
    }
}
