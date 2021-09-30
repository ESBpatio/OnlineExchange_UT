// Decompiled with JetBrains decompiler
// Type: ESB_ConnectionPoints.SamplePlugins.File.IngoingConnectionPointFactory
// Assembly: ESB_ConnectionPoints.SamplePlugins.File, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BDABA861-D09F-44D5-A4A8-DDA719527C99
// Assembly location: \\sd-esb-adapter2\C$\ProgramData\Datareon\ESB\Plugins\Patio(SOAP client)-2.0.0.11-dotNET-WINDOWS\ESB_ConnectionPoints.SamplePlugins.File.dll

using ESB_ConnectionPoints.PluginsInterfaces;
using System.Collections.Generic;

namespace ESB_ConnectionPoints.SamplePlugins.File
{
  public sealed class IngoingConnectionPointFactory : IIngoingConnectionPointFactory
  {
    public const string FILE_NAME_PATTERN_PARAMETER = "FileNamePattern";

    public IIngoingConnectionPoint Create(
      Dictionary<string, string> parameters,
      IServiceLocator serviceLocator)
    {
      string fileNamePattern = "*.*";
      if (parameters.ContainsKey("FileNamePattern"))
        fileNamePattern = parameters["FileNamePattern"];
      return (IIngoingConnectionPoint) new IngoingConnectionPoint(fileNamePattern, serviceLocator);
    }
  }
}
