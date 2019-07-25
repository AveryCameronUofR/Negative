using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Camera cam;

    public bool flippingEnabled = false;
    public bool invertByDefault = false;

    public Vector3 invertedScale;

    private Vector3 normalScale;
    
    private Mesh mesh;

    private Vector3[] worldVerts;

    private Vector2[] uvs;

    void Start()
    {
        // set the normal scale
        normalScale = transform.localScale;

        // if invert by default, flip the normal and inverted variables
        if (invertByDefault)
        {
            Vector3 temp = normalScale;
            normalScale = invertedScale;
            invertedScale = temp;
        }

        // fetch mesh and uvs
        mesh = GetComponent<MeshFilter>().mesh;
        uvs = mesh.uv;

        // transform verts to world coords and store
        worldVerts = new Vector3[mesh.vertices.Length];
        for (int i = 0; i < mesh.vertices.Length; i++)
            worldVerts[i] = transform.TransformPoint(mesh.vertices[i]);

        // set material texture to camera's render texture
        var renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = cam.targetTexture;
    }

    void Update()
    {
        /*
            adjust portal's uv's to select the part of the screen the portal occupies
            (this is done by converting the world coordinates to viewport coords.
            the render texture is the size of the screen so we can use the viewport coords
            as uv's to get the desired effect.
        */
        Vector2[] newUVs = new Vector2[uvs.Length];
        for (int i = 0; i < uvs.Length; i++)
            newUVs[i] = Camera.main.WorldToViewportPoint(worldVerts[i]);

        // assign new UV
        mesh.uv = newUVs;

        // invert the portal for double-sided portals (if enabled)
        if (flippingEnabled)
        {
            Transform camTransform = cam.gameObject.transform;
            var horizontal = new Vector3(camTransform.position.x, transform.position.y, camTransform.position.z);
            var targetDir = horizontal - transform.position;
            var angle = Vector2.SignedAngle(
                new Vector2(targetDir.x, targetDir.z),
                new Vector2(transform.forward.x, transform.forward.z)
            );

            if (angle > 0.0f) transform.localScale = normalScale;
            else transform.localScale = invertedScale;
        }
    }
}
