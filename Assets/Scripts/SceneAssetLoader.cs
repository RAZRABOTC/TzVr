using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class SceneAssetLoader : MonoBehaviour
{
    [SerializeField] private AssetReference _map;
    [SerializeField] private Transform _mapSpawnPoint;
    private readonly List<GameObject> _spawnedObjects = new List<GameObject>();

    private async void Awake()
    {
        LoadAndSpawnAsync().Forget();
    }

    private async UniTaskVoid LoadAndSpawnAsync()
    {
        var h1 = await _map.InstantiateAsync(_mapSpawnPoint).ToUniTask();
        _spawnedObjects.Add(h1);
    }

    private void OnDestroy()
    {
        foreach (var obj in _spawnedObjects)
        {
            if (obj != null)
            {
                Addressables.Release(obj);
            }
        }
        _spawnedObjects.Clear();
    }
}
