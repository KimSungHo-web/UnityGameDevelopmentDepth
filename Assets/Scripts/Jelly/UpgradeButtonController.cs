using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtonController : MonoBehaviour
{
    [SerializeField] private Animator JellyPanelAnimator;
    [SerializeField] private Animator PlantPanelAnimator;
    [SerializeField] private Button JellyPanelButton;
    [SerializeField] private Button PlantPanelButton;
    private bool isJellyPanelVisible = false;
    private bool isPlantPanelVisible = false;

    private void Start()
    {
        JellyPanelButton.onClick.AddListener(() => TogglePanel(JellyPanelAnimator, ref isJellyPanelVisible));
        PlantPanelButton.onClick.AddListener(() => TogglePanel(PlantPanelAnimator, ref isPlantPanelVisible));
    }

    private void TogglePanel(Animator panelAnimator, ref bool isPanelVisible)
    {
        if (isPanelVisible)
        {
            panelAnimator.SetTrigger("IsHide");
        }
        else
        {
            panelAnimator.SetTrigger("IsShow");
        }

        isPanelVisible = !isPanelVisible;
    }
}
