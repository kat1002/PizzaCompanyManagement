   M S B A M L   `   `   `  ����A  =WPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WPFApp.ViewsWPFApp.Views  5      3clr-namespace:WPFApp.UtilitiesWPFApp.Utilities  5          WPFApp.Views.ConfirmOrder   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:WPFApp.Views     5      -cvclr-namespace:WPFApp.Utilities     5        � 	Resources  5      0   *WPFApp.Utilities.PizzaDescriptionConverter   PizzaDescriptionConverter(   "WPFApp.Utilities.ToppingsConverter  ToppingsConverter��%:   &	        &	        5   
   6'     5   
   6   5      .��5      � 
�������.+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��	dataGrid1��5         
IsReadOnly$
 True��5         AutoGenerateColumns$ False��5      $��20,20,20,353q�5         CanUserAddRows$ False��5      ��5      �� *Pizzas+ �� SelectedItem 5      �� *SelectedPizza+ �� Mode$ TwoWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Pizza��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5   %   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 5   %   �� *Pizza+
 �� 	Converter#
 [  5   1     5      $ Quantity��6%   	 5   %   �� *
Quantity+ �� UpdateSourceTrigger$ PropertyChanged=�6i     5      $ Price��6%   	 5   %   �� *Price+6A      RowDetailsTemplate 5!      �� 5"      .R�5#      �� $��0q�6   
������� �� Padding$ 10q�5%      ._�5&      ��  �� Orientation$ Vertical=�6%   .+�5'      �� $ 
Horizontal=�6)   .+�5(   "   �� $��12(�6,   $��
Toppings: ��5)   ,   $��Center=�5*   ,   �� 5+   "   $��16(�6,   
���p�$��Center=�5.   ,   $
��Wrap=�5/   ,   $	��500��50   ,   ��5-   ,   �� *Pizza.Toppings+#
 [ 50   ,   51      53      54      55      57        58   
   $ False��6   $��20,252,315,90q�5:      $ False��5<      $
 True��5=      ��59      �� *Drinks+ 5;      �� *SelectedDrink+$ TwoWay=� 5>        5?      $ Drinks��6%   $ * 5A   %   	 5@   %   �� *
Drink.Name+5A   1     5B      $ Quantity��6%   	 5C   %   �� *
Quantity+$ PropertyChanged=�6i     5D      $ Price��6%   $ 75 5F   %   	 5E   %   �� *Price+5F   2   5H        5I   
   $ False��6   $��315,252,20,90q�5K      $
 True��5M      $
 True��5N      ��5J      �� *Sides+ 5L      �� *SelectedSide+$ TwoWay=� 5O        5P      $ Sides��6%   $ * 5R   %   	 5Q   %   �� *	Side.Name+5R   1     5S      $ Quantity��6%   	 5T   %   �� *
Quantity+$ PropertyChanged=�6i     5U      $ Price��6%   $ 75 5W   %   	 5V   %   �� *Price+5W   2   5Y      �� 5Z   
   $��Clear Order��6   $
��Left=�5[      $��422,528,0,0q�5\      $	��Top=�5]       J� RenderTransformOrigin$ 	0.3,-0.55&�5^      $��73��5_      $��30��5`      ��5a      �� *ClearCommand+�� 5b   
   $��Confirm Order��6   $
��Left=�5c      $��520,528,0,0q�5d      $	��Top=�5e      $��82��5f      $��30��5g      $ 	0.58,0.12&�5i      ��5h      �� *AddressCommand+5i      �� 5j   
   $��+��6   $
��Left=�5k      $��
20,526,0,0q�5l      $	��Top=�5m      $��25��5n      $��30��5o      $��20(�5p      ���	#FF9AFF7F��5r      �� *IncreaseCommand+�� 5s   
   $��-��6   $
��Left=�5t      $��
76,526,0,0q�5u      $	��Top=�5v      $��25��5w      $��30��5x      $��20(�5y      ���	#FFF8FF73��5{      �� *DecreaseCommand+�� 5|   
   $��Delete��6   $
��Left=�5}      $��124,526,0,0q�5~      $	��Top=�5      $��40��5�      $��30��5�      ���	#FFFF9797��5�      �� *DeleteCommand+�� 5�   
   $��Total Price:��6   $
��Left=�5�      $��216,524,0,0q�5�      $	��Top=�5�      $��18(�5�      $
��Bold"�5�      �� 5�   
   $
��Left=�6   $��319,530,0,0q�5�      $
��Wrap=�5�      $	��Top=�5�      $��16(�5�      ��5�      �� *
TotalPrice+� 5�   
   -   5        $��ShippingAddressPopup��5�      $��Center=�5�       � 	StaysOpen$ False��5�       � AllowsTransparency$
 True��5�      ��5�      �� *IsPopupOpen+.��5�      �� 
�������
���   �$��1q�5�      $ 10q�5�      ._�5�      �� .+�5�      �� $��Enter Shipping Address:��6    $��0,0,0,10q�5�       $
��Bold"�5�       �� 5�      $ 
Horizontal=�6!   $��0,5,0,5q�5�   !   .+�5�      �� $��Address:��6$   $	��100��5�   $   $��Center=�5�   $   �� 5�      -   5        $��NameTextBox��5�   "   $	��200��5�   "   ��5�   "   �� *ShippingAddress+5�      �� 5�      $ 
Horizontal=�6!   $��Right=�5�   !   $��0,10,0,0q�5�   !   .+�5�      �� $��Confirm��6!   $��75��5�   !   $��0,0,5,0q�5�   !   ��5�   !   �� *ConfirmCommand+5�   !   �� 5�      $��Cancel��6!   $��75��5�   !   ��5�   !   �� *ClosePopupCommand+5�   !   5�      5�      5�      5�      5�      5�      