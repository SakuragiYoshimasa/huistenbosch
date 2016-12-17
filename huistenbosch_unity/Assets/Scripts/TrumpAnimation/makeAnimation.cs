using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class makeAnimation : MonoBehaviour {

    AnimationClip animClip;

    public Transform targetTower;
    public float elapsedTime;
    // Use this for initialization

    public Dictionary<string, AnimationCurve> curves;

    void Start() {
        animClip = new AnimationClip();


        //makeKeyFrame(transform, targetTower, "");
        
        curves = new Dictionary<string, AnimationCurve>(0);
        generateCurve(transform, "", 0f);
        Debug.Log("Generated Curves" + curves.Count);
        
        //foreach (KeyValuePair<string, AnimationCurve> curve in curves) {
         //   Debug.Log(curve.Key);
       // }
	}

  
    void Update()
    {
        elapsedTime += Time.deltaTime;
        addKeys(transform, "", elapsedTime);

        if (Input.GetKeyDown(KeyCode.B)) {
            setAnimationCurves(transform, "");
            saveAnimationClip();
        }
    }

    void setAnimationCurves(Transform parent, string parentPath) {
        for (int i = 0; i < parent.childCount; ++i)
        {
            if (parent.GetChild(i).gameObject.GetComponent<Trump>() != null || parent.GetChild(i).gameObject.tag == "makeKeyFrame")
            { 
                string path = parentPath + parent.GetChild(i).gameObject.name;

                animClip.SetCurve(path, typeof(Transform), "localPosition.x", curves[path + "curvePX"]);
                animClip.SetCurve(path, typeof(Transform), "localPosition.y", curves[path + "curvePY"]);
                animClip.SetCurve(path, typeof(Transform), "localPosition.z", curves[path + "curvePZ"]);

                animClip.SetCurve(path, typeof(Transform), "localRotation.x", curves[path + "curveRX"]);
                animClip.SetCurve(path, typeof(Transform), "localRotation.y", curves[path + "curveRY"]);
                animClip.SetCurve(path, typeof(Transform), "localRotation.z", curves[path + "curveRZ"]);
                animClip.SetCurve(path, typeof(Transform), "localRotation.w", curves[path + "curveRW"]);
            }
            else
            {
                setAnimationCurves(parent.GetChild(i), parentPath + parent.GetChild(i).gameObject.name + "/");
            }
        }
    }

    void saveAnimationClip() {
        AssetDatabase.CreateAsset(
            animClip,
            AssetDatabase.GenerateUniqueAssetPath("Assets/DistructionAnimation.anim")
            );
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        Debug.Log("Finsh!");
    }

    void addKeys(Transform parent, string parentPath, float time) {
      
        for (int i = 0; i < parent.childCount; ++i)
        {
            if (parent.GetChild(i).gameObject.GetComponent<Trump>() != null || parent.GetChild(i).gameObject.tag == "makeKeyFrame")
            {
                Transform tf = parent.GetChild(i);
                //make key frame about their position and lotation

                Keyframe startKeyframePX = new Keyframe(time, tf.localPosition.x);
                Keyframe startKeyframePY = new Keyframe(time, tf.localPosition.y);
                Keyframe startKeyframePZ = new Keyframe(time, tf.localPosition.z);

                Keyframe startKeyframeRX = new Keyframe(time, tf.localRotation.x);
                Keyframe startKeyframeRY = new Keyframe(time, tf.localRotation.y);
                Keyframe startKeyframeRZ = new Keyframe(time, tf.localRotation.z);
                Keyframe startKeyframeRW = new Keyframe(time, tf.localRotation.w);

                string path = parentPath + parent.GetChild(i).gameObject.name;
                Debug.Log(path);
                curves[path + "curvePX"].AddKey(startKeyframePX);
                curves[path + "curvePY"].AddKey(startKeyframePY);
                curves[path + "curvePZ"].AddKey(startKeyframePZ);

                curves[path + "curveRX"].AddKey(startKeyframeRX);
                curves[path + "curveRY"].AddKey(startKeyframeRY);
                curves[path + "curveRZ"].AddKey(startKeyframeRZ);
                curves[path + "curveRW"].AddKey(startKeyframeRW);
            }
            else
            {
                addKeys(parent.GetChild(i), parentPath + parent.GetChild(i).gameObject.name + "/", time);
            }
        }
    }

    void generateCurve(Transform parent, string parentPath, float time) {

        for (int i = 0; i < parent.childCount; ++i)
        {
            if (parent.GetChild(i).gameObject.GetComponent<Trump>() != null || parent.GetChild(i).gameObject.tag == "makeKeyFrame")
            {
                AnimationCurve curvePX = new AnimationCurve();
                AnimationCurve curvePY = new AnimationCurve();
                AnimationCurve curvePZ = new AnimationCurve();

                AnimationCurve curveRX = new AnimationCurve();
                AnimationCurve curveRY = new AnimationCurve();
                AnimationCurve curveRZ = new AnimationCurve();
                AnimationCurve curveRW = new AnimationCurve();
                string path = parentPath + parent.GetChild(i).gameObject.name;
                //Debug.Log(path);
                curves.Add(path + "curvePX", curvePX);
                curves.Add(path + "curvePY", curvePY);
                curves.Add(path + "curvePZ", curvePZ);

                curves.Add(path + "curveRX", curveRX);
                curves.Add(path + "curveRY", curveRY);
                curves.Add(path + "curveRZ", curveRZ);
                curves.Add(path + "curveRW", curveRW);
            }
            else
            {
                generateCurve(parent.GetChild(i), parentPath + parent.GetChild(i).gameObject.name + "/", time);
            }
        }
    }

    void makeKeyFrame(Transform parent, Transform tartgetParent, string parentPath) {
        for (int i = 0; i < parent.childCount; ++i)
        {
            if (parent.GetChild(i).gameObject.GetComponent<Trump>() != null || parent.GetChild(i).gameObject.tag == "makeKeyFrame")
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

                string path = parentPath + parent.GetChild(i).gameObject.name;

                animClip.SetCurve(path, typeof(Transform), "localPosition.x", curvePX);
                animClip.SetCurve(path, typeof(Transform), "localPosition.y", curvePY);
                animClip.SetCurve(path, typeof(Transform), "localPosition.z", curvePZ);

                animClip.SetCurve(path, typeof(Transform), "localRotation.x", curveRX);
                animClip.SetCurve(path, typeof(Transform), "localRotation.y", curveRY);
                animClip.SetCurve(path, typeof(Transform), "localRotation.z", curveRZ);
                animClip.SetCurve(path, typeof(Transform), "localRotation.w", curveRW);
            }
            else
            {
                makeKeyFrame(parent.GetChild(i), tartgetParent.GetChild(i), parentPath + parent.GetChild(i).gameObject.name + "/");
            }
        }
    }
}
