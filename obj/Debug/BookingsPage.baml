   M S B A M L   `   `   `  ����G  CResortStudio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ResortStudioResortStudio  5          ResortStudio.BookingsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:ResortStudio     5        N� Title$  BookingsPage��5	       N� 
Background
 �����.��5      �  � RowDefinitions 5   
   �� 5      $��3* �6   �� 5      $��9* �6   .+�5   
   � -   5         �Name$ 
PageHeader��5      $��0��6#   $��20q�60   $��Stretch=�6=   $��Center=�6[    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��auto �6#   .+�5      �� $��0��6   $
��Bold"�6(   $��24(�6:   
Bookings6R   �� 5      -   5         ��Name$ Filters��5   )   $��1��6    �� Orientation$ 
Horizontal=�6:   .+�5      �� -   5         ��Name$ FilterBtnAll��5         SecondaryButton#��[  6F   .��6p   
Show all6z   �� 5      -   5        $ FilterBtnUnc��5      #��[  6N   .��6w   Unconfirmed6�   �� 5      -   5        $ FilterBtnChin��5      #��[  6M   .��6w   
Checked in6�   �� 5      -   5        $ FilterBtnChout��5      #��[  6O   .��6x   Checked out6�   5      5      � 5   
   -   5        $ PageContent��5      $��1��6$    5      �� 5      $��9* �6#   �� 5       $��3* �6#   .+�5"      �� $��0��6   .+�5#      &   System.Windows.Controls.DataGrid  -   5          Name$ BookingsTable��5#   -     MyDataGridStyle#��[ 6D   	 �� SelectedIndex$	 0��6�   $	��Top=�6�   
   Columns
 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6-      Header$ Cabin Id��67   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6I   �� *	CabinId+  5&      $ * 6-   $ Guest Id��67    6I   �� *	GuestId+  5'      $ * 6-   $ Dates��68    6G   �� *FormattedDates+  5(      $ * 6-   $ Status��68    6H   �� *Status+  5)      $ * 6.   $ Amount��68    6H   �� *Amount+5+      � 5,      $��10 20q�6    5-      �� 5.      $��* �6+   �� 5/      $
��Auto �6+   .+�52      �� -	   5         ��Name$ 
tbPageInfo��52   A   $��0��6    ��60   �� 6A   �� 54      $��1��6!   $ 
Horizontal=�61   $��Center=�6J   .+�55      �� -
   5        $��Previous page��55   5   #��[  6M   �� 56      -   5        $��	Next page��56   1     PrimaryButton#��[ 6E   57      58      59      � 5;      $��1��6   
�������.+�5<      �� $��10q�6   .+�5=      �� $
��Bold"�6   $��0 10 0 0q�6.   $��Cabin Image��6@   �� 5>      -   5         ��Name$ tbCabinImage��5>   G   $	��100��6   $��50��6(   $
��Fill=�6]   ��64   �� 6]   �� 5?      $
��Bold"�6   $��0 10 0 0q�6.   $��
Guest Name��6@   �� 5@      -   5        $ tbGuestName��5@   1   ��6    �� 61   �� 5A      $
��Bold"�6   $��0 10 0 0q�6.   $��Guest Email��6@   �� 5B      -   5        $ tbEmail��5B   1   ��6    �� 61   �� 5C      $
��Bold"�6   $��0 10 0 0q�6.   $��Dates��6@   �� 5D      -   5        $ tbDates��5D   1   ��6    �� 61   �� 5E      $
��Bold"�6   $��0 10 0 0q�6.   $��Number of nights��6@   �� 5F      -   5        $ tbNumNights��5F   1   ��6    �� 61   �� 5G      $
��Bold"�6   $��0 10 0 0q�6.   $��Number of guests��6@   �� 5H      -   5        $ tbNumGuests��5H   1   ��6    �� 61   �� 5I      $
��Bold"�6   $��0 10 0 0q�6.   $��
Cabin Name��6@   �� 5J      -   5        $ tbCabinName��5J   1   ��6    �� 61   �� 5K      $
��Bold"�6   $��0 10 0 0q�6.   $��Cabin price��6@   �� 5L      -   5        $ tbCabinPrice��5L   1   ��6    �� 61   �� 5M      $
��Bold"�6   $��0 10 0 0q�6.   $��Breakfast price��6@   �� 5N      -   5        $ tbBreakfastPrice��5N   1   ��6    �� 61   �� 5O      $
��Bold"�6   $��0 10 0 0q�6.   $��Total price��6@   �� 5P      -   5        $ tbTotalPrice��5P   1   ��6    �� 61   �� 5Q      $
��Bold"�6   $��Status��6.   �� 5R      -   5        $ tbCheckedIn��5R   1   ��6    �� 61   �� 5S      $
��Bold"�6   $��Is Paid��6.   �� 5T      -   5        $ tbPaid��5T   1   ��6    �� 61   �� 5U      -   5         ��Name$ cbBreakfastIncluded��5U   1   $��0 10 0 0q�6   .��6�   Breakfast included6�   �� 5X      $��0 20 0 0q�6!   $��Center=�64   .+�5Y      �� -   5        $	��0 5q�5Y   !   #��[ 6.   .��6l   
Check in6v   �� 5Z      -   5        $	��0 5q�5Z   !   #��[ 6.   .��6m   	Check out6x   �� 5[      -   5        $	��0 5q�5[   !   #��[  6.   .��6m   Remove booking6}   5\      5]      5_      5`      5b      5c      