using UnityEngine;

public class BackGround : MonoBehaviour
{
    [Header ("Clouds")]
    [SerializeField] private GameObject _clouds;
    [SerializeField] private float _cloudsSpeed; // 구름의 속도
    [SerializeField] private float _cloudsEnd; // 구름의 끝나는 지점
    private Vector3 _cloudsStartPosition; // 구름의 시작 위치
   
    private void Awake()
    {
        _clouds = transform.Find("Clouds").gameObject;

        _cloudsStartPosition = _clouds .transform.localPosition;
    }

    private void Update()
    {
        _clouds.transform.Translate(Vector3.right * _cloudsSpeed * Time.deltaTime);

        if (_clouds.transform.localPosition.x >= _cloudsEnd) 
        {
            ResetCloudPosition();
        }

    }

    private void ResetCloudPosition()
    {
        _clouds.transform.localPosition = _cloudsStartPosition;
    }
}