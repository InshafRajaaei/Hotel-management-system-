﻿#pragma checksum "..\..\..\EditRoomWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C2AB1C401C171C89820AE42AFFDBDC7DC9DC946B"
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
using System.Windows.Controls.Ribbon;
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


namespace HotelMS {
    
    
    /// <summary>
    /// EditRoomWindow
    /// </summary>
    public partial class EditRoomWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\EditRoomWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RoomIdTextBox;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\EditRoomWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RoomNumberTextBox;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\EditRoomWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox RoomTypeComboBox;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\EditRoomWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PricePerNightTextBox;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\EditRoomWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox IsOccupiedCheckBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/HotelMS;component/editroomwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\EditRoomWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.RoomIdTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.RoomNumberTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.RoomTypeComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.PricePerNightTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.IsOccupiedCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 6:
            
            #line 26 "..\..\..\EditRoomWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Save_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 27 "..\..\..\EditRoomWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Cancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

