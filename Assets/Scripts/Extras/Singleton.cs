using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _instancia;
    public static T Instancia
    {
        get
        {
            if (_instancia == null)
            {
                _instancia = FindObjectOfType<T>();
                if (_instancia == null)
                {
                    GameObject nuevoGO = new GameObject();
                    _instancia = nuevoGO.AddComponent<T>();
                }
            }

            return _instancia;
        }
    }

    protected virtual void Awake()
    {
        _instancia = this as T;
    }
}
