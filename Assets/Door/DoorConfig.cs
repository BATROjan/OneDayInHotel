using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Door
{
    [CreateAssetMenu(fileName = "DoorConfig", menuName = "Configs/DoorConfig")]
    public class DoorConfig : ScriptableObject
    {
        [SerializeField] private DoorModel[] doorModels;

        [NonSerialized] private bool _inited;

        private Dictionary<Type, DoorModel> _dict = new ();

        private void Init()
        {
            _inited = true;
            foreach (var model in doorModels)
            {
                _dict.Add(model.Type, model);
            }
        }

        public DoorModel GetTypeWithId(int id)
        {
            if (!_inited)
            {
                Init();
            }

            return doorModels[id];
        }
    }

    public enum Type
    {
       Open,
       Close
    }

    [Serializable]
    public struct DoorModel
    {
        public Type Type;
        public Sprite Sprite;
        public bool IsOpen;
    }
}