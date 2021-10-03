using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    private const float CAMERA_ORTHO_SIZE = 50f;
    private const float PIPE_WIDTH = 7.8f;
    private const float PIPE_HEAD_HEIGHT = 3.75f;

    private void Start()
    {
        CreatePipe(30f, 20f, true);
        CreatePipe(40f, 20f, false);
    }

    private void CreatePipe(float height, float xPosition, bool createBottom)
    {
        // Setup Pipe Head
        Transform pipeHead = Instantiate(GameAssets.GetInstance().pfPipeHead);
        float pipeHeadPosition;
        if (createBottom)
        {
            pipeHeadPosition = -CAMERA_ORTHO_SIZE + height - PIPE_HEAD_HEIGHT * 0.5f;
        }
        else
        {
            pipeHeadPosition = +CAMERA_ORTHO_SIZE - height + PIPE_HEAD_HEIGHT * 0.5f;
        }
        pipeHead.position = new Vector3(xPosition, pipeHeadPosition);


        // Setup Pipe Body
        Transform pipeBoody = Instantiate(GameAssets.GetInstance().pfPipeBody);
        float pipeBodyPosition;
        if (createBottom)
        {
            pipeBodyPosition = -CAMERA_ORTHO_SIZE;
        }
        else
        {
            pipeBodyPosition = +CAMERA_ORTHO_SIZE;
            pipeBoody.localScale = new Vector3(1, -1); //This is done so that the pipe is not created at the botton, sticking out of the frame.
        }
        pipeBoody.position = new Vector3(xPosition, pipeBodyPosition);

        // We need to define a height for the pipe body. The size remains the same.
        // Made the draw mode to be sliced. We could change the height value there.
        SpriteRenderer pipeBodySpriteRenderer = pipeBoody.GetComponent<SpriteRenderer>();
        pipeBodySpriteRenderer.size = new Vector2(PIPE_WIDTH, height);

        //Set the size of the box collider.
        BoxCollider2D boxCollider2D = pipeBoody.GetComponent<BoxCollider2D>();
        boxCollider2D.size = new Vector2(PIPE_WIDTH, height);
        //setting the offset, because the collider took 0 as offset. 
        boxCollider2D.offset = new Vector2(0f, height * 0.5f);
    }
}
