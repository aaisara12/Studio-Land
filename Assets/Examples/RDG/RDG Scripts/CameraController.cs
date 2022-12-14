using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraController : MonoBehaviour
{

    public Room currRoom;
    public float camSpeed;

    [SerializeField] Camera camera;
    [SerializeField] RenderPipelineAsset renderer2D;

    public static CameraController instance { get; private set; }

    void Awake()
    {
        if (instance == null)
        {
            Debug.Log("camera created");
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
            GraphicsSettings.renderPipelineAsset = renderer2D;
            QualitySettings.SetQualityLevel(3,true);
            Debug.Log("renderer changed to 2d");
    }

    void Update()
    {
        MoveCam();
    }

    private void MoveCam()
    {
        if (currRoom == null)
        {
            Debug.Log("current room not set");
            return;
        }

        Vector3 newPos = new Vector3(currRoom.X * currRoom.width, currRoom.Y * currRoom.height);
        newPos.z = transform.position.z;

        transform.position = Vector3.MoveTowards(transform.position, newPos, Time.deltaTime * camSpeed);

    }
}
