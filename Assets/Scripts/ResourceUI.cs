using UnityEngine;
using UnityEngine.UI;

public class ResourceUI : MonoBehaviour {
    public Text amountText;
    public Resource resource;

    void UpdateAmountLabel() {
        this.amountText.text = this.resource.ResourcesOwned.ToString($"0 {this.resource.name}");
    }

    void Update() {
        UpdateAmountLabel();
    }
}