using UnityEngine;
using Zenject;

public class HallView : MonoBehaviour
{
    public class Pool : MonoMemoryPool<HallView>
    {
    }
}
