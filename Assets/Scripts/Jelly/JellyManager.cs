using System.Collections.Generic;
using UnityEngine;

public class JellyManager : MonoBehaviour
{
    public List<JellyController> activeJellies = new List<JellyController>();
    public Transform spawnArea;
    public GameObject jellyPrefab;

    public void SpawnJelly(JellyData jellyData)
    {
        // 젤리 소환 위치 설정 (랜덤 위치)
        Vector3 spawnPosition = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(-1.5f, 1.5f), 0);
        GameObject newJelly = Instantiate(jellyPrefab, spawnPosition, Quaternion.identity);
        JellyController jellyController = newJelly.GetComponent<JellyController>();

        // 젤리 데이터 설정
        jellyController.Initialize(jellyData);

        // 활성 젤리 리스트에 추가
        activeJellies.Add(jellyController);
    }
}
