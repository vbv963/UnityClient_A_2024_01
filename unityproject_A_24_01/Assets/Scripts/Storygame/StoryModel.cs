using STORYGAME;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static STORYGAME.StoryTableObject;

[CreateAssetMenu(fileName = "NewStory", menuName = "ScriptableObjects/StoryModel")]
public class StoryModel : ScriptableObject
{
    public int storyNumber;               //스토리 번호
    public Texture2D MainImage;           //스토리 보여줄 이미지 텍스쳐

    public enum STORYTYPE                 //스토리 타입 설정
    {
        MAIN,
        SUB,
        SERIAL
    }

    public STORYTYPE storytype;           //스토리 타입 선언
    public bool storyDone;                //스토리 종료 여부

    [TextArea(10, 10)]                    //텍스트 영역 표시
    public string storyText;              //메인 스토리

    public Option[] options;              //선택지 배열

    [System.Serializable]
    public class Option
    {
        public string optiontext;
        public string buttonText;
        public EventCheck eventCheck;
    }

    [System.Serializable]
    public class EventCheck
    {
        public int checkValue;

        public enum EventType : int
        {
            NONE,
            GoToBattle,
            CheckSTR,
            CheckDEX,
            CheckCON,
            CheckINT,
            CheckWIS,
            CheckCHA,
        }

        public EventType eventtype;
         
        public Result[] suceessResult;      //선택지에 대한 성공 결과 배열
        public Result[] failResults;        //선택지에 대한 실패 결과 배열
    }

    [System.Serializable]
    public class Result
    {
       public enum ResultType : int
        {
            ChangeHp,
            ChangeSp,
            AddExperience,
            GoToShop,
            GoToNextStory,
            GoToRandomStory,
            GoToEnding
        }

        public ResultType resultType;       //결과값 타입
        public int value;                   //변화 수치 입력
        public Stats stats;                 //해당 스텟 변화 수치
    }
}
