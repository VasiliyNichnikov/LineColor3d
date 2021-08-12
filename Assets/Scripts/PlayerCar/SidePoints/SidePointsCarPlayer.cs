using PlayerCar.SidePoints;
using UnityEngine;
using UnityEngine.Serialization;

public class SidePointsCarPlayer : MonoBehaviour
{
    public SidePointUp Up => up;
    public SidePointDown Down => down;
    
    public SidePointRight Right => right;
    public SidePointLeft Left => left;
    
    public SidePointForward ForwardProjector => forwardProjector;
    public SidePointBehind BehindProjector => behindProjector;

    [FormerlySerializedAs("_pointUp")]
    [Header("Up and down points")]
    [SerializeField] private SidePointUp up;
    [FormerlySerializedAs("_pointDown")] [SerializeField] private SidePointDown down;
    
    [FormerlySerializedAs("_pointRight")]
    [Header("Right and left points")]
    [SerializeField] private SidePointRight right;
    [FormerlySerializedAs("_pointLeft")] [SerializeField] private SidePointLeft left;

    [FormerlySerializedAs("_pointForwardProjector")]
    [Header("Forward and behind points projector")] 
    [SerializeField] private SidePointForward forwardProjector;
    [FormerlySerializedAs("_pointBehindProjector")] [SerializeField] private SidePointBehind behindProjector;
}
