using System.Threading.Tasks;
using UnityEngine;

public abstract class GameTask : ScriptableObject
{
    public abstract Task Do();
}