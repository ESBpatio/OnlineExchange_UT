// Decompiled with JetBrains decompiler
// Type: ESB_ConnectionPoints.SamplePlugins.File.axaptaGate.IntegrationaxSoapClient
// Assembly: ESB_ConnectionPoints.SamplePlugins.File, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BDABA861-D09F-44D5-A4A8-DDA719527C99
// Assembly location: \\sd-esb-adapter2\C$\ProgramData\Datareon\ESB\Plugins\Patio(SOAP client)-2.0.0.11-dotNET-WINDOWS\ESB_ConnectionPoints.SamplePlugins.File.dll

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace ESB_ConnectionPoints.SamplePlugins.File.axaptaGate
{
  [DebuggerStepThrough]
  [GeneratedCode("System.ServiceModel", "4.0.0.0")]
  public class IntegrationaxSoapClient : ClientBase<IntegrationaxSoap>, IntegrationaxSoap
  {
    public IntegrationaxSoapClient()
    {
    }

    public IntegrationaxSoapClient(string endpointConfigurationName)
      : base(endpointConfigurationName)
    {
    }

    public IntegrationaxSoapClient(string endpointConfigurationName, string remoteAddress)
      : base(endpointConfigurationName, remoteAddress)
    {
    }

    public IntegrationaxSoapClient(string endpointConfigurationName, EndpointAddress remoteAddress)
      : base(endpointConfigurationName, remoteAddress)
    {
    }

    public IntegrationaxSoapClient(Binding binding, EndpointAddress remoteAddress)
      : base(binding, remoteAddress)
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    sendMessageResponse IntegrationaxSoap.sendMessage(
      sendMessageRequest request)
    {
      return this.Channel.sendMessage(request);
    }

    public ResponceArg sendMessage(RequestArg request)
    {
      sendMessageRequest request1 = new sendMessageRequest()
      {
        Body = new sendMessageRequestBody()
      };
      request1.Body.request = request;
      return ((IntegrationaxSoap) this).sendMessage(request1).Body.sendMessageResult;
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    Task<sendMessageResponse> IntegrationaxSoap.sendMessageAsync(
      sendMessageRequest request)
    {
      return this.Channel.sendMessageAsync(request);
    }

    public Task<sendMessageResponse> sendMessageAsync(RequestArg request)
    {
      sendMessageRequest request1 = new sendMessageRequest()
      {
        Body = new sendMessageRequestBody()
      };
      request1.Body.request = request;
      return ((IntegrationaxSoap) this).sendMessageAsync(request1);
    }
  }
}
