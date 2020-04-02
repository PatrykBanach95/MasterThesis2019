using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;//Used to send controll signals in real time
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;//Used to draw skeleton
using Microsoft.Kinect;
using ABB.Robotics.Controllers;
using ABB.Robotics.Controllers.Discovery;
using ABB.Robotics.Controllers.RapidDomain;

namespace PracaMagisterska
{
    public static class ExtensionsMethods
    {
        #region Body
        //Getting skeleton joint position value and scale it
        public static Joint ScaleTo(this Joint joint, double width, double height, float skeletonMaxX, float skeletonMaxY)
        {
            joint.Position = new CameraSpacePoint
            {
                X = Scale(width, skeletonMaxX, joint.Position.X),
                Y = Scale(height, skeletonMaxY, -joint.Position.Y),
                Z = joint.Position.Z
            };

            return joint;
        }

        public static Joint ScaleTo(this Joint joint, double width, double height)
        {
            return ScaleTo(joint, width, height, 1.0f, 1.0f);
        }

        private static float Scale(double maxPixel, double maxSkeleton, float position)
        {
            float value = (float)((((maxPixel / maxSkeleton) / 2) * position) + (maxPixel / 2));

            if (value > maxPixel)
            {
                return (float)maxPixel;
            }

            if (value < 0)
            {
                return 0;
            }

            return value;
        }

        #endregion

        #region Drawing

        public static void DrawSkeleton(this Canvas canvas, Body body)
        {
            //method draw skeleton at canvas component
            if (body == null) return;

            foreach (Joint joint in body.Joints.Values)
            {
                canvas.DrawPoint(joint); //Draw joints
            }
            //Draw lines between joints
            canvas.DrawLine(body.Joints[JointType.Head], body.Joints[JointType.Neck]);
            canvas.DrawLine(body.Joints[JointType.Neck], body.Joints[JointType.SpineShoulder]);
            canvas.DrawLine(body.Joints[JointType.SpineShoulder], body.Joints[JointType.ShoulderLeft]);
            canvas.DrawLine(body.Joints[JointType.SpineShoulder], body.Joints[JointType.ShoulderRight]);
            canvas.DrawLine(body.Joints[JointType.SpineShoulder], body.Joints[JointType.SpineMid]);
            canvas.DrawLine(body.Joints[JointType.ShoulderLeft], body.Joints[JointType.ElbowLeft]);
            canvas.DrawLine(body.Joints[JointType.ShoulderRight], body.Joints[JointType.ElbowRight]);
            canvas.DrawLine(body.Joints[JointType.ElbowLeft], body.Joints[JointType.WristLeft]);
            canvas.DrawLine(body.Joints[JointType.ElbowRight], body.Joints[JointType.WristRight]);
            canvas.DrawLine(body.Joints[JointType.WristLeft], body.Joints[JointType.HandLeft]);
            canvas.DrawLine(body.Joints[JointType.WristRight], body.Joints[JointType.HandRight]);
            canvas.DrawLine(body.Joints[JointType.HandLeft], body.Joints[JointType.HandTipLeft]);
            canvas.DrawLine(body.Joints[JointType.HandRight], body.Joints[JointType.HandTipRight]);
            canvas.DrawLine(body.Joints[JointType.HandTipLeft], body.Joints[JointType.ThumbLeft]);
            canvas.DrawLine(body.Joints[JointType.HandTipRight], body.Joints[JointType.ThumbRight]);
            canvas.DrawLine(body.Joints[JointType.SpineMid], body.Joints[JointType.SpineBase]);
            canvas.DrawLine(body.Joints[JointType.SpineBase], body.Joints[JointType.HipLeft]);
            canvas.DrawLine(body.Joints[JointType.SpineBase], body.Joints[JointType.HipRight]);
            canvas.DrawLine(body.Joints[JointType.HipLeft], body.Joints[JointType.KneeLeft]);
            canvas.DrawLine(body.Joints[JointType.HipRight], body.Joints[JointType.KneeRight]);
            canvas.DrawLine(body.Joints[JointType.KneeLeft], body.Joints[JointType.AnkleLeft]);
            canvas.DrawLine(body.Joints[JointType.KneeRight], body.Joints[JointType.AnkleRight]);
            canvas.DrawLine(body.Joints[JointType.AnkleLeft], body.Joints[JointType.FootLeft]);
            canvas.DrawLine(body.Joints[JointType.AnkleRight], body.Joints[JointType.FootRight]);
        }

        public static void DrawPoint(this Canvas canvas, Joint joint)
        {
            //Draw joints
            if (joint.TrackingState == TrackingState.NotTracked) return;

            joint = joint.ScaleTo(canvas.ActualWidth, canvas.ActualHeight);

            Ellipse ellipse = new Ellipse
            {
                Width = 20,
                Height = 20,
                Fill = new SolidColorBrush(Colors.LightBlue)
            };

            Canvas.SetLeft(ellipse, joint.Position.X - ellipse.Width / 2);
            Canvas.SetTop(ellipse, joint.Position.Y - ellipse.Height / 2);

            canvas.Children.Add(ellipse);
        }

        public static void DrawLine(this Canvas canvas, Joint first, Joint second)
        {
            //Draw lines between joints
            if (first.TrackingState == TrackingState.NotTracked || second.TrackingState == TrackingState.NotTracked) return;

            first = first.ScaleTo(canvas.ActualWidth, canvas.ActualHeight);
            second = second.ScaleTo(canvas.ActualWidth, canvas.ActualHeight);

            Line line = new Line
            {
                X1 = first.Position.X,
                Y1 = first.Position.Y,
                X2 = second.Position.X,
                Y2 = second.Position.Y,
                StrokeThickness = 8,
                Stroke = new SolidColorBrush(Colors.LightBlue)
            };

            canvas.Children.Add(line);
        }

        #endregion
        #region RobotControl
        public static string SelectAxis(Body controlBody, string selectedAxis)
        {
            //Method used to controll robot by gestures
            //Declared joints to create controll logic
            var rightHand = controlBody.Joints[JointType.HandRight];
            var rightElbow = controlBody.Joints[JointType.ElbowRight];
            var rightHandState = controlBody.HandRightState;

            var hipLeft = controlBody.Joints[JointType.HipLeft];
            var leftHand = controlBody.Joints[JointType.HandLeft];
            var head = controlBody.Joints[JointType.Head];
            var leftShoulder = controlBody.Joints[JointType.ShoulderLeft];
            var leftHandState = controlBody.HandLeftState;

            //positive direction control
            if (rightHand.Position.X > rightElbow.Position.X && leftHandState == HandState.Closed)
            {
                //axis x
                if (head.Position.Y > leftHand.Position.Y && leftHand.Position.Y > leftShoulder.Position.Y)
                {
                    selectedAxis = "1";
                }
                //axis y
                if (head.Position.Y > leftHand.Position.Y && leftHand.Position.Y < leftShoulder.Position.Y)
                {
                    selectedAxis = "2";
                }
                //axis z
                if (head.Position.Y < leftHand.Position.Y)
                {
                    selectedAxis = "3";
                }
            }
            //negative direction control
            else if (rightHand.Position.X < rightElbow.Position.X && leftHandState == HandState.Closed)
            {
                //axis x
                if (head.Position.Y > leftHand.Position.Y && leftHand.Position.Y > leftShoulder.Position.Y)
                {
                    selectedAxis = "4";
                }
                //axis y
                if (head.Position.Y > leftHand.Position.Y && leftHand.Position.Y < leftShoulder.Position.Y)
                {
                    selectedAxis = "5";
                }
                //axis z
                if (head.Position.Y < leftHand.Position.Y)
                {
                    selectedAxis = "6";
                }
            }

            else
            {
                selectedAxis = "0";//stop
            }
            return selectedAxis;
        }
        //Variables declared to send control data to robot controller
        const int PortNo = 5000;
        static string SERVER_IP = "127.0.0.1";
        //static string SERVER_IP = "10.1.75.161";

        public static string SendDataToController(string selectedAxis, string recivedPosition)
        {
            //method used to sending and reciving data to/from robot controller
            bool isIntString = selectedAxis.All(char.IsDigit);
            if (isIntString == true)
            {
                //crete TCP/IP connection with robot controller, send controll data to, recive robot position and then close connection
                TcpClient client = new TcpClient(SERVER_IP, PortNo);
                NetworkStream nwStream = client.GetStream();
                byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(selectedAxis);

                //---send the text---
                Console.WriteLine("Sending : " + selectedAxis);
                nwStream.Write(bytesToSend, 0, bytesToSend.Length);

                //---read back the text---
                byte[] bytesToRead = new byte[client.ReceiveBufferSize];
                int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
                Console.WriteLine("Received : " + Encoding.ASCII.GetString(bytesToRead, 0, bytesRead));
                
                client.Close();
                recivedPosition = Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);
            }
            return recivedPosition;
        }

        public static string SelectAxisWithVoice(Body controlBody, string selectedAxis, string voiceAxis)
        {
            //Method used to controll robot by gestures and voice
            //Joints declared to choose axis direction(positive/negative)
            var rightHand = controlBody.Joints[JointType.HandRight];
            var rightElbow = controlBody.Joints[JointType.ElbowRight];
            var rightHandState = controlBody.HandRightState;
            //positive direction control
            if (rightHand.Position.X > rightElbow.Position.X && rightHandState == HandState.Closed)
            {
                //axis x
                if (voiceAxis == "axis x")
                {
                    selectedAxis = "1";
                }
                //axis y
                if (voiceAxis == "axis y")
                {
                    selectedAxis = "2";
                }
                //axis z
                if (voiceAxis == "axis z")
                {
                    selectedAxis = "3";
                }
            }
            //negative direction control
            else if (rightHand.Position.X < rightElbow.Position.X && rightHandState == HandState.Closed)
            {
                //axis x
                if (voiceAxis == "axis x")
                {
                    selectedAxis = "4";
                }
                //axis y
                if (voiceAxis == "axis y")
                {
                    selectedAxis = "5";
                }
                //axis z
                if (voiceAxis == "axis z")
                {
                    selectedAxis = "6";
                }
            }
            else
            {
                selectedAxis = "0";//stop
            }
            return selectedAxis;
        }
        public static string SelectAxisByVoice(string selectedAxis, string voiceAxis)
        {
            //Method used to controll robot by voice
            //Conditions below choose axis and condition where robot should move
            //axis +x
            if (voiceAxis == "plus x")
            {
                selectedAxis = "1";
            }
            //axis +y
            else if(voiceAxis == "plus y")
            {
                selectedAxis = "2";
            }
            //axis +z
            else if(voiceAxis == "plus z")
            {
                selectedAxis = "3";
            }

            //axis -x
            else if(voiceAxis == "minus x")
            {
                selectedAxis = "4";
            }
            //axis -y
            else if(voiceAxis == "minus y")
            {
                selectedAxis = "5";
            }
            //axis -z
            else if(voiceAxis == "minus z")
            {
                selectedAxis = "6";
            }
            else
            {
                selectedAxis = "0";//stop
            }
            return selectedAxis;
        }
        public static string PickAndPlaceProgram(string selectedAxis, string voiceAxis)
        {
            //method used to choose and start program from robot memory
            if (voiceAxis == "pick and place")
            {
                selectedAxis = "7";
            }
            return selectedAxis;
        }
        #endregion
    }
}