// Decompiled with JetBrains decompiler
// Type: ESB_ConnectionPoints.SamplePlugins.File.axaptaStage1.sendMessageResponseBody
// Assembly: ESB_ConnectionPoints.SamplePlugins.File, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BDABA861-D09F-44D5-A4A8-DDA719527C99
// Assembly location: \\sd-esb-adapter2\C$\ProgramData\Datareon\ESB\Plugins\Patio(SOAP client)-2.0.0.11-dotNET-WINDOWS\ESB_ConnectionPoints.SamplePlugins.File.dll

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace ESB_ConnectionPoints.SamplePlugins.File.axaptaStage1
{
  [DebuggerStepThrough]
  [GeneratedCode("System.ServiceModel", "4.0.0.0")]
  [EditorBrowsable(EditorBrowsableState.Advanced)]
  [DataContract(Namespace = "http://s-ax-rep:80/integrationax/")]
  public class sendMessageResponseBody
  {
    [DataMember(EmitDefaultValue = false, Order = 0)]
    public ResponseArg sendMessageResult;

    public sendMessageResponseBody()
    {
    }

    public sendMessageResponseBody(ResponseArg sendMessageResult) => this.sendMessageResult = sendMessageResult;
  }
}
