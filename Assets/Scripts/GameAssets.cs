using UnityEngine;

public class GameAssets : MonoBehaviour
{

    private static GameAssets gameAssets;

    public static GameAssets GetInstance()
    {
        return gameAssets;
    }

    private void Awake()
    {
        gameAssets = this;
    }

    public Sprite pipeHeadSprite;
    public Transform pfPipeHead;
    public Transform pfPipeBody;

}
