using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class makeAnimation : MonoBehaviour {

    AnimationClip animClip;

    public Transform targetTower;
    // Use this for initialization
    void Start() {
        animClip = new AnimationClip();

        
        makeKeyFrame(transform, targetTower, "");
     
       
        AssetDatabase.CreateAsset(
            animClip,
            AssetDatabase.GenerateUniqueAssetPath("Assets/ConstructionAnimation.anim")
            );
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        Debug.Log("Finsh!");


	}

    void makeKeyFrame(Transform parent, Transform tartgetParent, string parentPath) {
        for (int i = 0; i < parent.childCount; ++i)
        {
            if (parent.GetChild(i).gameObject.GetComponent<Trump>() != null)
            {

                Transform tf = parent.GetChild(i);
                //make key frame about their position and lotation
             
                Keyframe startKeyframePX = new Keyframe(0, tf.localPosition.x);
                Keyframe startKeyframePY = new Keyframe(0, tf.localPosition.y);
                Keyframe startKeyframePZ = new Keyframe(0, tf.localPosition.z);
                if (i >= tartgetParent.childCount) {
                    continue;
                }
                Transform tfTarget = tartgetParent.GetChild(i);
                
                Keyframe startKeyframePX2 = new Keyframe(60f, tfTarget.localPosition.x);
                Keyframe startKeyframePY2 = new Keyframe(60f, tfTarget.localPosition.y);
                Keyframe startKeyframePZ2 = new Keyframe(60f, tfTarget.localPosition.z);
                
                AnimationCurve curvePX = new AnimationCurve();
                AnimationCurve curvePY = new AnimationCurve();
                AnimationCurve curvePZ = new AnimationCurve();

                curvePX.AddKey(startKeyframePX);
                curvePY.AddKey(startKeyframePY);
                curvePZ.AddKey(startKeyframePZ);
                
                curvePX.AddKey(startKeyframePX2);
                curvePY.AddKey(startKeyframePY2);
                curvePZ.AddKey(startKeyframePZ2);
                
                Keyframe startKeyframeRX = new Keyframe(0, tf.localRotation.x);
                Keyframe startKeyframeRY = new Keyframe(0, tf.localRotation.y);
                Keyframe startKeyframeRZ = new Keyframe(0, tf.localRotation.z);
                Keyframe startKeyframeRW = new Keyframe(0, tf.localRotation.w);
                
                Keyframe startKeyframeRX2 = new Keyframe(60f, tfTarget.localRotation.x);
                Keyframe startKeyframeRY2 = new Keyframe(60f, tfTarget.localRotation.y);
                Keyframe startKeyframeRZ2 = new Keyframe(60f, tfTarget.localRotation.z);
                Keyframe startKeyframeRW2 = new Keyframe(60f, tfTarget.localRotation.w);
                
                AnimationCurve curveRX = new AnimationCurve();
                AnimationCurve curveRY = new AnimationCurve();
                AnimationCurve curveRZ = new AnimationCurve();
                AnimationCurve curveRW = new AnimationCurve();

                curveRX.AddKey(startKeyframeRX);
                curveRY.AddKey(startKeyframeRY);
                curveRZ.AddKey(startKeyframeRZ);
                curveRW.AddKey(startKeyframeRW);
                
                curveRX.AddKey(startKeyframeRX2);
                curveRY.AddKey(startKeyframeRY2);
                curveRZ.AddKey(startKeyframeRZ2);
                curveRW.AddKey(startKeyframeRW2);
                
                animClip.SetCurve(parentPath + parent.GetChild(i).gameObject.name, typeof(Transform), "localPosition.x", curvePX);
                animClip.SetCurve(parentPath + parent.GetChild(i).gameObject.name, typeof(Transform), "localPosition.y", curvePY);
                animClip.SetCurve(parentPath + parent.GetChild(i).gameObject.name, typeof(Transform), "localPosition.z", curvePZ);

                animClip.SetCurve(parentPath + parent.GetChild(i).gameObject.name, typeof(Transform), "localRotation.x", curveRX);
                animClip.SetCurve(parentPath + parent.GetChild(i).gameObject.name, typeof(Transform), "localRotation.y", curveRY);
                animClip.SetCurve(parentPath + parent.GetChild(i).gameObject.name, typeof(Transform), "localRotation.z", curveRZ);
                animClip.SetCurve(parentPath + parent.GetChild(i).gameObject.name, typeof(Transform), "localRotation.w", curveRW);
            }
            else
            {
                makeKeyFrame(parent.GetChild(i), tartgetParent.GetChild(i), parentPath + parent.GetChild(i).gameObject.name + "/");
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
