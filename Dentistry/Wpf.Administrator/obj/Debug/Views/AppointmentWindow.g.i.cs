﻿#pragma checksum "..\..\..\Views\AppointmentWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FAF076D4D54ECC97A5374A3F2486CCC77B739C18AF33B2B1C37826779E5546BB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DevExpress.Core;
using DevExpress.Mvvm;
using DevExpress.Mvvm.UI;
using DevExpress.Mvvm.UI.Interactivity;
using DevExpress.Mvvm.UI.ModuleInjection;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Core.ConditionalFormatting;
using DevExpress.Xpf.Core.DataSources;
using DevExpress.Xpf.Core.Serialization;
using DevExpress.Xpf.Core.ServerMode;
using DevExpress.Xpf.DXBinding;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Editors.DataPager;
using DevExpress.Xpf.Editors.DateNavigator;
using DevExpress.Xpf.Editors.ExpressionEditor;
using DevExpress.Xpf.Editors.Filtering;
using DevExpress.Xpf.Editors.Flyout;
using DevExpress.Xpf.Editors.Popups;
using DevExpress.Xpf.Editors.Popups.Calendar;
using DevExpress.Xpf.Editors.RangeControl;
using DevExpress.Xpf.Editors.Settings;
using DevExpress.Xpf.Editors.Settings.Extension;
using DevExpress.Xpf.Editors.Validation;
using DevExpress.Xpf.LayoutControl;
using DevExpress.Xpf.Scheduling;
using DevExpress.Xpf.Scheduling.Common;
using DevExpress.Xpf.Scheduling.Editors;
using DevExpress.Xpf.Scheduling.Themes;
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
using Wpf.Administrator.Infrastructure.DialogService;
using Wpf.Administrator.ViewModels;


namespace Wpf.Administrator.Views {
    
    
    /// <summary>
    /// AppointmentWindow
    /// </summary>
    public partial class AppointmentWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 3 "..\..\..\Views\AppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Wpf.Administrator.Views.AppointmentWindow NewAppointmentWindow;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Views\AppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.LayoutControl.LayoutControl validationContainer;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Views\AppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.TextEdit subjectEdit;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\Views\AppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.TextEdit patientName;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Views\AppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.TextEdit patientPhone;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\Views\AppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.TextEdit patientEmail;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\Views\AppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.DateEdit editorStartDate;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\Views\AppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.TextEdit editorStartTime;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\Views\AppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.DateEdit editorEndDate;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\Views\AppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.TextEdit editorEndTime;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\Views\AppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOk;
        
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
            System.Uri resourceLocater = new System.Uri("/Wpf.Administrator;component/views/appointmentwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\AppointmentWindow.xaml"
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
            this.NewAppointmentWindow = ((Wpf.Administrator.Views.AppointmentWindow)(target));
            return;
            case 2:
            this.validationContainer = ((DevExpress.Xpf.LayoutControl.LayoutControl)(target));
            return;
            case 3:
            this.subjectEdit = ((DevExpress.Xpf.Editors.TextEdit)(target));
            return;
            case 4:
            this.patientName = ((DevExpress.Xpf.Editors.TextEdit)(target));
            return;
            case 5:
            this.patientPhone = ((DevExpress.Xpf.Editors.TextEdit)(target));
            return;
            case 6:
            this.patientEmail = ((DevExpress.Xpf.Editors.TextEdit)(target));
            return;
            case 7:
            this.editorStartDate = ((DevExpress.Xpf.Editors.DateEdit)(target));
            return;
            case 8:
            this.editorStartTime = ((DevExpress.Xpf.Editors.TextEdit)(target));
            return;
            case 9:
            this.editorEndDate = ((DevExpress.Xpf.Editors.DateEdit)(target));
            return;
            case 10:
            this.editorEndTime = ((DevExpress.Xpf.Editors.TextEdit)(target));
            return;
            case 11:
            this.btnOk = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

