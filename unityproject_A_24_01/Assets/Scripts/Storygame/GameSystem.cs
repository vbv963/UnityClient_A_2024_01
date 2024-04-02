using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;     //������ 
using System.Text;     // �ؽ�Ʈ ��� 

namespace STORYGAME  //�̸� �浹 ����
{
#if UNITY_EDITOR
    [CustomEditor(typeof(GameSystem))]
    public class GameSystemEditor : Editor     //����Ƽ �����͸� ���
    {
        public override void OnInspectorGUI()        //�ν����� �Լ��� ������
        {
            base.OnInspectorGUI();                   //���� �ν����͸� �����ͼ� ����

            GameSystem gameSystem = (GameSystem)target;    //���� �ý��� ��ũ��Ʈ Ÿ���� ����

            if (GUILayout.Button("Reset Stroy Models"))    //��ư�� ����
            {
                gameSystem.ResetStoryModels();
            }
        }
    }
#endif

    public class GameSystem : MonoBehaviour
    {
        public static GameSystem instance;    //������ �̱��� ȭ

        private void Awake()
        {
            instance = this;
        }

        public StoryTableObject[] storyModels;

# if UNITY_EDITOR
        [ContextMenu("Reset Stroy Models")]

        public void ResetStoryModels()
        {
            storyModels = Resources.LoadAll<StoryTableObject>("");     //Resources  ���� �Ʒ� ��� StoryModel �ҷ�����
        }
#endif
    }
}