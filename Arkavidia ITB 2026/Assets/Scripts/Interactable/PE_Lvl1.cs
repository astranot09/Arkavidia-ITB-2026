using UnityEngine;

public class PE_Lvl1 : PaperSpoiler
{
    [SerializeField] private Collider2D invisPlatform;
    protected override void PaperEffect()
    {
        base.PaperEffect();
        invisPlatform.enabled = true;
    }
}
