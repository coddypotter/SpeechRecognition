using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;

namespace SpeechRecog
{
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine _recognizer = new SpeechRecognitionEngine();
        SpeechSynthesizer VAS = new SpeechSynthesizer();
        /// <summary>
        /// Above is init of speech dude.
        /// </summary>
        
        public Form1()
        {
            Choices listWords = new Choices("Hi", "Hello");
            GrammarBuilder GB = new GrammarBuilder(listWords);
            Grammar SudeepGrammer = new Grammar(GB);
            _recognizer.SetInputToDefaultAudioDevice();
            _recognizer.LoadGrammar(SudeepGrammer);
            _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(_recognizer_SpeechRecognized);
            _recognizer.RecognizeAsync(RecognizeMode.Multiple);
            InitializeComponent();
        }
        void _recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;
            MessageBox.Show(speech);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
