   M S B A M L   `   `   `  ����G  CResortStudio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ResortStudioResortStudio  5          ResortStudio.GuestsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:ResortStudio     5        N� Title$  
GuestsPage��5	       N� 
Background
 �����.��5      �  � RowDefinitions 5   
   �� 5      $��3* �6   �� 5      $��9* �6   .+�5   
   � -   5         �Name$ 
PageHeader��5      $��0��6#   $��20q�60   $��Stretch=�6=   $��Center=�6[    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   .+�5      �� $��Center=�6   $��0��63   $
��Bold"�6C   $��24(�6U   Guests6k   �� 5      $��1��6    �� Orientation$ 
Horizontal=�6)   $��Stretch=�6B   $��Center=�6`   .+�5      �� -   5         ��Name$ 	SearchAll��5   G   $��	0 0 200 0q�6   $��Center=�6,      PrimaryButton#��[  6r   .��6�   
Search all6�   �� 5      -   5         ��Name$ Filters��5      $��Center=�6+   .+�5      �� $��16(�6   $��Search for a guest ��6&   $
��Bold"�6D    �� Target 6V   �� 	 �� ElementName$	 tbSearchGuest���� 5      -   5        
 ��Name$
 tbSearchGuest��5   4   $	��300��6K   $��30��6W   $��Center=�6c    �� TextAlignment$ Center=�6�   5      5      5      �� 5    
   -   5        $ PageContent��5       $��1��6*   .+�5!      &   System.Windows.Controls.DataGrid  -   5          Name$ GuestsTable��5!   )     MyDataGridStyle#��[ 6>      Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6)      Header$ 	Full Name��63   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6F   �� *
FullName+  5$      $ * 6)   $ Email��63    6B   �� *Email+  5%      $ * 6)   $ Nationality��64    6I   �� *Nationality+  5&      $ * 6)   $ National ID��64    6I   �� *
NationalId+5(      � 5*      $��10 20q�6    5+      �� 5,      $��* �6'   �� 5-      $
��Auto �6'   .+�50      �� -   5         ��Name$ 
tbPageInfo��50   =   $��0��6   ��6,   �� 6=   �� 52      $��1��6   $ 
Horizontal=�6-   $��Center=�6F   .+�53      �� -   5        $��Previous page��53   1     SecondaryButton#��[ 6I   �� 54      -	   5        $��	Next page��54   -   #��[  6A   55      56      57      59      5:      