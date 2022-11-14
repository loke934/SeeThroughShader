using UnityEngine;

public class CircleSync : MonoBehaviour
{
    public static int targetPosId = Shader.PropertyToID("_TargetPosition");
    public static int circleSizeId = Shader.PropertyToID("_CircleSize");

    [SerializeField, Range(0, 1)] private float circleSize = 0.5f;
    [SerializeField] private Material seeThroughMaterial;
    [SerializeField] private Camera camera;
    [SerializeField] private LayerMask wallMask;

    
    void Update()
    {
        Vector3 position = transform.position;
        Vector3 cameraDir = (camera.transform.position - position).normalized;
        
        Ray ray = new Ray(position, cameraDir);
        if (Physics.Raycast(ray,3000, wallMask))
        {
            seeThroughMaterial.SetFloat(circleSizeId, circleSize);
        }
        else
        {
            seeThroughMaterial.SetFloat(circleSizeId, 0);
        }
        
        Vector3 screenPosition = camera.WorldToViewportPoint(transform.position);
        seeThroughMaterial.SetVector(targetPosId, screenPosition);
    }
}
