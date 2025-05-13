using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "CameraConfig", menuName = "Configs/CameraConfig")]
    public class CameraConfig : ScriptableObject
    {
        [field: SerializeField] public float Speed {get; private set;}
        [field: SerializeField] public float Sensitivity {get; private set;}
    }
}