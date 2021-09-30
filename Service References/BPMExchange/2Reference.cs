// Decompiled with JetBrains decompiler
// Type: ESB_ConnectionPoints.SamplePlugins.File.BPMExchange.BPMExchangePortTypeClient
// Assembly: ESB_ConnectionPoints.SamplePlugins.File, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BDABA861-D09F-44D5-A4A8-DDA719527C99
// Assembly location: \\sd-esb-adapter2\C$\ProgramData\Datareon\ESB\Plugins\Patio(SOAP client)-2.0.0.11-dotNET-WINDOWS\ESB_ConnectionPoints.SamplePlugins.File.dll

using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace ESB_ConnectionPoints.SamplePlugins.File.BPMExchange
{
  [DebuggerStepThrough]
  [GeneratedCode("System.ServiceModel", "4.0.0.0")]
  public class BPMExchangePortTypeClient : ClientBase<BPMExchangePortType>, BPMExchangePortType
  {
    public BPMExchangePortTypeClient()
    {
    }

    public BPMExchangePortTypeClient(string endpointConfigurationName)
      : base(endpointConfigurationName)
    {
    }

    public BPMExchangePortTypeClient(string endpointConfigurationName, string remoteAddress)
      : base(endpointConfigurationName, remoteAddress)
    {
    }

    public BPMExchangePortTypeClient(
      string endpointConfigurationName,
      EndpointAddress remoteAddress)
      : base(endpointConfigurationName, remoteAddress)
    {
    }

    public BPMExchangePortTypeClient(Binding binding, EndpointAddress remoteAddress)
      : base(binding, remoteAddress)
    {
    }

    public ResponseArg SendMessage(RequestArg Request) => this.Channel.SendMessage(Request);

    public Task<ResponseArg> SendMessageAsync(RequestArg Request) => this.Channel.SendMessageAsync(Request);
  }
}
