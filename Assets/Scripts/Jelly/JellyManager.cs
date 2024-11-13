using System.Collections.Generic;
using UnityEngine;

public class JellyManager : MonoBehaviour
{
    public List<JellyController> activeJellies = new List<JellyController>();
    [SerializeField] private Canvas parentCanvas;
    public Transform spawnArea;


    public void SpawnJelly(JellyData jellyData)
    {
        if (jellyData.jellyPrefab == null)
        {
            Debug.LogError("jellyPrefab�� �Ҵ���� �ʾҽ��ϴ�!");
            return;
        }

        GameObject newJelly = Instantiate(jellyData.jellyPrefab, parentCanvas.transform);

        Vector3 spawnLocalPosition = new Vector3(Random.Range(-70f, -18f), Random.Range(70f, 14f), 0);
        newJelly.GetComponent<RectTransform>().localPosition = spawnLocalPosition;

        JellyController jellyController = newJelly.GetComponent<JellyController>();
        if (jellyController == null)
        {
            Debug.LogError("JellyController ��ũ��Ʈ�� ã�� �� �����ϴ�!");
            return;
        }

        jellyController.Initialize(jellyData);

        activeJellies.Add(jellyController);

        Debug.Log($"{jellyData.jellyName} ������ UI ĵ������ ���������� ��ȯ�Ǿ����ϴ�.");
    }
}
