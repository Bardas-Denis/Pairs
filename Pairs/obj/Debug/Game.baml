   M S B A M L   `   `   `  ����@  <Pairs, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PairsPairs  5   	       
Pairs.Game   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Pairs     5   	     � Title$
  Game��5   	   $	��700��6   $	��700��6#    � WindowStartupLocation$ Manual=�5	   	    � Left$ 50��5
   	   
 � Top$ 50��6    � 
ResizeMode$ NoResize=�5   	   ���#376BCD.��5      �  � RowDefinitions 5   
   �� 5      $	��10* �6   �� 5      $��* �6   .+�5   
   �� -   5        $��FinalMessage��5   "   $��0��6   $;��5Congratulations!! You have passed to the next level!!��66   $��Center=�6s   $��Center=�6�   $��50(�6�   $
��Bold"�6�   $
��Wrap=�6�    �� TextAlignment$ Center=�6�   $y�Hidden=�6�   ��5      �� 5       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 0,1&�67   .��5      � � 5      	 � Color$	 #46FF00��6'   
 � Offset$
 0Q�67   � 5      $	 #B2FA0E��6'   $	
 0.4Q�67   � 5      $	 #FFFF00��6'   $	
 0.8Q�67   5      5       J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         ShadowDepth$ 8Q�5         	Direction$ 0Q�5          Color$ 	DarkGreen��5!         Opacity$	 0.9Q�5"         
BlurRadius$ 10Q�5#      5&      � 5'   
   -   5        $
��game��5'      $��0��6   5)      � 5*   
   $��1��6   .+�5+      �� -   5        $��
backButton��5+   .   
���/���$
��Back��6@   $��18(�6O   $
��Bold"�6]   $	��120��6o   $��40��6{   $��Right=�6�   $��Bottom=�6�   $��7q�6�    � 	Resources 5,       �� 
TargetType �� Property �� Value��%_   '��       �� 5-      " ��6   .�5.      ��  �@��CornerRadius$ 15��69   5/      50      51      �� 52      -   5        $��
saveButton��52   .   
���/���$��	Save game��6@   $��18(�6T   $
��Bold"�6b   $	��120��6t   $��40��6�   $
��Left=�6�   $��Bottom=�6�   $��7q�6�    53      ��%_   '��       �� 54      " ��6   .�55      ��  �@��CornerRadius$ 15��69   56      57      58      �� 59      -   5        $��nextLevelButton��59   .   
���/���$��
Next Level��6E   $��18(�6Z   $
��Bold"�6h   $	��120��6z   $��40��6�   $��Center=�6�   $��Bottom=�6�   $��7q�6�   $y�Hidden=�6�    5:      ��%_   '��       �� 5;      " ��6   .�5<      ��  �@��CornerRadius$ 15��69   5=      5>      5?      5C      5D      5E      