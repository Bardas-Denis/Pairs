﻿#pragma checksum "..\..\GameChooser.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FDFD75E4A795AF5C07745A25FEFB51AC78689941BD18ACBC68522AE32E594697"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Pairs;
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


namespace Pairs {
    
    
    /// <summary>
    /// GameChooser
    /// </summary>
    public partial class GameChooser : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\GameChooser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NewGame;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\GameChooser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OpenGame;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\GameChooser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Stats;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\GameChooser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Exit;
        
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
            System.Uri resourceLocater = new System.Uri("/Pairs;component/gamechooser.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\GameChooser.xaml"
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
            this.NewGame = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\GameChooser.xaml"
            this.NewGame.Click += new System.Windows.RoutedEventHandler(this.NewGame_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.OpenGame = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\GameChooser.xaml"
            this.OpenGame.Click += new System.Windows.RoutedEventHandler(this.OpenGame_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Stats = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\GameChooser.xaml"
            this.Stats.Click += new System.Windows.RoutedEventHandler(this.Stats_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Exit = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\GameChooser.xaml"
            this.Exit.Click += new System.Windows.RoutedEventHandler(this.Exit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
