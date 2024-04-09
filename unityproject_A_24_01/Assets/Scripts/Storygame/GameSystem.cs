using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;     //에디터 
using System.Text;     // 텍스트 사용 
using UnityEngine.UI;  //UI 사용하기 위해

namespace STORYGAME  //이름 충돌 방지
{
#if UNITY_EDITOR
    [CustomEditor(typeof(GameSystem))]
    public class GameSystemEditor : Editor     //유니티 에디터를 상속
    {
        public override void OnInspectorGUI()        //인스펙터 함수를 재정의
        {
            base.OnInspectorGUI();                   //기존 인스펙터를 가져와서 실행

            GameSystem gameSystem = (GameSystem)target;    //게임 시스템 스크립트 타겟을 설정

            if (GUILayout.Button("Reset Stroy Models"))    //버튼을 생성
            {
                gameSystem.ResetStoryModels();
            }

            if (GUILayout.Button("Assing Text Component by Name"))    //버튼을 생성(UI 컴포넌트를 불러온다)
            {
                //오브젝트 이름으로 Text 컴포넌트 찾기
                GameObject textObject = GameObject.Find("StoryTextUI");
                if (textObject != null)
                {
                    Text textComponent = textObject.GetComponent<Text>();
                    if (textComponent != null)
                    {
                        //Text Component 할당
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
        public static GameSystem instance;    //간단한 싱글톤 화
        public Text textComponent = null;

        public float delay = 0.1f;            //각 글자가 나타나는 데 걸리는 시간
        public string fullText;               //전체 표시할 텍스트
        public string currentText = "";       //현재가지 표시된 텍스트

        public enum GAMESTATE                //상태값 설정 열거형
        {
            STORYSHOW,
            WAITSELECT,
            STORYEND,
            ENDMODE
        }

        public GAMESTATE currentState;
        public StoryTableObject[] storyModels;    //기존에 있던것 모델들 소스코드 위치 이동
        public StoryTableObject currentModels;    //현재 스토리 모델 객체
        public int currentStoryIndex;             //스토리 모델 인덱스

        private void Awake()
        {
            instance = this;
        }

        public void Start()                  //게임 시작시
        {
            StartCoroutine(ShowText());      //텍스트를 보여준다
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
            storyModels = Resources.LoadAll<StoryTableObject>("");     //Resources  폴더 아래 모든 StoryModel 불러오기
        }
#endif
    }
}