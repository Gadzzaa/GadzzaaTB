﻿#pragma checksum "..\..\..\Windows\StreamCompanion.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CCDA2266C89A38787ACB10F7676D20C1FCA0E75397930EEFFC83C369BE15B5B5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace GadzzaaTB {
    
    
    /// <summary>
    /// StreamCompanion
    /// </summary>
    public partial class StreamCompanion : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 35 "..\..\..\Windows\StreamCompanion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SetSCLoc;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Windows\StreamCompanion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RestartSC;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Windows\StreamCompanion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label FolderLocation;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Windows\StreamCompanion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackButton;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\Windows\StreamCompanion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox AutoStartSCY;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\Windows\StreamCompanion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button StartWebSocket;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\Windows\StreamCompanion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Status;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\Windows\StreamCompanion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DisconnectSCWebsocket;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\Windows\StreamCompanion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BugReportBUtton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GadzzaaTB;component/windows/streamcompanion.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\StreamCompanion.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.SetSCLoc = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\Windows\StreamCompanion.xaml"
            this.SetSCLoc.Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 2:
            this.RestartSC = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\Windows\StreamCompanion.xaml"
            this.RestartSC.Click += new System.Windows.RoutedEventHandler(this.Button_Click_2);
            
            #line default
            #line hidden
            return;
            case 3:
            this.FolderLocation = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.BackButton = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\..\Windows\StreamCompanion.xaml"
            this.BackButton.Click += new System.Windows.RoutedEventHandler(this.Button_Click_3);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AutoStartSCY = ((System.Windows.Controls.CheckBox)(target));
            
            #line 62 "..\..\..\Windows\StreamCompanion.xaml"
            this.AutoStartSCY.Checked += new System.Windows.RoutedEventHandler(this.CheckBox_Checked);
            
            #line default
            #line hidden
            
            #line 63 "..\..\..\Windows\StreamCompanion.xaml"
            this.AutoStartSCY.Unchecked += new System.Windows.RoutedEventHandler(this.CheckBox_Unchecked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.StartWebSocket = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\..\Windows\StreamCompanion.xaml"
            this.StartWebSocket.Click += new System.Windows.RoutedEventHandler(this.WebSocketConnect);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Status = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.DisconnectSCWebsocket = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\..\Windows\StreamCompanion.xaml"
            this.DisconnectSCWebsocket.Click += new System.Windows.RoutedEventHandler(this.WebSocketDisconnect);
            
            #line default
            #line hidden
            return;
            case 9:
            this.BugReportBUtton = ((System.Windows.Controls.Button)(target));
            
            #line 85 "..\..\..\Windows\StreamCompanion.xaml"
            this.BugReportBUtton.Click += new System.Windows.RoutedEventHandler(this.DaPula);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

