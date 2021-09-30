// Decompiled with JetBrains decompiler
// Type: ESB_ConnectionPoints.SamplePlugins.File.axaptaGate.ResponceArg
// Assembly: ESB_ConnectionPoints.SamplePlugins.File, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BDABA861-D09F-44D5-A4A8-DDA719527C99
// Assembly location: \\sd-esb-adapter2\C$\ProgramData\Datareon\ESB\Plugins\Patio(SOAP client)-2.0.0.11-dotNET-WINDOWS\ESB_ConnectionPoints.SamplePlugins.File.dll

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace ESB_ConnectionPoints.SamplePlugins.File.axaptaGate
{
  [DebuggerStepThrough]
  [GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
  [DataContract(Name = "ResponceArg", Namespace = "http://sd-ax-rep1:80/integrationax/")]
  [Serializable]
  public class ResponceArg : IExtensibleDataObject, INotifyPropertyChanged
  {
    [NonSerialized]
    private ExtensionDataObject extensionDataField;
    private bool resultStatusField;
    private ResponceArgLocation resultLocationField;
    [OptionalField]
    private string resultCodeField;
    [OptionalField]
    private string resultMessageField;
    private long resultRecIdField;
    private long resultTableIdField;
    [OptionalField]
    private string resultDocNumField;

    [Browsable(false)]
    public ExtensionDataObject ExtensionData
    {
      get => this.extensionDataField;
      set => this.extensionDataField = value;
    }

    [DataMember(IsRequired = true)]
    public bool resultStatus
    {
      get => this.resultStatusField;
      set
      {
        if (this.resultStatusField.Equals(value))
          return;
        this.resultStatusField = value;
        this.RaisePropertyChanged(nameof (resultStatus));
      }
    }

    [DataMember(IsRequired = true, Order = 1)]
    public ResponceArgLocation resultLocation
    {
      get => this.resultLocationField;
      set
      {
        if (this.resultLocationField.Equals((object) value))
          return;
        this.resultLocationField = value;
        this.RaisePropertyChanged(nameof (resultLocation));
      }
    }

    [DataMember(EmitDefaultValue = false, Order = 2)]
    public string resultCode
    {
      get => this.resultCodeField;
      set
      {
        if ((object) this.resultCodeField == (object) value)
          return;
        this.resultCodeField = value;
        this.RaisePropertyChanged(nameof (resultCode));
      }
    }

    [DataMember(EmitDefaultValue = false, Order = 3)]
    public string resultMessage
    {
      get => this.resultMessageField;
      set
      {
        if ((object) this.resultMessageField == (object) value)
          return;
        this.resultMessageField = value;
        this.RaisePropertyChanged(nameof (resultMessage));
      }
    }

    [DataMember(IsRequired = true, Order = 4)]
    public long resultRecId
    {
      get => this.resultRecIdField;
      set
      {
        if (this.resultRecIdField.Equals(value))
          return;
        this.resultRecIdField = value;
        this.RaisePropertyChanged(nameof (resultRecId));
      }
    }

    [DataMember(IsRequired = true, Order = 5)]
    public long resultTableId
    {
      get => this.resultTableIdField;
      set
      {
        if (this.resultTableIdField.Equals(value))
          return;
        this.resultTableIdField = value;
        this.RaisePropertyChanged(nameof (resultTableId));
      }
    }

    [DataMember(EmitDefaultValue = false, Order = 6)]
    public string resultDocNum
    {
      get => this.resultDocNumField;
      set
      {
        if ((object) this.resultDocNumField == (object) value)
          return;
        this.resultDocNumField = value;
        this.RaisePropertyChanged(nameof (resultDocNum));
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
