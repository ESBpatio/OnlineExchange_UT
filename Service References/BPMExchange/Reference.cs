// Decompiled with JetBrains decompiler
// Type: ESB_ConnectionPoints.SamplePlugins.File.BPMExchange.RequestArg
// Assembly: ESB_ConnectionPoints.SamplePlugins.File, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BDABA861-D09F-44D5-A4A8-DDA719527C99
// Assembly location: \\sd-esb-adapter2\C$\ProgramData\Datareon\ESB\Plugins\Patio(SOAP client)-2.0.0.11-dotNET-WINDOWS\ESB_ConnectionPoints.SamplePlugins.File.dll

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace ESB_ConnectionPoints.SamplePlugins.File.BPMExchange
{
  [GeneratedCode("System.Xml", "4.7.3062.0")]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(Namespace = "http://srv-1c-web.patio-minsk.by/BPMExchange/")]
  [Serializable]
  public class RequestArg : INotifyPropertyChanged
  {
    private string idField;
    private string typeField;
    private int classIdField;
    private string bodyField;
    private string externalSystemField;
    private string destinationServerField;

    [XmlElement(IsNullable = true, Order = 0)]
    public string Id
    {
      get => this.idField;
      set
      {
        this.idField = value;
        this.RaisePropertyChanged(nameof (Id));
      }
    }

    [XmlElement(IsNullable = true, Order = 1)]
    public string Type
    {
      get => this.typeField;
      set
      {
        this.typeField = value;
        this.RaisePropertyChanged(nameof (Type));
      }
    }

    [XmlElement(Order = 2)]
    public int ClassId
    {
      get => this.classIdField;
      set
      {
        this.classIdField = value;
        this.RaisePropertyChanged(nameof (ClassId));
      }
    }

    [XmlElement(Order = 3)]
    public string Body
    {
      get => this.bodyField;
      set
      {
        this.bodyField = value;
        this.RaisePropertyChanged(nameof (Body));
      }
    }

    [XmlElement(IsNullable = true, Order = 4)]
    public string ExternalSystem
    {
      get => this.externalSystemField;
      set
      {
        this.externalSystemField = value;
        this.RaisePropertyChanged(nameof (ExternalSystem));
      }
    }

    [XmlElement(IsNullable = true, Order = 5)]
    public string DestinationServer
    {
      get => this.destinationServerField;
      set
      {
        this.destinationServerField = value;
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
