using UnityEngine;
public class Installer : MonoBehaviour
{
    [SerializeField] private Menu _menu;
    [SerializeField] private GameManager _gameManager;

    private void Awake()
    {

        _gameManager.Configure(GetSavePersistence());
        _menu.Configure(GetLoadPersistence());
    }

    private ILoad GetLoadPersistence()
    {
#if UNITY_EDITOR
        return new FilePersistence();
#endif
        return new PlayerPrefsPersistence();
    }

    private ISave GetSavePersistence()
    {
#if UNITY_EDITOR
        return new FilePersistence();
#endif
        return new PlayerPrefsPersistence();
    }
}
