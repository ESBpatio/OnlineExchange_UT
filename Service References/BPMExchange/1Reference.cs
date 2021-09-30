// Decompiled with JetBrains decompiler
// Type: ESB_ConnectionPoints.SamplePlugins.File.BPMExchange.ResponseArg
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
  public class ResponseArg : INotifyPropertyChanged
  {
    private bool resultStatusField;
    private string resultLocationField;
    private string resultCodeField;
    private string resultMessageField;
    private string resultRecIdField;
    private string resultTableIdField;
    private string resultDocNumField;

    public bool resultStatus
    {
      get => this.resultStatusField;
      set
      {
        this.resultStatusField = value;
        this.RaisePropertyChanged(nameof (resultStatus));
      }
    }

    [XmlElement(IsNullable = true)]
    public string resultLocation
    {
      get => this.resultLocationField;
      set
      {
        this.resultLocationField = value;
        this.RaisePropertyChanged(nameof (resultLocation));
      }
    }

    [XmlElement(IsNullable = true)]
    public string resultCode
    {
      get => this.resultCodeField;
      set
      {
        this.resultCodeField = value;
        this.RaisePropertyChanged(nameof (resultCode));
      }
    }

    [XmlElement(IsNullable = true)]
    public string resultMessage
    {
      get => this.resultMessageField;
      set
      {
        this.resultMessageField = value;
        this.RaisePropertyChanged(nameof (resultMessage));
      }
    }

    [XmlElement(IsNullable = true)]
    public string resultRecId
    {
      get => this.resultRecIdField;
      set
      {
        this.resultRecIdField = value;
        this.RaisePropertyChanged(nameof (resultRecId));
      }
    }

    [XmlElement(IsNullable = true)]
    public string resultTableId
    {
      get => this.resultTableIdField;
      set
      {
        this.resultTableIdField = value;
        this.RaisePropertyChanged(nameof (resultTableId));
      }
    }

    [XmlElement(IsNullable = true)]
    public string resultDocNum
    {
      get => this.resultDocNumField;
      set
      {
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
