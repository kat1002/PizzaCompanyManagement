   M S B A M L   `   `   `  ����A  =WPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WPFApp.ViewsWPFApp.Views  5      3clr-namespace:WPFApp.UtilitiesWPFApp.Utilities  5          WPFApp.Views.OrderDetail   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:WPFApp.Views     5      -cvclr-namespace:WPFApp.Utilities     5        � 	Resources  5      0   *WPFApp.Utilities.PizzaDescriptionConverter   PizzaDescriptionConverter(   "WPFApp.Utilities.ToppingsConverter  ToppingsConverter��%:   &	        &	        5   
   6'     5   
   6   5      .��5      � 
�������$y�Visible=�6   .+�5   
   �� $
��Left=�6   $��	33,26,0,0q�5      $
��Wrap=�5      $��Order Detail��5      $	��Top=�5      $��36(�5      $
��Bold"�5      �� 5   
   $��
0,0,0,-103q�6   $��Hidden=�6+   $��Hidden=�6R   .��5   
   � $	��622��6   .+�5      � $��33,79,33,462q�6    � RowDefinitions 5      �� 5      $��30 �6$   �� 5      $��30 �6$    � ColumnDefinitions 5      �� 5      $��* �6'   �� 5       $
��1.5* �6'   �� 5!      $��* �6'   �� 5"      $
��1.5* �6'   .+�5$      �� $��Customer Name��6   $��0��5%      $��0��5&      $��0,0,0,0q�5'      $��14(�5(      $��Center=�5)      �� 5*      $��1��6   $��0,0,0,0q�5+      $��0��5,       �� TextWrapping$
 Wrap=�5-      $��TextBox��5.      $��14(�5/       �� TextAlignment$ Center=�50       �� 
IsReadOnly$
 True��51      �� 52      $��Email��6   $��0��53      $��2��54      $��0,0,0,0q�55      $��14(�56      $��Center=�57      �� 58      $��3��6   $��0,0,0,0q�59      $��0��5:      $
 Wrap=�5;      $��TextBox��5<      $��14(�5=      $ Center=�5>      $
 True��5?      �� 5@      $��Phone��6   $��1��5A      $��0��5B      $��0,0,0,0q�5C      $��14(�5D      $��Center=�5E      �� 5F      $��1��6   $��0,0,0,0q�5G      $��1��5H      $
 Wrap=�5I      $��TextBox��5J      $��14(�5K      $ Center=�5L      $
 True��5M      �� 5N      $��Ship Address��6   $��1��5O      $��2��5P      $��0,0,0,0q�5Q      $��14(�5R      $��Center=�5S      �� 5T      $��3��6   $��0,0,0,0q�5U      $��1��5V      $
 Wrap=�5W      $��TextBox��5X      $��14(�5Y      $ Center=�5Z      $
 True��5[      5]      &   System.Windows.Controls.DataGrid  5^      -   5        $��	dataGrid1��5^         
IsReadOnly$
 True��5_         AutoGenerateColumns$ False��5`      $��20,176,20,353q�5a         CanUserAddRows$ False��5d      ��5b      �� *Pizzas+	 �� SelectedItem	 5c      �� *SelectedPizza+
 �� Mode$
 TwoWay=�   Columns 5f      0  *System.Windows.Controls.DataGridTextColumn  5g      ,  &System.Windows.Controls.DataGridColumn   Header$ Pizza��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5i   -   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5h   -   �� *Pizza+ �� 	Converter# [  5i   9     5j      $ Quantity��6-    5k   -   �� *
Quantity+ �� UpdateSourceTrigger$ PropertyChanged=�6q     5l      $ Price��6-   $	 100 5m   -    5n   -   �� *Price+6I      RowDetailsTemplate 5p      �� 5q      .R�5r      �� $��0q�6%   
������� �� Padding$ 10q�5t   %   ._�5u   "   ��  �� Orientation$ Vertical=�6-   .+�5v   &   �� $ 
Horizontal=�61   .+�5w   *   �� $��12(�64   $��
Toppings: ��5x   4   $��Center=�5y   4   �� 5z   *   $��16(�64   
���p�$��Center=�5}   4   ��5|   4   �� *Pizza.Toppings+# [ 5}   4   5~   '   5�   #   5�      5�      5�        5�      $ False��6   $��20,396,315,111q�5�      $
 True��5�      $ False��5�      ��5�      �� *Drinks+	 5�      �� *SelectedDrink+$
 TwoWay=� 5�        5�      $ Drinks��6-   $ * 5�   -    5�   -   �� *
Drink.Name+5�   9     5�      $ Quantity��6-    5�   -   �� *
Quantity+$ PropertyChanged=�6q     5�      $ Price��6-   $ 75 5�   -    5�   -   �� *Price+5�   :   5�        5�      $ False��6   $��315,396,20,111q�5�      $ False��5�      $
 True��5�      ��5�      �� *Sides+	 5�      �� *SelectedSide+$
 TwoWay=� 5�        5�      $ Sides��6-   $ * 5�   -    5�   -   �� *	Side.Name+5�   9     5�      $ Quantity��6-    5�   -   �� *
Quantity+$ PropertyChanged=�6q     5�      $ Price��6-   $ 75 5�   -    5�   -   �� *Price+5�   :   5�      �� 5�      $��Total Amount��6   $
��Left=�5�      $��311,620,0,0q�5�      $	��Top=�5�      $��18(�5�      $
��Bold"�5�      �� 5�      $
��Left=�6   $��442,624,0,0q�5�      $
 Wrap=�5�      $��TextBox��5�      $	��Top=�5�      $	��120��5�      $��18(�5�      $
 True��5�      �� 5�      $��Pizza��6   $
��Left=�5�      $��
25,145,0,0q�5�      $	��Top=�5�      $��60��5�      $
��Bold"�5�      $��16(�5�      �� 5�      $��Drink��6   $
��Left=�5�      $��
25,366,0,0q�5�      $	��Top=�5�      $��60��5�      $��16(�5�      $
��Bold"�5�      �� 5�      $
��Side��6   $
��Left=�5�      $��336,366,0,0q�5�      $	��Top=�5�      $��60��5�      $
��Bold"�5�      $��16(�5�      �� 5�      $
��Back��6   $
��Left=�5�      $��
542,39,0,0q�5�      $	��Top=�5�      $��60��5�      $��25��5�      ���	#FFFFE772��5�      �� *BackCommand+5�      5�      5�      5�      