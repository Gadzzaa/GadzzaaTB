   M S B A M L   `   `   `  ����   	GadzzaaTB    GadzzaaTB.Main   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       N� Title$
  Main��   	Righteous N� 
FontFamily# [   N� 
Foreground
 �����.��� -    �Name$ mainGrid�� � ColumnDefinitions �� $��20 ��� $
��Auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $��* ��� $��20 � � RowDefinitions �� $��20 ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* ��� $��40 ��� $��20 �.+��� $��1��$��1��$��2��$��	GadzzaaTB��$��25(��� $��1��$��2��$��2��$��Integrations status:��$��20(��� -    ��Name$ StreamCompanionStatus��$��3��$��2��$��StreamCompanion��$��Center=�$��Center=�$��Center=�$��19(�$��5,1,5,0q�
���\\��
������ $��0q� � Cursor$
 Hand���� -   $ GosumemoryStatus��$��4��$��2��$��2��$��
Gosumemory��$��Center=�$��Center=�$��Center=�$��19(�$��5,1,5,0q�
���\\��
������ $��0q�$
 Hand���� -    ��Name$ RequestStatus��$��3��$��4��$��Requests��	 �� TextAlignment$	 Center=�$��Center=�$��19(�$��5,0,5,0q�
��������� -   $ TwitchStatus��$��4��$��4��$��2��$��Twitch��$��Center=�$��Center=�$��Center=�$��19(�$��5,0,5,0q�
���\\��
������ $��0q�$
 Hand��]� $��3��$��5��$��
10,25,10,5q�.+��� $��!��$��17(�
 �� TextAlignment$
 Center=�$��1,1,0,1q� �� 
IsReadOnly . �� -    ��Name$ 	npTextBox��$��np�� �� 	MaxLength$ 4��$
 Center=�$��17(�$��0,1,1,1q�]� $��3��$��6��$��	10,5,10,5q�.+��� $��!��$��17(�$
 Center=�$��1,1,0,1q� . �� -   $ npppTextBox��$
��nppp��$
 Center=�$��17(�$ 4��$��0,1,1,1q��� $��1��$��5��$
	 Left=�$��Center=�$��Display now playing info:��$��16(�$��0,20,0,0q��� $��1��$��6��$
	 Left=�$��Center=�$"��Display now playing PP info:��$��14(��� $��1��$��7��$
	 Left=�$��Center=�$��Twitch Channel Name:��$��16(�$��0,20,0,0q��� -   $ channelName��$��3��$��7��$
 Center=�$��17(�$��Channel Name��$��
10,20,10,0q�$	��154��$��23���� $��5��$��8��$��Right=�$��Bottom=�.+��� $	 Center=�$��15(�v.Beta�� -	   $��Center=�$��Center=�$��
Bug Report��$
 Hand���� $��1��$��8��$
��Left=�$��Bottom=�.+��� $	 Center=�$��15(�twitch.tv/gadzzaa�� -
    ��Name$ transparentNegru��$��0��$��0��$��10��$��10�����	#7F000000$y�Hidden=��� -   $ 
pleaseWait��$��0��$��0��$��10��$��10��$��Please Wait...��$��75(�$��Normal&�$	 Center=�$��Center=�$��Center=����	#FF00D884$��NoWrap=�$y�Hidden=�