using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text;

#if UNITY_EDITOR
public class GameSystemEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GameSystem gameSystem = (GameSystem)target;
        if (GUILayout.Button("Reset Story Models"))    //�����Ϳ��� ��ư �߻�
        {
            gameSystem.ResetStoryModels();
        }
    }
}

#endif

public class GameSystem : MonoBehaviour
{
    public StoryModel[] storyModels;                        //����� ���丮 �𵨷� ����

#if UNITY_EDITOR
    [ContextMenu("Reset Story Models")]
    public void ResetStoryModels()
    {
        storyModels = Resources.LoadAll<StoryModel>("");    //Resources ���� �Ʒ� ��� StoryModel �ҷ�����
    }
#endif
}