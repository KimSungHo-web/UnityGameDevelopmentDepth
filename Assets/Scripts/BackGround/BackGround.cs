using UnityEngine;

public class BackGround : MonoBehaviour
{
    [Header ("Clouds")]
    [SerializeField] private GameObject _clouds;
    [SerializeField] private float _cloudsSpeed; // ������ �ӵ�
    [SerializeField] private float _cloudsEnd; // ������ ������ ����
    private Vector3 _cloudsStartPosition; // ������ ���� ��ġ
   
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