using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Bone : MonoBehaviour
{
    public GameObject parentObject;
    public bool alwaysDrawDebugPosition = false;
    public Vector3 Offset;
    public bool keepOrientation = true;
    public bool keepScale = true;

    Vector3 realOffset;

    void OnDrawGizmos()
    {

        if (parentObject == null) return;

        if (UnityEditor.Selection.activeGameObject != this.gameObject && !alwaysDrawDebugPosition) return;

        if (alwaysDrawDebugPosition) Gizmos.color = Color.yellow;
        if (UnityEditor.Selection.activeGameObject == this.gameObject) Gizmos.color = Color.green;

        Vector3 worldPosition = parentObject.transform.TransformPoint(Offset);

        Gizmos.DrawWireSphere(worldPosition, 0.3f);

        Gizmos.DrawLine(parentObject.transform.position, worldPosition);

        Matrix4x4 rotationMatrix = Matrix4x4.TRS(parentObject.transform.position, parentObject.transform.rotation, parentObject.transform.lossyScale);
        Gizmos.matrix = rotationMatrix;
        Vector3 Cubesize = new Vector3(0.4f, 0.1f, 0.1f);
        Gizmos.DrawWireCube(new Vector3(0f, 0f, 0f), Cubesize);

        Quaternion worldRotation = parentObject.transform.rotation;
        Vector3 worldScale = parentObject.transform.lossyScale;

        transform.position = worldPosition;
        if (!keepOrientation) transform.rotation = worldRotation;
        if (!keepScale) transform.localScale = worldScale;

    }

    void Start()
    {

    }

    void Update()
    {
        if (parentObject == null) return;

        Vector3 worldPosition = parentObject.transform.TransformPoint(Offset);
        Quaternion worldRotation = parentObject.transform.rotation;
        Vector3 worldScale = parentObject.transform.lossyScale;

        transform.position = worldPosition;
        if (!keepOrientation) transform.rotation = worldRotation;
        if (!keepScale) transform.localScale = worldScale;

    }
}
