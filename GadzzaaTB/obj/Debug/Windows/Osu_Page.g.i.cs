﻿#pragma checksum "..\..\..\Windows\Osu_Page.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E3970207852905C95A5FD6E443EB3E1B6106D11F30CED07786811C6A42483051"
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
    /// Osu_Page
    /// </summary>
    public partial class Osu_Page : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\..\Windows\Osu_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal GadzzaaTB.Osu_Page OsuPageu;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\Windows\Osu_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid1;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Windows\Osu_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelNp;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Windows\Osu_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelNppp;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Windows\Osu_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackButtonOsu;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Windows\Osu_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Command1;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Windows\Osu_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Command2;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\Windows\Osu_Page.xaml"
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
            System.Uri resourceLocater = new System.Uri("/GadzzaaTB;component/windows/osu_page.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\Osu_Page.xaml"
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
            this.OsuPageu = ((GadzzaaTB.Osu_Page)(target));
            return;
            case 2:
            this.grid1 = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.LabelNp = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.LabelNppp = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.BackButtonOsu = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\Windows\Osu_Page.xaml"
            this.BackButtonOsu.Click += new System.Windows.RoutedEventHandler(this.HideOsuBot);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Command1 = ((System.Windows.Controls.TextBox)(target));
            
            #line 52 "..\..\..\Windows\Osu_Page.xaml"
            this.Command1.GotFocus += new System.Windows.RoutedEventHandler(this.npGetFocus);
            
            #line default
            #line hidden
            
            #line 52 "..\..\..\Windows\Osu_Page.xaml"
            this.Command1.LostFocus += new System.Windows.RoutedEventHandler(this.npLoseFocus);
            
            #line default
            #line hidden
            
            #line 52 "..\..\..\Windows\Osu_Page.xaml"
            this.Command1.KeyDown += new System.Windows.Input.KeyEventHandler(this.OnKeyDownHandler);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Command2 = ((System.Windows.Controls.TextBox)(target));
            
            #line 57 "..\..\..\Windows\Osu_Page.xaml"
            this.Command2.LostFocus += new System.Windows.RoutedEventHandler(this.npppLoseFocus);
            
            #line default
            #line hidden
            
            #line 57 "..\..\..\Windows\Osu_Page.xaml"
            this.Command2.KeyDown += new System.Windows.Input.KeyEventHandler(this.OnKeyDownHandler2);
            
            #line default
            #line hidden
            
            #line 57 "..\..\..\Windows\Osu_Page.xaml"
            this.Command2.GotFocus += new System.Windows.RoutedEventHandler(this.npppGetFocus);
            
            #line default
            #line hidden
            return;
            case 8:
            this.BugReportBUtton = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\..\Windows\Osu_Page.xaml"
            this.BugReportBUtton.Click += new System.Windows.RoutedEventHandler(this.DaPula);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

