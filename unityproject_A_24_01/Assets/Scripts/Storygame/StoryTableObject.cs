using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace STORYGAME
{
    [CreateAssetMenu(fileName = "NewStory", menuName = "ScriptableObjects/StoryTableObject")]

    public class StoryTableObject : ScriptableObject
    {
        public int storyNumber;   //���丮 ��ȣ
        public Enums.StoryType storyType;  //���丮 Ÿ�� ����
        public bool storyDone;

       [TextArea(10, 10)]
        public string storyText;
        public List<Option> options = new List<Option>();

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
            public Enums.EvenType evenType;
            public List<Result> successResult = new List<Result>();
            public List<Result> failResult = new List<Result>();
        }
        [System.Serializable]

        public class Result
        {
            public Enums.ResultType resultType;   //���丮 Ÿ�� ����
            public int value;
            public Stats stats;
        }
    }
}
