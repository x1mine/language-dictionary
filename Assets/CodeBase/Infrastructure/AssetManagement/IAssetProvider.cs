using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.AssetManagement {
    public interface IAssetProvider : IService {
        GameObject Instantiate(string path, Vector2 at);
        GameObject Instantiate(string path);
    }
}