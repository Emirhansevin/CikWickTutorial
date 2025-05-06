using UnityEngine;


[CreateAssetMenu(fileName ="WheatDesignSO" , menuName ="ScriptableObjects/WheatDesignSO")]
public class WheatDesignSO : ScriptableObject
{
    [SerializeField] private float _increaseDecreaseMultipler;
    [SerializeField] private float _resetBoostDureation;

    public float IncreaseDecreaseMultipler => _increaseDecreaseMultipler;
    public float ResetBoostDureation => _resetBoostDureation;

}
