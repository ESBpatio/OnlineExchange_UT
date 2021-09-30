// Decompiled with JetBrains decompiler
// Type: ESB_ConnectionPoints.SamplePlugins.File.axaptaGate.sendMessageResponse
// Assembly: ESB_ConnectionPoints.SamplePlugins.File, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BDABA861-D09F-44D5-A4A8-DDA719527C99
// Assembly location: \\sd-esb-adapter2\C$\ProgramData\Datareon\ESB\Plugins\Patio(SOAP client)-2.0.0.11-dotNET-WINDOWS\ESB_ConnectionPoints.SamplePlugins.File.dll

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace ESB_ConnectionPoints.SamplePlugins.File.axaptaGate
{
  [DebuggerStepThrough]
  [GeneratedCode("System.ServiceModel", "4.0.0.0")]
  [EditorBrowsable(EditorBrowsableState.Advanced)]
  [MessageContract(IsWrapped = false)]
  public class sendMessageResponse
  {
    [MessageBodyMember(Name = "sendMessageResponse", Namespace = "http://sd-ax-rep1:80/integrationax/", Order = 0)]
    public sendMessageResponseBody Body;

    public sendMessageResponse()
    {
    }

    public sendMessageResponse(sendMessageResponseBody Body) => this.Body = Body;
  }
}
