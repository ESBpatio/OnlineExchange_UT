// Decompiled with JetBrains decompiler
// Type: ESB_ConnectionPoints.SamplePlugins.File.axaptaStage1.RequestArg
// Assembly: ESB_ConnectionPoints.SamplePlugins.File, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BDABA861-D09F-44D5-A4A8-DDA719527C99
// Assembly location: \\sd-esb-adapter2\C$\ProgramData\Datareon\ESB\Plugins\Patio(SOAP client)-2.0.0.11-dotNET-WINDOWS\ESB_ConnectionPoints.SamplePlugins.File.dll

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace ESB_ConnectionPoints.SamplePlugins.File.axaptaStage1
{
  [DebuggerStepThrough]
  [GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
  [DataContract(Name = "RequestArg", Namespace = "http://s-ax-rep:80/integrationax/")]
  [Serializable]
  public class RequestArg : IExtensibleDataObject, INotifyPropertyChanged
  {
    [NonSerialized]
    private ExtensionDataObject extensionDataField;
    [OptionalField]
    private string IdField;
    [OptionalField]
    private string TypeField;
    [OptionalField]
    private string ClassIdField;
    [OptionalField]
    private string BodyField;
    [OptionalField]
    private string ExternalSystemField;
    [OptionalField]
    private string DestinationServerField;

    [Browsable(false)]
    public ExtensionDataObject ExtensionData
    {
      get => this.extensionDataField;
      set => this.extensionDataField = value;
    }

    [DataMember(EmitDefaultValue = false)]
    public string Id
    {
      get => this.IdField;
      set
      {
        if ((object) this.IdField == (object) value)
          return;
        this.IdField = value;
        this.RaisePropertyChanged(nameof (Id));
      }
    }

    [DataMember(EmitDefaultValue = false)]
    public string Type
    {
      get => this.TypeField;
      set
      {
        if ((object) this.TypeField == (object) value)
          return;
        this.TypeField = value;
        this.RaisePropertyChanged(nameof (Type));
      }
    }

    [DataMember(EmitDefaultValue = false, Order = 2)]
    public string ClassId
    {
      get => this.ClassIdField;
      set
      {
        if ((object) this.ClassIdField == (object) value)
          return;
        this.ClassIdField = value;
        this.RaisePropertyChanged(nameof (ClassId));
      }
    }

    [DataMember(EmitDefaultValue = false, Order = 3)]
    public string Body
    {
      get => this.BodyField;
      set
      {
        if ((object) this.BodyField == (object) value)
          return;
        this.BodyField = value;
        this.RaisePropertyChanged(nameof (Body));
      }
    }

    [DataMember(EmitDefaultValue = false, Order = 4)]
    public string ExternalSystem
    {
      get => this.ExternalSystemField;
      set
      {
        if ((object) this.ExternalSystemField == (object) value)
          return;
        this.ExternalSystemField = value;
        this.RaisePropertyChanged(nameof (ExternalSystem));
      }
    }

    [DataMember(EmitDefaultValue = false, Order = 5)]
    public string DestinationServer
    {
      get => this.DestinationServerField;
      set
      {
        if ((object) this.DestinationServerField == (object) value)
          return;
        this.DestinationServerField = value;
        this.RaisePropertyChanged(nameof (DestinationServer));
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
      PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
      if (propertyChanged == null)
        return;
      propertyChanged((object) this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
