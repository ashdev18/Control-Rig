using UnityEngine;
using UnityEditor;
using UnityEngine.Animations.Rigging;

namespace ControlRig
{
    public class ControlRigBuilder : EditorWindow
    {
        private Animator targetAnimator;

        private GameObject ControlRig;

        private Transform hip;
        private Transform spineRoot;
        private Transform spineTip;
        private Transform rightFoot;
        private Transform rightLowerLeg;
        private Transform rightUpperLeg;
        private Transform leftFoot;
        private Transform leftLowerLeg;
        private Transform leftUpperLeg;
        private Transform rightHand;
        private Transform rightLowerArm;
        private Transform rightUpperArm;
        private Transform leftHand;
        private Transform leftLowerArm;
        private Transform leftUpperArm;
        private Transform head;

        [MenuItem("Tools/Control Rig Builder")]
        public static void ShowWindow()
        {
            GetWindow(typeof(ControlRigBuilder));
        }

        private void OnGUI()
        {
            GUILayout.Label("Control Rig Builder", EditorStyles.boldLabel);
            targetAnimator = (Animator)EditorGUILayout.ObjectField("Target Animator", targetAnimator, typeof(Animator), true);


            if (GUILayout.Button("Build Rig"))
            {
                BuildRig();
            }
        }

        private void BuildRig()
        {
            GetReferences();
            ApplyReferences();
        }

        private void ApplyReferences()
        {
            RigBuilder rigBuilder;
            if (targetAnimator.gameObject.GetComponent<RigBuilder>() == null)
            {
                rigBuilder = targetAnimator.gameObject.AddComponent<RigBuilder>();
            }
            else
            {
                rigBuilder = targetAnimator.gameObject.GetComponent<RigBuilder>();
            }

            ControlRig = (GameObject)Resources.Load("Control Rig");

            GameObject tempControlRig = Instantiate(ControlRig, targetAnimator.transform);

            Rig rig = tempControlRig.GetComponent<Rig>();
            rigBuilder.layers.Clear();
            rigBuilder.layers.Add(new RigLayer(rig, true));


            //references
            Rig_References rig_References = tempControlRig.GetComponent<Rig_References>();

            //hip Rig
            rig_References.hipRig.data.constrainedObject = hip;

            //Spine Rig
            rig_References.spineRig.data.root = spineRoot;
            rig_References.spineRig.data.tip = spineTip;

            //leg rig
            //Right Leg Rig
            rig_References.RightLegRig.data.tip = rightFoot;
            rig_References.RightLegRig.data.mid = rightLowerLeg;
            rig_References.RightLegRig.data.root = rightUpperLeg;
            //left Leg Rig
            rig_References.LeftLegRig.data.tip = leftFoot;
            rig_References.LeftLegRig.data.mid = leftLowerLeg;
            rig_References.LeftLegRig.data.root = leftUpperLeg;

            //Hand Rig
            //Right Hand Rig
            rig_References.RightHandRig.data.tip = rightHand;
            rig_References.RightHandRig.data.mid = rightLowerArm;
            rig_References.RightHandRig.data.root = rightUpperArm;
            //left Hand Rig
            rig_References.LeftHandRig.data.tip = leftHand;
            rig_References.LeftHandRig.data.mid = leftLowerArm;
            rig_References.LeftHandRig.data.root = leftUpperArm;

            //Head Aim Rig
            rig_References.headRig.data.constrainedObject = head;



            setRigTargetTransforms(rig_References);

        }

        private void setRigTargetTransforms(Rig_References rig_References)
        {
            // hip rig
            rig_References.hipRig.data.sourceObjects[0].transform.position = rig_References.hipRig.data.constrainedObject.position;

            //spine rig
            rig_References.spineRig.data.rootTarget.position = rig_References.spineRig.data.root.position;
            rig_References.spineRig.data.tipTarget.position = rig_References.spineRig.data.tip.position;
            rig_References.spineRig.data.rootTarget.rotation = rig_References.spineRig.data.root.rotation;
            rig_References.spineRig.data.tipTarget.rotation = rig_References.spineRig.data.tip.rotation;

            //leg rig
            //Right Leg Rig
            rig_References.RightLegRig.data.target.position = rig_References.RightLegRig.data.tip.position;
            //left Leg Rig
            rig_References.LeftLegRig.data.target.position = rig_References.LeftLegRig.data.tip.position;

            //Hand Rig
            //Right Hand Rig
            rig_References.RightHandRig.data.target.position = rig_References.RightHandRig.data.tip.position;
            //left Hand Rig
            rig_References.LeftHandRig.data.target.position = rig_References.LeftHandRig.data.tip.position;

            //Head Aim Rig
            rig_References.headRig.data.sourceObjects[0].transform.transform.position = rig_References.headRig.data.constrainedObject.position + Vector3.forward;

        }

        private void AddRigEffectors(Rig_References rig_References, RigBuilder rigBuilder)
        {

        }

        private void GetReferences()
        {
            hip = targetAnimator.GetBoneTransform(HumanBodyBones.Hips);
            spineRoot = targetAnimator.GetBoneTransform(HumanBodyBones.Spine);
            spineTip = targetAnimator.GetBoneTransform(HumanBodyBones.Neck);
            rightFoot = targetAnimator.GetBoneTransform(HumanBodyBones.RightFoot);
            rightLowerLeg = targetAnimator.GetBoneTransform(HumanBodyBones.RightLowerLeg);
            rightUpperLeg = targetAnimator.GetBoneTransform(HumanBodyBones.RightUpperLeg);
            leftFoot = targetAnimator.GetBoneTransform(HumanBodyBones.LeftFoot);
            leftLowerLeg = targetAnimator.GetBoneTransform(HumanBodyBones.LeftLowerLeg);
            leftUpperLeg = targetAnimator.GetBoneTransform(HumanBodyBones.LeftUpperLeg);
            rightHand = targetAnimator.GetBoneTransform(HumanBodyBones.RightHand);
            rightLowerArm = targetAnimator.GetBoneTransform(HumanBodyBones.RightLowerArm);
            rightUpperArm = targetAnimator.GetBoneTransform(HumanBodyBones.RightUpperArm);
            leftHand = targetAnimator.GetBoneTransform(HumanBodyBones.LeftHand);
            leftLowerArm = targetAnimator.GetBoneTransform(HumanBodyBones.LeftLowerArm);
            leftUpperArm = targetAnimator.GetBoneTransform(HumanBodyBones.LeftUpperArm);
            head = targetAnimator.GetBoneTransform(HumanBodyBones.Head);

        }
    }
}