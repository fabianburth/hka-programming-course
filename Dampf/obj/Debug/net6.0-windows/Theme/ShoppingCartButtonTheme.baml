   M S B A M L   `   `   `  ����@  <Dampf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Dampf.MVVM.ViewModelDampf.MVVM.ViewModel  5      W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� BasedOn �� 
TargetType   ShoppingCartButtonTheme �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers P� Property P� Value	 �� Path
 �� RelativeSource �� Mode �� AncestorType�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      0	viewModel"clr-namespace:Dampf.MVVM.ViewModel  5      %�  &	        7d��� 5      8    " d�5      �5   
   �� 5       � �� 5	      �� 5
      " d�6&   .R�5      �� $ 5��6!   $��0,0,4,4q�5   !   #��z��5   !   ._�5      � $��Stretch=�6#   $��Stretch=�5   #   .+�5   "   �� #��z��6,   $��Center=�5   ,   $��Center=�5   ,   $��20(�5   ,   5      5      5      5      �� 5       � ��
 ���� 6+   �� 5       � ��$ 0q�60   �� 5       �@�Cursor$
 Hand��6'    5    
   P� 5!       �@d�	IsChecked$
 TrueY�6+   . �5"      ��  � ��
 � � �6/   �� 5#       � ��$
 🛒��6,   �� 5$       � �� 6,   �� $'	 !DataContext.RemoveFromCartCommand�
 �� $ FindAncestor=�" >��� 5%       � �� 65   �� *Title+5&      P� 5'       �@d�	IsChecked$ FalseY�6+   . �5(      ��  � �� �#8D99AE6/   �� 5)       � ��$
 🗑��6,   �� 5*       � �� 6,   �� $"	 DataContext.AddToCartCommand�
 �� $ FindAncestor=�" >��� 5+       � �� 65   �� *Title+5,      P� 5-       �@J�IsMouseOver$
 True��6-   . �5.      ��  � �� �#BEE6FD6/   5/      51      53      