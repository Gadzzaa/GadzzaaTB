﻿#pragma checksum "..\..\..\Windows\Main.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "88903FC682DED7E97F9C2D540FD87998E2DF004AB16C7A00EF53C04970DD63CB"
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
    /// Main
    /// </summary>
    public partial class Main : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 35 "..\..\..\Windows\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Integrations;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Windows\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OsuBot;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Windows\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Twitch;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\Windows\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Settings;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\Windows\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Test2;
        
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
            System.Uri resourceLocater = new System.Uri("/GadzzaaTB;component/windows/main.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\Main.xaml"
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
            this.Integrations = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\Windows\Main.xaml"
            this.Integrations.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.OsuBot = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\Windows\Main.xaml"
            this.OsuBot.Click += new System.Windows.RoutedEventHandler(this.ShowOsuBot);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Twitch = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\..\Windows\Main.xaml"
            this.Twitch.Click += new System.Windows.RoutedEventHandler(this.ShowTwitch);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Settings = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.Test2 = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\..\Windows\Main.xaml"
            this.Test2.Click += new System.Windows.RoutedEventHandler(this.DaPula);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

