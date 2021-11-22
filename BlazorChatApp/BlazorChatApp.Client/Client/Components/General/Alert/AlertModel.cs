using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorChatApp.Client.Components.General.Alert
{
    public class AlertModel
    {
        public static Dictionary<AlertType, string> alertTypeClassDictionary = Enum.GetValues(typeof(AlertType)).Cast<AlertType>().ToDictionary(t => t, t => "alert-" + t.ToString().ToLower());
        public bool ShowAlert { get; set; } = false;
        public string AlertMessage { get; set; }
        public AlertType AlertType { get; set; }
        public AlertModel()
        {

        }

        public AlertModel(AlertType alertType, string message, bool show )
        {
            AlertType = alertType;
            AlertMessage = message;
            ShowAlert = show;


        }
        public string GetAlertCSSClass(){
            return alertTypeClassDictionary.GetValueOrDefault(AlertType);
        }
    }
}
