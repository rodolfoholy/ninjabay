using System;
using System.Collections.Generic;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Shared.Infra
{
    public interface IAppLogger
    {
        void Info(string message);
        void Info(string message, params object[] args);
        void Warn(string message);
        void Warn(string message, params object[] args);
        void Error(Exception e);
        void Error(string message, Exception e);
        void Fatal(Exception e);
        void Fatal(string message, Exception e);
    }
}