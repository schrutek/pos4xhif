   M S B A M L   `   `   `  ����T  PSpg.TicketShop.WpfBackEnd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:Spg.TicketShop.WpfBackEnd.ViewModels$Spg.TicketShop.WpfBackEnd.ViewModels  5   	   *    $Spg.TicketShop.WpfBackEnd.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Dlocal2clr-namespace:Spg.TicketShop.WpfBackEnd.ViewModels     5   	     � Title$  
MainWindow��5   	   $	��600��6   $
��1200��6)    � 	Resources 5
         
odpVmEvent S� 
ObjectType2   ,Spg.TicketShop.WpfBackEnd.ViewModels.VmEvent��%'   &	        S� 5   
   "  60   6V   5      .��5      �  � DataContext 6   ��  �� Source# [   � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $��* �6   6)    � ColumnDefinitions 5   
   �� 5      $��1* �6   6,   �� 5      $��1* �6   6,   �� 5      $��1* �6   6,   .+�5   
   �� $��0��6   $��0��6   $��10q�6K   $��15q�6X   ��6/   ��  �� Path$ EMail�6f   �� 5   
   $��0��6   $��1��6   $��10q�6N   $��15q�6[   ��6/   �� $ Password�6i   �� 5   
   $��0��6   $��2��6"    �� Orientation$ 
Horizontal=�62   .+�5      �� $��Sign In��6   $��10q�6'   $��15q�64   $�� ��5    1   ��6   �� $ SignIn�5!      �� 5"      $��0��6   $��2��6"   $��Reload Events��62   $��10q�6J   $��15q�6W   $�� ��5#   7   	 � ToolTip$A	 ;Dienst nur zur demonstration wenn man nicht angemeldet ist.��6K   ��6   �� $ ReloadEvents�5$      5%      �� 5'   
   $��1��6   $��0��6!   $��Events��61   $��15q�6?   6M   �� 5(   
   $��1��6   $��1��6!   $��Termine��61   $��15q�6@   6N   �� 5)   
   $��1��6   $��2��6!   $��Kontingente��61   $��15q�6D   6R   �� 5+   
   $��2��6   $��0��6"   $ 
Horizontal=�62   .+�5,      �� $��5q�6   $��15, 5, 1, 5q�6!   ��5-      �� $ 
UpdateItem���5.      �� 
 �� ElementName$
 	lstEvents��$ SelectedItem�.��6W   Neu6\   �� 5/      $��5q�6   $��
1, 5, 1, 5q�6!   $
��Auto��65   ��50      �� $ 
UpdateItem���51      �� $
 	lstEvents��$ SelectedItem�.��6W   
Bearbeiten6c   �� 52      $��5q�6   $��1, 5, 15, 5q�6!   ��53      �� $ 
UpdateItem���54      �� $
 	lstEvents��$ SelectedItem�.��6W   
Löschen6`   55      �� 57   
   $��2��6   $��1��6"   $ 
Horizontal=�62   .+�58      �� $��5q�6   $��15, 5, 1, 5q�6!   ��59      �� $ 
UpdateItem���5:      �� $
 lstShows��$ SelectedItem�.��6V   Neu6[   �� 5;      $��5q�6   $��
1, 5, 1, 5q�6!   $
��Auto��65   ��5<      �� $ 
UpdateItem���5=      �� $
 lstShows��$ SelectedItem�.��6V   
Bearbeiten6b   �� 5>      $��5q�6   $��1, 5, 15, 5q�6!   ��5?      �� $ 
UpdateItem���5@      �� $
 lstShows��$ SelectedItem�.��6V   
Löschen6_   5A      �� 5C   
   -   5         ��Name$ 	lstEvents��5C   /   $��3��6   $��0��6   $��15, 0, 15, 50q�6B    �� SelectedValuePath$ Id��5E      ��5D      �� $ Events���5F      �� 5G      .R�5H      �� $��5q�6    �� 5I      �6   �� $
 Name�6;   5J      5K       �� SelectedValue 5M      �� 5N      $ EventSelected�6    �� BindsDirectlyToSource .  �� Mode$ OneWayToSource=�5P      5R      �� 5T   
   -   5        $ lstShows��5T   /   $��3��6   $��1��6   $��15, 0, 15, 50q�6A   $ Id��5V      ��5U      �� $ ShowsByEvent���5W      �� 5X      .R�5Y      �� $��5q�6    �� 5Z      $
��Bold"�6   �60   �� $ Start� �� StringFormat$ d��6]    (�� 5[      �6   �� $ Start�$ t��6L    - �� 5\      �6    �� $	 End�$ t��6K   ) �� 5]      $
��Bold"�6   $�CheckIn:��60   6B    �� 5^      �6   �� $ CheckIn�$ t��6N   5_      5`      5b      5c      5e      