﻿#pragma checksum "..\..\IranytevesztesWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "58B4B2D317A6951397CE25052E8AA7B0A8CDC005F687F90703CE3E541887777E"
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
using Tobii.Interaction.Wpf;


namespace SkillTest {
    
    
    /// <summary>
    /// IranytevesztesWindow
    /// </summary>
    public partial class IranytevesztesWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 55 "..\..\IranytevesztesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label titleName;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\IranytevesztesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button StartButton;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\IranytevesztesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label DirectionLabel;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\IranytevesztesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MenuButton;
        
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
            System.Uri resourceLocater = new System.Uri("/SkillTest;component/iranyteveszteswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\IranytevesztesWindow.xaml"
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
            this.titleName = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.StartButton = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\IranytevesztesWindow.xaml"
            this.StartButton.Click += new System.Windows.RoutedEventHandler(this.StartButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 62 "..\..\IranytevesztesWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).AddHandler(Tobii.Interaction.Wpf.Behaviors.HasGazeChangedEvent, new System.EventHandler<Tobii.Interaction.Wpf.HasGazeChangedRoutedEventArgs>(this.TopArrow_HasGazeChanged));
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 72 "..\..\IranytevesztesWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).AddHandler(Tobii.Interaction.Wpf.Behaviors.HasGazeChangedEvent, new System.EventHandler<Tobii.Interaction.Wpf.HasGazeChangedRoutedEventArgs>(this.LeftArrow_HasGazeChanged));
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 82 "..\..\IranytevesztesWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).AddHandler(Tobii.Interaction.Wpf.Behaviors.HasGazeChangedEvent, new System.EventHandler<Tobii.Interaction.Wpf.HasGazeChangedRoutedEventArgs>(this.RightArrow_HasGazeChanged));
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 86 "..\..\IranytevesztesWindow.xaml"
            ((System.Windows.Controls.Viewbox)(target)).AddHandler(Tobii.Interaction.Wpf.Behaviors.HasGazeChangedEvent, new System.EventHandler<Tobii.Interaction.Wpf.HasGazeChangedRoutedEventArgs>(this.BottomArrow_HasGazeChanged));
            
            #line default
            #line hidden
            return;
            case 7:
            this.DirectionLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.MenuButton = ((System.Windows.Controls.Button)(target));
            
            #line 101 "..\..\IranytevesztesWindow.xaml"
            this.MenuButton.Click += new System.Windows.RoutedEventHandler(this.MenuButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

