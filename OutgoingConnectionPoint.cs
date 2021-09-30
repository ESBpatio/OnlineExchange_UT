// Decompiled with JetBrains decompiler
// Type: ESB_ConnectionPoints.SamplePlugins.File.OutgoingConnectionPoint
// Assembly: ESB_ConnectionPoints.SamplePlugins.File, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BDABA861-D09F-44D5-A4A8-DDA719527C99
// Assembly location: \\sd-esb-adapter2\C$\ProgramData\Datareon\ESB\Plugins\Patio(SOAP client)-2.0.0.11-dotNET-WINDOWS\ESB_ConnectionPoints.SamplePlugins.File.dll

using ESB_ConnectionPoints.PluginsInterfaces;
using ESB_ConnectionPoints.SamplePlugins.File.BPMExchange;
using System;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading;

namespace ESB_ConnectionPoints.SamplePlugins.File
{
    public sealed class OutgoingConnectionPoint : IStandartOutgoingConnectionPoint, IOutgoingConnectionPoint, IConnectionPoint, IDisposable
    {
        private readonly ILogger _logger;
        private readonly string _login;
        private readonly string _password;
        private readonly string _connectionPoint;
        private readonly string _system;
        private readonly string _server;
        private readonly string _wsdlAddress;

        public OutgoingConnectionPoint(
          IServiceLocator serviceLocator,
          string Login,
          string Password,
          string Point,
          string Server,
          string System,
          string address)
        {
            this._connectionPoint = Point;
            this._logger = serviceLocator.GetLogger(this.GetType());
            this._login = Login;
            this._password = Password;
            this._server = Server;
            this._system = System;
            this._wsdlAddress = address;
        }

        public void Initialize()
        {
            if (string.IsNullOrEmpty(this._connectionPoint))
                throw new Exception("Не задан параметр <Connection point>");
            if (this._connectionPoint == "1C" && (string.IsNullOrEmpty(this._login) || string.IsNullOrEmpty(this._password)))
                throw new Exception("Не задан логин или пароль, для приложение 1с обязательное заполнение.");
        }

        public void Run(
          IMessageSource messageSource,
          IMessageReplyHandler replyHandler,
          CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                PluginsInterfaces.Message message = messageSource.PeekLockMessage(ct, 10);
                if (message == null)
                {
                    ct.WaitHandle.WaitOne(10);
                }
                else
                {
                    try
                    {
                        if (this._connectionPoint == "1C")
                        {
                            EndpointAddress remoteAddress = new EndpointAddress(new Uri(this._wsdlAddress), new AddressHeader[0]);
                            using (BPMExchangePortTypeClient ws = new BPMExchangePortTypeClient((Binding)new BasicHttpBinding()
                            {
                                Security = {
                  Mode = BasicHttpSecurityMode.TransportCredentialOnly,
                  Transport = {
                    ClientCredentialType = HttpClientCredentialType.Basic
                  }
                }
                            }, remoteAddress))
                            {
                                ws.ClientCredentials.UserName.UserName = this._login;
                                ws.ClientCredentials.UserName.Password = this._password;
                                ws.Open();
                                ConfiguredTaskAwaitable<ResponseArg>.ConfiguredTaskAwaiter receiptMethod = ws.SendMessageAsync(this.CreateOutgoingMessageUT(message)).ConfigureAwait(false).GetAwaiter();
                                receiptMethod.OnCompleted((Action)(() =>
                               {
                                   try
                                   {
                                       messageSource.CompletePeekLock(message.Id);
                                       PluginsInterfaces.Message replyMessageUt = this.CreateReplyMessageUT(receiptMethod.GetResult(), message);
                                       replyHandler.HandleReplyMessage(replyMessageUt);
                                       this._logger.Debug("Ответ сформирован :" + Encoding.UTF8.GetString(replyMessageUt.Body));
                                       ws.Close();
                                   }
                                   catch (Exception ex)
                                   {
                                       replyHandler.HandleReplyMessage(this.CreateAndSendCatchMessage(ex.Message, message));
                                       this._logger.Error(ex.Message);
                                       ws.Abort();
                                   }
                               }));
                                ws.Close();
                            }
                        }
                        else if (this._connectionPoint == "AxaptaGate")
                        {
                            axaptaGate.IntegrationaxSoapClient ws = this.ConnectionAxapteService();
                            ConfiguredTaskAwaitable<axaptaGate.sendMessageResponse>.ConfiguredTaskAwaiter receiptMethod = ws.sendMessageAsync(this.CreateOutgoingMessageAxapta(message)).ConfigureAwait(false).GetAwaiter();
                            receiptMethod.OnCompleted((Action)(() =>
                           {
                               try
                               {
                                   PluginsInterfaces.Message replyMessageAxapta = this.CreateReplyMessageAxapta(receiptMethod.GetResult(), message);
                                   replyHandler.HandleReplyMessage(replyMessageAxapta);
                                   this._logger.Debug("Ответ сформирован :" + Encoding.UTF8.GetString(replyMessageAxapta.Body));
                                   ws.Close();
                               }
                               catch (Exception ex)
                               {
                                   replyHandler.HandleReplyMessage(this.CreateAndSendCatchMessage(ex.Message, message));
                                   this._logger.Error(ex.Message);
                                   ws.Abort();
                               }
                           }));
                        }
                        else if (this._connectionPoint == "AxaptaStage")
                        {
                            axaptaStage1.IntegrationaxSoapClient ws = this.ConnectionAxaptaStage();
                            ConfiguredTaskAwaitable<axaptaStage1.sendMessageResponse>.ConfiguredTaskAwaiter receiptMethod = ws.sendMessageAsync(this.CreateOutgoingMessageAxaptaStage(message)).ConfigureAwait(false).GetAwaiter();
                            receiptMethod.OnCompleted((Action)(() =>
                           {
                               try
                               {
                                   PluginsInterfaces.Message messageAxaptaStage = this.CreateReplyMessageAxaptaStage(receiptMethod.GetResult(), message);
                                   replyHandler.HandleReplyMessage(messageAxaptaStage);
                                   this._logger.Debug("Ответ сформирован : " + Encoding.UTF8.GetString(messageAxaptaStage.Body));
                                   ws.Close();
                               }
                               catch (Exception ex)
                               {
                                   replyHandler.HandleReplyMessage(this.CreateAndSendCatchMessage(ex.Message, message));
                                   this._logger.Error(ex.Message);
                                   ws.Abort();
                               }
                           }));
                        }
                    }
                    catch (Exception ex)
                    {
                        this._logger.Error("Ошибка HandleMessage " + ex.Message);
                    }
                }
            }
        }

        public bool HandleMessage(PluginsInterfaces.Message message, IMessageReplyHandler replyHandler) => true;

        public bool IsReady() => true;

        public void Cleanup()
        {
        }

        public void Dispose()
        {
        }

        public BPMExchangePortTypeClient ConnectionServiceUT(
          string password,
          string login)
        {
            BPMExchangePortTypeClient exchangePortTypeClient = new BPMExchangePortTypeClient((Binding)new BasicHttpBinding()
            {
                Security = {
          Mode = BasicHttpSecurityMode.TransportCredentialOnly,
          Transport = {
            ClientCredentialType = HttpClientCredentialType.Basic
          }
        }
            }, new EndpointAddress(new Uri(this._wsdlAddress), new AddressHeader[0]));
            exchangePortTypeClient.ClientCredentials.UserName.UserName = this._login;
            exchangePortTypeClient.ClientCredentials.UserName.Password = this._password;
            exchangePortTypeClient.Open();
            return exchangePortTypeClient;
        }

        public axaptaGate.IntegrationaxSoapClient ConnectionAxapteService()
        {
            axaptaGate.IntegrationaxSoapClient integrationaxSoapClient = new ESB_ConnectionPoints.SamplePlugins.File.axaptaGate.IntegrationaxSoapClient((Binding)new BasicHttpBinding(), new EndpointAddress(new Uri(this._wsdlAddress), new AddressHeader[0]));
            integrationaxSoapClient.Open();
            return integrationaxSoapClient;
        }

        public axaptaStage1.IntegrationaxSoapClient ConnectionAxaptaStage()
        {
            axaptaStage1.IntegrationaxSoapClient integrationaxSoapClient = new ESB_ConnectionPoints.SamplePlugins.File.axaptaStage1.IntegrationaxSoapClient((Binding)new BasicHttpBinding(), new EndpointAddress(new Uri(this._wsdlAddress), new AddressHeader[0]));
            integrationaxSoapClient.Open();
            return integrationaxSoapClient;
        }

        public RequestArg CreateOutgoingMessageUT(
          PluginsInterfaces.Message esbMessage)
        {
            return new RequestArg()
            {
                Body = Encoding.UTF8.GetString(esbMessage.Body),
                ClassId = int.Parse(esbMessage.ClassId),
                DestinationServer = this._server,
                ExternalSystem = this._system,
                Id = esbMessage.Id.ToString(),
                Type = esbMessage.Type
            };
        }

        public axaptaGate.RequestArg CreateOutgoingMessageAxapta(
          PluginsInterfaces.Message esbMessage)
        {
            return new axaptaGate.RequestArg()
            {
                Body = Encoding.UTF8.GetString(esbMessage.Body),
                ClassId = esbMessage.ClassId,
                DestinationServer = this._system,
                ExternalSystem = this._server,
                Id = esbMessage.Id.ToString(),
                Type = esbMessage.Type
            };
        }

        public axaptaStage1.RequestArg CreateOutgoingMessageAxaptaStage(
          PluginsInterfaces.Message esbMessage)
        {
            return new axaptaStage1.RequestArg()
            {
                Body = Encoding.UTF8.GetString(esbMessage.Body),
                ClassId = esbMessage.ClassId,
                DestinationServer = this._system,
                ExternalSystem = this._server,
                Id = esbMessage.Id.ToString(),
                Type = esbMessage.Type
            };
        }

        public PluginsInterfaces.Message CreateReplyMessageUT(
          ResponseArg response,
          PluginsInterfaces.Message message)
        {
            PluginsInterfaces.Message message1 = new PluginsInterfaces.Message();
            string s = "<ResponseArg  xmlns=\"http://schemas.datacontract.org/2004/07/\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\r\n " +
                      " <resultStatus>" + response.resultStatus.ToString() + "</resultStatus>\r\n                                " +
                      " <resultLocation>" + response.resultLocation + "</resultLocation>\r\n                                 " +
                      "<resultCode>" + response.resultCode + "</resultCode>\r\n                                 " +
                      "<resultMessage><![CDATA[" + response.resultMessage + "]]></resultMessage> \r\n                                 " +
                      "<resultRecId>" + response.resultRecId + "</resultRecId>                   \r\n                                 " +
                      "<resultTableId>" + response.resultTableId + "</resultTableId>                  \r\n                               " +
                      " <resultDocNum>" + response.resultDocNum + "</resultDocNum>\r\n                               " +
                      " </ResponseArg>";
            message1.Body = Encoding.UTF8.GetBytes(s);
            message1.ClassId = message.ClassId;
            message1.Id = Guid.NewGuid();
            message1.Type = message.Type;
            message1.CorrelationId = message.CorrelationId;
            message1.Receiver = message.Source;
            //message1.NeedAcknowledgment = true;
            message1.SetPropertyWithValue("originalMessage", Encoding.UTF8.GetString(message.Body));
            return message1;
        }

        public PluginsInterfaces.Message CreateReplyMessageAxapta(
          axaptaGate.sendMessageResponse response,
          PluginsInterfaces.Message message)
        {
            PluginsInterfaces.Message message1 = new PluginsInterfaces.Message();
            string s = "<ResponseArg  xmlns=\"http://schemas.datacontract.org/2004/07/\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\r\n " +
                      "<resultStatus>" + response.Body.sendMessageResult.resultStatus.ToString() + "</resultStatus>\r\n" +
                      "<resultLocation>" + (object)response.Body.sendMessageResult.resultLocation + "</resultLocation>\r\n" +
                      "<resultCode>" + response.Body.sendMessageResult.resultCode + "</resultCode>\r\n" +
                      "<resultMessage><![CDATA[" + response.Body.sendMessageResult.resultMessage + "]]></resultMessage> \r\n" +
                      "<resultRecId>" + (object)response.Body.sendMessageResult.resultRecId + "</resultRecId>\r\n" +
                      "<resultTableId>" + (object)response.Body.sendMessageResult.resultTableId + "</resultTableId>\r\n" +
                      "<resultDocNum>" + response.Body.sendMessageResult.resultDocNum + "</resultDocNum>\r\n" +
                      "</ResponseArg>";
            message1.Body = Encoding.UTF8.GetBytes(s);
            message1.ClassId = message.ClassId;
            message1.Id = Guid.NewGuid();
            message1.Type = message.Type;
            message1.CorrelationId = message.CorrelationId;
            message1.Receiver = message.Source;
            message1.NeedAcknowledgment = true;
            return message1;
        }

        public PluginsInterfaces.Message CreateReplyMessageAxaptaStage(
          axaptaStage1.sendMessageResponse response,
          PluginsInterfaces.Message message)
        {
            PluginsInterfaces.Message message1 = new PluginsInterfaces.Message();
            string s = "<ResponseArg  xmlns=\"http://schemas.datacontract.org/2004/07/\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\r\n                                 <resultStatus>" + response.Body.sendMessageResult.resultStatus.ToString() + "</resultStatus>\r\n                                 <resultLocation>" + (object)response.Body.sendMessageResult.resultLocation + "</resultLocation>\r\n                                 <resultCode>" + response.Body.sendMessageResult.resultCode + "</resultCode>\r\n                                 <resultMessage><![CDATA[" + response.Body.sendMessageResult.resultMessage + "]]></resultMessage> \r\n                                 <resultRecId>" + (object)response.Body.sendMessageResult.resultRecId + "</resultRecId>                   \r\n                                 <resultTableId>" + (object)response.Body.sendMessageResult.resultTableId + "</resultTableId>                  \r\n                                <resultDocNum>" + response.Body.sendMessageResult.resultDocNum + "</resultDocNum>\r\n                                </ResponseArg>";
            message1.Body = Encoding.UTF8.GetBytes(s);
            message1.ClassId = message.ClassId;
            message1.Id = Guid.NewGuid();
            message1.Type = message.Type;
            message1.CorrelationId = message.CorrelationId;
            message1.Receiver = message.Source;
            message1.NeedAcknowledgment = true;
            return message1;
        }

        public PluginsInterfaces.Message CreateAndSendCatchMessage(
          string ex,
          PluginsInterfaces.Message esbMessage)
        {
            string s = "<ResponseArg  xmlns=\"http://schemas.datacontract.org/2004/07/\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\r\n" +
                      "                                 <resultStatus>False</resultStatus>\r\n" +
                      "                                 <resultLocation>UT</resultLocation>\r\n" +
                      "                                 <resultCode>0</resultCode>\r\n" +
                      "                                <resultMessage><![CDATA[" + ex + "]]></resultMessage> \r\n" +
                      "                                 <resultRecId>0</resultRecId>                   \r\n" +
                      "                                 <resultTableId>0</resultTableId>                  \r\n" +
                      "                                <resultDocNum>0</resultDocNum>\r\n" +
                      "                                </ResponseArg>";
            return new PluginsInterfaces.Message()
            {
                Body = Encoding.UTF8.GetBytes(s),
                ClassId = esbMessage.ClassId,
                Id = Guid.NewGuid(),
                Type = esbMessage.Type,
                CorrelationId = esbMessage.CorrelationId,
                Receiver = esbMessage.Source,
                NeedAcknowledgment = true
            };
        }
    }
}
