using UnityEngine;

public class ScaleTrap : TrapScript
{
    [SerializeField] private Vector3 size;

    protected override void TrapDo()
    {
        transform.localScale = size;
    }
}
