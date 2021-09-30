// Decompiled with JetBrains decompiler
// Type: ESB_ConnectionPoints.SamplePlugins.File.OutgoingConnectionPointFactory
// Assembly: ESB_ConnectionPoints.SamplePlugins.File, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BDABA861-D09F-44D5-A4A8-DDA719527C99
// Assembly location: \\sd-esb-adapter2\C$\ProgramData\Datareon\ESB\Plugins\Patio(SOAP client)-2.0.0.11-dotNET-WINDOWS\ESB_ConnectionPoints.SamplePlugins.File.dll

using ESB_ConnectionPoints.PluginsInterfaces;
using System.Collections.Generic;

namespace ESB_ConnectionPoints.SamplePlugins.File
{
  public sealed class OutgoingConnectionPointFactory : IOutgoingConnectionPointFactory
  {
    public const string LOGIN = "Имя пользователя";
    public const string PASSWORD = "Пароль";
    public const string CONNECTION_POINT = "Учетная система";
    public const string EXTERNAL_SYSTEM = "Внешняя система";
    public const string DESTINATION_SERVER = "Сервер назначения";
    public const string ADRESS_END_POINT = "Адрес сервиса";

    public IOutgoingConnectionPoint Create(
      Dictionary<string, string> parameters,
      IServiceLocator serviceLocator)
    {
      string parameter1 = parameters["Имя пользователя"];
      string parameter2 = parameters["Пароль"];
      string parameter3 = parameters["Учетная система"];
      string parameter4 = parameters["Внешняя система"];
      string parameter5 = parameters["Сервер назначения"];
      string parameter6 = parameters["Адрес сервиса"];
      return (IOutgoingConnectionPoint) new OutgoingConnectionPoint(serviceLocator, parameter1, parameter2, parameter3, parameter4, parameter5, parameter6);
    }
  }
}
