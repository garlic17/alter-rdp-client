﻿using AlterApp.ViewModels;
using MsRdcAx;

namespace AlterApp.Services.Interfaces
{
    internal interface IMainWindowViewModelService
    {
        public string GetWindowTitle(string connectionNickname, string remoteComputer, string remotePort, string userNmae);

        public string GetRemoteComputerWithPort(string remoteComputer, string remotePort);

        public ConnectionInfoHeaderVisibility GetConnectionHeaderVisibility(string remoteComputer, string userName, string connectionTitle);

        public bool ValidateRemoteComputer(string remoteComputer);

        public bool ValidateRemotePort(string remotePort);

        public bool ValidateUserName(string userName);

        public RdpClientHost GetRdpClientInstance();

        public bool ShouldShowDisconnectReason(RdpClientDisconnectReason lastDisconnectReason);

        public string GetVersionInfoText();

        public void OpenProjectWebsite();
    }
}
