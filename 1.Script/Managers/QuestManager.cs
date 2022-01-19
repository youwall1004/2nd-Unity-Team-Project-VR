using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    Dictionary<int, string[]> questData;
    private void Awake()
    {   // int 값 : 랜덤 추출값 넣음
        //string 첫번째 배열 : 신청자명 , 두번째 배열 : 퀘스트 내용
        questData = new Dictionary<int, string[]>();
        OpenedMine_1();
        OpenedMine_2();
        OpenedMine_3();
        OpenedMine_4();
        OpenedMine_5();
        OpenedMine_6();
    }

    /*첫 광산 해금시*/
    void OpenedMine_1()
    {
        questData.Add(1, new string[] { "Mrs.Jung", "아들이 가지고 놀만한 가벼운 검이 필요하다네" });
        questData.Add(2, new string[] { "James", "길드전을 준비할만한 훈련용 검을 장만할 계획입니다." });
        questData.Add(3, new string[] { "중앙 교회", "신전에 전시할 가벼운 검을 준비해주게." });
        questData.Add(4, new string[] { "KATE 대장간", "경쟁자 Smith의 검이 쓸만한지 궁금한걸?" });
        questData.Add(5, new string[] { "경비대", "초급 경비대원들이 사용할 만한 검을 보내주게." });
    }

    /*두번째 광산 해금시*/
    void OpenedMine_2()
    {
        questData.Add(1, new string[] { "Mrs.Jung", "아들이 두번째 광산에 가고싶다네요. 빈손으로 보낼 수 없죠." });
        questData.Add(2, new string[] { "James", "광산에 가서 쓸만한 칼을 장만할 계획입니다." });
        questData.Add(3, new string[] { "중앙 교회", "교회에 봉사하는 전사들에게 하사할 검이 필요하네." });
        questData.Add(4, new string[] { "KATE 대장간", "경쟁자 Smith의 검이 좋아졌다는 소문이 있던데." });
        questData.Add(5, new string[] { "경비대", "초급 경비대원들이 더 좋은 검을 달라고 아우성이야." });
    }

    /*세번째 광산 해금시*/
    void OpenedMine_3()
    {
        questData.Add(1,new string[] { "Mrs.Jung", "아들이 두번째 광산에 가고싶다네요. 빈손으로 보낼 수 없죠." });
        questData.Add(2,new string[] { "James", "광산에 가서 쓸만한 칼을 장만할 계획입니다." });
        questData.Add(3,new string[] { "중앙 교회", "신전에 전시할 검을 준비해주게." });
        questData.Add(4,new string[] { "KATE 대장간", "경쟁자 Smith의 검이 좋아졌다는 소문이 있던데." });
        questData.Add(5,new string[] { "경비대", "초급 경비대원들이 더 좋은 검을 달라고 아우성이야." });
    }

    /*네번째 광산 해금시*/
    void OpenedMine_4()
    {
        questData.Add(1, new string[] { "Mrs.Jung", "아들이 두번째 광산에 가고싶다네요. 빈손으로 보낼 수 없지요.." });
        questData.Add(2, new string[] { "James", "길드전을 준비할만한 훈련용 검을 장만할 계획입니다." });
        questData.Add(3, new string[] { "중앙 교회", "신전에 전시할 가벼운 검을 준비해주게." });
        questData.Add(4, new string[] { "KATE 대장간", "경쟁자 Smith의 검이 쓸만한지 궁금한걸?" });
        questData.Add(5, new string[] { "경비대", "수도원에 접근하는 스켈레톤을 무찌를 검을 보내주게." });
    }

    /*다섯번째 광산 해금시*/
    void OpenedMine_5()
    {
        questData.Add(1, new string[] { "Mrs.Jung", "아들이 두번째 광산에 가고싶다네요. 빈손으로 보낼 수 없지요.." });
        questData.Add(2, new string[] { "James", "길드전을 준비할만한 훈련용 검을 장만할 계획입니다." });
        questData.Add(3, new string[] { "중앙 교회", "신전에 전시할 가벼운 검을 준비해주게." });
        questData.Add(4, new string[] { "KATE 대장간", "경쟁자 Smith의 검이 쓸만한지 궁금한걸?" });
        questData.Add(5, new string[] { "경비대", "수도원에 접근하는 스켈레톤을 무찌를 검을 보내주게." });
    }
    /*엔딩씬 유미와 대사*/
    void OpenedMine_6()
    {
        questData.Add(1, new string[] { "Mrs.Jung", "아들이 두번째 광산에 가고싶다네요. 빈손으로 보낼 수 없지요.." });
        questData.Add(2, new string[] { "James", "길드전을 준비할만한 훈련용 검을 장만할 계획입니다." });
        questData.Add(3, new string[] { "중앙 교회", "신전에 전시할 가벼운 검을 준비해주게." });
        questData.Add(4, new string[] { "KATE 대장간", "경쟁자 Smith의 검이 쓸만한지 궁금한걸?" });
        questData.Add(5, new string[] { "경비대", "수도원에 접근하는 스켈레톤을 무찌를 검을 보내주게." });
    }
    //_id에 랜덤값 넣고 
    //public string GetMonoData(int _id, int ownerStr, int missionstr)
    //{
        //if (str_Idx == questData[_id].Length)
        //{
        //    return null;
        //}
        //else
        //{
            //return questData[_id][str_Idx];
        //}
   // }
}
