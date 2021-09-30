// Decompiled with JetBrains decompiler
// Type: ESB_ConnectionPoints.SamplePlugins.File.IngoingConnectionPoint
// Assembly: ESB_ConnectionPoints.SamplePlugins.File, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BDABA861-D09F-44D5-A4A8-DDA719527C99
// Assembly location: \\sd-esb-adapter2\C$\ProgramData\Datareon\ESB\Plugins\Patio(SOAP client)-2.0.0.11-dotNET-WINDOWS\ESB_ConnectionPoints.SamplePlugins.File.dll

using ESB_ConnectionPoints.PluginsInterfaces;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ESB_ConnectionPoints.SamplePlugins.File
{
  public sealed class IngoingConnectionPoint : IStandartIngoingConnectionPoint, IIngoingConnectionPoint, IConnectionPoint, IDisposable
  {
    private readonly ILogger _logger;
    private readonly IMessageFactory _messageFactory;
    private readonly string _inputDirectory;
    private readonly string _fileNamePattern;
    private TimeSpan _readInterval = TimeSpan.FromSeconds(1.0);
    private readonly HashSet<string> _processedFiles = new HashSet<string>();

    public IngoingConnectionPoint(string fileNamePattern, IServiceLocator serviceLocator)
    {
      this._logger = serviceLocator.GetLogger(this.GetType());
      this._messageFactory = serviceLocator.GetMessageFactory();
      this._fileNamePattern = fileNamePattern;
    }

    public void Initialize()
    {
    }

    public void Run(IMessageHandler messageHandler, CancellationToken ct)
    {
    }

    public void Cleanup()
    {
    }

    public void Dispose()
    {
    }
  }
}
