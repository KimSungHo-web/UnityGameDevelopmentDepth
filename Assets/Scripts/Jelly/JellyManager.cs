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
            Debug.LogError("jellyPrefab이 할당되지 않았습니다!");
            return;
        }

        GameObject newJelly = Instantiate(jellyData.jellyPrefab, parentCanvas.transform);

        Vector3 spawnLocalPosition = new Vector3(Random.Range(-70f, -18f), Random.Range(70f, 14f), 0);
        newJelly.GetComponent<RectTransform>().localPosition = spawnLocalPosition;

        JellyController jellyController = newJelly.GetComponent<JellyController>();
        if (jellyController == null)
        {
            Debug.LogError("JellyController 스크립트를 찾을 수 없습니다!");
            return;
        }

        jellyController.Initialize(jellyData);

        activeJellies.Add(jellyController);

        Debug.Log($"{jellyData.jellyName} 젤리가 UI 캔버스에 성공적으로 소환되었습니다.");
    }
}
