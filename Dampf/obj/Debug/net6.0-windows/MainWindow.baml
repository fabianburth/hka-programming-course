   M S B A M L   `   `   `  ����@  <Dampf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DampfDampf  5   	   1clr-namespace:Dampf.MVVM.ViewDampf.MVVM.View  5   	   ;"clr-namespace:Dampf.MVVM.ViewModelDampf.MVVM.ViewModel  5   	       Dampf.MainWindow   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Dampf     5   	   .viewclr-namespace:Dampf.MVVM.View     5   	   8	viewModel"clr-namespace:Dampf.MVVM.ViewModel     5   	   $	��600��5
   	   $	��920��6     � WindowStyle$
  None=�5   	    � 
ResizeMode$ CanResizeWithGrip=�5   	   
������  � AllowsTransparency$
 True��5   	    � DataContext 5      (   "Dampf.MVVM.ViewModel.MainViewModel  5   
   .��5      �� -   5        ���#272537 �� CornerRadius$ 20��5      ._�5   
   �  � ColumnDefinitions 5      �� 5      �� 5      $	��256 �6#    � RowDefinitions 5      �� 5      $��28 �6    �� 5      $��50 �6    �� 5       .+�5#      �� $��0��6   $��2��5$      ���#22202f���#272537$��0,0,0,1q�5'      $ 	25,25,0,0��5(      ._�5*      � $��Stretch=�6   .+�5+      �� $��Dampf��6   ���#8D99AE$��8,0,0,0q�5-      $��SemiBold"�5.      �� 50      $��Right=�6!    �� Orientation$ 
Horizontal=�51   !   $��0,0,8,0q�52   !   .+�54      �� -   5        $��20��54   !   $��20��6,   $��_��55   !   
������ $��0q�57   !   
�������$
��Bold"�59   !   $��0,0,0,4q�5:   !   5;   !   �� 5=      -   5        $��20��5=   !   $��20��6,   $	��□��5>   !   
������ $��0q�5@   !   
�������$
��Bold"�5B   !   5C   !   �� 5E      -   5        $��20��5E   !   $��20��6,   $	��✕��5F   !   
������ $��0q�5H   !   
�������$
��Bold"�5J   !   5K   !   5L      5M      5P      �� 5R      $ 
Horizontal=�6   $
��Left=�5S      $��1��5T      $��0��5U      .+�5W      	�  	� 	GroupName$
 Menu��6   $��Laden��5X      $	��128��5Y      
�������$��16(�5[         MenuButtonTheme#��[  5\      	 d� 	IsChecked$
	 TrueY�5]      ��5^      �� *ShopViewCommand+	� 5`      $
 Menu��6   $��
Bibliothek��5a      $	��128��5b      
�������$��16(�5d      #��[  5e      ��5f      �� *LibraryViewCommand+5g      �� 5i      $ 
Horizontal=�6   $��Right=�5j      $��1��5k      $��1��5l      .+�5n      	� $
 Menu��6   $	��128��5p      
�������$��16(�5r      #��[  5s      ��5o      �� *&$ShopViewModel.Shop.User.BalanceValue+��5t      �� *BalanceViewCommand+�� 5w      
�������$��16(�5y      $	��128��5z      $��Center=�5{      
 �� TextAlignment$
 Center=�5|      ��5w      �� *ShopViewModel.Shop.User.Name+5|      5~      �� 5�      $��2��6   $��2��5�      ��5�      �� *CurrentView+5�      5�      5�      