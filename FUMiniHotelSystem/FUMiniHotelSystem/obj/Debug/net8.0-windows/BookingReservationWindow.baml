   M S B A M L   `   `   `  ����L  HFUMiniHotelSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:FUMiniHotelSystemFUMiniHotelSystem  5   	   0    *FUMiniHotelSystem.BookingReservationWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:FUMiniHotelSystem     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ Booking History��5	   	   $	��450��6!   $	��800��6.   .��5
      � ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��5      �  � Color$ #0099FF��6    � Offset$ 0Q�6/   � 5      $ 	#FF347BDA��6   $ 0.794Q�61   � 5      $ 	#FF60B1E7��6   $ 1Q�61   � 5      $ 	#FF596FDD��6   $ 0.309Q�61   � 5      $ 	#FF472FDE��6   $ 0.484Q�61   5       � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      $��* �6   �� 5      $��60 �6    � ColumnDefinitions 5   
   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ label��5      $��Booking History��6   $��0��69   $��0��6I   $��36(�6V   $��Center=�6d   &   System.Windows.Controls.DataGrid  5!   
   -   5        	  Name$	 dgBookingHistory��5!      $��10q�6-   $��0��69   $��1��6I   
   AutoGenerateColumns$
 False��6V      CanUserAddRows$ False��6r      Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Header$ Reservation ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6f   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *BookingReservationID+6f     5$      $ Booking Date��6%   $ * 6z    6;   �� *BookingDate+ �� StringFormat$ {0:dd/MM/yyyy}��6z     5%      $ Total Price��6%   $ * 6o    6:   �� *
TotalPrice+$ {0:C}��6o     5&      $ Status��6%   $ * 6W    65   �� *BookingStatus+6W   5(      �� 5*   
   $��0��6   $��2��6%    �� Orientation$ 
Horizontal=�62   $��Center=�6K   $��Center=�6h   $��	0,10,0,10q�6�   .+�5+      �� -   5         ��Name$ btnUserProfile��5+      $��User Profile��6-   $	��150��6D   $��50��6P   ���	#FF1B71A1
�������$��	10,0,10,0q�6�   6�   �� 5,      -   5        $ btnClose��5,      $��Close��6'   $	��150��67   $��50��6C   ���	#FFEF8F18
�������$��	10,0,10,0q�6y   6�   5-      5.      5/      