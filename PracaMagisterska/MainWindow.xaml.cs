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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Kinect;//Library used to connect with Kinect V2 module
using ABB.Robotics.Controllers;//Library used to connect with robot controller
using ABB.Robotics.Controllers.Discovery;
using ABB.Robotics.Controllers.RapidDomain;
using Task = ABB.Robotics.Controllers.RapidDomain.Task;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.ComponentModel;
using System.Speech.Recognition;//Library used to speech recognition
using System.IO;

namespace PracaMagisterska
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Variables for used to connect and control Kinect
        private KinectSensor kinectSensor = null;
        BodyFrameReader bodyFrameReader = null;
        IList<Body> bodies = null;
        ulong bodyTrackingID = 0;
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        string voiceAxis = "stop";
        int voiceControl = 0;
        //Variables for used to connect and control robot controller
        private NetworkScanner scanner = null;
        private Controller controller = null;
        private Task[] tasks = null;
        private RapidData rdRobotPosition;
        private Pos robotPosition;
        private RapidData rdSpeed;
        private Num robotSpeed;
        private RapidData rdZone;
        private Num robotZone;
        private RapidData rdProgramStart;
        private Num programStart;
        ////Variables for used to send controls signals 
        private string selectedAxis = null;
        private string checkAxis = null;
        bool robotControl = false;
        bool startKinectControl = false;
        int framesPerSecond = 0;
        bool startSending = false;
        string recivedPosition = "0";
        bool startPickAndPlaceProgram;

        public MainWindow()
        {
            InitializeComponent();//Create main window
            CbSpeedFields();//Add robot speed values to combobox
            CbZoneFields();//Add robot zone values to combobox
            CbControlTypeFields();//Add robot control types values to combobox
            InitializeSpeech();//Start speech recognition mechanism
        }

        private void InitializeSpeech()
        {
            //method create and build control words library and strat speech recognition system
            Choices axes = new Choices();
            axes.Add(new string[] { "axis x", "axis y", "axis z",
                "plus x", "minus x", "plus y", "minus y", "plus z",
                "minus z", "pick and place", "stop" });
            GrammarBuilder gBuilder = new GrammarBuilder();
            gBuilder.Append(axes);
            Grammar grammar = new Grammar(gBuilder);

            recEngine.LoadGrammarAsync(grammar);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.SpeechRecognized += RecEngine_SpeechRecognized;
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void RecEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            //method search in recived data declared words and then assign voiceAxis field value
            switch (e.Result.Text)
            {
                case "axis x":
                    voiceAxis = "axis x";
                    break;
                case "axis y":
                    voiceAxis = "axis y";
                    break;
                case "axis z":
                    voiceAxis = "axis z";
                    break;
                case "plus x":
                    voiceAxis = "plus x";
                    break;
                case "minus x":
                    voiceAxis = "minus x";
                    break;
                case "plus y":
                    voiceAxis = "plus y";
                    break;
                case "minus y":
                    voiceAxis = "minus y";
                    break;
                case "plus z":
                    voiceAxis = "plus z";
                    break;
                case "minus z":
                    voiceAxis = "minus z";
                    break;
                case "pick and place":
                    voiceAxis = "pick and place";
                    //dodane
                    startPickAndPlaceProgram = true;
                    break;
                case "stop":
                    voiceAxis = "stop";
                    break;
            }
        }

        private void CbZoneFields()
        {
            //method add robot zones values
            cbZone.Items.Add(0);
            cbZone.Items.Add(1);
            cbZone.Items.Add(5);
            cbZone.Items.Add(10);
        }

        private void CbSpeedFields()
        {
            //method add robot speed values
            cbSpeed.Items.Add(10);
            cbSpeed.Items.Add(50);
            cbSpeed.Items.Add(100);
            cbSpeed.Items.Add(200);
        }
        private void CbControlTypeFields()
        {
            //method add robot control type values
            cbControlType.Items.Add("Gesty");
            cbControlType.Items.Add("Głos");
            cbControlType.Items.Add("Gesty + głos");
            cbControlType.Items.Add("Pick and place");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Event search, and if found connect to Kinect module and then search, and if found add to listView robot controllers
            kinectSensor = KinectSensor.GetDefault();

            if (kinectSensor != null)
            {
                kinectSensor.Open();
                bodyFrameReader = kinectSensor.BodyFrameSource.OpenReader();
                bodyFrameReader.FrameArrived += ReaderFrameArrived;
            }
            this.scanner = new NetworkScanner();
            this.scanner.Scan();
            ControllerInfoCollection controllers = scanner.Controllers;
            //for each found controller method add item in listView(create new RobotController object and assign them found controller values)
            foreach (ControllerInfo controllerInfo in controllers)
            {
                listViewRobotControlers.Items.Add(new RobotController
                {
                    IPAddress = controllerInfo.IPAddress.ToString(),
                    Availability = controllerInfo.Availability.ToString(),
                    Virtual = controllerInfo.IsVirtual.ToString(),
                    SystemName = controllerInfo.SystemName,
                    RobotWareVersion = controllerInfo.Version.ToString(),
                    ControllerName = controllerInfo.ControllerName,
                    Tag = controllerInfo
                });
            }
        }


        private void Window_Closed(object sender, EventArgs e)
        {
            //Event call EndConnection method
            EndConnection();
        }

        private void ReaderFrameArrived(object sender, BodyFrameArrivedEventArgs e)
        {
            /* Event check if recived from Kinect module data contains person skeleton and if is then call DrawSkeleton method to draw it on canvas.
             * Next check which type of controll is choosen and then assign proper value to one of control variables and then send it to robot controller.
             * NAt the end wait when robot controller send back robot position and then add(showed) proper position values to main window(sliders,labels)*/
            using (var frameReference = e.FrameReference.AcquireFrame())
            {
                if (frameReference != null)
                {
                    canvas.Children.Clear();//clear old skeleton

                    bodies = new Body[frameReference.BodyFrameSource.BodyCount];

                    frameReference.GetAndRefreshBodyData(bodies);

                    foreach (var body in bodies)
                    {
                        if (body != null && body.IsTracked)
                        {
                            if (bodyTrackingID == 0 || bodyTrackingID != body.TrackingId)
                            {
                                bodyTrackingID = body.TrackingId;
                            }
                            else
                            {
                                // Draw skeleton.
                                canvas.DrawSkeleton(body);
                                if (robotControl && framesPerSecond == 6 && startKinectControl)//check which controll type is choosen and then choose proper method and sent to it arguments
                                {
                                    if (voiceControl == 1)
                                    {
                                        selectedAxis = ExtensionsMethods.SelectAxisWithVoice(body, selectedAxis, voiceAxis);
                                    }
                                    else if (voiceControl == 2)
                                    {
                                        selectedAxis = ExtensionsMethods.SelectAxis(body, selectedAxis);
                                    }
                                    else if (voiceControl == 3)
                                    {
                                        selectedAxis = ExtensionsMethods.SelectAxisByVoice(selectedAxis, voiceAxis);
                                    }
                                    else if (voiceControl == 4 )
                                    {
                                        
                                        if (startPickAndPlaceProgram)
                                        {
                                            
                                            selectedAxis = ExtensionsMethods.PickAndPlaceProgram(selectedAxis, voiceAxis);
                                            startPickAndPlaceProgram = false;
                                        }
                                        else
                                        {
                                            selectedAxis = "0";
                                        }
                                    }
                                    //Show which axis is actually controlled
                                    if(selectedAxis == "1" || selectedAxis == "4" || voiceAxis == "axis x")
                                    {
                                        controlledAxis.Content = "X";
                                    }
                                    else if(selectedAxis == "2" || selectedAxis == "5" || voiceAxis == "axis y")
                                    {
                                        controlledAxis.Content = "Y";
                                    }
                                    else if (selectedAxis == "3" || selectedAxis == "6" || voiceAxis == "axis z")
                                    {
                                        controlledAxis.Content = "Z";
                                    }
                                    else
                                    {
                                        controlledAxis.Content = "----";
                                    }
                                    //Use SendDataToController method to send controll signals and recived and assign to recivedPosition variable actual robot position
                                    recivedPosition = ExtensionsMethods.SendDataToController(selectedAxis, recivedPosition);
                                    //Prepare recived data and show actual position at main window
                                    if (recivedPosition.Length >= 7)
                                    {
                                        int numberOfChar = recivedPosition.Length;
                                        string recivedPosition1 = recivedPosition.Remove(numberOfChar - 1,1);
                                        string recivedPosition2 = recivedPosition1.Remove(0,1);
                                        string[] recivedPosition3 = recivedPosition2.Split(',');
                                        int i = 0;
                                        foreach (string position in recivedPosition3)
                                        {
                                            if (i == 0)
                                            {
                                                sliderAxisX.Value = Convert.ToDouble(position);
                                                lblValueAxisX.Content = position;
                                            }
                                            else if (i == 1)
                                            {
                                                sliderAxisY.Value = Convert.ToDouble(position);
                                                lblValueAxisY.Content = position;
                                            }
                                            else if (i == 2)
                                            {
                                                sliderAxisZ.Value = Convert.ToDouble(position);
                                                lblValueAxisZ.Content = position;
                                            }
                                            i++;
                                        }
                                    }
                                    framesPerSecond = 0;  
                                }
                                else
                                {
                                    framesPerSecond++;
                                    checkAxis = selectedAxis;
                                    startKinectControl = true;

                                }                  
                            }   
                        }
                    }
                }
            }
        }

        private void EndConnection()
        {
            //method disconnect application from Kinect V2 module and stop robot controller program
            recEngine.RecognizeAsyncStop();
            if (bodyFrameReader != null)
            {
                bodyFrameReader.Dispose();
            }
            if (kinectSensor != null)
            {
                kinectSensor.Close();
            }

            if (controller != null)
            {
                using (Mastership m = Mastership.Request(controller.Rapid))
                {
                    controller.Rapid.Stop(StopMode.Immediate);
                }
            }

        }

        private void ListViewRobotControlers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Event try connect with robot controller choosen from listView component, and if connect then informs about it on main window
            RobotController item = (RobotController)listViewRobotControlers.SelectedItem;

            if (item.Tag != null)
            {
                ControllerInfo controllerInfo = (ControllerInfo)item.Tag;
                if
                (controllerInfo.Availability == Availability.Available)
                {
                    if (this.controller != null)
                    {
                        this.controller.Logoff();
                        this.controller.Dispose();
                        this.controller = null;
                    }
                    this.controller = ControllerFactory.CreateFrom(controllerInfo);
                    this.controller.Logon(UserInfo.DefaultUser);
                    lblSelectedController.Content = "Połączono z wybranym kontrolerem";
                    lblSelectedController.Visibility = Visibility.Visible;
          
                    ConnectToRobotProgram();
                    

                }
                else
                {
                    MessageBox.Show("Selected controller not available.");
                }
            }
        }

        private void ConnectToRobotProgram()
        {
            //method try connect to robot controller and getting data from it (robot speed value, robot zone value, programStart variable and also actual robot position) 
            try
            {
                if (controller.OperatingMode == ControllerOperatingMode.Auto)
                {
                    tasks = controller.Rapid.GetTasks();
                    using (Mastership m = Mastership.Request(controller.Rapid))
                    {
                        rdRobotPosition = tasks[0].GetRapidData("Module1", "position1");
                        if (rdRobotPosition.Value is Pos)
                        {
                            robotPosition = (Pos)rdRobotPosition.Value;

                            sliderAxisX.Value = robotPosition.X;
                            lblValueAxisX.Content = robotPosition.X.ToString();
                            sliderAxisY.Value = robotPosition.Y;
                            lblValueAxisY.Content = robotPosition.Y.ToString();
                            sliderAxisZ.Value = robotPosition.Z;
                            lblValueAxisZ.Content = robotPosition.Z.ToString();
                        }
                        rdZone = tasks[0].GetRapidData("Module1", "robotZone");
                        rdSpeed = tasks[0].GetRapidData("Module1", "robotSpeed");
                        rdProgramStart = tasks[0].GetRapidData("Module1", "programStart");
                    }
                }
                else
                {
                    MessageBox.Show("Automatic mode is required to start execution from a remote client.");
                }
            }
            catch (System.InvalidOperationException ex)
            {
                MessageBox.Show("Mastership is held by another client." + ex.Message);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Unexpected error occurred: " + ex.Message);
            }
        }

        private void RobotSettings_Click(object sender, RoutedEventArgs e)
        {
            //Send to robot controller speed and zone values and then start robot program
            using (Mastership m = Mastership.Request(controller.Rapid))
            {
                programStart.FillFromString2("1");
                rdProgramStart.Value = programStart;
                rdZone.Value = robotZone;
                rdSpeed.Value = robotSpeed;
                tasks[0].ResetProgramPointer();
                tasks[1].ResetProgramPointer();
                tasks[0].SetProgramPointer("Module1", "main");
                tasks[1].SetProgramPointer("Listening", "main");
                controller.Rapid.Start();
            }
            robotControl = true;

        }
        // 2 methods below change string data to proper robot controller format data
        private void CbZone_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            robotZone.FillFromString2(cbZone.SelectedValue.ToString());
        }

        private void CbSpeed_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            robotSpeed.FillFromString2(cbSpeed.SelectedValue.ToString());
        }
        
        private void CbControlType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //event choose control type
            selectedAxis = cbControlType.SelectedValue.ToString();
            if(cbControlType.SelectedValue.ToString() == "Gesty + głos")
            {
                voiceControl = 1;
            }
            else if(cbControlType.SelectedValue.ToString() == "Gesty")
            {
                voiceControl = 2;
            }
            else if(cbControlType.SelectedValue.ToString() == "Głos")
            {
                voiceControl = 3;
            }
            else if(cbControlType.SelectedValue.ToString() == "Pick and place")
            {
                voiceControl = 4;
            }
        }

        private void Instruction_Click(object sender, RoutedEventArgs e)
        {
            //event open application instruction window
            InstructionWindow programInstruction = new InstructionWindow();
            programInstruction.ShowDialog();
        }

        private void Information_Click(object sender, RoutedEventArgs e)
        {
            //event open information about application window
            InformationWindow informationWindow = new InformationWindow();
            informationWindow.ShowDialog();
        }
    }
}
