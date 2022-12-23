using UnityEngine;
using System.Linq;
using System;

namespace Game.Data
{
    [CreateAssetMenu(menuName = "Game/Data/" + nameof(StorageImage))]
    public class StorageImage : ScriptableObject
    {
        [System.Serializable]
        public class Storage
        {
            [Header("Name List image")]
            [SerializeField] private string _name;
            [SerializeField] private Sprite[] _images;

            public string Name => _name;
            public Sprite[] Images => _images;
        }

        [SerializeField] private Storage[] _storages;

        public Storage GetStorage(string name)
        {
            return _storages.FirstOrDefault(s => s.Name == name);
        }

        public Sprite GetImage(string path)
        {
            Sprite[] images = GetStorage(path.Split('_')[0])?.Images;

            if (images == null) return null;

            return images[Convert.ToInt32(path.Split('_')[1])];
        }
    }
}