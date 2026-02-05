using UnityEngine;

public class RotateTrap : TrapScript
{
    protected override void TrapDo()
    {
        gameObject.transform.Rotate(0, 0, 90);
    }
}
