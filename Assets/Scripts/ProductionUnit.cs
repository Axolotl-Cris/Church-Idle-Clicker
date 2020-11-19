using UnityEngine;

[CreateAssetMenu]
public class ProductionUnit : ScriptableObject {
    public int resourcesProduced = 2;
    public int originalCost = 100;
    public float costMultiplier = 1.1f;
    public float productionTime = 1f;
    public int lvl = 0;
    public int perClickIncrease = 0;
    //public float productionMultiplier = 1.02f;
    
    public int CurrentCost(int level) {
        var result = this.originalCost * Mathf.Pow(this.costMultiplier, level);
        return Mathf.RoundToInt(result);
    }
}