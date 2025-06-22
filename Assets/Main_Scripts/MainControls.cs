using UnityEngine;
using Whisper.Utils;
using UnityEngine.UI;
using Whisper;
using TMPro;
using System.Diagnostics;
using LLMUnity;
using Piper;

public class MainControls : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public WhisperManager whisper;
    public MicrophoneRecord microphoneRecord;
    public LLMCharacter llmCharacter;
    public PiperManager piper; 
    [SerializeField] Button MicControl;
    [SerializeField] TMP_Text ButtonText;
    [SerializeField] AudioSource audioSource;
    public bool streamSegments = true;

    private string _buffer;
    private string AIResposne;

    void Awake()
    {
        whisper.OnNewSegment += OnNewSegment;
        whisper.OnProgress += OnProgressHandler;
        microphoneRecord.OnRecordStop += OnRecordStop;
        MicControl.onClick.AddListener(OnButtonPressed);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnButtonPressed()
    {
        if(!microphoneRecord.IsRecording){
            microphoneRecord.StartRecord();
            ButtonText.text = "Stop";
        }
        else
        {
            microphoneRecord.StopRecord();
            ButtonText.text = "Record";
        }
    }
    async void OnRecordStop(AudioChunk recordedAudio)
    {
        ButtonText.text = "Record";
        _buffer = "";

        var sw = new Stopwatch();
        sw.Start();
        
        var res = await whisper.GetTextAsync(recordedAudio.Data, recordedAudio.Frequency, recordedAudio.Channels);
        if (res == null ) 
            return;

        var time = sw.ElapsedMilliseconds;
        var rate = recordedAudio.Length / (time * 0.001f);
        //timeText.text = $"Time: {time} ms\nRate: {rate:F1}x";

        var text = res.Result;
        if (true)
            text += $"\n\nLanguage: {res.Language}";
        print(text);
        //outputText.text = text;
        //UiUtils.ScrollDown(scroll);
        StartLLMChat(text);
    }

    void OnNewSegment(WhisperSegment segment)
    {
        if (!streamSegments)
                return;

            _buffer += segment.Text;
            //outputText.text = _buffer + "...";
    }

    void OnProgressHandler(int Progress)
    {
        //Todo
    }

    void StartLLMChat(string prompt)
    {
        print("Sent to LLM");
        var res = llmCharacter.Chat(prompt,SetAIText, AIReplyComplete);
    }

    void SetAIText(string response){
        //todo;
        AIResposne = response;
        
    }
    void AIReplyComplete()
    {
        print(AIResposne);
        LLMSpeak(AIResposne);
    }

    async void LLMSpeak(string response){
        var sw = new System.Diagnostics.Stopwatch();
        sw.Start();
        print("Starting TTS");
        var audio = piper.TextToSpeech(response);
        print("TTS Conpleted");
        //timerText.text = $"Time: {sw.ElapsedMilliseconds} ms";
        audioSource.Stop();
        if (audioSource && audioSource.clip)
            Destroy(audioSource.clip);

        audioSource.clip = await audio;
        audioSource.Play();

    }
}
