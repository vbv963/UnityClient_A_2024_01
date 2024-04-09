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
        public bool showStory = false;

        private void Awake()
        {
            instance = this;
        }

        public void Start()                  //���� ���۽�
        {
            StartCoroutine(ShowText());      //�ؽ�Ʈ�� �����ش�
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q)) StoryShow(1);       //QŰ�� ������ 1�� ���丮
            if (Input.GetKeyDown(KeyCode.W)) StoryShow(2);       //WŰ�� ������ 2�� ���丮
            if (Input.GetKeyDown(KeyCode.E)) StoryShow(3);       //EŰ�� ������ 3�� ���丮

            if (Input.GetKeyDown(KeyCode.Space))
            {
                delay = 0.0f;                                    
            }
        }

        public void StoryShow(int number)
        {
            if (!showStory)
            {
                currentModels = FindStoryModeI(number);              //���丮 ���� ��ȣ�� ã�Ƽ�
                delay = 0.1f;
                StartCoroutine(ShowText());                          //��ƾ�� ���� ��Ų��.
            }
        }

        StoryTableObject FindStoryModeI(int number)              //���丮 �� ��ȣ�� ã�� �Լ�
        {
            StoryTableObject tempStoryModels = null;             //temp �̸� ���� �س��� ������ ����
            for(int i = 0; i < storyModels.Length; i++)          //��ư���� �޾ƿ� ����Ʈ�� for������ �˻��Ͽ�
            { 
                if (storyModels[i].storyNumber == number)        //���ڰ� ���� ���
                {
                    tempStoryModels = storyModels[i];            //�̸� ������ ���� ������ �ְ�
                    break;                                       //for ���� ���� ���´�.
                } 
            }

            return tempStoryModels;                              //���丮 ���� �����ش�.
        }

        IEnumerator ShowText()
        {
            showStory = true;
            for (int i = 0; i <= currentModels.storyText.Length; i++)
            {
                currentText = currentModels.storyText.Substring(0, i);
                textComponent.text = currentText;
                yield return new WaitForSeconds(delay);
            }

            yield return new WaitForSeconds(delay);
            showStory = false;
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