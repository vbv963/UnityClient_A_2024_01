using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;              //UI�� ��Ʈ�� �� ���̶� �߰�
using System;                      //string ���� �Լ� ��� �ϱ� ���� �߰�

public class StorySystem : MonoBehaviour
{
    public static StorySystem instance;          //������ �̱��� ȭ
    public StoryModel currentStoryModel;         //���� ���丮 �� ����

    public enum TEXTSYSTEM
    {
        DOING,
        SELECT,
        DONE
    }

    public float delay = 0.1f;                  //�� ���ڰ� ��Ÿ���µ� �ɸ��� �ð�
    public string fullText;                     //��ü ǥ���� �ؽ�Ʈ
    private string currentText = "";            //������� ǥ�õ� �ؽ�Ʈ
    public Text textComponent;                  //text ������Ʈ UI
    public Text storyIndex;                     //���丮 ��ȣ ǥ���� UI
    public Image imageComponent;                //�̹��� UI

    public Button[] buttonWay = new Button[3];  //������ ��ư �߰�
    public Text[] buttonWayText = new Text[3];  //������ ��ư text

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < buttonWay.Length; i++)                     //��ư ���ڿ� ���� �Լ�
        {
            int wayIndex = i;
            buttonWay[i].onClick.AddListener(() => OnWayClick(wayIndex));
        }

        StoryModelinit();
        StartCoroutine(ShowText());
    }

    public void StoryModelinit()
    {
        fullText = currentStoryModel.storyText;
        storyIndex.text = currentStoryModel.storyNumber.ToString();

        for (int i = 0; i < currentStoryModel.options.Length; i++)
        {
            buttonWayText[i].text = currentStoryModel.options[i].buttonText;        //��ư �̸��� ����
        }
    }

    public void OnWayClick(int index)
    {

    }

    IEnumerator ShowText()                                           //�ڷ�ƾ �Լ� ���
    {
        if(currentStoryModel.MainImage != null)
        {
            //Texture2D�� Sprite ��ȯ

            Rect rect = new Rect(0,0,currentStoryModel.MainImage.width,currentStoryModel.MainImage.height);
            Vector2 pivot = new Vector2(0.5f, 0.5f);    //��������Ʈ�� ��(�߽�) ����
            Sprite sprite = Sprite.Create(currentStoryModel.MainImage, rect, pivot);

            imageComponent.sprite = sprite;
        }
        else
        {
            Debug.LogError("�ؽ��� �ε��� ���� �ʽ��ϴ�. : " + currentStoryModel.MainImage.name);
        }

        for(int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0,i);                   //Substring ���ڿ� �ڸ��� �Լ�
            textComponent.text = currentText;
            yield return new WaitForSeconds(delay);                  //delay �ʸ�ŭ For ���� ���� ��Ų��.
        }

        for (int i = 0; i < currentStoryModel.options.Length; i++)
        {
            buttonWay[i].gameObject.SetActive(true);
            yield return new WaitForSeconds(delay);
        }

        yield return new WaitForSeconds(delay);
    }
}
