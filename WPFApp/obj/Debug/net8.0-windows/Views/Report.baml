   M S B A M L   `   `   `  ����A  =WPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WPFApp.ViewsWPFApp.Views  5      3clr-namespace:WPFApp.UtilitiesWPFApp.Utilities  5          WPFApp.Views.Report   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:WPFApp.Views     5      -cvclr-namespace:WPFApp.Utilities     5        � 	Resources  5      *   $WPFApp.Utilities.TotalPriceConverter   TotalPriceConverter��%   &	          5   
   6!   5      .��5      � 
�������.+�5   
   �� $
��Left=�6   $��	33,26,0,0q�5      $
��Wrap=�5      $��Report��5      $	��Top=�5      $��36(�5      $
��Bold"�5      (  "System.Windows.Controls.DatePicker  5   
   $
��Left=�6   $��	75,79,0,0q�5      $	��Top=�5      $	��134��5         SelectedDate 5      �� *	StartDate+ �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   $
��Left=�6   $��	33,79,0,0q�5      $
��Wrap=�5      $
��From��5      $	��Top=�5      $��16(�5       �� 5!   
   $
��Left=�6   $��
226,80,0,0q�5"      $
��Wrap=�5#      $��To��5$      $	��Top=�5%      $��16(�5&        5'   
   $
��Left=�6   $��
247,80,0,0q�5(      $	��Top=�5)      $	��134��5*       5+      �� *	EndDate+$ PropertyChanged=��� 5,   
   $��Search��6   $
��Left=�5-      $��
402,80,0,0q�5.      $	��Top=�5/      $��64��50      $��16(�51      ��52      �� *Filter+&   System.Windows.Controls.DataGrid  53   
   $��10,110,10,61q�54         AutoGenerateColumns$ False��55         CanUserAddRows$ False��56         
IsReadOnly$
 True��57      ��53      �� *	Reports+   Columns 58      0  *System.Windows.Controls.DataGridTextColumn  59      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5;   %   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 5:   %   �� *Id+5;   1     5<      $
 Date��6%   $ * 5>   %   	 5=   %   �� *	OrderDate+5>   1     5?      $
 Time��6%   $ * 5A   %   	 5@   %   �� *	OrderTime+5A   1     5B      $ Shipping Address��6%   $ 2* 5D   %   	 5C   %   �� *ShippingAddress+5D   2     5E      $ Customer ID��6%   $ * 5G   %   	 5F   %   �� *
CustomerId+5G   1     5H      $ Total Price��6%   $ * 5J   %   	 5I   %   �� *.+
 �� 	Converter#
 [  5J   1   5L      �� 5M   
   $��Total Amount��6   $
��Left=�5N      $��385,556,0,0q�5O      $	��Top=�5P      �� 5Q   
   $
��Left=�6   $��466,561,0,0q�5R      $
��Wrap=�5S      $	��Top=�5T      $��16(�5U      ��5V      �� *TotalOrderPrice+$ PropertyChanged=�5Y      5Z      