using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PracaMagisterska
{
    /// <summary>
    /// Interaction logic for Instruction.xaml
    /// </summary>
    public partial class InstructionWindow : Window
    {
        MainWindow mainWindow;
        public InstructionWindow()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Close();
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Voice_Click(object sender, RoutedEventArgs e)
        {
            HideElements();
            Voice.Visibility = Visibility.Visible;
            Voice1.Visibility = Visibility.Visible;
            Voice2.Visibility = Visibility.Visible;
            Voice3.Visibility = Visibility.Visible;
            Voice4.Visibility = Visibility.Visible;
            Voice5.Visibility = Visibility.Visible;
            Voice6.Visibility = Visibility.Visible;
            Voice7.Visibility = Visibility.Visible;
        }

        private void VoicePlusGesture_Click(object sender, RoutedEventArgs e)
        {
            HideElements();
            VoiceAndGesture.Visibility = Visibility.Visible;
            VoiceAndGesture1.Visibility = Visibility.Visible;
            VoiceAndGesture2.Visibility = Visibility.Visible;
            VoiceAndGesture3.Visibility = Visibility.Visible;
            VoiceAndGesture4.Visibility = Visibility.Visible;
            VoiceAndGesture5.Visibility = Visibility.Visible;
            VoiceAndGesture6.Visibility = Visibility.Visible;
            VoiceAndGesture7.Visibility = Visibility.Visible;
            VoiceAndGesture8.Visibility = Visibility.Visible;
            VoiceAndGesture9.Visibility = Visibility.Visible;
            VoiceAndGesture10.Visibility = Visibility.Visible;
            VoiceAndGesture11.Visibility = Visibility.Visible;
            VoiceAndGesture12.Visibility = Visibility.Visible;
        }

        private void Gesture_Click(object sender, RoutedEventArgs e)
        {
            HideElements();
            Gesture.Visibility = Visibility.Visible;
            Gesture1.Visibility = Visibility.Visible;
            Gesture2.Visibility = Visibility.Visible;
            Gesture3.Visibility = Visibility.Visible;
            Gesture4.Visibility = Visibility.Visible;
            Gesture5.Visibility = Visibility.Visible;
            Gesture6.Visibility = Visibility.Visible;
            Gesture8.Visibility = Visibility.Visible;
            Gesture9.Visibility = Visibility.Visible;
            Gesture11.Visibility = Visibility.Visible;
            Gesture12.Visibility = Visibility.Visible;
            Gesture14.Visibility = Visibility.Visible;
            Gesture15.Visibility = Visibility.Visible;
            Gesture16.Visibility = Visibility.Visible;
            Gesture17.Visibility = Visibility.Visible;
            Gesture18.Visibility = Visibility.Visible;
            Gesture19.Visibility = Visibility.Visible;
            Gesture21.Visibility = Visibility.Visible;
            Gesture22.Visibility = Visibility.Visible;
            Gesture23.Visibility = Visibility.Visible;
            Gesture24.Visibility = Visibility.Visible;
            Gesture25.Visibility = Visibility.Visible;
            Gesture26.Visibility = Visibility.Visible;
            Gesture27.Visibility = Visibility.Visible;
            Gesture28.Visibility = Visibility.Visible;

        }

        private void PickAndPlace_Click(object sender, RoutedEventArgs e)
        {
            HideElements();
            PickAnPlace.Visibility = Visibility.Visible;
            PickAnPlace1.Visibility = Visibility.Visible;
            PickAnPlace2.Visibility = Visibility.Visible;
            PickAnPlace3.Visibility = Visibility.Visible;
            PickAnPlace4.Visibility = Visibility.Visible;
            PickAnPlace5.Visibility = Visibility.Visible;
            PickAnPlace6.Visibility = Visibility.Visible;

        }
        private void HideElements()
        {
            Voice.Visibility = Visibility.Hidden;
            Voice1.Visibility = Visibility.Hidden;
            Voice2.Visibility = Visibility.Hidden;
            Voice3.Visibility = Visibility.Hidden;
            Voice4.Visibility = Visibility.Hidden;
            Voice5.Visibility = Visibility.Hidden;
            Voice6.Visibility = Visibility.Hidden;
            Voice7.Visibility = Visibility.Hidden;
            VoiceAndGesture.Visibility = Visibility.Hidden;
            VoiceAndGesture1.Visibility = Visibility.Hidden;
            VoiceAndGesture2.Visibility = Visibility.Hidden;
            VoiceAndGesture3.Visibility = Visibility.Hidden;
            VoiceAndGesture4.Visibility = Visibility.Hidden;
            VoiceAndGesture5.Visibility = Visibility.Hidden;
            VoiceAndGesture6.Visibility = Visibility.Hidden;
            VoiceAndGesture7.Visibility = Visibility.Hidden;
            VoiceAndGesture8.Visibility = Visibility.Hidden;
            VoiceAndGesture9.Visibility = Visibility.Hidden;
            VoiceAndGesture10.Visibility = Visibility.Hidden;
            VoiceAndGesture11.Visibility = Visibility.Hidden;
            VoiceAndGesture12.Visibility = Visibility.Hidden;
            Gesture.Visibility = Visibility.Hidden;
            Gesture1.Visibility = Visibility.Hidden;
            Gesture2.Visibility = Visibility.Hidden;
            Gesture3.Visibility = Visibility.Hidden;
            Gesture4.Visibility = Visibility.Hidden;
            Gesture5.Visibility = Visibility.Hidden;
            Gesture6.Visibility = Visibility.Hidden;
            Gesture8.Visibility = Visibility.Hidden;
            Gesture9.Visibility = Visibility.Hidden;
            Gesture11.Visibility = Visibility.Hidden;
            Gesture12.Visibility = Visibility.Hidden;
            Gesture14.Visibility = Visibility.Hidden;
            Gesture15.Visibility = Visibility.Hidden;
            Gesture16.Visibility = Visibility.Hidden;
            Gesture17.Visibility = Visibility.Hidden;
            Gesture18.Visibility = Visibility.Hidden;
            Gesture19.Visibility = Visibility.Hidden;
            Gesture21.Visibility = Visibility.Hidden;
            Gesture22.Visibility = Visibility.Hidden;
            Gesture23.Visibility = Visibility.Hidden;
            Gesture24.Visibility = Visibility.Hidden;
            Gesture25.Visibility = Visibility.Hidden;
            Gesture26.Visibility = Visibility.Hidden;
            Gesture27.Visibility = Visibility.Hidden;
            Gesture28.Visibility = Visibility.Hidden;
            PickAnPlace.Visibility = Visibility.Hidden;
            PickAnPlace1.Visibility = Visibility.Hidden;
            PickAnPlace2.Visibility = Visibility.Hidden;
            PickAnPlace3.Visibility = Visibility.Hidden;
            PickAnPlace4.Visibility = Visibility.Hidden;
            PickAnPlace5.Visibility = Visibility.Hidden;
            PickAnPlace6.Visibility = Visibility.Hidden;
        }
    }
}
