﻿#pragma checksum "..\..\GuestsPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C527F1465896229939BCD95E61DC7C96DA4707DA3EEEF51640BD241E99C71D18"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ResortStudio;
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


namespace ResortStudio {
    
    
    /// <summary>
    /// GuestsPage
    /// </summary>
    public partial class GuestsPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\GuestsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid PageHeader;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\GuestsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SearchAll;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\GuestsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel Filters;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\GuestsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbSearchGuest;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\GuestsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel PageContent;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\GuestsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid GuestsTable;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\GuestsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbPageInfo;
        
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
            System.Uri resourceLocater = new System.Uri("/ResortStudio;component/guestspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\GuestsPage.xaml"
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
            this.PageHeader = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.SearchAll = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\GuestsPage.xaml"
            this.SearchAll.Click += new System.Windows.RoutedEventHandler(this.SearchAll_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Filters = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 4:
            this.tbSearchGuest = ((System.Windows.Controls.TextBox)(target));
            
            #line 28 "..\..\GuestsPage.xaml"
            this.tbSearchGuest.KeyDown += new System.Windows.Input.KeyEventHandler(this.TextBox_KeyDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.PageContent = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 6:
            this.GuestsTable = ((System.Windows.Controls.DataGrid)(target));
            
            #line 33 "..\..\GuestsPage.xaml"
            this.GuestsTable.Loaded += new System.Windows.RoutedEventHandler(this.OnLoaded);
            
            #line default
            #line hidden
            return;
            case 7:
            this.tbPageInfo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            
            #line 51 "..\..\GuestsPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PreviousBtn);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 52 "..\..\GuestsPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NextBtn);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
