using UnityEngine;

public class TestGear : MonoBehaviour
{
    [SerializeField]
    private string Name = "LOQUESEA";

    [SerializeField]
    private int strength = 1;

    public int Strength { get => strength; }
}