using UnityEngine;
using UnityEngine.UI;

public class Producer : MonoBehaviour {
    public ProductionUnit productionUnit;
    public Text currentLevelText;
    public Text costText;
    public Text gainText;
    private float _elapsedTime;
    public Resource resource;

    private bool CanGetUpgrades => resource.ResourcesOwned >= productionUnit.originalCost;

    void Start() {
        currentLevelText.text = productionUnit.lvl.ToString("LVL 0");
        costText.text = $"{productionUnit.CurrentCost(this.Level)}";
        gainText.text = productionUnit.resourcesProduced.ToString("+0 /SEC");
        costText.color = Color.red;
        gainText.color = Color.red;
        UpdateLevelText();
    }

    void Update() {
        this._elapsedTime += Time.deltaTime;
        if (this._elapsedTime >= this.productionUnit.productionTime) {
            ProduceFaith();
            this._elapsedTime -= this.productionUnit.productionTime;
        }
        
        if (CanGetUpgrades) {
            costText.color = Color.black;
            gainText.color = Color.black;
        } else if (!CanGetUpgrades) {
            costText.color = Color.red;
            gainText.color = Color.red;
        }
    }
    
    void ProduceFaith() {
        resource.ResourcesOwned += Mathf.RoundToInt(this.productionUnit.resourcesProduced * this.Level);
    }

    int Level {
        get => PlayerPrefs.GetInt(this.productionUnit.name, 0);
        set {
            PlayerPrefs.SetInt(this.productionUnit.name, value);
            UpdateLevelText();
        }
    }

    void UpdateLevelText() {
        this.currentLevelText.text = this.Level.ToString("LVL 0");
    }

    public void LvlUp() {
        if (resource.ResourcesOwned >= productionUnit.CurrentCost(this.Level)) {
            resource.ResourcesOwned -= productionUnit.CurrentCost(this.Level);
            this.Level += 1;
            costText.text = $"{productionUnit.CurrentCost(this.Level)}";
        }
    }

    public void OnClickBoost() {
        if (resource.ResourcesOwned >= productionUnit.CurrentCost(this.Level)) {
            resource.ResourcesOwned -= productionUnit.CurrentCost(this.Level);
            resource.gainPerClick += this.productionUnit.perClickIncrease;
            this.Level += 1;
            costText.text = $"{productionUnit.CurrentCost(this.Level)}";
        }
    }
}      