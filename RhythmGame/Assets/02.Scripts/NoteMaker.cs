using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class NoteMaker : MonoBehaviour
{
    private SongData _songData;
    private KeyCode[] _keys = { KeyCode.S, KeyCode.D, KeyCode.F, KeyCode.Space, KeyCode.J, KeyCode.K, KeyCode.L };
    [SerializeField] private VideoPlayer _vp;
    [SerializeField] private int _level = 1;
    public bool DoRecord;


    //===================================================================================
    //=******************************* Public Methods ***********************************
    //===================================================================================

    /// <summary>
    /// 노래 데이터 생성, 녹화시작
    /// </summary>
    public void StartRecording()
    {
        if (DoRecord)
            return;

        _songData = new SongData(_vp.clip.name, _level);
        _vp.Play();
        DoRecord = true;
        
    }
    /// <summary>
    /// 키 입력 체크하면서 해당 키에 대한 노트 데이터 생성
    /// </summary>
    public void Recording()
    {
        foreach(KeyCode key in _keys)
        {
            if (Input.GetKeyDown(key))
                CreateNoteData(key);
        }
    }

    /// <summary>
    /// 녹화중 정지버튼 누를 시 노래데이터 저장 후 비디오 멈춤
    /// </summary>
    public void StopRecording()
    {
        if (DoRecord == false)
            return;
        
            SaveSongData();
            _songData = null;
            _vp.Stop();
    }


    //===================================================================================
    //=****************************** Private Methods ***********************************
    //===================================================================================


    private void Update()
    {
        if (DoRecord)
            Recording();
    }
    private void CreateNoteData(KeyCode keyCode)
    {
        NoteData noteData = new NoteData();

        float time = (float)System.Math.Round(_vp.time, 2); //반올림 함수
        noteData.Time = time;
        noteData.Key = keyCode;

        _songData.Notes.Add(noteData);
        Debug.Log($"NotesMaker : Note created, {keyCode}, {time} ");

    }

    private void SaveSongData()
    {
        // 저장 패널 띄우기 -> 경로를 반환
        string dir = UnityEditor.EditorUtility.SaveFilePanel("저장할 곳을 지정하세요","",$"{_songData.Name}", "json" );
        // dir에 저장한 저장 경로를 json으로 저장
        System.IO.File.WriteAllText(dir, JsonUtility.ToJson(_songData));
    }
}
