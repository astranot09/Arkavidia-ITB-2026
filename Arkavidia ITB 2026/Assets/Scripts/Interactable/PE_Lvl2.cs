using UnityEngine;
using UnityEngine.Tilemaps;

public class PE_Lvl2 : PaperSpoiler
{
    [SerializeField] private GameObject[] invisPlatform;

    private void Start()
    {
        Debug.Log("kimintil");
        invisPlatform = GameObject.FindGameObjectsWithTag("InvisGround");
        Debug.Log(invisPlatform);
    }
    protected override void PaperEffect()
    {
        base.PaperEffect();
        for (int i = 0; i < invisPlatform.Length; i++)
        {
            invisPlatform[i].GetComponent<TilemapRenderer>().enabled = true;
        }
        
    }
}
