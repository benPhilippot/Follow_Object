using UnityEngine;

[ExecuteInEditMode]

public class Follow_Bone : MonoBehaviour
{
    [SerializeField] private GameObject parentObject;
    [SerializeField] private Vector3 Offset;

    [SerializeField] private bool keepOrientation = true;
    [SerializeField] private bool keepScale = true;
 
    [SerializeField] private bool alwaysDrawDebugPosition = false;
    
    private Vector3 _cubeSize = new Vector3(0.4f, 0.1f, 0.1f);

    void OnDrawGizmos()
    {
        if (parentObject == null)
            return;

        if (UnityEditor.Selection.activeGameObject != this.gameObject && !alwaysDrawDebugPosition)
            return;

        Gizmos.color = Color.yellow;

        if (UnityEditor.Selection.activeGameObject == this.gameObject)
            Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, 0.3f);

        Gizmos.DrawLine(parentObject.transform.position, transform.position);

        Matrix4x4 rotationMatrix = Matrix4x4.TRS(parentObject.transform.position, parentObject.transform.rotation, parentObject.transform.lossyScale);
        Gizmos.matrix = rotationMatrix;
        Gizmos.DrawWireCube(Vector3.zero, _cubeSize);
    }


    void Update()
    {
        if (parentObject == null) 
            return;

        Vector3 worldPosition = parentObject.transform.TransformPoint(Offset);
        Quaternion worldRotation = parentObject.transform.rotation;
        Vector3 worldScale = parentObject.transform.lossyScale;
        
        transform.position = worldPosition;
        if (!keepOrientation) 
            transform.rotation = worldRotation;
        if (!keepScale) 
            transform.localScale = worldScale;
    }
}


