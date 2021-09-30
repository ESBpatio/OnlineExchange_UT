// Decompiled with JetBrains decompiler
// Type: ESB_ConnectionPoints.SamplePlugins.File.BPMExchange.BPMExchangePortType
// Assembly: ESB_ConnectionPoints.SamplePlugins.File, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BDABA861-D09F-44D5-A4A8-DDA719527C99
// Assembly location: \\sd-esb-adapter2\C$\ProgramData\Datareon\ESB\Plugins\Patio(SOAP client)-2.0.0.11-dotNET-WINDOWS\ESB_ConnectionPoints.SamplePlugins.File.dll

using System.CodeDom.Compiler;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ESB_ConnectionPoints.SamplePlugins.File.BPMExchange
{
  [GeneratedCode("System.ServiceModel", "4.0.0.0")]
  [ServiceContract(ConfigurationName = "BPMExchange.BPMExchangePortType", Namespace = "http://srv-1c-web.patio-minsk.by/BPMExchange/")]
  public interface BPMExchangePortType
  {
    [OperationContract(Action = "http://srv-1c-web.patio-minsk.by/BPMExchange/#BPMExchange:SendMessage", ReplyAction = "*")]
    [XmlSerializerFormat(SupportFaults = true)]
    [return: MessageParameter(Name = "return")]
    ResponseArg SendMessage(RequestArg Request);

    [OperationContract(Action = "http://srv-1c-web.patio-minsk.by/BPMExchange/#BPMExchange:SendMessage", ReplyAction = "*")]
    [return: MessageParameter(Name = "return")]
    Task<ResponseArg> SendMessageAsync(RequestArg Request);
  }
}
