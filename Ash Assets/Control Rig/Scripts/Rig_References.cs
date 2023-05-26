using UnityEngine;
using UnityEditor;
using UnityEngine.Animations.Rigging;

namespace ControlRig
{
    public class Rig_References : MonoBehaviour
    {
        public MultiParentConstraint hipRig;
        public TwistChainConstraint spineRig;
        public TwoBoneIKConstraint RightLegRig;
        public TwoBoneIKConstraint LeftLegRig;
        public TwoBoneIKConstraint RightHandRig;
        public TwoBoneIKConstraint LeftHandRig;
        public MultiAimConstraint headRig;
    }
}
