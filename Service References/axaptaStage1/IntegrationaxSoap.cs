// Decompiled with JetBrains decompiler
// Type: ESB_ConnectionPoints.SamplePlugins.File.axaptaStage1.IntegrationaxSoap
// Assembly: ESB_ConnectionPoints.SamplePlugins.File, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BDABA861-D09F-44D5-A4A8-DDA719527C99
// Assembly location: \\sd-esb-adapter2\C$\ProgramData\Datareon\ESB\Plugins\Patio(SOAP client)-2.0.0.11-dotNET-WINDOWS\ESB_ConnectionPoints.SamplePlugins.File.dll

using System.CodeDom.Compiler;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ESB_ConnectionPoints.SamplePlugins.File.axaptaStage1
{
  [GeneratedCode("System.ServiceModel", "4.0.0.0")]
  [ServiceContract(ConfigurationName = "axaptaStage1.IntegrationaxSoap", Namespace = "http://s-ax-rep:80/integrationax/")]
  public interface IntegrationaxSoap
  {
    [OperationContract(Action = "http://s-ax-rep:80/integrationax/sendMessage", ReplyAction = "*")]
    sendMessageResponse sendMessage(sendMessageRequest request);

    [OperationContract(Action = "http://s-ax-rep:80/integrationax/sendMessage", ReplyAction = "*")]
    Task<sendMessageResponse> sendMessageAsync(sendMessageRequest request);
  }
}
