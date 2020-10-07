using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(1000, new string[] { "안녕?:0", "이 곳에 처음 왔구나?:1" });
        talkData.Add(2000, new string[] { "이 연못에는 보물이 있어!:1" });
        talkData.Add(100, new string[] { "평범한 상자인듯 하다." });
        talkData.Add(200, new string[] { "누군가 사용했던 흔적이 있다." });

        //Quest Talk
        talkData.Add(1010, new string[] { "어서와.:0", "이 마을에 놀라운 전설이 있다는데:1", "오른쪽 호수 쪽에 루도가 알려줄거야:1" });
        talkData.Add(2011, new string[] { "여어.:0", "이 호수의 전설을 들으로 온거야?:1", "그럼 일 좀 하나 해주면 좋을텐데...:1", "내 집 근처에 떨어진 동전 좀 주워줬으면 해.:2" });

        talkData.Add(1020, new string[] { "루도의 동전?:1", "돈을 흘리고 다니면 못쓰지!?:3", "나중에 루도에게 한마디 해야겠어.:3" });
        talkData.Add(2020, new string[] { "찾으면 꼭 좀 가져다 줘.:1" });
        talkData.Add(5020, new string[] { "근처에서 동전을 찾았다.:" });
        talkData.Add(2021, new string[] { "엇, 찾아줘서 고마워!:2" });

        portraitData.Add(1000, portraitArr[0]);
        portraitData.Add(1001, portraitArr[1]);
        portraitData.Add(1002, portraitArr[2]);
        portraitData.Add(2000, portraitArr[4]);
        portraitData.Add(1003, portraitArr[3]);
        portraitData.Add(2001, portraitArr[5]);
        portraitData.Add(2002, portraitArr[6]);
        portraitData.Add(2003, portraitArr[7]);
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id - id % 10))
                return GetTalk(id - id % 100, talkIndex);
            else
                return GetTalk(id - id % 10, talkIndex);
        }

        if (talkIndex == talkData[id].Length)
        {
            return null;
        }
        else
        {
            return talkData[id][talkIndex];
        }
    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
}
