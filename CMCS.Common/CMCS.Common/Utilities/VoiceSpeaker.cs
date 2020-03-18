using System.Collections.Generic;
//
using DotNetSpeech;

namespace CMCS.Common.Utilities
{
    /// <summary>
    /// 语音播报对象
    /// </summary>
    public class VoiceSpeaker
    {
        private string _Version = "1.0.0.0";

        public string Version
        {
            get { return _Version; }
        }

        SpVoice voice = new SpVoice();

        private string lastValue = string.Empty;

        /// <summary>
        /// 上一次播报内容
        /// </summary>
        public string LastValue
        {
            get { return lastValue; }
        }

        /// <summary>
        /// 设置语音
        /// </summary>
        /// <param name="Rate"></param>
        /// <param name="Volume"></param>
        /// <param name="VoiceName"></param>
        public void SetVoice(int Rate, int Volume, string VoiceName)
        {
            voice.Rate = Rate;
            voice.Volume = Volume;
            ISpeechObjectTokens arrVoices = voice.GetVoices();
            int index = 0;
            for (int i = 0; i < arrVoices.Count; i++)
            {
                if (arrVoices.Item(i).GetDescription() == VoiceName)
                {
                    index = i;
                    break;
                }
            }
            voice.Voice = voice.GetVoices().Item(index);
        }

        /// <summary>
        /// 重置播报内容
        /// </summary>
        public void Reset()
        {
            lastValue = string.Empty;
        }

        /// <summary>
        /// 文本播报
        /// </summary>
        /// <param name="value">内容</param>
        /// <param name="count">次数</param>
        /// <param name="reset">播报前重置</param>
        public void Speak(string value, int count, bool reset = true)
        {
            if (reset) Reset();

            //多音字转义
            value = value.Replace("重", "众");

            if (lastValue == value) return;

            lastValue = value;

            for (int i = 0; i < count; i++)
            {
                try
                {
                    voice.Speak(value, SpeechVoiceSpeakFlags.SVSFlagsAsync);
                }
                catch { }
            }

        }

        /// <summary>
        /// 文本播报（只读一次）
        /// </summary>
        /// <param name="value"></param>
        /// <param name="reset"></param>
        public void Speak(string value, bool reset = true)
        {
            Speak(value, 1, reset);
        }

        /// <summary>
        /// 获取本机所有语音包
        /// </summary>
        /// <returns></returns>
        public List<string> GetVoices()
        {
            List<string> list = new List<string>();
            ISpeechObjectTokens arrVoices = new SpVoice().GetVoices();
            for (int i = 0; i < arrVoices.Count; i++)
            {
                list.Add(arrVoices.Item(i).GetDescription());
            }
            return list;
        }
    }
}