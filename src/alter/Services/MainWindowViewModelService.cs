﻿using MsRdcAx;

namespace AlterApp.Services
{
    internal class MainWindowViewModelService : IMainWindowViewModelService
    {
        public string BuildWindowTitle(string appName, string userNmae, string remoteComputer, string remotePort)
        {
            if (!string.IsNullOrWhiteSpace(userNmae) && !string.IsNullOrWhiteSpace(remoteComputer) && !string.IsNullOrWhiteSpace(remotePort))
            {
                return string.Format("{0}@{1}:{2} - {3}", userNmae, remoteComputer, remotePort, appName);
            }
            else if (!string.IsNullOrWhiteSpace(userNmae) && !string.IsNullOrWhiteSpace(remoteComputer))
            {
                return string.Format("{0}@{1} - {2}", userNmae, remoteComputer, appName);
            }
            else if (!string.IsNullOrWhiteSpace(remoteComputer) && !string.IsNullOrWhiteSpace(remotePort))
            {
                return string.Format("{0}:{1} - {2}", remoteComputer, remotePort, appName);
            }
            else if (!string.IsNullOrWhiteSpace(remoteComputer))
            {
                return string.Format("{0} - {1}", remoteComputer, appName);
            }
            else
            {
                return appName;
            }
        }

        public string BuildDestinationDisplayText(string userNmae, string remoteComputer, string remotePort)
        {
            const string PlaceHolderText = "????";
            var userNamePart = string.IsNullOrWhiteSpace(userNmae) ? PlaceHolderText : userNmae;
            var remoteComputerPart = string.IsNullOrWhiteSpace(remoteComputer) ? PlaceHolderText : remoteComputer;
            var remotePortPart = string.IsNullOrWhiteSpace(remotePort) ? PlaceHolderText : remotePort;
            return string.Format("{0}@{1}:{2}", userNamePart, remoteComputerPart, remotePortPart);
        }

        public bool ShouldShowDisconnectReason(RdpClientDisconnectReason lastDisconnectReason)
        {
            switch (lastDisconnectReason.Reason)
            {
                case RdpClientDisconnectReasonCode.NoInfo:
                    return lastDisconnectReason.ExtendedReason switch
                    {
                        RdpClientExtendedDisconnectReasonCode.NoInfo => false,
                        _ => true,
                    };
                case RdpClientDisconnectReasonCode.LocalNotError:
                    return lastDisconnectReason.ExtendedReason switch
                    {
                        RdpClientExtendedDisconnectReasonCode.NoInfo => false,
                        _ => true,
                    };
                //case RdpClientDisconnectReasonCode.RemoteByUser:
                //    return lastDisconnectReason.ExtendedReason switch
                //    {
                //        RdpClientExtendedDisconnectReasonCode.RpcInitiatedDisconnectByUser => false,
                //        RdpClientExtendedDisconnectReasonCode.LogoffByUser => false,
                //        _ => true,
                //    };
                case RdpClientDisconnectReasonCode.AuthenticationWarningDismissed:
                    return false;
                default:
                    return true;
            }
        }
    }
}