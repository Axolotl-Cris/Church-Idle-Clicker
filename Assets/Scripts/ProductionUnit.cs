using UnityEngine;

[CreateAssetMenu]
public class ProductionUnit : ScriptableObject {
    public int resourcesProduced = 1;
    public int cost = 100;
    public float productionTime = 1f;
    public int lvl = 0;
    public int perClickIncrease = 0;
}