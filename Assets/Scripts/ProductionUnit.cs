using UnityEngine;

[CreateAssetMenu]
public class ProductionUnit : ScriptableObject {
    public Resource costResource;
    [SerializeField] public int originalCost = 100;
    [SerializeField] public float costMultiplier = 1.1f;
    public float productionTime = 1f;
    public Resource productionResource;
    public int resourcesProduced = 2;
    public int perClickIncrease;
    
    public int CurrentCost(int level) {
        var result = this.originalCost * Mathf.Pow(this.costMultiplier, level);
        return Mathf.RoundToInt(result);
    }    
    public int CurrentProduction(int level) {
        var result = this.resourcesProduced * level;
        return Mathf.RoundToInt(result);
    }
}