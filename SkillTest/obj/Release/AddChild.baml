   M S B A M L   `   `   `  ����   	SkillTest    SkillTest.AddChild   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � Title$   Adja meg a gyermek adatait��$	��250��$	��300��$	��200��$	��400�� � 
ResizeMode$ CanResizeWithGrip=� � WindowStartupLocation$ CenterScreen=�   icon � Icon# [  .��� 
������� � RowDefinitions �� $��35��$	��35* ��� $��35��$	��35* ��� $	��100��$	��100 � � ColumnDefinitions �� $	��140��$	��140 ��� $	��100��$
��100* �.+��� -    ��Name$ childNameLabel��$��Gyerek neve: ��$��0��$��0��$��Right=�$��Center=�$	��5,5q�$
��Bold"��� -   $ childIDLabel��$��Gyerek azonosítója: ��$��1��$��0��$��Right=�$��Center=�$	��5,5q�$
��Bold"��� -    ��Name$ childNameTextBox��$��0��$��1��
�������$��Stretch=�$��Center=�$��5q��� -   $ childIDTextBox��$��1��$��1��
�������$��Stretch=�$��Center=�$��5q��� -    ��Name$ 
saveButton��$��2��$��1��$��Mentés��$��30��$��Right=�$��Center=�$��5,5,95,5q�$��80��
���   �$��2q��� -   $ cancelButton��$��2��$��1��$��Mégse��$��30��$��Right=�$��Center=�$��5,5,5,5q�$��80��
���   �$��2q�