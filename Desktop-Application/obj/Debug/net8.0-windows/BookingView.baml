   M S B A M L   `   `   `  ����  HotelMS    HotelMS.BookingsView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      .��5      �� .+�5   
   &   System.Windows.Controls.DataGrid  -   5           Name$  BookingsGrid��5         AutoGenerateColumns$ False��5         HeadersVisibility$ Column=�5         
IsReadOnly$
 True��5	         SelectionMode$ Single=�5
      
����������#A67C52$��2q�5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Booking ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *	BookingId+  5      $ Room ID��6%    66   �� *RoomId+  5      $ Guest ID��6%    67   �� *	GuestId+  5      $ Check-In Date��6%    6<   �� *CheckInDate+ �� StringFormat$ {0:dd/MM/yyyy}��  5      $ Check-Out Date��6%    6=   �� *CheckOutDate+$ {0:dd/MM/yyyy}��  5      $ 
Total Cost��6%    69   �� *	TotalCost+4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Actions��6)   	   CellTemplate	 5      �� 5      .R�5      �� 
 �� Orientation$
 
Horizontal=�6)   .+�5   "   �� -   5        $
��Edit��5   )   $��5q�5   )   $��5q�5   )   ���#A67C52
�������5   )   �� 5   "   -   5        $��Delete��5   )   $��5q�5!   )   $��5q�5"   )   ���#E74C3C
�������5$   )   5%      5&      5(      5*      �� 5,   
   -   5        $��Add Booking��5,      $��0,10,0,0q�5.      $��10q�5/      ���#A67C52
�������
������ $
��Bold"�53      54      55      