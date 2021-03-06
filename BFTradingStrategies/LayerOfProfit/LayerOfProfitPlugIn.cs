﻿using net.sxtrader.bftradingstrategies.sxhelper;
using net.sxtrader.bftradingstrategies.tippsters.GUI.Configuration;
using net.sxtrader.bftradingstrategies.tippsters.GUI.Trade;
using net.sxtrader.muk.interfaces;
using net.sxtrader.plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace net.sxtrader.bftradingstrategies.tippsters
{
    public class PluginLayerOfProfit : IPlugin, IDisposable
    {
        private IPluginHost _host;
        private System.Windows.Forms.UserControl _ctlCfg = new ctlConfiguration();
        private System.Windows.Forms.UserControl _ctlMain = new ctlLOP();
        private bool _disposed = false;
        #region IPlugin Members
        public IPluginHost Host
        {
            get
            {
                return _host;
            }
            set
            {
                _host = value;
            }
        }


        public string Name
        {
            get { return LayerOfProfit.strName; }
        }

        public string FullQualifiedName
        {
            get { return LayerOfProfit.strFQLayerOfProfit; }
        }

        public string Description
        {
            get { return LayerOfProfit.strDescription; }
        }

        public string Author
        {
            get { return "SXTrader"; }
        }

        public string Version
        {
            get
            {
                Type type = this.GetType();
                Assembly assembly = Assembly.GetAssembly(type);
                AssemblyName assemblyName = assembly.GetName();
                Version version = assemblyName.Version;
                return version.ToString();
            }
        }

        public Guid GUID
        {
            get { return new Guid("{855869A1-9B8F-4600-921A-2C256B85F6D4}"); }
        }

        public System.Windows.Forms.UserControl MainInterface
        {
            get { return _ctlMain; }
        }

        public System.Windows.Forms.UserControl ConfigurationInterface
        {
            get { return _ctlCfg; }
        }

        public System.Windows.Forms.UserControl FastBetInterface
        {
            get { return null; }
        }

        public void Initialize(object[] parameters, net.sxtrader.bftradingstrategies.livescoreparser.LiveScoreParser parser)
        {
            ((ctlLOP)_ctlMain).initHost(_host);
            ((IBFTSCommon)_ctlMain).ExceptionMessageEvent += LayerOfProfitPlugIn_ExceptionMessageEvent;
        }

        void LayerOfProfitPlugIn_ExceptionMessageEvent(object sender, muk.eventargs.SXExceptionMessageEventArgs e)
        {
            if (_host != null)
            {
                _host.ErrorMessage(e.MessageNumber, e.ToString());
            }
        }
        #endregion

        #region IDisposable Member
        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                DebugWriter.Instance.WriteMessage("PluginLayerOfProfit", "Disposing");
                if (disposing)
                {
                    if (_ctlCfg != null)
                    {
                        _ctlCfg.Dispose();
                    }

                    if (_ctlMain != null)
                    {
                        _ctlMain.Dispose();
                    }
                }
                _disposed = true;
            }
        }
        #endregion
    }
}
