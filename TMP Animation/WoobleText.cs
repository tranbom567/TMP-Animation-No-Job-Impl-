using DG.Tweening;
using DG.Tweening.Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WoobleText : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textMesh;
    [SerializeField]
    private float speed = 1;
    private bool isComplete;
    private float scale;
    private Mesh textMeshInit;
    private Vector3[] cacheVert;
    private Vector3[] passVert;
    private readonly int sides = 4;
    void Start()
    {

        textMesh.ForceMeshUpdate();
        textMeshInit = textMesh.mesh;
        cacheVert = textMeshInit.vertices;
        passVert = textMeshInit.vertices;

    }

    private void Update()
    {
        foreach (var charInfo in textMesh.textInfo.characterInfo)
        {
            var randomPrefix = Random.Range(0.2f,1+0.1f);
            if (charInfo.isVisible)
            {
                for (int i = 0; i < sides; i++)
                    passVert[charInfo.vertexIndex + i] = cacheVert[charInfo.vertexIndex + i] + new Vector3(Mathf.Cos(Time.time * speed) * randomPrefix, Mathf.Sin(Time.time * speed)*randomPrefix, cacheVert[i].z);
                textMeshInit.vertices = passVert;
                textMesh.canvasRenderer.SetMesh(textMeshInit);
            }
        }
    }
}
