   M S B A M L   `   `   `  ����G  CResortStudio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ResortStudioResortStudio  5          ResortStudio.SettingsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:ResortStudio     5        N� Title$  SettingsPage��5	       N� 
Background
 �����.��5      �  � RowDefinitions 5   
   �� 5      $��3* �6   �� 5      $��9* �6   .+�5   
   �� -   5         ��Name$ 
PageHeader��5      $��0��6)   $��20q�66   $��Stretch=�6C   $��Center=�6a   .+�5      �� $��0��6   $
��Bold"�6(   $��24(�6:   Update hotel settings6_   5      �� 5   
   -   5        $ PageContent��5      $��1��6*   .+�5      �� $��100 10q�6   $	��400��6)   $
��Left=�65   .+�5      �� $
��Bold"�6   $��15(�6*   $��Minimum booking length��68    �� Target 6Y   ��  �� ElementName$ tbMinBookingLength���� 5      -   5         ��Name$ tbMinBookingLength��5   <   $��30��6Y   $��Center=�6f    �� TextAlignment$ Center=�6�   ��6   �� *MinBookingLength+6�   5      �� 5      $��100 10q�6   $	��400��6)   $
��Left=�65   .+�5      �� $
��Bold"�6   $��15(�6*   $��Maximum booking length��68    6Y   �� $ tbMaxBookingLength���� 5      -   5        $ tbMaxBookingLength��5   <   $��30��6Y   $��Center=�6f   $ Center=�6�   ��6   �� *MaxBookingLength+6�   5      �� 5      $��100 10q�6   $	��400��6)   $
��Left=�65   .+�5      �� $
��Bold"�6   $��15(�6*   $��Max guests per booking��68    6Y   �� $ tbMaxGuests���� 5      -   5        $ tbMaxGuests��5   ?   $��30��6U   $��Center=�6b   $ Center=�6�   ��6   �� *MaxGuestsPerBooking+6�   5      �� 5       $��100 10q�6   $	��400��6*   $
��Left=�66   .+�5!      �� $
��Bold"�6   $��15(�6*   $��Breakfast price��68    6R   �� $ tbBreakfastPrice���� 5"      -   5        $ tbBreakfastPrice��5"   :   $��30��6U   $��Center=�6a   $ Center=�6�   ��6   �� *BreakfastPrice+6�   5#      �� 5%      $
��Left=�6   $��100 10q�64    �� Orientation$ 
Horizontal=�6D   .+�5&      �� -   5           PrimaryButton#��[  5&   .   .��6U   Update settings6f   5'      5(      5)      5*      