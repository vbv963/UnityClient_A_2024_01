using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;     //������ 
using System.Text;     // �ؽ�Ʈ ��� 
using UnityEngine.UI;  //UI ����ϱ� ����

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

            if (GUILayout.Button("Assing Text Component by Name"))    //��ư�� ����(UI ������Ʈ�� �ҷ��´�)
            {
                //������Ʈ �̸����� Text ������Ʈ ã��
                GameObject textObject = GameObject.Find("StoryTextUI");
                if (textObject != null)
                {
                    Text textComponent = textObject.GetComponent<Text>();
                    if (textComponent != null)
                    {
                        //Text Component �Ҵ�
                        gameSystem.textComponent = textComponent;
                        Debug.Log("Text Component assigned Successfully");
                    }
                }
            }
        }
    }
#endif

    public class GameSystem : MonoBehaviour
    {
        public static GameSystem instance;    //������ �̱��� ȭ
        public Text textComponent = null;

        public float delay = 0.1f;            //�� ���ڰ� ��Ÿ���� �� �ɸ��� �ð�
        public string fullText;               //��ü ǥ���� �ؽ�Ʈ
        public string currentText = "";       //���簡�� ǥ�õ� �ؽ�Ʈ

        public enum GAMESTATE                //���°� ���� ������
        {
            STORYSHOW,
            WAITSELECT,
            STORYEND,
            ENDMODE
        }

        public GAMESTATE currentState;
        public StoryTableObject[] storyModels;    //������ �ִ��� �𵨵� �ҽ��ڵ� ��ġ �̵�
        public StoryTableObject currentModels;    //���� ���丮 �� ��ü
        public int currentStoryIndex;             //���丮 �� �ε���

        private void Awake()
        {
            instance = this;
        }

        public void Start()                  //���� ���۽�
        {
            StartCoroutine(ShowText());      //�ؽ�Ʈ�� �����ش�
        }

        IEnumerator ShowText()
        {
            for (int i = 0; i <= currentModels.storyText.Length; i++)
            {
                currentText = currentModels.storyText.Substring(0, i);
                textComponent.text = currentText;
                yield return new WaitForSeconds(delay);
            }
        }

# if UNITY_EDITOR
        [ContextMenu("Reset Stroy Models")]

        public void ResetStoryModels()
        {
            storyModels = Resources.LoadAll<StoryTableObject>("");     //Resources  ���� �Ʒ� ��� StoryModel �ҷ�����
        }
#endif
    }
}