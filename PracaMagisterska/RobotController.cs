using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;
using ABB.Robotics.Controllers;
using ABB.Robotics.Controllers.Discovery;

namespace PracaMagisterska
{
    class RobotController
    {
        public string IPAddress { get; set; }
        public string RobotID { get; set; }
        public string Availability { get; set; }
        public string Virtual { get; set; }
        public string SystemName { get; set; }
        public string RobotWareVersion { get; set; }
        public string ControllerName { get; set; }
        public ControllerInfo Tag { get; set; }
    }
}
