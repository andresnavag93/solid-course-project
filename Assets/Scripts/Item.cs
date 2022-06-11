using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private string id;
    public string Id => id;
}
