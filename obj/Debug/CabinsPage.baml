   M S B A M L   `   `   `  ����G  CResortStudio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ResortStudioResortStudio  5          ResortStudio.CabinsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:ResortStudio     5      -   5          N� 
Background
  ����� N� Title$ 
CabinsPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��3* �6   �� 5      $��9* �6   .+�5   
   � -   5         �Name$ 
PageHeader��5      $��0��6#   $��20q�60   $��Stretch=�6=   $��Center=�6[    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��auto �6#   .+�5      �� $��0��6   $
��Bold"�6(   $��24(�6:   Cabins6P   �� 5      -   5         ��Name$ Filters��5   )   $��1��6    �� Orientation$ 
Horizontal=�6:   .+�5      �� -   5         ��Name$ FilterBtnAll��5   .      PrimaryButton#��[  6D   .��6l   
Show all6v   �� 5      -   5        $ FilterBtnNoDiscount��5   ;     SecondaryButton#��[ 6X   .��6�   No discount6�   �� 5      -   5        $ FilterBtnDiscount��5   8   #��[ 6S   .��6}   With discount6�   5      5      � 5   
   -   5        $ PageContent��5      $��1��6$    5      �� 5      $��9* �6#   �� 5      $��3* �6#   .+�5"      �� $��0��6   .+�5#      &   System.Windows.Controls.DataGrid  -   5          Name$ 
CabinTable��5#        MyDataGridStyle#��[ 6/   $��0��6X   	 �� SelectedIndex$	 0��6h   
   Columns
 5$      4  .System.Windows.Controls.DataGridTemplateColumn  5%      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 61      Header$ Image��6;      CellTemplate 5&      �� 5'   "   .R�5(   &   �� $	��100��6,   $	��100��68   $��UniformToFill=�6^   ��6E   �� *Image+6^   5)   #   5+      0  *System.Windows.Controls.DataGridTextColumn  5,      $ * 6-   $
 Name��67   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   �� *Name+  5-      $ * 6-   $ Max Capacity��68    6N   �� *MaxCapacity+  5.      $ * 6-   $ Regular Price��68    6O   �� *RegularPrice+  5/      $ * 6.   $ Discount��68    6J   �� *
Discount+  51      $ * 6-   $ Description��67    6L   �� *Description+   ElementStyle 52      �� 53   "    �� 
TargetType" ��6(   .�54   &   ��  �� Property � �� �� Value$
 Wrap=�6E   55   #   57      59      � 5;      $��10 20q�6    5<      �� 5=      $��* �6+   �� 5>      $
��Auto �6+   .+�5A      �� -	   5         ��Name$ 
tbPageInfo��5A   A   $��0��6    ��60   �� 6A   �� 5C      $��1��6!   $ 
Horizontal=�61   $��Center=�6J   .+�5D      �� -
   5        $��Previous page��5D   5   #��[ 6M   �� 5E      -   5        $��	Next page��5E   1   #��[  6E   5F      5G      5H      � 5I      $��1��6   
�������.+�5J      �� $��10q�6   .+�5K      �� $��0 10 0 0q�6   $��	Image url��6T    �� Target 6.   ��  �� ElementName$ tbName��6T   �� 5L      -   5         ��Name$ tbImage��5L   Z   $��22��6   $	��250��6*   ��66   �� *Image+ �� Mode$ TwoWay=�6Z   �� 5M      $��0 10 0 0q�6   $
��Name��6T    6.   �� $ tbName��6T   �� 5N      -   5        $ tbName��5N   Y   $��22��6   $	��250��6*   ��66   �� *Name+$ TwoWay=�6Y   �� 5O      $��0 10 0 0q�6   $��Max capacity��6[    6.   �� $ tbMaxCapacity��6[   �� 5P      -   5        $ tbMaxCapacity��5P   `   $��22��6   $	��250��6*   ��66   �� *MaxCapacity+$ TwoWay=�6`   �� 5Q      $��0 10 0 0q�6   $��Regular price��6\    6.   �� $ tbRegularPrice��6\   �� 5R      -   5        $ tbRegularPrice��5R   a   $��22��6   $	��250��6*   ��66   �� *RegularPrice+$ TwoWay=�6a   �� 5S      $��0 10 0 0q�6   $��Discount��6X    6.   �� $ 
tbDiscount��6X   �� 5T      -   5        $ 
tbDiscount��5T   ]   $��22��6   $	��250��6*   ��66   �� *
Discount+$ TwoWay=�6]   �� 5U      $��0 10 0 0q�6   $��Description��6\    6/   �� $ tbDescription��6\   �� 5V      -   5        $ tbDescription��5V   `   $��22��6   $	��250��6*   ��66   �� *Description+$ TwoWay=�6`   �� 5W      -   5         ��Name$ cbFull��5W   �   $
��0 10q�6r    d� 	IsChecked 6   �� *IsFull+.��6�   Full6�   �� 5Y      $
��0 20q�6!   $��Center=�60   .+�5Z      �� -   5        $ BtnUpdateCabin��5Z   5   $	��0 5q�6M   #��[  6Z   .��6�   Update cabin6�   �� 5[      -   5        $ BtnRemoveCabin��5[   5   $	��0 5q�6M   #��[ 6Z   .��6�   Remove cabin6�   �� 5\      -   5        $ BtnAddCabin��5\   3   $
��0 10q�6I   #��[  6W   .��6~   Add new cabin6�   5]      5^      5_      5`      5a      5b      