using UnityEngine;

[CreateAssetMenu(menuName = "BehaviourTree/Node")]
public class BehaviourTreeNode : ScriptableObject
{
    public BehaviourTreeNode _parent;
    public BehaviourTreeNode _leftChild;
    public BehaviourTreeNode _rightSibling;
    public BehaviourTreeNodeProcessor _nodeProcessor;

}
