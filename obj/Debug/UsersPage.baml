   M S B A M L   `   `   `  ����G  CResortStudio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ResortStudioResortStudio  5          ResortStudio.UsersPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:ResortStudio     5        N� Title$  	UsersPage��5	       N� 
Background
 �����.��5      �  � RowDefinitions 5   
   �� 5      $��3* �6   �� 5      $��9* �6   .+�5   
   �� -   5         ��Name$ 
PageHeader��5      $��0��6)   $��20q�66   $��Stretch=�6C   $��Center=�6a   .+�5      �� $��0��6   $
��Bold"�6(   $��24(�6:   Create a new user6[   5      �� 5   
   -   5        $ PageContent��5      $��1��6*   .+�5      �� $��100 10q�6   $	��400��6)   $
��Left=�65   .+�5      �� $
��Bold"�6   $��15(�6*   $��Email address��68    �� Target 6P   ��  �� ElementName$ tbEmail���� 5      -   5         ��Name$ tbEmail��5      $��30��6,   $��Center=�69    �� TextAlignment$ Center=�6\   5      �� 5      $��100 10q�6   $	��400��6*   $
��Left=�66   .+�5      �� $
��Bold"�6   $��15(�6*   $��Password��68    6K   �� $ 
tbPassword��G� 5      -   5         G�Name$ 
tbPassword��5      $��30��63   $��Center=�6?   5      �� 5      $
��Left=�6   $��100 10q�64   	 �� Orientation$	 
Horizontal=�6D   .+�5      �� -   5           PrimaryButton#��[  5   ,   .��6S   Create user6`   �� 5       -   5          SecondaryButton#��[ 5    -   .��6V   Cancel6^   5!      5"      5#      5$      