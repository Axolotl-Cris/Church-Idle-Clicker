using UnityEngine;
using UnityEngine.UI;

public class Producer : MonoBehaviour {
    public ProductionUnit productionUnit;
    public Text currentLevelText;
    public Text costText;
    public Text gainText;
    public Text perClickText;
    
    private float _elapsedTime;
    public Resource resource;

    private bool CanGetUpgrades => resource.ResourcesOwned >= productionUnit.CurrentCost(this.Level);

    void Start() {
        currentLevelText.text = productionUnit.lvl.ToString("LVL 0");
        costText.text = $"{productionUnit.CurrentCost(this.Level)}";
        gainText.text = $"+{productionUnit.CurrentProduction(this.Level)}/SEC";
        perClickText.text = resource.gainPerClick.ToString("+0/CLICK");
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
            perClickText.color = Color.black;
            currentLevelText.color = Color.black;
        } else {
            costText.color = Color.red;
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
            gainText.text = $"+{productionUnit.CurrentProduction(this.Level)}/SEC";
        }
    }

    public void OnClickBoost() {
        if (resource.ResourcesOwned >= productionUnit.CurrentCost(this.Level)) {
            resource.ResourcesOwned -= productionUnit.CurrentCost(this.Level);
            resource.gainPerClick += this.productionUnit.perClickIncrease;
            this.Level += 1;
            costText.text = $"{productionUnit.CurrentCost(this.Level)}";
            perClickText.text = resource.gainPerClick.ToString("+0/CLICK");
        }
    }
}      