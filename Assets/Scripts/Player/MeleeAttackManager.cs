using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MeleeAttackManager : MonoBehaviour
{
    public MeleeAttackKeyFrame[] keyFrames = new MeleeAttackKeyFrame[0];

    void OnDrawGizmos()
    {
        if (Selection.Contains (gameObject))
            for (int i = 0; i < keyFrames.Length; i++)
            {
                MeleeAttackKeyFrame frame = keyFrames[i];
                Gizmos.color = new Color(1, 0, 0, 0.5f);
                Gizmos.DrawCube(transform.position+frame.position, new Vector3(frame.width, frame.height, 0));      
            }
    }

    public IEnumerator Attack ()
    {
        foreach (MeleeAttackKeyFrame frame in keyFrames)
        {
            yield return StartCoroutine(DoFrame(frame));
        }
    }

    IEnumerator DoFrame (MeleeAttackKeyFrame frame)
    {
        BoxCollider2D collider = gameObject.AddComponent<BoxCollider2D>();
        collider.offset = frame.position;
        collider.size = new Vector2(frame.width, frame.height);
        yield return new WaitForSeconds(frame.seconds);
        Destroy(collider);
    }

}
