   M S B A M L   `   `   `  ����  HotelMS    HotelMS.RoomsView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      .��5      �� .+�5   
   &   System.Windows.Controls.DataGrid  -   5           Name$  	RoomsGrid��5         AutoGenerateColumns$ False��5         HeadersVisibility$ Column=�5         
IsReadOnly$
 True��5	         SelectionMode$ Single=�5
      
����������#A67C52$��2q�5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Room ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *RoomId+  5      $ Room Number��6%    6:   �� *
RoomNumber+  5      $ 	Room Type��6%    68   �� *
RoomType+  5      $ Price Per Night��6%    6>   �� *PricePerNight+4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $ Occupied��6)      
IsReadOnly$
 True��6Z    6;   �� *
IsOccupied+6Z   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Actions��6)   	   CellTemplate	 5      �� 5      .R�5      �� 
 �� Orientation$
 
Horizontal=�6)   .+�5   "   �� -   5        $
��Edit��5   )   $��5q�5   )   $��5q�5   )   ���#A67C52
�������5   )   �� 5   "   -   5        $��Delete��5   )   $��5q�5    )   $��5q�5!   )   ���#E74C3C
�������5#   )   5$      5%      5'      5)      �� 5+   
   -   5        $��Add Room��5+      $��0,10,0,0q�5-      $��10q�5.      ���#A67C52
�������
������ $
��Bold"�52      53      54      