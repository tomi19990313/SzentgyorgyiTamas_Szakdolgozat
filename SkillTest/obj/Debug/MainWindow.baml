   M S B A M L   `   `   `  ����]  YTobii.Interaction.Net, Version=0.7.1.36, Culture=neutral, PublicKeyToken=70326046dcdce6cb\Bclr-namespace:Tobii.Interaction.Wpf;assembly=Tobii.Interaction.NetTobii.Interaction.Wpf  5   	    	SkillTest   SkillTest.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   RwpfBclr-namespace:Tobii.Interaction.Wpf;assembly=Tobii.Interaction.Net     5   	     � Title$"  Iránytévesztés vizsgálat��5   	   $	��400��5	   	   $	��400��6    � 
ResizeMode$ CanResizeWithGrip=�6(    � WindowState$ 	Maximized=�6G    � Icon$ /images/icon.ico��5
   	    � 	Resources 5         ViewboxGazeAwareAnimation �� 
TargetType �� Property �� Value%   Tobii.Interaction.Wpf.Behaviors �� Triggers	 P� Property
 P� Value N� EnterActions �� TargetProperty W� From	 W� To g� Duration N� ExitActions�� 5   
   %�  &	        �� 5      " (�66   .�5      ��  � y�$ Visible=�6/   �� 5       �@ IsGazeAware . 6M    5      P� 5      	 �@ HasGaze
 .  5      �� 5      .��5   "   �� .��5   &   W� $ Opacity�66   $	 1.0X�6Z   $	 0.0X�6e   $ 0:0:.2D�6n   5   #   5       5      �� 5      .��5   "   �� .��5   &   W� $ Opacity�66   $	 0.0X�6Z   $	 1.0X�6e   $ 0:0:.2D�6n   5   #   5      5!      5#      5$      .��5'      � ���	#FF00A8FF � RowDefinitions 5(   
   �� 5)      $��80��6   $	��80* �6+   �� 5*      $��80��6   $	��80* �6+   �� 5+      $��80��6   $	��80* �6+   �� 5,      $��80��6   $	��80* �6+    � ColumnDefinitions 5/   
   �� 50      $��80��6   $	��80* �6-   �� 51      $��80��6   $	��80* �6-   �� 52      $��80��6   $	��80* �6-   .+�55   
   (� $��0��6   $��1��6    (� Stretch$ Uniform=�6/   $��Center=�6A   $	��Top=�6^   $��10q�6v   .��56      �� -   5         ��Name$ 	titleName��56      $"��Iránytévesztés vizsgálat��6'   $
��Bold"�6J   $��5(�6\   57      (� 59   
   $��1��6   $��1��6   $ Uniform=�6/   $��Center=�6A   $��Bottom=�6^   #��[  6y   .��5:      �� $
��1 cm��6   $
��1 cm��6$    J� RenderTransformOrigin$ 0.5,0.5&�65    	 arrow#��[ 6U   z�5;      V� 5<      .~�5=      ��  �� Angle$	 -90Q�6*   5>      5@      5A      (� 5C   
   $��2��6   $��0��6   $ Uniform=�6/   $��Right=�6A   $��Center=�6]   #��[  6x   .��5D      �� $
��1 cm��6   $
��1 cm��6$   #��[ 65   $ 0.5,0.5&�6U   z�5E      V� 5F      .~�5G      �� $	 180Q�6*   5H      5J      5K      (� 5M   
   $��2��6   $��2��6   $
��Left=�6/   $��Center=�6J   #��[  6e   .��5N      �� $
��1 cm��6   $
��1 cm��6$   #��[ 65   5O      (� 5Q   
   $��3��6   $��1��6   $��Center=�6/   $	��Top=�6L   #��[  6d   .��5R      �� $
��1 cm��6   $
��1 cm��6$   #��[ 65   $ 0.5,0.5&�6U   z�5S      V� 5T      .~�5U      �� $ 90Q�6*   5V      5X      5Y      (� 5[   
   $��2��6   $��1��6   $ Uniform=�6/   $��20q�6A   $��Center=�6M   $��Center=�6j   .��5\      �� $��Nézz jobbra!��6   $
��1 cm��6+   $
��1 cm��6<   $��18(�6L   $
��Bold"�6Z   $��15q�6l   $��4q�6y   
���   �6�   5]      5^      5`      