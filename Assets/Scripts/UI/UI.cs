using System.Numerics;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI jellatinText;
    [SerializeField] private TextMeshProUGUI goldText;

    private void Awake()
    {
        if (jellatinText == null)
        {
            jellatinText = GameObject.Find("JellatinText").GetComponent<TextMeshProUGUI>();
        }

        if (goldText == null)
        {
            goldText = GameObject.Find("GoldText").GetComponent<TextMeshProUGUI>();
        }
    }

    private void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        // PlayerData의 문자열 값을 BigInteger로 변환
        BigInteger jellatin = BigInteger.Parse(DataManager.Instance.playerData.jellatin);
        BigInteger gold = BigInteger.Parse(DataManager.Instance.playerData.gold);

        UpdateJellatinUI(jellatin);
        UpdateGoldUI(gold);
    }

    public void UpdateJellatinUI(BigInteger jellatin)
    {
        jellatinText.text = FormatBigNumber(jellatin);
    }

    public void UpdateGoldUI(BigInteger gold)
    {
        goldText.text = FormatBigNumber(gold);
    }

    // 방치형 게임 형식의 숫자 포맷
    private string FormatBigNumber(BigInteger value)
    {
        if (value < 1000)
            return value.ToString();

        string[] suffixes = { "", "a", "b", "c", "d", "e", "f", "g", "h", "i" };
        int order = 0;
        BigInteger divisor = new BigInteger(1000);

        while (value >= divisor && order < suffixes.Length - 1)
        {
            value /= divisor;
            order++;
        }

        return $"{value}{suffixes[order]}";
    }
}
